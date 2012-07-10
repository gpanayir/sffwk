namespace Fwk.UI.Controls
{
    partial class UC_ComboBoxLabel
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
            this.components = new System.ComponentModel.Container();
            this.lblTitle = new System.Windows.Forms.Label();
            this.Control_workingArea = new Fwk.UI.Controls.Designers.WorkingAreaControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ComboBoxCtrl = new Fwk.UI.Controls.ComboBoxDxBase(this.components);
            this.Control_workingArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxCtrl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblTitle.Location = new System.Drawing.Point(21, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(44, 13);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Caption";
            // 
            // Control_workingArea
            // 
            this.Control_workingArea.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Control_workingArea.Controls.Add(this.ComboBoxCtrl);
            this.Control_workingArea.Location = new System.Drawing.Point(134, 3);
            this.Control_workingArea.Name = "Control_workingArea";
            this.Control_workingArea.Size = new System.Drawing.Size(331, 20);
            this.Control_workingArea.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Fwk.UI.Properties.Resources.file_edit_16;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 23);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // ComboBoxCtrl
            // 
            this.ComboBoxCtrl.AllowEmptyTextValue = false;
            this.ComboBoxCtrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ComboBoxCtrl.ErrorIconRightToLeft = false;
            this.ComboBoxCtrl.Location = new System.Drawing.Point(0, 0);
            this.ComboBoxCtrl.Name = "ComboBoxCtrl";
            this.ComboBoxCtrl.NullTextValue = null;
            this.ComboBoxCtrl.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ComboBoxCtrl.ReadOnly = false;
            this.ComboBoxCtrl.Required = false;
            this.ComboBoxCtrl.RequiredErrorText = null;
            this.ComboBoxCtrl.Size = new System.Drawing.Size(331, 20);
            this.ComboBoxCtrl.TabIndex = 0;
            // 
            // UC_ComboBoxLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.Control_workingArea);
            this.Name = "UC_ComboBoxLabel";
            this.Size = new System.Drawing.Size(468, 25);
            this.Control_workingArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ComboBoxCtrl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.UI.Controls.Designers.WorkingAreaControl Control_workingArea;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label lblTitle;
        private ComboBoxDxBase ComboBoxCtrl;
    }
}
