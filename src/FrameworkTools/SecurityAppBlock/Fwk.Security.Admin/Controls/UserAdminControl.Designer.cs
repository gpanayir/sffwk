namespace SecurityAppBlock.Admin.Controls
{
    partial class UserAdminControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblRolesByUser = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.grdRoles1 = new System.Windows.Forms.DataGridView();
            this.btnUsersList = new System.Windows.Forms.Button();
            this.grdUsers1 = new System.Windows.Forms.DataGridView();
            this.fwkMessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.btnRemove = new System.Windows.Forms.Button();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceRoles1 = new System.Windows.Forms.BindingSource(this.components);
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userByAppBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRolesByUser
            // 
            this.lblRolesByUser.Location = new System.Drawing.Point(280, 143);
            this.lblRolesByUser.Name = "lblRolesByUser";
            this.lblRolesByUser.Size = new System.Drawing.Size(238, 16);
            this.lblRolesByUser.TabIndex = 21;
            this.lblRolesByUser.Text = "Roles ";
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.btnRemove);
            this.groupControl1.Controls.Add(this.btnUpdate);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txtPassword);
            this.groupControl1.Controls.Add(this.txtEmail);
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.label6);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.btnCreateUser);
            this.groupControl1.Location = new System.Drawing.Point(3, 7);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(687, 124);
            this.groupControl1.TabIndex = 22;
            this.groupControl1.Text = "User properties";
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Location = new System.Drawing.Point(402, 83);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(117, 26);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update User Data";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label10
            // 
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(5, 67);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(80, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "e-mail";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(270, 44);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtPassword.Properties.Appearance.Options.UseBackColor = true;
            this.txtPassword.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtPassword.Size = new System.Drawing.Size(153, 22);
            this.txtPassword.TabIndex = 5;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(4, 86);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtEmail.Properties.Appearance.Options.UseBackColor = true;
            this.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtEmail.Size = new System.Drawing.Size(153, 22);
            this.txtEmail.TabIndex = 15;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(5, 43);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtUserName.Properties.Appearance.Options.UseBackColor = true;
            this.txtUserName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtUserName.Size = new System.Drawing.Size(153, 22);
            this.txtUserName.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(267, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Password:";
            // 
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username:";
            // 
            // btnCreateUser
            // 
            this.btnCreateUser.BackColor = System.Drawing.Color.White;
            this.btnCreateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateUser.Location = new System.Drawing.Point(270, 82);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(126, 26);
            this.btnCreateUser.TabIndex = 1;
            this.btnCreateUser.Text = "Create User";
            this.btnCreateUser.UseVisualStyleBackColor = false;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);
            // 
            // grdRoles1
            // 
            this.grdRoles1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRoles1.AutoGenerateColumns = false;
            this.grdRoles1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRoles1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdRoles1.DataSource = this.bindingSourceRoles1;
            this.grdRoles1.Location = new System.Drawing.Point(283, 164);
            this.grdRoles1.Name = "grdRoles1";
            this.grdRoles1.Size = new System.Drawing.Size(290, 355);
            this.grdRoles1.TabIndex = 20;
            // 
            // btnUsersList
            // 
            this.btnUsersList.BackColor = System.Drawing.Color.White;
            this.btnUsersList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsersList.Image = global::SecurityAppBlock.Admin.Properties.Resources.fwk_Refresh;
            this.btnUsersList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsersList.Location = new System.Drawing.Point(6, 134);
            this.btnUsersList.Name = "btnUsersList";
            this.btnUsersList.Size = new System.Drawing.Size(97, 24);
            this.btnUsersList.TabIndex = 19;
            this.btnUsersList.Text = "    Refresh users";
            this.btnUsersList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsersList.UseVisualStyleBackColor = false;
            this.btnUsersList.Click += new System.EventHandler(this.btnUsersList_Click);
            // 
            // grdUsers1
            // 
            this.grdUsers1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdUsers1.AutoGenerateColumns = false;
            this.grdUsers1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.appNameDataGridViewTextBoxColumn});
            this.grdUsers1.DataSource = this.userByAppBindingSource;
            this.grdUsers1.Location = new System.Drawing.Point(5, 164);
            this.grdUsers1.Name = "grdUsers1";
            this.grdUsers1.Size = new System.Drawing.Size(253, 355);
            this.grdUsers1.TabIndex = 18;
            this.grdUsers1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers1_CellDoubleClick);
            this.grdUsers1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers1_CellClick);
            this.grdUsers1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers1_CellContentClick);
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
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Image = global::SecurityAppBlock.Admin.Properties.Resources.fwk_delete_16x;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(540, 82);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(113, 26);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove User";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            // 
            // bindingSourceRoles1
            // 
            this.bindingSourceRoles1.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // appNameDataGridViewTextBoxColumn
            // 
            this.appNameDataGridViewTextBoxColumn.DataPropertyName = "AppName";
            this.appNameDataGridViewTextBoxColumn.HeaderText = "AppName";
            this.appNameDataGridViewTextBoxColumn.Name = "appNameDataGridViewTextBoxColumn";
            // 
            // userByAppBindingSource
            // 
            this.userByAppBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // UserAdminControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblRolesByUser);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grdRoles1);
            this.Controls.Add(this.btnUsersList);
            this.Controls.Add(this.grdUsers1);
            this.Name = "UserAdminControl";
            this.Size = new System.Drawing.Size(704, 533);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRolesByUser;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.DataGridView grdRoles1;
        private System.Windows.Forms.Button btnUsersList;
        private System.Windows.Forms.DataGridView grdUsers1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userByAppBindingSource;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSourceRoles1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
    }
}
