namespace Fwk.Logging.Viewer
{
    partial class FRM_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_Main));
            this.ctlStatus = new System.Windows.Forms.StatusStrip();
            this.ctlNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.ctlContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuMostrar = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSalir = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenFromDB = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllEventsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMenu = new System.Windows.Forms.MenuStrip();
            this.fwkMessageViewComponent1 = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.ExceptionViewer = new Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent(this.components);
            this.ctlContextMenu.SuspendLayout();
            this.mnuMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctlStatus
            // 
            this.ctlStatus.Location = new System.Drawing.Point(0, 504);
            this.ctlStatus.Name = "ctlStatus";
            this.ctlStatus.Size = new System.Drawing.Size(623, 22);
            this.ctlStatus.TabIndex = 2;
            this.ctlStatus.Text = "statusStrip1";
            // 
            // ctlNotify
            // 
            this.ctlNotify.ContextMenuStrip = this.ctlContextMenu;
            this.ctlNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("ctlNotify.Icon")));
            this.ctlNotify.Text = "Fwk - Logging Viewer";
            this.ctlNotify.Visible = true;
            this.ctlNotify.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ctlNotify_MouseDoubleClick);
            // 
            // ctlContextMenu
            // 
            this.ctlContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMostrar,
            this.mnuSalir});
            this.ctlContextMenu.Name = "ctlContextMenu";
            this.ctlContextMenu.Size = new System.Drawing.Size(123, 48);
            // 
            // mnuMostrar
            // 
            this.mnuMostrar.Image = ((System.Drawing.Image)(resources.GetObject("mnuMostrar.Image")));
            this.mnuMostrar.Name = "mnuMostrar";
            this.mnuMostrar.Size = new System.Drawing.Size(122, 22);
            this.mnuMostrar.Text = "&Mostrar";
            this.mnuMostrar.Click += new System.EventHandler(this.mnuMostrar_Click);
            // 
            // mnuSalir
            // 
            this.mnuSalir.Image = ((System.Drawing.Image)(resources.GetObject("mnuSalir.Image")));
            this.mnuSalir.Name = "mnuSalir";
            this.mnuSalir.Size = new System.Drawing.Size(122, 22);
            this.mnuSalir.Text = "&Salir";
            this.mnuSalir.Click += new System.EventHandler(this.mnuSalir_Click);
            // 
            // mnuFile
            // 
            this.mnuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpen,
            this.mnuOpenFromDB,
            this.toolStripMenuItem1,
            this.mnuExit});
            this.mnuFile.Name = "mnuFile";
            this.mnuFile.Size = new System.Drawing.Size(36, 20);
            this.mnuFile.Text = "Log";
            // 
            // mnuOpen
            // 
            this.mnuOpen.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpen.Image")));
            this.mnuOpen.Name = "mnuOpen";
            this.mnuOpen.Size = new System.Drawing.Size(184, 22);
            this.mnuOpen.Text = "Open xml log file";
            this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
            // 
            // mnuOpenFromDB
            // 
            this.mnuOpenFromDB.Image = ((System.Drawing.Image)(resources.GetObject("mnuOpenFromDB.Image")));
            this.mnuOpenFromDB.Name = "mnuOpenFromDB";
            this.mnuOpenFromDB.Size = new System.Drawing.Size(184, 22);
            this.mnuOpenFromDB.Text = "Open from database";
            this.mnuOpenFromDB.Click += new System.EventHandler(this.mnuOpenFromDB_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 6);
            // 
            // mnuExit
            // 
            this.mnuExit.Image = ((System.Drawing.Image)(resources.GetObject("mnuExit.Image")));
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.Size = new System.Drawing.Size(184, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.clearAllEventsToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // clearAllEventsToolStripMenuItem
            // 
            this.clearAllEventsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clearAllEventsToolStripMenuItem.Image")));
            this.clearAllEventsToolStripMenuItem.Name = "clearAllEventsToolStripMenuItem";
            this.clearAllEventsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.clearAllEventsToolStripMenuItem.Text = "Clear all events";
            this.clearAllEventsToolStripMenuItem.Click += new System.EventHandler(this.clearAllEventsToolStripMenuItem_Click);
            // 
            // mnuMenu
            // 
            this.mnuMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuFile,
            this.actionsToolStripMenuItem});
            this.mnuMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuMenu.Name = "mnuMenu";
            this.mnuMenu.Size = new System.Drawing.Size(975, 24);
            this.mnuMenu.TabIndex = 2;
            this.mnuMenu.Text = "menuStrip1";
            // 
            // fwkMessageViewComponent1
            // 
            this.fwkMessageViewComponent1.BackColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageViewComponent1.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewComponent1.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewComponent1.TextMessageColor = System.Drawing.Color.SteelBlue;
            this.fwkMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.PaleGoldenrod;
            this.fwkMessageViewComponent1.Title = "Message";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.SystemColors.WindowText;
            this.ExceptionViewer.Title = "FrmTechnicalMsg";
            // 
            // FRM_Main
            // 
            this.BackColor = System.Drawing.Color.Gray;
            this.ClientSize = new System.Drawing.Size(975, 675);
            this.Controls.Add(this.mnuMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "FRM_Main";
            this.ShowInTaskbar = false;
            this.Text = "Framework .: Log Viewer :.";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FRM_Main_KeyDown);
            this.ctlContextMenu.ResumeLayout(false);
            this.mnuMenu.ResumeLayout(false);
            this.mnuMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.StatusStrip ctlStatus;
 
        private System.Windows.Forms.NotifyIcon ctlNotify;
        private System.Windows.Forms.ContextMenuStrip ctlContextMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuMostrar;
        private System.Windows.Forms.ToolStripMenuItem mnuSalir;

        private System.Windows.Forms.ToolStripMenuItem mnuFile;
        private System.Windows.Forms.ToolStripMenuItem mnuOpen;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFromDB;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllEventsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip mnuMenu;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewComponent1;
        private Fwk.Bases.FrontEnd.Controls.FwkExceptionViewComponent ExceptionViewer;

    }
}

