﻿namespace pjtUserPermsMgr;

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
        cmbPerms = new System.Windows.Forms.ComboBox();
        btnAddUser = new System.Windows.Forms.Button();
        btnAssignPerm = new System.Windows.Forms.Button();
        btnUnassignPerm = new System.Windows.Forms.Button();
        lblUsername = new System.Windows.Forms.Label();
        lblPerm = new System.Windows.Forms.Label();
        btnSearch = new System.Windows.Forms.Button();
        btnUserPerms = new System.Windows.Forms.Button();
        btnSort = new System.Windows.Forms.Button();
        lblSearchResults = new System.Windows.Forms.Label();
        lsbResults = new System.Windows.Forms.ListBox();
        cmbSortMethod = new System.Windows.Forms.ComboBox();
        cmbSearchMethod = new System.Windows.Forms.ComboBox();
        lblSearchType = new System.Windows.Forms.Label();
        lblNewPermission = new System.Windows.Forms.Label();
        txbNewPermission = new System.Windows.Forms.TextBox();
        btnAddPermission = new System.Windows.Forms.Button();
        btnDeletePermission = new System.Windows.Forms.Button();
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
        txbUsername.MaxLength = 64;
        txbUsername.MinimumSize = new System.Drawing.Size(200, 27);
        txbUsername.Name = "txbUsername";
        txbUsername.Size = new System.Drawing.Size(200, 27);
        txbUsername.TabIndex = 12;
        // 
        // cmbPerms
        // 
        cmbPerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbPerms.Location = new System.Drawing.Point(93, 49);
        cmbPerms.MinimumSize = new System.Drawing.Size(200, 0);
        cmbPerms.Name = "cmbPerms";
        cmbPerms.Size = new System.Drawing.Size(200, 28);
        cmbPerms.TabIndex = 14;
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
        // btnAssignPerm
        // 
        btnAssignPerm.AutoSize = true;
        btnAssignPerm.Location = new System.Drawing.Point(12, 85);
        btnAssignPerm.MinimumSize = new System.Drawing.Size(104, 29);
        btnAssignPerm.Name = "btnAssignPerm";
        btnAssignPerm.Size = new System.Drawing.Size(136, 30);
        btnAssignPerm.TabIndex = 18;
        btnAssignPerm.Text = "Assign Permission";
        btnAssignPerm.Click += BtnAssignPermClick;
        // 
        // btnUnassignPerm
        // 
        btnUnassignPerm.AutoSize = true;
        btnUnassignPerm.Location = new System.Drawing.Point(154, 85);
        btnUnassignPerm.MinimumSize = new System.Drawing.Size(114, 29);
        btnUnassignPerm.Name = "btnUnassignPerm";
        btnUnassignPerm.Size = new System.Drawing.Size(147, 30);
        btnUnassignPerm.TabIndex = 19;
        btnUnassignPerm.Text = "Remove Permission";
        btnUnassignPerm.Click += BtnUnassignPermClick;
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
        // lblPerm
        // 
        lblPerm.AutoSize = true;
        lblPerm.Location = new System.Drawing.Point(12, 52);
        lblPerm.Name = "lblPerm";
        lblPerm.Size = new System.Drawing.Size(82, 20);
        lblPerm.TabIndex = 13;
        lblPerm.Text = "Permission:";
        // 
        // btnSearch
        // 
        btnSearch.AutoSize = true;
        btnSearch.Location = new System.Drawing.Point(771, 365);
        btnSearch.MinimumSize = new System.Drawing.Size(114, 29);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(114, 30);
        btnSearch.TabIndex = 20;
        btnSearch.Text = "Search";
        btnSearch.Click += BtnSearchClick;
        // 
        // btnUserPerms
        // 
        btnUserPerms.AutoSize = true;
        btnUserPerms.Location = new System.Drawing.Point(309, 49);
        btnUserPerms.MinimumSize = new System.Drawing.Size(114, 29);
        btnUserPerms.Name = "btnUserPerms";
        btnUserPerms.Size = new System.Drawing.Size(128, 30);
        btnUserPerms.TabIndex = 21;
        btnUserPerms.Text = "Show User Roles";
        btnUserPerms.Click += BtnUserPermsClick;
        // 
        // btnSort
        // 
        btnSort.AutoSize = true;
        btnSort.Location = new System.Drawing.Point(771, 411);
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
        lsbResults.Location = new System.Drawing.Point(534, 35);
        lsbResults.MinimumSize = new System.Drawing.Size(281, 321);
        lsbResults.Name = "lsbResults";
        lsbResults.Size = new System.Drawing.Size(384, 304);
        lsbResults.TabIndex = 25;
        // 
        // cmbSortMethod
        // 
        cmbSortMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbSortMethod.Items.AddRange(new object[] { "Bubble Sort", "Quick Sort", "Merge Sort" });
        cmbSortMethod.Location = new System.Drawing.Point(557, 411);
        cmbSortMethod.MinimumSize = new System.Drawing.Size(114, 0);
        cmbSortMethod.Name = "cmbSortMethod";
        cmbSortMethod.Size = new System.Drawing.Size(186, 28);
        cmbSortMethod.TabIndex = 22;
        // 
        // cmbSearchMethod
        // 
        cmbSearchMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbSearchMethod.Items.AddRange(new object[] { "Linear Search", "Binary Search" });
        cmbSearchMethod.Location = new System.Drawing.Point(557, 367);
        cmbSearchMethod.MinimumSize = new System.Drawing.Size(114, 0);
        cmbSearchMethod.Name = "cmbSearchMethod";
        cmbSearchMethod.Size = new System.Drawing.Size(186, 28);
        cmbSearchMethod.TabIndex = 27;
        // 
        // lblSearchType
        // 
        lblSearchType.AutoSize = true;
        lblSearchType.Location = new System.Drawing.Point(557, 341);
        lblSearchType.Name = "lblSearchType";
        lblSearchType.Size = new System.Drawing.Size(112, 20);
        lblSearchType.TabIndex = 26;
        lblSearchType.Text = "Search Method:";
        // 
        // lblNewPermission
        // 
        lblNewPermission.AutoSize = true;
        lblNewPermission.Location = new System.Drawing.Point(4, 124);
        lblNewPermission.Name = "lblNewPermission";
        lblNewPermission.Size = new System.Drawing.Size(116, 20);
        lblNewPermission.TabIndex = 3;
        lblNewPermission.Text = "New Permission:";
        // 
        // txbNewPermission
        // 
        txbNewPermission.Location = new System.Drawing.Point(133, 121);
        txbNewPermission.MaxLength = 64;
        txbNewPermission.Name = "txbNewPermission";
        txbNewPermission.Size = new System.Drawing.Size(186, 27);
        txbNewPermission.TabIndex = 4;
        // 
        // btnAddPermission
        // 
        btnAddPermission.Location = new System.Drawing.Point(325, 121);
        btnAddPermission.Name = "btnAddPermission";
        btnAddPermission.Size = new System.Drawing.Size(94, 29);
        btnAddPermission.TabIndex = 5;
        btnAddPermission.Text = "Add";
        btnAddPermission.UseVisualStyleBackColor = true;
        btnAddPermission.Click += addPermissionButton_Click;
        // 
        // btnDeletePermission
        // 
        btnDeletePermission.Location = new System.Drawing.Point(425, 121);
        btnDeletePermission.Name = "btnDeletePermission";
        btnDeletePermission.Size = new System.Drawing.Size(94, 29);
        btnDeletePermission.TabIndex = 6;
        btnDeletePermission.Text = "Remove";
        btnDeletePermission.UseVisualStyleBackColor = true;
        btnDeletePermission.Click += DeletePermissionButton_Click;
        // 
        // nudUserCount
        // 
        nudUserCount.Location = new System.Drawing.Point(12, 225);
        nudUserCount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudUserCount.Name = "nudUserCount";
        nudUserCount.Size = new System.Drawing.Size(115, 27);
        nudUserCount.TabIndex = 8;
        // 
        // btnGenerateUsers
        // 
        btnGenerateUsers.Location = new System.Drawing.Point(133, 223);
        btnGenerateUsers.Name = "btnGenerateUsers";
        btnGenerateUsers.Size = new System.Drawing.Size(186, 29);
        btnGenerateUsers.TabIndex = 9;
        btnGenerateUsers.Text = "Generate Users";
        btnGenerateUsers.UseVisualStyleBackColor = true;
        btnGenerateUsers.Click += generateUsersButton_Click;
        // 
        // btnRandomizePerms
        // 
        btnRandomizePerms.Location = new System.Drawing.Point(133, 376);
        btnRandomizePerms.Name = "btnRandomizePerms";
        btnRandomizePerms.Size = new System.Drawing.Size(168, 78);
        btnRandomizePerms.TabIndex = 10;
        btnRandomizePerms.Text = "Randomize Perm Assignments";
        btnRandomizePerms.UseVisualStyleBackColor = true;
        btnRandomizePerms.Click += randomizePermsButton_Click;
        // 
        // lblUserCount
        // 
        lblUserCount.AutoSize = true;
        lblUserCount.Location = new System.Drawing.Point(4, 202);
        lblUserCount.Name = "lblUserCount";
        lblUserCount.Size = new System.Drawing.Size(123, 20);
        lblUserCount.TabIndex = 7;
        lblUserCount.Text = "Number of Users:";
        // 
        // nudPermCount
        // 
        nudPermCount.Location = new System.Drawing.Point(12, 293);
        nudPermCount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
        nudPermCount.Name = "nudPermCount";
        nudPermCount.Size = new System.Drawing.Size(115, 27);
        nudPermCount.TabIndex = 1;
        // 
        // btnGeneratePerms
        // 
        btnGeneratePerms.Location = new System.Drawing.Point(133, 291);
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
        lblPermCount.Location = new System.Drawing.Point(4, 270);
        lblPermCount.Name = "lblPermCount";
        lblPermCount.Size = new System.Drawing.Size(122, 20);
        lblPermCount.TabIndex = 0;
        lblPermCount.Text = "New Permissions:";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(971, 515);
        Controls.Add(lblPermCount);
        Controls.Add(nudPermCount);
        Controls.Add(btnGeneratePerms);
        Controls.Add(lblNewPermission);
        Controls.Add(txbNewPermission);
        Controls.Add(btnAddPermission);
        Controls.Add(btnDeletePermission);
        Controls.Add(lblUserCount);
        Controls.Add(nudUserCount);
        Controls.Add(btnGenerateUsers);
        Controls.Add(btnRandomizePerms);
        Controls.Add(lblUsername);
        Controls.Add(txbUsername);
        Controls.Add(lblPerm);
        Controls.Add(cmbPerms);
        Controls.Add(btnAddUser);
        Controls.Add(btnAssignPerm);
        Controls.Add(btnUnassignPerm);
        Controls.Add(btnSearch);
        Controls.Add(btnUserPerms);
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
    private ComboBox cmbPerms;
    private Button btnAddUser;
    private System.Windows.Forms.Button btnAssignPerm;
    private System.Windows.Forms.Button btnUnassignPerm;
    private System.Windows.Forms.Button btnSearch;
    private System.Windows.Forms.Button btnUserPerms;
    private System.Windows.Forms.Button btnSort;
    private System.Windows.Forms.ComboBox cmbSortMethod;
    private Label lblUsername;
    private Label lblPerm;
    private System.Windows.Forms.Label lblSearchResults;
    private System.Windows.Forms.ListBox lsbResults;
    private System.Windows.Forms.ComboBox cmbSearchMethod;
    private System.Windows.Forms.Label lblSearchType;
    private System.Windows.Forms.TextBox txbNewPermission;
    private System.Windows.Forms.Button btnAddPermission;
    private System.Windows.Forms.Button btnDeletePermission;
    private System.Windows.Forms.Label lblNewPermission;
    private System.Windows.Forms.NumericUpDown nudUserCount;
    private System.Windows.Forms.Button btnGenerateUsers;
    private System.Windows.Forms.Button btnRandomizePerms;
    private System.Windows.Forms.Label lblUserCount;
    private System.Windows.Forms.NumericUpDown nudPermCount;
    private System.Windows.Forms.Button btnGeneratePerms;
    private System.Windows.Forms.Label lblPermCount;
}