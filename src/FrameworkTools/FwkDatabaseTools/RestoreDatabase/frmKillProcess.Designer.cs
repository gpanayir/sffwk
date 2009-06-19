namespace RestoreDatabase
{
    partial class frmKillProcess
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmKillProcess));
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.currentSetting = new System.Windows.Forms.BindingSource(this.components);
            this.btnKillProcess = new System.Windows.Forms.Button();
            this.grdLogRegistry = new System.Windows.Forms.DataGridView();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnWho = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.fwkFlatComboBox1 = new Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox();
            this.configSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.wViewAll = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRestore = new System.Windows.Forms.Button();
            this.txtBackUpSource = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.currentSetting)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogRegistry)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configSettingBindingSource)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentSetting, "DataBaseName", true));
            this.txtDataBaseName.Location = new System.Drawing.Point(413, 75);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(179, 20);
            this.txtDataBaseName.TabIndex = 0;
            // 
            // currentSetting
            // 
            this.currentSetting.DataSource = typeof(RestoreDatabase.ConfigSetting);
            // 
            // btnKillProcess
            // 
            this.btnKillProcess.BackColor = System.Drawing.Color.SteelBlue;
            this.btnKillProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKillProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKillProcess.ForeColor = System.Drawing.Color.White;
            this.btnKillProcess.Location = new System.Drawing.Point(114, 51);
            this.btnKillProcess.Name = "btnKillProcess";
            this.btnKillProcess.Size = new System.Drawing.Size(135, 22);
            this.btnKillProcess.TabIndex = 1;
            this.btnKillProcess.Text = "Kill SQL process";
            this.btnKillProcess.UseVisualStyleBackColor = false;
            this.btnKillProcess.Click += new System.EventHandler(this.btnKillProcess_Click);
            // 
            // grdLogRegistry
            // 
            this.grdLogRegistry.AllowUserToDeleteRows = false;
            this.grdLogRegistry.AllowUserToOrderColumns = true;
            this.grdLogRegistry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdLogRegistry.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.grdLogRegistry.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdLogRegistry.DefaultCellStyle = dataGridViewCellStyle6;
            this.grdLogRegistry.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(153)))), ((int)(((byte)(204)))));
            this.grdLogRegistry.Location = new System.Drawing.Point(12, 166);
            this.grdLogRegistry.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.grdLogRegistry.Name = "grdLogRegistry";
            this.grdLogRegistry.ReadOnly = true;
            this.grdLogRegistry.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(247)))), ((int)(((byte)(251)))));
            this.grdLogRegistry.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.SteelBlue;
            this.grdLogRegistry.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.grdLogRegistry.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.grdLogRegistry.Size = new System.Drawing.Size(818, 353);
            this.grdLogRegistry.TabIndex = 17;
            this.grdLogRegistry.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdLogRegistry_CellContentDoubleClick);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Label1.Location = new System.Drawing.Point(412, 58);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(85, 13);
            this.Label1.TabIndex = 18;
            this.Label1.Text = "Data base name";
            // 
            // btnWho
            // 
            this.btnWho.BackColor = System.Drawing.Color.SteelBlue;
            this.btnWho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWho.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWho.ForeColor = System.Drawing.Color.White;
            this.btnWho.Location = new System.Drawing.Point(22, 51);
            this.btnWho.Name = "btnWho";
            this.btnWho.Size = new System.Drawing.Size(74, 22);
            this.btnWho.TabIndex = 19;
            this.btnWho.Text = "Who";
            this.btnWho.UseVisualStyleBackColor = false;
            this.btnWho.Click += new System.EventHandler(this.btnWho_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.fwkFlatComboBox1);
            this.groupBox1.Controls.Add(this.txtPassword);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.wViewAll);
            this.groupBox1.Controls.Add(this.btnWho);
            this.groupBox1.Controls.Add(this.btnKillProcess);
            this.groupBox1.Controls.Add(this.txtUser);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtDataBaseName);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(9, -3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(783, 101);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // fwkFlatComboBox1
            // 
            this.fwkFlatComboBox1.ActiveArrowColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fwkFlatComboBox1.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fwkFlatComboBox1.ActiveButtonColor = System.Drawing.SystemColors.ControlDark;
            this.fwkFlatComboBox1.AllowEmptyTextValue = false;
            this.fwkFlatComboBox1.AutoComplete = true;
            this.fwkFlatComboBox1.DataSource = this.configSettingBindingSource;
            this.fwkFlatComboBox1.DisplayMember = "Name";
            this.fwkFlatComboBox1.ErrorIconRightToLeft = false;
            this.fwkFlatComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fwkFlatComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwkFlatComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkFlatComboBox1.FormattingEnabled = true;
            this.fwkFlatComboBox1.InactiveArrowColor = System.Drawing.SystemColors.ControlDark;
            this.fwkFlatComboBox1.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.fwkFlatComboBox1.InactiveButtonColor = System.Drawing.SystemColors.Control;
            this.fwkFlatComboBox1.Location = new System.Drawing.Point(12, 19);
            this.fwkFlatComboBox1.Name = "fwkFlatComboBox1";
            this.fwkFlatComboBox1.NullTextValue = null;
            this.fwkFlatComboBox1.ReadOnly = false;
            this.fwkFlatComboBox1.ReadOnlyColor = System.Drawing.SystemColors.ControlLightLight;
            this.fwkFlatComboBox1.Required = false;
            this.fwkFlatComboBox1.RequiredErrorText = null;
            this.fwkFlatComboBox1.Size = new System.Drawing.Size(368, 21);
            this.fwkFlatComboBox1.TabIndex = 22;
            this.fwkFlatComboBox1.SelectedIndexChanged += new System.EventHandler(this.fwkFlatComboBox1_SelectedIndexChanged);
            // 
            // configSettingBindingSource
            // 
            this.configSettingBindingSource.DataSource = typeof(RestoreDatabase.ConfigSetting);
            // 
            // txtPassword
            // 
            this.txtPassword.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentSetting, "Password", true));
            this.txtPassword.Location = new System.Drawing.Point(623, 75);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(123, 20);
            this.txtPassword.TabIndex = 26;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(620, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "Password";
            // 
            // wViewAll
            // 
            this.wViewAll.AutoSize = true;
            this.wViewAll.Location = new System.Drawing.Point(22, 78);
            this.wViewAll.Name = "wViewAll";
            this.wViewAll.Size = new System.Drawing.Size(62, 17);
            this.wViewAll.TabIndex = 20;
            this.wViewAll.Text = "View all";
            this.wViewAll.UseVisualStyleBackColor = true;
            // 
            // txtUser
            // 
            this.txtUser.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentSetting, "User", true));
            this.txtUser.Location = new System.Drawing.Point(617, 31);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(123, 20);
            this.txtUser.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label4.Location = new System.Drawing.Point(614, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "User";
            // 
            // txtServer
            // 
            this.txtServer.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.currentSetting, "Server", true));
            this.txtServer.Location = new System.Drawing.Point(413, 31);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(179, 20);
            this.txtServer.TabIndex = 22;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label3.Location = new System.Drawing.Point(412, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "SQL Server";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRestore);
            this.groupBox2.Controls.Add(this.txtBackUpSource);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 101);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(780, 60);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRestore.ForeColor = System.Drawing.Color.Blue;
            this.btnRestore.Location = new System.Drawing.Point(517, 29);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(74, 22);
            this.btnRestore.TabIndex = 21;
            this.btnRestore.Text = "Restore";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // txtBackUpSource
            // 
            this.txtBackUpSource.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.configSettingBindingSource, "BackUpSource", true));
            this.txtBackUpSource.Location = new System.Drawing.Point(9, 30);
            this.txtBackUpSource.Name = "txtBackUpSource";
            this.txtBackUpSource.Size = new System.Drawing.Size(502, 20);
            this.txtBackUpSource.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label2.Location = new System.Drawing.Point(8, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Source BackUp";
            // 
            // frmKillProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(842, 530);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grdLogRegistry);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(722, 468);
            this.Name = "frmKillProcess";
            this.Text = "Restore database";
            this.Load += new System.EventHandler(this.frmKillProcess_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmKillProcess_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.currentSetting)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdLogRegistry)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.configSettingBindingSource)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtDataBaseName;
        private System.Windows.Forms.Button btnKillProcess;
        internal System.Windows.Forms.DataGridView grdLogRegistry;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnWho;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.TextBox txtBackUpSource;
        internal System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox wViewAll;
        private System.Windows.Forms.TextBox txtServer;
        internal System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPassword;
        internal System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUser;
        internal System.Windows.Forms.Label label4;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatComboBox fwkFlatComboBox1;
        private System.Windows.Forms.BindingSource configSettingBindingSource;
        private System.Windows.Forms.BindingSource currentSetting;
    }
}

