namespace Fwk.UI.Security
{
    partial class FRM_RoleAssign
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
            this.uC_RoleMain1 = new Fwk.UI.Security.Controls.UC_RoleMain();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(7, 537);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(833, 23);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // uC_RoleMain1
            // 
            this.uC_RoleMain1.AcceptButton = null;
            this.uC_RoleMain1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_RoleMain1.CancelButton = null;
            this.uC_RoleMain1.Location = new System.Drawing.Point(-1, 2);
            this.uC_RoleMain1.Name = "uC_RoleMain1";
            this.uC_RoleMain1.Size = new System.Drawing.Size(838, 529);
            this.uC_RoleMain1.TabIndex = 0;
            // 
            // FRM_RoleAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 567);
            this.Controls.Add(this.uC_RoleMain1);
            this.Name = "FRM_RoleAssign";
            this.Text = "Asignación de roles";
            this.Controls.SetChildIndex(this.uC_RoleMain1, 0);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Security.Controls.UC_RoleMain uC_RoleMain1;


      


    }
}