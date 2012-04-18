namespace Fwk.UI.Forms
{
    partial class FormBaseNotify
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
            DevExpress.XtraBars.Alerter.AlertButton alertButton1 = new DevExpress.XtraBars.Alerter.AlertButton();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(this.components);
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // alertControl1
            // 
            this.alertControl1.AutoFormDelay = 5000;
            alertButton1.Image = global::Fwk.UI.Properties.Resources.inbox_32;
            alertButton1.ImageDown = global::Fwk.UI.Properties.Resources.inbox_back_32;
            alertButton1.Name = "alertButton1";
            this.alertControl1.Buttons.Add(alertButton1);
            // 
            // FormBaseNotify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 474);
            this.LookAndFeel.UseWindowsXPTheme = true;
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FormBaseNotify";
            this.Padding = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Text = "";
            this.Activated += new System.EventHandler(this.frmBaseNotify_Activated);
            this.Load += new System.EventHandler(this.frmBaseNotify_Load);
            this.Resize += new System.EventHandler(this.frmBaseNotify_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.NotifyIcon notifyIcon1;
        public DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        public DevExpress.XtraBars.Alerter.AlertButton alertButton2;
        

    }
}