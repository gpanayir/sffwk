namespace Fwk.UI.Forms
{
    partial class FormDialogBase
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
            this.aceptCancelButtonBar1 = new Fwk.UI.Controls.UC_AceptCancelButtonBar();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonEnabled = true;
            this.aceptCancelButtonBar1.AceptButtonText = "&Aceptar";
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonEnabled = true;
            this.aceptCancelButtonBar1.CancelButtonText = "&Cancelar";
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(7, 381);
            this.aceptCancelButtonBar1.Name = "aceptCancelButtonBar1";
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(599, 23);
            this.aceptCancelButtonBar1.TabIndex = 0;
            // 
            // FormDialogBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(613, 411);
            this.Controls.Add(this.aceptCancelButtonBar1);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDialogBase";
            this.Padding = new System.Windows.Forms.Padding(7);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormNewEditBase";
            this.ResumeLayout(false);

        }

        #endregion

        public Controls.UC_AceptCancelButtonBar aceptCancelButtonBar1;





    }
}
