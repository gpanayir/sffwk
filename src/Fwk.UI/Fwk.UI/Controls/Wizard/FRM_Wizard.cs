using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.UI.Forms;
using Fwk.UI.Controls.Wizard.BE;


namespace Fwk.UI.Controls.Wizard
{

    public partial class FRM_Wizard : FormBase
    {
        #region Eventos y delegados
        // Declare the delegate (if using non-generic pattern).
        public delegate void FRM_WizardEventHandler(object sender, Fwk.UI.Controls.Wizard.FRM_Wizard.ImportEventArgs e);

        // Declare the event.
        public event FRM_WizardEventHandler WizardComplete;

        #endregion

        #region Private Members

        private ColumnsMappingBEList _ColumnsToMap;
        
        #endregion

        #region Properties

        [Description("Nombre de las que se deben mapear")]
        public ColumnsMappingBEList ColumnsToMap
        {
            get
            {
                return _ColumnsToMap;
            }
            set
            {
                _ColumnsToMap = value;
            }
        }

        #endregion

        public FRM_Wizard()
        {
            InitializeComponent();
        }

        public void Populate()
        {
            uC_WizzardMain1.ColumnsToMap = _ColumnsToMap;
        }

        public void Populate(ColumnsMappingBEList pColumnsToMap)
        {
            _ColumnsToMap = pColumnsToMap;
            uC_WizzardMain1.ColumnsToMap = pColumnsToMap;
            uC_WizzardMain1.ImportComplete += new UC_WizzardMain.ImportEventHandler(uC_WizzardMain1_ImportComplete);
            uC_WizzardMain1.CancelImport += new EventHandler(uC_WizzardMain1_CancelImport);
        }

        void uC_WizzardMain1_CancelImport(object sender, EventArgs e)
        {
            this.Close();
        }

        void uC_WizzardMain1_ImportComplete(object sender, FRM_Wizard.ImportEventArgs e)
        {
            if (WizardComplete != null)
                WizardComplete(sender, e);
        }             

        public class ImportEventArgs : EventArgs
        {
            public ImportEventArgs(DataTable pDataToImport, ColumnsMappingBEList pColumnsMapping)
            {
                _DataToImport = pDataToImport;
                _ColumnsMapping = pColumnsMapping;
            }

            private DataTable _DataToImport;
            private ColumnsMappingBEList _ColumnsMapping;

            /// <summary>
            /// Columnas mapeadas por el usuario
            /// </summary>
            public ColumnsMappingBEList ColumnsMapping
            {
                get
                {
                    return _ColumnsMapping;
                }
                set
                {
                    _ColumnsMapping = value;
                }
            }

            /// <summary>
            /// DataTable con los datos a importar
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

        }

    }
}
