using ICSharpCode.TextEditor;
using System.Windows.Forms;
using ICSharpCode.TextEditor.Document;
using System.Drawing;
namespace Fwk.Controls.Win32.TextCodeEditor
{
    partial class TextCodeEditor
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

        private void InitializeComponent()
        {
            this.txtEditor = new ICSharpCode.TextEditor.TextEditorControl();
            this.lblTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtEditor
            // 
            this.txtEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEditor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtEditor.EnableFolding = false;
            this.txtEditor.Location = new System.Drawing.Point(0, 19);
            this.txtEditor.Name = "txtEditor";
            this.txtEditor.ShowEOLMarkers = true;
            this.txtEditor.ShowSpaces = true;
            this.txtEditor.ShowTabs = true;
            this.txtEditor.ShowVRuler = true;
            this.txtEditor.Size = new System.Drawing.Size(533, 316);
            this.txtEditor.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTitle.BackColor = System.Drawing.Color.Silver;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(524, 16);
            this.lblTitle.TabIndex = 2;
            // 
            // TextCodeEditor
            // 
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtEditor);
            this.Name = "TextCodeEditor";
            this.Size = new System.Drawing.Size(536, 338);
            this.ResumeLayout(false);

        }


        private ICSharpCode.TextEditor.TextEditorControl txtEditor;

        private System.Windows.Forms.MenuItem menuItem12;
        private System.Windows.Forms.MenuItem menuItem13;
        private System.Windows.Forms.Label lblTitle;
       

        #endregion
    }
}
