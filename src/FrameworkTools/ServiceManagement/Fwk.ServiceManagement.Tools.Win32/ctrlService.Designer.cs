namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
    partial class ctrlService
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtTimeout = new Fwk.Bases.FrontEnd.Controls.FwkNumericTextBox();
            this.txtResponse = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox();
            this.bindingSourceService = new System.Windows.Forms.BindingSource(this.components);
            this.txtRequest = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox();
            this.txtHandler = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox();
            this.txtName = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox();
            this.txtDescription = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox();
            this.chkCacheable = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboIsolationLevel = new System.Windows.Forms.ComboBox();
            this.ckbAudit = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.ckbAvailable = new System.Windows.Forms.CheckBox();
            this.cboTransactionalBehaviour = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceService)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.txtTimeout);
            this.groupBox1.Controls.Add(this.txtResponse);
            this.groupBox1.Controls.Add(this.txtRequest);
            this.groupBox1.Controls.Add(this.txtHandler);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.txtDescription);
            this.groupBox1.Controls.Add(this.chkCacheable);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboIsolationLevel);
            this.groupBox1.Controls.Add(this.ckbAudit);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblName);
            this.groupBox1.Controls.Add(this.ckbAvailable);
            this.groupBox1.Controls.Add(this.cboTransactionalBehaviour);
            this.groupBox1.Location = new System.Drawing.Point(2, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(671, 324);
            this.groupBox1.TabIndex = 49;
            this.groupBox1.TabStop = false;
            // 
            // txtTimeout
            // 
            this.txtTimeout.Location = new System.Drawing.Point(331, 289);
            this.txtTimeout.Name = "txtTimeout";
            this.txtTimeout.NumericType = Fwk.Bases.FrontEnd.Controls.FwkNumericTextBox.NumericTypeEnum.Int;
            this.txtTimeout.Size = new System.Drawing.Size(81, 21);
            this.txtTimeout.TabIndex = 73;
            this.txtTimeout.TextBoxBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtTimeout.TextBoxEnabled = true;
            this.txtTimeout.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimeout.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.txtTimeout.TextBoxText = "0";
            this.txtTimeout.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtResponse
            // 
            this.txtResponse.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtResponse.AllowedCharacters = null;
            this.txtResponse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtResponse.BackColor = System.Drawing.Color.White;
            this.txtResponse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtResponse.CapitalOnly = false;
            this.txtResponse.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Response", true));
            this.txtResponse.ErrorIconRightToLeft = true;
            this.txtResponse.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponse.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtResponse.Location = new System.Drawing.Point(12, 242);
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.NotAllowedCharactersErrorText = null;
            this.txtResponse.Required = true;
            this.txtResponse.RequiredErrorText = "Response is required";
            this.txtResponse.Size = new System.Drawing.Size(650, 21);
            this.txtResponse.TabIndex = 72;
            
            // 
            // bindingSourceService
            // 
            this.bindingSourceService.DataSource = typeof(Fwk.Bases.ServiceConfiguration);
            // 
            // txtRequest
            // 
            this.txtRequest.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtRequest.AllowedCharacters = null;
            this.txtRequest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRequest.BackColor = System.Drawing.Color.White;
            this.txtRequest.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequest.CapitalOnly = false;
            this.txtRequest.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Request", true));
            this.txtRequest.ErrorIconRightToLeft = true;
            this.txtRequest.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRequest.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtRequest.Location = new System.Drawing.Point(12, 203);
            this.txtRequest.Name = "txtRequest";
            this.txtRequest.NotAllowedCharactersErrorText = null;
            this.txtRequest.Required = true;
            this.txtRequest.RequiredErrorText = "Request is required";
            this.txtRequest.Size = new System.Drawing.Size(650, 21);
            this.txtRequest.TabIndex = 71;
            
            // 
            // txtHandler
            // 
            this.txtHandler.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtHandler.AllowedCharacters = null;
            this.txtHandler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtHandler.BackColor = System.Drawing.Color.White;
            this.txtHandler.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHandler.CapitalOnly = false;
            this.txtHandler.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Handler", true));
            this.txtHandler.ErrorIconRightToLeft = true;
            this.txtHandler.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHandler.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtHandler.Location = new System.Drawing.Point(12, 164);
            this.txtHandler.Name = "txtHandler";
            this.txtHandler.NotAllowedCharactersErrorText = null;
            this.txtHandler.Required = true;
            this.txtHandler.RequiredErrorText = "Handler is required";
            this.txtHandler.Size = new System.Drawing.Size(650, 21);
            this.txtHandler.TabIndex = 70;
            
            // 
            // txtName
            // 
            this.txtName.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtName.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.BackColor = System.Drawing.Color.White;
            this.txtName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtName.CapitalOnly = false;
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Name", true));
            this.txtName.ErrorIconRightToLeft = true;
            this.txtName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtName.Location = new System.Drawing.Point(12, 26);
            this.txtName.Name = "txtName";
            this.txtName.NotAllowedCharactersErrorText = null;
            this.txtName.Required = true;
            this.txtName.RequiredErrorText = "Name value is required";
            this.txtName.Size = new System.Drawing.Size(653, 21);
            this.txtName.TabIndex = 69;
            this.txtName.TabStop = false;
            
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtDescription.AllowedCharacters = null;
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.BackColor = System.Drawing.Color.White;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.CapitalOnly = false;
            this.txtDescription.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSourceService, "Description", true));
            this.txtDescription.ErrorIconRightToLeft = true;
            this.txtDescription.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.InactiveBorderColor = System.Drawing.SystemColors.Control;
            this.txtDescription.Location = new System.Drawing.Point(12, 75);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.NotAllowedCharactersErrorText = null;
            this.txtDescription.Required = false;
            this.txtDescription.RequiredErrorText = null;
            this.txtDescription.Size = new System.Drawing.Size(651, 70);
            this.txtDescription.TabIndex = 68;
            
            // 
            // chkCacheable
            // 
            this.chkCacheable.AutoSize = true;
            this.chkCacheable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceService, "Cacheable", true));
            this.chkCacheable.Location = new System.Drawing.Point(554, 293);
            this.chkCacheable.Name = "chkCacheable";
            this.chkCacheable.Size = new System.Drawing.Size(77, 17);
            this.chkCacheable.TabIndex = 67;
            this.chkCacheable.Text = "Cacheable";
            this.chkCacheable.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(339, 273);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 66;
            this.label6.Text = "Timeout";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(172, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 65;
            this.label4.Text = "Isolation level";
            // 
            // cboIsolationLevel
            // 
            this.cboIsolationLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboIsolationLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboIsolationLevel.FormattingEnabled = true;
            this.cboIsolationLevel.Location = new System.Drawing.Point(175, 289);
            this.cboIsolationLevel.Name = "cboIsolationLevel";
            this.cboIsolationLevel.Size = new System.Drawing.Size(150, 21);
            this.cboIsolationLevel.TabIndex = 58;
            // 
            // ckbAudit
            // 
            this.ckbAudit.AutoSize = true;
            this.ckbAudit.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceService, "Audit", true));
            this.ckbAudit.Location = new System.Drawing.Point(496, 293);
            this.ckbAudit.Name = "ckbAudit";
            this.ckbAudit.Size = new System.Drawing.Size(50, 17);
            this.ckbAudit.TabIndex = 61;
            this.ckbAudit.Text = "Audit";
            this.ckbAudit.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 273);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(121, 13);
            this.label10.TabIndex = 64;
            this.label10.Text = "Transactional behaviour";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 226);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Response";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 187);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Request";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 57;
            this.label2.Text = "Handler";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 55;
            this.label1.Text = "Description";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(12, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 54;
            this.lblName.Text = "Name";
            // 
            // ckbAvailable
            // 
            this.ckbAvailable.AutoSize = true;
            this.ckbAvailable.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSourceService, "Available", true));
            this.ckbAvailable.Location = new System.Drawing.Point(421, 293);
            this.ckbAvailable.Name = "ckbAvailable";
            this.ckbAvailable.Size = new System.Drawing.Size(69, 17);
            this.ckbAvailable.TabIndex = 60;
            this.ckbAvailable.Text = "Available";
            this.ckbAvailable.UseVisualStyleBackColor = true;
            // 
            // cboTransactionalBehaviour
            // 
            this.cboTransactionalBehaviour.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTransactionalBehaviour.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboTransactionalBehaviour.FormattingEnabled = true;
            this.cboTransactionalBehaviour.Location = new System.Drawing.Point(10, 289);
            this.cboTransactionalBehaviour.Name = "cboTransactionalBehaviour";
            this.cboTransactionalBehaviour.Size = new System.Drawing.Size(150, 21);
            this.cboTransactionalBehaviour.TabIndex = 56;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 1);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(51, 20);
            this.lblTitle.TabIndex = 50;
            this.lblTitle.Text = "label3";
            // 
            // ctrlService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.groupBox1);
            this.Name = "ctrlService";
            this.Size = new System.Drawing.Size(674, 345);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSourceService)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkCacheable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboIsolationLevel;
        private System.Windows.Forms.CheckBox ckbAudit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.CheckBox ckbAvailable;
        private System.Windows.Forms.ComboBox cboTransactionalBehaviour;
        private System.Windows.Forms.BindingSource bindingSourceService;
        private System.Windows.Forms.Label lblTitle;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtDescription;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtResponse;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtRequest;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtHandler;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtName;
        private Fwk.Bases.FrontEnd.Controls.FwkNumericTextBox txtTimeout;
    }
}
