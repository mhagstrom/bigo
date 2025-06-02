using System.Diagnostics;

namespace pjtUserPermsMgr;

public class OperationTimer : IDisposable
{
    private readonly string _operationName;
    private readonly int _operationItems;
    private readonly Stopwatch _stopwatch;
    private readonly string _logFilePath;
    private static readonly object _lockObject = new object();

    public OperationTimer(string operationName, int operationItems)
    {
        _operationName = operationName;
        _operationItems = operationItems;
        _stopwatch = Stopwatch.StartNew();
        _logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "operation_timings.log");
    }

    public void Dispose()
    {
        _stopwatch.Stop();
        var elapsed = _stopwatch.Elapsed;
        var logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss.fff} - {_operationName} with {_operationItems} items took {elapsed.TotalMilliseconds:F2}ms";
        
        lock (_lockObject)
        {
            File.AppendAllLines(_logFilePath, new[] { logMessage });
        }
    }
}


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
        RefreshPermissionsList();
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
        RefreshPermissionsList();
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
        
        RefreshPermissionsList();
        MessageBox.Show($"Removed permission type: {selectedPermission}\n" +
                       $"Users affected: {affectedUsers.Count}");
    }

    private void RefreshPermissionsList()
    {
        var selectedRole = cmbPerms.SelectedItem?.ToString();
        cmbPerms.Items.Clear();
        cmbPerms.Items.AddRange(permsDictionary.Keys.ToArray());
        
        if (!string.IsNullOrEmpty(selectedRole) && permsDictionary.ContainsKey(selectedRole))
        {
            cmbPerms.SelectedItem = selectedRole;
        }
        else
        {
            cmbPerms.SelectedIndex = 0;
        }

        foreach (KeyValuePair<string, HashSet<string>> element in permsDictionary)
        {
            List<string> users = element.Value.ToList();
            
            Console.WriteLine($"{element.Key}: {users}");
        }
    }

    private void BtnAddUserClick(object sender, EventArgs e)
    {
        string username = txbUsername.Text.Trim();
        if (!string.IsNullOrEmpty(username) && whitelist.Add(username))
        {
            permsDictionary["NoPerms"].Add(username);
            MessageBox.Show($"Added {username} to whitelist with NoPerms role.");
            RefreshPermsList();
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
            RefreshPermsList();
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
            
                RefreshPermsList();
            }
        }
    }

   
    /*
    private void BtnSearchClick(object sender, EventArgs e) 
        // Binary Search - O(log n) - requires sorted array , Linear Search - O(n) time complexity
    {
        string searchUsername = txbUsername.Text.Trim();
        string searchPermission = cmbPerms.SelectedItem?.ToString();
        lsbResults.Items.Clear();

        if (string.IsNullOrEmpty(searchUsername) && string.IsNullOrEmpty(searchPermission))
        {
            MessageBox.Show("Please enter a username or select a permission to search.");
            return;
        }

        if (!string.IsNullOrEmpty(searchUsername))
        {
            if (cmbSearchMethod.SelectedItem.ToString() == "Linear Search")
            {
                
                var userPermissions = new List<string>();
                foreach (var permission in permsDictionary.Keys)
                {
                    if (permsDictionary[permission].Contains(searchUsername))
                    {
                        userPermissions.Add(permission);
                    }
                }

                if (userPermissions.Count > 0)
                {
                    lsbResults.Items.Add($"Permissions for user '{searchUsername}' (using Linear Search):");
                    foreach (var permission in userPermissions)
                    {
                        lsbResults.Items.Add($"- {permission}");
                    }
                }
                else
                {
                    lsbResults.Items.Add($"No permsDictionary found for user '{searchUsername}'");
                }
            }
            else
            {
                var allPermissionUsers = new List<(string Permission, string User)>();
                foreach (var permission in permsDictionary)
                {
                    foreach (var user in permission.Value)
                    {
                        allPermissionUsers.Add((permission.Key, user));
                    }
                }
                
                allPermissionUsers = allPermissionUsers
                    .OrderBy(x => x.User)
                    .ToList();
                
                int left = 0;
                int right = allPermissionUsers.Count - 1;
                bool found = false;

                while (left <= right)
                {
                    int mid = left + (right - left) / 2;
                    int comparison = string.Compare(allPermissionUsers[mid].User, searchUsername);

                    if (comparison == 0)
                    {
                        found = true;
                        var userPermissions = allPermissionUsers
                            .Where(x => x.User == searchUsername)
                            .Select(x => x.Permission)
                            .Distinct()
                            .ToList();

                        lsbResults.Items.Add($"Permissions for user '{searchUsername}' (using Binary Search):");
                        foreach (var permission in userPermissions)
                        {
                            lsbResults.Items.Add($"- {permission}");
                        }
                        break;
                    }

                    if (comparison < 0)
                        left = mid + 1;
                    else
                        right = mid - 1;
                }

                if (!found)
                {
                    lsbResults.Items.Add($"No permsDictionary found for user '{searchUsername}'");
                }
            }
        }
        else if (!string.IsNullOrEmpty(searchPermission))
        {
            if (permsDictionary.TryGetValue(searchPermission, out var users))
            {
                if (cmbSearchMethod.SelectedItem.ToString() == "Linear Search")
                {
                    // Linear Search - O(n)
                    if (users.Count > 0)
                    {
                        lsbResults.Items.Add($"Users with permission '{searchPermission}' (using Linear Search):");
                        foreach (var user in users)
                        {
                            lsbResults.Items.Add($"- {user}");
                        }
                    }
                    else
                    {
                        lsbResults.Items.Add($"No users found with permission '{searchPermission}'");
                    }
                }
                else
                {
                    var sortedUsers = users.OrderBy(x => x).ToList();

                    if (sortedUsers.Count > 0)
                    {
                        lsbResults.Items.Add($"Users with permission '{searchPermission}' (using Binary Search):");
                        foreach (var user in sortedUsers)
                        {
                            lsbResults.Items.Add($"- {user}");
                        }
                    }
                    else
                    {
                        lsbResults.Items.Add($"No users found with permission '{searchPermission}'");
                    }
                }
            }
            else
            {
                lsbResults.Items.Add($"Permission '{searchPermission}' not found");
            }
        }

        if (lsbResults.Items.Count == 0)
        {
            lsbResults.Items.Add("No results found");
        }
    }
    */

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
        bool isBinarySearchType = cmbSearchMethod.SelectedItem.ToString() == "Binary Search";
        if (!string.IsNullOrEmpty(searchUsername))
        {
            if (isBinarySearchType)
            {
                using (var timer = new OperationTimer("Binary Search of Users", permsDictionary.Count))
                {
                    searchResult = BinarySearch(searchUsername, permsDictionary, true);
                }
            }
            else
            {
                using (var timer = new OperationTimer("Linear Search of Users", permsDictionary.Count))
                {
                    searchResult = LinearSearch(searchUsername, permsDictionary);
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
                    searchResult = BinarySearch(searchPermission, permsDictionary, false);
                }
            }
            else
            {
                using (var timer = new OperationTimer("Linear Search of Permissions", permsDictionary.Count))
                {
                    searchResult = LinearSearch(searchPermission, permsDictionary);
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
    
    private List<string> BinarySearch(string searchTerm, Dictionary<string, HashSet<string>> permissionsDict, bool isUserSearch)
    {
        List<string> searchResult = new List<string>();
        List<(string Permission, string User)> tupleAllUserPerms = new List<(string Permission, string User)>();
        foreach (var permission in permissionsDict)
        {
            foreach (var user in permission.Value)
            {
                tupleAllUserPerms.Add((permission.Key, user));
            }
        }
        
        tupleAllUserPerms = tupleAllUserPerms
            .OrderBy(x => isUserSearch ? x.User : x.Permission)
            .ToList();
                
        int left = 0;
        int right = tupleAllUserPerms.Count - 1;
        bool found = false;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            int comparison = isUserSearch ? String.Compare(tupleAllUserPerms[mid].User, searchTerm) : String.Compare(tupleAllUserPerms[mid].Permission, searchTerm);

            if (comparison == 0)
            {
                found = true;
                var userPermissions = tupleAllUserPerms
                    .Where(x => isUserSearch ? x.User == searchTerm : x.Permission == searchTerm)
                    .Select(x => isUserSearch ? x.Permission : x.User)
                    .Distinct()
                    .ToList();

                //searchResult.Add($"Permissions for user '{searchTerm}' (using Binary Search):");
                foreach (var permission in userPermissions)
                {
                    searchResult.Add(permission);
                }
                break;
            }

            if (comparison < 0)
                left = mid + 1;
            else
                right = mid - 1;
        }

        if (!found)
        {
            //searchResult.Add($"No permsDictionary found for user '{searchTerm}'");
        }
        
        return searchResult;
    }
    
    private List<string> LinearSearch(string searchTerm, Dictionary<string, HashSet<string>> permissionsDict)
    {
        List<string> searchResult = new List<string>();
        foreach (var permission in permissionsDict)
        {
            if (permission.Value.Contains(searchTerm))
            {
                searchResult.Add(permission.Key);
            }
            
            else if (permission.Key == searchTerm)
            {
                permissionsDict.TryGetValue(searchTerm, out var users);
                searchResult = users.ToList();
            }
        }
        return searchResult;
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
                    BubbleSort(items); // O(n²)
                }

                break;
            case "Quick Sort":
                using (var timer = new OperationTimer("Quick Sort", items.Count))
                {
                    QuickSort(items, 0, items.Count - 1); // O(n log n)
                }

                break;
            case "Merge Sort":
                using (var timer = new OperationTimer("Merge Sort", items.Count))
                {
                    items = MergeSort(items); // O(n log n)
                }

                break;
        }

        lsbResults.Items.Clear();
        lsbResults.Items.AddRange(items.ToArray());
    }

    // Bubble Sort - O(n²)
    private void BubbleSort(List<string> items)
    {
        int n = items.Count;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (string.Compare(items[j], items[j + 1]) > 0)
                {
                    var temp = items[j];
                    items[j] = items[j + 1];
                    items[j + 1] = temp;
                }
            }
        }
    }

    // Quick Sort - O(n log n)
    private void QuickSort(List<string> items, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(items, low, high);
            QuickSort(items, low, partitionIndex - 1);
            QuickSort(items, partitionIndex + 1, high);
        }
    }

    private int Partition(List<string> items, int low, int high)
    {
        string pivot = items[high];
        int i = low - 1;

        for (int j = low; j < high; j++)
        {
            if (string.Compare(items[j], pivot) <= 0)
            {
                i++;
                var temp = items[i];
                items[i] = items[j];
                items[j] = temp;
            }
        }

        var temp1 = items[i + 1];
        items[i + 1] = items[high];
        items[high] = temp1;

        return i + 1;
    }

    // Merge Sort - O(n log n)
    private List<string> MergeSort(List<string> items)
    {
        if (items.Count <= 1) return items;

        int mid = items.Count / 2;
        var left = items.GetRange(0, mid);
        var right = items.GetRange(mid, items.Count - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    private List<string> Merge(List<string> left, List<string> right)
    {
        var result = new List<string>();
        int leftIndex = 0, rightIndex = 0;

        while (leftIndex < left.Count && rightIndex < right.Count)
        {
            if (string.Compare(left[leftIndex], right[rightIndex]) <= 0)
            {
                result.Add(left[leftIndex]);
                leftIndex++;
            }
            else
            {
                result.Add(right[rightIndex]);
                rightIndex++;
            }
        }

        while (leftIndex < left.Count)
        {
            result.Add(left[leftIndex]);
            leftIndex++;
        }

        while (rightIndex < right.Count)
        {
            result.Add(right[rightIndex]);
            rightIndex++;
        }

        return result;
    }

    private void RefreshPermsList()
    {
        string selectedRole = cmbPerms.SelectedItem?.ToString();
        lsbPerms.Items.Clear();

        if (!string.IsNullOrEmpty(selectedRole) && permsDictionary.ContainsKey(selectedRole))
        {
            foreach (var user in permsDictionary[selectedRole])
            {
                lsbPerms.Items.Add(user);
            }
        }
    }

    private void permissionListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (lsbPerms.SelectedItem != null)
        {
            txbUsername.Text = lsbPerms.SelectedItem.ToString();
        }
    }

	private void generateUsersButton_Click(object sender, EventArgs e)
	{
		int userCount = (int)nudUserCount.Value;
		int existingUsers = whitelist.Count;

		for (int i = 0; i < userCount; i++)
		{
			string newUser = $"User_{existingUsers + i}";
			whitelist.Add(newUser);
			permsDictionary["NoPerms"].Add(newUser);
		}

		RefreshPermsList();
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

		RefreshPermsList();
        
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

    RefreshPermissionsList();
    
    MessageBox.Show($"Generated {permCount} new permsDictionary.\n" +
                   $"Total permsDictionary: {permsDictionary.Count}\n" +
                   $"(excluding NoPerms: {permsDictionary.Count - 1})");
}
}