using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using System.IO;
using System.Xml.Serialization;
using System.Xml;



namespace Fwk.GuidPk
{
    public delegate void SelectElementHandler(object e);
    public delegate void AfterCheckHandler();
    /// <summary>
    /// 
    /// </summary>
    public class TreeViewHelper
    {


       

        #region Tables
        /// <summary>
        /// Carga el arbol con todas las tablas .- 
        /// </summary>
        /// <param name="pTreeView">Nodo</param>
        /// <param name="pTables">Tablas</param>
        public static void LoadTreeView(TreeView pTreeView, TableCollection pTables)
        {
            TreeNode wTreeNode;
            pTreeView.Nodes.Clear();    
            foreach (Table wTable in pTables)
            {
                wTreeNode = new TreeNode();
                wTreeNode.Checked = false;
                
                wTreeNode.Text = wTable.Name;
                wTreeNode.Tag = wTable;
                pTreeView.Nodes.Add(wTreeNode);
                //LoadColumnsNodes(wTreeNode, wTable);

                
            }
           
        }

        /// <summary>
        /// Carga las coluimnas al nodo pParentNode.-
        /// </summary>
        /// <param name="pParentNode">Nodo padre </param>
        /// <param name="pTable"></param>
        internal static void LoadColumnsNodes(TreeNode pParentNode, Table pTable)
        {
            TreeNode wTreeNode;
            foreach (Column wColumn in pTable.Columns)
            {

                String nullable = wColumn.Nullable ? "NULL" : String.Empty;

                wTreeNode = new TreeNode();
         
                wTreeNode.Checked = false;
                wTreeNode.Text = string.Concat(wColumn.Name, " ", wColumn.DataType.Name, " ", nullable);
                //wTreeNode.Tag = wColumn;
                wTreeNode.ImageIndex = 3;
                wTreeNode.SelectedImageIndex = 3;
                pParentNode.Nodes.Add(wTreeNode);
            }
        }

       

        #endregion

        //#region Store Procedures
        ///// <summary>
        ///// Carga el arbol con todas los Store Procedures .- 
        ///// </summary>
        ///// <param name="pTreeView">Nodo</param>
        ///// <param name="pStoreProcedures">StoreProcedures</param>
        //public static void LoadTreeView(TreeView pTreeView, Fwk_DataEntities.StoreProcedures pStoreProcedures)
        //{
        //    pTreeView.Nodes.Clear();
        //    foreach (Fwk_DataEntities.StoreProcedure wStoreProcedure in pStoreProcedures)
        //    {
        //        TreeNode wTreeNode = new TreeNode();
        //        wTreeNode.Checked = false;

        //        wTreeNode.Text = wStoreProcedure.Name;
        //        pTreeView.Nodes.Add(wTreeNode);
        //        LoadParameteresNodes(wTreeNode, wStoreProcedure);

        //        OnAddElementEvent();
        //    }

        //}

        ///// <summary>
        ///// Carga los parametros al nodo pParentNode  (StoreProcedure).-
        ///// </summary>
        ///// <param name="pParentNode">Nodo padre </param>
        ///// <param name="pStoreProcedure">Store Procedure</param>
        //private static void LoadParameteresNodes(TreeNode pParentNode, Fwk_DataEntities.StoreProcedure pStoreProcedure)
        //{

        //    foreach (Fwk_DataEntities.SPParameter wParameter in pStoreProcedure.Parameters)
        //    {
        //        TreeNode wTreeNode = new TreeNode();
        //        wTreeNode.Checked = false;
        //        wTreeNode.Text = wParameter.Type + " " + wParameter.Name;
        //        wTreeNode.Tag = wParameter.Name;
        //        wTreeNode.ImageIndex = 5;
        //        wTreeNode.SelectedImageIndex = 5;
        //        pParentNode.Nodes.Add(wTreeNode);
        //    }
        //}

        //internal static void FillParameters(TreeNode pTreeNodePadre, Fwk.DataBase.DataEntities.StoreProcedure pStoreProcedure)
        //{
        //    if (pStoreProcedure.IsParametersLoaded) return;

