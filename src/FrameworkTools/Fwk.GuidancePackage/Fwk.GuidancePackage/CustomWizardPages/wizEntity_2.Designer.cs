namespace Fwk.GuidPk
{
    partial class wizEntity_2
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
            this.txtEntityName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTargetNamespace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ctrlTreeViewTables1 = new Fwk.GuidPk.ctrlTreeViewTables();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ctrlTreeViewViews1 = new Fwk.GuidPk.ctrlTreeViewViews();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Location = new System.Drawing.Point(0, 301);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(5);
            this.infoPanel.Size = new System.Drawing.Size(1028, 393);
            this.infoPanel.Visible = false;
            // 
            // txtEntityName
            // 
            this.txtEntityName.BackColor = System.Drawing.Color.White;
            this.txtEntityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntityName.ForeColor = System.Drawing.Color.DimGray;
            this.txtEntityName.Location = new System.Drawing.Point(481, 239);
            this.txtEntityName.Margin = new System.Windows.Forms.Padding(4);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(507, 26);
            this.txtEntityName.TabIndex = 68;
            this.txtEntityName.TextChanged += new System.EventHandler(this.txtEntityName_TextChanged);
            this.txtEntityName.Enter += new System.EventHandler(this.txtEntityName_Enter);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTitle.Image = global::Fwk.GuidPk.Properties.Resources.applications_32;
            this.lblTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Location = new System.Drawing.Point(0, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(1028, 92);
            this.lblTitle.TabIndex = 69;
            this.lblTitle.Text = "Select table from databse";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(332, 239);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 66;
            this.label1.Text = "Entity Name";
            // 
            // txtTargetNamespace
            // 
            this.txtTargetNamespace.BackColor = System.Drawing.Color.White;
            this.txtTargetNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTargetNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.txtTargetNamespace.Location = new System.Drawing.Point(477, 188);
            this.txtTargetNamespace.Margin = new System.Windows.Forms.Padding(4);
            this.txtTargetNamespace.Name = "txtTargetNamespace";
            this.txtTargetNamespace.Size = new System.Drawing.Size(507, 26);
            this.txtTargetNamespace.TabIndex = 71;
            this.txtTargetNamespace.TextChanged += new System.EventHandler(this.txtTargetNamespace_TextChanged);
            this.txtTargetNamespace.Enter += new System.EventHandler(this.txtTargetNamespace_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gray;
            this.label2.Location = new System.Drawing.Point(332, 192);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 70;
            this.label2.Text = "Namespase";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(3, 109);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(312, 578);
            this.tabControl1.TabIndex = 72;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ctrlTreeViewTables1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(304, 549);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Tag = "0";
            this.tabPage1.Text = "Table";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ctrlTreeViewTables1
            // 
            this.ctrlTreeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlTreeViewTables1.CheckBoxes = true;
            this.ctrlTreeViewTables1.Location = new System.Drawing.Point(5, 5);
            this.ctrlTreeViewTables1.Margin = new System.Windows.Forms.Padding(5);
            this.ctrlTreeViewTables1.Name = "ctrlTreeViewTables1";
            this.ctrlTreeViewTables1.SelectedTable = null;
            this.ctrlTreeViewTables1.Size = new System.Drawing.Size(291, 519);
            this.ctrlTreeViewTables1.TabIndex = 67;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ctrlTreeViewViews1);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(304, 549);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Tag = "3";
            this.tabPage2.Text = "Views";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ctrlTreeViewViews1
            // 
            this.ctrlTreeViewViews1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlTreeViewViews1.CheckBoxes = true;
            this.ctrlTreeViewViews1.Location = new System.Drawing.Point(4, 7);
            this.ctrlTreeViewViews1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ctrlTreeViewViews1.Name = "ctrlTreeViewViews1";
            this.ctrlTreeViewViews1.Size = new System.Drawing.Size(292, 526);
            this.ctrlTreeViewViews1.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = global::Fwk.GuidPk.Properties.Resources.ref_16;
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(337, 121);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(185, 31);
            this.btnRefresh.TabIndex = 73;
            this.btnRefresh.Text = "Refresh database";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // wizEntity_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.txtTargetNamespace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEntityName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label1);
            this.InfoRTBoxSize = new System.Drawing.Size(661, 74);
            this.Name = "wizEntity_2";
            this.Size = new System.Drawing.Size(1028, 694);
            this.Load += new System.EventHandler(this.wizEntity_2_Load);
            this.VisibleChanged += new System.EventHandler(this.wizEntity_2_VisibleChanged);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.txtEntityName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTargetNamespace, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.btnRefresh, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtEntityName;
        public System.Windows.Forms.Label lblTitle;
        private ctrlTreeViewTables ctrlTreeViewTables1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtTargetNamespace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ctrlTreeViewViews ctrlTreeViewViews1;
        private System.Windows.Forms.Button btnRefresh;
    }
}
