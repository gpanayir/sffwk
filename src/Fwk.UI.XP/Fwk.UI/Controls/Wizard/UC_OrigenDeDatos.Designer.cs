using Fwk.UI.Common;
namespace Fwk.UI.Controls.Wizard
{
    partial class UC_OrigenDeDatos
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
            this.enumComboBox1 = new Fwk.UI.Controls.EnumComboBox(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.enumComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.enumComboBox1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // enumComboBox1
            // 
            this.enumComboBox1.AllowEmptyTextValue = false;
            this.enumComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.enumComboBox1.EditValue = DataOriginTypeEnum.CharSeparated;
            this.enumComboBox1.EnumType = Fwk.UI.Common.TypesEnum.DataOriginTypeEnum;
            this.enumComboBox1.ErrorIconRightToLeft = false;
            this.enumComboBox1.Location = new System.Drawing.Point(6, 24);
            this.enumComboBox1.Name = "enumComboBox1";
            this.enumComboBox1.NullTextValue = null;
            this.enumComboBox1.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.enumComboBox1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.enumComboBox1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.ImageComboBoxItem[] {
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Archivo de texto separado por un caracter", DataOriginTypeEnum.CharSeparated, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Archivo Xls", DataOriginTypeEnum.Xls, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Archivo de texto plano sin separador de columnas", DataOriginTypeEnum.PlainText, -1),
            new DevExpress.XtraEditors.Controls.ImageComboBoxItem("Datos almacenados en una base de datos", DataOriginTypeEnum.DataBase, -1)});
            this.enumComboBox1.Properties.NullText = "<Seleccione una opción...>";
            this.enumComboBox1.ReadOnly = false;
            this.enumComboBox1.Required = true;
            this.enumComboBox1.RequiredErrorText = "Valor requerido";
            this.enumComboBox1.Size = new System.Drawing.Size(232, 20);
            this.enumComboBox1.TabIndex = 0;
            this.enumComboBox1.Validating += new System.ComponentModel.CancelEventHandler(this.enumComboBox1_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Origen de Datos";
            // 
            // UC_OrigenDeDatos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enumComboBox1);
            this.Name = "UC_OrigenDeDatos";
            this.Size = new System.Drawing.Size(245, 50);
            ((System.ComponentModel.ISupportInitialize)(this.enumComboBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.enumComboBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Fwk.UI.Controls.EnumComboBox enumComboBox1;
        private System.Windows.Forms.Label label1;
    }
}
