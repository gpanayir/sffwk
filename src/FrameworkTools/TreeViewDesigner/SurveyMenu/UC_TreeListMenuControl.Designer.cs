namespace Fwk.Tools.SurveyMenu
{
    partial class UC_TreeListMenuControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TreeListMenuControl));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colEnabled = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDisplayName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colTypeImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.colAssemblyInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colToolTipInfo = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colPelsoftName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSelectedImage = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colSelectedImageIndex = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.menuItemSurveyBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            this.btnchangeImageView = new DevExpress.XtraEditors.SimpleButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemSurveyBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeList1.Appearance.FixedLine.BackColor = System.Drawing.Color.White;
            this.treeList1.Appearance.FixedLine.Options.UseBackColor = true;
            this.treeList1.Appearance.TreeLine.BorderColor = System.Drawing.Color.White;
            this.treeList1.Appearance.TreeLine.Options.UseBorderColor = true;
            this.treeList1.Appearance.VertLine.BorderColor = System.Drawing.Color.White;
            this.treeList1.Appearance.VertLine.Options.UseBorderColor = true;
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colEnabled,
            this.colDisplayName,
            this.colTypeImage,
            this.colAssemblyInfo,
            this.colToolTipInfo,
            this.colPelsoftName,
            this.colImage,
            this.colSelectedImage,
            this.colSelectedImageIndex});
            this.treeList1.DataSource = this.menuItemSurveyBindingSource;
            this.treeList1.FixedLineWidth = 1;
            this.treeList1.Location = new System.Drawing.Point(4, 30);
            this.treeList1.Margin = new System.Windows.Forms.Padding(4);
            this.treeList1.Name = "treeList1";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1,
            this.repositoryItemPictureEdit1});
            this.treeList1.Size = new System.Drawing.Size(411, 474);
            this.treeList1.TabIndex = 44;
            this.treeList1.ToolTipController = this.toolTipController1;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            // 
            // colEnabled
            // 
            this.colEnabled.Caption = "Enabled";
            this.colEnabled.FieldName = "Enabled";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.Width = 49;
            // 
            // colDisplayName
            // 
            this.colDisplayName.Caption = "DisplayName";
            this.colDisplayName.FieldName = "DisplayName";
            this.colDisplayName.Name = "colDisplayName";
            this.colDisplayName.OptionsColumn.AllowEdit = false;
            this.colDisplayName.OptionsColumn.AllowSort = false;
            this.colDisplayName.OptionsColumn.ReadOnly = true;
            this.colDisplayName.Visible = true;
            this.colDisplayName.VisibleIndex = 0;
            this.colDisplayName.Width = 191;
            // 
            // colTypeImage
            // 
            this.colTypeImage.Caption = "TypeImage";
            this.colTypeImage.ColumnEdit = this.repositoryItemImageEdit1;
            this.colTypeImage.FieldName = "TypeImage";
            this.colTypeImage.Name = "colTypeImage";
            this.colTypeImage.OptionsColumn.ReadOnly = true;
            this.colTypeImage.Visible = true;
            this.colTypeImage.VisibleIndex = 1;
            this.colTypeImage.Width = 202;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            this.repositoryItemImageEdit1.ReadOnly = true;
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
            // colPelsoftName
            // 
            this.colPelsoftName.Caption = "PelsoftName";
            this.colPelsoftName.FieldName = "PelsoftName";
            this.colPelsoftName.Name = "colPelsoftName";
            this.colPelsoftName.Width = 50;
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
            this.menuItemSurveyBindingSource.DataSource = typeof(Fwk.Tools.MenuItem);
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            // 
            // btnchangeImageView
            // 
            this.btnchangeImageView.Image = global::Fwk.Tools.Properties.Resources.Window_full_screen_16x16;
            this.btnchangeImageView.Location = new System.Drawing.Point(7, 1);
            this.btnchangeImageView.Margin = new System.Windows.Forms.Padding(4);
            this.btnchangeImageView.Name = "btnchangeImageView";
            this.btnchangeImageView.Size = new System.Drawing.Size(176, 25);
            this.btnchangeImageView.TabIndex = 45;
            this.btnchangeImageView.Text = "Ver imagenes";
            this.btnchangeImageView.Click += new System.EventHandler(this.btnchangeImageView_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            // 
            // UC_TreeListMenuControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.Controls.Add(this.btnchangeImageView);
            this.Controls.Add(this.treeList1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "UC_TreeListMenuControl";
            this.Size = new System.Drawing.Size(425, 510);
            this.Load += new System.EventHandler(this.TreeListMenuControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuItemSurveyBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

       

        

   

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDisplayName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colTypeImage;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colEnabled;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAssemblyInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colToolTipInfo;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colPelsoftName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colImage;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSelectedImage;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colSelectedImageIndex;
        private System.Windows.Forms.BindingSource menuItemSurveyBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnchangeImageView;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private System.Windows.Forms.ImageList imageList1;

    }
}
