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
            this.objectDomainGroupBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.groupBox1.Location = new System.Drawing.Point(8, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 609);
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
            this.domainGoups2.Size = new System.Drawing.Size(346, 548);
            this.domainGoups2.TabIndex = 21;
            this.domainGoups2.DomainGroupChangeEvent += new Fwk.Security.ActiveDirectory.Test.DomainGroupChangeHandler(this.domainGoups2_DomainGroupChangeEvent);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(14, 13);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(180, 20);
            this.txtDomain.TabIndex = 13;
            this.txtDomain.Text = "Pelsoft-ar";
            // 
            // btnSearchInDomain
            // 
            this.btnSearchInDomain.BackColor = System.Drawing.Color.White;
            this.btnSearchInDomain.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchInDomain.Image = global::Fwk.Security.ActiveDirectory.Test.Properties.Resources.srch_16;
            this.btnSearchInDomain.Location = new System.Drawing.Point(200, 13);
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
            this.grdGroupInfo.DataSource = this.objectDomainGroupBindingSource;
            this.grdGroupInfo.Location = new System.Drawing.Point(12, 666);
            this.grdGroupInfo.Name = "grdGroupInfo";
            this.grdGroupInfo.Size = new System.Drawing.Size(1047, 24);
            this.grdGroupInfo.TabIndex = 24;
            // 
            // domainUsers1
            // 
            this.domainUsers1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.domainUsers1.Location = new System.Drawing.Point(373, 76);
            this.domainUsers1.Name = "domainUsers1";
            this.domainUsers1.Size = new System.Drawing.Size(689, 569);
            this.domainUsers1.TabIndex = 22;
            this.domainUsers1.ObjectDomainDoubleClickEvent += new Fwk.Security.ActiveDirectory.Test.ObjectDomainDoubleClickHandler(this.domainUsers1_ObjectDomainDoubleClickEvent);
            this.domainUsers1.ObjectDomainChangeEvent += new Fwk.Security.ActiveDirectory.Test.ObjectDomainChangeHandler(this.domainUsers1_ObjectDomainChangeEvent);
            // 
            // frmTestGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 712);
            this.Controls.Add(this.btnSearchInDomain);
            this.Controls.Add(this.txtDomain);
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
    }
}