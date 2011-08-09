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
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlTreeViewTables1 = new Fwk.GuidPk.ctrlTreeViewTables();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // infoPanel
            // 
            this.infoPanel.Location = new System.Drawing.Point(0, 245);
            this.infoPanel.Size = new System.Drawing.Size(771, 319);
            this.infoPanel.Visible = false;
            // 
            // txtEntityName
            // 
            this.txtEntityName.BackColor = System.Drawing.Color.White;
            this.txtEntityName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEntityName.ForeColor = System.Drawing.Color.DimGray;
            this.txtEntityName.Location = new System.Drawing.Point(138, 87);
            this.txtEntityName.Name = "txtEntityName";
            this.txtEntityName.Size = new System.Drawing.Size(630, 23);
            this.txtEntityName.TabIndex = 68;
            this.txtEntityName.Text = "Entity name";
            this.txtEntityName.TextChanged += new System.EventHandler(this.txtEntityName_TextChanged);
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
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(771, 75);
            this.lblTitle.TabIndex = 69;
            this.lblTitle.Text = "Select table from databse";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(17, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 66;
            this.label1.Text = "Entity Name";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(365, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 36);
            this.button1.TabIndex = 70;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlTreeViewTables1
            // 
            this.ctrlTreeViewTables1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ctrlTreeViewTables1.CheckBoxes = true;
            this.ctrlTreeViewTables1.Location = new System.Drawing.Point(3, 122);
            this.ctrlTreeViewTables1.Name = "ctrlTreeViewTables1";
            this.ctrlTreeViewTables1.SelectedTable = null;
            this.ctrlTreeViewTables1.Size = new System.Drawing.Size(226, 436);
            this.ctrlTreeViewTables1.TabIndex = 67;
            // 
            // wizEntity_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtEntityName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.ctrlTreeViewTables1);
            this.Controls.Add(this.label1);
            this.Name = "wizEntity_2";
            this.Size = new System.Drawing.Size(771, 564);
            this.Load += new System.EventHandler(this.wizEntity_2_Load);
            this.VisibleChanged += new System.EventHandler(this.wizEntity_2_VisibleChanged);
            this.Controls.SetChildIndex(this.infoPanel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.ctrlTreeViewTables1, 0);
            this.Controls.SetChildIndex(this.lblTitle, 0);
            this.Controls.SetChildIndex(this.txtEntityName, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtEntityName;
        public System.Windows.Forms.Label lblTitle;
        private ctrlTreeViewTables ctrlTreeViewTables1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}
