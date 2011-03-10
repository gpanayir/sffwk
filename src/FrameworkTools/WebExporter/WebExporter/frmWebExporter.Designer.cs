namespace WebExporter
{
    partial class frmWebExporter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmWebExporter));
            this.txtRuta1 = new System.Windows.Forms.TextBox();
            this.txtRuta2 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOpenDest = new System.Windows.Forms.Button();
            this.btnOpenSource = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.txtErrors = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRuta1
            // 
            this.txtRuta1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRuta1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtRuta1.Location = new System.Drawing.Point(14, 30);
            this.txtRuta1.Name = "txtRuta1";
            this.txtRuta1.Size = new System.Drawing.Size(576, 20);
            this.txtRuta1.TabIndex = 2;
            this.txtRuta1.Text = "c:\\";
            this.txtRuta1.TextChanged += new System.EventHandler(this.txtRuta1_TextChanged);
            // 
            // txtRuta2
            // 
            this.txtRuta2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtRuta2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.txtRuta2.Location = new System.Drawing.Point(13, 78);
            this.txtRuta2.Name = "txtRuta2";
            this.txtRuta2.Size = new System.Drawing.Size(577, 20);
            this.txtRuta2.TabIndex = 3;
            this.txtRuta2.Text = "c:\\";
            this.txtRuta2.TextChanged += new System.EventHandler(this.txtRuta2_TextChanged);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(11, 355);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(721, 13);
            this.progressBar1.TabIndex = 6;
            this.progressBar1.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(7, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Source path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(11, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Destination path";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOpenDest);
            this.groupBox2.Controls.Add(this.btnOpenSource);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnProcess);
            this.groupBox2.Controls.Add(this.txtRuta1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtRuta2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(718, 117);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            // 
            // btnOpenDest
            // 
            this.btnOpenDest.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOpenDest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOpenDest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenDest.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenDest.ForeColor = System.Drawing.Color.SlateGray;
            this.btnOpenDest.Image = global::WebExporter.Properties.Resources.forum_search;
            this.btnOpenDest.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenDest.Location = new System.Drawing.Point(595, 78);
            this.btnOpenDest.Name = "btnOpenDest";
            this.btnOpenDest.Size = new System.Drawing.Size(26, 19);
            this.btnOpenDest.TabIndex = 14;
            this.btnOpenDest.Text = "...";
            this.btnOpenDest.UseVisualStyleBackColor = true;
            this.btnOpenDest.Click += new System.EventHandler(this.btnOpenDest_Click);
            // 
            // btnOpenSource
            // 
            this.btnOpenSource.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnOpenSource.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnOpenSource.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenSource.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenSource.ForeColor = System.Drawing.Color.SlateGray;
            this.btnOpenSource.Image = global::WebExporter.Properties.Resources.forum_search;
            this.btnOpenSource.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenSource.Location = new System.Drawing.Point(596, 30);
            this.btnOpenSource.Name = "btnOpenSource";
            this.btnOpenSource.Size = new System.Drawing.Size(26, 19);
            this.btnOpenSource.TabIndex = 13;
            this.btnOpenSource.Text = "...";
            this.btnOpenSource.UseVisualStyleBackColor = true;
            this.btnOpenSource.Click += new System.EventHandler(this.btnOpenSource_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnProcess.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.Color.SlateGray;
            this.btnProcess.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcess.Location = new System.Drawing.Point(640, 44);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(72, 31);
            this.btnProcess.TabIndex = 1;
            this.btnProcess.Text = "Export";
            this.btnProcess.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtErrors
            // 
            this.txtErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtErrors.BackColor = System.Drawing.Color.White;
            this.txtErrors.Location = new System.Drawing.Point(11, 135);
            this.txtErrors.Multiline = true;
            this.txtErrors.Name = "txtErrors";
            this.txtErrors.ReadOnly = true;
            this.txtErrors.Size = new System.Drawing.Size(713, 214);
            this.txtErrors.TabIndex = 0;
            this.txtErrors.TextChanged += new System.EventHandler(this.txtErrors_TextChanged);
            // 
            // frmWebExporter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(744, 375);
            this.Controls.Add(this.txtErrors);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmWebExporter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Web exporter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmEasyReplace_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.TextBox txtRuta1;
        private System.Windows.Forms.TextBox txtRuta2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOpenDest;
        private System.Windows.Forms.Button btnOpenSource;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtErrors;
      
    }
}

