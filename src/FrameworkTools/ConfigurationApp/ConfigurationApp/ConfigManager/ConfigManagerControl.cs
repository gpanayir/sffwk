using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using ConfigurationApp.Common;
using Fwk.Configuration.Common;

using Fwk.HelperFunctions;
using FwkXml = Fwk.Xml;
using ConfigurationApp.IsolatedStorage;
using System.Linq;
namespace ConfigurationApp
{
    internal class ConfigManagerControl
    {
        static Fwk.Configuration.LocalHolder _Holder = null;
        static ConfigManagerControl()
        {
            CreateConfigurationHolder();
        }
        /// <summary>
        /// Operacion que retorna una instancia de la clase <see cref="LocalHolder"/> 
        /// utilizando un patron Singlenton
        /// </summary>
        /// <returns><see cref="LocalHolder"/> </returns>
        /// <Author>Marcelo Oviedo</Author>
        private static void CreateConfigurationHolder()
        {
            if (_Holder == null)
            {
                _Holder = new Fwk.Configuration.LocalHolder();

            }

        }

        /// <summary>
        /// Lista de archivos App.Config, en esta lista se almacenan los nombres completo de todos los archivos abiertos 
        /// de modo que quede un registro en memoria de los archivos con los cuales se esta trabajando.-
        /// </summary>
        internal static List<String> _ConfigMannagerFilesList = new List<string>();
        #region [File]

        /// <summary>
        /// Metodo que carga varios archivos de configuracion almacenados en el configuration manager
        /// </summary>
        /// <param name="pConfigManagerTreeNode"></param>
        /// <param name="mnContextCnfgManFile"></param>
        /// <param name="mnGroupOrProperty"></param>
        /// <param name="pStorage"></param>
        internal static void LoadFilesFromIsolatedStorage(TreeNode pConfigManagerTreeNode,
          ContextMenuStrip mnContextCnfgManFile,
          ContextMenuStrip mnGroupOrProperty, Storage pStorage)
        {
            pStorage.LoadStorage();
            foreach (KeyValuePair<String, String> item in pStorage.ConfigManagerFiles)
            {
                if (System.IO.File.Exists(item.Value))
                {
                    LoadFile(pConfigManagerTreeNode, mnContextCnfgManFile, mnGroupOrProperty, item.Key, item.Value);
                }
            }
            pStorage.ConfigManagerFiles.Clear();
        }

        /// <summary>
        /// Metodo que carga un archivo de configuracion desde el menu del formulario principal
        /// </summary>
        /// <param name="pConfigManagerTreeNode"></param>
        /// <param name="mnContextCnfgManFile"></param>
        /// <param name="mnGroupOrProperty"></param>
        internal static void LoadFile(TreeNode pConfigManagerTreeNode,
            ContextMenuStrip mnContextCnfgManFile,
            ContextMenuStrip mnGroupOrProperty)
        {
            String strFullFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter);
            if (strFullFileName.Length == 0)
                return;

            String strFileName = System.IO.Path.GetFileName(strFullFileName);


            if (_Holder.ExistConfigurationFile(strFileName))
            {
                MessageBox.Show("The file " + strFileName + " exist");
                return;
            }

            LoadFile(pConfigManagerTreeNode, mnContextCnfgManFile, mnGroupOrProperty, strFileName, strFullFileName);

        }

