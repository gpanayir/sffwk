using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Fwk.UI.Controls.Wizard.BE;

namespace Fwk.UI.Controls.Wizard
{
    public partial class ImportDataFromDataOrigin : Component
    {
        #region Eventos y delegados
        // Declare the delegate (if using non-generic pattern).
        public delegate void ImportDataFromDataOriginEventHandler(object sender, Fwk.UI.Controls.Wizard.FRM_Wizard.ImportEventArgs e);

        // Declare the event.
        public event ImportDataFromDataOriginEventHandler WizardComplete;

        #endregion

        #region Private Members

        private FRM_Wizard _FormWizard;
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

        #region [Constructor]

        public ImportDataFromDataOrigin()
        {
            InitializeComponent();
        }

        public ImportDataFromDataOrigin(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #endregion

        /// <summary>
        /// Inicia el Wizar del importador de registros desde un origen de datos
        /// </summary>
        public void Show()
        {            
            _FormWizard = new FRM_Wizard();
            
            
            _FormWizard.Populate(_ColumnsToMap);
            _FormWizard.WizardComplete += new FRM_Wizard.FRM_WizardEventHandler(_FormWizard_WizardComplete);
            _FormWizard.Show();
        }

        void _FormWizard_WizardComplete(object sender, FRM_Wizard.ImportEventArgs e)
        {
            if(WizardComplete != null)
                WizardComplete(sender, e);
        }


        public void Close()
        {
            _FormWizard.Close();
        }
    }
}