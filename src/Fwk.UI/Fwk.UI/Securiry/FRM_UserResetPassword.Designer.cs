namespace Fwk.UI.Security.Controls
{
    partial class FRM_UserResetPassword
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
            this.uC_Reset1 = new Fwk.UI.Security.Controls.UC_Reset();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(9, 157);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(639, 28);
            // 
            // uC_Reset1
            // 
            this.uC_Reset1.AcceptButton = null;
            this.uC_Reset1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_Reset1.CancelButton = null;
            this.uC_Reset1.Location = new System.Drawing.Point(8, 9);
            this.uC_Reset1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.uC_Reset1.Name = "uC_Reset1";
            this.uC_Reset1.Size = new System.Drawing.Size(640, 126);
            this.uC_Reset1.TabIndex = 1;
            this.uC_Reset1.UserName = null;
            // 
            // FRM_UserResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 196);
            this.Controls.Add(this.uC_Reset1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FRM_UserResetPassword";
            this.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.Text = "Restablecer contraseña";
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.uC_Reset1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Security.Controls.UC_Reset uC_Reset1;


    }
}