        private static void LoadFile(TreeNode pConfigManagerTreeNode,
           ContextMenuStrip mnContextCnfgManFile,
           ContextMenuStrip mnGroupOrProperty, String strFileName, String strFullFileName)
        {
            //XmlDocument doc = null;
            ListDictionary wDictionary = new ListDictionary();
            try
            {
                ConfigurationFile wConfigurationFile = _Holder.GetConfig_WhihoutAppSetting(strFullFileName);
                wConfigurationFile.FileName = System.IO.Path.GetFileName(strFullFileName);


                #region [Set to FileNode]
                TreeNode wFileNode = new TreeNode(strFileName);

                wFileNode.ToolTipText = strFullFileName;
                wDictionary.Add("FullFileName", strFullFileName);
                wDictionary.Add("ConfigurationFile", wConfigurationFile);
                wDictionary.Add("Saved", true);

                wFileNode.Tag = wDictionary;
                wFileNode.ContextMenuStrip = mnContextCnfgManFile;
                wFileNode.ImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("inifile.ico");
                wFileNode.SelectedImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("inifile.ico");

                #region Agrego todos los grupos

                LoadGroupFromFile(pConfigManagerTreeNode, wFileNode, wConfigurationFile.Groups, mnGroupOrProperty);

                #endregion

                #endregion

                //Si todo funciono buien agrego el nodo 
                pConfigManagerTreeNode.Nodes.Add(wFileNode);
            }
            catch (Exception er)
            {
                MessageBox.Show("It's not valid configuration manager file" + Environment.NewLine + er.Message, "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _Holder.RemoveConfigManager(strFullFileName);

            }
        }

        internal static void NewFile(TreeNode pConfigManagerTreeNode, ContextMenuStrip mnContextCnfgManFile,
           ContextMenuStrip mnGroupOrProperty)
        {
            ConfigurationFile wConfigurationFile = new ConfigurationFile();
            String strFullFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New(wConfigurationFile.GetXml(), Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter, true);

            if (strFullFileName.Length == 0) return;
            String strFileName = System.IO.Path.GetFileName(strFullFileName);

            wConfigurationFile.FileName = strFileName;

            LoadFile(pConfigManagerTreeNode, mnContextCnfgManFile, mnGroupOrProperty, strFileName, strFullFileName);
        }




        /// <summary>
        /// Guarda el archivo 
        /// </summary>
        /// <param name="pFileNode">Nombre del archivo</param>
        internal static void SaveFile(TreeNode pFileNode)
        {

            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            String szFullFileName = dic["FullFileName"].ToString();
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
            dic["Saved"] = true;
            if (System.IO.File.Exists(szFullFileName))
            {
                try
                {
                    FileFunctions.SaveTextFile(szFullFileName, wConfigurationFile.GetXml(), false);
                }
                catch (System.UnauthorizedAccessException)
                {
                    throw new Exception("No tiene permiso para actualizar el archivo " + szFullFileName);
                }
            }
        }

        /// <summary>
        /// Quita un archivo configuration manager.-
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        public static void QuitFile(TreeNode pFileNode)
        {
            ListDictionary dic = (ListDictionary)pFileNode.Tag;

            bool wSaved = (bool)dic["Saved"];

            if (wSaved)
            {
                SaveFile(pFileNode);
                pFileNode.Remove();
                _Holder.RemoveConfigManager(pFileNode.Text);
            }
            else
            {
                DialogResult d = MessageBox.Show("Save changes to " + pFileNode.Text + "?"
                    , "Configuration App", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    SaveFile(pFileNode);
                    pFileNode.Remove();
                    _Holder.RemoveConfigManager(pFileNode.Text);

                }
                if (d == DialogResult.No)
                {

                    pFileNode.Remove();
                    pFileNode.TreeView.Refresh();
                    _Holder.RemoveConfigManager(pFileNode.Text);
                }

                if (d == DialogResult.Cancel)
                { return; }

            }
        }


        /// <summary>
        /// Guarda en cache (IsolatedStorage) los pares [FileName,FullFileName]
        /// </summary>
        /// <param name="pConfigManagerTreeNode"></param>
        /// <param name="pStorage"></param>
        internal static void SaveIsolatedStorage(TreeNode pConfigManagerTreeNode, Storage pStorage)
        {
            ListDictionary dic = null;
            pStorage.ConfigManagerFiles.Clear();
            foreach (TreeNode wFileNode in pConfigManagerTreeNode.Nodes)
            {
                dic = (ListDictionary)wFileNode.Tag;
                pStorage.ConfigManagerFiles.Add(wFileNode.Text, dic["FullFileName"].ToString());
            }

            pStorage.CreateStorage();
        }

        #endregion

        #region [Key]
        /// <summary>
        /// Rellena el nodo Grupo con las Keys 
        /// </summary>
        /// <param name="pGroupNode">Tree Node Grupo</param>
        /// <param name="pXmlGroup">Xml Node Grupo</param>
        /// <param name="mnGroupOrProperty">Menu contextual</param>
        internal static void LoadKeysFromGroup(TreeNode pGroupNode, Group pGroup, ContextMenuStrip mnGroupOrProperty, System.Windows.Forms.ImageList pImageList)
        {


            foreach (Key wKey in pGroup.Keys)
            {
                TreeNode wTreeNodeKey = new TreeNode(wKey.Name);
                wTreeNodeKey.Tag = wKey;
                wTreeNodeKey.Name = wKey.Name;
                wTreeNodeKey.SelectedImageIndex = pImageList.Images.IndexOfKey("PushpinHS.png");
                wTreeNodeKey.ImageIndex = pImageList.Images.IndexOfKey("UtilityText.ico");

                wTreeNodeKey.ContextMenuStrip = mnGroupOrProperty;
                pGroupNode.Nodes.Add(wTreeNodeKey);
            }
        }
        internal static void LoadGroupFromFile(TreeNode pConfigManagerTreeNode,
            TreeNode wFileNode, Groups pGroups, ContextMenuStrip mnGroupOrProperty)
        {

            foreach (Fwk.Configuration.Common.Group wGroup in pGroups)
            {
                TreeNode wtvGroupNode = new TreeNode(wGroup.Name);
                wtvGroupNode.Text = wGroup.Name;
                wtvGroupNode.Name = wGroup.Name;
                wtvGroupNode.ImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
                wtvGroupNode.SelectedImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
                wtvGroupNode.ContextMenuStrip = mnGroupOrProperty;

                wtvGroupNode.Tag = wGroup;

                wFileNode.Nodes.Add(wtvGroupNode);

                

                LoadKeysFromGroup(wtvGroupNode, wGroup, mnGroupOrProperty, pConfigManagerTreeNode.TreeView.ImageList);
            }
            SetKeyRepetidos(pGroups, wFileNode, pConfigManagerTreeNode.TreeView.ImageList);
        }

        /// <summary>
        /// Marca las Key que estan repetidas dentro de un grupo
        /// </summary>
        /// <param name="pGroupElement"></param>
        internal static void SetKeyRepetidos(Groups pGroup, TreeNode treeNodeFile,ImageList img)
        {
            string strGorupKey ; 
            Int32 wCount = 0;
            List<string> wNames = new List<string>();

            foreach (Group wGroup in pGroup)
            {
                foreach (Key wKey in wGroup.Keys)
                {
                    if (!wNames.Contains(wKey.Name))
                    {
                        wCount = wGroup.Keys.GetCountByName(wKey.Name);

                        if (wCount > 1)
                        {
                            strGorupKey = string.Concat(wGroup.Name, ',', wKey.Name);
                            wNames.Add(strGorupKey);
                        }
                    }
                }
            }

            foreach (string str in wNames)
            {
                string group = str.Split(',')[0];
                string key = str.Split(',')[1];
                TreeNode[] trGroup = treeNodeFile.Nodes.Find(group, true);

               

                if (trGroup.Length != 0)
                {
                    TreeNode[] trKeys = trGroup[0].Nodes.Find( key, false);
                    foreach (TreeNode trKey in trKeys)
                    {
                        trKey.ToolTipText = "Clave repetida !!";
                        trKey.SelectedImageIndex = img.Images.IndexOfKey("WarningHS.png");
                        trKey.ImageIndex = img.Images.IndexOfKey("WarningHS.png");
                    }
                }
            }
            
        }


        static List<TreeNode> FindChildsNodes(TreeNode tr, string pName, bool pFirshOnly)
        {
            List<TreeNode> wTreeNodeChilds = new List<TreeNode>();
            foreach (TreeNode wChild in tr.Nodes)
            {
                if (string.Compare(pName, wChild.Text) == 0)
                {
                    wTreeNodeChilds.Add(wChild);
                    if (pFirshOnly) return wTreeNodeChilds;
                }
            }
            return wTreeNodeChilds;
        }
        public static void ChangeKey(TreeNode wTreeNodeKey, Key newKey)
        {
            TreeNode wTreeNodeFileNode = wTreeNodeKey.Parent.Parent;
            ListDictionary dic = (ListDictionary)wTreeNodeFileNode.Tag;
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
            dic["Saved"] = false;

            wTreeNodeKey.Tag = newKey;

            wTreeNodeKey.Text = newKey.Name;


        }




        /// <summary>
        /// Elimina una key 
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        /// <param name="pGroupName">Nombre de grupo</param>
        /// <param name="pKeyName">Nombre de la Key</param>
        public static void RemoveKey(TreeNode pFileNode, String pGroupName, String pKeyName)
        {
            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            //"Groups"
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
            dic["Saved"] = false;

            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            Key wKey = wGroup.Keys.GetFirstByName(pKeyName);
            wGroup.Keys.Remove(wKey);
        }

        /// <summary>
        /// Agrega una nueva Key 
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        /// <param name="pGroupName">Nombre de grupo</param>
        /// <param name="pKeyName">Nombre de la nueva Key</param>
        /// <param name="pKeyValue">Valor de la nueva Key</param>
        /// <param name="mnGroupOrProperty">Menu contextual espesifico para grupos o propiedades(keys)</param>
        public static void AddKey(TreeNode pFileNode,
           TreeNode pTreeNodeGroup,
           String pKeyName,
            String pKeyValue,
           ContextMenuStrip mnGroupOrProperty
           )
        {
            #region Seleccion de Groups Node
            if (ConfigurationApp.Common.Helper.TreeNodeExist(pTreeNodeGroup, pKeyName))
            {
                MessageBox.Show("Already exist a key witch this name", "Duplicated key");
                return;
            }
            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
            dic["Saved"] = false;
            #endregion

            #region Crea la Key a nivel del TreeView

            TreeNode wKeyTreeNode = new TreeNode(pKeyName);


            wKeyTreeNode.SelectedImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("PushpinHS.png");
            wKeyTreeNode.ImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("UtilityText.ico");

            wKeyTreeNode.ContextMenuStrip = mnGroupOrProperty;

            Key wKey = new Key();
            wKey.Value.Text = pKeyValue;
            wKey.Name = pKeyName;

            wKeyTreeNode.Tag = wKey;


            pTreeNodeGroup.Nodes.Add(wKeyTreeNode);
            Group wGroup= (Group)pTreeNodeGroup.Tag;
            wGroup.Keys.Add(wKey);
            #endregion

        }
        #endregion

        #region [Group]

        /// <summary>
        /// Cambia el nombre del grupo
        /// </summary>
        /// <param name="pTreeNodeGroupNode">TreeNode perteneciente al grupo</param>
        internal static void ChangeGroupName(TreeNode pTreeNodeGroupNode, Group newGroup)
        {
            if (newGroup == null) return;
            ListDictionary dic = (ListDictionary)pTreeNodeGroupNode.Parent.Tag;
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
            dic["Saved"] = false;

            pTreeNodeGroupNode.Tag = newGroup;
            pTreeNodeGroupNode.Text = newGroup.Name;
            pTreeNodeGroupNode.Name = newGroup.Name;
            Group gr = wConfigurationFile.Groups.GetFirstByName(pTreeNodeGroupNode.Text);
            pTreeNodeGroupNode.Tag = newGroup;
            gr.Name = newGroup.Name;
        }

        /// <summary>
        /// Elimina un grupo
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        /// <param name="pGroupName">Nombre de grupo</param>
        internal static void RemoveGroup(TreeNode pFileNode, String pGroupName)
        {

            ListDictionary dic = (ListDictionary)pFileNode.Tag;
          
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
            dic["Saved"] = false;
          
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            wConfigurationFile.Groups.Remove(wGroup);
        }

        /// <summary>
        /// Agrega un nuevo grupo
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        /// <param name="pGroupName">Nombre de grupo</param>
        /// <param name="mnGroupOrProperty">Menu contextual espesifico para grupos o propiedades(keys)</param>
        internal static void AddGroup(TreeNode pFileNode,
            String pGroupName,
            ContextMenuStrip mnGroupOrProperty
            )
        {


            if (ConfigurationApp.Common.Helper.TreeNodeExist(pFileNode, pGroupName))
            {
                MessageBox.Show("Already exist a group witch this name", "Duplicated group");
                return;
            }


            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            //"Groups"
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
            dic["Saved"] = false;




            TreeNode wtvGroupNode = new TreeNode(pGroupName);
            wtvGroupNode.ImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
            wtvGroupNode.SelectedImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
            wtvGroupNode.ContextMenuStrip = mnGroupOrProperty;
            Group wGroup = new Group();
            wGroup.Name = pGroupName;
            wtvGroupNode.Tag = wGroup;

            wConfigurationFile.Groups.Add(wGroup);
            pFileNode.Nodes.Add(wtvGroupNode);

        }



        #endregion

      
    }
}
