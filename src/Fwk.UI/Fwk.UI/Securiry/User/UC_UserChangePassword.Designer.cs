namespace Fwk.UI.Security.Controls
{
    partial class UC_UserChangePassword
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
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtPasswordConfirm = new Fwk.UI.Controls.TextBox(this.components);
            this.txtNewPassword = new Fwk.UI.Controls.TextBox(this.components);
            this.txtOldPassword = new Fwk.UI.Controls.TextBox(this.components);
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Contraseña actual:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(8, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(92, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Nueva contraseña:";
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
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(301, 107);
            this.groupControl1.TabIndex = 4;
            this.groupControl1.Text = "Datos contraseña";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.CapitalOnly = false;
            this.txtPasswordConfirm.Location = new System.Drawing.Point(123, 77);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.NotAllowedCharacters = "";
            this.txtPasswordConfirm.NullTextValue = "";
            this.txtPasswordConfirm.Properties.MaxLength = 128;
            this.txtPasswordConfirm.Properties.PasswordChar = '*';
            this.txtPasswordConfirm.Required = true;
            this.txtPasswordConfirm.RequiredErrorText = "Requerido";
            this.txtPasswordConfirm.Size = new System.Drawing.Size(158, 20);
            this.txtPasswordConfirm.TabIndex = 2;
            this.txtPasswordConfirm.TexMaxLength = 128;
            this.txtPasswordConfirm.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtPasswordConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.txtPasswordConfirm_Validating);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.CapitalOnly = false;
            this.txtNewPassword.Location = new System.Drawing.Point(123, 51);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.NotAllowedCharacters = "";
            this.txtNewPassword.NullTextValue = "";
            this.txtNewPassword.Properties.MaxLength = 128;
            this.txtNewPassword.Properties.PasswordChar = '*';
            this.txtNewPassword.Required = true;
            this.txtNewPassword.RequiredErrorText = "Requerido";
            this.txtNewPassword.Size = new System.Drawing.Size(158, 20);
            this.txtNewPassword.TabIndex = 1;
            this.txtNewPassword.TexMaxLength = 128;
            this.txtNewPassword.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.CapitalOnly = false;
            this.txtOldPassword.Location = new System.Drawing.Point(123, 25);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.NotAllowedCharacters = "";
            this.txtOldPassword.NullTextValue = "";
            this.txtOldPassword.Properties.MaxLength = 128;
            this.txtOldPassword.Properties.PasswordChar = '*';
            this.txtOldPassword.Required = true;
            this.txtOldPassword.RequiredErrorText = "Requerido";
            this.txtOldPassword.Size = new System.Drawing.Size(158, 20);
            this.txtOldPassword.TabIndex = 0;
            this.txtOldPassword.TexMaxLength = 128;
            this.txtOldPassword.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(8, 80);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(108, 13);
            this.labelControl3.TabIndex = 4;
            this.labelControl3.Text = "Confirmar contraseña:";
            // 
            // UC_UserChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.groupControl1);
            this.Name = "UC_UserChangePassword";
            this.Size = new System.Drawing.Size(301, 107);
            this.Load += new System.EventHandler(this.UC_UserChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOldPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private Fwk.UI.Controls.TextBox txtOldPassword;
        private Fwk.UI.Controls.TextBox txtPasswordConfirm;
        private Fwk.UI.Controls.TextBox txtNewPassword;
    }
}
