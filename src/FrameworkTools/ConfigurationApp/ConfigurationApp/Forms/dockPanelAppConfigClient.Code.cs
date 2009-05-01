using System;
using System.Windows.Forms;
using ConfigurationApp.Common;
using ConfigurationApp.IsolatedStorage;
using ConfigurationApp.AppConfig;

namespace ConfigurationApp.Forms
{
    public delegate void DoActionEventHandler(Object sender);

    partial class dockPanelAppConfigClient
    {

        private event DoActionEventHandler _DoActionEvent;
        private Boolean PropertyGrid_PropertyValueChangedDataBase_Activated = false;
        private Boolean PropertyGrid_PropertyValueChangedSetting_Activated = false;
        
        private void OnDoActionEvent(Object sender)
        {
            if (_DoActionEvent != null)
                _DoActionEvent(sender);
        }

        public event DoActionEventHandler DoActionEvent
        {
            add
            {
                _DoActionEvent = (DoActionEventHandler)Delegate.Combine(_DoActionEvent, value);

            }
            remove
            {
                _DoActionEvent = (DoActionEventHandler)Delegate.Remove(_DoActionEvent, value);
            }
        }

        #region [Attributtes]
        
        private ConfigurationApp.Common.AppConfigSelectedNodeType _AppConfigSelectedNodeType = ConfigurationApp.Common.AppConfigSelectedNodeType.Root;
        private Storage _Storage = null;
        private PropertyGrid _PropertyGrid = null;
        public  String _FileName = String.Empty;
        public String _GroupName = String.Empty;
        public String _KeyName = String.Empty;

        public PropertyGrid Property
        {
            get { return _PropertyGrid; }
            set { _PropertyGrid = value; }

        }
        public TreeNode SelectedNode
        {
            get { return treeView1.SelectedNode; }
        }

        internal Storage Storage
        {
            get { return _Storage; }
            set { _Storage = value; }
        }
        #endregion

        #region Private Methods

