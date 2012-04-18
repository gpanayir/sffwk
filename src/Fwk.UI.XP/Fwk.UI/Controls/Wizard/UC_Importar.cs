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
using Fwk.UI;
using System.Timers;
using System.Diagnostics;
using Fwk.UI.Common;
using Fwk.UI.Controls.Wizard.BE;


namespace Fwk.UI.Controls.Wizard
{
    [ToolboxItem(true)]
    public partial class UC_Importar : UC_UserControlBase
    {
        #region Eventos y delegados
        // Declare the delegate (if using non-generic pattern).
        public delegate void ImportEventHandler(object sender, Fwk.UI.Controls.Wizard.FRM_Wizard.ImportEventArgs e);

        // Declare the event.
        public event ImportEventHandler PreImportComplete;

        #endregion

        #region Members

        private ColumnsMappingBEList _DataTableMapper;
        private DataOriginTypeEnum _MappingType = DataOriginTypeEnum.None;        
        private DataTable _DataToImport;
        private String _ServerName;
        private String _DataBaseName;

        #endregion

        #region Properties

        /// <summary>
        /// Nombre de la Base de Datos de la que se desea obtener los datos a importar.(Solo para tipo DB)
        /// </summary>
        /// <remarks>Solo para tipo de importación DB</remarks>
		public String DataBaseName
		{
			get
			{
				return _DataBaseName;
			}
			set
			{
				_DataBaseName = value;
			}
		}
        /// <summary>
        /// Nombre del servidor del que se desean obtener los datos a importar.
        /// </summary>
        /// /// <remarks>Solo para tipo de importación DB</remarks>
		public String ServerName
		{
			get
			{
				return _ServerName;
			}
			set
			{
				_ServerName = value;
			}
		}        
        /// <summary>
        /// Tabla con los datos obtenidos de un archivo que se desean importar
        /// </summary>
		public DataTable DataToImport
		{
			get
			{
				return _DataToImport;
			}
			set
			{
				_DataToImport = value;
			}
		}
        /// <summary>
        /// DataTable  cuyas filas son el mapeo de las columnas
        /// </summary>
        public ColumnsMappingBEList DataTableMapper
        {
            get
            {
                return _DataTableMapper;
            }
            set
            {
                _DataTableMapper = value;
            }
        }
        /// <summary>
        /// Tipo origen de datos del que se desea importar.
        /// </summary>
        public DataOriginTypeEnum MappingType
        {
            get
            {
                return _MappingType;
            }
            set
            {
                _MappingType = value;
            }
        }

        #endregion

        #region Constructor

        public UC_Importar()
        {
            InitializeComponent();
        }

        #endregion

        // Hace visible o invisible los controles
        private void VisibleControl(Boolean pVisible)
        {
            lblAguarde.Visible = pVisible;
            picLoading.Visible = pVisible;
        }

        private void UC_Importar_Load(object sender, EventArgs e)
        {
            VisibleControl(false);
            
            //if (_Controller == null)
            //    _Controller = new WizzardController();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            if (this._MappingType != DataOriginTypeEnum.DataBase)
            {
                // se cambia el nombre de las columnas
                DataTableMapper.ForEach(p => DataToImport.Columns[p.ColumnSource].ColumnName = p.ColumnTarget);

                // se quitan las columnas que no se mapearon
                DataView dv = new DataView(DataToImport);
                List<String> wColumns = new List<string>();
                // se obtienen los nombres de las nuevas columnas 
                wColumns.AddRange(from p in DataTableMapper select p.ColumnTarget);
                // se crea un nuevo datatable
                DataTable dt = dv.ToTable(false, wColumns.ToArray<String>());

                // se lanza el evento de importacion completa
                PreImportComplete(new object(), new Fwk.UI.Controls.Wizard.FRM_Wizard.ImportEventArgs(dt, DataTableMapper));
            }
            else
            {
                // se lanza el evento de importacion completa
                PreImportComplete(new object(), new Fwk.UI.Controls.Wizard.FRM_Wizard.ImportEventArgs(DataToImport, DataTableMapper));
            }

            

        }

        /// <summary>
        /// true = Start
        /// false = stop
        /// </summary>
        /// <param name="pAction"></param>
        public void ProgressAction(Boolean pAction)
        {        
            //true = Start
            // false = stop
            VisibleControl(pAction);
        }
               
    }
}