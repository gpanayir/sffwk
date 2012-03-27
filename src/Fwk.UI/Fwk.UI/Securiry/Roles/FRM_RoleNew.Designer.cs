namespace Fwk.UI.Security
{
    partial class FRM_RoleNew
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
            this.uC_RoleNew1 = new Fwk.UI.Security.Controls.UC_RoleNew();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(9, 101);
            this.aceptCancelButtonBar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(265, 28);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            this.aceptCancelButtonBar1.Enter += new System.EventHandler(this.aceptCancelButtonBar1_Enter);
            // 
            // uC_RoleNew1
            // 
            this.uC_RoleNew1.AcceptButton = null;
            this.uC_RoleNew1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_RoleNew1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.uC_RoleNew1.CancelButton = null;
            this.uC_RoleNew1.Location = new System.Drawing.Point(12, 12);
            this.uC_RoleNew1.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.uC_RoleNew1.Name = "uC_RoleNew1";
            this.uC_RoleNew1.RoleExists = false;
            this.uC_RoleNew1.Size = new System.Drawing.Size(260, 85);
            this.uC_RoleNew1.TabIndex = 1;
            // 
            // FRM_RoleNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(283, 140);
            this.Controls.Add(this.uC_RoleNew1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FRM_RoleNew";
            this.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.ShowInTaskbar = false;
            this.Text = "Nuevo rol";
            this.Load += new System.EventHandler(this.FRM_RoleNew_Load);
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.uC_RoleNew1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Security.Controls.UC_RoleNew uC_RoleNew1;

    }
}