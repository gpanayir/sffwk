namespace Fwk.UI.Controls.Wizard
{
    partial class UC_Importar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_Importar));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.btnImportar = new DevExpress.XtraEditors.SimpleButton();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.lblAguarde = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.SuspendLayout();
            
            // 
            // btnImportar
            // 
            this.btnImportar.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportar.Location = new System.Drawing.Point(212, 203);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 6;
            this.btnImportar.Text = "Importar";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // picLoading
            // 
            this.picLoading.Image = ((System.Drawing.Image)(resources.GetObject("picLoading.Image")));
            this.picLoading.Location = new System.Drawing.Point(184, 162);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(131, 19);
            this.picLoading.TabIndex = 7;
            this.picLoading.TabStop = false;
            // 
            // lblAguarde
            // 
            this.lblAguarde.Location = new System.Drawing.Point(98, 132);
            this.lblAguarde.Name = "lblAguarde";
            this.lblAguarde.Size = new System.Drawing.Size(302, 13);
            this.lblAguarde.TabIndex = 8;
            this.lblAguarde.Text = "Por favor aguarde, esta operación puede tardar unos minutos.";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(169, 183);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(160, 13);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Finalizo el proceso de importación";
            this.labelControl1.Visible = false;
            // 
            // UC_Importar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.lblAguarde);
            this.Controls.Add(this.picLoading);
            this.Controls.Add(this.btnImportar);
            this.Name = "UC_Importar";
            this.Size = new System.Drawing.Size(498, 358);
            this.Load += new System.EventHandler(this.UC_Importar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton btnImportar;
        private System.Windows.Forms.PictureBox picLoading;
        private DevExpress.XtraEditors.LabelControl lblAguarde;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
