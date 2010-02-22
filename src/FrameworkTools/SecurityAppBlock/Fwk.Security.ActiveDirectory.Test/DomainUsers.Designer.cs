namespace Fwk.Security.ActiveDirectory.Test
{
    partial class DomainUsers
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
            this.txDomainUserName = new System.Windows.Forms.TextBox();
            this.grdDomainUsers = new System.Windows.Forms.DataGridView();
            this.btnFilterUsers = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.fwkIdentityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userPrincipalNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distinguishedNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdDomainUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkIdentityBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txDomainUserName
            // 
            this.txDomainUserName.Location = new System.Drawing.Point(69, 7);
            this.txDomainUserName.Name = "txDomainUserName";
            this.txDomainUserName.Size = new System.Drawing.Size(178, 20);
            this.txDomainUserName.TabIndex = 23;
            this.txDomainUserName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txDomainUserName_KeyDown);
            // 
            // grdDomainUsers
            // 
            this.grdDomainUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDomainUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdDomainUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.mailDataGridViewTextBoxColumn,
            this.distinguishedNameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.userPrincipalNameDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn});
            this.grdDomainUsers.Location = new System.Drawing.Point(3, 32);
            this.grdDomainUsers.Name = "grdDomainUsers";
            this.grdDomainUsers.Size = new System.Drawing.Size(311, 375);
            this.grdDomainUsers.TabIndex = 21;
            this.grdDomainUsers.Click += new System.EventHandler(this.grdDomainUsers_Click);
            // 
            // btnFilterUsers
            // 
            this.btnFilterUsers.BackColor = System.Drawing.Color.White;
            this.btnFilterUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFilterUsers.Location = new System.Drawing.Point(250, 6);
            this.btnFilterUsers.Name = "btnFilterUsers";
            this.btnFilterUsers.Size = new System.Drawing.Size(59, 22);
            this.btnFilterUsers.TabIndex = 24;
            this.btnFilterUsers.Text = "Filter";
            this.btnFilterUsers.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnFilterUsers.UseVisualStyleBackColor = false;
            this.btnFilterUsers.Click += new System.EventHandler(this.btnFilterUsers_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources._161;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(3, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(21, 18);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(27, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 42;
            this.label1.Text = "Users";
            // 
            // fwkIdentityBindingSource
            // 
            this.fwkIdentityBindingSource.DataSource = typeof(Fwk.Security.ActiveDirectory.ADUser);
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // userPrincipalNameDataGridViewTextBoxColumn
            // 
            this.userPrincipalNameDataGridViewTextBoxColumn.DataPropertyName = "UserPrincipalName";
            this.userPrincipalNameDataGridViewTextBoxColumn.HeaderText = "UserPrincipalName";
            this.userPrincipalNameDataGridViewTextBoxColumn.Name = "userPrincipalNameDataGridViewTextBoxColumn";
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            // 
            // distinguishedNameDataGridViewTextBoxColumn
            // 
            this.distinguishedNameDataGridViewTextBoxColumn.DataPropertyName = "DistinguishedName";
            this.distinguishedNameDataGridViewTextBoxColumn.HeaderText = "DistinguishedName";
            this.distinguishedNameDataGridViewTextBoxColumn.Name = "distinguishedNameDataGridViewTextBoxColumn";
            // 
            // mailDataGridViewTextBoxColumn
            // 
            this.mailDataGridViewTextBoxColumn.DataPropertyName = "Mail";
            this.mailDataGridViewTextBoxColumn.HeaderText = "Mail";
            this.mailDataGridViewTextBoxColumn.Name = "mailDataGridViewTextBoxColumn";
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DomainUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.txDomainUserName);
            this.Controls.Add(this.btnFilterUsers);
            this.Controls.Add(this.grdDomainUsers);
            this.Name = "DomainUsers";
            this.Size = new System.Drawing.Size(317, 410);
            ((System.ComponentModel.ISupportInitialize)(this.grdDomainUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkIdentityBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txDomainUserName;
        private System.Windows.Forms.Button btnFilterUsers;
        private System.Windows.Forms.DataGridView grdDomainUsers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mailDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distinguishedNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userPrincipalNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource fwkIdentityBindingSource;
    }
}
