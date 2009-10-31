namespace Fwk.Security.Admin.Controls
{
    partial class UserAdmin
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuest = new DevExpress.XtraEditors.TextEdit();
            this.txtAnsw = new DevExpress.XtraEditors.TextEdit();
            this.chkApproved = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.grdRoles1 = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingSourceRoles1 = new System.Windows.Forms.BindingSource(this.components);
            this.btnUsersList = new System.Windows.Forms.Button();
            this.usersGrid1 = new Fwk.Security.Admin.UsersGrid();
            this.label5 = new System.Windows.Forms.Label();
            this.txtComments = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnsw.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComments.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblRolesByUser
            // 
            this.lblRolesByUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRolesByUser.Image = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.lblRolesByUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRolesByUser.Location = new System.Drawing.Point(389, 31);
            this.lblRolesByUser.Name = "lblRolesByUser";
            this.lblRolesByUser.Size = new System.Drawing.Size(79, 16);
            this.lblRolesByUser.TabIndex = 21;
            this.lblRolesByUser.Text = "User roles";
            this.lblRolesByUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl1.Controls.Add(this.label4);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtQuest);
            this.groupControl1.Controls.Add(this.txtAnsw);
            this.groupControl1.Controls.Add(this.chkApproved);
            this.groupControl1.Controls.Add(this.label10);
            this.groupControl1.Controls.Add(this.txtEmail);
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Location = new System.Drawing.Point(9, 502);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(633, 129);
            this.groupControl1.TabIndex = 22;
            this.groupControl1.Text = "User properties";
            // 
            // label4
            // 
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(221, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 16);
            this.label4.TabIndex = 28;
            this.label4.Text = "Answer";
            // 
            // label3
            // 
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(221, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 16);
            this.label3.TabIndex = 27;
            this.label3.Text = "Question";
            // 
            // txtQuest
            // 
            this.txtQuest.Location = new System.Drawing.Point(223, 43);
            this.txtQuest.Name = "txtQuest";
            this.txtQuest.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtQuest.Properties.Appearance.Options.UseBackColor = true;
            this.txtQuest.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtQuest.Size = new System.Drawing.Size(279, 22);
            this.txtQuest.TabIndex = 26;
            // 
            // txtAnsw
            // 
            this.txtAnsw.Location = new System.Drawing.Point(224, 97);
            this.txtAnsw.Name = "txtAnsw";
            this.txtAnsw.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtAnsw.Properties.Appearance.Options.UseBackColor = true;
            this.txtAnsw.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtAnsw.Size = new System.Drawing.Size(278, 22);
            this.txtAnsw.TabIndex = 25;
            // 
            // chkApproved
            // 
            this.chkApproved.AutoSize = true;
            this.chkApproved.Checked = true;
            this.chkApproved.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApproved.Location = new System.Drawing.Point(490, -64);
            this.chkApproved.Name = "chkApproved";
            this.chkApproved.Size = new System.Drawing.Size(84, 17);
            this.chkApproved.TabIndex = 24;
            this.chkApproved.Text = "Is approved";
            this.chkApproved.UseVisualStyleBackColor = true;
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
            // label2
            // 
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(6, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Username:";
            // 
            // btnRemove
            // 
            this.btnRemove.BackColor = System.Drawing.Color.White;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Image = global::Fwk.Security.Admin.Properties.Resources.file_del_16;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(211, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 26);
            this.btnRemove.TabIndex = 17;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.White;
            this.btnUpdate.Enabled = false;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Image = global::Fwk.Security.Admin.Properties.Resources.file_edit_16;
            this.btnUpdate.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnUpdate.Location = new System.Drawing.Point(106, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(99, 26);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update ";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // grdRoles1
            // 
            this.grdRoles1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRoles1.AutoGenerateColumns = false;
            this.grdRoles1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRoles1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdRoles1.DataSource = this.bindingSourceRoles1;
            this.grdRoles1.Location = new System.Drawing.Point(392, 50);
            this.grdRoles1.Name = "grdRoles1";
            this.grdRoles1.Size = new System.Drawing.Size(250, 374);
            this.grdRoles1.TabIndex = 20;
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
            // btnUsersList
            // 
            this.btnUsersList.BackColor = System.Drawing.Color.White;
            this.btnUsersList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUsersList.Image = global::Fwk.Security.Admin.Properties.Resources.fwk_Refresh;
            this.btnUsersList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsersList.Location = new System.Drawing.Point(2, 3);
            this.btnUsersList.Name = "btnUsersList";
            this.btnUsersList.Size = new System.Drawing.Size(100, 24);
            this.btnUsersList.TabIndex = 19;
            this.btnUsersList.Text = "    Refresh users";
            this.btnUsersList.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUsersList.UseVisualStyleBackColor = false;
            this.btnUsersList.Click += new System.EventHandler(this.btnUsersList_Click);
            // 
            // usersGrid1
            // 
            this.usersGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.usersGrid1.Location = new System.Drawing.Point(3, 34);
            this.usersGrid1.Name = "usersGrid1";
            this.usersGrid1.Size = new System.Drawing.Size(383, 403);
            this.usersGrid1.TabIndex = 23;
            this.usersGrid1.OnUserChange += new Fwk.Security.Admin.UserChangeHandler(this.usersGrid1_OnUserChange);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(6, 440);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Comments";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(9, 459);
            this.txtComments.Name = "txtComments";
            this.txtComments.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtComments.Properties.Appearance.Options.UseBackColor = true;
            this.txtComments.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtComments.Size = new System.Drawing.Size(593, 22);
            this.txtComments.TabIndex = 29;
            // 
            // UserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.usersGrid1);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.lblRolesByUser);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.grdRoles1);
            this.Controls.Add(this.btnUsersList);
            this.Name = "UserAdmin";
            this.Size = new System.Drawing.Size(654, 646);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQuest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnsw.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRoles1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtComments.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRolesByUser;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtUserName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdRoles1;
        private System.Windows.Forms.Button btnUsersList;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bindingSourceRoles1;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnUpdate;
        private UsersGrid usersGrid1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.TextEdit txtQuest;
        private DevExpress.XtraEditors.TextEdit txtAnsw;
        private System.Windows.Forms.CheckBox chkApproved;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.TextEdit txtComments;
    }
}
