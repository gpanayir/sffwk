//using System;
//using System.Collections.Generic;
//using System.Collections.Specialized;
//using System.Configuration;
//using System.IO;
//using System.Text;
//using System.Xml;
//using System.Windows.Forms;
//using ConfigurationApp.Common;
//using Fwk.HelperFunctions;
//using Fwk.Xml;
//using  ConfigurationApp.IsolatedStorage;
//using Fwk.Bases.FrontEnd.Controls;

//namespace ConfigurationApp
//{
//    /// <summary>
//    /// Permite gestionar creaciones modificacions etc de archivos AppConfig
//    /// </summary>
//    internal class AppConfigControl
//    {
//        /// <summary>
//        /// Lista de archivos App.Config, en esta lista se almacenan los nombres completo de todos los archivos abiertos 
//        /// de modo que quede un registro en memoria de los archivos con los cuales se esta trabajando.-
//        /// </summary>
//        internal static List<String> _AppConfigFilesList = new List<string>();

//        /// <summary>
//        /// Limpia la lista de archivos  AppConfigFilesList <see cref="_AppConfigFilesList"/>
//        /// </summary>
//        internal static void ClearAppConfigFilesList()
//        {
//            _AppConfigFilesList.Clear();
//        }

//        /// <summary>
//        /// Crea un nuevo archivo App.Config 
//        /// </summary>
//        /// <param name="pTreeNodeRoot">nodo raiz de todos los archivos</param>
//        /// <param name="mnAppConfigAplications">Menu contextual</param>
//        internal static void NewFile(TreeNode pTreeNodeRoot, ContextMenuStrip mnAppConfigAplications, ContextMenuStrip pContextMenuStripSection)
//        {
//            String wstrFullFileName = NewFile();
//            if (wstrFullFileName.Length == 0) return;
//            LoadFile(pTreeNodeRoot, mnAppConfigAplications, null, null, pContextMenuStripSection, wstrFullFileName);

//        }

//        /// <summary>
//        /// Carga los archivos App.Config del Isolated Storage y lo mapea al tree view.
//        /// </summary>
//        /// <param name="pTreeNodeRoot">Nodo padre de los app.config files</param>
//        /// <param name="mnAppConfigAplications">Menu contextual para los archivos individuales</param>
//        /// <param name="pContextMenuCnnStrings">Menu contextual para los archivos individuales</param>
//        /// <param name="pContextMenuCnnString">Menu contextual para los archivos individuales</param> 
//        /// <param name="pContextMenuStripSection">Menu contextual para los archivos individuales</param> 
//        /// <param name="pStorage">Administrador del Isolated Storage</param>
//        internal static void LoadFilesFromStorage(TreeNode pTreeNodeRoot,
//            ContextMenuStrip mnAppConfigAplications,
//            ContextMenuStrip pContextMenuCnnStrings,
//            ContextMenuStrip pContextMenuCnnString,
//            ContextMenuStrip pContextMenuStripSection,
//            Storage pStorage)
//        {
//            pStorage.LoadStorage();
//            foreach (KeyValuePair<String, String> item in pStorage.AppConfigFiles)
//            {
//                if (System.IO.File.Exists(item.Value))
//                    LoadFile(pTreeNodeRoot, mnAppConfigAplications, pContextMenuCnnStrings, pContextMenuCnnString, pContextMenuStripSection, item.Value);

//            }

//            pStorage.AppConfigFiles.Clear();
//        }

       
        
//        /// <summary>
//        /// Carga un archivo App.Config y lo mapea al tree view. Agrega un nuevo nodo (llamado NodeFile) al Node Root
//        /// </summary>
//        /// <param name="pTreeNodeRoot">Nodo padre de los app.config files</param>
//        /// <param name="pAppConfigAplications">Menu contextual para los archivos individuales</param>
//        /// <param name="pDataAccessMenuStip"></param>
//        /// <param name="pConnectionMenuStip"></param>
//        /// <param name="pContextMenuStripSection"></param>
//        /// <param name="pstrFullFileName">>Nombre completo del archivo</param>
//        internal static void LoadFile(TreeNode pTreeNodeRoot, ContextMenuStrip pAppConfigAplications,
//            ContextMenuStrip pDataAccessMenuStip,
//            ContextMenuStrip pConnectionMenuStip,
//            ContextMenuStrip pContextMenuStripSection,
//            string pstrFullFileName)
//        {
//            if (pstrFullFileName.Length == 0)
//                pstrFullFileName = OpenFile();

//            if (pstrFullFileName.Length == 0)
//                return;

//            String strFileName = System.IO.Path.GetFileName(pstrFullFileName);

//            if (_AppConfigFilesList.IndexOf(pstrFullFileName) != -1)
//            {
                
//             FwkMessageView.Show("This file already exist in the tree", "Config mannager", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Information);
//                return;
//            }

