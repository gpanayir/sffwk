namespace Fwk.UI.Controls.Wizard
{
    partial class UC_TablasBD
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_TablasBD));
            this.chklistColumnas = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lstTablas = new DevExpress.XtraEditors.ImageListBoxControl();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.chklistColumnas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstTablas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // chklistColumnas
            // 
            this.chklistColumnas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.chklistColumnas.Location = new System.Drawing.Point(284, 26);
            this.chklistColumnas.Name = "chklistColumnas";
            this.chklistColumnas.Size = new System.Drawing.Size(251, 160);
            this.chklistColumnas.TabIndex = 0;
            this.chklistColumnas.SelectedIndexChanged += new System.EventHandler(this.chklistColumnas_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(19, 7);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Tablas";
            // 
            // lstTablas
            // 
            this.lstTablas.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lstTablas.ImageList = this.imageList1;
            this.lstTablas.Location = new System.Drawing.Point(19, 26);
            this.lstTablas.Name = "lstTablas";
            this.lstTablas.Size = new System.Drawing.Size(251, 160);
            this.lstTablas.TabIndex = 2;
            this.lstTablas.Tag = "";
            this.lstTablas.SelectedIndexChanged += new System.EventHandler(this.lstTablas_SelectedIndexChanged);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "databaseTable.gif");
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Location = new System.Drawing.Point(284, 7);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(46, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Columnas";
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // UC_TablasBD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.lstTablas);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.chklistColumnas);
            this.MaximumSize = new System.Drawing.Size(552, 196);
            this.Name = "UC_TablasBD";
            this.Size = new System.Drawing.Size(552, 196);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.UC_TablasBD_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.chklistColumnas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lstTablas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.CheckedListBoxControl chklistColumnas;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ImageListBoxControl lstTablas;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;

    }
}
