namespace pjtUserPermsMgr;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;
    
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        txbUsername = new System.Windows.Forms.TextBox();
        cmbRoles = new System.Windows.Forms.ComboBox();
        lsbPerms = new System.Windows.Forms.ListBox();
        btnAddUser = new System.Windows.Forms.Button();
        btnAssignRole = new System.Windows.Forms.Button();
        btnRemoveRole = new System.Windows.Forms.Button();
        lblUsername = new System.Windows.Forms.Label();
        lblRole = new System.Windows.Forms.Label();
        lblPerms = new System.Windows.Forms.Label();
        btnSearch = new System.Windows.Forms.Button();
        btnUserRoles = new System.Windows.Forms.Button();
        btnSort = new System.Windows.Forms.Button();
        lblSearchResults = new System.Windows.Forms.Label();
        lsbResults = new System.Windows.Forms.ListBox();
        cmbSortMethod = new System.Windows.Forms.ComboBox();
        cmbSearchMethod = new System.Windows.Forms.ComboBox();
        lblSearchType = new System.Windows.Forms.Label();
        lblNewPermission = new System.Windows.Forms.Label();
        txbNewPermission = new System.Windows.Forms.TextBox();
        btnAddPermission = new System.Windows.Forms.Button();
        btnRemovePermission = new System.Windows.Forms.Button();
        nudUserCount = new System.Windows.Forms.NumericUpDown();
        btnGenerateUsers = new System.Windows.Forms.Button();
        btnRandomizePerms = new System.Windows.Forms.Button();
        lblUserCount = new System.Windows.Forms.Label();
        nudPermCount = new System.Windows.Forms.NumericUpDown();
        btnGeneratePerms = new System.Windows.Forms.Button();
        lblPermCount = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)nudUserCount).BeginInit();
        ((System.ComponentModel.ISupportInitialize)nudPermCount).BeginInit();
        SuspendLayout();
        // 
        // txbUsername
        // 
        txbUsername.Location = new System.Drawing.Point(93, 12);
        txbUsername.MinimumSize = new System.Drawing.Size(200, 27);
        txbUsername.Name = "txbUsername";
        txbUsername.Size = new System.Drawing.Size(200, 27);
        txbUsername.TabIndex = 12;
        // 
        // cmbRoles
        // 
        cmbRoles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbRoles.Location = new System.Drawing.Point(93, 49);
        cmbRoles.MinimumSize = new System.Drawing.Size(200, 0);
        cmbRoles.Name = "cmbRoles";
        cmbRoles.Size = new System.Drawing.Size(200, 28);
        cmbRoles.TabIndex = 14;
        // 
        // lsbPerms
        // 
        lsbPerms.Location = new System.Drawing.Point(12, 115);
        lsbPerms.MinimumSize = new System.Drawing.Size(281, 244);
        lsbPerms.Name = "lsbPerms";
        lsbPerms.Size = new System.Drawing.Size(281, 244);
        lsbPerms.TabIndex = 16;
        // 
        // btnAddUser
        // 
        btnAddUser.AutoSize = true;
        btnAddUser.Location = new System.Drawing.Point(309, 11);
        btnAddUser.MinimumSize = new System.Drawing.Size(94, 29);
        btnAddUser.Name = "btnAddUser";
        btnAddUser.Size = new System.Drawing.Size(94, 30);
        btnAddUser.TabIndex = 17;
        btnAddUser.Text = "Add User";
        btnAddUser.Click += BtnAddUserClick;
        // 
        // btnAssignRole
        // 
        btnAssignRole.AutoSize = true;
        btnAssignRole.Location = new System.Drawing.Point(309, 48);
        btnAssignRole.MinimumSize = new System.Drawing.Size(104, 29);
        btnAssignRole.Name = "btnAssignRole";
        btnAssignRole.Size = new System.Drawing.Size(104, 30);
        btnAssignRole.TabIndex = 18;
        btnAssignRole.Text = "Assign Role";
        btnAssignRole.Click += BtnAssignRoleClick;
        // 
        // btnRemoveRole
        // 
        btnRemoveRole.AutoSize = true;
        btnRemoveRole.Location = new System.Drawing.Point(309, 85);
        btnRemoveRole.MinimumSize = new System.Drawing.Size(114, 29);
        btnRemoveRole.Name = "btnRemoveRole";
        btnRemoveRole.Size = new System.Drawing.Size(114, 30);
        btnRemoveRole.TabIndex = 19;
        btnRemoveRole.Text = "Remove Role";
        btnRemoveRole.Click += BtnRemoveRoleClick;
        // 
        // lblUsername
        // 
        lblUsername.AutoSize = true;
        lblUsername.Location = new System.Drawing.Point(12, 15);
        lblUsername.Name = "lblUsername";
        lblUsername.Size = new System.Drawing.Size(78, 20);
        lblUsername.TabIndex = 11;
        lblUsername.Text = "Username:";
        // 
        // lblRole
        // 
        lblRole.AutoSize = true;
        lblRole.Location = new System.Drawing.Point(12, 52);
        lblRole.Name = "lblRole";
        lblRole.Size = new System.Drawing.Size(42, 20);
        lblRole.TabIndex = 13;
        lblRole.Text = "Role:";
        // 
        // lblPerms
        // 
        lblPerms.AutoSize = true;
        lblPerms.Location = new System.Drawing.Point(12, 92);
        lblPerms.Name = "lblPerms";
        lblPerms.Size = new System.Drawing.Size(88, 20);
        lblPerms.TabIndex = 15;
        lblPerms.Text = "Permissions:";
        // 
        // btnSearch
        // 
        btnSearch.AutoSize = true;
        btnSearch.Location = new System.Drawing.Point(309, 122);
        btnSearch.MinimumSize = new System.Drawing.Size(114, 29);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(114, 30);
        btnSearch.TabIndex = 20;
        btnSearch.Text = "Search";
        btnSearch.Click += BtnSearchClick;
        // 
        // btnUserRoles
        // 
        btnUserRoles.AutoSize = true;
        btnUserRoles.Location = new System.Drawing.Point(309, 159);
        btnUserRoles.MinimumSize = new System.Drawing.Size(114, 29);
        btnUserRoles.Name = "btnUserRoles";
        btnUserRoles.Size = new System.Drawing.Size(128, 30);
        btnUserRoles.TabIndex = 21;
        btnUserRoles.Text = "Show User Roles";
        btnUserRoles.Click += BtnUserRolesClick;
        // 
        // btnSort
        // 
        btnSort.AutoSize = true;
        btnSort.Location = new System.Drawing.Point(309, 233);
        btnSort.MinimumSize = new System.Drawing.Size(114, 29);
        btnSort.Name = "btnSort";
        btnSort.Size = new System.Drawing.Size(114, 30);
        btnSort.TabIndex = 23;
        btnSort.Text = "Sort Results";
        btnSort.Click += BtnSortClick;
        // 
        // lblSearchResults
        // 
        lblSearchResults.AutoSize = true;
        lblSearchResults.Location = new System.Drawing.Point(461, 12);
        lblSearchResults.Name = "lblSearchResults";
        lblSearchResults.Size = new System.Drawing.Size(58, 20);
        lblSearchResults.TabIndex = 24;
        lblSearchResults.Text = "Results:";
        // 
        // lsbResults
        // 
        lsbResults.Location = new System.Drawing.Point(461, 35);
        lsbResults.MinimumSize = new System.Drawing.Size(281, 321);
        lsbResults.Name = "lsbResults";
        lsbResults.Size = new System.Drawing.Size(457, 304);
        lsbResults.TabIndex = 25;
        // 
        // cmbSortMethod
        // 
        cmbSortMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbSortMethod.Items.AddRange(new object[] { "Bubble Sort", "Quick Sort", "Merge Sort" });
        cmbSortMethod.Location = new System.Drawing.Point(309, 196);
        cmbSortMethod.MinimumSize = new System.Drawing.Size(114, 0);
        cmbSortMethod.Name = "cmbSortMethod";
        cmbSortMethod.Size = new System.Drawing.Size(114, 28);
        cmbSortMethod.TabIndex = 22;
        // 
        // cmbSearchMethod
        // 
        cmbSearchMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbSearchMethod.Items.AddRange(new object[] { "Linear Search", "Binary Search" });
        cmbSearchMethod.Location = new System.Drawing.Point(309, 293);
        cmbSearchMethod.MinimumSize = new System.Drawing.Size(114, 0);
        cmbSearchMethod.Name = "cmbSearchMethod";
        cmbSearchMethod.Size = new System.Drawing.Size(114, 28);
        cmbSearchMethod.TabIndex = 27;
        // 
        // lblSearchType
        // 
        lblSearchType.AutoSize = true;
        lblSearchType.Location = new System.Drawing.Point(309, 270);
        lblSearchType.Name = "lblSearchType";
        lblSearchType.Size = new System.Drawing.Size(112, 20);
        lblSearchType.TabIndex = 26;
        lblSearchType.Text = "Search Method:";
        // 
        // lblNewPermission
        // 
        lblNewPermission.AutoSize = true;
        lblNewPermission.Location = new System.Drawing.Point(11, 382);
        lblNewPermission.Name = "lblNewPermission";
        lblNewPermission.Size = new System.Drawing.Size(116, 20);
        lblNewPermission.TabIndex = 3;
        lblNewPermission.Text = "New Permission:";
        // 
        // txbNewPermission
        // 
        txbNewPermission.Location = new System.Drawing.Point(126, 379);
        txbNewPermission.Name = "txbNewPermission";
        txbNewPermission.Size = new System.Drawing.Size(150, 27);
        txbNewPermission.TabIndex = 4;
        // 
        // btnAddPermission
        // 
        btnAddPermission.Location = new System.Drawing.Point(282, 378);
        btnAddPermission.Name = "btnAddPermission";
        btnAddPermission.Size = new System.Drawing.Size(94, 29);
        btnAddPermission.TabIndex = 5;
        btnAddPermission.Text = "Add";
        btnAddPermission.UseVisualStyleBackColor = true;
        btnAddPermission.Click += addPermissionButton_Click;
        // 
        // btnRemovePermission
        // 
        btnRemovePermission.Location = new System.Drawing.Point(382, 378);
        btnRemovePermission.Name = "btnRemovePermission";
        btnRemovePermission.Size = new System.Drawing.Size(94, 29);
        btnRemovePermission.TabIndex = 6;
        btnRemovePermission.Text = "Remove";
        btnRemovePermission.UseVisualStyleBackColor = true;
        btnRemovePermission.Click += removePermissionButton_Click;
        // 
        // nudUserCount
        // 
        nudUserCount.Location = new System.Drawing.Point(126, 420);
        nudUserCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudUserCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudUserCount.Name = "nudUserCount";
        nudUserCount.Size = new System.Drawing.Size(150, 27);
        nudUserCount.TabIndex = 8;
        nudUserCount.Value = new decimal(new int[] { 100, 0, 0, 0 });
        // 
        // btnGenerateUsers
        // 
        btnGenerateUsers.Location = new System.Drawing.Point(282, 419);
        btnGenerateUsers.Name = "btnGenerateUsers";
        btnGenerateUsers.Size = new System.Drawing.Size(94, 29);
        btnGenerateUsers.TabIndex = 9;
        btnGenerateUsers.Text = "Generate";
        btnGenerateUsers.UseVisualStyleBackColor = true;
        btnGenerateUsers.Click += generateUsersButton_Click;
        // 
        // btnRandomizePerms
        // 
        btnRandomizePerms.Location = new System.Drawing.Point(382, 419);
        btnRandomizePerms.Name = "btnRandomizePerms";
        btnRandomizePerms.Size = new System.Drawing.Size(94, 29);
        btnRandomizePerms.TabIndex = 10;
        btnRandomizePerms.Text = "Randomize";
        btnRandomizePerms.UseVisualStyleBackColor = true;
        btnRandomizePerms.Click += randomizePermsButton_Click;
        // 
        // lblUserCount
        // 
        lblUserCount.AutoSize = true;
        lblUserCount.Location = new System.Drawing.Point(11, 422);
        lblUserCount.Name = "lblUserCount";
        lblUserCount.Size = new System.Drawing.Size(123, 20);
        lblUserCount.TabIndex = 7;
        lblUserCount.Text = "Number of Users:";
        // 
        // nudPermCount
        // 
        nudPermCount.Location = new System.Drawing.Point(126, 460);
        nudPermCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
        nudPermCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        nudPermCount.Name = "nudPermCount";
        nudPermCount.Size = new System.Drawing.Size(150, 27);
        nudPermCount.TabIndex = 1;
        nudPermCount.Value = new decimal(new int[] { 10, 0, 0, 0 });
        // 
        // btnGeneratePerms
        // 
        btnGeneratePerms.Location = new System.Drawing.Point(282, 459);
        btnGeneratePerms.Name = "btnGeneratePerms";
        btnGeneratePerms.Size = new System.Drawing.Size(194, 29);
        btnGeneratePerms.TabIndex = 2;
        btnGeneratePerms.Text = "Generate Permissions";
        btnGeneratePerms.UseVisualStyleBackColor = true;
        btnGeneratePerms.Click += generatePermissionsButton_Click;
        // 
        // lblPermCount
        // 
        lblPermCount.AutoSize = true;
        lblPermCount.Location = new System.Drawing.Point(11, 462);
        lblPermCount.Name = "lblPermCount";
        lblPermCount.Size = new System.Drawing.Size(122, 20);
        lblPermCount.TabIndex = 0;
        lblPermCount.Text = "New Permissions:";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(971, 591);
        Controls.Add(lblPermCount);
        Controls.Add(nudPermCount);
        Controls.Add(btnGeneratePerms);
        Controls.Add(lblNewPermission);
        Controls.Add(txbNewPermission);
        Controls.Add(btnAddPermission);
        Controls.Add(btnRemovePermission);
        Controls.Add(lblUserCount);
        Controls.Add(nudUserCount);
        Controls.Add(btnGenerateUsers);
        Controls.Add(btnRandomizePerms);
        Controls.Add(lblUsername);
        Controls.Add(txbUsername);
        Controls.Add(lblRole);
        Controls.Add(cmbRoles);
        Controls.Add(lblPerms);
        Controls.Add(lsbPerms);
        Controls.Add(btnAddUser);
        Controls.Add(btnAssignRole);
        Controls.Add(btnRemoveRole);
        Controls.Add(btnSearch);
        Controls.Add(btnUserRoles);
        Controls.Add(cmbSortMethod);
        Controls.Add(btnSort);
        Controls.Add(lblSearchResults);
        Controls.Add(lsbResults);
        Controls.Add(lblSearchType);
        Controls.Add(cmbSearchMethod);
        MinimumSize = new System.Drawing.Size(750, 410);
        Text = "VRC Permission Manager";
        ((System.ComponentModel.ISupportInitialize)nudUserCount).EndInit();
        ((System.ComponentModel.ISupportInitialize)nudPermCount).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private TextBox txbUsername;
    private ComboBox cmbRoles;
    private ListBox lsbPerms;
    private Button btnAddUser;
    private Button btnAssignRole;
    private Button btnRemoveRole;
    private Button btnSearch;
    private Button btnUserRoles;
    private Button btnSort;
    private ComboBox cmbSortMethod;
    private Label lblUsername;
    private Label lblRole;
    private Label lblPerms;
    private System.Windows.Forms.Label lblSearchResults;
    private System.Windows.Forms.ListBox lsbResults;
    private ComboBox cmbSearchMethod;
    private Label lblSearchType;
    private System.Windows.Forms.TextBox txbNewPermission;
    private System.Windows.Forms.Button btnAddPermission;
    private System.Windows.Forms.Button btnRemovePermission;
    private System.Windows.Forms.Label lblNewPermission;
    private System.Windows.Forms.NumericUpDown nudUserCount;
    private System.Windows.Forms.Button btnGenerateUsers;
    private System.Windows.Forms.Button btnRandomizePerms;
    private System.Windows.Forms.Label lblUserCount;
    private System.Windows.Forms.NumericUpDown nudPermCount;
    private System.Windows.Forms.Button btnGeneratePerms;
    private System.Windows.Forms.Label lblPermCount;
}