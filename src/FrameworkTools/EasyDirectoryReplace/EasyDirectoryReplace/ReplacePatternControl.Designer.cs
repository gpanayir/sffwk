namespace EasyDirectoryReplace
{
    partial class ReplacePatternControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chkReplaceContentFile = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOldText = new System.Windows.Forms.TextBox();
            this.txtNewText = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.btnRemove);
            this.groupBox1.Controls.Add(this.chkReplaceContentFile);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtOldText);
            this.groupBox1.Controls.Add(this.txtNewText);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(509, 94);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // btnRemove
            // 
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.btnRemove.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.ForeColor = System.Drawing.Color.SlateGray;
            this.btnRemove.Image = global::EasyDirectoryReplace.Properties.Resources.delete;
            this.btnRemove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRemove.Location = new System.Drawing.Point(-8, -11);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(30, 31);
            this.btnRemove.TabIndex = 15;
            this.btnRemove.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // chkReplaceContentFile
            // 
            this.chkReplaceContentFile.AutoSize = true;
            this.chkReplaceContentFile.Location = new System.Drawing.Point(9, 69);
            this.chkReplaceContentFile.Margin = new System.Windows.Forms.Padding(4);
            this.chkReplaceContentFile.Name = "chkReplaceContentFile";
            this.chkReplaceContentFile.Size = new System.Drawing.Size(155, 21);
            this.chkReplaceContentFile.TabIndex = 11;
            this.chkReplaceContentFile.Text = "Replace content file";
            this.chkReplaceContentFile.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.ForeColor = System.Drawing.Color.SteelBlue;
            this.label3.Location = new System.Drawing.Point(6, 19);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Text to replase";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(270, 20);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "New text";
            // 
            // txtOldText
            // 
            this.txtOldText.Location = new System.Drawing.Point(9, 39);
            this.txtOldText.Margin = new System.Windows.Forms.Padding(4);
            this.txtOldText.Name = "txtOldText";
            this.txtOldText.Size = new System.Drawing.Size(247, 22);
            this.txtOldText.TabIndex = 4;
            // 
            // txtNewText
            // 
            this.txtNewText.Location = new System.Drawing.Point(274, 39);
            this.txtNewText.Margin = new System.Windows.Forms.Padding(4);
            this.txtNewText.Name = "txtNewText";
            this.txtNewText.Size = new System.Drawing.Size(203, 22);
            this.txtNewText.TabIndex = 5;
            // 
            // ReplacePatternControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ReplacePatternControl";
            this.Size = new System.Drawing.Size(509, 94);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkReplaceContentFile;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOldText;
        private System.Windows.Forms.TextBox txtNewText;
        private System.Windows.Forms.Button btnRemove;
    }
}
