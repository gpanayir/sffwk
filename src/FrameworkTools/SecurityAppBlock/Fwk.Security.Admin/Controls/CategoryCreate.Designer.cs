namespace Fwk.Security.Admin.Controls
{
    partial class CategoryCreate
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
            this.label11 = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.btnCreateNewRol = new System.Windows.Forms.Button();
            this.lblRolesByUser = new System.Windows.Forms.Label();
            this.lstBoxRules = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.fwkAuthorizationRuleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.fwkCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chkParentCategory = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkAuthorizationRuleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkCategoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(17, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 16);
            this.label11.TabIndex = 19;
            this.label11.Text = "Enter category name";
            // 
            // txtRuleName
            // 
            this.txtRuleName.Location = new System.Drawing.Point(161, 42);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(190, 21);
            this.txtRuleName.TabIndex = 18;
            // 
            // btnCreateNewRol
            // 
            this.btnCreateNewRol.BackColor = System.Drawing.Color.White;
            this.btnCreateNewRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNewRol.Image = global::Fwk.Security.Admin.Properties.Resources.save_16;
            this.btnCreateNewRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewRol.Location = new System.Drawing.Point(3, 3);
            this.btnCreateNewRol.Name = "btnCreateNewRol";
            this.btnCreateNewRol.Size = new System.Drawing.Size(112, 26);
            this.btnCreateNewRol.TabIndex = 20;
            this.btnCreateNewRol.Text = "Save category";
            this.btnCreateNewRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewRol.UseVisualStyleBackColor = false;
            this.btnCreateNewRol.Click += new System.EventHandler(this.btnCreateNewRol_Click);
            // 
            // lblRolesByUser
            // 
            this.lblRolesByUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRolesByUser.Image = global::Fwk.Security.Admin.Properties.Resources.Users;
            this.lblRolesByUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRolesByUser.Location = new System.Drawing.Point(431, 84);
            this.lblRolesByUser.Name = "lblRolesByUser";
            this.lblRolesByUser.Size = new System.Drawing.Size(126, 15);
            this.lblRolesByUser.TabIndex = 25;
            this.lblRolesByUser.Text = "Assigned rules";
            this.lblRolesByUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstBoxRules
            // 
            this.lstBoxRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lstBoxRules.Appearance.BackColor = System.Drawing.Color.White;
            this.lstBoxRules.Appearance.BackColor2 = System.Drawing.Color.White;
            this.lstBoxRules.Appearance.BorderColor = System.Drawing.Color.White;
            this.lstBoxRules.Appearance.Options.UseBackColor = true;
            this.lstBoxRules.Appearance.Options.UseBorderColor = true;
            this.lstBoxRules.DataSource = this.fwkAuthorizationRuleBindingSource;
            this.lstBoxRules.DisplayMember = "Name";
            this.lstBoxRules.Location = new System.Drawing.Point(424, 114);
            this.lstBoxRules.Name = "lstBoxRules";
            this.lstBoxRules.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstBoxRules.Size = new System.Drawing.Size(286, 251);
            this.lstBoxRules.TabIndex = 24;
            this.lstBoxRules.ValueMember = "Name";
            // 
            // fwkAuthorizationRuleBindingSource
            // 
            this.fwkAuthorizationRuleBindingSource.DataSource = typeof(Fwk.Security.FwkAuthorizationRule);
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, 6),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 2)});
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // treeList1
            // 
            this.treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName});
            this.treeList1.DataSource = this.fwkCategoryBindingSource;
            this.treeList1.FixedLineWidth = 1;
            this.treeList1.KeyFieldName = "CategoryId";
            this.treeList1.Location = new System.Drawing.Point(18, 114);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.ShowCheckBoxes = true;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "ParentId";
            this.treeList1.Size = new System.Drawing.Size(400, 251);
            this.treeList1.TabIndex = 26;
            this.treeList1.Click += new System.EventHandler(this.treeList1_Click);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.OptionsColumn.AllowEdit = false;
            this.colName.OptionsColumn.ReadOnly = true;
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            this.colName.Width = 126;
            // 
            // fwkCategoryBindingSource
            // 
            this.fwkCategoryBindingSource.DataSource = typeof(Fwk.Security.FwkCategory);
            // 
            // chkParentCategory
            // 
            this.chkParentCategory.AutoSize = true;
            this.chkParentCategory.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.chkParentCategory.Location = new System.Drawing.Point(20, 91);
            this.chkParentCategory.Name = "chkParentCategory";
            this.chkParentCategory.Size = new System.Drawing.Size(156, 17);
            this.chkParentCategory.TabIndex = 28;
            this.chkParentCategory.Text = "Select parent category";
            this.chkParentCategory.UseVisualStyleBackColor = true;
            this.chkParentCategory.CheckedChanged += new System.EventHandler(this.chkParentCategory_CheckedChanged);
            // 
            // CategoryCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkParentCategory);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.lblRolesByUser);
            this.Controls.Add(this.lstBoxRules);
            this.Controls.Add(this.btnCreateNewRol);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRuleName);
            this.Name = "CategoryCreate";
            this.Size = new System.Drawing.Size(721, 440);
            this.Load += new System.EventHandler(this.CategoryCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstBoxRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkAuthorizationRuleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkCategoryBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.Button btnCreateNewRol;
        private System.Windows.Forms.Label lblRolesByUser;
        private DevExpress.XtraEditors.CheckedListBoxControl lstBoxRules;
        private System.Windows.Forms.BindingSource fwkAuthorizationRuleBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.BindingSource fwkCategoryBindingSource;
        private System.Windows.Forms.CheckBox chkParentCategory;
    }
}
