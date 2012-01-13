namespace Fwk.UI.Security.Controls
{
    partial class UC_RoleNew
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.grpRolData = new DevExpress.XtraEditors.GroupControl();
            this.txtCreateRole = new Fwk.UI.Controls.TextBox(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRolData)).BeginInit();
            this.grpRolData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateRole.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(8, 23);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(37, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Nombre";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // grpRolData
            // 
            this.grpRolData.Controls.Add(this.txtCreateRole);
            this.grpRolData.Controls.Add(this.labelControl1);
            this.grpRolData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpRolData.Location = new System.Drawing.Point(0, 0);
            this.grpRolData.Name = "grpRolData";
            this.grpRolData.Size = new System.Drawing.Size(260, 75);
            this.grpRolData.TabIndex = 3;
            this.grpRolData.Text = "Datos rol";
            // 
            // txtCreateRole
            // 
            this.txtCreateRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCreateRole.CapitalOnly = false;
            this.txtCreateRole.Location = new System.Drawing.Point(6, 42);
            this.txtCreateRole.Name = "txtCreateRole";
            this.txtCreateRole.NotAllowedCharacters = "";
            this.txtCreateRole.NullTextValue = "";
            this.txtCreateRole.Required = true;
            this.txtCreateRole.RequiredErrorText = "Nombre requerido";
            this.txtCreateRole.Size = new System.Drawing.Size(249, 20);
            this.txtCreateRole.TabIndex = 3;
            this.txtCreateRole.TexMaxLength = 0;
            this.txtCreateRole.TextBoxType = Fwk.UI.Common.TextBoxTypeEnum.Nothing;
            this.txtCreateRole.Validating += new System.ComponentModel.CancelEventHandler(this.txtCreateRole_Validating);
            // 
            // UC_RoleNew
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.Controls.Add(this.grpRolData);
            this.Name = "UC_RoleNew";
            this.Size = new System.Drawing.Size(260, 75);
            this.Load += new System.EventHandler(this.UC_RoleNew_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRolData)).EndInit();
            this.grpRolData.ResumeLayout(false);
            this.grpRolData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreateRole.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.GroupControl grpRolData;
        private Fwk.UI.Controls.TextBox txtCreateRole;
    }
}
