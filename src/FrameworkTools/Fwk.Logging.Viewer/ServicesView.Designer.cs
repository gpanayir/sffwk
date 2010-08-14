namespace Fwk.Logging.Viewer
{
    partial class ServicesView
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
            this.lblMessage2 = new System.Windows.Forms.Label();
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.txtMessage2 = new System.Windows.Forms.TextBox();
            this.txtMessage1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMessage2
            // 
            this.lblMessage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage2.AutoSize = true;
            this.lblMessage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage2.Location = new System.Drawing.Point(582, 14);
            this.lblMessage2.Name = "lblMessage2";
            this.lblMessage2.Size = new System.Drawing.Size(63, 13);
            this.lblMessage2.TabIndex = 9;
            this.lblMessage2.Text = "Response";
            // 
            // lblMessage1
            // 
            this.lblMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage1.AutoSize = true;
            this.lblMessage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage1.Location = new System.Drawing.Point(8, 14);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(54, 13);
            this.lblMessage1.TabIndex = 8;
            this.lblMessage1.Text = "Request";
            // 
            // txtMessage2
            // 
            this.txtMessage2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage2.Location = new System.Drawing.Point(585, 33);
            this.txtMessage2.Multiline = true;
            this.txtMessage2.Name = "txtMessage2";
            this.txtMessage2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage2.Size = new System.Drawing.Size(556, 286);
            this.txtMessage2.TabIndex = 7;
            // 
            // txtMessage1
            // 
            this.txtMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage1.Location = new System.Drawing.Point(6, 33);
            this.txtMessage1.Multiline = true;
            this.txtMessage1.Name = "txtMessage1";
            this.txtMessage1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage1.Size = new System.Drawing.Size(556, 286);
            this.txtMessage1.TabIndex = 6;
            // 
            // ServicesView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage2);
            this.Controls.Add(this.lblMessage1);
            this.Controls.Add(this.txtMessage2);
            this.Controls.Add(this.txtMessage1);
            this.Name = "ServicesView";
            this.Size = new System.Drawing.Size(1166, 361);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage2;
        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.TextBox txtMessage2;
        private System.Windows.Forms.TextBox txtMessage1;
    }
}
