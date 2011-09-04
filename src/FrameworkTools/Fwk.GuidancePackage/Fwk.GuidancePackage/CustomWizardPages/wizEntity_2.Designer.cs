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
            this.ctrlTreeViewTables1 = new Fwk.GuidPk.ctrlTreeViewTables();
            this.txtTargetNamespace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Location = new System.Drawing.Point(0, 300);
            this.infoPanel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.infoPanel.Size = new System.Drawing.Size(1028, 394);
            this.infoPanel.Visible = false;
            // 
            // txtEntityName
            // 
            this.txtEntityName.BackColor = System.Drawing.Color.White;
            this.txtEntityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntityName.ForeColor = System.Drawing.Color.DimGray;
            this.txtEntityName.Location = new System.Drawing.Point(492, 180);
            this.txtEntityName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.label1.Location = new System.Drawing.Point(343, 180);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 25);
            this.label1.TabIndex = 66;
            this.label1.Text = "Entity Name";
            // 
            // ctrlTreeViewTables1
            // 
            this.ctrlTreeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlTreeViewTables1.CheckBoxes = true;
            this.ctrlTreeViewTables1.Location = new System.Drawing.Point(4, 150);
            this.ctrlTreeViewTables1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctrlTreeViewTables1.Name = "ctrlTreeViewTables1";
            this.ctrlTreeViewTables1.SelectedTable = null;
            this.ctrlTreeViewTables1.Size = new System.Drawing.Size(301, 537);
            this.ctrlTreeViewTables1.TabIndex = 67;
            // 
            // txtTargetNamespace
            // 
            this.txtTargetNamespace.BackColor = System.Drawing.Color.White;
            this.txtTargetNamespace.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTargetNamespace.ForeColor = System.Drawing.Color.DimGray;
            this.txtTargetNamespace.Location = new System.Drawing.Point(488, 129);
            this.txtTargetNamespace.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
            this.label2.Location = new System.Drawing.Point(343, 133);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 70;
            this.label2.Text = "Namespase";
            // 
            // wizEntity_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTargetNamespace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtEntityName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlTreeViewTables1);
            this.Controls.Add(this.label1);
            this.InfoRTBoxSize = new System.Drawing.Size(661, 74);
            this.Name = "wizEntity_2";
            this.Size = new System.Drawing.Size(1028, 694);
            this.Load += new System.EventHandler(this.wizEntity_2_Load);
            this.VisibleChanged += new System.EventHandler(this.wizEntity_2_VisibleChanged);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ctrlTreeViewTables1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.txtEntityName, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.txtTargetNamespace, 0);
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
    }
}
