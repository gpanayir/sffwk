using Fwk.Security.Common;
namespace Fwk.Security.Admin
{
    partial class frmAdmin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.userAdmminControl1 = new Fwk.Security.Admin.Controls.UserAdmin();
            this.tabPageRoles = new System.Windows.Forms.TabPage();
            this.rolesAdmin1 = new Fwk.Security.Admin.Controls.CreateRoles();
            this.tabPageAsingRol = new System.Windows.Forms.TabPage();
            this.assingRoles1 = new Fwk.Security.Admin.Controls.UserAssingRoles();
            this.tabPage_Rules = new System.Windows.Forms.TabPage();
            this.createRulesControl1 = new Fwk.Security.Admin.Controls.CheckRulesControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.assingRulesControl1 = new Fwk.Security.Admin.Controls.AssingRulesControl();
            this.lbltitle = new System.Windows.Forms.Label();
            this.fwkMessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.navBarControl1 = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroup_Users = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_UserCreate = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_AssingRoles = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup_Groups = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_RoleCreate = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroup_Rules = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem_CreateRule = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_CategoryCreate = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_Check = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_CreateUser = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem_AddRoles = new DevExpress.XtraNavBar.NavBarItem();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.tabControl1.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.tabPageRoles.SuspendLayout();
            this.tabPageAsingRol.SuspendLayout();
            this.tabPage_Rules.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageUsers);
            this.tabControl1.Controls.Add(this.tabPageRoles);
            this.tabControl1.Controls.Add(this.tabPageAsingRol);
            this.tabControl1.Controls.Add(this.tabPage_Rules);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(387, 76);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(456, 564);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.userAdmminControl1);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(448, 538);
            this.tabPageUsers.TabIndex = 0;
            this.tabPageUsers.Text = "Users";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // userAdmminControl1
            // 
            this.userAdmminControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAdmminControl1.Location = new System.Drawing.Point(3, 3);
            this.userAdmminControl1.Name = "userAdmminControl1";
            this.userAdmminControl1.Size = new System.Drawing.Size(442, 532);
            this.userAdmminControl1.TabIndex = 0;
            // 
            // tabPageRoles
            // 
            this.tabPageRoles.Controls.Add(this.rolesAdmin1);
            this.tabPageRoles.Location = new System.Drawing.Point(4, 22);
            this.tabPageRoles.Name = "tabPageRoles";
            this.tabPageRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRoles.Size = new System.Drawing.Size(448, 538);
            this.tabPageRoles.TabIndex = 1;
            this.tabPageRoles.Text = "Roles";
            this.tabPageRoles.UseVisualStyleBackColor = true;
            // 
            // rolesAdmin1
            // 
            this.rolesAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolesAdmin1.Location = new System.Drawing.Point(3, 3);
            this.rolesAdmin1.Name = "rolesAdmin1";
            this.rolesAdmin1.Size = new System.Drawing.Size(442, 532);
            this.rolesAdmin1.TabIndex = 0;
            // 
            // tabPageAsingRol
            // 
            this.tabPageAsingRol.Controls.Add(this.assingRoles1);
            this.tabPageAsingRol.Location = new System.Drawing.Point(4, 22);
            this.tabPageAsingRol.Name = "tabPageAsingRol";
            this.tabPageAsingRol.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAsingRol.Size = new System.Drawing.Size(448, 538);
            this.tabPageAsingRol.TabIndex = 2;
            this.tabPageAsingRol.Text = "Assing roles";
            this.tabPageAsingRol.UseVisualStyleBackColor = true;
            // 
            // assingRoles1
            // 
            this.assingRoles1.Cursor = System.Windows.Forms.Cursors.Default;
            this.assingRoles1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assingRoles1.Location = new System.Drawing.Point(3, 3);
            this.assingRoles1.Name = "assingRoles1";
            this.assingRoles1.Size = new System.Drawing.Size(442, 532);
            this.assingRoles1.TabIndex = 0;
            // 
            // tabPage_Rules
            // 
            this.tabPage_Rules.Controls.Add(this.createRulesControl1);
            this.tabPage_Rules.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Rules.Name = "tabPage_Rules";
            this.tabPage_Rules.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Rules.Size = new System.Drawing.Size(448, 538);
            this.tabPage_Rules.TabIndex = 3;
            this.tabPage_Rules.Text = "Check rules";
            this.tabPage_Rules.UseVisualStyleBackColor = true;
            // 
            // createRulesControl1
            // 
            this.createRulesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createRulesControl1.Location = new System.Drawing.Point(3, 3);
            this.createRulesControl1.Name = "createRulesControl1";
            this.createRulesControl1.Size = new System.Drawing.Size(442, 532);
            this.createRulesControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.assingRulesControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(448, 538);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Rules designer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // assingRulesControl1
            // 
            this.assingRulesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assingRulesControl1.Location = new System.Drawing.Point(3, 3);
            this.assingRulesControl1.Name = "assingRulesControl1";
            this.assingRulesControl1.Size = new System.Drawing.Size(442, 532);
            this.assingRulesControl1.TabIndex = 0;
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.White;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(855, 69);
            this.lbltitle.TabIndex = 2;
            this.lbltitle.Text = "Security admin";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fwkMessageViewInfo
            // 
            this.fwkMessageViewInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fwkMessageViewInfo.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewInfo.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewInfo.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageViewInfo.TextMessageForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.fwkMessageViewInfo.Title = "Security admin";
            // 
            // navBarControl1
            // 
            this.navBarControl1.ActiveGroup = this.navBarGroup_Users;
            this.navBarControl1.ContentButtonHint = null;
            this.navBarControl1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup_Users,
            this.navBarGroup_Groups,
            this.navBarGroup_Rules});
            this.navBarControl1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem_CreateUser,
            this.navBarItem_AddRoles,
            this.navBarItem_UserCreate,
            this.navBarItem2,
            this.navBarItem_RoleCreate,
            this.navBarItem_CreateRule,
            this.navBarItem_CategoryCreate,
            this.navBarItem_AssingRoles,
            this.navBarItem_Check});
            this.navBarControl1.Location = new System.Drawing.Point(7, 72);
            this.navBarControl1.Name = "navBarControl1";
            this.navBarControl1.OptionsNavPane.ExpandedWidth = 177;
            this.navBarControl1.Size = new System.Drawing.Size(177, 557);
            this.navBarControl1.TabIndex = 4;
            this.navBarControl1.Text = "navBarControl1";
            this.navBarControl1.View = new DevExpress.XtraNavBar.ViewInfo.StandardSkinExplorerBarViewInfoRegistrator("Money Twins");
            this.navBarControl1.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarControl1_LinkClicked);
            // 
            // navBarGroup_Users
            // 
            this.navBarGroup_Users.Caption = "Users";
            this.navBarGroup_Users.Expanded = true;
            this.navBarGroup_Users.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup_Users.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_UserCreate),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_AssingRoles)});
            this.navBarGroup_Users.LargeImage = global::Fwk.Security.Admin.Properties.Resources.User;
            this.navBarGroup_Users.Name = "navBarGroup_Users";
            // 
            // navBarItem_UserCreate
            // 
            this.navBarItem_UserCreate.Caption = "Add new";
            this.navBarItem_UserCreate.LargeImage = global::Fwk.Security.Admin.Properties.Resources.file_new_32;
            this.navBarItem_UserCreate.Name = "navBarItem_UserCreate";
            this.navBarItem_UserCreate.SmallImage = global::Fwk.Security.Admin.Properties.Resources.file_add_16;
            this.navBarItem_UserCreate.Tag = "Fwk.Security.Admin.Controls.UserCretate, Fwk.Security.Admin";
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Find/Edit";
            this.navBarItem2.LargeImage = global::Fwk.Security.Admin.Properties.Resources.file_edit_32;
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImage = global::Fwk.Security.Admin.Properties.Resources.file_edit_16;
            this.navBarItem2.Tag = "Fwk.Security.Admin.Controls.UserAdmin, Fwk.Security.Admin";
            // 
            // navBarItem_AssingRoles
            // 
            this.navBarItem_AssingRoles.Caption = "Assing roles";
            this.navBarItem_AssingRoles.LargeImage = global::Fwk.Security.Admin.Properties.Resources.impt_24;
            this.navBarItem_AssingRoles.Name = "navBarItem_AssingRoles";
            this.navBarItem_AssingRoles.SmallImage = global::Fwk.Security.Admin.Properties.Resources.impt_24;
            this.navBarItem_AssingRoles.Tag = "Fwk.Security.Admin.Controls.UserAssingRoles, Fwk.Security.Admin";
            // 
            // navBarGroup_Groups
            // 
            this.navBarGroup_Groups.Caption = "Groups";
            this.navBarGroup_Groups.Expanded = true;
            this.navBarGroup_Groups.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsText;
            this.navBarGroup_Groups.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_RoleCreate)});
            this.navBarGroup_Groups.LargeImage = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.navBarGroup_Groups.Name = "navBarGroup_Groups";
            this.navBarGroup_Groups.SmallImage = global::Fwk.Security.Admin.Properties.Resources.Users;
            // 
            // navBarItem_RoleCreate
            // 
            this.navBarItem_RoleCreate.Caption = "Add new";
            this.navBarItem_RoleCreate.LargeImage = global::Fwk.Security.Admin.Properties.Resources.file_new_32;
            this.navBarItem_RoleCreate.Name = "navBarItem_RoleCreate";
            this.navBarItem_RoleCreate.SmallImage = global::Fwk.Security.Admin.Properties.Resources.file_add_16;
            this.navBarItem_RoleCreate.Tag = "Fwk.Security.Admin.Controls.CreateRoles,Fwk.Security.Admin";
            // 
            // navBarGroup_Rules
            // 
            this.navBarGroup_Rules.Caption = "rules";
            this.navBarGroup_Rules.Expanded = true;
            this.navBarGroup_Rules.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroup_Rules.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_CreateRule),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_Check),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem_CategoryCreate)});
            this.navBarGroup_Rules.LargeImage = global::Fwk.Security.Admin.Properties.Resources.admin_24;
            this.navBarGroup_Rules.Name = "navBarGroup_Rules";
            this.navBarGroup_Rules.SmallImage = global::Fwk.Security.Admin.Properties.Resources.admin_16;
            // 
            // navBarItem_CreateRule
            // 
            this.navBarItem_CreateRule.Caption = "Create rule";
            this.navBarItem_CreateRule.LargeImage = global::Fwk.Security.Admin.Properties.Resources.application_list_add_32;
            this.navBarItem_CreateRule.Name = "navBarItem_CreateRule";
            this.navBarItem_CreateRule.Tag = "Fwk.Security.Admin.Controls.AssingRulesControl, Fwk.Security.Admin";
            // 
            // navBarItem_CategoryCreate
            // 
            this.navBarItem_CategoryCreate.Caption = "Create category";
            this.navBarItem_CategoryCreate.LargeImage = global::Fwk.Security.Admin.Properties.Resources.map_32;
            this.navBarItem_CategoryCreate.Name = "navBarItem_CategoryCreate";
            this.navBarItem_CategoryCreate.SmallImage = global::Fwk.Security.Admin.Properties.Resources.map_16;
            this.navBarItem_CategoryCreate.Tag = "Fwk.Security.Admin.Controls.CategoryCreate, Fwk.Security.Admin";
            // 
            // navBarItem_Check
            // 
            this.navBarItem_Check.Caption = "Check rule";
            this.navBarItem_Check.LargeImage = global::Fwk.Security.Admin.Properties.Resources.access_control_ok_32;
            this.navBarItem_Check.Name = "navBarItem_Check";
            this.navBarItem_Check.Tag = "Fwk.Security.Admin.Controls.CheckRulesControl, Fwk.Security.Admin";
            // 
            // navBarItem_CreateUser
            // 
            this.navBarItem_CreateUser.Caption = "Crear";
            this.navBarItem_CreateUser.LargeImage = global::Fwk.Security.Admin.Properties.Resources.User;
            this.navBarItem_CreateUser.Name = "navBarItem_CreateUser";
            // 
            // navBarItem_AddRoles
            // 
            this.navBarItem_AddRoles.Caption = "Asignar roles";
            this.navBarItem_AddRoles.LargeImage = global::Fwk.Security.Admin.Properties.Resources.roles_32;
            this.navBarItem_AddRoles.Name = "navBarItem_AddRoles";
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.AutoSize = true;
            this.panelControl1.Location = new System.Drawing.Point(190, 72);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(644, 561);
            this.panelControl1.TabIndex = 5;
            // 
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 651);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.navBarControl1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdmin";
            this.Text = "Security admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageRoles.ResumeLayout(false);
            this.tabPageAsingRol.ResumeLayout(false);
            this.tabPage_Rules.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navBarControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageRoles;
        private System.Windows.Forms.TabPage tabPageAsingRol;
        private System.Windows.Forms.TabPage tabPage_Rules;
        private System.Windows.Forms.TabPage tabPage1;
        private Fwk.Security.Admin.Controls.AssingRulesControl assingRulesControl1;
        private Fwk.Security.Admin.Controls.CreateRoles rolesAdmin1;
        private Fwk.Security.Admin.Controls.UserAssingRoles assingRoles1;
        private Fwk.Security.Admin.Controls.CheckRulesControl createRulesControl1;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
        private Fwk.Security.Admin.Controls.UserAdmin userAdmminControl1;
        private DevExpress.XtraNavBar.NavBarControl navBarControl1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_Users;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_Groups;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup_Rules;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_CreateUser;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_AddRoles;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_UserCreate;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_RoleCreate;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_CreateRule;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_CategoryCreate;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_AssingRoles;
        private DevExpress.XtraNavBar.NavBarItem navBarItem_Check;
    }
}

