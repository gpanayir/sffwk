namespace Fwk.UI.Controls.Wizard
{
    partial class UC_SeparatedText
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
            this.cmbSeparationChar = new DevExpress.XtraEditors.ImageComboBoxEdit();
            this.lblCmbSeparator = new DevExpress.XtraEditors.LabelControl();
            this.chkHasColumnsName = new DevExpress.XtraEditors.CheckEdit();
            this.lblArchivoOrigen = new DevExpress.XtraEditors.LabelControl();
            this.ctlFileSelection = new Fwk.UI.Controls.UC_FileSelection();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSeparationChar.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHasColumnsName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSeparationChar
            // 
            this.cmbSeparationChar.Location = new System.Drawing.Point(135, 40);
            this.cmbSeparationChar.Name = "cmbSeparationChar";
            this.cmbSeparationChar.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbSeparationChar.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Tab", 9, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(",", 44, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem(";", 59, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("#", 35, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("-", 45, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Espacio", 32, -1)});
            this.cmbSeparationChar.Size = new System.Drawing.Size(204, 20);
            this.cmbSeparationChar.TabIndex = 15;
            // 
            // lblCmbSeparator
            // 
            this.lblCmbSeparator.Location = new System.Drawing.Point(5, 43);
            this.lblCmbSeparator.Name = "lblCmbSeparator";
            this.lblCmbSeparator.Size = new System.Drawing.Size(112, 13);
            this.lblCmbSeparator.TabIndex = 14;
            this.lblCmbSeparator.Text = "Caracter de separaci�n";
            // 
            // chkHasColumnsName
            // 
            this.chkHasColumnsName.Location = new System.Drawing.Point(3, 69);
            this.chkHasColumnsName.Name = "chkHasColumnsName";
            this.chkHasColumnsName.Properties.Caption = "Archivo contiene nombre de columnas";
            this.chkHasColumnsName.Size = new System.Drawing.Size(209, 18);
            this.chkHasColumnsName.TabIndex = 16;
            // 
            // lblArchivoOrigen
            // 
            this.lblArchivoOrigen.Location = new System.Drawing.Point(5, 13);
            this.lblArchivoOrigen.Name = "lblArchivoOrigen";
            this.lblArchivoOrigen.Size = new System.Drawing.Size(84, 13);
            this.lblArchivoOrigen.TabIndex = 17;
            this.lblArchivoOrigen.Text = "Archivo de origen";
            // 
            // ctlFileSelection
            // 
            this.ctlFileSelection.FileDialogFilter = "";
            this.ctlFileSelection.IsValidFile = false;
            this.ctlFileSelection.Location = new System.Drawing.Point(119, 12);
            this.ctlFileSelection.Name = "ctlFileSelection";
            this.ctlFileSelection.NullText = "";
            this.ctlFileSelection.OpenFileDialogTitle = "";
            this.ctlFileSelection.ReadOnly = false;
            this.ctlFileSelection.Size = new System.Drawing.Size(363, 20);
            this.ctlFileSelection.TabIndex = 18;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // UC_SeparatedText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.ctlFileSelection);
            this.Controls.Add(this.lblArchivoOrigen);
            this.Controls.Add(this.chkHasColumnsName);
            this.Controls.Add(this.cmbSeparationChar);
            this.Controls.Add(this.lblCmbSeparator);
            this.Name = "UC_SeparatedText";
            this.Size = new System.Drawing.Size(495, 95);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.UC_SeparatedText_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSeparationChar.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkHasColumnsName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.ImageComboBoxEdit cmbSeparationChar;
        private DevExpress.XtraEditors.LabelControl lblCmbSeparator;
        private DevExpress.XtraEditors.CheckEdit chkHasColumnsName;
        private Fwk.UI.Controls.UC_FileSelection ctlFileSelection;
        private DevExpress.XtraEditors.LabelControl lblArchivoOrigen;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}