//            Configuration wConfiguration = null;
//            try
//            {
//                ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
//                configFile.ExeConfigFilename = pstrFullFileName;

//                wConfiguration =
//                    ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

//                _AppConfigFilesList.Add(pstrFullFileName);

//                TreeNodeConfig.MapXmlToTreeview(wConfiguration, pTreeNodeRoot, strFileName, pstrFullFileName,
//                                                  pAppConfigAplications, pDataAccessMenuStip, pConnectionMenuStip,
//                                                  pContextMenuStripSection);
//            }
//            catch (System.Configuration.ConfigurationErrorsException wConfigurationErrorsException)
//            {
//                LunchConfigurationErrorsException(strFileName, wConfigurationErrorsException);
//            }
//            catch (Exception ex)
//            {
               
//                FwkMessageView.Show(ex.Message, "Config mannager", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
//            }
            
//        }

//        /// <summary>
//        /// Guarda el archivo App.Config
//        /// </summary>
//        /// <param name="pFileNode"></param>
//        internal static void SaveFile(TreeNode pFileNode)
//        {
//            ListDictionary dic = (ListDictionary)pFileNode.Tag;
//            String szFullFileName = dic["FullFileName"].ToString();
//            Configuration wConfiguration = (Configuration)dic["Configuration"];
//            dic["Saved"] = true;
//            if (System.IO.File.Exists(szFullFileName))
//            {
//                //FileFunctions.SaveTextFile(szFullFileName, xmlGroups.OuterXml);
//                wConfiguration.Save(ConfigurationSaveMode.Full);
//            }
//        }

//        /// <summary>
//        /// Guarda en cache (IsolatedStorage) los pares [FileName,FullFileName]
//        /// </summary>
//        /// <param name="pTreeNodeRoot">Nodo padre de los app.config files</param>
//        /// <param name="pStorage">Administrador del Isolated Storage</param>
//        internal static void SaveIsolatedStorage(TreeNode pTreeNodeRoot, Storage pStorage)
//        {
//            ListDictionary dic = null;
//            pStorage.AppConfigFiles.Clear();
//            foreach (TreeNode wFileNode in pTreeNodeRoot.Nodes)
//            {
//                dic = (ListDictionary)wFileNode.Tag;
//                pStorage.AppConfigFiles.Add(wFileNode.Text, dic["FullFileName"].ToString());
//            }

//            pStorage.CreateStorage();
//        }


//        /// <summary>
//        /// Quita un archivo  App.Config.-.-
//        /// </summary>
//        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
//        internal static void QuitFile(TreeNode pFileNode)
//        {
//            ListDictionary dic = (ListDictionary) pFileNode.Tag;
//            bool wSaved = (bool) dic["Saved"];
//            String szFullFileName = dic["FullFileName"].ToString();
//            try
//            {
//                if (wSaved)
//                {
//                    SaveFile(pFileNode);
//                    pFileNode.Remove();
//                    _AppConfigFilesList.Remove(szFullFileName);
//                }
//                else
//                {
                   
                   
//                    DialogResult d = FwkMessageView.Show(string.Concat("Save changes to " , pFileNode.Text , "?")
//                                                     ,"Config mannager", 
//                                                     MessageBoxButtons.YesNoCancel, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Question);
//                    if (d == DialogResult.Yes)
//                    {
//                        SaveFile(pFileNode);
//                        pFileNode.Remove();
//                        _AppConfigFilesList.Remove(szFullFileName);
//                    }
//                    if (d == DialogResult.No)
//                    {
//                        pFileNode.Remove();
//                        if (pFileNode.TreeView != null)
//                            pFileNode.TreeView.Refresh();
//                    }

//                    if (d == DialogResult.Cancel)
//                    {
//                        return;
//                    }
//                }
//            }
//            catch (System.Configuration.ConfigurationErrorsException wConfigurationErrorsException)
//            {
//                LunchConfigurationErrorsException(szFullFileName, wConfigurationErrorsException);
//            }
//            catch (Exception ex)
//            {
//                FwkMessageView.Show(ex.Message, "Config mannager", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
//            }
//        }

//        #region private members




//        /// <summary>
//        /// Muestra dialog box para abrir el archivo de configuracion
//        /// </summary>
//        /// <returns>String con el nombre del archivo</returns>
//        private static String OpenFile()
//        {
//            OpenFileDialog wDialog = new OpenFileDialog();
//            wDialog.DefaultExt = "config";
//            wDialog.CheckFileExists = true;
//            wDialog.Filter = "Config Files (*.config)|*.config|All Files (*.*)|*.*";


//            if (wDialog.ShowDialog() == DialogResult.OK) return wDialog.FileName;
//            else return String.Empty;
//        }

