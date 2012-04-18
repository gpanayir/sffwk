namespace Fwk.UI.Controls
{
    /// <summary>
    /// 
    /// </summary>
    partial class MessageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessageView));
            this.lbOptionalMessage = new DevExpress.XtraEditors.LabelControl();
            this.txtMessage = new DevExpress.XtraEditors.MemoEdit();
            this.btnOk = new DevExpress.XtraEditors.BaseButton();
            this.btnCancel = new DevExpress.XtraEditors.BaseButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNo = new DevExpress.XtraEditors.BaseButton();
            this.btnYes = new DevExpress.XtraEditors.BaseButton();
            this.imgIcon = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // lbOptionalMessage
            // 
            resources.ApplyResources(this.lbOptionalMessage, "lbOptionalMessage");
            this.lbOptionalMessage.Name = "lbOptionalMessage";
            // 
            // txtMessage
            // 
            resources.ApplyResources(this.txtMessage, "txtMessage");
            this.txtMessage.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Properties.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("txtMessage.Properties.Appearance.BackColor")));
            this.txtMessage.Properties.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("txtMessage.Properties.Appearance.ForeColor")));
            this.txtMessage.Properties.Appearance.Options.UseBackColor = true;
            this.txtMessage.Properties.Appearance.Options.UseForeColor = true;
            this.txtMessage.Properties.ReadOnly = true;
            // 
            // btnOk
            // 
            resources.ApplyResources(this.btnOk, "btnOk");
            this.btnOk.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnOk.Appearance.ForeColor")));
            this.btnOk.Appearance.Options.UseForeColor = true;
            this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOk.Name = "btnOk";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnCancel.Appearance.ForeColor")));
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnCancel);
            this.flowLayoutPanel1.Controls.Add(this.btnOk);
            this.flowLayoutPanel1.Controls.Add(this.btnNo);
            this.flowLayoutPanel1.Controls.Add(this.btnYes);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // btnNo
            // 
            resources.ApplyResources(this.btnNo, "btnNo");
            this.btnNo.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnNo.Appearance.ForeColor")));
            this.btnNo.Appearance.Options.UseForeColor = true;
            this.btnNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNo.Name = "btnNo";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // btnYes
            // 
            resources.ApplyResources(this.btnYes, "btnYes");
            this.btnYes.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("btnYes.Appearance.ForeColor")));
            this.btnYes.Appearance.Options.UseForeColor = true;
            this.btnYes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnYes.Name = "btnYes";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // imgIcon
            // 
            this.imgIcon.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.imgIcon.Image = global::Fwk.UI.Properties.Resources.information_32;
            resources.ApplyResources(this.imgIcon, "imgIcon");
            this.imgIcon.Name = "imgIcon";
            this.imgIcon.TabStop = false;
            // 
            // MessageView
            // 
            this.Appearance.ForeColor = ((System.Drawing.Color)(resources.GetObject("MessageView.Appearance.ForeColor")));
            this.Appearance.Options.UseForeColor = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.imgIcon);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lbOptionalMessage);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.LookAndFeel.SkinName = "Money Twins";
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.Name = "MessageView";
            this.Opacity = 0.9D;
            ((System.ComponentModel.ISupportInitialize)(this.txtMessage.Properties)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgIcon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lbOptionalMessage;
        internal DevExpress.XtraEditors.BaseButton btnOk;
        private DevExpress.XtraEditors.MemoEdit txtMessage;
        internal DevExpress.XtraEditors.BaseButton btnCancel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        internal DevExpress.XtraEditors.BaseButton btnNo;
        internal DevExpress.XtraEditors.BaseButton btnYes;
        private System.Windows.Forms.PictureBox imgIcon;
    }
}