namespace SerealsGenerator
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.txtImput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMD5Value = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnValidateMD5 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.txtEncryptedValue = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtKeyValue = new System.Windows.Forms.TextBox();
            this.btnGenerateKey = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.chkDrivers0 = new System.Windows.Forms.CheckBox();
            this.chlDateTime = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtNroSerie = new System.Windows.Forms.TextBox();
            this.txtKey_1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.txtEncriptedValue_1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtResultDecrypt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 238);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 0;
            this.button1.Text = "Convert";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtImput
            // 
            this.txtImput.Location = new System.Drawing.Point(18, 74);
            this.txtImput.Name = "txtImput";
            this.txtImput.Size = new System.Drawing.Size(574, 22);
            this.txtImput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Imput";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "MD5 value";
            // 
            // txtMD5Value
            // 
            this.txtMD5Value.Location = new System.Drawing.Point(21, 147);
            this.txtMD5Value.Name = "txtMD5Value";
            this.txtMD5Value.Size = new System.Drawing.Size(574, 22);
            this.txtMD5Value.TabIndex = 3;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(774, 474);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtImput);
            this.tabPage1.Controls.Add(this.txtMD5Value);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(766, 387);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "MD5 Gen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(181, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Check sum value generator";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label7);
            this.tabPage3.Controls.Add(this.textBox1);
            this.tabPage3.Controls.Add(this.label8);
            this.tabPage3.Controls.Add(this.textBox2);
            this.tabPage3.Controls.Add(this.btnValidateMD5);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(766, 387);
            this.tabPage3.TabIndex = 3;
            this.tabPage3.Text = "MD5 verifier";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 39);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 17);
            this.label7.TabIndex = 14;
            this.label7.Text = "MD5 value";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(37, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(574, 22);
            this.textBox1.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Imput";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(37, 128);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(574, 22);
            this.textBox2.TabIndex = 11;
            // 
            // btnValidateMD5
            // 
            this.btnValidateMD5.Location = new System.Drawing.Point(34, 210);
            this.btnValidateMD5.Name = "btnValidateMD5";
            this.btnValidateMD5.Size = new System.Drawing.Size(75, 32);
            this.btnValidateMD5.TabIndex = 10;
            this.btnValidateMD5.Text = "Validate";
            this.btnValidateMD5.UseVisualStyleBackColor = true;
            this.btnValidateMD5.Click += new System.EventHandler(this.btnValidateMD5_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkDrivers0);
            this.tabPage2.Controls.Add(this.chlDateTime);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Controls.Add(this.txtNroSerie);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.dateTimePicker1);
            this.tabPage2.Controls.Add(this.btnEncrypt);
            this.tabPage2.Controls.Add(this.txtEncryptedValue);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtDate);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.txtKeyValue);
            this.tabPage2.Controls.Add(this.btnGenerateKey);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(766, 445);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Encrypt";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.SteelBlue;
            this.label9.Location = new System.Drawing.Point(88, 141);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "expiration";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(190, 141);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 22);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Location = new System.Drawing.Point(145, 325);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(83, 27);
            this.btnEncrypt.TabIndex = 9;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // txtEncryptedValue
            // 
            this.txtEncryptedValue.Location = new System.Drawing.Point(26, 358);
            this.txtEncryptedValue.Multiline = true;
            this.txtEncryptedValue.Name = "txtEncryptedValue";
            this.txtEncryptedValue.Size = new System.Drawing.Size(695, 65);
            this.txtEncryptedValue.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.SteelBlue;
            this.label4.Location = new System.Drawing.Point(86, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(195, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Imput --> value to encrypt";
            // 
            // txtDate
            // 
            this.txtDate.Location = new System.Drawing.Point(89, 208);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(574, 22);
            this.txtDate.TabIndex = 5;
            this.txtDate.Text = "31|12|9999";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Imput";
            // 
            // txtKeyValue
            // 
            this.txtKeyValue.Location = new System.Drawing.Point(147, 65);
            this.txtKeyValue.Name = "txtKeyValue";
            this.txtKeyValue.Size = new System.Drawing.Size(574, 22);
            this.txtKeyValue.TabIndex = 3;
            this.txtKeyValue.Text = "7gp6CZ+Y8BZULbjOOkT86vi8HnrtyaIQ6WiLhdY48jY=$PbUiRifcU1q8Egl96hC7tw==";
            // 
            // btnGenerateKey
            // 
            this.btnGenerateKey.Location = new System.Drawing.Point(12, 56);
            this.btnGenerateKey.Name = "btnGenerateKey";
            this.btnGenerateKey.Size = new System.Drawing.Size(122, 27);
            this.btnGenerateKey.TabIndex = 0;
            this.btnGenerateKey.Text = "Generate Key";
            this.btnGenerateKey.UseVisualStyleBackColor = true;
            this.btnGenerateKey.Click += new System.EventHandler(this.btnGenerateKey_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.label16);
            this.tabPage4.Controls.Add(this.txtResultDecrypt);
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.txtEncriptedValue_1);
            this.tabPage4.Controls.Add(this.button2);
            this.tabPage4.Controls.Add(this.txtKey_1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(766, 445);
            this.tabPage4.TabIndex = 4;
            this.tabPage4.Text = "Expiration time Decript";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(8, 325);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 17);
            this.label11.TabIndex = 20;
            this.label11.Text = "3 - Encript ";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DimGray;
            this.label12.Location = new System.Drawing.Point(6, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(222, 17);
            this.label12.TabIndex = 19;
            this.label12.Text = "1 - Generate encriptation key";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.DimGray;
            this.label13.Location = new System.Drawing.Point(3, 110);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(244, 17);
            this.label13.TabIndex = 21;
            this.label13.Text = "2 - Set the the values to encript ";
            // 
            // chkDrivers0
            // 
            this.chkDrivers0.AutoSize = true;
            this.chkDrivers0.Location = new System.Drawing.Point(52, 261);
            this.chkDrivers0.Name = "chkDrivers0";
            this.chkDrivers0.Size = new System.Drawing.Size(18, 17);
            this.chkDrivers0.TabIndex = 30;
            this.chkDrivers0.UseVisualStyleBackColor = true;
            // 
            // chlDateTime
            // 
            this.chlDateTime.AutoSize = true;
            this.chlDateTime.Checked = true;
            this.chlDateTime.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chlDateTime.Location = new System.Drawing.Point(52, 211);
            this.chlDateTime.Name = "chlDateTime";
            this.chlDateTime.Size = new System.Drawing.Size(18, 17);
            this.chlDateTime.TabIndex = 29;
            this.chlDateTime.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(77, 241);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 17);
            this.label14.TabIndex = 28;
            this.label14.Text = "Drive 0 Sereial Number";
            // 
            // txtNroSerie
            // 
            this.txtNroSerie.Enabled = false;
            this.txtNroSerie.Location = new System.Drawing.Point(80, 261);
            this.txtNroSerie.Name = "txtNroSerie";
            this.txtNroSerie.Size = new System.Drawing.Size(574, 22);
            this.txtNroSerie.TabIndex = 27;
            // 
            // txtKey_1
            // 
            this.txtKey_1.Location = new System.Drawing.Point(26, 61);
            this.txtKey_1.Name = "txtKey_1";
            this.txtKey_1.Size = new System.Drawing.Size(647, 22);
            this.txtKey_1.TabIndex = 5;
            this.txtKey_1.Text = "7gp6CZ+Y8BZULbjOOkT86vi8HnrtyaIQ6WiLhdY48jY=$PbUiRifcU1q8Egl96hC7tw==";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(26, 212);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(83, 27);
            this.button2.TabIndex = 23;
            this.button2.Text = "Decrypt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.SteelBlue;
            this.label15.Location = new System.Drawing.Point(6, 252);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(209, 17);
            this.label15.TabIndex = 25;
            this.label15.Text = "3 - Result dencrypted value";
            // 
            // txtEncriptedValue_1
            // 
            this.txtEncriptedValue_1.Location = new System.Drawing.Point(22, 125);
            this.txtEncriptedValue_1.Multiline = true;
            this.txtEncriptedValue_1.Name = "txtEncriptedValue_1";
            this.txtEncriptedValue_1.Size = new System.Drawing.Size(666, 48);
            this.txtEncriptedValue_1.TabIndex = 24;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.SteelBlue;
            this.label16.Location = new System.Drawing.Point(3, 105);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(191, 17);
            this.label16.TabIndex = 27;
            this.label16.Text = "2 - Input Encrypted value";
            // 
            // txtResultDecrypt
            // 
            this.txtResultDecrypt.Location = new System.Drawing.Point(26, 286);
            this.txtResultDecrypt.Multiline = true;
            this.txtResultDecrypt.Name = "txtResultDecrypt";
            this.txtResultDecrypt.Size = new System.Drawing.Size(676, 74);
            this.txtResultDecrypt.TabIndex = 26;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.SteelBlue;
            this.label10.Location = new System.Drawing.Point(10, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 17);
            this.label10.TabIndex = 28;
            this.label10.Text = "1 - Input key";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 498);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(829, 405);
            this.Name = "Form1";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sereals generator";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtImput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMD5Value;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.TextBox txtEncryptedValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtKeyValue;
        private System.Windows.Forms.Button btnGenerateKey;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnValidateMD5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox chkDrivers0;
        private System.Windows.Forms.CheckBox chlDateTime;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtNroSerie;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtResultDecrypt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtEncriptedValue_1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtKey_1;
    }
}