//        /// <summary>
//        /// Crea uhn nuevo archivo App.Config
//        /// </summary>
//        /// <returns>FullFileName</returns>
//        private static String NewFile()
//        {
//            SaveFileDialog wDialog = new SaveFileDialog();
            
//            wDialog.DefaultExt = "config";
//            wDialog.Filter = "Config Files (*.config)|*.config|All Files (*.*)|*.*";
//            if (wDialog.ShowDialog() != DialogResult.OK)
//                return String.Empty;

//            String wFileEnvelope = TemplateProvider.GetAppConfigValue("FileEnvelope");
//            Fwk.HelperFunctions.FileFunctions.SaveTextFile(wDialog.FileName, wFileEnvelope,false);


//            return wDialog.FileName;
//        }

//        #endregion



//        public static void AddConfigurationManagerSeccion(TreeNode node, ContextMenuStrip pContextMenuStripSection)
//        {
//            ConfigurationManagerConfig.AddSection(node, pContextMenuStripSection);
//        }


//        /// <summary>
//        /// Cambia el valor de un Setting:
//        /// /configuration/applicationSettings/setting [name].Value
//        /// </summary>
//        /// <param name="pTreeNodeFile">Nodo con el contenido del archivo App.config</param>
//        /// <param name="pTreeNode">Reprecenta un nodo Settings </param>
//        /// <Author>Marcelo Oviedo</Author> 
//        public static void ChangeSettingValue(TreeNode pTreeNodeFile, TreeNode pTreeNode)
//        {
//            Settings pSettings = (Settings)pTreeNode.Tag;
//            SectionsAndGroupsConfig.ChangeSettingValue(pTreeNodeFile, pSettings.SectionName, pSettings.Name, pSettings.Value);
//        }

//        #region Wrapper
//        /// <summary>
//        /// Agrega una seccion para Fwk Wrapper Web Service
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
//        public static void AddWebServiceWrapperSeccion(TreeNode pTreeNodeFile, ContextMenuStrip pContextMenuStripSection)
//        {
//            WrapperConfig.AddWebServiceWrapperSection(pTreeNodeFile, pContextMenuStripSection);
//        }

//        /// <summary>
//        /// Agrega una seccion para Fwk Wrapper Remoting
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
//        public static void AddRemotingWrapperSeccion(TreeNode pTreeNodeFile, ContextMenuStrip pContextMenuStripSection)
//        {
//            WrapperConfig.AddRemotingWrapperSection(pTreeNodeFile, pContextMenuStripSection);
//        }
//        /// <summary>
//        /// Agrega una seccion para Fwk Wrapper Local
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        /// <param name="pContextMenuStripSection">Menu contextual de todos los nodos sections</param>
//        public static void AddLocalWrapperSection(TreeNode pTreeNodeFile, ContextMenuStrip pContextMenuStripSection)
//        {
//            WrapperConfig.AddLocalWrapperSection(pTreeNodeFile, pContextMenuStripSection);
//        }

//        /// <summary>
//        /// Elimina la configuracion del Wrapper existente
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        public static void RemoveWrapperSection(TreeNode pTreeNodeFile)
//        {
//            WrapperConfig.Remove(pTreeNodeFile);
//        }
//        #endregion



//        /// <summary>
//        /// Elimina la configuracion del Wrapper existente
//        /// </summary>
//        /// <param name="pTreeNodeFile">Node a nivel de archivo</param>
//        /// <param name="pSectionName">Indica el nombre de ls seccion</param>
//        public static void Remove(TreeNode pTreeNodeFile, string pSectionName)
//        {
//            if (TemplateProvider.GetAppConfigValue("WrapperConfigSectionsName") == pSectionName ||
//                TemplateProvider.GetAppConfigValue("WrapperType.ConfigSectionsName") == pSectionName)
//            {
//                WrapperConfig.Remove(pTreeNodeFile);
//            }

//            if (TemplateProvider.GetAppConfigValue("ConfigurationConfigSectionsName") == pSectionName ||
//                TemplateProvider.GetAppConfigValue("BusinessFacadeConfigSectionName") == pSectionName)
//            {
//                ///Elimino del archivo
//                SectionsAndGroupsConfig.RemoveSection(pTreeNodeFile, pSectionName);

//                ///Elimino del treeview
//                TreeNodeConfig.RemoveSection(pTreeNodeFile, pSectionName);
//            }
//        }



//        static void LunchConfigurationErrorsException(string strFileName,ConfigurationErrorsException er)
//        {
//              StringBuilder sbError = new StringBuilder("El archivo de configuracion ");
//                sbError.Append(strFileName);
//                sbError.AppendLine(" no esta bien formado o no es compatible con la version actual del framework");
//                sbError.AppendLine("Error trace");
//                sbError.AppendLine("------------------------------");
//                sbError.AppendLine(er.Message);
                

//                FwkMessageView.Show(sbError.ToString(), "AppConfiguration Error", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
//        }
//    }
//}