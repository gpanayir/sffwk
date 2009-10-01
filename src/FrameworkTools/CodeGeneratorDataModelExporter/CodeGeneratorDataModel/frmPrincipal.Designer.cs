namespace CodeGenerator.DataModelExporter
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.cnnDataBaseForm1 = new Fwk.DataBase.CustomControls.CnnDataBaseForm();
            this.cnnDataBaseForm = new Fwk.DataBase.CustomControls.CnnDataBaseForm();
            this.dlgSaveFile = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cnnDataBaseForm1
            // 
            this.cnnDataBaseForm1.ButtonsBackColor = System.Drawing.Color.SlateGray;
            this.cnnDataBaseForm1.ButtonsFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cnnDataBaseForm1.ButtonsFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cnnDataBaseForm1.Connection = null;
            this.cnnDataBaseForm1.LabelsForeColor = System.Drawing.Color.SteelBlue;
            this.cnnDataBaseForm1.Location = new System.Drawing.Point(138, 128);
            this.cnnDataBaseForm1.Name = "cnnDataBaseForm1";
            this.cnnDataBaseForm1.Size = new System.Drawing.Size(9, 7);
            this.cnnDataBaseForm1.TabIndex = 0;
            this.cnnDataBaseForm1.TestBottonVisible = true;
            // 
            // cnnDataBaseForm
            // 
            this.cnnDataBaseForm.ButtonsBackColor = System.Drawing.Color.SlateGray;
            this.cnnDataBaseForm.ButtonsFlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cnnDataBaseForm.ButtonsFont = new System.Drawing.Font("Lucida Console", 8.25F);
            this.cnnDataBaseForm.Connection = null;
            this.cnnDataBaseForm.ForeColor = System.Drawing.Color.Black;
            this.cnnDataBaseForm.LabelsForeColor = System.Drawing.Color.MintCream;
            this.cnnDataBaseForm.Location = new System.Drawing.Point(4, 0);
            this.cnnDataBaseForm.Name = "cnnDataBaseForm";
            this.cnnDataBaseForm.Size = new System.Drawing.Size(400, 182);
            this.cnnDataBaseForm.TabIndex = 0;
            this.cnnDataBaseForm.TestBottonVisible = false;
            this.cnnDataBaseForm.AceptEvent += new Fwk.DataBase.CustomControls.AceptHandler(this.cnnDataBaseForm_AceptEvent);
            this.cnnDataBaseForm.CancelEvent += new Fwk.DataBase.CustomControls.CancelHandler(this.cnnDataBaseForm_CancelEvent);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 185);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusStrip1.Size = new System.Drawing.Size(406, 22);
            this.statusStrip1.TabIndex = 64;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblInfo
            // 
            this.lblInfo.BackColor = System.Drawing.SystemColors.Control;
            this.lblInfo.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.lblInfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 11F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(406, 207);
            this.Controls.Add(this.cnnDataBaseForm);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.cnnDataBaseForm1);
            this.Font = new System.Drawing.Font("Lucida Console", 8.25F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.Text = "Code Generator - Data Model Exporter";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.DataBase.CustomControls.CnnDataBaseForm cnnDataBaseForm1;
        private Fwk.DataBase.CustomControls.CnnDataBaseForm cnnDataBaseForm;
        private System.Windows.Forms.SaveFileDialog dlgSaveFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblInfo;
    }
}

