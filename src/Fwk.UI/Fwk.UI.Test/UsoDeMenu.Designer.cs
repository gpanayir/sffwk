namespace Fwk.UI.Test
{
    partial class UsoDeMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsoDeMenu));
            this.uC_NavMenu1 = new Fwk.UI.UC_NavMenu();
            this.navBarGroup1 = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem1 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem3 = new DevExpress.XtraNavBar.NavBarItem();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.navBarGroup2 = new DevExpress.XtraNavBar.NavBarGroup();
            ((System.ComponentModel.ISupportInitialize)(this.uC_NavMenu1)).BeginInit();
            this.SuspendLayout();
            // 
            // uC_NavMenu1
            // 
            this.uC_NavMenu1.ActiveGroup = this.navBarGroup1;
            this.uC_NavMenu1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_NavMenu1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.uC_NavMenu1.ContentButtonHint = null;
            this.uC_NavMenu1.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.navBarGroup2,
            this.navBarGroup1});
            this.uC_NavMenu1.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItem1,
            this.navBarItem2,
            this.navBarItem3});
            this.uC_NavMenu1.Location = new System.Drawing.Point(0, 3);
            this.uC_NavMenu1.MenuBar = ((Fwk.UI.Controls.Menu.MenuNavBar)(resources.GetObject("uC_NavMenu1.MenuBar")));
            this.uC_NavMenu1.Name = "uC_NavMenu1";
            this.uC_NavMenu1.OptionsNavPane.ExpandedWidth = 184;
            this.uC_NavMenu1.OptionsNavPane.ShowOverflowPanel = false;
            this.uC_NavMenu1.PaintStyleKind = DevExpress.XtraNavBar.NavBarViewKind.NavigationPane;
            this.uC_NavMenu1.Size = new System.Drawing.Size(262, 506);
            this.uC_NavMenu1.TabIndex = 0;
            this.uC_NavMenu1.Text = "uC_NavMenu1";
            this.uC_NavMenu1.OnLinkButtonClick += new Fwk.UI.Controls.Menu.MenuButtonClickHandler(this.uC_NavMenu1_OnLinkButtonClick);
            // 
            // navBarGroup1
            // 
            this.navBarGroup1.Caption = "navBarGroup1";
            this.navBarGroup1.Expanded = true;
            this.navBarGroup1.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.SmallIconsList;
            this.navBarGroup1.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem3)});
            this.navBarGroup1.Name = "navBarGroup1";
            // 
            // navBarItem1
            // 
            this.navBarItem1.Caption = "navBarItem1";
            this.navBarItem1.LargeImage = global::Fwk.UI.Test.Properties.Resources.add_32;
            this.navBarItem1.Name = "navBarItem1";
            this.navBarItem1.SmallImage = global::Fwk.UI.Test.Properties.Resources.add_16;
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "navBarItem2";
            this.navBarItem2.LargeImage = global::Fwk.UI.Test.Properties.Resources.admin_24;
            this.navBarItem2.Name = "navBarItem2";
            this.navBarItem2.SmallImage = global::Fwk.UI.Test.Properties.Resources.admin_16;
            // 
            // navBarItem3
            // 
            this.navBarItem3.Caption = "navBarItem3";
            this.navBarItem3.Name = "navBarItem3";
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(312, 3);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(251, 475);
            this.propertyGrid1.TabIndex = 1;
            // 
            // navBarGroup2
            // 
            this.navBarGroup2.Caption = "navBarGroup2";
            this.navBarGroup2.Name = "navBarGroup2";
            // 
            // UsoDeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 521);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.uC_NavMenu1);
            this.Name = "UsoDeMenu";
            this.Text = "Menu test";
            this.Load += new System.EventHandler(this.UsoDeMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.uC_NavMenu1)).EndInit();
            this.ResumeLayout(false);

        }

     

        #endregion

        private UC_NavMenu uC_NavMenu1;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem1;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItem3;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroup2;


    }
}