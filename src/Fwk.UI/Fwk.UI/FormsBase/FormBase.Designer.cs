

using Fwk.UI.Controls;
using Fwk.UI.Common;

namespace Fwk.UI.Forms
{
    partial class FormBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBase));
            this.ToolTipControl = new DevExpress.Utils.ToolTipController(this.components);
            this.ExceptionViewer = new Fwk.UI.Controls.ExceptionViewComponent(this.components);
            this.MessageViewer = new Fwk.UI.Controls.MessageViewerComponent(this.components);
            this.SuspendLayout();
            // 
            // ExceptionViewer
            // 
            this.ExceptionViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.ExceptionViewer.ButtonsYesNoVisible = DevExpress.XtraBars.BarItemVisibility.Never;
            this.ExceptionViewer.TextMessageColor = System.Drawing.Color.White;
            this.ExceptionViewer.TextMessageForeColorColor = System.Drawing.Color.Black;
            this.ExceptionViewer.Title = "";
            // 
            // MessageViewer
            // 
            this.MessageViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.MessageViewer.IconSize = Fwk.UI.Common.IconSize.Medium;
            this.MessageViewer.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.MessageViewer.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            this.MessageViewer.TextMessageColor = System.Drawing.Color.White;
            this.MessageViewer.TextMessageForeColor = System.Drawing.Color.Black;
            this.MessageViewer.Title = "";
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 413);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBase";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "FormBase";
            this.ResumeLayout(false);

        }

        #endregion

        public MessageViewerComponent MessageViewer;
        public ExceptionViewComponent ExceptionViewer;
        public DevExpress.Utils.ToolTipController ToolTipControl;
        

    }
}