using System.Diagnostics;

namespace pjtUserPermsMgr;

public partial class MainForm : Form
{
    private HashSet<string> whitelist = new HashSet<string>();
    private Dictionary<string, HashSet<string>> permsDictionary = new Dictionary<string, HashSet<string>>
    {
        {"NoPerms", new HashSet<string>()}
    };

	private readonly Random random = new Random();

    public MainForm()
    {
        InitializeComponent();
        Operations.RefreshPermissionsList(cmbPerms, permsDictionary);
    }

    private void addPermissionButton_Click(object sender, EventArgs e)
    {
        string newPermission = txbNewPermission.Text.Trim();
        
        if (string.IsNullOrEmpty(newPermission))
        {
            MessageBox.Show("Permission name cannot be empty.");
            return;
        }

        //StringComparison OrdinalIgnoreCase is for case-insensitive comparison to ensure no usermade NoPerms role can exist.
        if (newPermission.Equals("NoPerms", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Cannot add 'NoPerms' as it is a reserved permission type.");
            return;
        }

        if (permsDictionary.ContainsKey(newPermission))
        {
            MessageBox.Show("This permission already exists.");
            return;
        }

        permsDictionary.Add(newPermission, new HashSet<string>());
        Operations.RefreshPermissionsList( cmbPerms, permsDictionary );
        MessageBox.Show($"Added new permission type: {newPermission}");
    }

    private void DeletePermissionButton_Click(object sender, EventArgs e)
    {
        string selectedPermission = cmbPerms.SelectedItem?.ToString();

        if (string.IsNullOrEmpty(selectedPermission))
        {
            MessageBox.Show("Please select a permission to remove.");
            return;
        }

        if (selectedPermission.Equals("NoPerms", StringComparison.OrdinalIgnoreCase))
        {
            MessageBox.Show("Cannot remove 'NoPerms' as it is a required permission type.");
            return;
        }
        
        var affectedUsers = permsDictionary[selectedPermission]
            .Where(user => permsDictionary
                .Where(p => p.Key != "NoPerms" && p.Key != selectedPermission)
                .All(p => !p.Value.Contains(user)))
            .ToList();
        
        foreach (var user in affectedUsers)
        {
            permsDictionary["NoPerms"].Add(user);
        }
        
        permsDictionary.Remove(selectedPermission);
        
        Operations.RefreshPermissionsList( cmbPerms, permsDictionary );
        MessageBox.Show($"Removed permission type: {selectedPermission}\n" +
                       $"Users affected: {affectedUsers.Count}");
    }

    private void BtnAddUserClick(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        if (!string.IsNullOrEmpty(username) && whitelist.Add(username))
        {
            permsDictionary["NoPerms"].Add(username);
            MessageBox.Show($"Added {username} to whitelist with NoPerms role.");
        }
    }

    private void BtnAssignPermClick(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        string role = cmbPerms.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(username) && permsDictionary.ContainsKey(role))
        {
            if (role != "NoPerms")
            {
                permsDictionary["NoPerms"].Remove(username);
            }
        
            permsDictionary[role].Add(username);
            MessageBox.Show($"Assigned role {role} to {username}.");
        }
    }

    private void BtnUnassignPermClick(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        string role = cmbPerms.SelectedItem?.ToString();

        if (!string.IsNullOrEmpty(username) && permsDictionary.ContainsKey(role))
        {
            if (permsDictionary[role].Remove(username))
            {
                bool hasOtherRoles = permsDictionary
                    .Where(p => p.Key != "NoPerms")
                    .Any(p => p.Value.Contains(username));
                
                if (!hasOtherRoles)
                {
                    permsDictionary["NoPerms"].Add(username);
                    MessageBox.Show($"Removed role {role} from {username}. User now has NoPerms role.");
                }
                else
                {
                    MessageBox.Show($"Removed role {role} from {username}.");
                }
                //add something here
            }
        }
    }

