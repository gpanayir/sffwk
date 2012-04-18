using Fwk.UI.Common;
namespace Fwk.UI.Controls.Wizard
{
    partial class FRM_Wizard
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
            this.uC_WizzardMain1 = new Fwk.UI.Controls.Wizard.UC_WizzardMain();
            this.SuspendLayout();
            // 
            // uC_WizzardMain1
            // 
            this.uC_WizzardMain1.AcceptButton = null;
            this.uC_WizzardMain1.CancelButton = null;
            this.uC_WizzardMain1.ColumnsToMap = null;
            this.uC_WizzardMain1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uC_WizzardMain1.Location = new System.Drawing.Point(3, 3);
            this.uC_WizzardMain1.Name = "uC_WizzardMain1";
            this.uC_WizzardMain1.RecordSetFileType = Fwk.UI.Common.DataOriginTypeEnum.DataBase;
            this.uC_WizzardMain1.Size = new System.Drawing.Size(672, 497);
            this.uC_WizzardMain1.TabIndex = 0;
            // 
            // FRM_Wizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 503);
            this.Controls.Add(this.uC_WizzardMain1);
            this.MinimumSize = new System.Drawing.Size(684, 535);
            this.Name = "FRM_Wizard";
            this.Text = "Wizard";
            this.ResumeLayout(false);

        }

        #endregion

        private UC_WizzardMain uC_WizzardMain1;
    }
}