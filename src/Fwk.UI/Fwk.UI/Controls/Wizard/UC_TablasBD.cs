using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Controls;
using Microsoft.SqlServer.Management.Smo;
using Fwk.UI.Controls.Wizard.BE;


namespace Fwk.UI.Controls.Wizard
{
    [ToolboxItem(true)]
    public partial class UC_TablasBD : UC_UserControlBase
    {
        #region Members

        String _NameServer = String.Empty;
        Server _Server;
        Database _DataBase;
        List<String> _Tables;
        private Object _Urn;
        private Table _TableSelected;
        private List<String> _ColumnsSelected;
        private ColumnsMappingBEList _ColumnasAMapear;


		public ColumnsMappingBEList ColumnasAMapear
		{
			get
			{
				return _ColumnasAMapear;
			}
			set
			{
				_ColumnasAMapear = value;
			}
		}

        #endregion

        #region Properties

        public List<String> ColumnsSelected
        {
            get
            {
                GetColumnsSelected();
                return _ColumnsSelected;
            }
        }
        public Table TableSelected
        {
            get
            {
                return _TableSelected;
            }
            set
            {
                _TableSelected = value;
            }
        }
        public Object Urn
        {
            get
            {
                return _TableSelected.Urn;
            }
        }
        public Database DataBaseSelected
        {
            get { return _DataBase; }
            set { _DataBase = value; }
        }
        public String NameServer
        {
            get { return _NameServer; }
            set { _NameServer = value; }
        }
        public Server ServerSelected
        {
            get { return _Server; }
            set { _Server = value; }
        }

        #endregion

        #region Constructor

        public UC_TablasBD()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public void Populate(Database pDataBase, Server pServer)
        {
            if (pServer == null)
                return;

            if (pDataBase == null)
                return;

            _Server = pServer;
            _DataBase = pDataBase;

            ObtenerTablas();
        }

        private void GetColumnsSelected()
        {
            _ColumnsSelected = new List<string>();

            foreach (var item in chklistColumnas.CheckedItems)
            {
                if (item != null)
                    _ColumnsSelected.Add(item.ToString());
            }
        }

        private void ObtenerColumnasTabla(Int32 pTablaId)
        {
            Table wTable = new Table();

            wTable = _DataBase.Tables.ItemById(pTablaId);

            chklistColumnas.Items.Clear();

            foreach (Column item in wTable.Columns)
            {
                chklistColumnas.Items.Add(item);
            }
        }

        // Se cargan las databases
        private void ObtenerTablas()
        {
            lstTablas.Items.Clear();

            // Se cargan las databases en el listbox2
            foreach (Table item in _DataBase.Tables)
            {
                lstTablas.Items.Add(item, 0);
            }
        }

        internal DataTable GetDataTable()
        {
            DataSet wResult = new DataSet();
            StringBuilder wBuilder = new StringBuilder();

            //String.Join(",", _ColumnsSelected.ToArray<String>());
            wBuilder.Append("SELECT TOP 5 ");
            wBuilder.AppendFormat(" {0} ", String.Join(",", _ColumnsSelected.ToArray<String>()));
            wBuilder.AppendFormat(" FROM {0} ", _TableSelected.ToString());

            String wColumns = wBuilder.ToString();
            wColumns = wColumns.Replace("[", "");
            wColumns = wColumns.Replace("]", "");

            wResult = _DataBase.ExecuteWithResults(wColumns);

            return wResult.Tables[0];
        }

        internal DataTable GetFullDataTable()
        {
            DataSet wResult = new DataSet();
            StringBuilder wBuilder = new StringBuilder();

            String wCol = String.Empty;
            ColumnasAMapear.ForEach(p => wCol += p.ColumnSource + " as " + p.ColumnTarget + ",");
            wCol = wCol.Remove(wCol.Length - 1);
            
            wBuilder.Append("SELECT");
            wBuilder.AppendFormat(" {0} ", wCol);   //String.Join(",", _ColumnsSelected.ToArray<String>()));
            wBuilder.AppendFormat(" FROM {0} ", _TableSelected.ToString());

            String wColumns = wBuilder.ToString();
            wColumns = wColumns.Replace("[", "");
            wColumns = wColumns.Replace("]", "");

            wResult = _DataBase.ExecuteWithResults(wColumns);

            return wResult.Tables[0];        
        }

        #endregion

        #region Events

        private void lstTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTablas.SelectedItem != null)
            {
                _TableSelected = ((Table)lstTablas.SelectedValue);
                ObtenerColumnasTabla(((Table)lstTablas.SelectedValue).ID);
            }
        }

        private void chklistColumnas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetColumnsSelected();
        }

        private void UC_TablasBD_Validating(object sender, CancelEventArgs e)
        {
            if (chklistColumnas.CheckedItems.Count == 0)
            {
                dxErrorProvider1.SetError(chklistColumnas, "Debe seleccionar al menos una columna");
                e.Cancel = true;
            }
            else
                dxErrorProvider1.SetError(chklistColumnas, string.Empty);
        }

        #endregion
    }
}
