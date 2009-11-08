namespace Fwk.Security.Admin.Controls
{
    partial class RulesEditControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RulesEditControl));
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lbltitle = new System.Windows.Forms.Label();
            this.grdRoles = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.removeSelectedsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grdRulesByCategory = new DevExpress.XtraGrid.GridControl();
            this.aspnetRulesInCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdViewRulesByCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.fwkCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdRulesByCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aspnetRulesInCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRulesByCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkCategoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataSource = typeof(Fwk.Security.Common.Rol);
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.White;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(885, 34);
            this.lbltitle.TabIndex = 20;
            this.lbltitle.Text = "Edit rules";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grdRoles
            // 
            this.grdRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRoles.AutoGenerateColumns = false;
            this.grdRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdRoles.ContextMenuStrip = this.contextMenuStrip1;
            this.grdRoles.DataSource = this.rolBindingSource;
            this.grdRoles.Location = new System.Drawing.Point(591, 60);
            this.grdRoles.Name = "grdRoles";
            this.grdRoles.Size = new System.Drawing.Size(275, 368);
            this.grdRoles.TabIndex = 19;
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.removeSelectedsToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // removeSelectedsToolStripMenuItem
            // 
            this.removeSelectedsToolStripMenuItem.Name = "removeSelectedsToolStripMenuItem";
            this.removeSelectedsToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.removeSelectedsToolStripMenuItem.Text = "Remove selecteds";
            this.removeSelectedsToolStripMenuItem.Click += new System.EventHandler(this.removeSelectedsToolStripMenuItem_Click);
            // 
            // grdRulesByCategory
            // 
            this.grdRulesByCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRulesByCategory.DataSource = this.aspnetRulesInCategoryBindingSource;
            this.grdRulesByCategory.Location = new System.Drawing.Point(313, 37);
            this.grdRulesByCategory.MainView = this.grdViewRulesByCategory;
            this.grdRulesByCategory.Name = "grdRulesByCategory";
            this.grdRulesByCategory.Size = new System.Drawing.Size(272, 403);
            this.grdRulesByCategory.TabIndex = 31;
            this.grdRulesByCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewRulesByCategory,
            this.gridView3});
            this.grdRulesByCategory.Click += new System.EventHandler(this.grdRulesByCategory_Click);
            // 
            // aspnetRulesInCategoryBindingSource
            // 
            this.aspnetRulesInCategoryBindingSource.DataSource = typeof(Fwk.Security.aspnet_RulesInCategory);
            // 
            // grdViewRulesByCategory
            // 
            this.grdViewRulesByCategory.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.grdViewRulesByCategory.GridControl = this.grdRulesByCategory;
            this.grdViewRulesByCategory.Name = "grdViewRulesByCategory";
            this.grdViewRulesByCategory.OptionsFilter.AllowFilterEditor = false;
            this.grdViewRulesByCategory.OptionsLayout.Columns.AddNewColumns = false;
            this.grdViewRulesByCategory.OptionsMenu.EnableColumnMenu = false;
            this.grdViewRulesByCategory.OptionsMenu.EnableFooterMenu = false;
            this.grdViewRulesByCategory.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdViewRulesByCategory.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.grdViewRulesByCategory.OptionsSelection.InvertSelection = true;
            this.grdViewRulesByCategory.OptionsSelection.MultiSelect = true;
            this.grdViewRulesByCategory.OptionsSelection.UseIndicatorForSelection = false;
            this.grdViewRulesByCategory.OptionsView.ShowColumnHeaders = false;
            this.grdViewRulesByCategory.OptionsView.ShowDetailButtons = false;
            this.grdViewRulesByCategory.OptionsView.ShowGroupPanel = false;
            this.grdViewRulesByCategory.OptionsView.ShowIndicator = false;
            this.grdViewRulesByCategory.OptionsView.ShowVertLines = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "RuleName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridView3
            // 
            this.gridView3.GridControl = this.grdRulesByCategory;
            this.gridView3.Name = "gridView3";
            // 
            // treeList1
            // 
            this.treeList1.AllowDrop = true;
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colName});
            this.treeList1.DataSource = this.fwkCategoryBindingSource;
            this.treeList1.FixedLineWidth = 1;
            this.treeList1.KeyFieldName = "CategoryId";
            this.treeList1.Location = new System.Drawing.Point(4, 37);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "ParentId";
            this.treeList1.Size = new System.Drawing.Size(290, 403);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 30;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "folder-closed_16.png");
            this.imageList1.Images.SetKeyName(1, "folder-open_16.png");
            this.imageList1.Images.SetKeyName(2, "admin_16.png");
            // 
            // RulesEditControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.grdRulesByCategory);
            this.Controls.Add(this.grdRoles);
            this.Name = "RulesEditControl";
            this.Size = new System.Drawing.Size(885, 456);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdRulesByCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aspnetRulesInCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRulesByCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkCategoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource rolBindingSource;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.DataGridView grdRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private DevExpress.XtraGrid.GridControl grdRulesByCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewRulesByCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.BindingSource fwkCategoryBindingSource;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem removeSelectedsToolStripMenuItem;
        private System.Windows.Forms.BindingSource aspnetRulesInCategoryBindingSource;
    }
}
