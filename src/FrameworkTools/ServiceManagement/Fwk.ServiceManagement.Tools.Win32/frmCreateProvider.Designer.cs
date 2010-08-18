namespace Fwk.ServiceManagement.Tools.Win32
{
    partial class frmCreateProvider
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
            this.txtApplicationId = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.lblName = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.txtSource = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.btnSearAssemblie = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboCnnStrings = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtCnnString = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.txtCnnStringNAme = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtApplicationId
            // 
            this.txtApplicationId.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtApplicationId.AllowBlankSpace = true;
            this.txtApplicationId.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtApplicationId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApplicationId.BackColor = System.Drawing.Color.White;
            this.txtApplicationId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApplicationId.CapitalOnly = false;
            this.txtApplicationId.ErrorIconRightToLeft = true;
            this.txtApplicationId.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApplicationId.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtApplicationId.Location = new System.Drawing.Point(12, 78);
            this.txtApplicationId.Name = "txtApplicationId";
            this.txtApplicationId.NotAllowedCharactersErrorText = null;
            this.txtApplicationId.Required = true;
            this.txtApplicationId.RequiredErrorText = "Name value is required";
            this.txtApplicationId.Size = new System.Drawing.Size(662, 21);
            this.txtApplicationId.TabIndex = 77;
            this.txtApplicationId.TabStop = false;
            this.txtApplicationId.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 62);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(71, 13);
            this.lblName.TabIndex = 76;
            this.lblName.Text = "Application Id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 79;
            this.label3.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtName.AllowBlankSpace = true;
            this.txtName.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.CapitalOnly = false;
            this.txtName.ErrorIconRightToLeft = true;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtName.Location = new System.Drawing.Point(11, 26);
            this.txtName.Name = "txtName";
            this.txtName.NotAllowedCharactersErrorText = null;
            this.txtName.Required = true;
            this.txtName.RequiredErrorText = "Name value is required";
            this.txtName.Size = new System.Drawing.Size(662, 21);
            this.txtName.TabIndex = 78;
            this.txtName.TabStop = false;
            this.txtName.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 81;
            this.label4.Text = "Type";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "xml",
            "sqldatabase"});
            this.cboType.Location = new System.Drawing.Point(12, 129);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(150, 21);
            this.cboType.TabIndex = 80;
            this.cboType.SelectedIndexChanged += new System.EventHandler(this.cboType_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOk.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOk.Location = new System.Drawing.Point(541, 468);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(66, 23);
            this.btnOk.TabIndex = 82;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // txtSource
            // 
            this.txtSource.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtSource.AllowBlankSpace = true;
            this.txtSource.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.BackColor = System.Drawing.Color.White;
            this.txtSource.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSource.CapitalOnly = false;
            this.txtSource.ErrorIconRightToLeft = true;
            this.txtSource.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSource.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtSource.Location = new System.Drawing.Point(6, 55);
            this.txtSource.Name = "txtSource";
            this.txtSource.NotAllowedCharactersErrorText = null;
            this.txtSource.Required = true;
            this.txtSource.RequiredErrorText = "Name value is required";
            this.txtSource.Size = new System.Drawing.Size(570, 21);
            this.txtSource.TabIndex = 83;
            this.txtSource.TabStop = false;
            this.txtSource.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // btnSearAssemblie
            // 
            this.btnSearAssemblie.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSearAssemblie.Image = global::Fwk.ServiceManagement.Tools.Win32.Properties.Resources.mostrar;
            this.btnSearAssemblie.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearAssemblie.Location = new System.Drawing.Point(631, 29);
            this.btnSearAssemblie.Name = "btnSearAssemblie";
            this.btnSearAssemblie.Size = new System.Drawing.Size(28, 23);
            this.btnSearAssemblie.TabIndex = 84;
            this.btnSearAssemblie.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSearAssemblie.UseVisualStyleBackColor = true;
            this.btnSearAssemblie.Click += new System.EventHandler(this.btnSearAssemblie_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 85;
            this.label1.Text = "File";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label2.Location = new System.Drawing.Point(93, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 87;
            this.label2.Text = "Connection strings";
            // 
            // cboCnnStrings
            // 
            this.cboCnnStrings.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCnnStrings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboCnnStrings.FormattingEnabled = true;
            this.cboCnnStrings.Location = new System.Drawing.Point(96, 40);
            this.cboCnnStrings.Name = "cboCnnStrings";
            this.cboCnnStrings.Size = new System.Drawing.Size(236, 21);
            this.cboCnnStrings.TabIndex = 86;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(11, 167);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(672, 273);
            this.tabControl1.TabIndex = 88;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtSource);
            this.tabPage1.Controls.Add(this.btnSearAssemblie);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(664, 247);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Xml";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtCnnString);
            this.tabPage2.Controls.Add(this.radioButton2);
            this.tabPage2.Controls.Add(this.radioButton1);
            this.tabPage2.Controls.Add(this.txtCnnStringNAme);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.cboCnnStrings);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(664, 247);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "SQL Database";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtCnnString
            // 
            this.txtCnnString.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtCnnString.AllowBlankSpace = true;
            this.txtCnnString.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtCnnString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnnString.BackColor = System.Drawing.Color.White;
            this.txtCnnString.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCnnString.CapitalOnly = false;
            this.txtCnnString.ErrorIconRightToLeft = true;
            this.txtCnnString.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnnString.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtCnnString.Location = new System.Drawing.Point(96, 159);
            this.txtCnnString.Name = "txtCnnString";
            this.txtCnnString.NotAllowedCharactersErrorText = null;
            this.txtCnnString.Required = true;
            this.txtCnnString.RequiredErrorText = "Name value is required";
            this.txtCnnString.Size = new System.Drawing.Size(540, 21);
            this.txtCnnString.TabIndex = 90;
            this.txtCnnString.TabStop = false;
            this.txtCnnString.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(19, 84);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 89;
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 88;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // txtCnnStringNAme
            // 
            this.txtCnnStringNAme.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtCnnStringNAme.AllowBlankSpace = true;
            this.txtCnnStringNAme.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtCnnStringNAme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCnnStringNAme.BackColor = System.Drawing.Color.White;
            this.txtCnnStringNAme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCnnStringNAme.CapitalOnly = false;
            this.txtCnnStringNAme.ErrorIconRightToLeft = true;
            this.txtCnnStringNAme.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCnnStringNAme.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtCnnStringNAme.Location = new System.Drawing.Point(96, 115);
            this.txtCnnStringNAme.Name = "txtCnnStringNAme";
            this.txtCnnStringNAme.NotAllowedCharactersErrorText = null;
            this.txtCnnStringNAme.Required = true;
            this.txtCnnStringNAme.RequiredErrorText = "Name value is required";
            this.txtCnnStringNAme.Size = new System.Drawing.Size(540, 21);
            this.txtCnnStringNAme.TabIndex = 86;
            this.txtCnnStringNAme.TabStop = false;
            this.txtCnnStringNAme.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label5.Location = new System.Drawing.Point(103, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 13);
            this.label5.TabIndex = 87;
            this.label5.Text = "New connection String";
            // 
            // frmCreateProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 497);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtApplicationId);
            this.Controls.Add(this.lblName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateProvider";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add provider";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtApplicationId;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label3;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Button btnOk;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtSource;
        private System.Windows.Forms.Button btnSearAssemblie;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboCnnStrings;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtCnnStringNAme;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtCnnString;
    }
}