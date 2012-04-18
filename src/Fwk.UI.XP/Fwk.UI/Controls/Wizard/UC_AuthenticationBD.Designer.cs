namespace Fwk.UI.Controls.Wizard
{
    partial class UC_AuthenticationBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_AuthenticationBD));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkAuthIntegrated = new DevExpress.XtraEditors.CheckEdit();
            this.cmbServers = new DevExpress.XtraEditors.LookUpEdit();
            this.lstDataBases = new DevExpress.XtraEditors.ImageListBoxControl();
            this.label4 = new System.Windows.Forms.Label();
            this.BGWServers = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.BGWBases = new System.ComponentModel.BackgroundWorker();
            this.txtPassword = new Fwk.UI.Controls.TextBox(this.components);
            this.txtUser = new Fwk.UI.Controls.TextBox(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chkAuthIntegrated.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServers.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDataBases)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Servidor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Contraseña";
            // 
            // chkAuthIntegrated
            // 
            this.chkAuthIntegrated.EditValue = true;
            this.chkAuthIntegrated.Location = new System.Drawing.Point(8, 90);
            this.chkAuthIntegrated.Name = "chkAuthIntegrated";
            this.chkAuthIntegrated.Properties.Caption = "Usa seguridad integrada";
            this.chkAuthIntegrated.Size = new System.Drawing.Size(141, 18);
            this.chkAuthIntegrated.TabIndex = 6;
            this.chkAuthIntegrated.CheckedChanged += new System.EventHandler(this.chkAuthIntegrated_CheckedChanged);
            // 
            // cmbServers
            // 
            this.cmbServers.Location = new System.Drawing.Point(8, 143);
            this.cmbServers.Name = "cmbServers";
            this.cmbServers.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbServers.Properties.NullText = "Seleccione una opción...";
            this.cmbServers.Size = new System.Drawing.Size(258, 20);
            this.cmbServers.TabIndex = 7;
            this.cmbServers.EditValueChanged += new System.EventHandler(this.cmbServers_EditValueChanged);
            this.cmbServers.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.cmbServers_EditValueChanging);
            // 
            // lstDataBases
            // 
            this.lstDataBases.Location = new System.Drawing.Point(9, 194);
            this.lstDataBases.Name = "lstDataBases";
            this.lstDataBases.Size = new System.Drawing.Size(258, 140);
            this.lstDataBases.TabIndex = 8;
            this.lstDataBases.SelectedIndexChanged += new System.EventHandler(this.lstDataBases_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Bases de Datos";
            // 
            // BGWServers
            // 
            this.BGWServers.WorkerSupportsCancellation = true;
            this.BGWServers.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.BGWServers.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(270, 142);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 22);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(270, 194);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 22);
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            // 
            // BGWBases
            // 
            this.BGWBases.WorkerSupportsCancellation = true;
            this.BGWBases.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWBases_DoWork);
            this.BGWBases.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWBases_RunWorkerCompleted);
            // 
            // txtPassword
            // 
            this.txtPassword.CapitalOnly = false;
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(10, 64);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.NotAllowedCharacters = "";
            this.txtPassword.NullTextValue = "";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Required = false;
            this.txtPassword.RequiredErrorText = null;
            this.txtPassword.Size = new System.Drawing.Size(258, 20);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TexMaxLength = 0;
            this.txtPassword.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            // 
            // txtUser
            // 
            this.txtUser.CapitalOnly = false;
            this.txtUser.Enabled = false;
            this.txtUser.Location = new System.Drawing.Point(10, 25);
            this.txtUser.Name = "txtUser";
            this.txtUser.NotAllowedCharacters = "";
            this.txtUser.NullTextValue = "";
            this.txtUser.Required = false;
            this.txtUser.RequiredErrorText = null;
            this.txtUser.Size = new System.Drawing.Size(258, 20);
            this.txtUser.TabIndex = 2;
            this.txtUser.TexMaxLength = 0;
            this.txtUser.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // UC_AuthenticationBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstDataBases);
            this.Controls.Add(this.cmbServers);
            this.Controls.Add(this.chkAuthIntegrated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.label1);
            this.Name = "UC_AuthenticationBD";
            this.Size = new System.Drawing.Size(299, 340);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.UC_AuthenticationBD_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.chkAuthIntegrated.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbServers.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstDataBases)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Fwk.UI.Controls.TextBox txtUser;
        private Fwk.UI.Controls.TextBox txtPassword;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.CheckEdit chkAuthIntegrated;
        private DevExpress.XtraEditors.LookUpEdit cmbServers;
        private DevExpress.XtraEditors.ImageListBoxControl lstDataBases;
        private System.Windows.Forms.Label label4;
        private System.ComponentModel.BackgroundWorker BGWServers;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker BGWBases;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}
