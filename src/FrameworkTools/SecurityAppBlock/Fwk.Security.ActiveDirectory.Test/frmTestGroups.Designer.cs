namespace Fwk.Security.ActiveDirectory.Test
{
    partial class frmTestGroups
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.domainGoups2 = new Fwk.Security.ActiveDirectory.Test.DomainGoups();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.btnSearchInDomain = new System.Windows.Forms.Button();
            this.grdGroupInfo = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fullNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distinguishedNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userPrincipalNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.firstNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.domainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectDomainGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.domainGoups1 = new Fwk.Security.ActiveDirectory.Test.DomainGoups();
            this.domainUsers1 = new Fwk.Security.ActiveDirectory.Test.DomainUsers();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDomainGroupBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.domainGoups2);
            this.groupBox1.Location = new System.Drawing.Point(8, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 523);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Domain Info";
            // 
            // domainGoups2
            // 
            this.domainGoups2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.domainGoups2.Location = new System.Drawing.Point(7, 46);
            this.domainGoups2.Name = "domainGoups2";
            this.domainGoups2.Size = new System.Drawing.Size(319, 471);
            this.domainGoups2.TabIndex = 21;
            this.domainGoups2.DomainGroupChangeEvent += new Fwk.Security.ActiveDirectory.Test.DomainGroupChangeHandler(this.domainGoups2_DomainGroupChangeEvent);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(12, 3);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(180, 20);
            this.txtDomain.TabIndex = 13;
            this.txtDomain.Text = "Alco";
            // 
            // btnSearchInDomain
            // 
            this.btnSearchInDomain.BackColor = System.Drawing.Color.White;
            this.btnSearchInDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchInDomain.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.fwk_find;
            this.btnSearchInDomain.Location = new System.Drawing.Point(198, 3);
            this.btnSearchInDomain.Name = "btnSearchInDomain";
            this.btnSearchInDomain.Size = new System.Drawing.Size(36, 20);
            this.btnSearchInDomain.TabIndex = 15;
            this.btnSearchInDomain.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSearchInDomain.UseVisualStyleBackColor = false;
            this.btnSearchInDomain.Click += new System.EventHandler(this.btnSearchInDomain_Click);
            // 
            // grdGroupInfo
            // 
            this.grdGroupInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdGroupInfo.AutoGenerateColumns = false;
            this.grdGroupInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdGroupInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.fullNameDataGridViewTextBoxColumn,
            this.cNDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.distinguishedNameDataGridViewTextBoxColumn,
            this.userPrincipalNameDataGridViewTextBoxColumn,
            this.firstNameDataGridViewTextBoxColumn,
            this.categoryDataGridViewTextBoxColumn,
            this.domainDataGridViewTextBoxColumn});
            this.grdGroupInfo.DataSource = this.objectDomainGroupBindingSource;
            this.grdGroupInfo.Location = new System.Drawing.Point(15, 550);
            this.grdGroupInfo.Name = "grdGroupInfo";
            this.grdGroupInfo.Size = new System.Drawing.Size(1075, 150);
            this.grdGroupInfo.TabIndex = 24;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // fullNameDataGridViewTextBoxColumn
            // 
            this.fullNameDataGridViewTextBoxColumn.DataPropertyName = "FullName";
            this.fullNameDataGridViewTextBoxColumn.HeaderText = "FullName";
            this.fullNameDataGridViewTextBoxColumn.Name = "fullNameDataGridViewTextBoxColumn";
            // 
            // cNDataGridViewTextBoxColumn
            // 
            this.cNDataGridViewTextBoxColumn.DataPropertyName = "CN";
            this.cNDataGridViewTextBoxColumn.HeaderText = "CN";
            this.cNDataGridViewTextBoxColumn.Name = "cNDataGridViewTextBoxColumn";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            // 
            // distinguishedNameDataGridViewTextBoxColumn
            // 
            this.distinguishedNameDataGridViewTextBoxColumn.DataPropertyName = "DistinguishedName";
            this.distinguishedNameDataGridViewTextBoxColumn.HeaderText = "DistinguishedName";
            this.distinguishedNameDataGridViewTextBoxColumn.Name = "distinguishedNameDataGridViewTextBoxColumn";
            this.distinguishedNameDataGridViewTextBoxColumn.Width = 320;
            // 
            // userPrincipalNameDataGridViewTextBoxColumn
            // 
            this.userPrincipalNameDataGridViewTextBoxColumn.DataPropertyName = "UserPrincipalName";
            this.userPrincipalNameDataGridViewTextBoxColumn.HeaderText = "UserPrincipalName";
            this.userPrincipalNameDataGridViewTextBoxColumn.Name = "userPrincipalNameDataGridViewTextBoxColumn";
            // 
            // firstNameDataGridViewTextBoxColumn
            // 
            this.firstNameDataGridViewTextBoxColumn.DataPropertyName = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.HeaderText = "FirstName";
            this.firstNameDataGridViewTextBoxColumn.Name = "firstNameDataGridViewTextBoxColumn";
            this.firstNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Category";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            // 
            // domainDataGridViewTextBoxColumn
            // 
            this.domainDataGridViewTextBoxColumn.DataPropertyName = "Domain";
            this.domainDataGridViewTextBoxColumn.HeaderText = "Domain";
            this.domainDataGridViewTextBoxColumn.Name = "domainDataGridViewTextBoxColumn";
            // 
            // objectDomainGroupBindingSource
            // 
            this.objectDomainGroupBindingSource.DataSource = typeof(Fwk.Security.Common.ObjectDomainGroup);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(370, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Sub grupos";
            // 
            // domainGoups1
            // 
            this.domainGoups1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.domainGoups1.Location = new System.Drawing.Point(373, 347);
            this.domainGoups1.Name = "domainGoups1";
            this.domainGoups1.Size = new System.Drawing.Size(689, 191);
            this.domainGoups1.TabIndex = 25;
            // 
            // domainUsers1
            // 
            this.domainUsers1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.domainUsers1.Location = new System.Drawing.Point(373, 21);
            this.domainUsers1.Name = "domainUsers1";
            this.domainUsers1.Size = new System.Drawing.Size(689, 296);
            this.domainUsers1.TabIndex = 22;
            // 
            // frmTestGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 712);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearchInDomain);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.domainGoups1);
            this.Controls.Add(this.grdGroupInfo);
            this.Controls.Add(this.domainUsers1);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmTestGroups";
            this.Text = "frmTestGroups";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdGroupInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.objectDomainGroupBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DomainUsers domainUsers1;
        private DomainGoups domainGoups2;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Button btnSearchInDomain;
        private System.Windows.Forms.DataGridView grdGroupInfo;
        private System.Windows.Forms.BindingSource objectDomainGroupBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fullNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distinguishedNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn userPrincipalNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn domainDataGridViewTextBoxColumn;
        private DomainGoups domainGoups1;
        private System.Windows.Forms.Label label1;
    }
}