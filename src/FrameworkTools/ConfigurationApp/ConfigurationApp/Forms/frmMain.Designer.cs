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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblKeyName = new System.Windows.Forms.Label();
            this.lblGroupName = new System.Windows.Forms.Label();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.lblFileName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblKey = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblGroup = new System.Windows.Forms.Label();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteDeDespachadorDeServicioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuNewAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuLoadAppClientConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemSaveAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsMenuItemRefreshAllFiles = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
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
            this.tsButtonAppClientConfigShow = new System.Windows.Forms.ToolStripButton();
            this.tsButtonConfigManagerShow = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.toolStripAppClientConfig.SuspendLayout();
            this.toolStrip2.SuspendLayout();
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
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(719, 352);
            this.splitContainer1.SplitterDistance = 226;
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
            this.dockPanel1.Size = new System.Drawing.Size(226, 352);
            this.dockPanel1.TabIndex = 6;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lblKeyName);
            this.groupBox1.Controls.Add(this.lblGroupName);
            this.groupBox1.Controls.Add(this.propertyGrid1);
            this.groupBox1.Controls.Add(this.lblFileName);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblKey);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblGroup);
            this.groupBox1.Location = new System.Drawing.Point(6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 341);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // lblKeyName
            // 
            this.lblKeyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKeyName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblKeyName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblKeyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKeyName.ForeColor = System.Drawing.Color.DimGray;
            this.lblKeyName.Location = new System.Drawing.Point(76, 65);
            this.lblKeyName.Name = "lblKeyName";
            this.lblKeyName.Size = new System.Drawing.Size(386, 16);
            this.lblKeyName.TabIndex = 19;
            // 
            // lblGroupName
            // 
            this.lblGroupName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGroupName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblGroupName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroupName.ForeColor = System.Drawing.Color.DimGray;
            this.lblGroupName.Location = new System.Drawing.Point(76, 43);
            this.lblGroupName.Name = "lblGroupName";
            this.lblGroupName.Size = new System.Drawing.Size(386, 16);
            this.lblGroupName.TabIndex = 18;
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGrid1.HelpBackColor = System.Drawing.Color.White;
            this.propertyGrid1.LineColor = System.Drawing.Color.Gainsboro;
            this.propertyGrid1.Location = new System.Drawing.Point(7, 113);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(466, 224);
            this.propertyGrid1.TabIndex = 9;
            // 
            // lblFileName
            // 
            this.lblFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFileName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lblFileName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblFileName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileName.ForeColor = System.Drawing.Color.DimGray;
            this.lblFileName.Location = new System.Drawing.Point(76, 20);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(386, 16);
            this.lblFileName.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(4, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Value";
            // 
            // lblKey
            // 
            this.lblKey.AutoSize = true;
            this.lblKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKey.ForeColor = System.Drawing.Color.Black;
            this.lblKey.Location = new System.Drawing.Point(5, 65);
            this.lblKey.Name = "lblKey";
            this.lblKey.Size = new System.Drawing.Size(28, 13);
            this.lblKey.TabIndex = 11;
            this.lblKey.Text = "Key";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "File";
            // 
            // lblGroup
            // 
            this.lblGroup.AutoSize = true;
            this.lblGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGroup.ForeColor = System.Drawing.Color.Black;
            this.lblGroup.Location = new System.Drawing.Point(5, 43);
            this.lblGroup.Name = "lblGroup";
            this.lblGroup.Size = new System.Drawing.Size(41, 13);
            this.lblGroup.TabIndex = 9;
            this.lblGroup.Text = "Group";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteDeDespachadorDeServicioToolStripMenuItem,
            this.tsMenuItemSave,
            this.tsMenuItemSaveAllFiles,
            this.tsMenuItemRefreshAllFiles});
            this.archivoToolStripMenuItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.archivoToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.archivoToolStripMenuItem.Text = "File";
            // 
            // clienteDeDespachadorDeServicioToolStripMenuItem
            // 
            this.clienteDeDespachadorDeServicioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsMenuNewAppClientConfig,
            this.tsMenuLoadAppClientConfig});
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.mail_small;
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Name = "clienteDeDespachadorDeServicioToolStripMenuItem";
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.clienteDeDespachadorDeServicioToolStripMenuItem.Text = "App Config";
            // 
            // tsMenuNewAppClientConfig
            // 
            this.tsMenuNewAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.document;
            this.tsMenuNewAppClientConfig.Name = "tsMenuNewAppClientConfig";
            this.tsMenuNewAppClientConfig.Size = new System.Drawing.Size(152, 22);
            this.tsMenuNewAppClientConfig.Text = "New";
            this.tsMenuNewAppClientConfig.Click += new System.EventHandler(this.tsMenuNewAppClientConfig_Click);
            // 
            // tsMenuLoadAppClientConfig
            // 
            this.tsMenuLoadAppClientConfig.Image = global::ConfigurationApp.Properties.Resources.Open16x16;
            this.tsMenuLoadAppClientConfig.Name = "tsMenuLoadAppClientConfig";
            this.tsMenuLoadAppClientConfig.Size = new System.Drawing.Size(152, 22);
            this.tsMenuLoadAppClientConfig.Text = "Open";
            this.tsMenuLoadAppClientConfig.Click += new System.EventHandler(this.tsMenuLoadAppClientConfig_Click);
            // 
            // tsMenuItemSave
            // 
            this.tsMenuItemSave.Image = global::ConfigurationApp.Properties.Resources.DISK06;
            this.tsMenuItemSave.Name = "tsMenuItemSave";
            this.tsMenuItemSave.Size = new System.Drawing.Size(152, 22);
            this.tsMenuItemSave.Text = "Save";
            this.tsMenuItemSave.Click += new System.EventHandler(this.tsMenuItemSave_Click);
            // 
            // tsMenuItemSaveAllFiles
            // 
            this.tsMenuItemSaveAllFiles.Image = global::ConfigurationApp.Properties.Resources.DISKS04;
            this.tsMenuItemSaveAllFiles.Name = "tsMenuItemSaveAllFiles";
            this.tsMenuItemSaveAllFiles.Size = new System.Drawing.Size(152, 22);
            this.tsMenuItemSaveAllFiles.Text = "Save All";
            this.tsMenuItemSaveAllFiles.Click += new System.EventHandler(this.tsMenuItemSaveAllFiles_Click);
            // 
            // tsMenuItemRefreshAllFiles
            // 
            this.tsMenuItemRefreshAllFiles.Image = global::ConfigurationApp.Properties.Resources.Refresh;
            this.tsMenuItemRefreshAllFiles.Name = "tsMenuItemRefreshAllFiles";
            this.tsMenuItemRefreshAllFiles.Size = new System.Drawing.Size(152, 22);
            this.tsMenuItemRefreshAllFiles.Text = "Refresh all";
            this.tsMenuItemRefreshAllFiles.Click += new System.EventHandler(this.tsMenuItemRefreshAllFiles_Click);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.document;
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::ConfigurationApp.Properties.Resources.Open16x16;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.BackColor = System.Drawing.Color.LightSteelBlue;
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(757, 24);
            this.MainMenuStrip.TabIndex = 2;
            this.MainMenuStrip.Text = "menuStrip1";
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
            this.toolStripAppClientConfig.Size = new System.Drawing.Size(208, 25);
            this.toolStripAppClientConfig.TabIndex = 7;
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
            // tsButtonSaveAll
            // 
            this.tsButtonSaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsButtonSaveAll.Image = global::ConfigurationApp.Properties.Resources.SaveAllHS22222;
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
            // quitToolStripButton
            // 
            this.quitToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.quitToolStripButton.Image = global::ConfigurationApp.Properties.Resources.Delete;
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
            // tsButtonAppClientConfigShow
            // 
            this.tsButtonAppClientConfigShow.Image = global::ConfigurationApp.Properties.Resources.mail_small;
            this.tsButtonAppClientConfigShow.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsButtonAppClientConfigShow.Name = "tsButtonAppClientConfigShow";
            this.tsButtonAppClientConfigShow.Size = new System.Drawing.Size(78, 22);
            this.tsButtonAppClientConfigShow.Text = "App config";
            this.tsButtonAppClientConfigShow.Click += new System.EventHandler(this.tsButtonAppClientConfigShow_Click);
            // 
            // tsButtonConfigManagerShow
            // 
            this.tsButtonConfigManagerShow.Image = global::ConfigurationApp.Properties.Resources.news_info;
            this.tsButtonConfigManagerShow.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.tsButtonConfigManagerShow.Name = "tsButtonConfigManagerShow";
            this.tsButtonConfigManagerShow.Size = new System.Drawing.Size(106, 22);
            this.tsButtonConfigManagerShow.Text = "Config manager ";
            this.tsButtonConfigManagerShow.Click += new System.EventHandler(this.tsButtonConfigManagerShow_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.AllowItemReorder = true;
            this.toolStrip2.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsButtonAppClientConfigShow,
            this.tsButtonConfigManagerShow});
            this.toolStrip2.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.toolStrip2.Location = new System.Drawing.Point(232, 24);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(187, 25);
            this.toolStrip2.TabIndex = 8;
            this.toolStrip2.Text = "Enable trre view windows";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(757, 417);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStripAppClientConfig);
            this.Controls.Add(this.MainMenuStrip);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.Text = "Fwk libraries configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
            this.toolStripAppClientConfig.ResumeLayout(false);
            this.toolStripAppClientConfig.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblKey;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblGroup;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nToolStripMenuItem;
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
        private System.Windows.Forms.ToolStripButton tsButtonAppClientConfigShow;
        private System.Windows.Forms.ToolStripButton tsButtonConfigManagerShow;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Label lblKeyName;
        private System.Windows.Forms.Label lblGroupName;
    }
}

