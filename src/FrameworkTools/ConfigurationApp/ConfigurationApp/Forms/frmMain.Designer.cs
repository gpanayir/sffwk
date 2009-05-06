namespace ConfigurationApp
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dockPanel1 = new Fwk.Controls.Win32.DockPanel();
            this.clienteDeDespachadorDeServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuNewAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuLoadAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemSaveAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemRefreshAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripAppClientConfig = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.tsButtonSaveAll = new System.Windows.Forms.ToolStripButton();
            this.tsButtonRefreshAll = new System.Windows.Forms.ToolStripButton();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStripAppClientConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(2, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dockPanel1);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(796, 462);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBottomPortion = 0.1;
            this.dockPanel1.DockLeftPortion = 0.9;
            this.dockPanel1.DockRightPortion = 0.1;
            this.dockPanel1.DocumentStyle = Fwk.Controls.Win32.DocumentStyles.DockingSdi;
            this.dockPanel1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.World);
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.ShowDocumentIcon = true;
            this.dockPanel1.Size = new System.Drawing.Size(250, 462);
            this.dockPanel1.TabIndex = 6;
            // 
            // clienteDeDespachadorDeServicioToolStripMenuItem
            // 
            this.clienteDeDespachadorDeServicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuNewAppClientConfig,
            this.tsMenuLoadAppClientConfig});
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Name = "clienteDeDespachadorDeServicioToolStripMenuItem";
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Text = "App Config";
            // 
            // tsMenuNewAppClientConfig
            // 
            this.tsMenuNewAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.documents_small;
            this.tsMenuNewAppClientConfig.Name = "tsMenuNewAppClientConfig";
            this.tsMenuNewAppClientConfig.Size = new System.Drawing.Size(111, 22);
            this.tsMenuNewAppClientConfig.Text = "New";
            // 
            // tsMenuLoadAppClientConfig
            // 
            this.tsMenuLoadAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.open_folder_small;
            this.tsMenuLoadAppClientConfig.Name = "tsMenuLoadAppClientConfig";
            this.tsMenuLoadAppClientConfig.Size = new System.Drawing.Size(111, 22);
            this.tsMenuLoadAppClientConfig.Text = "Open";
            // 
            // tsMenuItemSave
            // 
            this.tsMenuItemSave.Image = global::ConfigurationApp.Properties.Resources.save_small;
            this.tsMenuItemSave.Name = "tsMenuItemSave";
            this.tsMenuItemSave.Size = new System.Drawing.Size(145, 22);
            this.tsMenuItemSave.Text = "Save";
            this.tsMenuItemSave.Click += new System.EventHandler(this.tsMenuItemSave_Click);
            // 
            // tsMenuItemSaveAllFiles
            // 
            this.tsMenuItemSaveAllFiles.Image = global::ConfigurationApp.Properties.Resources.save_as_small;
            this.tsMenuItemSaveAllFiles.Name = "tsMenuItemSaveAllFiles";
            this.tsMenuItemSaveAllFiles.Size = new System.Drawing.Size(145, 22);
            this.tsMenuItemSaveAllFiles.Text = "Save All";
            this.tsMenuItemSaveAllFiles.Click += new System.EventHandler(this.tsMenuItemSaveAllFiles_Click);
            // 
            // tsMenuItemRefreshAllFiles
            // 
            this.tsMenuItemRefreshAllFiles.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsMenuItemRefreshAllFiles.Name = "tsMenuItemRefreshAllFiles";
            this.tsMenuItemRefreshAllFiles.Size = new System.Drawing.Size(145, 22);
            this.tsMenuItemRefreshAllFiles.Text = "Refresh all";
            this.tsMenuItemRefreshAllFiles.Click += new System.EventHandler(this.tsMenuItemRefreshAllFiles_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.file_new_16;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.open_folder_large;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // toolStripAppClientConfig
            // 
            this.toolStripAppClientConfig.BackColor = System.Drawing.Color.Transparent;
            this.toolStripAppClientConfig.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripAppClientConfig.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripButton,
            this.tsButtonSaveAll,
            this.tsButtonRefreshAll,
            this.newToolStripButton,
            this.openToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.quitToolStripButton,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStripAppClientConfig.Location = new System.Drawing.Point(0, 24);
            this.toolStripAppClientConfig.Name = "toolStripAppClientConfig";
            this.toolStripAppClientConfig.Size = new System.Drawing.Size(239, 25);
            this.toolStripAppClientConfig.TabIndex = 7;
            this.toolStripAppClientConfig.Text = "toolStrip1";
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = global::ConfigurationApp.Properties.Resources.save_small;
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.ToolTipText = "Save the selected file";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // tsButtonSaveAll
            // 
            this.tsButtonSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonSaveAll.Image = global::ConfigurationApp.Properties.Resources.save_as_small;
            this.tsButtonSaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonSaveAll.Name = "tsButtonSaveAll";
            this.tsButtonSaveAll.Size = new System.Drawing.Size(23, 22);
            this.tsButtonSaveAll.Text = "Save all files";
            this.tsButtonSaveAll.Click += new System.EventHandler(this.tsButtonSaveAll_Click);
            // 
            // tsButtonRefreshAll
            // 
            this.tsButtonRefreshAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonRefreshAll.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsButtonRefreshAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsButtonRefreshAll.Name = "tsButtonRefreshAll";
            this.tsButtonRefreshAll.Size = new System.Drawing.Size(23, 22);
            this.tsButtonRefreshAll.Text = "Refresh all files";
            this.tsButtonRefreshAll.Click += new System.EventHandler(this.tsButtonRefreshAll_Click);
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.newToolStripButton.Image = global::ConfigurationApp.Properties.Resources.documents_small;
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
            this.openToolStripButton.Image = global::ConfigurationApp.Properties.Resources.open_folder_large;
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
            // quitToolStripButton
            // 
            this.quitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quitToolStripButton.Image = global::ConfigurationApp.Properties.Resources.file_delete_16;
            this.quitToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.quitToolStripButton.Name = "quitToolStripButton";
            this.quitToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.quitToolStripButton.Text = "Q&uit";
            this.quitToolStripButton.ToolTipText = "Quit the selected file";
            this.quitToolStripButton.Click += new System.EventHandler(this.quitToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(834, 527);
            this.Controls.Add(this.toolStripAppClientConfig);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Fwk libraries configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.toolStripAppClientConfig.ResumeLayout(false);
            this.toolStripAppClientConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        
        
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteDeDespachadorDeServicioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsMenuNewAppClientConfig;
        private System.Windows.Forms.ToolStripMenuItem tsMenuLoadAppClientConfig;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemSave;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemSaveAllFiles;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemRefreshAllFiles;
     
        private System.Windows.Forms.ToolStrip toolStripAppClientConfig;
        private System.Windows.Forms.ToolStripButton tsButtonSaveAll;
        private System.Windows.Forms.ToolStripButton tsButtonRefreshAll;
        private Fwk.Controls.Win32.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton printToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton quitToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton helpToolStripButton;
    }
}

