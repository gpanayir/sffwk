using System;

namespace ConfigurationApp.Forms
{
    partial class dockPanelAppConfigClient
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("App config file", 6, 6);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dockPanelAppConfigClient));
            this.mnRoot = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuNewFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuSaveAllFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuQuitAllFile = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuRefreshAllFile = new System.Windows.Forms.ToolStripMenuItem();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imgImages = new System.Windows.Forms.ImageList(this.components);
            this.mnAppConfigAplications = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemAddConfigurationProvider = new System.Windows.Forms.ToolStripMenuItem();
            this.setDispatcherSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemAddDataConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemWrapper = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemWrapperWebService = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemWrapperRemoting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemWrappeRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.localToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuRefreshAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuSaveAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuQuitAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.exploreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCnnStrings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tSMenuNewCnnString = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuQuitDataAccessCnnString = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuItemQuitSection = new System.Windows.Forms.ToolStripMenuItem();
            this.mnCnnString = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsMenuQuitCnnString = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuRenameCnnString = new System.Windows.Forms.ToolStripMenuItem();
            this.mnRoot.SuspendLayout();
            this.mnAppConfigAplications.SuspendLayout();
            this.mnCnnStrings.SuspendLayout();
            this.mnSection.SuspendLayout();
            this.mnCnnString.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnRoot
            // 
            this.mnRoot.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuNewFile,
            this.tsMenuSaveAllFile,
            this.tsMenuQuitAllFile,
            this.tsMenuRefreshAllFile});
            this.mnRoot.Name = "mnContextConfigManager";
            this.mnRoot.Size = new System.Drawing.Size(138, 92);
            // 
            // tsMenuNewFile
            // 
            this.tsMenuNewFile.Image = global::ConfigurationApp.Properties.Resources.document;
            this.tsMenuNewFile.Name = "tsMenuNewFile";
            this.tsMenuNewFile.Size = new System.Drawing.Size(137, 22);
            this.tsMenuNewFile.Text = "New";
            this.tsMenuNewFile.Click += new System.EventHandler(this.tsMenuNewFile_Click);
            // 
            // tsMenuSaveAllFile
            // 
            this.tsMenuSaveAllFile.ForeColor = System.Drawing.Color.Black;
            this.tsMenuSaveAllFile.Image = global::ConfigurationApp.Properties.Resources.SaveAllHS22222;
            this.tsMenuSaveAllFile.ImageTransparentColor = System.Drawing.Color.White;
            this.tsMenuSaveAllFile.Name = "tsMenuSaveAllFile";
            this.tsMenuSaveAllFile.Size = new System.Drawing.Size(137, 22);
            this.tsMenuSaveAllFile.Text = "Save All";
            this.tsMenuSaveAllFile.Click += new System.EventHandler(this.tsMenuSaveAllFile_Click);
            // 
            // tsMenuQuitAllFile
            // 
            this.tsMenuQuitAllFile.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuQuitAllFile.Name = "tsMenuQuitAllFile";
            this.tsMenuQuitAllFile.Size = new System.Drawing.Size(137, 22);
            this.tsMenuQuitAllFile.Text = "Quit All";
            this.tsMenuQuitAllFile.Click += new System.EventHandler(this.tsMenuQuitAllFile_Click);
            // 
            // tsMenuRefreshAllFile
            // 
            this.tsMenuRefreshAllFile.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsMenuRefreshAllFile.Name = "tsMenuRefreshAllFile";
            this.tsMenuRefreshAllFile.Size = new System.Drawing.Size(137, 22);
            this.tsMenuRefreshAllFile.Text = "Refresh All";
            this.tsMenuRefreshAllFile.Click += new System.EventHandler(this.tsMenuRefreshAllFile_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BackColor = System.Drawing.Color.White;
            this.treeView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.FullRowSelect = true;
            this.treeView1.HotTracking = true;
            this.treeView1.ImageKey = "EditInformationHS.png";
            this.treeView1.ImageList = this.imgImages;
            this.treeView1.Location = new System.Drawing.Point(1, 3);
            this.treeView1.Name = "treeView1";
            treeNode1.ContextMenuStrip = this.mnRoot;
            treeNode1.ImageIndex = 6;
            treeNode1.Name = "Node0";
            treeNode1.SelectedImageIndex = 6;
            treeNode1.StateImageKey = "(none)";
            treeNode1.Text = "App config file";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.ShowNodeToolTips = true;
            this.treeView1.Size = new System.Drawing.Size(229, 403);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imgImages
            // 
            this.imgImages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgImages.ImageStream")));
            this.imgImages.TransparentColor = System.Drawing.Color.Transparent;
            this.imgImages.Images.SetKeyName(0, "WarningHS.png");
            this.imgImages.Images.SetKeyName(1, "AddTableHS.png");
            this.imgImages.Images.SetKeyName(2, "CascadeWindowsHS.png");
            this.imgImages.Images.SetKeyName(3, "CopyHS.png");
            this.imgImages.Images.SetKeyName(4, "dbs.ico");
            this.imgImages.Images.SetKeyName(5, "DocumentHS.png");
            this.imgImages.Images.SetKeyName(6, "EditInformationHS.png");
            this.imgImages.Images.SetKeyName(7, "EditTableHS.png");
            this.imgImages.Images.SetKeyName(8, "inifile.ico");
            this.imgImages.Images.SetKeyName(9, "item-lista.gif");
            this.imgImages.Images.SetKeyName(10, "POWER04B.ICO");
            this.imgImages.Images.SetKeyName(11, "PushpinHS.png");
            this.imgImages.Images.SetKeyName(12, "RecordHS.png");
            this.imgImages.Images.SetKeyName(13, "ShowAllCommentsHS.png");
            this.imgImages.Images.SetKeyName(14, "TortoiseAdded.ico");
            this.imgImages.Images.SetKeyName(15, "UtilityText.ico");
            this.imgImages.Images.SetKeyName(16, "46.ICO");
            // 
            // mnAppConfigAplications
            // 
            this.mnAppConfigAplications.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemAddConfigurationProvider,
            this.setDispatcherSettingsToolStripMenuItem,
            this.tsMenuItemAddDataConnection,
            this.tsMenuItemWrapper,
            this.tsMenuRefreshAppClientConfig,
            this.tsMenuSaveAppClientConfig,
            this.tsMenuQuitAppClientConfig,
            this.exploreToolStripMenuItem});
            this.mnAppConfigAplications.Name = "mnContextConfigManager";
            this.mnAppConfigAplications.Size = new System.Drawing.Size(216, 202);
            // 
            // tsMenuItemAddConfigurationProvider
            // 
            this.tsMenuItemAddConfigurationProvider.Image = global::ConfigurationApp.Properties.Resources.add;
            this.tsMenuItemAddConfigurationProvider.Name = "tsMenuItemAddConfigurationProvider";
            this.tsMenuItemAddConfigurationProvider.Size = new System.Drawing.Size(215, 22);
            this.tsMenuItemAddConfigurationProvider.Text = "Add Configuration provider";
            this.tsMenuItemAddConfigurationProvider.Click += new System.EventHandler(this.tsMenuItemAddConfigurationProvider_Click);
            // 
            // setDispatcherSettingsToolStripMenuItem
            // 
            this.setDispatcherSettingsToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.add;
            this.setDispatcherSettingsToolStripMenuItem.Name = "setDispatcherSettingsToolStripMenuItem";
            this.setDispatcherSettingsToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.setDispatcherSettingsToolStripMenuItem.Text = "Set dispatcher settings";
            this.setDispatcherSettingsToolStripMenuItem.Click += new System.EventHandler(this.setDispatcherSettingsToolStripMenuItem_Click);
            // 
            // tsMenuItemAddDataConnection
            // 
            this.tsMenuItemAddDataConnection.Image = global::ConfigurationApp.Properties.Resources.add;
            this.tsMenuItemAddDataConnection.Name = "tsMenuItemAddDataConnection";
            this.tsMenuItemAddDataConnection.Size = new System.Drawing.Size(215, 22);
            this.tsMenuItemAddDataConnection.Text = "Connection string";
            this.tsMenuItemAddDataConnection.Click += new System.EventHandler(this.tsMenuItemAddDataConnection_Click);
            // 
            // tsMenuItemWrapper
            // 
            this.tsMenuItemWrapper.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemWrapperWebService,
            this.tsMenuItemWrapperRemoting,
            this.localToolStripMenuItem,
            this.tsMenuItemWrappeRemove});
            this.tsMenuItemWrapper.Image = global::ConfigurationApp.Properties.Resources.add;
            this.tsMenuItemWrapper.Name = "tsMenuItemWrapper";
            this.tsMenuItemWrapper.Size = new System.Drawing.Size(215, 22);
            this.tsMenuItemWrapper.Text = "Wrapper";
            // 
            // tsMenuItemWrapperWebService
            // 
            this.tsMenuItemWrapperWebService.Image = global::ConfigurationApp.Properties.Resources.Web_WebConfig;
            this.tsMenuItemWrapperWebService.Name = "tsMenuItemWrapperWebService";
            this.tsMenuItemWrapperWebService.Size = new System.Drawing.Size(152, 22);
            this.tsMenuItemWrapperWebService.Text = "Web service";
            this.tsMenuItemWrapperWebService.Click += new System.EventHandler(this.tsMenuItemWrapperWebService_Click);
            // 
            // tsMenuItemWrapperRemoting
            // 
            this.tsMenuItemWrapperRemoting.Image = global::ConfigurationApp.Properties.Resources._69;
            this.tsMenuItemWrapperRemoting.Name = "tsMenuItemWrapperRemoting";
            this.tsMenuItemWrapperRemoting.Size = new System.Drawing.Size(152, 22);
            this.tsMenuItemWrapperRemoting.Text = "Remoting";
            this.tsMenuItemWrapperRemoting.Click += new System.EventHandler(this.tsMenuItemWrapperRemoting_Click);
            // 
            // tsMenuItemWrappeRemove
            // 
            this.tsMenuItemWrappeRemove.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuItemWrappeRemove.Name = "tsMenuItemWrappeRemove";
            this.tsMenuItemWrappeRemove.Size = new System.Drawing.Size(152, 22);
            this.tsMenuItemWrappeRemove.Text = "Remove";
            this.tsMenuItemWrappeRemove.Click += new System.EventHandler(this.tsMenuItemWrappeRemove_Click);
            // 
            // localToolStripMenuItem
            // 
            
            this.localToolStripMenuItem.Name = "localToolStripMenuItem";
            this.localToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.localToolStripMenuItem.Text = "Local";
            this.localToolStripMenuItem.Click += new System.EventHandler(this.localToolStripMenuItem_Click);
            // 
            // tsMenuRefreshAppClientConfig
            // 
            this.tsMenuRefreshAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsMenuRefreshAppClientConfig.Name = "tsMenuRefreshAppClientConfig";
            this.tsMenuRefreshAppClientConfig.Size = new System.Drawing.Size(215, 22);
            this.tsMenuRefreshAppClientConfig.Text = "Refresh";
            this.tsMenuRefreshAppClientConfig.Click += new System.EventHandler(this.tsMenuRefreshAppClientConfig_Click);
            // 
            // tsMenuSaveAppClientConfig
            // 
            this.tsMenuSaveAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.saveHS;
            this.tsMenuSaveAppClientConfig.Name = "tsMenuSaveAppClientConfig";
            this.tsMenuSaveAppClientConfig.Size = new System.Drawing.Size(215, 22);
            this.tsMenuSaveAppClientConfig.Text = "Save";
            this.tsMenuSaveAppClientConfig.Click += new System.EventHandler(this.tsMenuSaveAppClientConfig_Click);
            // 
            // tsMenuQuitAppClientConfig
            // 
            this.tsMenuQuitAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuQuitAppClientConfig.Name = "tsMenuQuitAppClientConfig";
            this.tsMenuQuitAppClientConfig.Size = new System.Drawing.Size(215, 22);
            this.tsMenuQuitAppClientConfig.Text = "Quit";
            this.tsMenuQuitAppClientConfig.Click += new System.EventHandler(this.tsMenuQuitAppClientConfig_Click);
            // 
            // exploreToolStripMenuItem
            // 
            this.exploreToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources._46;
            this.exploreToolStripMenuItem.Name = "exploreToolStripMenuItem";
            this.exploreToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.exploreToolStripMenuItem.Text = "Explore";
            this.exploreToolStripMenuItem.Click += new System.EventHandler(this.exploreToolStripMenuItem_Click);
            // 
            // mnCnnStrings
            // 
            this.mnCnnStrings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuNewCnnString,
            this.tsMenuQuitDataAccessCnnString});
            this.mnCnnStrings.Name = "mnContextConfigManager";
            this.mnCnnStrings.Size = new System.Drawing.Size(192, 48);
            // 
            // tSMenuNewCnnString
            // 
            this.tSMenuNewCnnString.Image = global::ConfigurationApp.Properties.Resources.add;
            this.tSMenuNewCnnString.Name = "tSMenuNewCnnString";
            this.tSMenuNewCnnString.Size = new System.Drawing.Size(191, 22);
            this.tSMenuNewCnnString.Text = "New connection string";
            this.tSMenuNewCnnString.Click += new System.EventHandler(this.tsMenuNewCnnString_Click);
            // 
            // tsMenuQuitDataAccessCnnString
            // 
            this.tsMenuQuitDataAccessCnnString.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuQuitDataAccessCnnString.Name = "tsMenuQuitDataAccessCnnString";
            this.tsMenuQuitDataAccessCnnString.Size = new System.Drawing.Size(191, 22);
            this.tsMenuQuitDataAccessCnnString.Text = "Remove all";
            this.tsMenuQuitDataAccessCnnString.Click += new System.EventHandler(this.tsMenuQuitDataAccessCnnString_Click);
            // 
            // mnSection
            // 
            this.mnSection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuItemQuitSection});
            this.mnSection.Name = "mnContextConfigManager";
            this.mnSection.Size = new System.Drawing.Size(106, 26);
            // 
            // tsMenuItemQuitSection
            // 
            this.tsMenuItemQuitSection.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuItemQuitSection.Name = "tsMenuItemQuitSection";
            this.tsMenuItemQuitSection.Size = new System.Drawing.Size(105, 22);
            this.tsMenuItemQuitSection.Text = "Quit";
            this.tsMenuItemQuitSection.Click += new System.EventHandler(this.tsMenuItemQuitSection_Click);
            // 
            // mnCnnString
            // 
            this.mnCnnString.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuQuitCnnString,
            this.tsMenuRenameCnnString});
            this.mnCnnString.Name = "mnContextConfigManager";
            this.mnCnnString.Size = new System.Drawing.Size(125, 48);
            // 
            // tsMenuQuitCnnString
            // 
            this.tsMenuQuitCnnString.Image = global::ConfigurationApp.Properties.Resources.Delete;
            this.tsMenuQuitCnnString.Name = "tsMenuQuitCnnString";
            this.tsMenuQuitCnnString.Size = new System.Drawing.Size(124, 22);
            this.tsMenuQuitCnnString.Text = "Quit";
            this.tsMenuQuitCnnString.Click += new System.EventHandler(this.tsMenuQuitCnnString_Click_1);
            // 
            // tsMenuRenameCnnString
            // 
            this.tsMenuRenameCnnString.Image = global::ConfigurationApp.Properties.Resources.mail_small;
            this.tsMenuRenameCnnString.Name = "tsMenuRenameCnnString";
            this.tsMenuRenameCnnString.Size = new System.Drawing.Size(124, 22);
            this.tsMenuRenameCnnString.Text = "Rename";
            this.tsMenuRenameCnnString.Click += new System.EventHandler(this.tsMenuRenameCnnString_Click);
            // 
            // dockPanelAppConfigClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(227, 449);
            this.Controls.Add(this.treeView1);
            this.Name = "dockPanelAppConfigClient";
            this.TabText = " App Config Client";
            this.Text = " App Config Client";
            this.Load += new System.EventHandler(this.dockPanelAppConfigClient_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.dockPanelAppConfigClient_FormClosed);
            this.mnRoot.ResumeLayout(false);
            this.mnAppConfigAplications.ResumeLayout(false);
            this.mnCnnStrings.ResumeLayout(false);
            this.mnSection.ResumeLayout(false);
            this.mnCnnString.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void tsMenuQuitCnnString_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imgImages;
        private System.Windows.Forms.ContextMenuStrip mnAppConfigAplications;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemAddConfigurationProvider;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemAddDataConnection;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemWrapper;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemWrapperWebService;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemWrapperRemoting;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemWrappeRemove;
        private System.Windows.Forms.ToolStripMenuItem tsMenuRefreshAppClientConfig;
        private System.Windows.Forms.ToolStripMenuItem tsMenuSaveAppClientConfig;
        private System.Windows.Forms.ToolStripMenuItem tsMenuQuitAppClientConfig;
        private System.Windows.Forms.ContextMenuStrip mnCnnStrings;
        private System.Windows.Forms.ToolStripMenuItem tSMenuNewCnnString;
        private System.Windows.Forms.ToolStripMenuItem tsMenuQuitDataAccessCnnString;
        private System.Windows.Forms.ContextMenuStrip mnSection;
        private System.Windows.Forms.ToolStripMenuItem tsMenuItemQuitSection;
        private System.Windows.Forms.ContextMenuStrip mnCnnString;
        private System.Windows.Forms.ToolStripMenuItem tsMenuQuitCnnString;
        private System.Windows.Forms.ToolStripMenuItem tsMenuRenameCnnString;
        private System.Windows.Forms.ContextMenuStrip mnRoot;
        private System.Windows.Forms.ToolStripMenuItem tsMenuNewFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuSaveAllFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuQuitAllFile;
        private System.Windows.Forms.ToolStripMenuItem tsMenuRefreshAllFile;
        private System.Windows.Forms.ToolStripMenuItem exploreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDispatcherSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localToolStripMenuItem;
    }
}