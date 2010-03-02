namespace Fwk.Logging.Viewer
{
    partial class OtherView
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
            this.lblMessage1 = new System.Windows.Forms.Label();
            this.txtMessage1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblMessage1
            // 
            this.lblMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage1.AutoSize = true;
            this.lblMessage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage1.Location = new System.Drawing.Point(15, 7);
            this.lblMessage1.Name = "lblMessage1";
            this.lblMessage1.Size = new System.Drawing.Size(57, 13);
            this.lblMessage1.TabIndex = 9;
            this.lblMessage1.Text = "Message";
            // 
            // txtMessage1
            // 
            this.txtMessage1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage1.Location = new System.Drawing.Point(13, 26);
            this.txtMessage1.Multiline = true;
            this.txtMessage1.Name = "txtMessage1";
            this.txtMessage1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtMessage1.Size = new System.Drawing.Size(481, 210);
            this.txtMessage1.TabIndex = 8;
            // 
            // OtherView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblMessage1);
            this.Controls.Add(this.txtMessage1);
            this.Name = "OtherView";
            this.Size = new System.Drawing.Size(515, 239);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblMessage1;
        private System.Windows.Forms.TextBox txtMessage1;
    }
}
