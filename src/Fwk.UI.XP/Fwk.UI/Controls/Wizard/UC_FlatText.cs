using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls;
using Fwk.UI;
using Fwk.UI.Common;

using Fwk.HelperFunctions;
using Fwk.UI.Controls.ImportControls;

namespace Fwk.UI.Controls.Wizard
{
    [ToolboxItem(true)]
    public partial class UC_FlatText : UC_UserControlBase
    {
        #region Members

        private TXTFileDescriptor _TxtFileDescriptor;
        private const int _FilasAMostrar = 10;
        private List<String> _ColumnsSelected;

        #endregion

        #region Properties

        public DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider ErrorProvider
        {
            get { return dxErrorProvider1; }
        }

        public List<String> ColumnsSelected
        {
            get
            {
                GetColumnsSelected();
                return _ColumnsSelected;
            }
        }

        #endregion

        #region Constructor

        public UC_FlatText()
        {
            InitializeComponent();
        }

        #endregion

        private void GetColumnsSelected()
        {
            _ColumnsSelected = new List<string>();
            _TxtFileDescriptor.Columns.ForEach(p => _ColumnsSelected.Add(p.Name));
        }

        public DataTable GetDataTableFromTxt()
        {
            DataTable wDataTable = null;
            TXTFileParser wParser = new TXTFileParser();
            try
            {
                    wDataTable = wParser.ParseFile(cmbFileSelection.GetSelectdFilePath(), _TxtFileDescriptor);
            }
            catch (Exception ex)
            {
                SimpleMessageView.Show(ex, "Importador de Datos", MessageBoxButtons.OK, Fwk.UI.Common.MessageBoxIcon.Error);
            }

            return wDataTable;
        }


        private void UC_FlatText_Load(object sender, EventArgs e)
        {
            _TxtFileDescriptor = new TXTFileDescriptor();
            txtColumnsEditor1.LoadColumns(_TxtFileDescriptor.Columns);
        }

        private void UC_FlatText_Validating(object sender, CancelEventArgs e)
        {
            if (!cmbFileSelection.Validate())
                e.Cancel = true;

            if (!txtColumnsEditor1.Validate())
            {
                dxErrorProvider1.SetError(cmbFileSelection, "Se debe agregar al menos una columna a la grilla");
                e.Cancel = true;
            }
            else
                dxErrorProvider1.SetError(cmbFileSelection, string.Empty);
        }

    }
}
