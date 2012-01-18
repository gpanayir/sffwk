using Fwk.UI.Common;
namespace Fwk.UI.Security.Controls.Rules
{
    partial class UC_RulesMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_RulesMain));
            this.bindingSourceRules = new System.Windows.Forms.BindingSource(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.rulesCategoryBEListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.grdRulesByCategory = new DevExpress.XtraGrid.GridControl();
            this.grdViewRulesByCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rulesCategoryBEListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRulesByCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRulesByCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // MessageViewer
            // 
            this.MessageViewer.IconSize = Fwk.UI.Common.IconSize.Medium;
            this.MessageViewer.Title = "Pelsoft";
            // 
            // bindingSourceRules
            // 
            this.bindingSourceRules.DataSource = typeof(Fwk.Security.FwkAuthorizationRuleList);
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
            this.treeList1.DataSource = this.rulesCategoryBEListBindingSource;
            this.treeList1.FixedLineWidth = 1;
            this.treeList1.KeyFieldName = "CategoryId";
            this.treeList1.Location = new System.Drawing.Point(3, 29);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "ParentCategoryId";
            this.treeList1.Size = new System.Drawing.Size(332, 492);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 28;
            this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
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
            // rulesCategoryBEListBindingSource
            // 
            this.rulesCategoryBEListBindingSource.DataSource = typeof(Fwk.Security.FwkCategoryList);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "admin_16.png");
            this.imageList1.Images.SetKeyName(1, "folder-closed_16.png");
            this.imageList1.Images.SetKeyName(2, "folder-open_16.png");
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(3, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(109, 16);
            this.labelControl1.TabIndex = 36;
            this.labelControl1.Text = "Grupos de reglas";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(379, 10);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(43, 16);
            this.labelControl2.TabIndex = 37;
            this.labelControl2.Text = "Reglas";
            // 
            // grdRulesByCategory
            // 
            this.grdRulesByCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRulesByCategory.DataSource = this.bindingSourceRules;
            this.grdRulesByCategory.Location = new System.Drawing.Point(370, 32);
            this.grdRulesByCategory.MainView = this.grdViewRulesByCategory;
            this.grdRulesByCategory.Name = "grdRulesByCategory";
            this.grdRulesByCategory.Size = new System.Drawing.Size(310, 489);
            this.grdRulesByCategory.TabIndex = 38;
            this.grdRulesByCategory.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewRulesByCategory,
            this.gridView3});
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
            this.grdViewRulesByCategory.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdViewRulesByCategory_FocusedRowChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "Name";
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
            // UC_RulesMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grdRulesByCategory);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.treeList1);
            this.Name = "UC_RulesMain";
            this.Size = new System.Drawing.Size(683, 524);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rulesCategoryBEListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRulesByCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRulesByCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSourceRules;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.GridControl grdRulesByCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewRulesByCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.BindingSource rulesCategoryBEListBindingSource;

    }
}
