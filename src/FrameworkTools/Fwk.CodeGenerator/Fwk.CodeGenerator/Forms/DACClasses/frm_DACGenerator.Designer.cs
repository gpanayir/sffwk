using Fwk.Controls.Win32.TextCodeEditor;
namespace Fwk.CodeGenerator
{
    partial class frm_DACGenerator
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_DACGenerator));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlTreeViewTables1 = new Fwk.CodeGenerator.ctrlTreeViewTables();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeViewStoreProcedures1 = new Fwk.DataBase.CustomControls.TreeViewStoreProcedures();
            this.btnGenerate2 = new System.Windows.Forms.Button();
            this.directorySearcher1 = new System.DirectoryServices.DirectorySearcher();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripButton();
            this.lblServer = new System.Windows.Forms.ToolStripLabel();
            this.lblDatabase = new System.Windows.Forms.ToolStripLabel();
            this.btnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonGenerate = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.textCodeEditor1 = new TextCodeEditor();
            this.listViewCodeGenerated1 = new Fwk.CodeGenerator.ListViewCodeGenerated();
            this.txtSPName = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 31);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.ShowToolTips = true;
            this.tabControl1.Size = new System.Drawing.Size(216, 494);
            this.tabControl1.TabIndex = 21;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.ctrlTreeViewTables1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(208, 468);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "0";
            this.tabPage1.Text = "From tables";
            // 
            // ctrlTreeViewTables1
            // 
            this.ctrlTreeViewTables1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrlTreeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlTreeViewTables1.CheckBoxes = true;
            this.ctrlTreeViewTables1.Location = new System.Drawing.Point(2, 2);
            this.ctrlTreeViewTables1.Name = "ctrlTreeViewTables1";
            this.ctrlTreeViewTables1.Size = new System.Drawing.Size(198, 458);
            this.ctrlTreeViewTables1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.SteelBlue;
            this.tabPage2.Controls.Add(this.treeViewStoreProcedures1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(208, 468);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "1";
            this.tabPage2.Text = "From store procedures";
            // 
            // treeViewStoreProcedures1
            // 
            this.treeViewStoreProcedures1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewStoreProcedures1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.treeViewStoreProcedures1.Location = new System.Drawing.Point(0, 3);
            this.treeViewStoreProcedures1.Name = "treeViewStoreProcedures1";
            this.treeViewStoreProcedures1.SelectedStoreProcedure = null;
            this.treeViewStoreProcedures1.SelectedStoreProcedureName = global::Fwk.CodeGenerator.Properties.Resources.AppIcon;
            this.treeViewStoreProcedures1.Size = new System.Drawing.Size(207, 451);
            this.treeViewStoreProcedures1.StoreProcedures = null;
            this.treeViewStoreProcedures1.TabIndex = 0;
            this.treeViewStoreProcedures1.SelectObjectEvent += new Fwk.DataBase.CustomControls.SelectObjectHandler(this.treeViewStoreProcedures1_SelectObjectEvent);
            // 
            // btnGenerate2
            // 
            this.btnGenerate2.Location = new System.Drawing.Point(0, 0);
            this.btnGenerate2.Name = "btnGenerate2";
            this.btnGenerate2.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate2.TabIndex = 33;
            // 
            // directorySearcher1
            // 
            this.directorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01");
            this.directorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01");
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.lblServer,
            this.lblDatabase,
            this.btnRefresh,
            this.toolStripLabel1,
            this.toolStripSeparator1,
            this.toolStripButtonGenerate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(855, 25);
            this.toolStrip1.TabIndex = 26;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnConnect.Image")));
            this.btnConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(23, 22);
            this.btnConnect.Text = "Connect";
            this.btnConnect.ToolTipText = "Connect to database";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblServer
            // 
            this.lblServer.Name = "lblServer";
            this.lblServer.Size = new System.Drawing.Size(49, 22);
            this.lblServer.Text = "Server : ";
            // 
            // lblDatabase
            // 
            this.lblDatabase.Name = "lblDatabase";
            this.lblDatabase.Size = new System.Drawing.Size(60, 22);
            this.lblDatabase.Text = "Database: ";
            // 
            // btnRefresh
            // 
            this.btnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 22);
            this.btnRefresh.Text = "toolStripButton2";
            this.btnRefresh.ToolTipText = "Refresh ";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(59, 22);
            this.toolStripLabel1.Text = ".............";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonGenerate
            // 
            this.toolStripButtonGenerate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.toolStripButtonGenerate.Image = global::Fwk.CodeGenerator.Properties.Resources.servicerunning;
            this.toolStripButtonGenerate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonGenerate.Name = "toolStripButtonGenerate";
            this.toolStripButtonGenerate.Size = new System.Drawing.Size(80, 22);
            this.toolStripButtonGenerate.Text = "Generate";
            this.toolStripButtonGenerate.Click += new System.EventHandler(this.toolStripButtonGenerate_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(220, 28);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.textCodeEditor1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listViewCodeGenerated1);
            this.splitContainer1.Size = new System.Drawing.Size(634, 489);
            this.splitContainer1.SplitterDistance = 418;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 32;
            // 
            // textCodeEditor1
            // 
            this.textCodeEditor1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textCodeEditor1.BackColor = System.Drawing.Color.GhostWhite;
            this.textCodeEditor1.Location = new System.Drawing.Point(5, 3);
            this.textCodeEditor1.Name = "textCodeEditor1";
            this.textCodeEditor1.Size = new System.Drawing.Size(410, 483);
            this.textCodeEditor1.TabIndex = 31;
            this.textCodeEditor1.TitleText = "";
            this.textCodeEditor1.TitleVisible = true;
            // 
            // listViewCodeGenerated1
            // 
            this.listViewCodeGenerated1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewCodeGenerated1.ForeColorBE = System.Drawing.Color.Empty;
            this.listViewCodeGenerated1.ForeColorDAC = System.Drawing.Color.Empty;
            this.listViewCodeGenerated1.ForeColorSP = System.Drawing.Color.Empty;
            this.listViewCodeGenerated1.ForeColorSVC = System.Drawing.Color.Empty;
            this.listViewCodeGenerated1.Location = new System.Drawing.Point(3, -7);
            this.listViewCodeGenerated1.Name = "listViewCodeGenerated1";
            this.listViewCodeGenerated1.NodeBE = null;
            this.listViewCodeGenerated1.NodeCustomSVC = null;
            this.listViewCodeGenerated1.NodeDAC = null;
            this.listViewCodeGenerated1.NodeSP = null;
            this.listViewCodeGenerated1.NodeSVC = null;
            this.listViewCodeGenerated1.NodeTDG = null;
            this.listViewCodeGenerated1.Size = new System.Drawing.Size(209, 493);
            this.listViewCodeGenerated1.TabIndex = 0;
            this.listViewCodeGenerated1.StoredProcedureCodeGeneratedSelectEvent += new Fwk.CodeGenerator.StoredProcedureCodeGeneratedSelectHandler(this.listViewCodeGenerated1_StoreProcedureCodeGeneratedSelectEvent);
            this.listViewCodeGenerated1.ServiceCodeGeneratedSelectEvent += new Fwk.CodeGenerator.ServiceCodeGeneratedSelectHandler(this.listViewCodeGenerated1_ServiceCodeGeneratedSelectEvent);
            this.listViewCodeGenerated1.DACCodeGeneratedSelectEvent += new Fwk.CodeGenerator.DACCodeGeneratedSelectHandler(this.listViewCodeGenerated1_DACCodeGeneratedSelectEvent);
            this.listViewCodeGenerated1.BECodeGeneratedSelectEvent += new Fwk.CodeGenerator.BECodeGeneratedSelectHandler(this.listViewCodeGenerated1_BECodeGeneratedSelectEvent);
            this.listViewCodeGenerated1.TDGCodeGeneratedSelectEvent += new Fwk.CodeGenerator.TDGCodeGeneratedSelectHandler(this.listViewCodeGenerated1_TDGCodeGeneratedSelectEvent);
            // 
            // txtSPName
            // 
            this.txtSPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSPName.Location = new System.Drawing.Point(135, 21);
            this.txtSPName.Name = "txtSPName";
            this.txtSPName.Size = new System.Drawing.Size(137, 20);
            this.txtSPName.TabIndex = 2;
            // 
            // frm_DACGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(855, 529);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnGenerate2);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(798, 534);
            this.Name = "frm_DACGenerator";
            this.TabText = "Back End :.";
            this.Text = "Back End components code generator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;

        private System.Windows.Forms.TabPage tabPage2;
        internal System.Windows.Forms.Button btnGenerate2;
        private System.DirectoryServices.DirectorySearcher directorySearcher1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnConnect;
        private System.Windows.Forms.ToolStripLabel lblServer;
        private System.Windows.Forms.ToolStripLabel lblDatabase;
        private System.Windows.Forms.ToolStripButton btnRefresh;
        private Fwk.DataBase.CustomControls.TreeViewStoreProcedures treeViewStoreProcedures1;
        private System.Windows.Forms.SplitContainer splitContainer1;

        private ListViewCodeGenerated listViewCodeGenerated1;
    
        private System.Windows.Forms.TextBox txtSPName;
        private System.Windows.Forms.ToolStripButton toolStripButtonGenerate;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        
        private TextCodeEditor textCodeEditor1;
        private Fwk.CodeGenerator.ctrlTreeViewTables ctrlTreeViewTables1;
      
    }
}
