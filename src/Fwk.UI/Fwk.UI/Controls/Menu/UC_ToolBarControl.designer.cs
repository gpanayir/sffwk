namespace Fwk.UI.Controls.Menu
{
    partial class UC_ToolBarControl
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
            this.standaloneBarDockControl1 = new DevExpress.XtraBars.StandaloneBarDockControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.ctlToolBar = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.defaultToolTipController = new DevExpress.Utils.DefaultToolTipController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // standaloneBarDockControl1
            // 
            this.defaultToolTipController.SetAllowHtmlText(this.standaloneBarDockControl1, DevExpress.Utils.DefaultBoolean.Default);
            this.standaloneBarDockControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.standaloneBarDockControl1.Location = new System.Drawing.Point(0, 0);
            this.standaloneBarDockControl1.Name = "standaloneBarDockControl1";
            this.standaloneBarDockControl1.Size = new System.Drawing.Size(768, 60);
            this.standaloneBarDockControl1.Text = "standaloneBarDockControl1";
            // 
            // barManager1
            // 
            this.barManager1.AllowCustomization = false;
            this.barManager1.AllowQuickCustomization = false;
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.ctlToolBar});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.DockControls.Add(this.standaloneBarDockControl1);
            this.barManager1.Form = this;
            this.barManager1.MaxItemId = 21;
            // 
            // ctlToolBar
            // 
            this.ctlToolBar.BarName = "ToolBar";
            this.ctlToolBar.DockCol = 0;
            this.ctlToolBar.DockRow = 0;
            this.ctlToolBar.DockStyle = DevExpress.XtraBars.BarDockStyle.Standalone;
            this.ctlToolBar.FloatLocation = new System.Drawing.Point(66, 250);
            this.ctlToolBar.OptionsBar.AllowQuickCustomization = false;
            this.ctlToolBar.OptionsBar.DisableClose = true;
            this.ctlToolBar.OptionsBar.DisableCustomization = true;
            this.ctlToolBar.OptionsBar.DrawDragBorder = false;
            this.ctlToolBar.OptionsBar.RotateWhenVertical = false;
            this.ctlToolBar.OptionsBar.UseWholeRow = true;
            this.ctlToolBar.StandaloneBarDockControl = this.standaloneBarDockControl1;
            this.ctlToolBar.Text = "ToolBar";
            // 
            // barDockControlTop
            // 
            this.defaultToolTipController.SetAllowHtmlText(this.barDockControlTop, DevExpress.Utils.DefaultBoolean.Default);
            // 
            // barDockControlBottom
            // 
            this.defaultToolTipController.SetAllowHtmlText(this.barDockControlBottom, DevExpress.Utils.DefaultBoolean.Default);
            // 
            // barDockControlLeft
            // 
            this.defaultToolTipController.SetAllowHtmlText(this.barDockControlLeft, DevExpress.Utils.DefaultBoolean.Default);
            // 
            // barDockControlRight
            // 
            this.defaultToolTipController.SetAllowHtmlText(this.barDockControlRight, DevExpress.Utils.DefaultBoolean.Default);
            // 
            // defaultToolTipController
            // 
            // 
            // 
            // 
            this.defaultToolTipController.DefaultController.AutoPopDelay = 500;
            // 
            // ToolBarControl
            // 
            this.defaultToolTipController.SetAllowHtmlText(this, DevExpress.Utils.DefaultBoolean.Default);
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.standaloneBarDockControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "ToolBarControl";
            this.Size = new System.Drawing.Size(768, 58);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.StandaloneBarDockControl standaloneBarDockControl1;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar ctlToolBar;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.Utils.DefaultToolTipController defaultToolTipController;
    }
}
