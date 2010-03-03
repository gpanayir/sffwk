namespace Fwk.Security.AD.TestLogin
{
    partial class frmDinamic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDinamic));
            this.label2 = new System.Windows.Forms.Label();
            this.lblCheckResult = new System.Windows.Forms.Label();
            this.btnCheck = new System.Windows.Forms.Button();
            this.txtDomain = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLoginName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 72;
            this.label2.Text = "Domain";
            // 
            // lblCheckResult
            // 
            this.lblCheckResult.BackColor = System.Drawing.Color.White;
            this.lblCheckResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCheckResult.Location = new System.Drawing.Point(11, 167);
            this.lblCheckResult.Name = "lblCheckResult";
            this.lblCheckResult.Size = new System.Drawing.Size(408, 77);
            this.lblCheckResult.TabIndex = 71;
            // 
            // btnCheck
            // 
            this.btnCheck.BackColor = System.Drawing.Color.White;
            this.btnCheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCheck.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheck.Location = new System.Drawing.Point(215, 136);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(91, 22);
            this.btnCheck.TabIndex = 70;
            this.btnCheck.Text = "Ahutenticate";
            this.btnCheck.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCheck.UseVisualStyleBackColor = false;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // txtDomain
            // 
            this.txtDomain.Location = new System.Drawing.Point(128, 100);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(178, 20);
            this.txtDomain.TabIndex = 69;
            this.txtDomain.Text = "Allus-ar";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 68;
            this.label1.Text = "Password";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(35, 27);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 67;
            this.label9.Text = "Login name";
            // 
            // txtLoginName
            // 
            this.txtLoginName.Location = new System.Drawing.Point(128, 27);
            this.txtLoginName.Name = "txtLoginName";
            this.txtLoginName.Size = new System.Drawing.Size(178, 20);
            this.txtLoginName.TabIndex = 65;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(128, 59);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 20);
            this.txtPassword.TabIndex = 66;
            // 
            // frmDinamic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 273);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCheckResult);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.txtDomain);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtLoginName);
            this.Controls.Add(this.txtPassword);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDinamic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDinamic";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCheckResult;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.TextBox txtDomain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLoginName;
        private System.Windows.Forms.TextBox txtPassword;
    }
}