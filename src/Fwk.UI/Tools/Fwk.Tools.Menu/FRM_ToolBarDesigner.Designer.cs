using Fwk.UI.Controls.Menu;
namespace Fwk.Tools.Menu
{
    partial class FRM_ToolBarDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_ToolBarDesigner));
            this.ctlTreeViewMenuBar = new DevExpress.XtraTreeList.TreeList();
            this.colCaption = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colObjeto = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.grpEditionContainer = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNew = new DevExpress.XtraEditors.DropDownButton();
            this.popNew = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.toolBarControl1 = new Fwk.UI.Controls.Menu.UC_ToolBarControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.menuFileBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.toolStripAppClientConfig = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeFiletoolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lstFiles = new DevExpress.XtraEditors.ListBoxControl();
            this.lblFileRemoved = new System.Windows.Forms.Label();
            this.lblSelectedFileName = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.ctlTreeViewMenuBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEditionContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuFileBindingSource)).BeginInit();
            this.toolStripAppClientConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstFiles)).BeginInit();
            this.SuspendLayout();
            // 
            // ctlTreeViewMenuBar
            // 
            this.ctlTreeViewMenuBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ctlTreeViewMenuBar.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colCaption,
            this.colObjeto});
            this.ctlTreeViewMenuBar.Location = new System.Drawing.Point(236, 91);
            this.ctlTreeViewMenuBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ctlTreeViewMenuBar.Name = "ctlTreeViewMenuBar";
            this.ctlTreeViewMenuBar.OptionsBehavior.PopulateServiceColumns = true;
            this.ctlTreeViewMenuBar.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.ctlTreeViewMenuBar.OptionsSelection.UseIndicatorForSelection = true;
            this.ctlTreeViewMenuBar.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.ctlTreeViewMenuBar.Size = new System.Drawing.Size(194, 650);
            this.ctlTreeViewMenuBar.TabIndex = 0;
            this.ctlTreeViewMenuBar.TreeLineStyle = DevExpress.XtraTreeList.LineStyle.Light;
            this.ctlTreeViewMenuBar.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.ctlTreeViewMenuBar_FocusedNodeChanged);
            // 
            // colCaption
            // 
            this.colCaption.AllNodesSummary = true;
            this.colCaption.Caption = "Caption";
            this.colCaption.FieldName = "colCaption";
            this.colCaption.Name = "colCaption";
            this.colCaption.OptionsColumn.AllowEdit = false;
            this.colCaption.OptionsColumn.ReadOnly = true;
            this.colCaption.UnboundType = DevExpress.XtraTreeList.Data.UnboundColumnType.String;
            this.colCaption.Visible = true;
            this.colCaption.VisibleIndex = 0;
            this.colCaption.Width = 61;
            // 
            // colObjeto
            // 
            this.colObjeto.Caption = "Objeto";
            this.colObjeto.FieldName = "colObjeto";
            this.colObjeto.Name = "colObjeto";
            // 
            // grpEditionContainer
            // 
            this.grpEditionContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEditionContainer.Location = new System.Drawing.Point(535, 133);
            this.grpEditionContainer.Margin = new System.Windows.Forms.Padding(0);
            this.grpEditionContainer.Name = "grpEditionContainer";
            this.grpEditionContainer.Size = new System.Drawing.Size(651, 612);
            this.grpEditionContainer.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::Fwk.Tools.Menu.Properties.Resources.close_16;
            this.btnDelete.Location = new System.Drawing.Point(309, 57);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(55, 31);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "-";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.DropDownControl = this.popNew;
            this.btnAddNew.Image = global::Fwk.Tools.Menu.Properties.Resources.add_16;
            this.btnAddNew.Location = new System.Drawing.Point(236, 55);
            this.btnAddNew.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(66, 32);
            this.btnAddNew.TabIndex = 3;
            this.btnAddNew.Text = "+";
            // 
            // popNew
            // 
            this.popNew.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.popNew.Manager = this.barManager1;
            this.popNew.Name = "popNew";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Simple Button";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Popup Button";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MaxItemId = 5;
            this.barManager1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barManager1_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(3, 5);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1194, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(3, 747);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1194, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(3, 5);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 742);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1197, 5);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 742);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Menu";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = global::Fwk.Tools.Menu.Properties.Resources.up_16;
            this.btnMoveUp.Location = new System.Drawing.Point(436, 133);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(57, 33);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.Text = "Up";
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = global::Fwk.Tools.Menu.Properties.Resources.down_16;
            this.btnMoveDown.Location = new System.Drawing.Point(436, 174);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(57, 37);
            this.btnMoveDown.TabIndex = 5;
            this.btnMoveDown.Text = "Dn";
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // toolBarControl1
            // 
            this.toolBarControl1.AcceptButton = null;
            this.toolBarControl1.AllowCheckAuthorization = false;
            this.toolBarControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBarControl1.CancelButton = null;
            this.toolBarControl1.Location = new System.Drawing.Point(535, 32);
            this.toolBarControl1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.toolBarControl1.Name = "toolBarControl1";
            this.toolBarControl1.Size = new System.Drawing.Size(651, 69);
            this.toolBarControl1.TabIndex = 6;
            this.toolBarControl1.ToolBar = null;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Fwk.Tools.Menu.Properties.Resources.refresh_32;
            this.btnRefresh.Location = new System.Drawing.Point(483, 37);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 44);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.ToolTip = "Refresh preview";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // menuFileBindingSource
            // 
            this.menuFileBindingSource.DataSource = typeof(Fwk.UI.Controls.Menu.MenuFileList);
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // toolStripAppClientConfig
            // 
            this.toolStripAppClientConfig.BackColor = System.Drawing.Color.Transparent;
            this.toolStripAppClientConfig.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAppClientConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.saveAllToolStripButton,
            this.newToolStripButton,
            this.openToolStripButton,
            this.removeFiletoolStripBtn,
            this.toolStripSeparator,
            this.toolStripSeparator1});
            this.toolStripAppClientConfig.Location = new System.Drawing.Point(5, 5);
            this.toolStripAppClientConfig.Name = "toolStripAppClientConfig";
            this.toolStripAppClientConfig.Size = new System.Drawing.Size(139, 25);
            this.toolStripAppClientConfig.TabIndex = 13;
            this.toolStripAppClientConfig.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::Fwk.Tools.Menu.Properties.Resources.save_16;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.ToolTipText = "Save the selected file";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // saveAllToolStripButton
            // 
            this.saveAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveAllToolStripButton.Image = global::Fwk.Tools.Menu.Properties.Resources.save_as_small_16;
            this.saveAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveAllToolStripButton.Name = "saveAllToolStripButton";
            this.saveAllToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveAllToolStripButton.Text = "toolStripButton1";
            this.saveAllToolStripButton.Click += new System.EventHandler(this.saveAllToolStripButton_Click);
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = global::Fwk.Tools.Menu.Properties.Resources.file_new_16;
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
            // removeFiletoolStripBtn
            // 
            this.removeFiletoolStripBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.removeFiletoolStripBtn.Image = global::Fwk.Tools.Menu.Properties.Resources.file_del_16;
            this.removeFiletoolStripBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeFiletoolStripBtn.Name = "removeFiletoolStripBtn";
            this.removeFiletoolStripBtn.Size = new System.Drawing.Size(23, 22);
            this.removeFiletoolStripBtn.Text = "toolStripButton1";
            this.removeFiletoolStripBtn.Click += new System.EventHandler(this.removeFiletoolStripBtn_Click);
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
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFiles.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuFileBindingSource, "Name", true));
            this.lstFiles.DataSource = this.menuFileBindingSource;
            this.lstFiles.DisplayMember = "Name";
            this.lstFiles.Location = new System.Drawing.Point(7, 55);
            this.lstFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(222, 686);
            this.lstFiles.TabIndex = 15;
            this.lstFiles.Click += new System.EventHandler(this.lstFiles_Click);
            // 
            // lblFileRemoved
            // 
            this.lblFileRemoved.AutoSize = true;
            this.lblFileRemoved.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblFileRemoved.ForeColor = System.Drawing.Color.Red;
            this.lblFileRemoved.Location = new System.Drawing.Point(541, 105);
            this.lblFileRemoved.Name = "lblFileRemoved";
            this.lblFileRemoved.Size = new System.Drawing.Size(336, 24);
            this.lblFileRemoved.TabIndex = 16;
            this.lblFileRemoved.Text = "Este archivo no exite o fue removido";
            this.lblFileRemoved.Visible = false;
            // 
            // lblSelectedFileName
            // 
            this.lblSelectedFileName.Location = new System.Drawing.Point(198, 9);
            this.lblSelectedFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSelectedFileName.Name = "lblSelectedFileName";
            this.lblSelectedFileName.Size = new System.Drawing.Size(53, 16);
            this.lblSelectedFileName.TabIndex = 14;
            this.lblSelectedFileName.Text = "file name";
            // 
            // FRM_ToolBarDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 752);
            this.Controls.Add(this.lblFileRemoved);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.lblSelectedFileName);
            this.Controls.Add(this.toolStripAppClientConfig);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.toolBarControl1);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.btnAddNew);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.grpEditionContainer);
            this.Controls.Add(this.ctlTreeViewMenuBar);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FRM_ToolBarDesigner";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Text = "Child menu designer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ToolBarDesigner_FormClosing);
            this.Load += new System.EventHandler(this.MenuDesigner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ctlTreeViewMenuBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEditionContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuFileBindingSource)).EndInit();
            this.toolStripAppClientConfig.ResumeLayout(false);
            this.toolStripAppClientConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lstFiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList ctlTreeViewMenuBar;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colCaption;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colObjeto;
        private DevExpress.XtraEditors.GroupControl grpEditionContainer;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.DropDownButton btnAddNew;
        private DevExpress.XtraEditors.SimpleButton btnMoveUp;
        private DevExpress.XtraEditors.SimpleButton btnMoveDown;
        private UC_ToolBarControl toolBarControl1;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar1;
        private System.Windows.Forms.ToolStrip toolStripAppClientConfig;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton saveAllToolStripButton;
        private System.Windows.Forms.BindingSource menuFileBindingSource;
        private DevExpress.XtraEditors.ListBoxControl lstFiles;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupMenu popNew;
        private System.Windows.Forms.Label lblFileRemoved;
        private System.Windows.Forms.ToolStripButton removeFiletoolStripBtn;
        private DevExpress.XtraEditors.LabelControl lblSelectedFileName;

    }
}