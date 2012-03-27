namespace Fwk.UI.Security
{
    partial class FRM_RoleMain
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
            this.uC_RoleMain1 = new Fwk.UI.Security.Controls.UC_RoleMain();
            this.SuspendLayout();
            // 
            // uC_RoleMain1
            // 
            this.uC_RoleMain1.AcceptButton = null;
            this.uC_RoleMain1.CancelButton = null;
            this.uC_RoleMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_RoleMain1.Location = new System.Drawing.Point(3, 6);
            this.uC_RoleMain1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_RoleMain1.Name = "uC_RoleMain1";
            this.uC_RoleMain1.Size = new System.Drawing.Size(1004, 751);
            this.uC_RoleMain1.TabIndex = 0;
            this.uC_RoleMain1.Load += new System.EventHandler(this.uC_RoleMain1_Load);
            // 
            // FRM_RoleMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1010, 763);
            this.Controls.Add(this.uC_RoleMain1);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_RoleMain";
            this.Padding = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Roles";
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Security.Controls.UC_RoleMain uC_RoleMain1;

        
    }
}