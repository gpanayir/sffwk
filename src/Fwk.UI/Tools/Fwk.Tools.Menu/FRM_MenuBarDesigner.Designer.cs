using Fwk.UI.Controls.Menu;
namespace Fwk.Tools.Menu
{
    partial class FRM_MenuBarDesigner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FRM_MenuBarDesigner));
            this.grpEditionContainer = new DevExpress.XtraEditors.GroupControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnMoveUp = new DevExpress.XtraEditors.SimpleButton();
            this.btnMoveDown = new DevExpress.XtraEditors.SimpleButton();
            this.menuFileBindingSource = new System.Windows.Forms.BindingSource();
            this.lblFileRemoved = new System.Windows.Forms.Label();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.lstFiles = new DevExpress.XtraEditors.ListBoxControl();
            this.lblSelectedFileName = new DevExpress.XtraEditors.LabelControl();
            this.uC_NavMenu1 = new Fwk.UI.UC_NavMenu();
            this.btnAddNavBar = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddNavItem = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStripAppClientConfig = new System.Windows.Forms.ToolStrip();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.removeFiletoolStripBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.grpEditionContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuFileBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uC_NavMenu1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStripAppClientConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpEditionContainer
            // 
            this.grpEditionContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEditionContainer.Location = new System.Drawing.Point(358, 66);
            this.grpEditionContainer.LookAndFeel.SkinName = "Blue";
            this.grpEditionContainer.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpEditionContainer.LookAndFeel.UseWindowsXPTheme = true;
            this.grpEditionContainer.Margin = new System.Windows.Forms.Padding(0);
            this.grpEditionContainer.Name = "grpEditionContainer";
            this.grpEditionContainer.ShowCaption = false;
            this.grpEditionContainer.Size = new System.Drawing.Size(580, 433);
            this.grpEditionContainer.TabIndex = 1;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Menu";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Button Group";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Button";
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
            this.barManager1.MaxItemId = 3;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(3, 5);
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1177, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(3, 570);
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1177, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(3, 5);
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 565);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1180, 5);
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 565);
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Image = global::Fwk.Tools.Menu.Properties.Resources.down_16;
            this.btnMoveUp.Location = new System.Drawing.Point(322, 186);
            this.btnMoveUp.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(33, 31);
            this.btnMoveUp.TabIndex = 4;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Image = global::Fwk.Tools.Menu.Properties.Resources.up_16;
            this.btnMoveDown.Location = new System.Drawing.Point(322, 146);
            this.btnMoveDown.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(33, 32);
            this.btnMoveDown.TabIndex = 5;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // menuFileBindingSource
            // 
            this.menuFileBindingSource.DataSource = typeof(Fwk.UI.Controls.Menu.MenuFile);
            // 
            // lblFileRemoved
            // 
            this.lblFileRemoved.AutoSize = true;
            this.lblFileRemoved.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblFileRemoved.ForeColor = System.Drawing.Color.Red;
            this.lblFileRemoved.Location = new System.Drawing.Point(386, 7);
            this.lblFileRemoved.Name = "lblFileRemoved";
            this.lblFileRemoved.Size = new System.Drawing.Size(345, 24);
            this.lblFileRemoved.TabIndex = 19;
            this.lblFileRemoved.Text = "Este archivo no existe o fue removido";
            this.lblFileRemoved.Visible = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Image = global::Fwk.Tools.Menu.Properties.Resources.refresh_32;
            this.btnRefresh.Location = new System.Drawing.Point(1122, 7);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(51, 46);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.ToolTip = "Refresh preview";
            this.btnRefresh.Visible = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lstFiles
            // 
            this.lstFiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lstFiles.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.menuFileBindingSource, "Name", true));
            this.lstFiles.DataSource = this.menuFileBindingSource;
            this.lstFiles.DisplayMember = "Name";
            this.lstFiles.Location = new System.Drawing.Point(3, 38);
            this.lstFiles.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lstFiles.Name = "lstFiles";
            this.lstFiles.Size = new System.Drawing.Size(222, 524);
            this.lstFiles.TabIndex = 20;
            this.lstFiles.SelectedIndexChanged += new System.EventHandler(this.lstFiles_SelectedIndexChanged);
            this.lstFiles.Click += new System.EventHandler(this.lstFiles_Click);
            // 
            // lblSelectedFileName
            // 
            this.lblSelectedFileName.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.lblSelectedFileName.Location = new System.Drawing.Point(239, 37);
            this.lblSelectedFileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSelectedFileName.Name = "lblSelectedFileName";
            this.lblSelectedFileName.Size = new System.Drawing.Size(24, 17);
            this.lblSelectedFileName.TabIndex = 21;
            this.lblSelectedFileName.Text = "[...]";
            // 
            // uC_NavMenu1
            // 
            this.uC_NavMenu1.ActiveGroup = null;
            this.uC_NavMenu1.AllowDrop = false;
            this.uC_NavMenu1.ContentButtonHint = null;
            this.uC_NavMenu1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_NavMenu1.Location = new System.Drawing.Point(3, 21);
            this.uC_NavMenu1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_NavMenu1.MenuBar = null;
            this.uC_NavMenu1.Name = "uC_NavMenu1";
            this.uC_NavMenu1.OptionsNavPane.ExpandedWidth = 140;
            this.uC_NavMenu1.OptionsNavPane.ShowOverflowPanel = false;
            this.uC_NavMenu1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.uC_NavMenu1.Size = new System.Drawing.Size(304, 409);
            this.uC_NavMenu1.TabIndex = 24;
            this.uC_NavMenu1.Text = "uC_NavMenu1";
            this.uC_NavMenu1.OnLinkButtonClick += new Fwk.UI.Controls.Menu.MenuButtonClickHandler(this.uC_NavMenu1_MenuButtonClick);
            this.uC_NavMenu1.ActiveGroupChanged += new DevExpress.XtraNavBar.NavBarGroupEventHandler(this.uC_NavMenu1_ActiveGroupChanged);
            // 
            // btnAddNavBar
            // 
            this.btnAddNavBar.Location = new System.Drawing.Point(359, 16);
            this.btnAddNavBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNavBar.Name = "btnAddNavBar";
            this.btnAddNavBar.Size = new System.Drawing.Size(96, 28);
            this.btnAddNavBar.TabIndex = 25;
            this.btnAddNavBar.Text = "Add gropup";
            this.btnAddNavBar.Click += new System.EventHandler(this.btnAddNavBar_Click);
            // 
            // btnAddNavItem
            // 
            this.btnAddNavItem.Location = new System.Drawing.Point(456, 16);
            this.btnAddNavItem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAddNavItem.Name = "btnAddNavItem";
            this.btnAddNavItem.Size = new System.Drawing.Size(96, 28);
            this.btnAddNavItem.TabIndex = 26;
            this.btnAddNavItem.Text = "Add item";
            this.btnAddNavItem.Click += new System.EventHandler(this.btnAddNavItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnAddNavItem);
            this.groupBox1.Controls.Add(this.btnAddNavBar);
            this.groupBox1.Controls.Add(this.grpEditionContainer);
            this.groupBox1.Controls.Add(this.btnMoveDown);
            this.groupBox1.Controls.Add(this.btnMoveUp);
            this.groupBox1.Location = new System.Drawing.Point(232, 57);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(941, 507);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(8, 16);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(310, 23);
            this.textBox1.TabIndex = 28;
            this.textBox1.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.uC_NavMenu1);
            this.groupBox2.Location = new System.Drawing.Point(7, 66);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(311, 433);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
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
            this.toolStripAppClientConfig.Location = new System.Drawing.Point(7, 4);
            this.toolStripAppClientConfig.Name = "toolStripAppClientConfig";
            this.toolStripAppClientConfig.Size = new System.Drawing.Size(170, 25);
            this.toolStripAppClientConfig.TabIndex = 28;
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
            // FRM_MenuBarDesigner
            // 
            this.AllowDrop = true;
            this.Appearance.BackColor = System.Drawing.Color.Snow;
            this.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1183, 575);
            this.Controls.Add(this.toolStripAppClientConfig);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblSelectedFileName);
            this.Controls.Add(this.lstFiles);
            this.Controls.Add(this.lblFileRemoved);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Blue";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.MinimumSize = new System.Drawing.Size(1020, 499);
            this.Name = "FRM_MenuBarDesigner";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Text = "Main menu designer";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MenuBarDesigner_FormClosing);
            this.Load += new System.EventHandler(this.MenuDesigner_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpEditionContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.menuFileBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uC_NavMenu1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.toolStripAppClientConfig.ResumeLayout(false);
            this.toolStripAppClientConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private DevExpress.XtraEditors.GroupControl grpEditionContainer;
        private DevExpress.XtraEditors.SimpleButton btnMoveUp;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.SimpleButton btnMoveDown;
        private System.Windows.Forms.BindingSource menuFileBindingSource;
        private System.Windows.Forms.Label lblFileRemoved;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.ListBoxControl lstFiles;
        private DevExpress.XtraEditors.LabelControl lblSelectedFileName;
        private DevExpress.XtraEditors.SimpleButton btnAddNavBar;
        private Fwk.UI.UC_NavMenu uC_NavMenu1;

        private DevExpress.XtraEditors.SimpleButton btnAddNavItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStrip toolStripAppClientConfig;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripButton saveAllToolStripButton;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton openToolStripButton;
        private System.Windows.Forms.ToolStripButton removeFiletoolStripBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}