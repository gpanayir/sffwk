namespace Fwk.UI.Controls.Wizard
{
    partial class UC_ExcelWorkSheets
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
            this.lblArchivoOrigen = new DevExpress.XtraEditors.LabelControl();
            this.ctlFileSelection = new Fwk.UI.Controls.UC_FileSelection();
            this.lblHoja = new DevExpress.XtraEditors.LabelControl();
            this.workSheetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmbWorkSheet = new DevExpress.XtraEditors.LookUpEdit();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.workSheetsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWorkSheet.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblArchivoOrigen
            // 
            this.lblArchivoOrigen.Location = new System.Drawing.Point(12, 23);
            this.lblArchivoOrigen.Name = "lblArchivoOrigen";
            this.lblArchivoOrigen.Size = new System.Drawing.Size(84, 13);
            this.lblArchivoOrigen.TabIndex = 0;
            this.lblArchivoOrigen.Text = "Archivo de origen";
            // 
            // ctlFileSelection
            // 
            this.ctlFileSelection.FileDialogFilter = "";
            this.ctlFileSelection.IsValidFile = false;
            this.ctlFileSelection.Location = new System.Drawing.Point(130, 16);
            this.ctlFileSelection.Name = "ctlFileSelection";
            this.ctlFileSelection.NullText = "";
            this.ctlFileSelection.OpenFileDialogTitle = "";
            this.ctlFileSelection.ReadOnly = false;
            this.ctlFileSelection.Size = new System.Drawing.Size(404, 20);
            this.ctlFileSelection.TabIndex = 1;
            this.ctlFileSelection.OnSelectedOk += new System.EventHandler(this.ctlFileSelection_OnSelectedOk);
            // 
            // lblHoja
            // 
            this.lblHoja.Location = new System.Drawing.Point(12, 53);
            this.lblHoja.Name = "lblHoja";
            this.lblHoja.Size = new System.Drawing.Size(122, 13);
            this.lblHoja.TabIndex = 2;
            this.lblHoja.Text = "Hoja de planilla de c�lculo";
            // 
            // workSheetsBindingSource
            // 
            this.workSheetsBindingSource.DataSource = typeof(Fwk.HelperFunctions.WorkSheets);
            // 
            // cmbWorkSheet
            // 
            this.cmbWorkSheet.Location = new System.Drawing.Point(147, 50);
            this.cmbWorkSheet.Name = "cmbWorkSheet";
            this.cmbWorkSheet.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbWorkSheet.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetDisplayName", "", 118, DevExpress.Utils.FormatType.None, "", true, DevExpress.Utils.HorzAlignment.Near),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SheetOriginalName", "Sheet Original Name", 107, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Near)});
            this.cmbWorkSheet.Properties.DataSource = this.workSheetsBindingSource;
            this.cmbWorkSheet.Properties.DisplayMember = "SheetDisplayName";
            this.cmbWorkSheet.Properties.NullText = "";
            this.cmbWorkSheet.Properties.ValueMember = "SheetOriginalName";
            this.cmbWorkSheet.Size = new System.Drawing.Size(203, 20);
            this.cmbWorkSheet.TabIndex = 3;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // UC_ExcelWorkSheets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.cmbWorkSheet);
            this.Controls.Add(this.lblHoja);
            this.Controls.Add(this.ctlFileSelection);
            this.Controls.Add(this.lblArchivoOrigen);
            this.Name = "UC_ExcelWorkSheets";
            this.Size = new System.Drawing.Size(546, 83);
            this.Load += new System.EventHandler(this.UC_ExcelWorkSheets_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.UC_ExcelWorkSheets_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.workSheetsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbWorkSheet.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblArchivoOrigen;
        private Fwk.UI.Controls.UC_FileSelection ctlFileSelection;
        private DevExpress.XtraEditors.LabelControl lblHoja;
        private System.Windows.Forms.BindingSource workSheetsBindingSource;
        private DevExpress.XtraEditors.LookUpEdit cmbWorkSheet;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;

    }
}
