using System;
using System.Windows.Forms;
using ConfigurationApp.Common;
using ConfigurationApp.Forms;
using ConfigurationApp.IsolatedStorage;
using Fwk.ConfigSection;

namespace ConfigurationApp
{
    public partial class frmMain : Fwk.Bases.FrontEnd.FrmBase
    {


        public frmMain()
        {
            InitializeComponent();

            InitializeDocPanels();

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
            if (!_WorkSpace.Contains(ConfigurationType.ConfigurationMannager))
            {
                _dockPanelConfigManager = new dockPanelConfigManager();

                _dockPanelConfigManager.Storage = _Storage;
              
                _dockPanelConfigManager.Panel = this.splitContainer1.Panel2.Controls;
                
          
                _dockPanelConfigManager.Enter += new EventHandler(_dockPanelConfigManager_Enter);
                _dockPanelConfigManager.FormClosing += new FormClosingEventHandler(_dockPanelConfigManager_FormClosing);

                _dockPanelConfigManager.Show(dockPanel1, Fwk.Controls.Win32.DockState.DockLeft);

                _WorkSpace.Add(_dockPanelConfigManager, ConfigurationType.ConfigurationMannager); 
            }
        }

        void _dockPanelConfigManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            _WorkSpace.Remove(ConfigurationType.ConfigurationMannager); 
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

        private void btnQuitProvider_Click(object sender, EventArgs e)
        {
            
        }

      
      





    }
}