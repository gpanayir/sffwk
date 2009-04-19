using Fwk.Security.Common;
namespace SecurityAppBlock.Admin
{
    partial class frmAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdmin));
            this.button1 = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageUsers = new System.Windows.Forms.TabPage();
            this.userAdmminControl1 = new SecurityAppBlock.Admin.Controls.UserAdminControl();
            this.tabPageRoles = new System.Windows.Forms.TabPage();
            this.rolesAdmin1 = new SecurityAppBlock.Admin.Controls.CreateRoles();
            this.tabPageAsingRol = new System.Windows.Forms.TabPage();
            this.assingRoles1 = new SecurityAppBlock.Admin.Controls.AssingRoles();
            this.tabPage_Rules = new System.Windows.Forms.TabPage();
            this.createRulesControl1 = new SecurityAppBlock.Admin.Controls.CheckRulesControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.assingRulesControl1 = new SecurityAppBlock.Admin.Controls.AssingRulesControl();
            this.lbltitle = new System.Windows.Forms.Label();
            this.fwkMessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageUsers.SuspendLayout();
            this.tabPageRoles.SuspendLayout();
            this.tabPageAsingRol.SuspendLayout();
            this.tabPage_Rules.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(573, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageUsers);
            this.tabControl1.Controls.Add(this.tabPageRoles);
            this.tabControl1.Controls.Add(this.tabPageAsingRol);
            this.tabControl1.Controls.Add(this.tabPage_Rules);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(7, 83);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(839, 553);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageUsers
            // 
            this.tabPageUsers.Controls.Add(this.userAdmminControl1);
            this.tabPageUsers.Location = new System.Drawing.Point(4, 22);
            this.tabPageUsers.Name = "tabPageUsers";
            this.tabPageUsers.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageUsers.Size = new System.Drawing.Size(831, 527);
            this.tabPageUsers.TabIndex = 0;
            this.tabPageUsers.Text = "Users";
            this.tabPageUsers.UseVisualStyleBackColor = true;
            // 
            // userAdmminControl1
            // 
            this.userAdmminControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userAdmminControl1.Location = new System.Drawing.Point(3, 3);
            this.userAdmminControl1.Name = "userAdmminControl1";
            this.userAdmminControl1.Size = new System.Drawing.Size(825, 521);
            this.userAdmminControl1.TabIndex = 0;
            this.userAdmminControl1.NewSecurityInfoCreated += new SecurityAppBlock.Admin.Controls.NewSecurityInfoCreatedHandler(this.userAdmminControl1_NewSecurityInfoCreated);
            // 
            // tabPageRoles
            // 
            this.tabPageRoles.Controls.Add(this.rolesAdmin1);
            this.tabPageRoles.Location = new System.Drawing.Point(4, 22);
            this.tabPageRoles.Name = "tabPageRoles";
            this.tabPageRoles.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRoles.Size = new System.Drawing.Size(831, 527);
            this.tabPageRoles.TabIndex = 1;
            this.tabPageRoles.Text = "Roles";
            this.tabPageRoles.UseVisualStyleBackColor = true;
            // 
            // rolesAdmin1
            // 
            this.rolesAdmin1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rolesAdmin1.Location = new System.Drawing.Point(3, 3);
            this.rolesAdmin1.Name = "rolesAdmin1";
            this.rolesAdmin1.Size = new System.Drawing.Size(825, 521);
            this.rolesAdmin1.TabIndex = 0;
            this.rolesAdmin1.NewSecurityInfoCreated += new SecurityAppBlock.Admin.Controls.NewSecurityInfoCreatedHandler(this.rolesAdmin1_NewSecurityInfoCreated);
            // 
            // tabPageAsingRol
            // 
            this.tabPageAsingRol.Controls.Add(this.assingRoles1);
            this.tabPageAsingRol.Location = new System.Drawing.Point(4, 22);
            this.tabPageAsingRol.Name = "tabPageAsingRol";
            this.tabPageAsingRol.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAsingRol.Size = new System.Drawing.Size(831, 527);
            this.tabPageAsingRol.TabIndex = 2;
            this.tabPageAsingRol.Text = "Assing roles";
            this.tabPageAsingRol.UseVisualStyleBackColor = true;
            // 
            // assingRoles1
            // 
            this.assingRoles1.Cursor = System.Windows.Forms.Cursors.Default;
            this.assingRoles1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assingRoles1.Location = new System.Drawing.Point(3, 3);
            this.assingRoles1.Name = "assingRoles1";
            this.assingRoles1.Size = new System.Drawing.Size(825, 521);
            this.assingRoles1.TabIndex = 0;
            this.assingRoles1.NewSecurityInfoCreated += new SecurityAppBlock.Admin.Controls.NewSecurityInfoCreatedHandler(this.assingRoles1_NewSecurityInfoCreated);
            // 
            // tabPage_Rules
            // 
            this.tabPage_Rules.Controls.Add(this.createRulesControl1);
            this.tabPage_Rules.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Rules.Name = "tabPage_Rules";
            this.tabPage_Rules.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Rules.Size = new System.Drawing.Size(831, 527);
            this.tabPage_Rules.TabIndex = 3;
            this.tabPage_Rules.Text = "Check rules";
            this.tabPage_Rules.UseVisualStyleBackColor = true;
            // 
            // createRulesControl1
            // 
            this.createRulesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createRulesControl1.Location = new System.Drawing.Point(3, 3);
            this.createRulesControl1.Name = "createRulesControl1";
            this.createRulesControl1.Size = new System.Drawing.Size(825, 521);
            this.createRulesControl1.TabIndex = 0;
            
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.assingRulesControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(831, 527);
            this.tabPage1.TabIndex = 4;
            this.tabPage1.Text = "Rules designer";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // assingRulesControl1
            // 
            this.assingRulesControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.assingRulesControl1.Location = new System.Drawing.Point(3, 3);
            this.assingRulesControl1.Name = "assingRulesControl1";
            this.assingRulesControl1.Size = new System.Drawing.Size(825, 521);
            this.assingRulesControl1.TabIndex = 0;
            this.assingRulesControl1.NewSecurityInfoCreated += new SecurityAppBlock.Admin.Controls.NewSecurityInfoCreatedHandler(this.assingRulesControl1_NewSecurityInfoCreated);
            // 
            // lbltitle
            // 
            this.lbltitle.BackColor = System.Drawing.Color.White;
            this.lbltitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbltitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.Image = global::SecurityAppBlock.Admin.Properties.Resources.Untitled__142_;
            this.lbltitle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbltitle.Location = new System.Drawing.Point(0, 0);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(846, 69);
            this.lbltitle.TabIndex = 2;
            this.lbltitle.Text = "Security admin";
            this.lbltitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            // frmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 640);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAdmin";
            this.Text = "Security admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tabControl1.ResumeLayout(false);
            this.tabPageUsers.ResumeLayout(false);
            this.tabPageRoles.ResumeLayout(false);
            this.tabPageAsingRol.ResumeLayout(false);
            this.tabPage_Rules.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageUsers;
        private System.Windows.Forms.TabPage tabPageRoles;
        private System.Windows.Forms.TabPage tabPageAsingRol;
        private System.Windows.Forms.TabPage tabPage_Rules;
        private System.Windows.Forms.TabPage tabPage1;
        private SecurityAppBlock.Admin.Controls.AssingRulesControl assingRulesControl1;
        private SecurityAppBlock.Admin.Controls.CreateRoles rolesAdmin1;
        private SecurityAppBlock.Admin.Controls.AssingRoles assingRoles1;
        private SecurityAppBlock.Admin.Controls.CheckRulesControl createRulesControl1;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
        private SecurityAppBlock.Admin.Controls.UserAdminControl userAdmminControl1;
    }
}

