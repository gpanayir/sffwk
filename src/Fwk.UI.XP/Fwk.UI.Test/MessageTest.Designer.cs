namespace Fwk.UI.Test
{
    partial class MessageTest
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.messageViewerComponent1 = new Fwk.UI.Controls.MessageViewerComponent(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.simpleMessageViewComponent1 = new Fwk.UI.Controls.SimpleMessageViewComponent(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(45, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(312, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Show Simple message View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(380, 29);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(372, 67);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "Env�as un SMS gratis desde el portal Arnet a un tel�fono Personal. Ahora podes ha" +
                "cerlo desde Arnet gratis y al instante.";
            // 
            // messageViewerComponent1
            // 
            this.messageViewerComponent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.messageViewerComponent1.IconSize = Fwk.UI.Common.IconSize.Small;
            this.messageViewerComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OKCancel;
            this.messageViewerComponent1.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Warning;
            this.messageViewerComponent1.TextMessageColor = System.Drawing.Color.White;
            this.messageViewerComponent1.TextMessageForeColor = System.Drawing.Color.Black;
            this.messageViewerComponent1.Title = "Message";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(45, 146);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(312, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Show Simple message View";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // simpleMessageViewComponent1
            // 
            this.simpleMessageViewComponent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.simpleMessageViewComponent1.IconSize = Fwk.UI.Common.IconSize.Small;
            this.simpleMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.simpleMessageViewComponent1.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Error;
            this.simpleMessageViewComponent1.TextMessageColor = System.Drawing.Color.Empty;
            this.simpleMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.Black;
            this.simpleMessageViewComponent1.Title = "Fwk ";
            // 
            // MessageTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 594);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "MessageTest";
            this.Text = "MessageTest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private Fwk.UI.Controls.MessageViewerComponent messageViewerComponent1;
        private System.Windows.Forms.Button button2;
        private Fwk.UI.Controls.SimpleMessageViewComponent simpleMessageViewComponent1;
    }
}