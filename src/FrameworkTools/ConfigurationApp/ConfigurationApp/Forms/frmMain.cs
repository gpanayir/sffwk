using System;
using System.Windows.Forms;
using ConfigurationApp.Common;
using ConfigurationApp.Forms;
using ConfigurationApp.IsolatedStorage;

namespace ConfigurationApp
{
    public partial class frmMain : Form
    {


        public frmMain()
        {
            InitializeComponent();

            InitializeDocPanels();
            RefreshAllFiles(false);

        }


        #region Events --> MainMenuStrip


        /// <summary>
        /// Guarda un archivo cualquiera dependiendo de donde esta el selected node apuntando
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemSave_Click(object sender, EventArgs e)
        {
            SaveFile();
        }

        /// <summary>
        /// Guarda todos los archivos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemSaveAllFiles_Click(object sender, EventArgs e)
        {
            SaveAllFiles();
        }

        /// <summary>
        /// Vuelve a cargar todos los archivos tanto de treeview como App client config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsMenuItemRefreshAllFiles_Click(object sender, EventArgs e)
        {
            RefreshAllFiles(true);
        }

   

        #region ConfigManagerControl


        /// <summary>
        /// Carga un archivo Config Mannager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dockPanelConfigManager.LoadFile();
        }

        /// <summary>
        /// Crea un nuevo archivo en el treeview de ConfigurationMannager
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _dockPanelConfigManager.NewFile();
        }
        #endregion

        #endregion



        #region Events --> toolStripAppClientConfig

        private void tsButtonSaveAll_Click(object sender, EventArgs e)
        {
            SaveAllFiles();
        }




        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            LoadFile();
        }


        private void quitToolStripButton_Click(object sender, EventArgs e)
        {
            QuitFile();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFile();
        }



        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewFile();
        }



        private void tsButtonRefreshAll_Click(object sender, EventArgs e)
        {
            _dockPanelConfigManager.SaveIsolatedStorage();

            RefreshAllFiles(true);
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

      





    }
}