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
using Fwk.UI.Common;
using Fwk.UI.Controls.Wizard.BE;


namespace Fwk.UI.Controls.Wizard
{
    [ToolboxItem(true)]
    public partial class UC_MapeoColumnas : UC_UserControlBase
    {
        #region Members

        private List<String> _ColumnsTarget;
        private DataOriginTypeEnum _MappingType = DataOriginTypeEnum.None;
        private List<String> _ColumnsSource;
        private ColumnsMappingBEList _DataTableMapped;
        private DataTable _DataToImport;

        #endregion

        #region Properties

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

        public List<String> ColumnsSource
		{
			get
			{
                return _ColumnsSource;
			}
			set
			{
                _ColumnsSource = value;
			}
		}

        public List<String> ColumnsTarget
		{
			get
			{
                return _ColumnsTarget;
			}
			set
			{
                _ColumnsTarget = value;
			}
		}
        
        public ColumnsMappingBEList DataTableMapped
		{
			get
			{
                return (ColumnsMappingBEList)columnsMappingBEBindingSource.DataSource;
			}			
		}

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

        public UC_MapeoColumnas()
        {
            InitializeComponent();
        }

        #endregion

        public void Populate(List<String> pColumnsSource, ColumnsMappingBEList pColumnsTarget)
        {
            // Nombre de los campos a mapear
            repDestino.DataSource = pColumnsSource;
            
            // Filas de la grilla
            columnsMappingBEBindingSource.DataSource = pColumnsTarget;
            gridControl1.RefreshDataSource();
        }

    }
}
