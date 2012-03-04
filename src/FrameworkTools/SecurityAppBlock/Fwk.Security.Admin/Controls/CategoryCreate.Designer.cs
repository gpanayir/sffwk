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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryCreate));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.colName1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.fwkCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grdRules = new DevExpress.XtraGrid.GridControl();
            this.fwkAuthorizationRuleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdViewRules = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdRulesByCategory = new DevExpress.XtraGrid.GridControl();
            this.grdViewRulesByCategory = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.popupContainerControl2 = new DevExpress.XtraEditors.PopupContainerControl();
            this.lblParentCategoryName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.simpleButton_OkCreateCategory = new DevExpress.XtraEditors.SimpleButton();
            this.lblParentCategory = new System.Windows.Forms.Label();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.popupContainerEdit_AddText = new DevExpress.XtraEditors.PopupContainerEdit();
            this.txtrulenameEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnFind = new System.Windows.Forms.Button();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkAuthorizationRuleBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRulesByCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRulesByCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl2)).BeginInit();
            this.popupContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit_AddText.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrulenameEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // colName1
            // 
            this.colName1.DisplayFormat.FormatString = "If()";
            this.colName1.FieldName = "Name";
            this.colName1.Name = "colName1";
            this.colName1.OptionsColumn.AllowEdit = false;
            this.colName1.OptionsColumn.ReadOnly = true;
            this.colName1.Visible = true;
            this.colName1.VisibleIndex = 0;
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
            this.treeList1.Location = new System.Drawing.Point(505, 55);
            this.treeList1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.EnableAppearanceEvenRow = true;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.ParentFieldName = "ParentId";
            this.treeList1.Size = new System.Drawing.Size(275, 671);
            this.treeList1.StateImageList = this.imageList1;
            this.treeList1.TabIndex = 27;
            this.treeList1.GetStateImage += new DevExpress.XtraTreeList.GetStateImageEventHandler(this.treeList1_GetStateImage);
            this.treeList1.Click += new System.EventHandler(this.treeList1_Click);
            this.treeList1.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeList1_DragDrop);
            this.treeList1.DragOver += new System.Windows.Forms.DragEventHandler(this.treeList1_DragOver);
            this.treeList1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.treeList1_MouseDown);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.MinWidth = 33;
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
            // grdRules
            // 
            this.grdRules.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRules.DataSource = this.fwkAuthorizationRuleBindingSource;
            this.grdRules.Location = new System.Drawing.Point(3, 55);
            this.grdRules.MainView = this.grdViewRules;
            this.grdRules.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdRules.Name = "grdRules";
            this.grdRules.Size = new System.Drawing.Size(495, 680);
            this.grdRules.TabIndex = 28;
            this.grdRules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewRules,
            this.gridView2});
            this.grdRules.MouseDown += new System.Windows.Forms.MouseEventHandler(this.grdRules_MouseDown);
            this.grdRules.MouseMove += new System.Windows.Forms.MouseEventHandler(this.grdRules_MouseMove);
            // 
            // fwkAuthorizationRuleBindingSource
            // 
            this.fwkAuthorizationRuleBindingSource.DataSource = typeof(Fwk.Security.FwkAuthorizationRule);
            // 
            // grdViewRules
            // 
            this.grdViewRules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName1});
            this.grdViewRules.GridControl = this.grdRules;
            this.grdViewRules.Name = "grdViewRules";
            this.grdViewRules.OptionsFilter.AllowFilterEditor = false;
            this.grdViewRules.OptionsLayout.Columns.AddNewColumns = false;
            this.grdViewRules.OptionsMenu.EnableColumnMenu = false;
            this.grdViewRules.OptionsMenu.EnableFooterMenu = false;
            this.grdViewRules.OptionsMenu.EnableGroupPanelMenu = false;
            this.grdViewRules.OptionsMenu.ShowGroupSortSummaryItems = false;
            this.grdViewRules.OptionsSelection.InvertSelection = true;
            this.grdViewRules.OptionsSelection.MultiSelect = true;
            this.grdViewRules.OptionsSelection.UseIndicatorForSelection = false;
            this.grdViewRules.OptionsView.ShowGroupPanel = false;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.grdRules;
            this.gridView2.Name = "gridView2";
            // 
            // grdRulesByCategory
            // 
            this.grdRulesByCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRulesByCategory.Location = new System.Drawing.Point(787, 55);
            this.grdRulesByCategory.MainView = this.grdViewRulesByCategory;
            this.grdRulesByCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grdRulesByCategory.Name = "grdRulesByCategory";
            this.grdRulesByCategory.Size = new System.Drawing.Size(355, 671);
            this.grdRulesByCategory.TabIndex = 29;
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
            // popupContainerControl2
            // 
            this.popupContainerControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.popupContainerControl2.Controls.Add(this.lblParentCategoryName);
            this.popupContainerControl2.Controls.Add(this.label2);
            this.popupContainerControl2.Controls.Add(this.simpleButton_OkCreateCategory);
            this.popupContainerControl2.Controls.Add(this.lblParentCategory);
            this.popupContainerControl2.Controls.Add(this.textEdit1);
            this.popupContainerControl2.Controls.Add(this.label1);
            this.popupContainerControl2.Location = new System.Drawing.Point(547, 87);
            this.popupContainerControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.popupContainerControl2.Name = "popupContainerControl2";
            this.popupContainerControl2.Size = new System.Drawing.Size(293, 142);
            this.popupContainerControl2.TabIndex = 30;
            this.popupContainerControl2.Leave += new System.EventHandler(this.popupContainerControl2_Leave);
            // 
            // lblParentCategoryName
            // 
            this.lblParentCategoryName.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblParentCategoryName.ForeColor = System.Drawing.Color.Maroon;
            this.lblParentCategoryName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentCategoryName.Location = new System.Drawing.Point(124, 38);
            this.lblParentCategoryName.Name = "lblParentCategoryName";
            this.lblParentCategoryName.Size = new System.Drawing.Size(164, 21);
            this.lblParentCategoryName.TabIndex = 34;
            this.lblParentCategoryName.Text = "......................";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(2, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(289, 35);
            this.label2.TabIndex = 33;
            this.label2.Text = "Add category";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // simpleButton_OkCreateCategory
            // 
            this.simpleButton_OkCreateCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.simpleButton_OkCreateCategory.Image = global::Fwk.Security.Admin.Properties.Resources.file_apply_16;
            this.simpleButton_OkCreateCategory.Location = new System.Drawing.Point(236, 110);
            this.simpleButton_OkCreateCategory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton_OkCreateCategory.Name = "simpleButton_OkCreateCategory";
            this.simpleButton_OkCreateCategory.Size = new System.Drawing.Size(54, 28);
            this.simpleButton_OkCreateCategory.TabIndex = 32;
            this.simpleButton_OkCreateCategory.Text = "Ok";
            this.simpleButton_OkCreateCategory.Click += new System.EventHandler(this.simpleButton_OkCreateCategory_Click);
            // 
            // lblParentCategory
            // 
            this.lblParentCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.lblParentCategory.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblParentCategory.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblParentCategory.Location = new System.Drawing.Point(3, 37);
            this.lblParentCategory.Name = "lblParentCategory";
            this.lblParentCategory.Size = new System.Drawing.Size(130, 21);
            this.lblParentCategory.TabIndex = 21;
            this.lblParentCategory.Text = "Parent category";
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(14, 83);
            this.textEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(240, 22);
            this.textEdit1.TabIndex = 0;
            this.textEdit1.Validating += new System.ComponentModel.CancelEventHandler(this.textEdit1_Validating);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(10, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = "Enter category name";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = global::Fwk.Security.Admin.Properties.Resources.file_del_16;
            this.simpleButton1.Location = new System.Drawing.Point(572, 0);
            this.simpleButton1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(34, 28);
            this.simpleButton1.TabIndex = 31;
            this.simpleButton1.ToolTip = "Remove category";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // popupContainerEdit_AddText
            // 
            this.popupContainerEdit_AddText.EditValue = "";
            this.popupContainerEdit_AddText.Location = new System.Drawing.Point(526, 1);
            this.popupContainerEdit_AddText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.popupContainerEdit_AddText.Name = "popupContainerEdit_AddText";
            this.popupContainerEdit_AddText.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("popupContainerEdit_AddText.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.popupContainerEdit_AddText.Properties.CloseOnLostFocus = false;
            this.popupContainerEdit_AddText.Properties.PopupControl = this.popupContainerControl2;
            this.popupContainerEdit_AddText.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.popupContainerEdit_AddText.Size = new System.Drawing.Size(38, 22);
            this.popupContainerEdit_AddText.TabIndex = 32;
            this.popupContainerEdit_AddText.ToolTip = "Add category";
            // 
            // txtrulenameEdit
            // 
            this.txtrulenameEdit.Location = new System.Drawing.Point(28, 9);
            this.txtrulenameEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtrulenameEdit.Name = "txtrulenameEdit";
            this.txtrulenameEdit.Size = new System.Drawing.Size(288, 22);
            this.txtrulenameEdit.TabIndex = 33;
            this.txtrulenameEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtrulenameEdit_KeyPress);
            // 
            // btnFind
            // 
            this.btnFind.Image = global::Fwk.Security.Admin.Properties.Resources.search_16;
            this.btnFind.Location = new System.Drawing.Point(323, 6);
            this.btnFind.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(31, 28);
            this.btnFind.TabIndex = 34;
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(791, 30);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(153, 21);
            this.labelControl1.TabIndex = 35;
            this.labelControl1.Text = "Rules by category";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(3, 30);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 21);
            this.labelControl2.TabIndex = 36;
            this.labelControl2.Text = "Rules ";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(505, 26);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(91, 21);
            this.labelControl3.TabIndex = 37;
            this.labelControl3.Text = "Categories";
            // 
            // CategoryCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.txtrulenameEdit);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.popupContainerEdit_AddText);
            this.Controls.Add(this.popupContainerControl2);
            this.Controls.Add(this.grdRulesByCategory);
            this.Controls.Add(this.grdRules);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.labelControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "CategoryCreate";
            this.Size = new System.Drawing.Size(1146, 747);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fwkAuthorizationRuleBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRulesByCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewRulesByCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl2)).EndInit();
            this.popupContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit_AddText.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtrulenameEdit.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colName;
        private System.Windows.Forms.BindingSource fwkCategoryBindingSource;
        private DevExpress.XtraGrid.GridControl grdRules;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewRules;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private System.Windows.Forms.BindingSource fwkAuthorizationRuleBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colName1;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.GridControl grdRulesByCategory;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewRulesByCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl2;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit_AddText;
        private System.Windows.Forms.Label lblParentCategory;
        private DevExpress.XtraEditors.SimpleButton simpleButton_OkCreateCategory;
        private DevExpress.XtraEditors.TextEdit txtrulenameEdit;
        private System.Windows.Forms.Button btnFind;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Label lblParentCategoryName;
    }
}
