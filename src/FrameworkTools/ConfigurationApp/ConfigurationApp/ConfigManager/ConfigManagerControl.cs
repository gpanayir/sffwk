using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Xml;
using System.Windows.Forms;
using ConfigurationApp.Common;
using Fwk.Configuration.Common;
using Fwk.Configuration.Common.ConfigurationResponse;
using Fwk.HelperFunctions;
using FwkXml = Fwk.Xml;
using ConfigurationApp.IsolatedStorage;

namespace ConfigurationApp
{
    internal class ConfigManagerControl
    {
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
            String strFullFileName = OpenFile();
            if (strFullFileName.Length == 0)
                return;
            
            String strFileName = System.IO.Path.GetFileName(strFullFileName);
           

            if (ConfigManagerEngine.ExistConfiguration(strFileName))
            {
                MessageBox.Show("The file " + strFileName + " must be loaded");
                return;
            }

            LoadFile(pConfigManagerTreeNode, mnContextCnfgManFile, mnGroupOrProperty,strFileName, strFullFileName);

        }

        private static void LoadFile(TreeNode pConfigManagerTreeNode,
           ContextMenuStrip mnContextCnfgManFile,
           ContextMenuStrip mnGroupOrProperty, String strFileName, String strFullFileName)
        {
            XmlDocument doc = null;
            ListDictionary wDictionary = new ListDictionary();
            try
            {
                ConfigurationFile wConfigurationFile = ConfigManagerEngine.GetConfigurationFile(strFullFileName);
                doc = new XmlDocument();

                doc.LoadXml(wConfigurationFile.ConfigResult.FileContent);

                #region [Set to FileNode]
                TreeNode wFileNode = new TreeNode(strFileName);
                
                wFileNode.ToolTipText = strFullFileName;
                wDictionary.Add("FullFileName", strFullFileName);
                wDictionary.Add("FileContent", doc.SelectSingleNode("Groups"));
                wDictionary.Add("Saved", true);

                wFileNode.Tag = wDictionary;
                wFileNode.ContextMenuStrip = mnContextCnfgManFile;
                wFileNode.ImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("inifile.ico");
                wFileNode.SelectedImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("inifile.ico");

                #region Agrego todos los grupos

                LoadGroupFromFile(pConfigManagerTreeNode, wFileNode, doc, mnGroupOrProperty);

                #endregion

                #endregion

                //Si todo funciono buien agrego el nodo 
                pConfigManagerTreeNode.Nodes.Add(wFileNode);
            }
            catch (Exception er)
            {
                MessageBox.Show("It's not valid configuration manager file" + Environment.NewLine + er.Message, "Error loading file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ConfigManagerEngine.RemoveConfigurationFile(strFileName);

            }
        }

        internal static void NewFile(TreeNode pConfigManagerTreeNode, ContextMenuStrip mnContextCnfgManFile,
           ContextMenuStrip mnGroupOrProperty)
        {
            String strFullFileName = NewFile();
            if (strFullFileName.Length ==0) return;
            String strFileName = System.IO.Path.GetFileName(strFullFileName);
            
            LoadFile(pConfigManagerTreeNode,mnContextCnfgManFile, mnGroupOrProperty, strFileName, strFullFileName);
        }
        /// <summary>
        /// Crea uhn nuevo archivo App.Config
        /// </summary>
        /// <returns>FullFileName</returns>
        private static String NewFile()
        {
            SaveFileDialog wDialog = new SaveFileDialog();
            wDialog.DefaultExt = "config";
            wDialog.Filter = "Xml Files (*.xml)|*.xml|All Files (*.*)|*.*";
            if (wDialog.ShowDialog() != DialogResult.OK)
                return String.Empty;

            String wFileEnvelope = TemplateProvider.GetConfigurationManagerValue("FileEnvelope");
            Fwk.HelperFunctions.FileFunctions.SaveTextFile(wDialog.FileName, wFileEnvelope,false);
            
            return wDialog.FileName;
        }

        /// <summary>
        /// Muestra dialog box para abrir el archivo de configuracion
        /// </summary>
        /// <returns></returns>
        private static String OpenFile()
        {
            OpenFileDialog wDialog = new OpenFileDialog();
            wDialog.DefaultExt = "xml";
            wDialog.CheckFileExists = true;
            wDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";


            if (wDialog.ShowDialog() == DialogResult.OK) return wDialog.FileName;
            else return String.Empty;
        }

        /// <summary>
        /// Guarda el archivo 
        /// </summary>
        /// <param name="pFileNode">Nombre del archivo</param>
        internal static void SaveFile(TreeNode pFileNode)
        {

            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            String szFullFileName = dic["FullFileName"].ToString();
            XmlNode xmlGroups = (XmlNode)dic["FileContent"];
            dic["Saved"] = true;
            if (System.IO.File.Exists(szFullFileName))
            {
                try
                {
                    xmlGroups.OwnerDocument.Save(szFullFileName);
                    //FileFunctions.SaveTextFile(szFullFileName, xmlGroups.OuterXml,false);
                    //Fwk.Xml.Document.DocumentCreateFromString();
                }
                catch (System.UnauthorizedAccessException)
                { 
                 throw new Exception( "No tiene permiso para actualizar el archivo " + szFullFileName);
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
                ConfigManagerEngine.RemoveConfigurationFile(pFileNode.Text);
            }
            else
            {
                DialogResult d = MessageBox.Show("Save changes to " + pFileNode.Text + "?"
                    , "Configuration App", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (d == DialogResult.Yes)
                {
                    SaveFile(pFileNode);
                    pFileNode.Remove();
                    ConfigManagerEngine.RemoveConfigurationFile(pFileNode.Text);

                }
                if (d == DialogResult.No)
                {

                    pFileNode.Remove();
                    pFileNode.TreeView.Refresh();
                    ConfigManagerEngine.RemoveConfigurationFile(pFileNode.Text);
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
                dic = (ListDictionary) wFileNode.Tag;                
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
        internal static void LoadKeysFromGroup(TreeNode pGroupNode, XmlNode pXmlGroup, ContextMenuStrip mnGroupOrProperty, System.Windows.Forms.ImageList pImageList)
        {
     
            //Recorro las keys del grupo (xmlnode)
            foreach (XmlNode wXmlNodeKey in pXmlGroup.ChildNodes)
            {
                if (wXmlNodeKey.Attributes != null)
                {
                    TreeNode wTreeNodeKey = new TreeNode(wXmlNodeKey.Attributes["name"].Value);

                    Key wKey = new Key(wTreeNodeKey.Text, pXmlGroup.Attributes["name"].Value, pGroupNode.Parent.Text);
                    wKey.Value = wXmlNodeKey.InnerText;
                    wTreeNodeKey.Tag = wKey;

                    if (wXmlNodeKey.Attributes["name"].Value.Contains("Repetido"))
                    {
                        wTreeNodeKey.ImageIndex = pImageList.Images.IndexOfKey("WarningHS.png");
                        wTreeNodeKey.SelectedImageIndex = pImageList.Images.IndexOfKey("WarningHS.gif");
                    }
                    else
                    {
                        wTreeNodeKey.SelectedImageIndex = pImageList.Images.IndexOfKey("PushpinHS.png");
                        wTreeNodeKey.ImageIndex = pImageList.Images.IndexOfKey("UtilityText.ico");
                    }
                    pGroupNode.Nodes.Add(wTreeNodeKey);
                    wTreeNodeKey.ContextMenuStrip = mnGroupOrProperty;
                }
            }
        }
        internal static void LoadGroupFromFile(TreeNode pConfigManagerTreeNode,
            TreeNode wFileNode, XmlDocument doc, ContextMenuStrip mnGroupOrProperty)
        {
            foreach (XmlNode oGrup in doc.SelectSingleNode("Groups").ChildNodes)
            {
                TreeNode wtvGroupNode = new TreeNode(oGrup.Attributes["name"].Value);
                wtvGroupNode.Text = oGrup.Attributes["name"].Value;
                wtvGroupNode.ImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
                wtvGroupNode.SelectedImageIndex = pConfigManagerTreeNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
                wtvGroupNode.ContextMenuStrip = mnGroupOrProperty;
                
                Group wGroup = new Group(wFileNode.Text);
                wGroup.Name = wtvGroupNode.Text;
                wtvGroupNode.Tag = wGroup;

                wFileNode.Nodes.Add(wtvGroupNode);

                ConfigManagerEngine.SetKeyRepetidos(oGrup);
                
                LoadKeysFromGroup(wtvGroupNode, oGrup, mnGroupOrProperty, pConfigManagerTreeNode.TreeView.ImageList);
            }
        }

        /// <summary>
        /// Cambia el valor de una Key
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        /// <param name="pKeyNode">Tree node que reprecenta la Key de configuración</param>
        /// <returns>XmlNode de la key </returns>
        internal static XmlNode ChangeKeyValue(TreeNode pKeyNode)
        {
            TreeNode wTreeNodeFileNode = pKeyNode.Parent.Parent;
            ListDictionary dic = (ListDictionary) wTreeNodeFileNode.Tag;
            //"Groups"
            XmlNode xmlGroups = (XmlNode) dic["FileContent"];

            dic["Saved"] = false;

            Key wKey = (Key) pKeyNode.Tag;
  
            StringBuilder sbXPath = new StringBuilder("Group[@name='");
            sbXPath.Append(wKey.GroupName);
            sbXPath.Append("']/Key[@name='");
            sbXPath.Append(pKeyNode.Text);
            sbXPath.Append("']");

            XmlNode wXmlNodeValueNew = xmlGroups.SelectSingleNode(sbXPath.ToString()).SelectSingleNode("Value").Clone();

            wXmlNodeValueNew.InnerText = String.Empty;
            FwkXml.CData.CDATASectionCreateAndAdd(wXmlNodeValueNew, wKey.Value);

            xmlGroups.SelectSingleNode(sbXPath.ToString()).RemoveChild(
                xmlGroups.SelectSingleNode(sbXPath.ToString()).SelectSingleNode("Value"));

            xmlGroups.SelectSingleNode(sbXPath.ToString()).AppendChild(wXmlNodeValueNew);

            return xmlGroups.SelectSingleNode(sbXPath.ToString());
        }

        /// <summary>
        /// Cambia el nombre de una Key
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        /// <param name="pGroupName">Grupo padre de la Key</param>
        /// <param name="pNewPropertyName">Nuevo nombre</param>
        /// <param name="pOldPropertyName">Nombre actual</param>
        public static void ChangeKeyName(TreeNode pKeyNode, String pOldKeyName)
        {

            TreeNode wFileNode = pKeyNode.Parent.Parent;
            Key wKey = (Key)pKeyNode.Tag;
            pKeyNode.Text = wKey.Name;

            ListDictionary dic = (ListDictionary)wFileNode.Tag;
            //"Groups"
            XmlNode xmlGroups = (XmlNode)dic["FileContent"];
            dic["Saved"] = false;

            StringBuilder sbXPath = new StringBuilder("Group[@name='");
            sbXPath.Append(wKey.GroupName);
            sbXPath.Append("']/Key[@name='");
            sbXPath.Append(pOldKeyName);
            sbXPath.Append("']");

            XmlNode OldPropertyNode = xmlGroups.SelectSingleNode(sbXPath.ToString());

            FwkXml.NodeAttribute.AttributeSet(OldPropertyNode, "name", wKey.Name);

        }

        /// <summary>
        /// Cambia el nombre de una key
        /// </summary>
        /// <param name="pKeyNode">XmlNode perteneciente  a la Key</param>
        /// <param name="pNewKeyName">Nuevo nombre de la key</param>
        internal static void ChangeKeyName(XmlNode pKeyNode, String pNewKeyName)
        {
            FwkXml.NodeAttribute.AttributeSet(pKeyNode, "name", pNewKeyName);
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
            XmlNode xmlGroups = (XmlNode)dic["FileContent"];
            dic["Saved"] = false;


            StringBuilder sbXPath = new StringBuilder("Group[@name='");
            sbXPath.Append(pGroupName);
            sbXPath.Append("']/Key[@name='");
            sbXPath.Append(pKeyName);
            sbXPath.Append("']");

            XmlNode PropertyNode = xmlGroups.SelectSingleNode(sbXPath.ToString());
            xmlGroups.SelectSingleNode("Group[@name='" + pGroupName + "']").RemoveChild(PropertyNode);
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
           String pGroupName,
           String pKeyName,
            String pKeyValue,
           ContextMenuStrip mnGroupOrProperty
           )
        {
            Int32 wIndex;

            #region Seleccion de Groups Node
            
            Helper.TreeNodeExist(pFileNode, pGroupName, out wIndex);

            TreeNode pTreeNodeGroup = pFileNode.Nodes[wIndex];

            if (Helper.TreeNodeExist(pTreeNodeGroup, pKeyName))
            {
                MessageBox.Show("Already exist a key witch this name", "Duplicated key");
                return;
            }

            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            XmlNode xmlGroups = (XmlNode)dic["FileContent"];
            dic["Saved"] = false;

            XmlNode xmlGroupNode = xmlGroups.SelectSingleNode("Group[@name='" + pGroupName + "']");

            #endregion

            #region Crea Key
            XmlNode wKeyXmlNode = FwkXml.Node.NodeCreateAndAdd(xmlGroupNode, "Key");

            FwkXml.NodeAttribute.AttributeCreateAndSet(xmlGroups.OwnerDocument, wKeyXmlNode, String.Empty, "name", pKeyName);
            FwkXml.NodeAttribute.AttributeCreateAndSet(xmlGroups.OwnerDocument, wKeyXmlNode, String.Empty, "encrypted", "False");

            #endregion

            #region Crea Value de la Key
            FwkXml.Node.NodeCreateAndAdd(wKeyXmlNode, "Value", pKeyValue);

            XmlNode wXmlNodeValueNew = wKeyXmlNode.SelectSingleNode("Value").Clone();

            wXmlNodeValueNew.InnerText = String.Empty;
            FwkXml.CData.CDATASectionCreateAndAdd(wXmlNodeValueNew, pKeyValue);

            wKeyXmlNode.RemoveChild(wKeyXmlNode.SelectSingleNode("Value"));

            wKeyXmlNode.AppendChild(wXmlNodeValueNew);
            #endregion

            #region Crea la Key a nivel del TreeView

            TreeNode wKeyTreeNode = new TreeNode(pKeyName);


            wKeyTreeNode.SelectedImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("PushpinHS.png");
            wKeyTreeNode.ImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("UtilityText.ico");

            wKeyTreeNode.ContextMenuStrip = mnGroupOrProperty;

            Key wKey = new Key(pKeyName, pGroupName, pFileNode.Text);
            wKey.Value = pKeyValue;

            wKey.Value = pKeyValue;
            wKeyTreeNode.Tag = wKey;


            pFileNode.TreeView.SelectedNode.Nodes.Add(wKeyTreeNode);

            #endregion

        }
        #endregion

        #region [Group]

        /// <summary>
        /// Cambia el nombre del grupo
        /// </summary>
        /// <param name="pTreeNodeGroupNode">TreeNode perteneciente al grupo</param>
        internal static void ChangeGroupName(TreeNode pTreeNodeGroupNode)
        {
            Group wGroup = (Group)pTreeNodeGroupNode.Tag;
            TreeNode wFileNode = pTreeNodeGroupNode.Parent;

            ListDictionary dic = (ListDictionary)wFileNode.Tag;
            //"Groups"
            XmlNode xmlGroups = (XmlNode)dic["FileContent"];
            dic["Saved"] = false;

            XmlNode xmlGroupNode = xmlGroups.SelectSingleNode("Group[@name='" + pTreeNodeGroupNode.Text + "']");

            FwkXml.NodeAttribute.AttributeSet(xmlGroupNode, "name", wGroup.Name);

            pTreeNodeGroupNode.Text = wGroup.Name;
        }

        /// <summary>
        /// Elimina un grupo
        /// </summary>
        /// <param name="pFileNode">Nodo que reprecenta el archivo ConfigurationManager.xml</param>
        /// <param name="pGroupName">Nombre de grupo</param>
        internal  static void RemoveGroup(TreeNode pFileNode, String pGroupName)
        {

            ListDictionary dic = (ListDictionary)pFileNode.Tag;
            //"Groups"
            XmlNode xmlGroups = (XmlNode)dic["FileContent"];
            dic["Saved"] = false;
            xmlGroups.RemoveChild(xmlGroups.SelectSingleNode("Group[@name='" + pGroupName + "']"));

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


            if (Helper.TreeNodeExist(pFileNode, pGroupName))
            {
                MessageBox.Show("Already exist a group witch this name", "Duplicated group");
                return;
            }


            ListDictionary dic = (ListDictionary) pFileNode.Tag;
            //"Groups"
            XmlNode xmlGroups = (XmlNode) dic["FileContent"];
            dic["Saved"] = false;

            XmlNode xmlGroupNode = FwkXml.Node.NodeCreateAndAdd(xmlGroups, "Group");
            FwkXml.NodeAttribute.AttributeCreateAndSet(xmlGroups.OwnerDocument, xmlGroupNode, String.Empty, "name", pGroupName);
            

            TreeNode wtvGroupNode = new TreeNode(pGroupName);
            wtvGroupNode.ImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
            wtvGroupNode.SelectedImageIndex = pFileNode.TreeView.ImageList.Images.IndexOfKey("ShowAllCommentsHS.png");
            wtvGroupNode.ContextMenuStrip = mnGroupOrProperty;
            Group wGroup = new Group(pFileNode.Text);
            wtvGroupNode.Tag = wGroup;
            pFileNode.Nodes.Add(wtvGroupNode);

        }

    

        #endregion

        internal static void Dispose()
        {
            ConfigManagerEngine.DisposeHolder();
        }
    }
}
