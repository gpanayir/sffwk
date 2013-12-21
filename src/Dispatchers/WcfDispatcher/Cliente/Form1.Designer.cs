namespace Cliente
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
            this.btn_RetrivePatientsReq1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_RetrivePatientsReq2 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_RetrivePatientsReq1
            // 
            this.btn_RetrivePatientsReq1.Location = new System.Drawing.Point(9, 18);
            this.btn_RetrivePatientsReq1.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RetrivePatientsReq1.Name = "btn_RetrivePatientsReq1";
            this.btn_RetrivePatientsReq1.Size = new System.Drawing.Size(170, 31);
            this.btn_RetrivePatientsReq1.TabIndex = 0;
            this.btn_RetrivePatientsReq1.Text = "RetrivePatientsReq";
            this.btn_RetrivePatientsReq1.UseVisualStyleBackColor = true;
            this.btn_RetrivePatientsReq1.Click += new System.EventHandler(this.btn_RetrivePatientsReq1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(742, 82);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(272, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "RetrivePacientesService";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_RetrivePatientsReq2
            // 
            this.btn_RetrivePatientsReq2.Location = new System.Drawing.Point(9, 82);
            this.btn_RetrivePatientsReq2.Margin = new System.Windows.Forms.Padding(4);
            this.btn_RetrivePatientsReq2.Name = "btn_RetrivePatientsReq2";
            this.btn_RetrivePatientsReq2.Size = new System.Drawing.Size(167, 36);
            this.btn_RetrivePatientsReq2.TabIndex = 2;
            this.btn_RetrivePatientsReq2.Text = "RetrivePatientsReq";
            this.btn_RetrivePatientsReq2.UseVisualStyleBackColor = true;
            this.btn_RetrivePatientsReq2.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(644, 323);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(272, 41);
            this.button4.TabIndex = 3;
            this.button4.Text = "Json test";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.Location = new System.Drawing.Point(12, 190);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(479, 447);
            this.txtResponse.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Response";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(186, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 40);
            this.label2.TabIndex = 6;
            this.label2.Text = " Wrapper que reutiliza proxy";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(916, 226);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(186, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 40);
            this.label4.TabIndex = 9;
            this.label4.Text = "Wraapper Dispose using";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button1.Location = new System.Drawing.Point(380, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(167, 36);
            this.button1.TabIndex = 10;
            this.button1.Text = "RetrivePatientsReq";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(554, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 40);
            this.label5.TabIndex = 11;
            this.label5.Text = "Repetitivo Wraapper Dispose using";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 639);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.btn_RetrivePatientsReq2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btn_RetrivePatientsReq1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_RetrivePatientsReq1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_RetrivePatientsReq2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label5;
    }
}

