using Fwk.UI.Common;
using Fwk.UI.Controls;
namespace Fwk.UI.Test
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.richEditBarController1 = new DevExpress.XtraRichEdit.UI.RichEditBarController();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.fwkFlatTextBox1 = new Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox(this.components);
            this.fwkNumericTextBox1 = new Fwk.Bases.FrontEnd.Controls.FwkNumericTextBox();
            this.fwkAutoComboBox1 = new Fwk.Bases.FrontEnd.Controls.FwkAutoComboBox();
            this.formConnector1 = new Fwk.Bases.FrontEnd.Controls.FormConnector(this.components);
            this.simpleMessageViewComponent1 = new Fwk.UI.Controls.SimpleMessageViewComponent(this.components);
            this.importDataFromDataOrigin1 = new Fwk.UI.Controls.Wizard.ImportDataFromDataOrigin(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.uC_LabelTitle2 = new Fwk.UI.Controls.UC_LabelTitle();
            this.uC_ExportToolBar1 = new Fwk.UI.Controls.UC_ExportToolBar();
            this.uC_AuthenticationBD1 = new Fwk.UI.Controls.Wizard.UC_AuthenticationBD();
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.uC_LabelTitle2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(20, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 54);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(43, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(80, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            // 
            // fwkFlatTextBox1
            // 
            this.fwkFlatTextBox1.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fwkFlatTextBox1.AllowBlankSpace = true;
            this.fwkFlatTextBox1.AllowedCharacters = null;
            this.fwkFlatTextBox1.CapitalOnly = false;
            this.fwkFlatTextBox1.ErrorIconRightToLeft = false;
            this.fwkFlatTextBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwkFlatTextBox1.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.fwkFlatTextBox1.Location = new System.Drawing.Point(0, 0);
            this.fwkFlatTextBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fwkFlatTextBox1.Name = "fwkFlatTextBox1";
            this.fwkFlatTextBox1.NotAllowedCharactersErrorText = "";
            this.fwkFlatTextBox1.Required = false;
            this.fwkFlatTextBox1.RequiredErrorText = null;
            this.fwkFlatTextBox1.Size = new System.Drawing.Size(132, 24);
            this.fwkFlatTextBox1.TabIndex = 21;
            this.fwkFlatTextBox1.TextBoxType = Fwk.Bases.FrontEnd.Controls.TextBoxTypeEnum.Nothing;
            // 
            // fwkNumericTextBox1
            // 
            this.fwkNumericTextBox1.Location = new System.Drawing.Point(716, 65);
            this.fwkNumericTextBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.fwkNumericTextBox1.Name = "fwkNumericTextBox1";
            this.fwkNumericTextBox1.NumericType = Fwk.Bases.FrontEnd.Controls.FwkNumericTextBox.NumericTypeEnum.Int;
            this.fwkNumericTextBox1.Size = new System.Drawing.Size(189, 26);
            this.fwkNumericTextBox1.TabIndex = 18;
            this.fwkNumericTextBox1.TextBoxBorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.fwkNumericTextBox1.TextBoxEnabled = true;
            this.fwkNumericTextBox1.TextBoxFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwkNumericTextBox1.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.fwkNumericTextBox1.TextBoxText = "0";
            this.fwkNumericTextBox1.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // fwkAutoComboBox1
            // 
            this.fwkAutoComboBox1.ActiveArrowColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fwkAutoComboBox1.ActiveBorderColor = System.Drawing.SystemColors.ControlDarkDark;
            this.fwkAutoComboBox1.ActiveButtonColor = System.Drawing.SystemColors.ControlDark;
            this.fwkAutoComboBox1.AllowEmptyTextValue = false;
            this.fwkAutoComboBox1.AutoComplete = false;
            this.fwkAutoComboBox1.ErrorIconRightToLeft = false;
            this.fwkAutoComboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.fwkAutoComboBox1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fwkAutoComboBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(83)))), ((int)(((byte)(141)))));
            this.fwkAutoComboBox1.FormattingEnabled = true;
            this.fwkAutoComboBox1.InactiveArrowColor = System.Drawing.SystemColors.ControlDark;
            this.fwkAutoComboBox1.InactiveBorderColor = System.Drawing.SystemColors.ControlDark;
            this.fwkAutoComboBox1.InactiveButtonColor = System.Drawing.SystemColors.Control;
            this.fwkAutoComboBox1.Location = new System.Drawing.Point(459, 32);
            this.fwkAutoComboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fwkAutoComboBox1.Name = "fwkAutoComboBox1";
            this.fwkAutoComboBox1.NullTextValue = null;
            this.fwkAutoComboBox1.ReadOnly = false;
            this.fwkAutoComboBox1.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.fwkAutoComboBox1.Required = false;
            this.fwkAutoComboBox1.RequiredErrorText = null;
            this.fwkAutoComboBox1.Size = new System.Drawing.Size(160, 25);
            this.fwkAutoComboBox1.TabIndex = 17;
            // 
            // formConnector1
            // 
            this.formConnector1.EntityParam = null;
            this.formConnector1.EntityResult = null;
            this.formConnector1.FormAssemblyName = null;
            this.formConnector1.FormClassName = null;
            this.formConnector1.FormStartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.formConnector1.FormWindowState = System.Windows.Forms.FormWindowState.Normal;
            // 
            // simpleMessageViewComponent1
            // 
            this.simpleMessageViewComponent1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.simpleMessageViewComponent1.IconSize = Fwk.UI.Common.IconSize.XtraLarge;
            this.simpleMessageViewComponent1.MessageBoxButtons = System.Windows.Forms.MessageBoxButtons.OK;
            this.simpleMessageViewComponent1.MessageBoxIcon = Fwk.UI.Common.MessageBoxIcon.Exclamation;
            this.simpleMessageViewComponent1.TextMessageColor = System.Drawing.Color.Empty;
            this.simpleMessageViewComponent1.TextMessageForeColor = System.Drawing.Color.Black;
            this.simpleMessageViewComponent1.Title = "Exportación";
            // 
            // importDataFromDataOrigin1
            // 
            this.importDataFromDataOrigin1.ColumnsToMap = null;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(805, 159);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 102);
            this.button2.TabIndex = 6;
            this.button2.Text = "Wizard Importar Registros";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // uC_LabelTitle2
            // 
            this.uC_LabelTitle2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.uC_LabelTitle2.Appearance.Options.UseBackColor = true;
            this.uC_LabelTitle2.IconVisible = true;
            this.uC_LabelTitle2.Image = ((System.Drawing.Image)(resources.GetObject("uC_LabelTitle2.Image")));
            this.uC_LabelTitle2.Location = new System.Drawing.Point(439, 266);
            this.uC_LabelTitle2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uC_LabelTitle2.Name = "uC_LabelTitle2";
            this.uC_LabelTitle2.Size = new System.Drawing.Size(469, 30);
            this.uC_LabelTitle2.TabIndex = 8;
            this.uC_LabelTitle2.TitleBackColor = System.Drawing.Color.Transparent;
            this.uC_LabelTitle2.TitleFont = new System.Drawing.Font("Tahoma", 10F);
            this.uC_LabelTitle2.TitleForeColor = System.Drawing.Color.Black;
            this.uC_LabelTitle2.TitleText = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";
            // 
            // uC_LabelTitle2.Working_Image
            // 
            this.uC_LabelTitle2.Working_Image.Image = ((System.Drawing.Image)(resources.GetObject("uC_LabelTitle2.Working_Image.Image")));
            this.uC_LabelTitle2.Working_Image.Location = new System.Drawing.Point(344, 55);
            this.uC_LabelTitle2.Working_Image.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.uC_LabelTitle2.Working_Image.Name = "Working_Image";
            this.uC_LabelTitle2.Working_Image.Size = new System.Drawing.Size(18, 23);
            this.uC_LabelTitle2.Working_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.uC_LabelTitle2.Working_Image.TabIndex = 6;
            this.uC_LabelTitle2.Working_Image.TabStop = false;
            // 
            // uC_ExportToolBar1
            // 
            this.uC_ExportToolBar1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.uC_ExportToolBar1.Appearance.ForeColor = System.Drawing.SystemColors.ControlText;
            this.uC_ExportToolBar1.Appearance.Options.UseBackColor = true;
            this.uC_ExportToolBar1.Appearance.Options.UseForeColor = true;
            this.uC_ExportToolBar1.GridControl = null;
            this.uC_ExportToolBar1.GridViewToExport = null;
            this.uC_ExportToolBar1.Location = new System.Drawing.Point(621, 159);
            this.uC_ExportToolBar1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uC_ExportToolBar1.Name = "uC_ExportToolBar1";
            this.uC_ExportToolBar1.Size = new System.Drawing.Size(39, 28);
            this.uC_ExportToolBar1.TabIndex = 15;
            // 
            // uC_AuthenticationBD1
            // 
            this.uC_AuthenticationBD1.AcceptButton = null;
            this.uC_AuthenticationBD1.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.uC_AuthenticationBD1.CancelButton = null;
            
            this.uC_AuthenticationBD1.Location = new System.Drawing.Point(611, 266);
            this.uC_AuthenticationBD1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.uC_AuthenticationBD1.Name = "uC_AuthenticationBD1";
            this.uC_AuthenticationBD1.NameServer = "";
            this.uC_AuthenticationBD1.ServerSelected = null;
            this.uC_AuthenticationBD1.Size = new System.Drawing.Size(399, 418);
            this.uC_AuthenticationBD1.TabIndex = 22;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 745);
            this.Controls.Add(this.uC_AuthenticationBD1);
            this.Controls.Add(this.uC_ExportToolBar1);
            this.Controls.Add(this.uC_LabelTitle2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.fwkAutoComboBox1);
            this.Controls.Add(this.fwkNumericTextBox1);
            this.Controls.Add(this.fwkFlatTextBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.richEditBarController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.uC_LabelTitle2.ResumeLayout(false);
            this.uC_LabelTitle2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button1;
        private DevExpress.XtraRichEdit.UI.RichEditBarController richEditBarController1;
        private SimpleMessageViewComponent simpleMessageViewComponent1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        
        private Fwk.Bases.FrontEnd.Controls.FwkAutoComboBox fwkAutoComboBox1;
        private Fwk.Bases.FrontEnd.Controls.FwkNumericTextBox fwkNumericTextBox1;
        
        
        private Fwk.Bases.FrontEnd.Controls.FwkFlatTextBox fwkFlatTextBox1;
        private Fwk.Bases.FrontEnd.Controls.FormConnector formConnector1;
        private System.Windows.Forms.Button button2;
        private Fwk.UI.Controls.Wizard.ImportDataFromDataOrigin importDataFromDataOrigin1;
        private UC_LabelTitle uC_LabelTitle2;
        private UC_ExportToolBar uC_ExportToolBar1;
        private Fwk.UI.Controls.Wizard.UC_AuthenticationBD uC_AuthenticationBD1;
        


    }
}

