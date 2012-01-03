namespace Fwk.Security.Admin.Controls
{
    partial class UserAssingRoles
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
            this.lstBoxRoles = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.rolListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAsignarRoles = new System.Windows.Forms.Button();
            this.bindingSourceUserRole = new System.Windows.Forms.BindingSource(this.components);
            this.lblSelectedUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.usersGrid1 = new Fwk.Security.Admin.UsersGrid();
            this.lblRolesByUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserRole)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lstBoxRoles
            // 
            this.lstBoxRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxRoles.Appearance.BackColor = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.BackColor2 = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.BorderColor = System.Drawing.Color.White;
            this.lstBoxRoles.Appearance.Options.UseBackColor = true;
            this.lstBoxRoles.Appearance.Options.UseBorderColor = true;
            this.lstBoxRoles.DataSource = this.rolListBindingSource;
            this.lstBoxRoles.DisplayMember = "RolName";
            this.lstBoxRoles.Location = new System.Drawing.Point(701, 86);
            this.lstBoxRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstBoxRoles.Name = "lstBoxRoles";
            this.lstBoxRoles.Size = new System.Drawing.Size(239, 321);
            this.lstBoxRoles.TabIndex = 13;
            this.lstBoxRoles.ValueMember = "RolName";
            // 
            // rolListBindingSource
            // 
            this.rolListBindingSource.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // btnAsignarRoles
            // 
            this.btnAsignarRoles.BackColor = System.Drawing.Color.White;
            this.btnAsignarRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarRoles.Image = global::Fwk.Security.Admin.Properties.Resources.file_add_16;
            this.btnAsignarRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarRoles.Location = new System.Drawing.Point(15, 5);
            this.btnAsignarRoles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAsignarRoles.Name = "btnAsignarRoles";
            this.btnAsignarRoles.Size = new System.Drawing.Size(118, 32);
            this.btnAsignarRoles.TabIndex = 14;
            this.btnAsignarRoles.Text = "Add Roles";
            this.btnAsignarRoles.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarRoles.UseVisualStyleBackColor = false;
            this.btnAsignarRoles.Click += new System.EventHandler(this.btnAsignarRoles_Click);
            // 
            // bindingSourceUserRole
            // 
            this.bindingSourceUserRole.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // lblSelectedUser
            // 
            this.lblSelectedUser.AutoSize = true;
            this.lblSelectedUser.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSelectedUser.ForeColor = System.Drawing.Color.Maroon;
            this.lblSelectedUser.Location = new System.Drawing.Point(558, 92);
            this.lblSelectedUser.Name = "lblSelectedUser";
            this.lblSelectedUser.Size = new System.Drawing.Size(76, 17);
            this.lblSelectedUser.TabIndex = 18;
            this.lblSelectedUser.Text = ".................";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(702, 422);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "User roles";
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bindingSourceUserRole;
            this.dataGridView1.Location = new System.Drawing.Point(705, 442);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(235, 126);
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
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Image = global::Fwk.Security.Admin.Properties.Resources.User;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(418, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 28);
            this.label2.TabIndex = 21;
            this.label2.Text = "Selected user: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // usersGrid1
            // 
            this.usersGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersGrid1.Location = new System.Drawing.Point(15, 47);
            this.usersGrid1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.usersGrid1.Name = "usersGrid1";
            this.usersGrid1.Size = new System.Drawing.Size(666, 548);
            this.usersGrid1.TabIndex = 22;
            this.usersGrid1.OnUserChange += new Fwk.Security.Admin.UserChangeHandler(this.usersGrid1_OnUserChange);
            // 
            // lblRolesByUser
            // 
            this.lblRolesByUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRolesByUser.Image = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.lblRolesByUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRolesByUser.Location = new System.Drawing.Point(698, 63);
            this.lblRolesByUser.Name = "lblRolesByUser";
            this.lblRolesByUser.Size = new System.Drawing.Size(92, 20);
            this.lblRolesByUser.TabIndex = 23;
            this.lblRolesByUser.Text = "All roles";
            this.lblRolesByUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // UserAssingRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSelectedUser);
            this.Controls.Add(this.lblRolesByUser);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstBoxRoles);
            this.Controls.Add(this.btnAsignarRoles);
            this.Controls.Add(this.usersGrid1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "UserAssingRoles";
            this.Size = new System.Drawing.Size(944, 598);
            this.Load += new System.EventHandler(this.UserAssingRoles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceUserRole)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl lstBoxRoles;
        private System.Windows.Forms.Button btnAsignarRoles;
        private System.Windows.Forms.BindingSource rolListBindingSource;

        private System.Windows.Forms.BindingSource bindingSourceUserRole;
        private System.Windows.Forms.Label lblSelectedUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label2;
        private UsersGrid usersGrid1;
        private System.Windows.Forms.Label lblRolesByUser;
    }
}
