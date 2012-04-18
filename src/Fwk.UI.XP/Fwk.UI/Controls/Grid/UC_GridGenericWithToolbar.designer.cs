using System;
using Fwk.UI.Controls.Menu;

namespace Fwk.UI.Controls
{
    partial class UC_GenericGridWithToolbar
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gridSimpleEditNoGroup1 = new Fwk.UI.Controls.GridSimpleEditNoGroup();
            this.gridSimpleEditNoGroupView1 = new Fwk.UI.Controls.GridSimpleEditNoGroupView();
            this.toolBar1 = new Fwk.UI.Controls.Menu.UC_ToolBarControl();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSimpleEditNoGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSimpleEditNoGroupView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.gridSimpleEditNoGroup1);
            this.panel1.Controls.Add(this.toolBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 238);
            this.panel1.TabIndex = 0;
            // 
            // gridSimpleEditNoGroup1
            // 
            this.gridSimpleEditNoGroup1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSimpleEditNoGroup1.EmbeddedNavigator.Name = "";
            this.gridSimpleEditNoGroup1.Location = new System.Drawing.Point(3, 62);
            this.gridSimpleEditNoGroup1.MainView = this.gridSimpleEditNoGroupView1;
            this.gridSimpleEditNoGroup1.Name = "gridSimpleEditNoGroup1";
            this.gridSimpleEditNoGroup1.Size = new System.Drawing.Size(413, 173);
            this.gridSimpleEditNoGroup1.TabIndex = 1;
            this.gridSimpleEditNoGroup1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSimpleEditNoGroupView1});
            // 
            // gridSimpleEditNoGroupView1
            // 
            this.gridSimpleEditNoGroupView1.GridControl = this.gridSimpleEditNoGroup1;
            this.gridSimpleEditNoGroupView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridSimpleEditNoGroupView1.Name = "gridSimpleEditNoGroupView1";
            this.gridSimpleEditNoGroupView1.OptionsBehavior.Editable = false;
            this.gridSimpleEditNoGroupView1.OptionsCustomization.AllowColumnMoving = false;
            this.gridSimpleEditNoGroupView1.OptionsCustomization.AllowFilter = false;
            this.gridSimpleEditNoGroupView1.OptionsCustomization.AllowGroup = false;
            this.gridSimpleEditNoGroupView1.OptionsDetail.AllowZoomDetail = false;
            this.gridSimpleEditNoGroupView1.OptionsFilter.AllowColumnMRUFilterList = false;
            this.gridSimpleEditNoGroupView1.OptionsFilter.AllowFilterEditor = false;
            this.gridSimpleEditNoGroupView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridSimpleEditNoGroupView1.OptionsMenu.EnableColumnMenu = false;
            this.gridSimpleEditNoGroupView1.OptionsMenu.EnableFooterMenu = false;
            this.gridSimpleEditNoGroupView1.OptionsMenu.EnableGroupPanelMenu = false;
            this.gridSimpleEditNoGroupView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridSimpleEditNoGroupView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.gridSimpleEditNoGroupView1.OptionsView.ShowGroupPanel = false;
            this.gridSimpleEditNoGroupView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            // 
            // toolBar1
            // 
            this.toolBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.toolBar1.AutoSize = true;
            this.toolBar1.Location = new System.Drawing.Point(3, 3);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.Size = new System.Drawing.Size(413, 60);
            this.toolBar1.TabIndex = 0;
            this.toolBar1.ToolBar = null;
            this.toolBar1.ToolBarButtonClick += new Fwk.UI.Controls.Menu.ToolBarButtonClickHandler(this.toolBar1_ToolBarButtonClick);
            // 
            // GenericGridWithToolbar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoSize = true;
            this.Controls.Add(this.panel1);
            this.Name = "GenericGridWithToolbar";
            this.Size = new System.Drawing.Size(419, 238);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSimpleEditNoGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSimpleEditNoGroupView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.Panel panel1;
        private Fwk.UI.Controls.GridSimpleEditNoGroupView gridSimpleEditNoGroupView1;
        public GridSimpleEditNoGroup gridSimpleEditNoGroup1;
        public UC_ToolBarControl toolBar1;

    }
}
