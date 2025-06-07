namespace pjtUserPermsMgr;

public static class Operations
{
    public static List<string> BinarySearch(string searchTerm, Dictionary<string, HashSet<string>> permissionsDict, bool isUserSearch)
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
    
    public static List<string> LinearSearch(string searchTerm, Dictionary<string, HashSet<string>> permissionsDict)
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
    
    // Bubble Sort - O(n²)
    public static void BubbleSort(List<string> items)
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
    public static void QuickSort(List<string> items, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(items, low, high);
            QuickSort(items, low, partitionIndex - 1);
            QuickSort(items, partitionIndex + 1, high);
        }
    }

    public static int Partition(List<string> items, int low, int high)
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
    public static List<string> MergeSort(List<string> items)
    {
        if (items.Count <= 1) return items;

        int mid = items.Count / 2;
        var left = items.GetRange(0, mid);
        var right = items.GetRange(mid, items.Count - mid);

        left = MergeSort(left);
        right = MergeSort(right);

        return Merge(left, right);
    }

    public static List<string> Merge(List<string> left, List<string> right)
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
    
    public static void RefreshPermissionsList( ComboBox cmbPerms, Dictionary<string, HashSet<string>> permsDictionary )
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
}