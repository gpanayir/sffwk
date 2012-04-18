using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Fwk.HelperFunctions;

namespace Fwk.UI.Controls.Wizard
{
    [ToolboxItem(true)]
    public partial class UC_ExcelWorkSheets : UC_UserControlBase
    {
        #region Members

        private String _SelectedFilePath;
 
        #endregion

        #region Properties

        public String SelectedFilePath
        {
            get { return _SelectedFilePath; }
            set { _SelectedFilePath = value; }
        }

        public String SelectedWorkSheet
        {
            get
            {
                if (cmbWorkSheet.EditValue != null)
                    return cmbWorkSheet.EditValue.ToString();
                else
                    return null;
            }
        }

        #endregion

        #region Constructor

        public UC_ExcelWorkSheets()
        {
            InitializeComponent();
        }

        #endregion

        private void UC_ExcelWorkSheets_Load(object sender, EventArgs e)
        {
            ctlFileSelection.FileDialogFilter = "Archivo de planilla de c�lculo (*.xls, *.xlsx) | *.xls; *.xlsx";
            ctlFileSelection.ClearFileName();
        }

        private void ctlFileSelection_OnSelectedOk(object sender, EventArgs e)
        {
            _SelectedFilePath = ctlFileSelection.GetSelectdFilePath();
            Fwk.HelperFunctions.WorkSheets wWorkSheets = ImportFunctions.SearchWorkSheets(_SelectedFilePath);
            workSheetsBindingSource.DataSource = wWorkSheets;

            cmbWorkSheet.ItemIndex = 0;
        }

        private void UC_ExcelWorkSheets_Validating(object sender, CancelEventArgs e)
        {
            if (!ctlFileSelection.Validate())
                e.Cancel = true;

            if (cmbWorkSheet.EditValue == null)
            {
                dxErrorProvider1.SetError(cmbWorkSheet, "ValorRequerido");
                e.Cancel = true;
            }
            else
                dxErrorProvider1.SetError(cmbWorkSheet, string.Empty);
        }

    }
}
