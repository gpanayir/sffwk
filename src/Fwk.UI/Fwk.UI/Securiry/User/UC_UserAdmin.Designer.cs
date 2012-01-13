namespace Fwk.UI.Security.Controls
{
    partial class UC_UserAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_UserAdmin));
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.chkMustChangePassword = new DevExpress.XtraEditors.CheckEdit();
            this.txtPasswordConfirm = new Fwk.UI.Controls.TextBox(this.components);
            this.txtPassword = new Fwk.UI.Controls.TextBox(this.components);
            this.txtUserName = new Fwk.UI.Controls.TextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnAddRol = new DevExpress.XtraEditors.SimpleButton();
            this.uC_RolesGrid1 = new Fwk.UI.Security.Controls.UC_RolesGrid();
            this.chkActiveFlag = new DevExpress.XtraEditors.CheckEdit();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chkApprove = new DevExpress.XtraEditors.CheckEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new Fwk.UI.Controls.TextBox(this.components);
            this.txtUserLastName = new Fwk.UI.Controls.TextBox(this.components);
            this.txtUserFirstName = new Fwk.UI.Controls.TextBox(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblDNI = new System.Windows.Forms.Label();
            this.txtDNI = new Fwk.UI.Controls.TextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkMustChangePassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkActiveFlag.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkApprove.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserLastName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserFirstName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDNI.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.chkMustChangePassword);
            this.groupControl3.Controls.Add(this.txtPasswordConfirm);
            this.groupControl3.Controls.Add(this.txtPassword);
            this.groupControl3.Controls.Add(this.txtUserName);
            this.groupControl3.Controls.Add(this.label6);
            this.groupControl3.Controls.Add(this.label1);
            this.groupControl3.Controls.Add(this.label2);
            this.groupControl3.Location = new System.Drawing.Point(3, 125);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(513, 142);
            this.groupControl3.TabIndex = 49;
            this.groupControl3.Text = "Seguridad";
            // 
            // chkMustChangePassword
            // 
            this.chkMustChangePassword.EditValue = true;
            this.chkMustChangePassword.Location = new System.Drawing.Point(6, 114);
            this.chkMustChangePassword.Name = "chkMustChangePassword";
            this.chkMustChangePassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMustChangePassword.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("chkMustChangePassword.Properties.Appearance.Image")));
            this.chkMustChangePassword.Properties.Appearance.Options.UseFont = true;
            this.chkMustChangePassword.Properties.Appearance.Options.UseImage = true;
            this.chkMustChangePassword.Properties.Caption = "Solicitar modificación de contraseña";
            this.chkMustChangePassword.Properties.DisplayValueChecked = "Unapproved";
            this.chkMustChangePassword.Properties.DisplayValueUnchecked = "Approved";
            this.chkMustChangePassword.Size = new System.Drawing.Size(192, 18);
            this.chkMustChangePassword.TabIndex = 9;
            this.chkMustChangePassword.ToolTip = "Seleccione esta opción para solicitar el cambio de contraseña la primera vez que " +
                "se loguee el usuario.";
            // 
            // txtPasswordConfirm
            // 
            this.txtPasswordConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPasswordConfirm.CapitalOnly = false;
            this.txtPasswordConfirm.EditValue = "";
            this.txtPasswordConfirm.Location = new System.Drawing.Point(134, 85);
            this.txtPasswordConfirm.Name = "txtPasswordConfirm";
            this.txtPasswordConfirm.NotAllowedCharacters = "";
            this.txtPasswordConfirm.NullTextValue = "";
            this.txtPasswordConfirm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPasswordConfirm.Properties.Appearance.Options.UseFont = true;
            this.txtPasswordConfirm.Properties.MaxLength = 20;
            this.txtPasswordConfirm.Properties.Name = "fProperties";
            this.txtPasswordConfirm.Properties.PasswordChar = '*';
            this.txtPasswordConfirm.Required = true;
            this.txtPasswordConfirm.RequiredErrorText = "Debe confirmar la contraseña";
            this.txtPasswordConfirm.Size = new System.Drawing.Size(249, 20);
            this.txtPasswordConfirm.TabIndex = 8;
            this.txtPasswordConfirm.TexMaxLength = 20;
            this.txtPasswordConfirm.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtPasswordConfirm.Validating += new System.ComponentModel.CancelEventHandler(this.txtPasswordConfirm_Validating);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.CapitalOnly = false;
            this.txtPassword.EditValue = "";
            this.txtPassword.Location = new System.Drawing.Point(134, 53);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NotAllowedCharacters = "";
            this.txtPassword.NullTextValue = "";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.MaxLength = 20;
            this.txtPassword.Properties.Name = "fProperties";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Required = true;
            this.txtPassword.RequiredErrorText = "Debe especificar contraseña";
            this.txtPassword.Size = new System.Drawing.Size(249, 20);
            this.txtPassword.TabIndex = 7;
            this.txtPassword.TexMaxLength = 20;
            this.txtPassword.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.CapitalOnly = false;
            this.txtUserName.Location = new System.Drawing.Point(134, 24);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.NotAllowedCharacters = "<>!|";
            this.txtUserName.NullTextValue = "";
            this.txtUserName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserName.Properties.Appearance.Options.UseFont = true;
            this.txtUserName.Properties.MaxLength = 50;
            this.txtUserName.Properties.Name = "fProperties";
            this.txtUserName.Required = true;
            this.txtUserName.RequiredErrorText = "Debe especificar un nombre de usuario";
            this.txtUserName.Size = new System.Drawing.Size(249, 20);
            this.txtUserName.TabIndex = 6;
            this.txtUserName.TexMaxLength = 50;
            this.txtUserName.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtUserName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserName_Validating);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(5, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 14);
            this.label6.TabIndex = 23;
            this.label6.Text = "Contraseña:";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(5, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "Confirmar contraseña:";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(5, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Nombre usuario:";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnAddRol);
            this.groupControl2.Controls.Add(this.uC_RolesGrid1);
            this.groupControl2.Location = new System.Drawing.Point(5, 273);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(511, 277);
            this.groupControl2.TabIndex = 53;
            this.groupControl2.Text = "Roles ";
            // 
            // btnAddRol
            // 
            this.btnAddRol.Location = new System.Drawing.Point(5, 23);
            this.btnAddRol.Name = "btnAddRol";
            this.btnAddRol.Size = new System.Drawing.Size(95, 23);
            this.btnAddRol.TabIndex = 10;
            this.btnAddRol.Text = "Ver roles";
            this.btnAddRol.Click += new System.EventHandler(this.btnAddRol_Click);
            // 
            // uC_RolesGrid1
            // 
            this.uC_RolesGrid1.AcceptButton = null;
            this.uC_RolesGrid1.CancelButton = null;
            this.uC_RolesGrid1.Location = new System.Drawing.Point(132, 23);
            this.uC_RolesGrid1.Name = "uC_RolesGrid1";
            this.uC_RolesGrid1.OnlyChecked = true;
            this.uC_RolesGrid1.Size = new System.Drawing.Size(249, 249);
            this.uC_RolesGrid1.TabIndex = 11;
            // 
            // chkActiveFlag
            // 
            this.chkActiveFlag.AllowDrop = true;
            this.chkActiveFlag.EditValue = true;
            this.chkActiveFlag.Location = new System.Drawing.Point(9, 5);
            this.chkActiveFlag.Name = "chkActiveFlag";
            this.chkActiveFlag.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkActiveFlag.Properties.Appearance.Options.UseFont = true;
            this.chkActiveFlag.Properties.Caption = "Vigente";
            this.chkActiveFlag.Properties.DisplayValueChecked = "Unapproved";
            this.chkActiveFlag.Properties.DisplayValueUnchecked = "Approved";
            this.chkActiveFlag.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkActiveFlag.Size = new System.Drawing.Size(70, 18);
            this.chkActiveFlag.TabIndex = 4;
            this.chkActiveFlag.ToolTip = "Indica si el usuario estara activo o vigente.-";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label7.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label7.Location = new System.Drawing.Point(9, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 18);
            this.label7.TabIndex = 57;
            this.label7.Text = "Apellido:";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(92, 18);
            this.label5.TabIndex = 56;
            this.label5.Text = "Nombre:";
            // 
            // chkApprove
            // 
            this.chkApprove.EditValue = true;
            this.chkApprove.Location = new System.Drawing.Point(8, 52);
            this.chkApprove.Name = "chkApprove";
            this.chkApprove.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApprove.Properties.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("chkApprove.Properties.Appearance.Image")));
            this.chkApprove.Properties.Appearance.Options.UseFont = true;
            this.chkApprove.Properties.Appearance.Options.UseImage = true;
            this.chkApprove.Properties.Caption = "Aprobado";
            this.chkApprove.Properties.DisplayValueChecked = "Unapproved";
            this.chkApprove.Properties.DisplayValueUnchecked = "Approved";
            this.chkApprove.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.chkApprove.Size = new System.Drawing.Size(70, 18);
            this.chkApprove.TabIndex = 5;
            this.chkApprove.ToolTip = "Click here to approve/Unapprove the user";
            this.chkApprove.Visible = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.label10.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label10.Location = new System.Drawing.Point(9, 95);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 18);
            this.label10.TabIndex = 55;
            this.label10.Text = "E-Mail:";
            // 
            // txtEmail
            // 
            this.txtEmail.CapitalOnly = false;
            this.txtEmail.Location = new System.Drawing.Point(137, 93);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.NotAllowedCharacters = "";
            this.txtEmail.NullTextValue = "";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.MaxLength = 50;
            this.txtEmail.Properties.Name = "fProperties";
            this.txtEmail.Required = false;
            this.txtEmail.RequiredErrorText = "El correo electronico es requerido";
            this.txtEmail.Size = new System.Drawing.Size(249, 20);
            this.txtEmail.TabIndex = 3;
            this.txtEmail.TexMaxLength = 50;
            this.txtEmail.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Email;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtUserLastName
            // 
            this.txtUserLastName.CapitalOnly = false;
            this.txtUserLastName.Location = new System.Drawing.Point(137, 37);
            this.txtUserLastName.Name = "txtUserLastName";
            this.txtUserLastName.NotAllowedCharacters = "<>!|";
            this.txtUserLastName.NullTextValue = "";
            this.txtUserLastName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserLastName.Properties.Appearance.Options.UseFont = true;
            this.txtUserLastName.Properties.MaxLength = 50;
            this.txtUserLastName.Properties.Name = "fProperties";
            this.txtUserLastName.Required = true;
            this.txtUserLastName.RequiredErrorText = "Debe especificar un apellido para el usuario";
            this.txtUserLastName.Size = new System.Drawing.Size(249, 20);
            this.txtUserLastName.TabIndex = 1;
            this.txtUserLastName.TexMaxLength = 50;
            this.txtUserLastName.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtUserLastName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserLastName_Validating);
            // 
            // txtUserFirstName
            // 
            this.txtUserFirstName.CapitalOnly = false;
            this.txtUserFirstName.Location = new System.Drawing.Point(137, 11);
            this.txtUserFirstName.Name = "txtUserFirstName";
            this.txtUserFirstName.NotAllowedCharacters = "<>!|";
            this.txtUserFirstName.NullTextValue = "";
            this.txtUserFirstName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUserFirstName.Properties.Appearance.Options.UseFont = true;
            this.txtUserFirstName.Properties.MaxLength = 50;
            this.txtUserFirstName.Properties.Name = "fProperties";
            this.txtUserFirstName.Required = true;
            this.txtUserFirstName.RequiredErrorText = "Debe especificar un nombre para el usuario";
            this.txtUserFirstName.Size = new System.Drawing.Size(249, 20);
            this.txtUserFirstName.TabIndex = 0;
            this.txtUserFirstName.TexMaxLength = 50;
            this.txtUserFirstName.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtUserFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.txtUserFirstName_Validating);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.chkActiveFlag);
            this.panelControl1.Controls.Add(this.chkApprove);
            this.panelControl1.Location = new System.Drawing.Point(429, 10);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(87, 31);
            this.panelControl1.TabIndex = 4;
            // 
            // lblDNI
            // 
            this.lblDNI.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.lblDNI.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblDNI.Location = new System.Drawing.Point(9, 67);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(56, 18);
            this.lblDNI.TabIndex = 60;
            this.lblDNI.Text = "DNI:";
            // 
            // txtDNI
            // 
            this.txtDNI.CapitalOnly = false;
            this.txtDNI.Location = new System.Drawing.Point(137, 65);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.NotAllowedCharacters = "<>!|";
            this.txtDNI.NullTextValue = "";
            this.txtDNI.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDNI.Properties.Appearance.Options.UseFont = true;
            this.txtDNI.Properties.MaxLength = 9;
            this.txtDNI.Properties.Name = "fProperties";
            this.txtDNI.Required = false;
            this.txtDNI.RequiredErrorText = "";
            this.txtDNI.Size = new System.Drawing.Size(249, 20);
            this.txtDNI.TabIndex = 2;
            this.txtDNI.TexMaxLength = 9;
            this.txtDNI.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            // 
            // UC_UserAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.lblDNI);
            this.Controls.Add(this.txtDNI);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.txtUserLastName);
            this.Controls.Add(this.txtUserFirstName);
            this.Controls.Add(this.groupControl3);
            this.Name = "UC_UserAdmin";
            this.Size = new System.Drawing.Size(522, 553);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkMustChangePassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPasswordConfirm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkActiveFlag.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkApprove.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserLastName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserFirstName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDNI.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Controls.TextBox txtEmail;
        private Fwk.UI.Controls.TextBox txtUserLastName;
        private Fwk.UI.Controls.TextBox txtUserFirstName;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private Fwk.UI.Controls.TextBox txtPasswordConfirm;
        private Fwk.UI.Controls.TextBox txtPassword;
        private Fwk.UI.Controls.TextBox txtUserName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnAddRol;
        private Fwk.UI.Security.Controls.UC_RolesGrid uC_RolesGrid1;
        private DevExpress.XtraEditors.CheckEdit chkActiveFlag;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.CheckEdit chkApprove;
        private System.Windows.Forms.Label label10;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label lblDNI;
        private Fwk.UI.Controls.TextBox txtDNI;
        private DevExpress.XtraEditors.CheckEdit chkMustChangePassword;
    }
}
