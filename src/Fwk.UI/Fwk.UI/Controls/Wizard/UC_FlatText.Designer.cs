using Fwk.UI.Controls.ImportControls;

namespace Fwk.UI.Controls.Wizard
{
    partial class UC_FlatText
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
            this.cmbFileSelection = new Fwk.UI.Controls.UC_FileSelection();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtColumnsEditor1 = new Fwk.UI.Controls.ImportControls.UC_TXTColumnsEditor();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbFileSelection
            // 
            this.cmbFileSelection.FileDialogFilter = "Archivo de texto (*.txt) | *.txt";
            this.cmbFileSelection.IsValidFile = false;
            this.cmbFileSelection.Location = new System.Drawing.Point(87, 5);
            this.cmbFileSelection.Name = "cmbFileSelection";
            this.cmbFileSelection.NullText = "";
            this.cmbFileSelection.OpenFileDialogTitle = "Seleccione el archivo origen de los datos";
            this.cmbFileSelection.ReadOnly = false;
            this.cmbFileSelection.Size = new System.Drawing.Size(240, 20);
            this.cmbFileSelection.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(3, 9);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(75, 13);
            this.labelControl1.TabIndex = 5;
            this.labelControl1.Text = "Archivo Origen:";
            // 
            // txtColumnsEditor1
            // 
            this.txtColumnsEditor1.AcceptButton = null;
            this.txtColumnsEditor1.CancelButton = null;
            this.txtColumnsEditor1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtColumnsEditor1.Location = new System.Drawing.Point(0, 36);
            this.txtColumnsEditor1.Name = "txtColumnsEditor1";
            this.txtColumnsEditor1.Size = new System.Drawing.Size(439, 143);
            this.txtColumnsEditor1.TabIndex = 6;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // UC_FlatText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.txtColumnsEditor1);
            this.Controls.Add(this.cmbFileSelection);
            this.Controls.Add(this.labelControl1);
            this.Name = "UC_FlatText";
            this.Size = new System.Drawing.Size(439, 179);
            this.Load += new System.EventHandler(this.UC_FlatText_Load);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.UC_FlatText_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.UI.Controls.UC_FileSelection cmbFileSelection;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private UC_TXTColumnsEditor txtColumnsEditor1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;

    }
}
