namespace Fwk.Tools.TreeView
{
    partial class FRM_MainDevExpress
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

        #region Windows Pelsoft Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MainDevExpress));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.toolStripAppClientConfig = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTypeImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.colEnabled = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAssemblyInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colToolTipInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSelectedImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSelectedImageIndex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.menuItemSurveyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.lblFileLoad = new System.Windows.Forms.Label();
            this.fwkMessageView_Warning = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.fwkMessageView_Error = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.menuItemEditorSurvey1 = new Fwk.Tools.TreeView.UC_MenuItemEditor();
            this.btnMenuPreview = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddCategory1 = new DevExpress.XtraEditors.SimpleButton();
            this.toolStripAppClientConfig.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemSurveyBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripAppClientConfig
            // 
            this.toolStripAppClientConfig.BackColor = System.Drawing.Color.Transparent;
            this.toolStripAppClientConfig.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAppClientConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.newToolStripButton,
            this.openToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.toolStripSeparator1,
            this.refreshToolStripButton});
            this.toolStripAppClientConfig.Location = new System.Drawing.Point(5, 5);
            this.toolStripAppClientConfig.Name = "toolStripAppClientConfig";
            this.toolStripAppClientConfig.Size = new System.Drawing.Size(139, 25);
            this.toolStripAppClientConfig.TabIndex = 12;
            this.toolStripAppClientConfig.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.ToolTipText = "Save the selected file";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.newToolStripButton.Text = "&New";
            this.newToolStripButton.ToolTipText = "Create new file";
            this.newToolStripButton.Click += new System.EventHandler(this.newToolStripButton_Click);
            // 
            // openToolStripButton
            // 
            this.openToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.openToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("openToolStripButton.Image")));
            this.openToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openToolStripButton.Name = "openToolStripButton";
            this.openToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.openToolStripButton.Text = "&Open";
            this.openToolStripButton.ToolTipText = "Open existent file";
            this.openToolStripButton.Click += new System.EventHandler(this.openToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            this.printToolStripButton.ToolTipText = "Print selected file";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // refreshToolStripButton
            // 
            this.refreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.refreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.refreshToolStripButton.Name = "refreshToolStripButton";
            this.refreshToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.refreshToolStripButton.Text = "toolStripButton1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanel1.Controls.Add(this.btnAdd);
            this.flowLayoutPanel1.Controls.Add(this.btnEdit);
            this.flowLayoutPanel1.Controls.Add(this.btnDelete);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(644, 5);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(860, 53);
            this.flowLayoutPanel1.TabIndex = 42;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAdd.Image = global::Fwk.Tools.Properties.Resources.add_window;
            this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdd.Location = new System.Drawing.Point(4, 4);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(115, 43);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "Add child";
            this.btnAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEdit.Image = global::Fwk.Tools.Properties.Resources.save;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(127, 4);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(106, 43);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit child";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDelete.Image = global::Fwk.Tools.Properties.Resources.remove_window;
            this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDelete.Location = new System.Drawing.Point(241, 5);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(125, 42);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete child";
            this.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeList1.Appearance.FocusedCell.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.FocusedCell.ForeColor = System.Drawing.Color.Maroon;
            this.treeList1.Appearance.FocusedCell.Options.UseFont = true;
            this.treeList1.Appearance.FocusedCell.Options.UseForeColor = true;
            this.treeList1.Appearance.FocusedRow.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.FocusedRow.ForeColor = System.Drawing.Color.Black;
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.Options.UseFont = true;
            this.treeList1.Appearance.FocusedRow.Options.UseForeColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.SelectedRow.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.treeList1.Appearance.SelectedRow.ForeColor = System.Drawing.Color.Maroon;
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.Options.UseFont = true;
            this.treeList1.Appearance.SelectedRow.Options.UseForeColor = true;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colDisplayName,
            this.colTypeImage,
            this.colEnabled,
            this.colAssemblyInfo,
            this.colToolTipInfo,
            this.colImage,
            this.colSelectedImage,
            this.colSelectedImageIndex});
            this.treeList1.DataSource = this.menuItemSurveyBindingSource;
            this.treeList1.Location = new System.Drawing.Point(5, 70);
            this.treeList1.Margin = new System.Windows.Forms.Padding(4);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsSelection.UseIndicatorForSelection = true;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1});
            this.treeList1.SelectImageList = this.imageList2;
            this.treeList1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowAlways;
            this.treeList1.Size = new System.Drawing.Size(481, 642);
            this.treeList1.StateImageList = this.imageList2;
            this.treeList1.TabIndex = 43;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // colDisplayName
            // 
            this.colDisplayName.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.colDisplayName.AppearanceCell.Options.UseFont = true;
            this.colDisplayName.Caption = "DisplayName";
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.Visible = true;
            this.colDisplayName.VisibleIndex = 1;
            this.colDisplayName.Width = 522;
            // 
            // colTypeImage
            // 
            this.colTypeImage.Caption = "TypeImage";
            this.colTypeImage.ColumnEdit = this.repositoryItemImageEdit1;
            this.colTypeImage.FieldName = "TypeImage";
            this.colTypeImage.MinWidth = 49;
            this.colTypeImage.Name = "colTypeImage";
            this.colTypeImage.OptionsColumn.AllowMove = false;
            this.colTypeImage.OptionsColumn.AllowSize = false;
            this.colTypeImage.OptionsColumn.FixedWidth = true;
            this.colTypeImage.OptionsColumn.ReadOnly = true;
            this.colTypeImage.Visible = true;
            this.colTypeImage.VisibleIndex = 0;
            this.colTypeImage.Width = 81;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, false, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, null, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ReadOnly = true;
            this.repositoryItemImageEdit1.ShowDropDown = DevExpress.XtraEditors.Controls.ShowDropDown.Never;
            this.repositoryItemImageEdit1.ShowIcon = false;
            this.repositoryItemImageEdit1.ShowMenu = false;
            // 
            // colEnabled
            // 
            this.colEnabled.Caption = "Enabled";
            this.colEnabled.FieldName = "Enabled";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Width = 49;
            // 
            // colAssemblyInfo
            // 
            this.colAssemblyInfo.Caption = "AssemblyInfo";
            this.colAssemblyInfo.FieldName = "AssemblyInfo";
            this.colAssemblyInfo.Name = "colAssemblyInfo";
            this.colAssemblyInfo.Width = 49;
            // 
            // colToolTipInfo
            // 
            this.colToolTipInfo.Caption = "ToolTipInfo";
            this.colToolTipInfo.FieldName = "ToolTipInfo";
            this.colToolTipInfo.Name = "colToolTipInfo";
            this.colToolTipInfo.Width = 49;
            // 
            // colImage
            // 
            this.colImage.Caption = "Image";
            this.colImage.FieldName = "Image";
            this.colImage.Name = "colImage";
            this.colImage.Width = 50;
            // 
            // colSelectedImage
            // 
            this.colSelectedImage.Caption = "SelectedImage";
            this.colSelectedImage.FieldName = "SelectedImage";
            this.colSelectedImage.Name = "colSelectedImage";
            this.colSelectedImage.Width = 50;
            // 
            // colSelectedImageIndex
            // 
            this.colSelectedImageIndex.Caption = "SelectedImageIndex";
            this.colSelectedImageIndex.FieldName = "SelectedImageIndex";
            this.colSelectedImageIndex.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSelectedImageIndex.Name = "colSelectedImageIndex";
            this.colSelectedImageIndex.Width = 50;
            // 
            // menuItemSurveyBindingSource
            // 
            this.menuItemSurveyBindingSource.DataSource = typeof(Fwk.UI.Controls.Menu.Tree.MenuItem);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList2.Images.SetKeyName(0, "Clipboard.png");
            // 
            // lblFileLoad
            // 
            this.lblFileLoad.AutoSize = true;
            this.lblFileLoad.BackColor = System.Drawing.Color.White;
            this.lblFileLoad.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblFileLoad.Location = new System.Drawing.Point(2, 41);
            this.lblFileLoad.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFileLoad.Name = "lblFileLoad";
            this.lblFileLoad.Size = new System.Drawing.Size(38, 17);
            this.lblFileLoad.TabIndex = 44;
            this.lblFileLoad.Text = "File: ";
            // 
            // fwkMessageView_Warning
            // 
            this.fwkMessageView_Warning.BackColor = System.Drawing.SystemColors.Control;
            this.fwkMessageView_Warning.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageView_Warning.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageView_Warning.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Warning;
            this.fwkMessageView_Warning.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageView_Warning.TextMessageForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.fwkMessageView_Warning.Title = "Menu item editor";
            // 
            // fwkMessageView_Error
            // 
            this.fwkMessageView_Error.BackColor = System.Drawing.SystemColors.Control;
            this.fwkMessageView_Error.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageView_Error.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageView_Error.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error;
            this.fwkMessageView_Error.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageView_Error.TextMessageForeColor = System.Drawing.Color.Maroon;
            this.fwkMessageView_Error.Title = "Message";
            // 
            // menuItemEditorSurvey1
            // 
            this.menuItemEditorSurvey1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.menuItemEditorSurvey1.CategoryChange = false;
            this.menuItemEditorSurvey1.imageComboBoxEdit1_EditValueChanged = null;
            this.menuItemEditorSurvey1.Location = new System.Drawing.Point(644, 75);
            this.menuItemEditorSurvey1.Margin = new System.Windows.Forms.Padding(5);
            this.menuItemEditorSurvey1.MenuItem = null;
            this.menuItemEditorSurvey1.Name = "menuItemEditorSurvey1";
            this.menuItemEditorSurvey1.ShowAction = Fwk.Tools.Action.Query;
            this.menuItemEditorSurvey1.Size = new System.Drawing.Size(839, 641);
            this.menuItemEditorSurvey1.TabIndex = 45;
            this.menuItemEditorSurvey1.TreeMenu = null;
            // 
            // btnMenuPreview
            // 
            this.btnMenuPreview.Image = global::Fwk.Tools.Properties.Resources.search_16;
            this.btnMenuPreview.Location = new System.Drawing.Point(181, 5);
            this.btnMenuPreview.Margin = new System.Windows.Forms.Padding(4);
            this.btnMenuPreview.Name = "btnMenuPreview";
            this.btnMenuPreview.Size = new System.Drawing.Size(149, 28);
            this.btnMenuPreview.TabIndex = 47;
            this.btnMenuPreview.Text = "Menu Preview";
            this.btnMenuPreview.Click += new System.EventHandler(this.btnMenuPreview_Click);
            // 
            // btnAddCategory1
            // 
            this.btnAddCategory1.Image = global::Fwk.Tools.Properties.Resources.add_16;
            this.btnAddCategory1.Location = new System.Drawing.Point(351, 2);
            this.btnAddCategory1.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddCategory1.Name = "btnAddCategory1";
            this.btnAddCategory1.Size = new System.Drawing.Size(154, 28);
            this.btnAddCategory1.TabIndex = 48;
            this.btnAddCategory1.Text = "Add root";
            this.btnAddCategory1.Click += new System.EventHandler(this.btnAddCategory1_Click);
            // 
            // FRM_MainDevExpress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1499, 767);
            this.Controls.Add(this.btnAddCategory1);
            this.Controls.Add(this.btnMenuPreview);
            this.Controls.Add(this.menuItemEditorSurvey1);
            this.Controls.Add(this.lblFileLoad);
            this.Controls.Add(this.treeList1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.toolStripAppClientConfig);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FRM_MainDevExpress";
            this.Text = "Menu designer";
            this.Load += new System.EventHandler(this.FRM_MainDevExpress_Load);
            this.Leave += new System.EventHandler(this.frmMainDevExpress_Leave);
            this.toolStripAppClientConfig.ResumeLayout(false);
            this.toolStripAppClientConfig.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemSurveyBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStripAppClientConfig;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton refreshToolStripButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private System.Windows.Forms.Label lblFileLoad;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageView_Warning;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageView_Error;
        private UC_MenuItemEditor menuItemEditorSurvey1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTypeImage;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEnabled;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAssemblyInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colToolTipInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colImage;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSelectedImage;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSelectedImageIndex;
        private System.Windows.Forms.BindingSource menuItemSurveyBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraEditors.SimpleButton btnMenuPreview;
        private DevExpress.XtraEditors.SimpleButton btnAddCategory1;
        public System.Windows.Forms.ImageList imageList2;
    }
}