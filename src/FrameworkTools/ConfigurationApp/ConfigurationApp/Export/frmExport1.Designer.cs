namespace ConfigurationApp
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
            this.components = new System.ComponentModel.Container();
            this.source = new System.Windows.Forms.ComboBox();
            this.dest = new System.Windows.Forms.ComboBox();
            this.provider1 = new ConfigurationApp.provider();
            this.provider2 = new ConfigurationApp.provider();
            this.txtAddres = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.provider2.SuspendLayout();
            this.SuspendLayout();
            // 
            // source
            // 
            this.source.FormattingEnabled = true;
            this.source.Location = new System.Drawing.Point(23, 12);
            this.source.Name = "source";
            this.source.Size = new System.Drawing.Size(233, 21);
            this.source.TabIndex = 0;
            this.source.SelectedIndexChanged += new System.EventHandler(this.source_SelectedIndexChanged);
            // 
            // dest
            // 
            this.dest.FormattingEnabled = true;
            this.dest.Location = new System.Drawing.Point(23, 173);
            this.dest.Name = "dest";
            this.dest.Size = new System.Drawing.Size(233, 21);
            this.dest.TabIndex = 1;
            this.dest.SelectedIndexChanged += new System.EventHandler(this.dest_SelectedIndexChanged);
            // 
            // provider1
            // 
            this.provider1.Location = new System.Drawing.Point(23, 39);
            this.provider1.Name = "provider1";
            this.provider1.Size = new System.Drawing.Size(511, 128);
            this.provider1.TabIndex = 2;
            // 
            // provider2
            // 
            this.provider2.Controls.Add(this.txtAddres);
            this.provider2.Location = new System.Drawing.Point(23, 200);
            this.provider2.Name = "provider2";
            this.provider2.Size = new System.Drawing.Size(511, 128);
            this.provider2.TabIndex = 3;
            // 
            // txtAddres
            // 
            this.txtAddres.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtAddres.AllowBlankSpace = true;
            this.txtAddres.AllowedCharacters = "0123456789ABCDEFGHIJKLMNÑOPQRSTUVWXYZabcdefghijklmnñopqrstuvwxyz";
            this.txtAddres.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddres.BackColor = System.Drawing.Color.White;
            this.txtAddres.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAddres.CapitalOnly = false;
            this.txtAddres.ErrorIconRightToLeft = false;
            this.txtAddres.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddres.InactiveBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtAddres.Location = new System.Drawing.Point(83, 56);
            this.txtAddres.Multiline = true;
            this.txtAddres.Name = "txtAddres";
            this.txtAddres.NotAllowedCharactersErrorText = "";
            this.txtAddres.ReadOnly = true;
            this.txtAddres.Required = false;
            this.txtAddres.RequiredErrorText = null;
            this.txtAddres.Size = new System.Drawing.Size(365, 20);
            this.txtAddres.TabIndex = 96;
            this.txtAddres.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // frmExport1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 438);
            this.Controls.Add(this.provider2);
            this.Controls.Add(this.provider1);
            this.Controls.Add(this.dest);
            this.Controls.Add(this.source);
            this.Name = "frmExport1";
            this.Text = "frmExport1";
            this.provider2.ResumeLayout(false);
            this.provider2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox source;
        private System.Windows.Forms.ComboBox dest;
        private provider provider1;
        private provider provider2;
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox txtAddres;
    }
}