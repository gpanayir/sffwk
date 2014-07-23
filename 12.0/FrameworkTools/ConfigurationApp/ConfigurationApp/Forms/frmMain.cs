using System;
using System.Windows.Forms;
using ConfigurationApp.Common;
using ConfigurationApp.Forms;
using ConfigurationApp.IsolatedStorage;
using Fwk.ConfigSection;
using System.Reflection;


namespace ConfigurationApp
{
    public partial class frmMain : Form
    {

        #region [Private members]
        private WorkSpace _WorkSpace = new WorkSpace();

        private ConfigurationApp.Forms.dockPanelConfigManager _dockPanelConfigManager = null;
        private Storage _Storage = null;
        private SelectedRoot m_SelectedRoot = SelectedRoot.None;
        #endregion

        public frmMain()
        {
            InitializeComponent();

            InitializeDocPanels();
            this.Text = string.Concat(this.Text, " version ", Assembly.GetExecutingAssembly().GetName().Version.ToString());
            //if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
                _dockPanelConfigManager.LoadFiles();
        }


        #region Events --> MainMenuStrip



        /// <summary>
        /// Vuelve a cargar todos los archivos tanto de treeview como App client config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemRefreshAllFiles_Click(object sender, EventArgs e)
        {
            RefreshAllFiles();
        }

   

        

        #endregion



        #region Events --> toolStripAppClientConfig



        private void tsButtonRefreshAll_Click(object sender, EventArgs e)
        {
            _dockPanelConfigManager.SaveIsolatedStorage();

            RefreshAllFiles();
        }
        #endregion

        private void tsButtonConfigManagerShow_Click(object sender, EventArgs e)
        {
            if (!_WorkSpace.Contains(ConfigurationType.ConfigurationManager))
            {
                _dockPanelConfigManager = new dockPanelConfigManager();

                _dockPanelConfigManager.Storage = _Storage;
              
                _dockPanelConfigManager.Panel = this.splitContainer1.Panel2.Controls;
                
          
                _dockPanelConfigManager.Enter += new EventHandler(_dockPanelConfigManager_Enter);
                _dockPanelConfigManager.FormClosing += new FormClosingEventHandler(_dockPanelConfigManager_FormClosing);

                _dockPanelConfigManager.Show(dockPanel1, Fwk.Controls.Win32.DockState.DockLeft);

                _WorkSpace.Add(_dockPanelConfigManager, ConfigurationType.ConfigurationManager); 
            }
        }

        void _dockPanelConfigManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            _WorkSpace.Remove(ConfigurationType.ConfigurationManager); 
        }
        void _dockPanelAppConfigClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            _WorkSpace.Remove(ConfigurationType.ApplicationConfiuration);
        }
        



        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            

            _dockPanelConfigManager.SaveIsolatedStorage();

        }

        private void btnNewProvider_Click(object sender, EventArgs e)
        {
            using (frmCreateProvider frm = new frmCreateProvider())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {


                    RefreshAllFiles();

                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            using (frmExport1 frm = new frmExport1())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {

                    RefreshAllFiles();
                }
            }

            
        }

     






        private void InitializeDocPanels()
        {
            _Storage = new Storage();

            _dockPanelConfigManager = new dockPanelConfigManager();
            _dockPanelConfigManager.Storage = _Storage;

            if (!_WorkSpace.Contains(ConfigurationType.ConfigurationManager))
            {
                _dockPanelConfigManager = new dockPanelConfigManager();

                _dockPanelConfigManager.Storage = _Storage;

                _dockPanelConfigManager.Panel = this.splitContainer1.Panel2.Controls;


                _dockPanelConfigManager.Enter += new EventHandler(_dockPanelConfigManager_Enter);
                _dockPanelConfigManager.FormClosing += new FormClosingEventHandler(_dockPanelConfigManager_FormClosing);

                _dockPanelConfigManager.Show(dockPanel1, Fwk.Controls.Win32.DockState.DockLeft);

                _WorkSpace.Add(_dockPanelConfigManager, ConfigurationType.ConfigurationManager);
            }


        }

        #region File methods
        //private void SaveAllFiles()
        //{

        //    _dockPanelConfigManager.SaveAllFiles();
        //}
        //private void LoadFile()
        //{


        //    if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
        //        _dockPanelConfigManager.LoadFile();
        //}
        //private void SaveFile()
        //{


        //    if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
        //        _dockPanelConfigManager.SaveFile();
        //}

        void _dockPanelConfigManager_Enter(object sender, EventArgs e)
        {
            m_SelectedRoot = SelectedRoot.ConfigManagerRoot;
        }

        void _dockPanelAppConfigClient_Enter(object sender, EventArgs e)
        {
            m_SelectedRoot = SelectedRoot.AppConfigRoot;
        }

        private void RefreshAllFiles()
        {



            if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
                _dockPanelConfigManager.RefreshAllFiles();
        }
        #endregion



    }
}