namespace Fwk.UI.Controls.Menu
{
    partial class UC_TreeNavBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TreeNavBar));
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.colCaption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.menuBarTreeNodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.repositoryItemImageComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.toolTipController1 = new DevExpress.Utils.ToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBarTreeNodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colCaption});
            this.treeList1.DataSource = this.menuBarTreeNodeBindingSource;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.ImageIndexFieldName = "";
            this.treeList1.KeyFieldName = "Id";
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsMenu.EnableColumnMenu = false;
            this.treeList1.OptionsMenu.EnableFooterMenu = false;
            this.treeList1.OptionsPrint.PrintHorzLines = false;
            this.treeList1.OptionsPrint.PrintVertLines = false;
            this.treeList1.OptionsPrint.UsePrintStyles = true;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.OptionsView.ShowHorzLines = false;
            this.treeList1.OptionsView.ShowIndicator = false;
            this.treeList1.OptionsView.ShowVertLines = false;
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageComboBox1});
            this.treeList1.SelectImageList = this.imageCollection1;
            this.treeList1.Size = new System.Drawing.Size(250, 459);
            this.treeList1.TabIndex = 0;
            this.treeList1.ToolTipController = this.toolTipController1;
            this.treeList1.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Dark;
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.GetSelectImage += new DevExpress.XtraTreeList.GetSelectImageEventHandler(this.treeList1_GetSelectImage);
            // 
            // colCaption
            // 
            this.colCaption.FieldName = "Caption";
            this.colCaption.Name = "colCaption";
            this.colCaption.OptionsColumn.AllowEdit = false;
            this.colCaption.OptionsColumn.AllowSort = false;
            this.colCaption.OptionsColumn.ReadOnly = true;
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 0;
            this.colCaption.Width = 184;
            // 
            // menuBarTreeNodeBindingSource
            // 
            this.menuBarTreeNodeBindingSource.DataSource = typeof(Fwk.UI.Controls.Menu.TreeNodeButton);
            // 
            // repositoryItemImageComboBox1
            // 
            this.repositoryItemImageComboBox1.AutoHeight = false;
            this.repositoryItemImageComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageComboBox1.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", false, 0),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("", true, 3)});
            this.repositoryItemImageComboBox1.LargeImages = this.imageCollection1;
            this.repositoryItemImageComboBox1.Name = "repositoryItemImageComboBox1";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "folder-closed_16.png");
            this.imageCollection1.Images.SetKeyName(1, "folder-open_16.png");
            this.imageCollection1.Images.SetKeyName(2, "Document.png");
            this.imageCollection1.Images.SetKeyName(3, "save.png");
            this.imageCollection1.Images.SetKeyName(4, "Warning.png");
            // 
            // UC_TreeNavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Name = "UC_TreeNavBar";
            this.Size = new System.Drawing.Size(250, 459);
            this.Load += new System.EventHandler(this.UC_TreeNavBar_Load);
            this.Click += new System.EventHandler(this.UC_TreeNavBar_Click);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuBarTreeNodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCaption;
        private System.Windows.Forms.BindingSource menuBarTreeNodeBindingSource;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox repositoryItemImageComboBox1;
    }
}