        private void DoAppConfig(TreeViewEventArgs pTreeNodeSelected)
        {
            DetermineHandles();

           switch (_AppConfigSelectedNodeType)
            {
                case ConfigurationApp.Common.AppConfigSelectedNodeType.CnnString:
                    {
                        _PropertyGrid.SelectedObject = treeView1.SelectedNode.Tag;
                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.CnnStrings:
                    {
                        _PropertyGrid.SelectedObject = String.Empty;
                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.Setting:
                    {
                        _PropertyGrid.SelectedObject = pTreeNodeSelected.Node.Tag;


                        _FileName = pTreeNodeSelected.Node.Parent.Parent.Parent.Text;
                        _GroupName = pTreeNodeSelected.Node.Parent.Text;
                        _KeyName = pTreeNodeSelected.Node.Text;

                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.Application:
                    {
                        _PropertyGrid.SelectedObject = String.Empty;

                        _FileName = pTreeNodeSelected.Node.Parent.Parent.Text;
                        _GroupName = pTreeNodeSelected.Node.Text;
                        _KeyName = String.Empty;


                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.ApplicationSettings:
                case ConfigurationApp.Common.AppConfigSelectedNodeType.SectionGroup:
                    {
                        _PropertyGrid.SelectedObject = String.Empty;

                        _FileName = pTreeNodeSelected.Node.Parent.Text;
                        _GroupName = String.Empty;
                        _KeyName = String.Empty;

                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.File:
                    {
                        _PropertyGrid.SelectedObject = String.Empty;

                        _FileName = pTreeNodeSelected.Node.Text;
                        _GroupName = String.Empty;
                        _KeyName = String.Empty;

                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.Root:
                    {
                        _PropertyGrid.SelectedObject = String.Empty;
                        _FileName = String.Empty;
                        _GroupName = String.Empty;
                        _KeyName = String.Empty;



                        break;
                    }
            }
            OnDoActionEvent(this);
        }

        /// <summary>
        /// Determina que metodo del Handler PropertyValueChangedEventHandler esta activo para 
        /// manipular los cambios en las propiedades de cnnstring o settings
        /// </summary>
        void DetermineHandles()
        {

            switch (_AppConfigSelectedNodeType)
            {
                case ConfigurationApp.Common.AppConfigSelectedNodeType.CnnString:
                    {
                        if (PropertyGrid_PropertyValueChangedDataBase_Activated == false)
                        {
                            _PropertyGrid.PropertyValueChanged +=
                                new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChangedDataBase);
                            PropertyGrid_PropertyValueChangedDataBase_Activated = true;
                        }

                        if (PropertyGrid_PropertyValueChangedSetting_Activated)
                        {
                            _PropertyGrid.PropertyValueChanged -=
                                new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChangedSetting);

                            PropertyGrid_PropertyValueChangedSetting_Activated = false;
                        }

                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.Setting:
                    {
                        if (PropertyGrid_PropertyValueChangedSetting_Activated == false)
                        {
                            _PropertyGrid.PropertyValueChanged +=
                                new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChangedSetting);
                            PropertyGrid_PropertyValueChangedSetting_Activated = true;
                        }

                        if (PropertyGrid_PropertyValueChangedDataBase_Activated)
                        {
                            _PropertyGrid.PropertyValueChanged -=
                                new PropertyValueChangedEventHandler(PropertyGrid_PropertyValueChangedDataBase);
                            PropertyGrid_PropertyValueChangedDataBase_Activated = false;
                        }


                        break;
                    }
            }
        }

        /// <summary>
        /// Determina el valor de _AppConfigSelectedNodeType
        /// tambien determina la habilitaceion de los handlers de la properti
        /// </summary>
        /// <param name="node"></param>
        private void DetermineAppConfigSelectedNodeType(TreeNode node)
        {
            //Si Root = 0, File = 1 , ApplicationSettingsOrSectionGroup = 2
            if (node.Level == 0 || node.Level == 1)
            {
                _AppConfigSelectedNodeType =
                    (ConfigurationApp.Common.AppConfigSelectedNodeType)Enum.Parse(typeof(ConfigurationApp.Common.AppConfigSelectedNodeType), node.Level.ToString());
                return;
            }
            if (node.Level == 2)
            {
                if (node.Text.Trim() == "sectionGroup")
                {
                    _AppConfigSelectedNodeType = ConfigurationApp.Common.AppConfigSelectedNodeType.SectionGroup;
                }
                if (node.Text.Trim() == "applicationSettings")
                {
                    _AppConfigSelectedNodeType = ConfigurationApp.Common.AppConfigSelectedNodeType.ApplicationSettings;
                }
                if (node.Text.Trim() == "Data base configuration")
                {
                    _AppConfigSelectedNodeType = ConfigurationApp.Common.AppConfigSelectedNodeType.CnnStrings;
                }

                return;
            }
            if (node.Tag != null)
            {
                if (node.Tag.GetType().ToString().Contains("ConfigurationApp.CnnString"))
                {
                    _AppConfigSelectedNodeType = ConfigurationApp.Common.AppConfigSelectedNodeType.CnnString;
                    return;
                }
                if (node.Tag.ToString().Contains("ConfigurationApp.Settings"))
                {
                    _AppConfigSelectedNodeType = ConfigurationApp.Common.AppConfigSelectedNodeType.Setting;
                    return;
                }
                if (node.Tag.ToString().Contains("Application"))
                {
                    _AppConfigSelectedNodeType = ConfigurationApp.Common.AppConfigSelectedNodeType.Application;
                    return;
                }

            }

        }

        /// <summary>
        /// Obtiene el nodo que reprecenta un archivo en el tree view
        /// </summary>
        /// <returns></returns>
        private TreeNode GetTreeNodeFile()
        {
            TreeNode wTreeNodeFile = null;
            switch (_AppConfigSelectedNodeType)
            {
                case ConfigurationApp.Common.AppConfigSelectedNodeType.File:
                    {
                        wTreeNodeFile = treeView1.SelectedNode;
                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.ApplicationSettings:
                case ConfigurationApp.Common.AppConfigSelectedNodeType.SectionGroup:
                case ConfigurationApp.Common.AppConfigSelectedNodeType.CnnStrings:
                    {
                        wTreeNodeFile = treeView1.SelectedNode.Parent;
                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.Setting:
                    {
                        wTreeNodeFile = treeView1.SelectedNode.Parent.Parent.Parent;
                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.Application:
                    {
                        wTreeNodeFile = treeView1.SelectedNode.Parent.Parent;
                        break;
                    }
                case ConfigurationApp.Common.AppConfigSelectedNodeType.CnnString:
                    {
                        wTreeNodeFile = treeView1.SelectedNode.Parent.Parent;
                        break;
                    }
            }


            return wTreeNodeFile;
        }

        /// <summary>
        /// Genera el cambio en el valor del nodo afectando el contenido del archivo
        /// Solo si cambia un setting o una cadena de conexión
        /// </summary>
        private void AppConfigSettingsChange()
        {
            switch (_AppConfigSelectedNodeType)
            {
                case ConfigurationApp.Common.AppConfigSelectedNodeType.Setting:
                    {
                        // Cambio el valor de la propiedad
                        TreeNode wNodeFile = GetTreeNodeFile(); // wSel.Parent.Parent.Parent.Parent.Nodes[0];
                        AppConfigControl.ChangeSettingValue(wNodeFile, treeView1.SelectedNode);
                      
                        break;
                    }
            }
        }


        private void DetermineContextMenuEnabled()
        {
            
            if (_AppConfigSelectedNodeType == AppConfigSelectedNodeType.File)
            {
                tsMenuQuitAppClientConfig.Enabled = true;
                tsMenuSaveAppClientConfig.Enabled = true;
                tsMenuRefreshAppClientConfig.Enabled = true;
            }
            else
            {
                tsMenuQuitAppClientConfig.Enabled = false;
                tsMenuSaveAppClientConfig.Enabled = false;
                tsMenuRefreshAppClientConfig.Enabled = false;
            }

            
        }

        #endregion

        #region Wrapper configuration
        /// <summary>
        /// Crea los settings  y secciones para el Wrapper de Web Service
        /// </summary>
        void AddWebServiceWrapperSeccion()
        {
            AppConfigControl.AddWebServiceWrapperSeccion(GetTreeNodeFile(),mnSection);
        }

        /// <summary>
        /// Crea los settings  y secciones para el Wrapper de Remoting
        /// </summary>
        void AddRemotingWrapperSeccion()
        {
            AppConfigControl.AddRemotingWrapperSeccion(GetTreeNodeFile(),mnSection);
        }

        /// <summary>
        /// Crea los settings y secciones para el Wrapper de acceso local
        /// </summary>
        void AddLocalWrapperSection()
        {
            AppConfigControl.AddLocalWrapperSection(GetTreeNodeFile(),mnSection);
        }

        void RemoveWrapperSection()
        {
            AppConfigControl.RemoveWrapperSection(GetTreeNodeFile());
        }
        #endregion
        private void AddBusinessFacadeSection()
        {
            ServiceMannagerConfig.AddBusinessFacadeSection(GetTreeNodeFile(), mnSection);
        }

        #region Data Access

        /// <summary>
        /// 
        /// </summary>
        private void AddDataConnection()
        {
            TreeNode t = null;
            if (_AppConfigSelectedNodeType == AppConfigSelectedNodeType.File)
            {
                t = treeView1.SelectedNode;
            }
            if (_AppConfigSelectedNodeType == AppConfigSelectedNodeType.ApplicationSettings ||
                _AppConfigSelectedNodeType == AppConfigSelectedNodeType.SectionGroup)
            {
                t = treeView1.SelectedNode.Parent;
            }
            if (t != null)
            {
                DataConfigControl.AddConfigSection(t, mnCnnStrings);
            }
        }

        /// <summary>
        /// Efectua el cambio de los valores de la connection
        /// </summary>
        /// <param name="pOldName"></param>
        private void CnnStringChange(String pOldName)
        {
            // Cambio el valor de la propiedad
            if (treeView1.SelectedNode.Text.Length != 0)
            {
                TreeNode wNodeFile = GetTreeNodeFile();
                DataConfigControl.ChangeCnnString(wNodeFile, treeView1.SelectedNode, pOldName);

            }
        }

        #endregion

        #region Files

        public void QuitFile()
        {
            if (_AppConfigSelectedNodeType == AppConfigSelectedNodeType.Root)
            {
                MessageBox.Show("Please.. select a file node.", "Config manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TreeNode wTreeNodeFile = GetTreeNodeFile();

            AppConfigControl.QuitFile(wTreeNodeFile);
        }

        private void QuitAllFiles()
        {
            foreach (TreeNode wFileTreeNode in treeView1.Nodes[0].Nodes)
            {
                AppConfigControl.QuitFile(wFileTreeNode);
            }
        }

        public void NewFile()
        {
            AppConfigControl.NewFile(treeView1.Nodes[0], mnAppConfigAplications,mnSection);
        }
        /// <summary>
        /// Carga un archivo App.Config y lo mapea al tree view. Agrega un nuevo nodo (llamado NodeFile) al Node Root
        /// </summary>
        public void LoadFile()
        {
            AppConfigControl.LoadFile(treeView1.Nodes[0], mnAppConfigAplications, mnCnnStrings, mnCnnString,mnSection, String.Empty);
        }

        /// <summary>
        /// Guarda todos los archivos
        /// </summary>
        public void SaveAllFile()
        {
            foreach (TreeNode o in treeView1.Nodes[0].Nodes)
            {
                AppConfigControl.SaveFile(o);
            }
        }

        /// <summary>
        /// Guarda un archivo AppConfig dependiendo de donde esta el selected node apuntando
        /// </summary>
        public void SaveFile()
        {

            if (_AppConfigSelectedNodeType == AppConfigSelectedNodeType.Root)
            {
                MessageBox.Show("Please.. select a file node.", "Config manager", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            TreeNode wTreeNodeFile = GetTreeNodeFile();
            AppConfigControl.SaveFile(wTreeNodeFile);

        }

        /// <summary>
        /// Vuelve a cargar los archivos en el tree view.-
        /// </summary>
        /// <param name="pClear">Determina si limpia los nodos del tree view y de AppConfigControl.AppConfigFilesList</param>
        public void RefreshAllFiles(Boolean pClear)
        {
            if (pClear)
            {
                treeView1.Nodes[0].Nodes.Clear();

                AppConfigControl.ClearAppConfigFilesList();
            }

            AppConfigControl.LoadFilesFromStorage(treeView1.Nodes[0], mnAppConfigAplications, mnCnnStrings, mnCnnString,mnSection, _Storage);

            treeView1.Nodes[0].Expand();
        }


        /// <summary>
        /// Guarda en un Isolated Storage los archivos (path) cargados en el treeview.-
        /// </summary>
        public void SaveIsolatedStorage()
        { AppConfigControl.SaveIsolatedStorage(treeView1.Nodes[0], _Storage); }
        #endregion
    }
}
