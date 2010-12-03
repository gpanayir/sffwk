namespace Fwk.ServiceManagement.Tools.Win32
{
    partial class frmExport1
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cnnstring_Source = new Fwk.ServiceManagement.Tools.Win32.cnnstring();
            this.label7 = new System.Windows.Forms.Label();
            this.txtAddres_source = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.lblAddressSource = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblConnectionType_source = new System.Windows.Forms.Label();
            this.ucbServiceGrid1 = new Fwk.ServiceManagement.Tools.Win32.UCBServiceGrid();
            this.cnnstring_Dest = new Fwk.ServiceManagement.Tools.Win32.cnnstring();
            this.ucbServiceGrid2 = new Fwk.ServiceManagement.Tools.Win32.UCBServiceGrid();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAddres = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.cmb2 = new System.Windows.Forms.ComboBox();
            this.lblAddressDest = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(1068, 686);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(975, 686);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cnnstring_Source);
            this.splitContainer1.Panel1.Controls.Add(this.label7);
            this.splitContainer1.Panel1.Controls.Add(this.txtAddres_source);
            this.splitContainer1.Panel1.Controls.Add(this.lblAddressSource);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.lblConnectionType_source);
            this.splitContainer1.Panel1.Controls.Add(this.ucbServiceGrid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cnnstring_Dest);
            this.splitContainer1.Panel2.Controls.Add(this.ucbServiceGrid2);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txtAddres);
            this.splitContainer1.Panel2.Controls.Add(this.cmb2);
            this.splitContainer1.Panel2.Controls.Add(this.lblAddressDest);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.lblConnectionType);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Size = new System.Drawing.Size(1167, 677);
            this.splitContainer1.SplitterDistance = 575;
            this.splitContainer1.TabIndex = 88;
            // 
            // cnnstring_Source
            // 
            this.cnnstring_Source.Location = new System.Drawing.Point(8, 107);
            this.cnnstring_Source.Name = "cnnstring_Source";
            this.cnnstring_Source.Size = new System.Drawing.Size(531, 32);
            this.cnnstring_Source.TabIndex = 96;
            this.cnnstring_Source.Visible = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Maroon;
            this.label7.Location = new System.Drawing.Point(2, 7);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(570, 32);
            this.label7.TabIndex = 92;
            this.label7.Text = "Source";
            // 
            // txtAddres_source
            // 
            this.txtAddres_source.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAddres_source.AllowBlankSpace = true;
            this.txtAddres_source.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtAddres_source.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.txtAddres_source.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddres_source.CapitalOnly = false;
            this.txtAddres_source.ErrorIconRightToLeft = false;
            this.txtAddres_source.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddres_source.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtAddres_source.Location = new System.Drawing.Point(129, 77);
            this.txtAddres_source.Name = "txtAddres_source";
            this.txtAddres_source.NotAllowedCharactersErrorText = "";
            this.txtAddres_source.ReadOnly = true;
            this.txtAddres_source.Required = false;
            this.txtAddres_source.RequiredErrorText = null;
            this.txtAddres_source.Size = new System.Drawing.Size(408, 14);
            this.txtAddres_source.TabIndex = 89;
            this.txtAddres_source.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // lblAddressSource
            // 
            this.lblAddressSource.AutoSize = true;
            this.lblAddressSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressSource.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAddressSource.Location = new System.Drawing.Point(9, 77);
            this.lblAddressSource.Name = "lblAddressSource";
            this.lblAddressSource.Size = new System.Drawing.Size(56, 13);
            this.lblAddressSource.TabIndex = 95;
            this.lblAddressSource.Text = "Address:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(9, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 13);
            this.label8.TabIndex = 93;
            this.label8.Text = "Metadata type:";
            // 
            // lblConnectionType_source
            // 
            this.lblConnectionType_source.AutoSize = true;
            this.lblConnectionType_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionType_source.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblConnectionType_source.Location = new System.Drawing.Point(126, 56);
            this.lblConnectionType_source.Name = "lblConnectionType_source";
            this.lblConnectionType_source.Size = new System.Drawing.Size(16, 13);
            this.lblConnectionType_source.TabIndex = 92;
            this.lblConnectionType_source.Text = "---";
            // 
            // ucbServiceGrid1
            // 
            this.ucbServiceGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucbServiceGrid1.Applications = null;
            this.ucbServiceGrid1.CurentServiceConfiguration = null;
            this.ucbServiceGrid1.Location = new System.Drawing.Point(7, 145);
            this.ucbServiceGrid1.Name = "ucbServiceGrid1";
            this.ucbServiceGrid1.Services = null;
            this.ucbServiceGrid1.Size = new System.Drawing.Size(560, 516);
            this.ucbServiceGrid1.TabIndex = 87;
            // 
            // cnnstring_Dest
            // 
            this.cnnstring_Dest.Location = new System.Drawing.Point(13, 99);
            this.cnnstring_Dest.Name = "cnnstring_Dest";
            this.cnnstring_Dest.Size = new System.Drawing.Size(531, 32);
            this.cnnstring_Dest.TabIndex = 94;
            this.cnnstring_Dest.Visible = false;
            // 
            // ucbServiceGrid2
            // 
            this.ucbServiceGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucbServiceGrid2.Applications = null;
            this.ucbServiceGrid2.CurentServiceConfiguration = null;
            this.ucbServiceGrid2.Location = new System.Drawing.Point(3, 145);
            this.ucbServiceGrid2.Name = "ucbServiceGrid2";
            this.ucbServiceGrid2.Services = null;
            this.ucbServiceGrid2.Size = new System.Drawing.Size(574, 516);
            this.ucbServiceGrid2.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(246, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Provider";
            // 
            // txtAddres
            // 
            this.txtAddres.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAddres.AllowBlankSpace = true;
            this.txtAddres.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtAddres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.txtAddres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddres.CapitalOnly = false;
            this.txtAddres.ErrorIconRightToLeft = false;
            this.txtAddres.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddres.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtAddres.Location = new System.Drawing.Point(136, 76);
            this.txtAddres.Name = "txtAddres";
            this.txtAddres.NotAllowedCharactersErrorText = "";
            this.txtAddres.ReadOnly = true;
            this.txtAddres.Required = false;
            this.txtAddres.RequiredErrorText = null;
            this.txtAddres.Size = new System.Drawing.Size(408, 14);
            this.txtAddres.TabIndex = 50;
            this.txtAddres.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // cmb2
            // 
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Location = new System.Drawing.Point(303, 21);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(255, 21);
            this.cmb2.TabIndex = 90;
            // 
            // lblAddressDest
            // 
            this.lblAddressDest.AutoSize = true;
            this.lblAddressDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddressDest.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblAddressDest.Location = new System.Drawing.Point(11, 77);
            this.lblAddressDest.Name = "lblAddressDest";
            this.lblAddressDest.Size = new System.Drawing.Size(56, 13);
            this.lblAddressDest.TabIndex = 56;
            this.lblAddressDest.Text = "Address:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(11, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 13);
            this.label3.TabIndex = 54;
            this.label3.Text = "Metadata type:";
            // 
            // lblConnectionType
            // 
            this.lblConnectionType.AutoSize = true;
            this.lblConnectionType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionType.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblConnectionType.Location = new System.Drawing.Point(129, 51);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(16, 13);
            this.lblConnectionType.TabIndex = 53;
            this.lblConnectionType.Text = "---";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.BackColor = System.Drawing.Color.White;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Maroon;
            this.label9.Location = new System.Drawing.Point(8, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(572, 32);
            this.label9.TabIndex = 93;
            this.label9.Text = "Destination";
            // 
            // frmExport1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 721);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "frmExport1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export from ";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private UCBServiceGrid ucbServiceGrid1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox cmb2;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtAddres_source;
        private System.Windows.Forms.Label lblAddressSource;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblConnectionType_source;
        private UCBServiceGrid ucbServiceGrid2;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtAddres;
        private System.Windows.Forms.Label lblAddressDest;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private cnnstring cnnstring_Dest;
        private cnnstring cnnstring_Source;
    }
}