namespace Fwk.UI.Controls
{
    partial class UC_ExportToolBar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UC_ExportToolBar));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnExcel = new DevExpress.XtraEditors.SimpleButton();
            this.toolTipController1 = new DevExpress.Utils.ToolTipController();
            this.btnPDF = new DevExpress.XtraEditors.SimpleButton();
            this.btnTXT = new DevExpress.XtraEditors.SimpleButton();
            this.btnHTML = new DevExpress.XtraEditors.SimpleButton();
            this.btnXML = new DevExpress.XtraEditors.SimpleButton();
            this.popupContainerEdit1 = new DevExpress.XtraEditors.PopupContainerEdit();
            this.popupContainerControl1 = new DevExpress.XtraEditors.PopupContainerControl();
            this.simpleMessageViewComponent2 = new Fwk.UI.Controls.SimpleMessageViewComponent();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).BeginInit();
            this.popupContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::Fwk.UI.Properties.Resources.Excel_16x16;
            this.btnExcel.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnExcel.Location = new System.Drawing.Point(3, 4);
            this.btnExcel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(34, 28);
            this.btnExcel.TabIndex = 1;
            this.btnExcel.ToolTip = "Documento de planilla de c�lculo";
            this.btnExcel.ToolTipController = this.toolTipController1;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.Image = global::Fwk.UI.Properties.Resources.PDF_16x16;
            this.btnPDF.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnPDF.Location = new System.Drawing.Point(44, 4);
            this.btnPDF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(34, 28);
            this.btnPDF.TabIndex = 2;
            this.btnPDF.ToolTip = "Archivo PDF";
            this.btnPDF.ToolTipController = this.toolTipController1;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnTXT
            // 
            this.btnTXT.Image = global::Fwk.UI.Properties.Resources.note_16x16;
            this.btnTXT.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnTXT.Location = new System.Drawing.Point(85, 4);
            this.btnTXT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTXT.Name = "btnTXT";
            this.btnTXT.Size = new System.Drawing.Size(34, 28);
            this.btnTXT.TabIndex = 4;
            this.btnTXT.ToolTip = "Documento de Texto";
            this.btnTXT.ToolTipController = this.toolTipController1;
            this.btnTXT.Click += new System.EventHandler(this.btnTXT_Click);
            // 
            // btnHTML
            // 
            this.btnHTML.Image = global::Fwk.UI.Properties.Resources.html_16x16;
            this.btnHTML.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnHTML.Location = new System.Drawing.Point(126, 4);
            this.btnHTML.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHTML.Name = "btnHTML";
            this.btnHTML.Size = new System.Drawing.Size(34, 28);
            this.btnHTML.TabIndex = 0;
            this.btnHTML.ToolTip = "P�gina Web";
            this.btnHTML.ToolTipController = this.toolTipController1;
            this.btnHTML.Click += new System.EventHandler(this.btnHTML_Click);
            // 
            // btnXML
            // 
            this.btnXML.Image = global::Fwk.UI.Properties.Resources.xml_16x16;
            this.btnXML.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnXML.Location = new System.Drawing.Point(167, 4);
            this.btnXML.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXML.Name = "btnXML";
            this.btnXML.Size = new System.Drawing.Size(34, 28);
            this.btnXML.TabIndex = 3;
            this.btnXML.ToolTip = "Archivo XML";
            this.btnXML.ToolTipController = this.toolTipController1;
            this.btnXML.Click += new System.EventHandler(this.btnXML_Click);
            // 
            // popupContainerEdit1
            // 
            this.popupContainerEdit1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popupContainerEdit1.Location = new System.Drawing.Point(0, 0);
            this.popupContainerEdit1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.popupContainerEdit1.Name = "popupContainerEdit1";
            this.popupContainerEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, ((System.Drawing.Image)(resources.GetObject("popupContainerEdit1.Properties.Buttons"))), new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.popupContainerEdit1.Properties.PopupControl = this.popupContainerControl1;
            this.popupContainerEdit1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.popupContainerEdit1.Size = new System.Drawing.Size(34, 22);
            this.popupContainerEdit1.TabIndex = 1;
            this.popupContainerEdit1.ToolTip = "Exportar a...";
            this.popupContainerEdit1.ToolTipController = this.toolTipController1;
            // 
            // popupContainerControl1
            // 
            this.popupContainerControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.popupContainerControl1.Appearance.Options.UseBackColor = true;
            this.popupContainerControl1.Controls.Add(this.btnExcel);
            this.popupContainerControl1.Controls.Add(this.btnXML);
            this.popupContainerControl1.Controls.Add(this.btnPDF);
            this.popupContainerControl1.Controls.Add(this.btnHTML);
            this.popupContainerControl1.Controls.Add(this.btnTXT);
            this.popupContainerControl1.Location = new System.Drawing.Point(65, 4);
            this.popupContainerControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.popupContainerControl1.Name = "popupContainerControl1";
            this.popupContainerControl1.Size = new System.Drawing.Size(208, 41);
            this.popupContainerControl1.TabIndex = 2;
            // 
            // simpleMessageViewComponent2
            // 
            this.simpleMessageViewComponent2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.simpleMessageViewComponent2.IconSize = Fwk.UI.Common.IconSize.Small;
            this.simpleMessageViewComponent2.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.YesNo;
            this.simpleMessageViewComponent2.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Information;
            this.simpleMessageViewComponent2.TextMessageColor = System.Drawing.Color.Empty;
            this.simpleMessageViewComponent2.TextMessageForeColor = System.Drawing.Color.Black;
            this.simpleMessageViewComponent2.Title = "Informaci�n";
            // 
            // UC_ExportToolBar
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseForeColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.popupContainerControl1);
            this.Controls.Add(this.popupContainerEdit1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "UC_ExportToolBar";
            this.Size = new System.Drawing.Size(34, 28);
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popupContainerControl1)).EndInit();
            this.popupContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnHTML;
        private DevExpress.XtraEditors.SimpleButton btnExcel;
        private DevExpress.XtraEditors.SimpleButton btnPDF;
        private DevExpress.XtraEditors.SimpleButton btnXML;
        private DevExpress.XtraEditors.SimpleButton btnTXT;
        private DevExpress.Utils.ToolTipController toolTipController1;
        private DevExpress.XtraEditors.PopupContainerEdit popupContainerEdit1;
        private DevExpress.XtraEditors.PopupContainerControl popupContainerControl1;
        
        private SimpleMessageViewComponent simpleMessageViewComponent2;


    }
}
