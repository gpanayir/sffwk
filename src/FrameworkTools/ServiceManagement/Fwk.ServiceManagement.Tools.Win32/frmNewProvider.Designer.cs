namespace Fwk.ServiceManagement.Tools.Win32
{
    partial class frmNewProvider
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
            this.cmb2 = new System.Windows.Forms.ComboBox();
            this.txtAddres = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.lblMetadata = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblConnectionType = new System.Windows.Forms.Label();
            this.lblConnectionStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddres_source = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.lblMetadata_source = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblConnectionType_source = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ucbServiceGrid1 = new Fwk.ServiceManagement.Tools.Win32.UCBServiceGrid();
            this.ucbServiceGrid2 = new Fwk.ServiceManagement.Tools.Win32.UCBServiceGrid();
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
            this.splitContainer1.Location = new System.Drawing.Point(12, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtAddres_source);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.lblMetadata_source);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.lblConnectionType_source);
            this.splitContainer1.Panel1.Controls.Add(this.label11);
            this.splitContainer1.Panel1.Controls.Add(this.ucbServiceGrid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ucbServiceGrid2);
            this.splitContainer1.Panel2.Controls.Add(this.txtAddres);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.lblMetadata);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.lblConnectionType);
            this.splitContainer1.Panel2.Controls.Add(this.lblConnectionStatus);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Size = new System.Drawing.Size(1131, 641);
            this.splitContainer1.SplitterDistance = 558;
            this.splitContainer1.TabIndex = 88;
            // 
            // cmb2
            // 
            this.cmb2.FormattingEnabled = true;
            this.cmb2.Location = new System.Drawing.Point(583, 12);
            this.cmb2.Name = "cmb2";
            this.cmb2.Size = new System.Drawing.Size(272, 21);
            this.cmb2.TabIndex = 90;
            // 
            // txtAddres
            // 
            this.txtAddres.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAddres.AllowBlankSpace = true;
            this.txtAddres.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtAddres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.txtAddres.CapitalOnly = false;
            this.txtAddres.ErrorIconRightToLeft = false;
            this.txtAddres.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddres.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtAddres.Location = new System.Drawing.Point(130, 87);
            this.txtAddres.Name = "txtAddres";
            this.txtAddres.NotAllowedCharactersErrorText = "";
            this.txtAddres.ReadOnly = true;
            this.txtAddres.Required = false;
            this.txtAddres.RequiredErrorText = null;
            this.txtAddres.Size = new System.Drawing.Size(408, 21);
            this.txtAddres.TabIndex = 50;
            this.txtAddres.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(6, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Address:";
            // 
            // lblMetadata
            // 
            this.lblMetadata.AutoSize = true;
            this.lblMetadata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetadata.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMetadata.Location = new System.Drawing.Point(123, 64);
            this.lblMetadata.Name = "lblMetadata";
            this.lblMetadata.Size = new System.Drawing.Size(19, 13);
            this.lblMetadata.TabIndex = 55;
            this.lblMetadata.Text = "...r";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(6, 64);
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
            this.lblConnectionType.Location = new System.Drawing.Point(123, 38);
            this.lblConnectionType.Name = "lblConnectionType";
            this.lblConnectionType.Size = new System.Drawing.Size(16, 13);
            this.lblConnectionType.TabIndex = 53;
            this.lblConnectionType.Text = "---";
            // 
            // lblConnectionStatus
            // 
            this.lblConnectionStatus.AutoSize = true;
            this.lblConnectionStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnectionStatus.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblConnectionStatus.Location = new System.Drawing.Point(123, 13);
            this.lblConnectionStatus.Name = "lblConnectionStatus";
            this.lblConnectionStatus.Size = new System.Drawing.Size(25, 13);
            this.lblConnectionStatus.TabIndex = 52;
            this.lblConnectionStatus.Text = "......";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Connection type:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(3, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Connection status:";
            // 
            // txtAddres_source
            // 
            this.txtAddres_source.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAddres_source.AllowBlankSpace = true;
            this.txtAddres_source.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtAddres_source.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(231)))), ((int)(((byte)(253)))));
            this.txtAddres_source.CapitalOnly = false;
            this.txtAddres_source.ErrorIconRightToLeft = false;
            this.txtAddres_source.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddres_source.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.txtAddres_source.Location = new System.Drawing.Point(142, 63);
            this.txtAddres_source.Name = "txtAddres_source";
            this.txtAddres_source.NotAllowedCharactersErrorText = "";
            this.txtAddres_source.ReadOnly = true;
            this.txtAddres_source.Required = false;
            this.txtAddres_source.RequiredErrorText = null;
            this.txtAddres_source.Size = new System.Drawing.Size(408, 21);
            this.txtAddres_source.TabIndex = 89;
            this.txtAddres_source.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SteelBlue;
            this.label6.Location = new System.Drawing.Point(18, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 95;
            this.label6.Text = "Address:";
            // 
            // lblMetadata_source
            // 
            this.lblMetadata_source.AutoSize = true;
            this.lblMetadata_source.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMetadata_source.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblMetadata_source.Location = new System.Drawing.Point(135, 40);
            this.lblMetadata_source.Name = "lblMetadata_source";
            this.lblMetadata_source.Size = new System.Drawing.Size(19, 13);
            this.lblMetadata_source.TabIndex = 94;
            this.lblMetadata_source.Text = "...r";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.SteelBlue;
            this.label8.Location = new System.Drawing.Point(18, 40);
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
            this.lblConnectionType_source.Location = new System.Drawing.Point(135, 14);
            this.lblConnectionType_source.Name = "lblConnectionType_source";
            this.lblConnectionType_source.Size = new System.Drawing.Size(16, 13);
            this.lblConnectionType_source.TabIndex = 92;
            this.lblConnectionType_source.Text = "---";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.SteelBlue;
            this.label11.Location = new System.Drawing.Point(15, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(103, 13);
            this.label11.TabIndex = 90;
            this.label11.Text = "Connection type:";
            // 
            // ucbServiceGrid1
            // 
            this.ucbServiceGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucbServiceGrid1.CurentServiceConfiguration = null;
            this.ucbServiceGrid1.Location = new System.Drawing.Point(7, 90);
            this.ucbServiceGrid1.Name = "ucbServiceGrid1";
            this.ucbServiceGrid1.Services = null;
            this.ucbServiceGrid1.Size = new System.Drawing.Size(543, 535);
            this.ucbServiceGrid1.TabIndex = 87;
            // 
            // ucbServiceGrid2
            // 
            this.ucbServiceGrid2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ucbServiceGrid2.CurentServiceConfiguration = null;
            this.ucbServiceGrid2.Location = new System.Drawing.Point(3, 126);
            this.ucbServiceGrid2.Name = "ucbServiceGrid2";
            this.ucbServiceGrid2.Services = null;
            this.ucbServiceGrid2.Size = new System.Drawing.Size(555, 499);
            this.ucbServiceGrid2.TabIndex = 88;
            // 
            // frmNewProvider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 721);
            this.Controls.Add(this.cmb2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Name = "frmNewProvider";
            this.Text = "frmNewProvider";
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
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMetadata_source;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblConnectionType_source;
        private System.Windows.Forms.Label label11;
        private UCBServiceGrid ucbServiceGrid2;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtAddres;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblMetadata;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblConnectionType;
        private System.Windows.Forms.Label lblConnectionStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
    }
}