        //    Fwk_DataBase.Metadata wMetadata = new Metadata();

        //    wMetadata.StoreProcedures_FillParameters(pStoreProcedure);

        //    LoadParameteresNodes(pTreeNodePadre, pStoreProcedure);

        //}

        //#endregion


    

        /// <summary>
        /// Agrega un nodo a un nodo padre con información sobre una tabla relacionada a la que éste representa.
        /// </summary>
        /// <param name="pParentNode">Nodo padre.</param>
        /// <param name="pText">Texto a mostrar.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        private static TreeNode AddChildNode(TreeNode pParentNode, string pText)
        {
            TreeNode wTreeNode = new TreeNode(pText);

            wTreeNode.Checked = false;
            wTreeNode.Tag = pText;
            pParentNode.Nodes.Add(wTreeNode);

            return wTreeNode;
        }




        /// <summary>
        /// Destilda los nodos hijos de un nodo padre.
        /// </summary>
        /// <param name="pNode">Nodo padre.</param>
        /// <date>2006-04-05T00:00:00</date>
        /// <author>Marcelo Oviedo</author>
        public static void UncheckChildNodes(TreeNode pNode)
        {
            Boolean Checked = pNode.Checked;

            foreach (TreeNode wNode in pNode.Nodes)
            {
                wNode.Checked = pNode.Checked;
                UncheckChildNodes(wNode);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ParentNode"></param>
        /// <returns></returns>
        public static bool HasSelectedNodes(TreeNode ParentNode)
        {
            Boolean wCheck = false;
            foreach (TreeNode child in ParentNode.Nodes)
            {
                if (child.Checked) wCheck = true;
            }

            return wCheck;
        }
    }



    internal static class HelperFunctions
    {
        #region -- Xml Serialization using Xml --

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObjType"></param>
        /// <param name="pXmlData"></param>
        /// <returns></returns>
        public static object Deserialize(Type pObjType, string pXmlData)
        {
            XmlSerializer wSerializer;
            UTF8Encoding wEncoder = new UTF8Encoding();
            MemoryStream wStream = new MemoryStream(wEncoder.GetBytes(pXmlData));

            wSerializer = new XmlSerializer(pObjType);
            return wSerializer.Deserialize(wStream);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObjType"></param>
        /// <param name="pXmlData"></param>
        /// <param name="pXPath"></param>
        /// <returns></returns>
        public static object Deserialize(Type pObjType, string pXmlData, string pXPath)
        {
            XmlDocument wDom = new XmlDocument();
            wDom.LoadXml(pXmlData);
            return Deserialize(pObjType, wDom.DocumentElement.SelectSingleNode(pXPath).OuterXml);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pTipo"></param>
        /// <param name="pXml"></param>
        /// <returns></returns>
        public static object DeserializeFromXml(Type pTipo, string pXml)
        {
            XmlSerializer wSerializer;
            StringReader wStrSerializado = new StringReader(pXml);
            XmlTextReader wXmlReader = new XmlTextReader(wStrSerializado);
            //XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();
            object wResObj = null;

            //wNameSpaces.Add(String.Empty, String.Empty);
            wSerializer = new XmlSerializer(pTipo);
            wResObj = wSerializer.Deserialize(wXmlReader);

            return wResObj;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pObj"></param>
        /// <returns></returns>
        public static string SerializeToXml(object pObj)
        {
            XmlSerializer wSerializer;
            StringWriter wStwSerializado = new StringWriter();
            XmlTextWriter wXmlWriter = new XmlTextWriter(wStwSerializado);
            XmlSerializerNamespaces wNameSpaces = new XmlSerializerNamespaces();

            wXmlWriter.Formatting = Formatting.Indented;
            wNameSpaces.Add(String.Empty, String.Empty);

            wSerializer = new XmlSerializer(pObj.GetType());
            wSerializer.Serialize(wXmlWriter, pObj, wNameSpaces);


            return wStwSerializado.ToString().Replace("<?xml version=\"1.0\" encoding=\"utf-16\"?>", String.Empty);
        }

        /// <summary>
        /// Serializa un objeto.
        /// </summary>
        /// <param name="pObj">Objeto a serializar</param>
        /// <returns>Representación en XML del objeto</returns>
        public static string Serialize(object pObj)
        {
            return Serialize(pObj, false);
        }

        /// <summary>
        /// Serializa un objeto.
        /// </summary>
        /// <param name="pObj">Objeto a serializar</param>
        /// <param name="pRemoveDeclaration">Indica si se debe remover el nodo de declaración</param>
        /// <returns>Representación en XML del objeto</returns>
        public static string Serialize(object pObj, bool pRemoveDeclaration)
        {
            XmlDocument wDoc = new XmlDocument();
            wDoc.Load(GetStream(pObj));

            if (pRemoveDeclaration && wDoc.ChildNodes.Count > 0 && wDoc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                wDoc.RemoveChild(wDoc.FirstChild);
            }

            return wDoc.InnerXml;
        }


        /// <summary>
        /// Devuelve un stream formado a partir del objeto enviado por parámetro.
        /// </summary>
        /// <param name="pObj">Objeto para extraer stream</param>
        /// <returns>MemoryStream</returns>
        public static MemoryStream GetStream(object pObj)
        {
            XmlSerializer wSerializer;
            MemoryStream wStream = new MemoryStream();

            wSerializer = new XmlSerializer(pObj.GetType());
            wSerializer.Serialize(wStream, pObj);

            wStream.Position = 0;

            return wStream;
        }

        #endregion

        /// <summary>
        /// Genera un string con el contenido del InnerException .-
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        internal static String GetAllMessageException(Exception ex)
        {

            StringBuilder wMessage = new StringBuilder();
            wMessage.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                wMessage.AppendLine("Source: ");
                wMessage.AppendLine(ex.Source);
                wMessage.AppendLine();
                wMessage.AppendLine("Message: ");
                wMessage.AppendLine(ex.Message);
            }
            return wMessage.ToString();
        }

        /// <summary>
        /// Abre un archivo de texto
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <returns></returns>
        internal static string OpenTextFile(string pFileName)
        {
            using (StreamReader sr = File.OpenText(pFileName))
            {
                string retString = sr.ReadToEnd();
                sr.Close();

                return retString;
            }

        }

        /// <summary>
        /// Agrega el texto a un archivo. Si el archivo no existe, este método crea uno nuevo. 
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <param name="pContent">Contenido del archivo</param>
        /// <param name="pAppend">Determina si se van a agregar datos al archivo. 
        /// Si ya existe el archivo y append es false, el archivo se sobrescribirá. 
        /// Si ya existe el archivo y append es true, los datos se anexarán al archivo. De lo contrario, se crea un nuevo archivo. 
        /// </param>
        public static void SaveTextFile(string pFileName, string pContent, bool pAppend)
        {
            using (StreamWriter sw = new StreamWriter(pFileName, pAppend))
            {
                sw.Write(pContent);
                sw.Close();
            }
        }
        internal static string ProgramFilesx86()
        {
            if (8 == IntPtr.Size
                || (!String.IsNullOrEmpty(Environment.GetEnvironmentVariable("PROCESSOR_ARCHITEW6432"))))
            {
                return Environment.GetEnvironmentVariable("ProgramFiles(x86)");
            }

            return Environment.GetEnvironmentVariable("ProgramFiles");
        }

        internal static EnvDTE.Project GetDTE_SelectedProject(EnvDTE.Solution solution)
        {
            EnvDTE.Project project = null;
            EnvDTE.SelectedItems wSelectedItems = ((EnvDTE.SelectedItems)((EnvDTE.Projects)solution.Projects).DTE.SelectedItems);

            if (wSelectedItems.Item(1).ProjectItem != null)
            {
                project = ((EnvDTE.Project)wSelectedItems.Item(1).ProjectItem.ContainingProject);

            }

            if (wSelectedItems.Item(1).Project != null)
            {
                project = wSelectedItems.Item(1).Project;
            }
            return project;
        }

        /// <summary>
        /// ReferencePath
        ///PreBuildEvent
        ///Copyright
        ///ApplicationIcon
        ///ExcludedPermissions
        ///RunPostBuildEvent
        ///DefaultTargetSchema
        ///RootNamespace
        ///ManifestTimestampUrl
        ///ManifestKeyFile
        ///DebugSecurityZoneURL
        ///Product
        ///PostBuildEvent
        ///OptionStrict
        ///DefaultHTMLPageLayout
        ///DelaySign
        ///OutputType
        ///NeutralResourcesLanguage
        ///OptionExplicit
        ///OutputFileName
        ///ServerExtensionsVersion
        ///AssemblyGuid
        ///GenerateManifests
        ///AssemblyVersion
        ///Win32ResourceFile
        ///Description
        ///URL
        ///DefaultClientScript
        ///TargetFrameworkSubset
        ///TargetFramework
        ///SignManifests
        ///OfflineURL
        ///WebServerVersion
        ///Publish
        ///AssemblyType
        ///FullPath
        ///WebAccessMethod
        ///AssemblyKeyProviderName
        ///TypeComplianceDiagnostics
        ///Company
        ///ActiveFileSharePath
        ///AssemblyOriginatorKeyFile
        ///ApplicationManifest
        ///AssemblyFileVersion
        ///AspnetVersion
        ///FileSharePath
        ///AssemblyName
        ///LocalPath
        ///DefaultNamespace
        ///LinkRepair
        ///TargetZone
        ///SignAssembly
        /// </summary>
        /// <param name="project"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        internal static EnvDTE.Property GetDTEProperty(EnvDTE.Project project, string propertyName)
        {

            EnvDTE.Properties wProperties = ((EnvDTE.Properties)project.Properties);

            return GetDTEProperty(wProperties, propertyName); ;
        }

        /// <summary>
        /// ExtenderCATID
        ///ProjectDependencies
        ///Extender
        ///ActiveConfig
        ///Path
        ///ExtenderNames
        ///Description
        ///Name
        ///StartupProject
        /// </summary>
        /// <param name="solution"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        internal static EnvDTE.Property GetDTEProperty(EnvDTE.Solution solution, string propertyName)
        {

            EnvDTE.Properties wProperties = ((EnvDTE.Properties)solution.Properties);
            return GetDTEProperty(wProperties, propertyName);
        }

        internal static EnvDTE.Property GetDTEProperty(EnvDTE.Properties pProperties, string propertyName)
        {
            StringBuilder str = new StringBuilder();
            EnvDTE.Property prop = null;
            foreach (EnvDTE.Property p in pProperties)
            {
                str.AppendLine(p.Name);
                if (p.Name.Equals(propertyName, StringComparison.InvariantCultureIgnoreCase))
                {
                    prop = ((EnvDTE.Property)pProperties.Item(propertyName));
                    break;
                }
            }

            return prop;
        }
        internal static EnvDTE.Project GetDTEProject(EnvDTE.Solution solution, string layer)
        {
            EnvDTE.Project prj = null;
            int start = 0;
            layer = string.Concat(".", layer);

            //Recorrido de los proyectos
            for (int i = 1; i <= solution.Projects.Count; i++)
            {
                prj = (EnvDTE.Project)solution.Projects.Item(i);
                //tomo el punto de inicio de la comparacion que es:
                // desde el final del nombre del proyecto 
                // hasta la cantiad de letras de "layer" (SVC, ISVC, etc) mas el punto .-
                start = prj.Name.Length - layer.Length;
                //Comparo si el final del nombre del proyecto es igual a .layer (ej: .ISVC)
                if (prj.Name.Substring(start, layer.Length).Equals(layer, StringComparison.OrdinalIgnoreCase))
                    break;
            }

            return prj;
        }
    }

}
