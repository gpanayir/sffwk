using Fwk.UI.Common;
using Fwk.UI.Controls;
using Fwk.Bases;
namespace Fwk.UI.Security.Controls
{
    partial class FRM_AuthenticationForm
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.cmbDominios = new DevExpress.XtraEditors.LookUpEdit();
            this.lblDominio = new System.Windows.Forms.Label();
            this.txtPassword = new Fwk.UI.Controls.TextBox();
            this.txtUserName = new Fwk.UI.Controls.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider();
            this.lblAuthentication = new System.Windows.Forms.Label();
            this.lbllTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgTitle = new System.Windows.Forms.PictureBox();
            this.aceptCancelButtonBar1 = new Fwk.UI.Controls.UC_AceptCancelButtonBar();
            this.btnChangePassword = new DevExpress.XtraEditors.SimpleButton();
            this.cmdAuthMode = new Fwk.UI.Controls.CommonEnumComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDominios.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAuthMode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAuthMode.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.cmbDominios);
            this.groupControl1.Controls.Add(this.lblDominio);
            this.groupControl1.Controls.Add(this.txtPassword);
            this.groupControl1.Controls.Add(this.txtUserName);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lblPassword);
            this.groupControl1.Location = new System.Drawing.Point(6, 98);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(311, 106);
            this.groupControl1.TabIndex = 444;
            this.groupControl1.Text = "Credenciales";
            // 
            // cmbDominios
            // 
            this.cmbDominios.Location = new System.Drawing.Point(117, 78);
            this.cmbDominios.Name = "cmbDominios";
            this.cmbDominios.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDominios.Properties.NullText = "";
            this.cmbDominios.Size = new System.Drawing.Size(170, 20);
            this.cmbDominios.TabIndex = 2;
            this.cmbDominios.EditValueChanged += new System.EventHandler(this.cmbDominios_EditValueChanged);
            // 
            // lblDominio
            // 
            this.lblDominio.AutoSize = true;
            this.lblDominio.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDominio.Location = new System.Drawing.Point(5, 81);
            this.lblDominio.Name = "lblDominio";
            this.lblDominio.Size = new System.Drawing.Size(44, 13);
            this.lblDominio.TabIndex = 19;
            this.lblDominio.Text = "Dominio";
            // 
            // txtPassword
            // 
            this.txtPassword.CapitalOnly = false;
            this.txtPassword.Location = new System.Drawing.Point(117, 52);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NotAllowedCharacters = "";
            this.txtPassword.NullTextValue = "";
            this.txtPassword.Properties.MaxLength = 128;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Required = true;
            this.txtPassword.RequiredErrorText = "La contraseña es requerida";
            this.txtPassword.Size = new System.Drawing.Size(170, 20);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TexMaxLength = 128;
            this.txtPassword.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            this.txtPassword.Validating += new System.ComponentModel.CancelEventHandler(this.txtPassword_Validating);
            // 
            // txtUserName
            // 
            this.txtUserName.CapitalOnly = false;
            this.txtUserName.Location = new System.Drawing.Point(117, 26);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.NotAllowedCharacters = "";
            this.txtUserName.NullTextValue = "";
            this.txtUserName.Properties.MaxLength = 50;
            this.txtUserName.Required = true;
            this.txtUserName.RequiredErrorText = "El nombre de usuario es requerido";
            this.txtUserName.Size = new System.Drawing.Size(170, 20);
            this.txtUserName.TabIndex = 0;
            this.txtUserName.TexMaxLength = 50;
            this.txtUserName.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Nombre de usuario";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(5, 55);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(63, 13);
            this.lblPassword.TabIndex = 14;
            this.lblPassword.Text = "Contraseña";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // lblAuthentication
            // 
            this.lblAuthentication.AutoSize = true;
            this.lblAuthentication.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuthentication.Location = new System.Drawing.Point(6, 69);
            this.lblAuthentication.Name = "lblAuthentication";
            this.lblAuthentication.Size = new System.Drawing.Size(72, 13);
            this.lblAuthentication.TabIndex = 448;
            this.lblAuthentication.Text = "Autenticación";
            // 
            // lbllTitle
            // 
            this.lbllTitle.AutoSize = true;
            this.lbllTitle.BackColor = System.Drawing.Color.White;
            this.lbllTitle.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllTitle.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lbllTitle.Location = new System.Drawing.Point(57, 10);
            this.lbllTitle.Name = "lbllTitle";
            this.lbllTitle.Size = new System.Drawing.Size(64, 35);
            this.lbllTitle.TabIndex = 449;
            this.lbllTitle.Text = "title";
            this.lbllTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.imgTitle);
            this.panel1.Controls.Add(this.lbllTitle);
            this.panel1.Location = new System.Drawing.Point(7, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(310, 50);
            this.panel1.TabIndex = 450;
            // 
            // imgTitle
            // 
            
            this.imgTitle.Location = new System.Drawing.Point(3, -2);
            this.imgTitle.Name = "imgTitle";
            this.imgTitle.Size = new System.Drawing.Size(50, 50);
            this.imgTitle.TabIndex = 450;
            this.imgTitle.TabStop = false;
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
            this.aceptCancelButtonBar1.Location = new System.Drawing.Point(3, 212);
            this.aceptCancelButtonBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.aceptCancelButtonBar1.Name = "aceptCancelButtonBar1";
            this.aceptCancelButtonBar1.Size = new System.Drawing.Size(335, 23);
            this.aceptCancelButtonBar1.TabIndex = 3;
            this.aceptCancelButtonBar1.ClickOkCancelEvent += new Fwk.UI.Common.ClickOkCancelHandler(this.aceptCancelButtonBar1_ClickOkCancelEvent);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChangePassword.Location = new System.Drawing.Point(6, 243);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(89, 22);
            this.btnChangePassword.TabIndex = 4;
            this.btnChangePassword.Text = "Cambiar clave";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // cmdAuthMode
            // 
            this.cmdAuthMode.AllowEmptyTextValue = false;
            this.cmdAuthMode.EditValue = "Error obteniendo los valores";
            this.cmdAuthMode.EnumType = Fwk.UI.Common.TypesEnum.AuthenticationModeEnum;
            this.cmdAuthMode.ErrorIconRightToLeft = false;
            this.cmdAuthMode.Location = new System.Drawing.Point(123, 66);
            this.cmdAuthMode.Name = "cmdAuthMode";
            this.cmdAuthMode.NullTextValue = null;
            this.cmdAuthMode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.cmdAuthMode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmdAuthMode.Properties.NullText = "<Seleccione una opción...>";
            this.cmdAuthMode.ReadOnly = false;
            this.cmdAuthMode.Required = false;
            this.cmdAuthMode.RequiredErrorText = null;
            this.cmdAuthMode.Size = new System.Drawing.Size(194, 20);
            this.cmdAuthMode.TabIndex = 5;
            this.cmdAuthMode.SelectedIndexChanged += new System.EventHandler(this.commonEnumComboBox1_SelectedIndexChanged);
            // 
            // FRM_AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(341, 239);
            this.Controls.Add(this.cmdAuthMode);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblAuthentication);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.aceptCancelButtonBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(404, 327);
            this.MinimizeBox = false;
            this.Name = "FRM_AuthenticationForm";
            this.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Iniciar sesión en ";
            this.Load += new System.EventHandler(this.AuthenticationForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDominios.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgTitle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAuthMode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmdAuthMode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private System.Windows.Forms.Label lblAuthentication;
        private System.Windows.Forms.Label lbllTitle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgTitle;
        private Fwk.UI.Controls.UC_AceptCancelButtonBar aceptCancelButtonBar1;
        private Fwk.UI.Controls.TextBox txtPassword;
        private Fwk.UI.Controls.TextBox txtUserName;
        private DevExpress.XtraEditors.SimpleButton btnChangePassword;
        private DevExpress.XtraEditors.LookUpEdit cmbDominios;
        private System.Windows.Forms.Label lblDominio;
        private CommonEnumComboBox cmdAuthMode;
    }
}