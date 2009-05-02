namespace SecurityAppBlock.Admin.Controls
{
    partial class AssingRoles
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
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lstBoxRoles = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.rolListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAsignarRoles = new System.Windows.Forms.Button();
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userByAppBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingSourceUserRole = new System.Windows.Forms.BindingSource(this.components);
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Image = global::SecurityAppBlock.Admin.Properties.Resources.Users;
            this.label9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label9.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label9.Location = new System.Drawing.Point(4, 49);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 23);
            this.label9.TabIndex = 16;
            this.label9.Text = "Users";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label8.Location = new System.Drawing.Point(302, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 16);
            this.label8.TabIndex = 15;
            this.label8.Text = "Roles";
            // 
            // lstBoxRoles
            // 
            this.lstBoxRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstBoxRoles.Appearance.BackColor = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.BackColor2 = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.BorderColor = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.Options.UseBackColor = true;
            this.lstBoxRoles.Appearance.Options.UseBorderColor = true;
            this.lstBoxRoles.DataSource = this.rolListBindingSource;
            this.lstBoxRoles.DisplayMember = "RolName";
            this.lstBoxRoles.Location = new System.Drawing.Point(305, 79);
            this.lstBoxRoles.Name = "lstBoxRoles";
            this.lstBoxRoles.Size = new System.Drawing.Size(232, 394);
            this.lstBoxRoles.TabIndex = 13;
            this.lstBoxRoles.ValueMember = "RolName";
            // 
            // rolListBindingSource
            // 
            this.rolListBindingSource.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // btnAsignarRoles
            // 
            this.btnAsignarRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAsignarRoles.BackColor = System.Drawing.Color.White;
            this.btnAsignarRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarRoles.Image = global::SecurityAppBlock.Admin.Properties.Resources.add;
            this.btnAsignarRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarRoles.Location = new System.Drawing.Point(294, 489);
            this.btnAsignarRoles.Name = "btnAsignarRoles";
            this.btnAsignarRoles.Size = new System.Drawing.Size(101, 26);
            this.btnAsignarRoles.TabIndex = 14;
            this.btnAsignarRoles.Text = "Add Roles";
            this.btnAsignarRoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarRoles.UseVisualStyleBackColor = false;
            this.btnAsignarRoles.Click += new System.EventHandler(this.btnAsignarRoles_Click);
            // 
            // grdUsers
            // 
            this.grdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdUsers.AutoGenerateColumns = false;
            this.grdUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.appNameDataGridViewTextBoxColumn});
            this.grdUsers.DataSource = this.userByAppBindingSource;
            this.grdUsers.Location = new System.Drawing.Point(3, 79);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(250, 396);
            this.grdUsers.TabIndex = 12;
            this.grdUsers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers_CellClick);
            this.grdUsers.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdUsers_CellContentClick);
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
            // bindingSourceUserRole
            // 
            this.bindingSourceUserRole.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Location = new System.Drawing.Point(117, 8);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(58, 13);
            this.lblSelectedUser.TabIndex = 18;
            this.lblSelectedUser.Text = ".................";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(2, 499);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "User roles";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSourceUserRole;
            this.dataGridView1.Location = new System.Drawing.Point(7, 530);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(530, 102);
            this.dataGridView1.TabIndex = 20;
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::SecurityAppBlock.Admin.Properties.Resources.User;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(4, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 23);
            this.label2.TabIndex = 21;
            this.label2.Text = "Selected user: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AssingRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblSelectedUser);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lstBoxRoles);
            this.Controls.Add(this.btnAsignarRoles);
            this.Controls.Add(this.grdUsers);
            this.Name = "AssingRoles";
            this.Size = new System.Drawing.Size(776, 641);
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userByAppBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.CheckedListBoxControl lstBoxRoles;
        private System.Windows.Forms.Button btnAsignarRoles;
        private System.Windows.Forms.DataGridView grdUsers;
        private System.Windows.Forms.BindingSource userByAppBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource rolListBindingSource;

        private System.Windows.Forms.BindingSource bindingSourceUserRole;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
    }
}
