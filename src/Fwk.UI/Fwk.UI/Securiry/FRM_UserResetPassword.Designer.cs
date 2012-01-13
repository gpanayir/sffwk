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
            // ctlButtonBar
            // 
         
            // 
            // uC_Reset1
            // 
            this.uC_Reset1.AcceptButton = null;
            this.uC_Reset1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_Reset1.CancelButton = null;
            this.uC_Reset1.Location = new System.Drawing.Point(7, 7);
            this.uC_Reset1.Name = "uC_Reset1";
            this.uC_Reset1.Size = new System.Drawing.Size(549, 102);
            this.uC_Reset1.TabIndex = 1;
            this.uC_Reset1.UserName = null;
            // 
            // FRM_UserResetPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 159);
            this.Controls.Add(this.uC_Reset1);
            this.Name = "FRM_UserResetPassword";
            this.Text = "Restablecer contraseña";
            this.Controls.SetChildIndex(this.uC_Reset1, 0);
        
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Security.Controls.UC_Reset uC_Reset1;


    }
}