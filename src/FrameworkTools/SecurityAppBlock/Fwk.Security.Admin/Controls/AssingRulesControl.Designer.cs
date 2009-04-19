namespace SecurityAppBlock.Admin.Controls
{
    partial class AssingRulesControl
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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnAsignarRoles = new System.Windows.Forms.Button();
            this.grdAssignedRoles = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolAssignedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdAllRoles = new System.Windows.Forms.DataGridView();
            this.rolNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rolBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnAddExcludedUser = new System.Windows.Forms.Button();
            this.grdUserExcluded = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userExcludedBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdAllUser = new System.Windows.Forms.DataGridView();
            this.userNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.appNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRuleExpression = new System.Windows.Forms.TextBox();
            this.btnCreateRule = new DevExpress.XtraEditors.SimpleButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtRuleName = new System.Windows.Forms.TextBox();
            this.btnGenerateRule = new DevExpress.XtraEditors.SimpleButton();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.fwkMessageViewInfo = new Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent(this.components);
            this.tabControl2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignedRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolAssignedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllRoles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserExcluded)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userExcludedBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl2
            // 
            this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Location = new System.Drawing.Point(6, 42);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(712, 452);
            this.tabControl2.TabIndex = 15;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnAsignarRoles);
            this.tabPage2.Controls.Add(this.grdAssignedRoles);
            this.tabPage2.Controls.Add(this.grdAllRoles);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(704, 426);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "Includes roles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnAsignarRoles
            // 
            this.btnAsignarRoles.BackColor = System.Drawing.Color.White;
            this.btnAsignarRoles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAsignarRoles.Image = global::SecurityAppBlock.Admin.Properties.Resources._177;
            this.btnAsignarRoles.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAsignarRoles.Location = new System.Drawing.Point(282, 134);
            this.btnAsignarRoles.Name = "btnAsignarRoles";
            this.btnAsignarRoles.Size = new System.Drawing.Size(114, 32);
            this.btnAsignarRoles.TabIndex = 17;
            this.btnAsignarRoles.Text = "Add Roles";
            this.btnAsignarRoles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAsignarRoles.UseVisualStyleBackColor = false;
            this.btnAsignarRoles.Click += new System.EventHandler(this.btnAddRol_Click);
            // 
            // grdAssignedRoles
            // 
            this.grdAssignedRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdAssignedRoles.AutoGenerateColumns = false;
            this.grdAssignedRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAssignedRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn1});
            this.grdAssignedRoles.DataSource = this.rolAssignedBindingSource;
            this.grdAssignedRoles.Location = new System.Drawing.Point(402, 29);
            this.grdAssignedRoles.Name = "grdAssignedRoles";
            this.grdAssignedRoles.Size = new System.Drawing.Size(213, 378);
            this.grdAssignedRoles.TabIndex = 11;
            // 
            // rolNameDataGridViewTextBoxColumn1
            // 
            this.rolNameDataGridViewTextBoxColumn1.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn1.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn1.Name = "rolNameDataGridViewTextBoxColumn1";
            // 
            // rolAssignedBindingSource
            // 
            this.rolAssignedBindingSource.DataSource = typeof(Fwk.Security.Common.Rol);
            // 
            // grdAllRoles
            // 
            this.grdAllRoles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdAllRoles.AutoGenerateColumns = false;
            this.grdAllRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAllRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolNameDataGridViewTextBoxColumn});
            this.grdAllRoles.DataSource = this.rolBindingSource;
            this.grdAllRoles.Location = new System.Drawing.Point(17, 29);
            this.grdAllRoles.Name = "grdAllRoles";
            this.grdAllRoles.Size = new System.Drawing.Size(260, 378);
            this.grdAllRoles.TabIndex = 10;
            this.grdAllRoles.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAllRoles_CellClick);
            // 
            // rolNameDataGridViewTextBoxColumn
            // 
            this.rolNameDataGridViewTextBoxColumn.DataPropertyName = "RolName";
            this.rolNameDataGridViewTextBoxColumn.HeaderText = "RolName";
            this.rolNameDataGridViewTextBoxColumn.Name = "rolNameDataGridViewTextBoxColumn";
            // 
            // rolBindingSource
            // 
            this.rolBindingSource.DataSource = typeof(Fwk.Security.Common.Rol);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnAddExcludedUser);
            this.tabPage3.Controls.Add(this.grdUserExcluded);
            this.tabPage3.Controls.Add(this.grdAllUser);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(704, 426);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Excludes Users";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnAddExcludedUser
            // 
            this.btnAddExcludedUser.Image = global::SecurityAppBlock.Admin.Properties.Resources.impt_24;
            this.btnAddExcludedUser.Location = new System.Drawing.Point(287, 91);
            this.btnAddExcludedUser.Name = "btnAddExcludedUser";
            this.btnAddExcludedUser.Size = new System.Drawing.Size(40, 41);
            this.btnAddExcludedUser.TabIndex = 16;
            this.btnAddExcludedUser.UseVisualStyleBackColor = true;
            this.btnAddExcludedUser.Click += new System.EventHandler(this.btnAddExcludedUser_Click);
            // 
            // grdUserExcluded
            // 
            this.grdUserExcluded.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdUserExcluded.AutoGenerateColumns = false;
            this.grdUserExcluded.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUserExcluded.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn1,
            this.appNameDataGridViewTextBoxColumn1});
            this.grdUserExcluded.DataSource = this.userExcludedBindingSource;
            this.grdUserExcluded.Location = new System.Drawing.Point(363, 23);
            this.grdUserExcluded.Name = "grdUserExcluded";
            this.grdUserExcluded.Size = new System.Drawing.Size(253, 363);
            this.grdUserExcluded.TabIndex = 14;
            // 
            // userNameDataGridViewTextBoxColumn1
            // 
            this.userNameDataGridViewTextBoxColumn1.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn1.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn1.Name = "userNameDataGridViewTextBoxColumn1";
            // 
            // appNameDataGridViewTextBoxColumn1
            // 
            this.appNameDataGridViewTextBoxColumn1.DataPropertyName = "AppName";
            this.appNameDataGridViewTextBoxColumn1.HeaderText = "AppName";
            this.appNameDataGridViewTextBoxColumn1.Name = "appNameDataGridViewTextBoxColumn1";
            // 
            // userExcludedBindingSource
            // 
            this.userExcludedBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // grdAllUser
            // 
            this.grdAllUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.grdAllUser.AutoGenerateColumns = false;
            this.grdAllUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdAllUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userNameDataGridViewTextBoxColumn,
            this.appNameDataGridViewTextBoxColumn});
            this.grdAllUser.DataSource = this.userBindingSource;
            this.grdAllUser.Location = new System.Drawing.Point(15, 23);
            this.grdAllUser.Name = "grdAllUser";
            this.grdAllUser.Size = new System.Drawing.Size(253, 367);
            this.grdAllUser.TabIndex = 13;
            this.grdAllUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdAllUser_CellClick);
            // 
            // userNameDataGridViewTextBoxColumn
            // 
            this.userNameDataGridViewTextBoxColumn.DataPropertyName = "UserName";
            this.userNameDataGridViewTextBoxColumn.HeaderText = "UserName";
            this.userNameDataGridViewTextBoxColumn.Name = "userNameDataGridViewTextBoxColumn";
            // 
            // appNameDataGridViewTextBoxColumn
            // 
            this.appNameDataGridViewTextBoxColumn.DataPropertyName = "AppName";
            this.appNameDataGridViewTextBoxColumn.HeaderText = "AppName";
            this.appNameDataGridViewTextBoxColumn.Name = "appNameDataGridViewTextBoxColumn";
            // 
            // userBindingSource
            // 
            this.userBindingSource.DataSource = typeof(Fwk.Security.Common.User);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRuleExpression);
            this.tabPage1.Controls.Add(this.btnCreateRule);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(704, 426);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Rule expression";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRuleExpression
            // 
            this.errorProvider1.SetIconAlignment(this.txtRuleExpression, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtRuleExpression.Location = new System.Drawing.Point(6, 35);
            this.txtRuleExpression.Multiline = true;
            this.txtRuleExpression.Name = "txtRuleExpression";
            this.txtRuleExpression.Size = new System.Drawing.Size(676, 311);
            this.txtRuleExpression.TabIndex = 20;
            // 
            // btnCreateRule
            // 
            this.btnCreateRule.Location = new System.Drawing.Point(16, 6);
            this.btnCreateRule.Name = "btnCreateRule";
            this.btnCreateRule.Size = new System.Drawing.Size(96, 23);
            this.btnCreateRule.TabIndex = 19;
            this.btnCreateRule.Text = "Create rule ";
            this.btnCreateRule.Click += new System.EventHandler(this.btnCreateRule_Click);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold);
            this.label11.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label11.Location = new System.Drawing.Point(3, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(138, 16);
            this.label11.TabIndex = 17;
            this.label11.Text = "Enter the rule name";
            // 
            // txtRuleName
            // 
            this.errorProvider1.SetIconAlignment(this.txtRuleName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft);
            this.txtRuleName.Location = new System.Drawing.Point(147, 9);
            this.txtRuleName.Name = "txtRuleName";
            this.txtRuleName.Size = new System.Drawing.Size(190, 20);
            this.txtRuleName.TabIndex = 16;
            this.txtRuleName.Validating += new System.ComponentModel.CancelEventHandler(this.textRuleName_Validating);
            // 
            // btnGenerateRule
            // 
            this.btnGenerateRule.Location = new System.Drawing.Point(389, 9);
            this.btnGenerateRule.Name = "btnGenerateRule";
            this.btnGenerateRule.Size = new System.Drawing.Size(141, 23);
            this.btnGenerateRule.TabIndex = 18;
            this.btnGenerateRule.Text = "Generate rule expression";
            this.btnGenerateRule.Click += new System.EventHandler(this.btnGenerateRule_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
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
            // AssingRulesControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnGenerateRule);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtRuleName);
            this.Controls.Add(this.tabControl2);
            this.Name = "AssingRulesControl";
            this.Size = new System.Drawing.Size(734, 497);
            this.tabControl2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdAssignedRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolAssignedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllRoles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rolBindingSource)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserExcluded)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userExcludedBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAllUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView grdAssignedRoles;
        private System.Windows.Forms.DataGridView grdAllRoles;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView grdAllUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.DataGridView grdUserExcluded;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource rolAssignedBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rolNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource rolBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn appNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource userExcludedBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn appNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Button btnAddExcludedUser;
        private System.Windows.Forms.TabPage tabPage1;
        private DevExpress.XtraEditors.SimpleButton btnGenerateRule;
        private DevExpress.XtraEditors.SimpleButton btnCreateRule;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TextBox txtRuleExpression;
        private System.Windows.Forms.Button btnAsignarRoles;
        private Fwk.Bases.FrontEnd.Controls.FwkMessageViewComponent fwkMessageViewInfo;
    }
}
