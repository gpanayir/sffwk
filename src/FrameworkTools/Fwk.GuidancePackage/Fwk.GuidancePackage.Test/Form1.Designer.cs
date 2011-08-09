namespace Fwk.GuidancePackage.Test
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            //this.wizDBSelect1 = new Fwk.GuidPk.wizDBSelect();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.wizDBSelect1)).BeginInit();
            this.SuspendLayout();
            // 
            // wizDBSelect1
            // 
            this.wizDBSelect1.AutoSize = true;
            this.wizDBSelect1.Cancellable = true;
            
            this.wizDBSelect1.Configuration = null;
            this.wizDBSelect1.Headline = "";
            this.wizDBSelect1.HelpKeyword = "";
            this.wizDBSelect1.Id = "4fb13bfb-34ce-49e8-933d-4cb8722fc228";
            this.wizDBSelect1.InfoRTBoxIcon = ((System.Drawing.Bitmap)(resources.GetObject("wizDBSelect1.InfoRTBoxIcon")));
            this.wizDBSelect1.InfoRTBoxSize = new System.Drawing.Size(496, 60);
            this.wizDBSelect1.InfoRTBoxText = "";
            this.wizDBSelect1.Location = new System.Drawing.Point(19, 9);
            
            this.wizDBSelect1.Margin = new System.Windows.Forms.Padding(0);
            this.wizDBSelect1.Name = "wizDBSelect1";
            this.wizDBSelect1.ParentPage = null;
            this.wizDBSelect1.ShowInfoPanel = false;
            this.wizDBSelect1.Size = new System.Drawing.Size(686, 456);
            this.wizDBSelect1.Skippable = true;
            this.wizDBSelect1.StepTitle = "";
            this.wizDBSelect1.TabIndex = 0;
            
            this.wizDBSelect1.Visited = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(37, 501);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(155, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 614);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.wizDBSelect1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.wizDBSelect1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.GuidPk.wizDBSelect wizDBSelect1;
        private System.Windows.Forms.Button button1;
    }
}

