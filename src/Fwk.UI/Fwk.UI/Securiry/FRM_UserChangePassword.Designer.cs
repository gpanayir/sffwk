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
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtPasswordConfirm = new Fwk.UI.Controls.TextBox(this.components);
            this.txtNewPassword = new Fwk.UI.Controls.TextBox(this.components);
            this.txtOldPassword = new Fwk.UI.Controls.TextBox(this.components);
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // aceptCancelButtonBar1
            // 
            this.aceptCancelButtonBar1.AceptButtonVisible = true;
            this.aceptCancelButtonBar1.BottomsVisible = true;
            this.aceptCancelButtonBar1.CancelButtonVisible = true;
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(9, 148);
            this.aceptCancelButtonBar1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(506, 28);
            this.aceptCancelButtonBar1.TabIndex = 3;
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtPasswordConfirm);
            this.groupControl1.Controls.Add(this.txtNewPassword);
            this.groupControl1.Controls.Add(this.txtOldPassword);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(9, 11);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(506, 137);
            this.groupControl1.TabIndex = 5;
            this.groupControl1.Text = "Datos contraseña";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.CapitalOnly = false;
            this.txtPasswordConfirm.Location = new System.Drawing.Point(143, 95);
            this.txtPasswordConfirm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.NotAllowedCharacters = "";
            this.txtPasswordConfirm.NullTextValue = "";
            this.txtPasswordConfirm.Properties.MaxLength = 128;
            this.txtPasswordConfirm.Properties.PasswordChar = '*';
            this.txtPasswordConfirm.Required = true;
            this.txtPasswordConfirm.RequiredErrorText = "Requerido";
            this.txtPasswordConfirm.Size = new System.Drawing.Size(184, 22);
            this.txtPasswordConfirm.TabIndex = 2;
            this.txtPasswordConfirm.TexMaxLength = 128;
            this.txtPasswordConfirm.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtPasswordConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.txtPasswordConfirm_Validating);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.CapitalOnly = false;
            this.txtNewPassword.Location = new System.Drawing.Point(143, 63);
            this.txtNewPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.NotAllowedCharacters = "";
            this.txtNewPassword.NullTextValue = "";
            this.txtNewPassword.Properties.MaxLength = 128;
            this.txtNewPassword.Properties.PasswordChar = '*';
            this.txtNewPassword.Required = true;
            this.txtNewPassword.RequiredErrorText = "Requerido";
            this.txtNewPassword.Size = new System.Drawing.Size(184, 22);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.TexMaxLength = 128;
            this.txtNewPassword.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.CapitalOnly = false;
            this.txtOldPassword.Location = new System.Drawing.Point(143, 31);
            this.txtOldPassword.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.NotAllowedCharacters = "";
            this.txtOldPassword.NullTextValue = "";
            this.txtOldPassword.Properties.MaxLength = 128;
            this.txtOldPassword.Properties.PasswordChar = '*';
            this.txtOldPassword.Required = true;
            this.txtOldPassword.RequiredErrorText = "Requerido";
            this.txtOldPassword.Size = new System.Drawing.Size(184, 22);
            this.txtOldPassword.TabIndex = 0;
            this.txtOldPassword.TexMaxLength = 128;
            this.txtOldPassword.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(9, 98);
            this.labelControl3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(129, 16);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Confirmar contraseña:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(9, 66);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(107, 16);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Nueva contraseña:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 34);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(108, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Contraseña actual:";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // FRM_UserChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 187);
            this.Controls.Add(this.groupControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "FRM_UserChangePassword";
            this.Padding = new System.Windows.Forms.Padding(9, 11, 9, 11);
            this.Text = "Cambiar contraseña";
            this.Controls.SetChildIndex(this.aceptCancelButtonBar1, 0);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private UI.Controls.TextBox txtPasswordConfirm;
        private UI.Controls.TextBox txtNewPassword;
        private UI.Controls.TextBox txtOldPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;

    }
}