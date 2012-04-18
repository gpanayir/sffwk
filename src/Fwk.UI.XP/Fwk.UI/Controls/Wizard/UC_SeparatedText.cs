using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Fwk.Exceptions;
using Fwk.UI.Controls.ImportControls;
using Fwk.UI.Controls.ImportControls.Exceptions;


namespace Fwk.UI.Controls.Wizard
{

    [ToolboxItem(true)]
    public partial class UC_SeparatedText : UC_UserControlBase
    {
        public DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ErrorProvider
        {
            get { return dxErrorProvider1; }
        }

        public UC_SeparatedText()
        {
            InitializeComponent();
        }

        public DataTable GetDataTableFromCharSeparated()
        {
            CharSeparatedFileDescriptor wDescriptor;
            CharSeparatedFileParser wParser;
            DataTable wDataTable = null;
            Boolean wIsColumnNameVisible;

            try
            {
                ImageComboBoxItem wSelectedItem = (ImageComboBoxItem)cmbSeparationChar.SelectedItem;
                wIsColumnNameVisible = chkHasColumnsName.Checked;

                wDescriptor = CharSeparatedFileDescriptor.GetDescriptorFromFile(ctlFileSelection.GetSelectdFilePath(), wIsColumnNameVisible, ((char)(int)wSelectedItem.Value));
                wParser = new CharSeparatedFileParser();

                //wParser.ProgressChanged += new ProgressChangeHandler(parser_ProgressChanged);

                wDataTable = wParser.ParseFile(ctlFileSelection.GetSelectdFilePath(), wDescriptor);
            }

            catch (InvalidCharSeparatedFileException)
            {
                MessageViewer.Show("El caracter de separaci�n de columnas no corresponde al del archivo seleccionado");
                
                //TODO: ver que pasa con el Mensaje del ConfigurationManager
                //throw new FunctionalException(null, "ImportarSeparadorIncorrecto", "ImportFileExceptionMessage", new String[] { });
            }

            return wDataTable;
        }

        private void UC_SeparatedText_Validating(object sender, CancelEventArgs e)
        {
            if (!ctlFileSelection.Validate())
                e.Cancel = true;

            if (cmbSeparationChar.SelectedIndex < 0)
            {
                //dxErrorProvider1.SetError(cmbSeparationChar, ConfigurationManager.GetProperty("ImportFileExceptionMessage", "ImportarSeparadorIncorrecto"), DevExpress.XtraEditors.DXErrorProvider.ErrorType.Critical);
                dxErrorProvider1.SetError(cmbSeparationChar, "Valor Requerido");
                e.Cancel = true;
            }
            else
                dxErrorProvider1.SetError(cmbSeparationChar, String.Empty);
        }

    }
}
