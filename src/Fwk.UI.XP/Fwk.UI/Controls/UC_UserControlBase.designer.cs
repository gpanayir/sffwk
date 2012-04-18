namespace Fwk.UI.Controls
{
    partial class UC_UserControlBase
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
            this.components = new System.ComponentModel.Container();
            this.MessageViewer = new MessageViewerComponent(this.components);
            this.ExceptionViewer = new ExceptionViewComponent(this.components);
            this.simpleMessageViewComponent1 = new SimpleMessageViewComponent(this.components);
            this.SuspendLayout();
            // 
            // MessageViewer
            // 
            this.MessageViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.MessageViewer.IconSize = Fwk.UI.Common.IconSize.Small;
            this.MessageViewer.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            this.MessageViewer.TextMessageColor = System.Drawing.Color.White;
            this.MessageViewer.TextMessageForeColor = System.Drawing.Color.Black;
            this.MessageViewer.Title = "Message";
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.ExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Always;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.Color.Black;
            this.ExceptionViewer.Title = "Exception";
            // 
            // simpleMessageViewComponent1
            // 
            this.simpleMessageViewComponent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.simpleMessageViewComponent1.IconSize = Fwk.UI.Common.IconSize.Small;
            this.simpleMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.simpleMessageViewComponent1.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            this.simpleMessageViewComponent1.TextMessageColor = System.Drawing.Color.Empty;
            this.simpleMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.Black;
            this.simpleMessageViewComponent1.Title = "";
            // 
            // UserControlBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "UserControlBase";
            this.Size = new System.Drawing.Size(561, 307);
            this.ResumeLayout(false);

        }

        #endregion

        public MessageViewerComponent MessageViewer;
        public ExceptionViewComponent ExceptionViewer;
        private SimpleMessageViewComponent simpleMessageViewComponent1;
    }
}