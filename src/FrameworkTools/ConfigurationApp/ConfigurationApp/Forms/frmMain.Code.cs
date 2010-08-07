
using System;
using System.Windows.Forms;
using System.Xml;
using ConfigurationApp.Common;
using ConfigurationApp.Forms;
using ConfigurationApp.IsolatedStorage;

namespace ConfigurationApp
{
    partial class frmMain
    {
        #region [Private members]
        private WorkSpace _WorkSpace = new WorkSpace();
        
        private ConfigurationApp.Forms.dockPanelConfigManager _dockPanelConfigManager = null;
        private Storage _Storage = null;
        private SelectedRoot m_SelectedRoot = SelectedRoot.None;
        #endregion


   

           
      



        

        private void InitializeDocPanels()
        {
            _Storage = new Storage();
           
            _dockPanelConfigManager = new dockPanelConfigManager();
            _dockPanelConfigManager.Storage = _Storage;

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
        //void NewFile()
        //{
           

         

        //    if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
        //        _dockPanelConfigManager.NewFile();
        //}
        //void QuitFile()
        //{
            

      

        //    if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
        //        _dockPanelConfigManager.QuitFile();
        //}
        private void RefreshAllFiles()
        {

          

            if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
                _dockPanelConfigManager.RefreshAllFiles();
        }
        #endregion
    }
}