    private void BtnSearchClick(object sender, EventArgs e)
        // Binary Search - O(log n) - requires sorted array , Linear Search - O(n) time complexity
    {
        List<string> searchResult = new List<string>();
        string searchUsername = txbUsername.Text.Trim();
        string searchPermission = cmbPerms.SelectedItem?.ToString();
        string searchTerm = string.Empty;
        lsbResults.Items.Clear();

        if (string.IsNullOrEmpty(searchUsername) && string.IsNullOrEmpty(searchPermission))
        {
            MessageBox.Show("Please enter a username or select a permission to search.");
            return;
        }

        Debug.Assert(cmbSearchMethod.SelectedItem != null, "cmbSearchMethod.SelectedItem != null");
        bool isBinarySearchType = cmbSearchMethod.SelectedItem.ToString() == "Binary Search";
        if (!string.IsNullOrEmpty(searchUsername))
        {
            if (isBinarySearchType)
            {
                using (var timer = new OperationTimer("Binary Search of Users", permsDictionary.Count))
                {
                    searchResult = Operations.BinarySearch(searchUsername, permsDictionary, true);
                }
            }
            else
            {
                using (var timer = new OperationTimer("Linear Search of Users", permsDictionary.Count))
                {
                    searchResult = Operations.LinearSearch(searchUsername, permsDictionary);
                }
            }
            searchTerm = searchUsername;
        }

        if (string.IsNullOrEmpty(searchUsername))
        {
            if (isBinarySearchType)
            {
                using (var timer = new OperationTimer("Binary Search of Permissions", permsDictionary.Count))
                {
                    searchResult = Operations.BinarySearch(searchPermission, permsDictionary, false);
                }
            }
            else
            {
                using (var timer = new OperationTimer("Linear Search of Permissions", permsDictionary.Count))
                {
                    searchResult = Operations.LinearSearch(searchPermission, permsDictionary);
                }
                
            }
            searchTerm = searchPermission;
        }
        
        if (searchResult.Count > 0)
        {
            lsbResults.Items.Add($"Results for '{searchTerm}' (using {cmbSearchMethod.SelectedItem.ToString()}):");
            foreach (var result in searchResult)
            {
                lsbResults.Items.Add($" - {result}");
            }
        }
        
    }

    private void BtnUserPermsClick(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        if (string.IsNullOrEmpty(username)) return;

        var userRoles = new List<string>();
        
        // O(n)
        foreach (var role in permsDictionary)
        {
            if (role.Value.Contains(username))
            {
                userRoles.Add(role.Key);
            }
        }

        lsbResults.Items.Clear();
        if (userRoles.Count > 0)
        {
            foreach (var role in userRoles)
            {
                lsbResults.Items.Add(role);
            }
        }
        else
        {
            lsbResults.Items.Add("User has no roles");
        }
    }

    private void BtnSortClick(object sender, EventArgs e)
    {
        var items = new List<string>();
        foreach (var item in lsbResults.Items)
        {
            items.Add(item.ToString());
        }

        switch (cmbSortMethod.SelectedItem.ToString())
        {
            case "Bubble Sort":
                using (var timer = new OperationTimer("Bubble Sort", items.Count))
                {
                    Operations.BubbleSort(items); // O(n²)
                }

                break;
            case "Quick Sort":
                using (var timer = new OperationTimer("Quick Sort", items.Count))
                {
                    Operations.QuickSort(items, 0, items.Count - 1); // O(n log n)
                }

                break;
            case "Merge Sort":
                using (var timer = new OperationTimer("Merge Sort", items.Count))
                {
                    items = Operations.MergeSort(items); // O(n log n)
                }

                break;
        }

        lsbResults.Items.Clear();
        lsbResults.Items.AddRange(items.ToArray());
    }

