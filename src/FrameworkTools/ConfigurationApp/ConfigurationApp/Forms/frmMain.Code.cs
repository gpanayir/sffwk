
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
        private ConfigurationApp.Forms.dockPanelAppConfigClient _dockPanelAppConfigClient = null;
        private ConfigurationApp.Forms.dockPanelConfigManager _dockPanelConfigManager = null;
        private Storage _Storage = null;
        private SelectedRoot m_SelectedRoot = SelectedRoot.None;
        #endregion


   

           
      


        private void DetermineLabels(object sender)
        {
            //DetermineRoot();
            if (m_SelectedRoot == SelectedRoot.AppConfigRoot)
            {

                lblGroup.Text = "Aplication:";
                lblKey.Text = "Setting:";
                lblFileName.Text = _dockPanelAppConfigClient._FileName;
                lblKeyName.Text = _dockPanelAppConfigClient._KeyName;
                lblGroupName.Text = _dockPanelAppConfigClient._GroupName;
            }
            else
            {
                lblGroup.Text = "Group:";
                lblKey.Text = "Key:";
                lblFileName.Text = _dockPanelConfigManager._FileName;
                lblKeyName.Text = _dockPanelConfigManager._KeyName;
                lblGroupName.Text = _dockPanelConfigManager._GroupName;
            }
        }

        void _dockPanelConfigManager_DoActionEvent(object sender)
        {
            DetermineLabels(sender);
        }

        void _dockPanelAppConfigClient_DoActionEvent(object sender)
        {
            DetermineLabels(sender);
        }

        

        private void InitializeDocPanels()
        {
            _Storage = new Storage();

            _dockPanelAppConfigClient = new dockPanelAppConfigClient();
            _dockPanelAppConfigClient.Storage = _Storage;
            _dockPanelAppConfigClient.Property = propertyGrid1;
            _dockPanelConfigManager = new dockPanelConfigManager();
            _dockPanelConfigManager.Storage = _Storage;
            _dockPanelConfigManager.Property = propertyGrid1;

       
        }

        #region File methods
        private void SaveAllFiles()
        {
            _dockPanelAppConfigClient.SaveAllFile();
            _dockPanelConfigManager.SaveAllFiles();
        }
        private void LoadFile()
        {
            if (m_SelectedRoot == SelectedRoot.AppConfigRoot)
                _dockPanelAppConfigClient.LoadFile();

            if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
                _dockPanelConfigManager.LoadFile();
        }
        private void SaveFile()
        {
            if (m_SelectedRoot == SelectedRoot.AppConfigRoot)
                _dockPanelAppConfigClient.SaveFile();

            if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
                _dockPanelConfigManager.SaveFile();
        }

        void _dockPanelConfigManager_Enter(object sender, EventArgs e)
        {
            m_SelectedRoot = SelectedRoot.ConfigManagerRoot;
        }

        void _dockPanelAppConfigClient_Enter(object sender, EventArgs e)
        {
            m_SelectedRoot = SelectedRoot.AppConfigRoot;
        }
        void NewFile()
        {
           

            if (m_SelectedRoot == SelectedRoot.AppConfigRoot)
                _dockPanelAppConfigClient.NewFile();

            if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
                _dockPanelConfigManager.NewFile();
        }
        void QuitFile()
        {
            

            if (m_SelectedRoot == SelectedRoot.AppConfigRoot)
                _dockPanelAppConfigClient.QuitFile();

            if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
                _dockPanelConfigManager.QuitFile();
        }
        private void RefreshAllFiles(bool pClear)
        {

            if (m_SelectedRoot == SelectedRoot.AppConfigRoot)
                _dockPanelAppConfigClient.RefreshAllFiles(pClear);

            if (m_SelectedRoot == SelectedRoot.ConfigManagerRoot)
                _dockPanelConfigManager.RefreshAllFiles(pClear);
        }
        #endregion
    }
}
