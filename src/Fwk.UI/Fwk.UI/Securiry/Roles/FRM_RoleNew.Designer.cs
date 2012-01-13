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
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(7, 84);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(229, 23);
            this.aceptCancelButtonBar1.Enter += new System.EventHandler(this.aceptCancelButtonBar1_Enter);
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // uC_RoleNew1
            // 
            this.uC_RoleNew1.AcceptButton = null;
            this.uC_RoleNew1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.uC_RoleNew1.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.uC_RoleNew1.CancelButton = null;
            this.uC_RoleNew1.Location = new System.Drawing.Point(10, 10);
            this.uC_RoleNew1.Name = "uC_RoleNew1";
            this.uC_RoleNew1.RoleExists = false;
            this.uC_RoleNew1.Size = new System.Drawing.Size(223, 69);
            this.uC_RoleNew1.TabIndex = 1;
            // 
            // RoleNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(243, 114);
            this.Controls.Add(this.uC_RoleNew1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RoleNew";
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