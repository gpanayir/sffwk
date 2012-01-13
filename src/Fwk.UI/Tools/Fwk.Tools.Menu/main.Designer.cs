namespace Fwk.Tools.Menu
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.menFile = new DevExpress.XtraBars.BarSubItem();
            this.optNew = new DevExpress.XtraBars.BarSubItem();
            this.optNewMenuBar = new DevExpress.XtraBars.BarButtonItem();
            this.optNewToolBar = new DevExpress.XtraBars.BarButtonItem();
            this.barSubItem3 = new DevExpress.XtraBars.BarSubItem();
            this.optOpenMenuBar = new DevExpress.XtraBars.BarButtonItem();
            this.optOpenToolBar = new DevExpress.XtraBars.BarButtonItem();
            this.optClose = new DevExpress.XtraBars.BarButtonItem();
            this.optSave = new DevExpress.XtraBars.BarButtonItem();
            this.optSaveAs = new DevExpress.XtraBars.BarButtonItem();
            this.optExit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barLargeButtonItem2 = new DevExpress.XtraBars.BarLargeButtonItem();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Blue";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.menFile,
            this.optNew,
            this.optNewToolBar,
            this.optNewMenuBar,
            this.barSubItem3,
            this.optOpenToolBar,
            this.optOpenMenuBar,
            this.optClose,
            this.optSave,
            this.optSaveAs,
            this.optExit,
            this.barButtonItem1,
            this.barLargeButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 20;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem4),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem3)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Main menu";
            this.barButtonItem4.Id = 19;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick_1);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Child menu";
            this.barButtonItem3.Id = 18;
            this.barButtonItem3.Name = "barButtonItem3";
            this.barButtonItem3.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem3_ItemClick_1);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // menFile
            // 
            this.menFile.Caption = "File";
            this.menFile.Id = 1;
            this.menFile.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.optNew),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSubItem3),
            new DevExpress.XtraBars.LinkPersistInfo(this.optClose),
            new DevExpress.XtraBars.LinkPersistInfo(this.optSave, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.optSaveAs),
            new DevExpress.XtraBars.LinkPersistInfo(this.optExit, true)});
            this.menFile.Name = "menFile";
            // 
            // optNew
            // 
            this.optNew.Caption = "New..";
            this.optNew.Id = 4;
            this.optNew.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.optNewMenuBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.optNewToolBar)});
            this.optNew.Name = "optNew";
            // 
            // optNewMenuBar
            // 
            this.optNewMenuBar.Caption = "MenuBar";
            this.optNewMenuBar.Id = 6;
            this.optNewMenuBar.Name = "optNewMenuBar";
            this.optNewMenuBar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.optNewMenuBar_ItemClick);
            // 
            // optNewToolBar
            // 
            this.optNewToolBar.Caption = "ToolBar";
            this.optNewToolBar.Id = 5;
            this.optNewToolBar.Name = "optNewToolBar";
            this.optNewToolBar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.optNewToolBar_ItemClick);
            // 
            // barSubItem3
            // 
            this.barSubItem3.Caption = "Open...";
            this.barSubItem3.Id = 7;
            this.barSubItem3.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.optOpenMenuBar),
            new DevExpress.XtraBars.LinkPersistInfo(this.optOpenToolBar)});
            this.barSubItem3.Name = "barSubItem3";
            // 
            // optOpenMenuBar
            // 
            this.optOpenMenuBar.Caption = "MenuBar";
            this.optOpenMenuBar.Id = 9;
            this.optOpenMenuBar.Name = "optOpenMenuBar";
            this.optOpenMenuBar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.optOpenMenuBar_ItemClick);
            // 
            // optOpenToolBar
            // 
            this.optOpenToolBar.Caption = "ToolBar";
            this.optOpenToolBar.Id = 8;
            this.optOpenToolBar.Name = "optOpenToolBar";
            this.optOpenToolBar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.optOpenToolBar_ItemClick);
            // 
            // optClose
            // 
            this.optClose.Caption = "Close";
            this.optClose.Id = 10;
            this.optClose.Name = "optClose";
            // 
            // optSave
            // 
            this.optSave.Caption = "Save";
            this.optSave.Id = 11;
            this.optSave.Name = "optSave";
            this.optSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.optSave_ItemClick);
            // 
            // optSaveAs
            // 
            this.optSaveAs.Caption = "Save as...";
            this.optSaveAs.Id = 12;
            this.optSaveAs.Name = "optSaveAs";
            this.optSaveAs.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.optSaveAs_ItemClick);
            // 
            // optExit
            // 
            this.optExit.Caption = "Exit";
            this.optExit.Id = 13;
            this.optExit.Name = "optExit";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Queseyo";
            this.barButtonItem1.Id = 15;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barLargeButtonItem2
            // 
            this.barLargeButtonItem2.Caption = "otro mas";
            this.barLargeButtonItem2.Id = 16;
            this.barLargeButtonItem2.Name = "barLargeButtonItem2";
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(848, 529);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "Main";
            this.Text = "Bigbang tools";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.BarSubItem menFile;
        private DevExpress.XtraBars.BarSubItem optNew;
        private DevExpress.XtraBars.BarButtonItem optNewMenuBar;
        private DevExpress.XtraBars.BarButtonItem optNewToolBar;
        private DevExpress.XtraBars.BarSubItem barSubItem3;
        private DevExpress.XtraBars.BarButtonItem optOpenMenuBar;
        private DevExpress.XtraBars.BarButtonItem optOpenToolBar;
        private DevExpress.XtraBars.BarButtonItem optClose;
        private DevExpress.XtraBars.BarButtonItem optSave;
        private DevExpress.XtraBars.BarButtonItem optSaveAs;
        private DevExpress.XtraBars.BarButtonItem optExit;
        //private DevExpress.XtraBars.PopupMenu popupMenu1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarLargeButtonItem barLargeButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;

    }
}