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
using Fwk.Exceptions;
using Fwk.Bases.FrontEnd.Controls;
using System.Configuration;
using Fwk.ConfigSection;
namespace ConfigurationApp
{
    internal class ConfigManagerControl
    {

        static ConfigManagerControl()
        {

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
        internal static void LoadFiles(TreeNode pConfigManagerTreeNode,
          ContextMenuStrip mnContextCnfgManFile,
          ContextMenuStrip mnGroupOrProperty, Storage pStorage)
        {
            pStorage.LoadStorage();
            foreach (ConfigProviderElement provider in Fwk.Configuration.ConfigurationManager.ConfigProvider.Providers)
            {
                LoadFile(pConfigManagerTreeNode, mnContextCnfgManFile, mnGroupOrProperty, provider);
            }

        }

        /// <summary>
        /// Metodo que carga un archivo de configuracion desde el menu del formulario principal
        /// </summary>
        /// <param name="pConfigManagerTreeNode"></param>
        /// <param name="mnContextCnfgManFile"></param>
        /// <param name="mnGroupOrProperty"></param>
        //internal static void LoadFile(TreeNode pConfigManagerTreeNode,
        //    ContextMenuStrip mnContextCnfgManFile,
        //    ContextMenuStrip mnGroupOrProperty)
        //{
        //    String strFullFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_Open(Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter);
        //    if (strFullFileName.Length == 0)
        //        return;

        //    String strFileName = System.IO.Path.GetFileName(strFullFileName);


        //    if (_Holder.ExistConfigurationFile(strFileName))
        //    {
        //        Fwk.Bases.FrontEnd.Controls.FwkMessageView.Show(string.Concat("The file ", strFileName, " exist"), "Config mannager", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Exclamation);

        //        return;
        //    }

        //    LoadFile(pConfigManagerTreeNode, mnContextCnfgManFile, mnGroupOrProperty, strFileName, strFullFileName);

        //}

        private static void LoadFile(TreeNode pConfigManagerTreeNode,
           ContextMenuStrip mnContextCnfgManFile,
           ContextMenuStrip mnGroupOrProperty, ConfigProviderElement provider)
        {

            ListDictionary wDictionary = new ListDictionary();
            try
            {
                ConfigurationFile wConfigurationFile = Fwk.Configuration.ConfigurationManager.GetConfigurationFile(provider.Name);
                wConfigurationFile.FileName = System.IO.Path.GetFileName(provider.BaseConfigFile);


                #region [Set to FileNode]
                TreeNode wFileNode = new TreeNode(wConfigurationFile.FileName);

                wFileNode.ToolTipText = string.Concat("Proveedor tipo: ", provider.ConfigProviderType.ToString()); ;
                wDictionary.Add("FullFileName", wConfigurationFile.BaseConfigFile);
                wDictionary.Add("ConfigurationFile", wConfigurationFile);
                wDictionary.Add("provider", provider.Name);

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
            catch (InvalidOperationException er)
            {

                TechnicalException te = new Fwk.Exceptions.TechnicalException("It's not valid configuration manager file", er);
                FwkMessageView.Show(te, "Config mannager", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);

            }
            catch (TechnicalException er1)
            {
                if (er1.ErrorId.Equals("8011") || er1.ErrorId.Equals("9200"))
                {
                    TreeNode wFileNode = new TreeNode(provider.BaseConfigFile);

                    wFileNode.ToolTipText = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(er1);
                    wDictionary.Add("FullFileName", provider.BaseConfigFile);
                    wDictionary.Add("ConfigurationFile", null);
                    wDictionary.Add("provider", provider.Name);

                    wFileNode.Tag = wDictionary;
                    //wFileNode.ContextMenuStrip = mnContextCnfgManFile;
                    wFileNode.ImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("alert.png");
                    wFileNode.SelectedImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("alert.png");
                    pConfigManagerTreeNode.Nodes.Add(wFileNode);
                }
                else
                {
                    FwkMessageView.Show(er1, "Config mannager", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                }
            }
        }

        //internal static void NewFile(TreeNode pConfigManagerTreeNode, ContextMenuStrip mnContextCnfgManFile,
        //   ContextMenuStrip mnGroupOrProperty)
        //{
        //    ConfigurationFile wConfigurationFile = new ConfigurationFile();
        //    String strFullFileName = Fwk.HelperFunctions.FileFunctions.OpenFileDialog_New(wConfigurationFile.GetXml(), Fwk.HelperFunctions.FileFunctions.OpenFilterEnums.OpenXmlFilter, true);

        //    if (strFullFileName.Length == 0) return;
        //    String strFileName = System.IO.Path.GetFileName(strFullFileName);

        //    wConfigurationFile.FileName = strFileName;

        //    LoadFile(pConfigManagerTreeNode, mnContextCnfgManFile, mnGroupOrProperty, strFileName, strFullFileName);
        //}




        /// <summary>
        /// Guarda el archivo 
        /// </summary>
        /// <param name="pFileNode">Nombre del archivo</param>
        //internal static void SaveFile(TreeNode pFileNode)
        //{

        //    ListDictionary dic = (ListDictionary)pFileNode.Tag;
        //    String szFullFileName = dic["FullFileName"].ToString();
        //    ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
        //    dic["Saved"] = true;
        //    if (System.IO.File.Exists(szFullFileName))
        //    {
        //        try
        //        {
        //            FileFunctions.SaveTextFile(szFullFileName, wConfigurationFile.GetXml(), false);
        //        }
        //        catch (System.UnauthorizedAccessException)
        //        {
        //            throw new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo " , szFullFileName));

        //        }
        //    }
        //}

        /// <summary>
        /// Quita un archivo configuration manager.-
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        //public static void QuitFile(TreeNode pFileNode)
        //{
        //    ListDictionary dic = (ListDictionary)pFileNode.Tag;

        //    bool wSaved = (bool)dic["Saved"];

        //    if (wSaved)
        //    {
        //        SaveFile(pFileNode);
        //        pFileNode.Remove();
        //        _Holder.RemoveConfigManager(pFileNode.Text);
        //    }
        //    else
        //    {


        //        DialogResult d = FwkMessageView.Show(string.Concat("Save changes to ", pFileNode.Text, "?"), "Config mannager", MessageBoxButtons.YesNoCancel, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Question);


        //        if (d == DialogResult.Yes)
        //        {
        //            SaveFile(pFileNode);
        //            pFileNode.Remove();
        //            _Holder.RemoveConfigManager(pFileNode.Text);

        //        }
        //        if (d == DialogResult.No)
        //        {

        //            pFileNode.Remove();
        //            pFileNode.TreeView.Refresh();
        //            _Holder.RemoveConfigManager(pFileNode.Text);
        //        }

        //        if (d == DialogResult.Cancel)
        //        { return; }

        //    }
        //}


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
        internal static void SetKeyRepetidos(Groups pGroup, TreeNode treeNodeFile, ImageList img)
        {
            string strGorupKey;
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
                    TreeNode[] trKeys = trGroup[0].Nodes.Find(key, false);
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


        /// <summary>
        /// Realiza combios en una key. Tanto en treeview como en origen de datos
        /// </summary>
        /// <param name="wTreeNodeKey">Nodo que contiene la clave</param>
        /// <param name="newKey">Valores de nueva clave</param>
        public static void ChangeKey(TreeNode wTreeNodeKey, Key newKey)
        {
            TreeNode wTreeNodeFileNode = wTreeNodeKey.Parent.Parent;
            ListDictionary dic = (ListDictionary)wTreeNodeFileNode.Tag;
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];


            //Obtengo la Key sin modificacion
            Key wKey = ((Key)wTreeNodeKey.Tag);
            string oldKeyName = wKey.Name;

            //Mapping de nuevos  valores
            wKey.Name = newKey.Name;
            wKey.Value = newKey.Value;
            wKey.Encrypted = newKey.Encrypted;
     
            
            wTreeNodeKey.Text = newKey.Name;

            ///Grupo donde se encuentra la key
            Group wGroup = ((Group)wTreeNodeKey.Parent.Tag);

            Fwk.Configuration.ConfigurationManager_CRUD.ChangeProperty(dic["provider"].ToString(), wGroup.Name, newKey, oldKeyName);

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
  
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];


            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            Key wKey = wGroup.Keys.GetFirstByName(pKeyName);
            wGroup.Keys.Remove(wKey);
            Fwk.Configuration.ConfigurationManager_CRUD.RemoveProperty(dic["provider"].ToString(), wGroup.Name, wKey.Name);
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
            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];
            Group wGroup = (Group)pTreeNodeGroup.Tag;
            if (wGroup.Keys.Exists(k => k.Name.Equals(pKeyName, StringComparison.OrdinalIgnoreCase)))
            {

                FwkMessageView.Show("Already exist a propertie witch this name", " Duplicated propertie", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Warning);
                return;
            }
            
     
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
            
            wGroup.Keys.Add(wKey);

            Fwk.Configuration.ConfigurationManager_CRUD.AddProperty(dic["provider"].ToString(), wGroup.Name, wKey);

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
            Group gr = (Group)pTreeNodeGroupNode.Tag;
            string oldName = gr.Name;
            pTreeNodeGroupNode.Tag = newGroup;
            pTreeNodeGroupNode.Text = newGroup.Name;
            pTreeNodeGroupNode.Name = newGroup.Name;
            
            pTreeNodeGroupNode.Tag = newGroup;
            //gr.Name = newGroup.Name;


            Fwk.Configuration.ConfigurationManager_CRUD.ChangeGroupName(dic["provider"].ToString(), oldName, newGroup.Name);
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


            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            wConfigurationFile.Groups.Remove(wGroup);

            Fwk.Configuration.ConfigurationManager_CRUD.RemoveGroup(dic["provider"].ToString(), pGroupName);
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
            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            ConfigurationFile wConfigurationFile = (ConfigurationFile)dic["ConfigurationFile"];

            if (wConfigurationFile.Groups.Exists(g => g.Name.Equals(pGroupName, StringComparison.OrdinalIgnoreCase)))
            {
                FwkMessageView.Show("Already exist a group witch this name", "Duplicated group", MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Warning);
                return;
            }


            TreeNode wtvGroupNode = new TreeNode(pGroupName);
            wtvGroupNode.ImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
            wtvGroupNode.SelectedImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
            wtvGroupNode.ContextMenuStrip = mnGroupOrProperty;
            Group wGroup = new Group();
            wGroup.Name = pGroupName;
            wtvGroupNode.Tag = wGroup;

            wConfigurationFile.Groups.Add(wGroup);
            pFileNode.Nodes.Add(wtvGroupNode);

            Fwk.Configuration.ConfigurationManager_CRUD.AddGroup(dic["provider"].ToString(), wGroup);
        }



        #endregion


    }
}
