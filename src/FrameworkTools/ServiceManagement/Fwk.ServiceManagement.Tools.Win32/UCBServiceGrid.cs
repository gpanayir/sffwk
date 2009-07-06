using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Fwk.HelperFunctions;
using Fwk.Bases;
namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="pServiceConfiguration"></param>
    public delegate void OnClickServiceHandler(ServiceConfiguration pServiceConfiguration);
    [DefaultEvent("OnClickServiceHandler")]
    public partial class UCBServiceGrid : UserControl
    {
        /// <summary>
        /// 
        /// </summary>
        public event OnClickServiceHandler OnClickServiceHandler;
        private ServiceConfigurationCollection _Services = null;
        private ServiceConfiguration _CurrentServiceConfiguration = null;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public ServiceConfiguration CurentServiceConfiguration
        {
            get { return _CurrentServiceConfiguration; }
            set { _CurrentServiceConfiguration = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public ServiceConfigurationCollection Services
        {

            get
            {
               
                return _Services;      
            }
            set
            {
                    _Services = value;
        

                   
                    serviceConfigurationCollectionBindingSource.DataSource = _Services;
                    SetSort();
                
            }
        }


        void SetSort()
        {
            DataGridViewColumn newColumn = grdServices.Columns[0];

            //serviceConfigurationCollectionBindingSource.SupportsSorting = true;
            //grdServices.Sort(newColumn, ListSortDirection.Ascending);

        }
        /// <summary>
        /// 
        /// </summary>
        public UCBServiceGrid()
        {
            InitializeComponent();
            InitializeFilterCombo();

            grdServices.Columns[0].Width = 250;
            grdServices.Columns[1].Width = 100;

        }

     



        private void grdServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _CurrentServiceConfiguration = grdServices.GetSelectedEntity<ServiceConfiguration>();

            if (OnClickServiceHandler != null)
                OnClickServiceHandler(_CurrentServiceConfiguration);

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceConfiguration"></param>
        internal void Update(ServiceConfiguration pServiceConfiguration)
        {
            
            if (_Services.Contains(_CurrentServiceConfiguration.Name))
            {
                _Services.Remove(_CurrentServiceConfiguration.Name);

                _CurrentServiceConfiguration = pServiceConfiguration;

                _Services.Add(_CurrentServiceConfiguration);

                //SetSort();

            }
            serviceConfigurationCollectionBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// 
        /// </summary>
        internal void RemoveCurrent()
        {
            _Services.Remove(_CurrentServiceConfiguration.Name);
            serviceConfigurationCollectionBindingSource.ResetBindings(true);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pServiceConfiguration"></param>
        internal void Add(ServiceConfiguration pServiceConfiguration)
        {


            if (_Services.Contains(pServiceConfiguration.Name))
            {
                throw new Fwk.Exceptions.TechnicalException(string.Concat("El servicio " + pServiceConfiguration.Name + " ya existe en la metadata"));
            }
            _CurrentServiceConfiguration = pServiceConfiguration;
            _Services.Add(_CurrentServiceConfiguration);
            serviceConfigurationCollectionBindingSource.ResetBindings(true);

        }


        #region Filters
        private void toolStripButtonFilter_Click(object sender, EventArgs e)
        {
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            Filter();
            this.Cursor = System.Windows.Forms.Cursors.Default;
        }

        private void InitializeFilterCombo()
        {





            String wTitle = String.Empty;
            cmbFilterTransactionalBehaviour.Items.Add("Any");
            foreach (string wName in Enum.GetNames(typeof(Fwk.Transaction.TransactionalBehaviour)))
            {
                cmbFilterTransactionalBehaviour.Items.Add(wName);
            }
            cmbFilterIsolationLevel.Items.Add("Any");
            foreach (string wName in Enum.GetNames(typeof(Fwk.Transaction.IsolationLevel)))
            {
                cmbFilterIsolationLevel.Items.Add(wName);
            }

          
            foreach (string wName in Enum.GetNames(typeof(Common.TipoBusquedaEnum)))
            {
                cmbSearchType.Items.Add(wName);
            }


            cmbSearchType.SelectedIndex = 0;
            cmbFilterTransactionalBehaviour.SelectedIndex = 0;
            cmbFilterIsolationLevel.SelectedIndex = 0;
        }

        private void txtXmlFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
                Filter();
                this.Cursor = System.Windows.Forms.Cursors.Default;
            }
        }

        private void Filter()
        {
            ServiceConfiguration wServiceConfiguration = new ServiceConfiguration();
            wServiceConfiguration.Name = txtXmlFilePath.Text;

            if (cmbFilterIsolationLevel.SelectedIndex != 0)
                wServiceConfiguration.IsolationLevel = (Fwk.Transaction.IsolationLevel)Enum.Parse(typeof(Fwk.Transaction.IsolationLevel), cmbFilterIsolationLevel.Text);
            if (cmbFilterTransactionalBehaviour.SelectedIndex != 0)
                wServiceConfiguration.TransactionalBehaviour = (Fwk.Transaction.TransactionalBehaviour)Enum.Parse(typeof(Fwk.Transaction.TransactionalBehaviour), cmbFilterTransactionalBehaviour.Text);


            if (_Services == null) return;
            bool wNotInclude_IsolationLevel = false;
            if (cmbFilterIsolationLevel.SelectedIndex == 0) wNotInclude_IsolationLevel = true;

            bool wNotInclude_TransactionalBehaviour = false;
            if (cmbFilterTransactionalBehaviour.SelectedIndex == 0) wNotInclude_TransactionalBehaviour = true;

            Common.TipoBusquedaEnum tb = (Common.TipoBusquedaEnum)Enum.Parse(typeof(Common.TipoBusquedaEnum), cmbSearchType.Text);

            IEnumerable<ServiceConfiguration> list = from s in _Services
                                                     where

                                                         (wNotInclude_TransactionalBehaviour || wServiceConfiguration.TransactionalBehaviour == s.TransactionalBehaviour)
                                                         &&
                                                         (wNotInclude_IsolationLevel || wServiceConfiguration.IsolationLevel == s.IsolationLevel)
                                                         &&
                                                         (
                                                         (s.Name.StartsWith(wServiceConfiguration.Name, StringComparison.OrdinalIgnoreCase) && Common.TipoBusquedaEnum.Start == tb)
                                                           ||
                                                           (s.Name.EndsWith(wServiceConfiguration.Name, StringComparison.OrdinalIgnoreCase) && Common.TipoBusquedaEnum.Finalize == tb)
                                                           ||
                                                           (s.Name.ToLower().Contains(wServiceConfiguration.Name.ToLower()) && Common.TipoBusquedaEnum.Contains == tb)
                                                           ||
                                                           (s.Name == wServiceConfiguration.Name && Common.TipoBusquedaEnum.Equal == tb)
                                                           ||
                                                           String.IsNullOrEmpty(wServiceConfiguration.Name))
                                                     select s;

            ServiceConfigurationCollection wServiceConfigurationCollection = new ServiceConfigurationCollection();

            foreach (ServiceConfiguration s in list)
            {
                wServiceConfigurationCollection.Add(s);
            }

            //grdServices.Populate<ServiceConfigurationCollection,ServiceConfiguration>( wServiceConfigurationCollection);
            serviceConfigurationCollectionBindingSource.DataSource = wServiceConfigurationCollection;
        }
        private void cmbSearchType_Click(object sender, EventArgs e)
        {
            Filter();
        }

   

     
        
        #endregion

        private void cmbFilterIsolationLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterIsolationLevel.SelectedIndex == 0)
                return;
        
            Filter();
        }

        private void cmbFilterTransactionalBehaviour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilterTransactionalBehaviour.SelectedIndex == 0)
                return;
            Filter();
        }

         




    }
}
