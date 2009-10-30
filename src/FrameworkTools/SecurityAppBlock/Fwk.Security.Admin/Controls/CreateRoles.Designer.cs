namespace Fwk.Security.Admin.Controls
{
    partial class CreateRoles
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.label13 = new System.Windows.Forms.Label();
            this.txtRolName = new DevExpress.XtraEditors.TextEdit();
            this.btnCreateNewRol = new System.Windows.Forms.Button();
            this.fwkMessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.grdUsers = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emailDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdRoles = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lblusers = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRolName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl2.Controls.Add(this.label13);
            this.groupControl2.Controls.Add(this.txtRolName);
            this.groupControl2.Controls.Add(this.btnCreateNewRol);
            this.groupControl2.Location = new System.Drawing.Point(3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(633, 84);
            this.groupControl2.TabIndex = 19;
            this.groupControl2.Text = "Rol properties";
            // 
            // label13
            // 
            this.label13.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label13.Location = new System.Drawing.Point(6, 24);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(80, 16);
            this.label13.TabIndex = 13;
            this.label13.Text = "Rol name";
            // 
            // txtRolName
            // 
            this.txtRolName.Location = new System.Drawing.Point(9, 43);
            this.txtRolName.Name = "txtRolName";
            this.txtRolName.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.txtRolName.Properties.Appearance.Options.UseBackColor = true;
            this.txtRolName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.txtRolName.Size = new System.Drawing.Size(153, 22);
            this.txtRolName.TabIndex = 6;
            // 
            // btnCreateNewRol
            // 
            this.btnCreateNewRol.BackColor = System.Drawing.Color.White;
            this.btnCreateNewRol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateNewRol.Image = global::Fwk.Security.Admin.Properties.Resources.save_16;
            this.btnCreateNewRol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCreateNewRol.Location = new System.Drawing.Point(194, 40);
            this.btnCreateNewRol.Name = "btnCreateNewRol";
            this.btnCreateNewRol.Size = new System.Drawing.Size(81, 26);
            this.btnCreateNewRol.TabIndex = 5;
            this.btnCreateNewRol.Text = "Save rol";
            this.btnCreateNewRol.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCreateNewRol.UseVisualStyleBackColor = false;
            this.btnCreateNewRol.Click += new System.EventHandler(this.btnCreateNewRol_Click);
            // 
            // fwkMessageViewInfo
            // 
            this.fwkMessageViewInfo.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.fwkMessageViewInfo.IconSize = Fwk.Bases.FrontEnd.Controls.IconSize.Small;
            this.fwkMessageViewInfo.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.fwkMessageViewInfo.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information;
            this.fwkMessageViewInfo.TextMessageColor = System.Drawing.Color.White;
            this.fwkMessageViewInfo.TextMessageForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.fwkMessageViewInfo.Title = "Security admin";
            // 
            // grdUsers
            // 
            this.grdUsers.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdUsers.AutoGenerateColumns = false;
            this.grdUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.emailDataGridViewTextBoxColumn});
            this.grdUsers.DataSource = this.userBindingSource;
            this.grdUsers.Location = new System.Drawing.Point(330, 120);
            this.grdUsers.Name = "grdUsers";
            this.grdUsers.Size = new System.Drawing.Size(306, 350);
            this.grdUsers.TabIndex = 22;
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // emailDataGridViewTextBoxColumn
            // 
            this.emailDataGridViewTextBoxColumn.DataPropertyName = "Email";
            this.emailDataGridViewTextBoxColumn.HeaderText = "Email";
            this.emailDataGridViewTextBoxColumn.Name = "emailDataGridViewTextBoxColumn";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // grdRoles
            // 
            this.grdRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdRoles.AutoGenerateColumns = false;
            this.grdRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdRoles.DataSource = this.rolListBindingSource;
            this.grdRoles.Location = new System.Drawing.Point(3, 120);
            this.grdRoles.Name = "grdRoles";
            this.grdRoles.Size = new System.Drawing.Size(302, 350);
            this.grdRoles.TabIndex = 20;
            this.grdRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdRoles2_CellClick);
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            // 
            // rolListBindingSource
            // 
            this.rolListBindingSource.DataSource = typeof(Fwk.Security.Common.RolList);
            // 
            // lblusers
            // 
            this.lblusers.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusers.Image = global::Fwk.Security.Admin.Properties.Resources.User;
            this.lblusers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblusers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.lblusers.Location = new System.Drawing.Point(344, 91);
            this.lblusers.Name = "lblusers";
            this.lblusers.Size = new System.Drawing.Size(122, 23);
            this.lblusers.TabIndex = 24;
            this.lblusers.Text = "Asigned users";
            this.lblusers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(9, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 23);
            this.label1.TabIndex = 25;
            this.label1.Text = "Roles";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CreateRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblusers);
            this.Controls.Add(this.grdUsers);
            this.Controls.Add(this.grdRoles);
            this.Controls.Add(this.groupControl2);
            this.Name = "CreateRoles";
            this.Size = new System.Drawing.Size(644, 490);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtRolName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label13;
        private DevExpress.XtraEditors.TextEdit txtRolName;
        private System.Windows.Forms.Button btnCreateNewRol;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
        private System.Windows.Forms.DataGridView grdUsers;
        private System.Windows.Forms.DataGridView grdRoles;
        private System.Windows.Forms.BindingSource rolListBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label lblusers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emailDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userBindingSource;
    }
}
