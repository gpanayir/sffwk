using System;
using System.ComponentModel;
namespace Fwk.UI.Security.Controls
{
    partial class FRM_UserChangePassword
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
            this.uC_UserChangePassword1 = new Fwk.UI.Security.Controls.UC_UserChangePassword();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(7, 122);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(298, 23);
            this.aceptCancelButtonBar1.TabIndex = 3;
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // uC_UserChangePassword1
            // 
            this.uC_UserChangePassword1.AcceptButton = null;
            this.uC_UserChangePassword1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uC_UserChangePassword1.CancelButton = null;
            this.uC_UserChangePassword1.Location = new System.Drawing.Point(5, 6);
            this.uC_UserChangePassword1.Name = "uC_UserChangePassword1";
            this.uC_UserChangePassword1.Size = new System.Drawing.Size(297, 109);
            this.uC_UserChangePassword1.TabIndex = 1;
            this.uC_UserChangePassword1.UserName = null;
            // 
            // FRM_AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 152);
            this.Controls.Add(this.uC_UserChangePassword1);
            this.Name = "FRM_AuthenticationForm";
            this.Text = "Cambiar contraseña";
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.uC_UserChangePassword1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Security.Controls.UC_UserChangePassword uC_UserChangePassword1;
    }
}