namespace Fwk.UI.Security.Controls
{
    partial class FRM_UserMain
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
            this.uC_UsersMain1 = new Fwk.UI.Security.Controls.UC_UsersMain();
            this.SuspendLayout();
            // 
            // uC_UsersMain1
            // 
            this.uC_UsersMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_UsersMain1.Location = new System.Drawing.Point(0, 0);
            this.uC_UsersMain1.Margin = new System.Windows.Forms.Padding(0);
            this.uC_UsersMain1.Name = "uC_UsersMain1";
            this.uC_UsersMain1.Size = new System.Drawing.Size(862, 405);
            this.uC_UsersMain1.TabIndex = 0;
            // 
            // FRM_UserMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 405);
            this.Controls.Add(this.uC_UsersMain1);
            this.Name = "FRM_UserMain";
            this.Padding = new System.Windows.Forms.Padding(0);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuarios";
            this.ResumeLayout(false);

        }

        #endregion

        private Fwk.UI.Security.Controls.UC_UsersMain uC_UsersMain1;

    }
}