	private void generateUsersButton_Click(object sender, EventArgs e)
	{
		int userCount = (int)nudUserCount.Value;
		int existingUsers = whitelist.Count;
        
        if (userCount < nudUserCount.Minimum + 1 || userCount > nudUserCount.Maximum - 1)
        {
            MessageBox.Show("Invalid number of users. Must be between " +
                            $"{nudUserCount.Minimum} and {nudUserCount.Maximum}.");
            return;
        }
        
		for (int i = 0; i < userCount; i++)
		{
			string newUser = $"User_{existingUsers + i}";
			whitelist.Add(newUser);
			permsDictionary["NoPerms"].Add(newUser);
		}

		//add probably the same something here
		MessageBox.Show($"Generated {userCount} new users.\nTotal users: {whitelist.Count}");
	}

	private void randomizePermsButton_Click(object sender, EventArgs e)
	{
		if (whitelist.Count == 0)
		{
			MessageBox.Show("No users to assign permsDictionary to.");
			return;
		}
        
		var availablePerms = permsDictionary.Keys
			.Where(p => p != "NoPerms")
			.ToList();

		if (availablePerms.Count == 0)
		{
			MessageBox.Show("No permsDictionary available to assign (other than NoPerms).");
			return;
		}
        
		foreach (var perm in permsDictionary.Values)
		{
			perm.Clear();
		}

		var users = whitelist.ToList();
        
		foreach (var user in users)
		{
			double randomValue = random.NextDouble();
			int numPermsToAssign = (int)(Math.Log(1 - randomValue) * -8.0);
			numPermsToAssign = Math.Min(numPermsToAssign, availablePerms.Count);

			if (numPermsToAssign == 0)
			{
				permsDictionary["NoPerms"].Add(user);
				continue;
			}
            
			var shuffledPerms = availablePerms.OrderBy(x => random.Next()).Take(numPermsToAssign);
			foreach (var perm in shuffledPerms)
			{
				permsDictionary[perm].Add(user);
			}
            
            permsDictionary = permsDictionary
                .OrderBy(x => random.Next())
                .ToDictionary(x => x.Key, x => x.Value);
        }

		//again same something here
        
		var stats = whitelist
			.Select(user => permsDictionary
				.Count(p => p.Value.Contains(user) && p.Key != "NoPerms"))
			.GroupBy(count => count)
			.OrderBy(g => g.Key)
			.Select(g => $"\n{g.Count()} users have {g.Key} permission(s)")
			.ToList();

		MessageBox.Show($"Randomized permsDictionary for all users." +
					   $"\n\nDistribution:{string.Join("", stats)}");
	}

private void generatePermissionsButton_Click(object sender, EventArgs e)
{
    int permCount = (int)nudPermCount.Value;
    int existingPerms = permsDictionary.Count;

    if (permCount < nudPermCount.Minimum + 1 || permCount > nudPermCount.Maximum - 1)
    {
        MessageBox.Show("Invalid number of permissions. Must be between " +
                        $"{nudPermCount.Minimum} and {nudPermCount.Maximum}.");
        return;
    }

    int startNumber = permsDictionary.Keys
        .Where(p => p.StartsWith("Perm_"))
        .Select(p => 
        {
            if (int.TryParse(p.Substring(5), out int num))
                return num;
            return -1;
        })
        .DefaultIfEmpty(-1)
        .Max() + 1;

    for (int i = 0; i < permCount; i++)
    {
        string newPerm = $"Perm_{startNumber + i}";
        if (!permsDictionary.ContainsKey(newPerm))
        {
            permsDictionary.Add(newPerm, new HashSet<string>());
        }
    }

    Operations.RefreshPermissionsList( cmbPerms, permsDictionary );
    
    MessageBox.Show($"Generated {permCount} new permsDictionary.\n" +
                   $"Total permsDictionary: {permsDictionary.Count}\n" +
                   $"(excluding NoPerms: {permsDictionary.Count - 1})");
}
}