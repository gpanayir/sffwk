using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;
using Fwk.Logging;
using System.Drawing;
using ProjectReferencesCreator.Properties;

namespace ProjectReferencesCreator
{
    [Serializable]
    public class ReferenceFile : Fwk.Bases.Entity
    {
        /// <summary>
        /// BigBang.BackEnd.Campaing.BC.csproj.user
        /// </summary>
        string userFilename;

        public string UserFilename
        {
            get { return userFilename; }
            set { userFilename = value; }
        }
        string csprojFilename;

        public string CsprojFilename
        {
            get { return csprojFilename; }
            set { csprojFilename = value; }
        }
 


        public string PrjName
        {
            get {


                return System.IO.Path.GetFileName(csprojFilename).Replace(".csproj", string.Empty);

            }
       
        }
        

        public string PrjPath
        {
            get
            {

             
                return System.IO.Path.GetFullPath(csprojFilename);

            }

        }
        Image image = Resources.confirm_16;
        public Image Image
        {
            get
            {
               if (!error) return Resources.confirm_16;
                else return Resources.delete_16;
            }

        }
       
        /// <summary>
        /// 
        /// </summary>
        string xmlcontentProject;

        public string XmlContentProject
        {
            get { return xmlcontentProject; }
            set { xmlcontentProject = value; }
        }
        bool userFileExist = false;

        public bool UserFileExist
        {
            get { return userFileExist; }
            set { userFileExist = value; }
        }
        string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; }
        }

        bool error = false;

        public bool Error
        {
            get { return error; }
            set { error = value; }
        }
        ReferenceType _ReferenceType;

        public ReferenceType ReferenceType
        {
            get { return _ReferenceType; }
            set { _ReferenceType = value; }
        }
        public bool Udated = false;
        
        //public Image UdatedImage
        //{
        //    get
        //    {
        //        if (!error) return Resources.confirm_16;
        //        else return Resources.delete_16;
        //    }

        //}
    }

    public enum ReferenceType
    { 
        Fwk,
        EnterpriseLibrary,
        AllusLibs
    }
    [Serializable]
    public class ReferenceFileList : Fwk.Bases.Entities<ReferenceFile>
    {
         public static event EventHandler FinalizeEvent;
         public static event EventHandler MessagEvent;
         const string VERSION_TEMPLATE = "$ASSEMBLY$, Version=$VERSION$, Culture=neutral, processorArchitecture=MSIL";
         const string EnterpriseLibrary = "Microsoft.Practices.EnterpriseLibrary.";
         const string AllusLibs = "Allus.Libs";

        private static List<string> fwkList;
        

        static ReferenceFileList()
        {
            fwkList = new List<string>();
            fwkList.Add("Fwk.Bases");
            fwkList.Add("Fwk.Security");
            fwkList.Add("Fwk.Bases.Connector");
            fwkList.Add("Fwk.DataBase");
            fwkList.Add("Fwk.Controls.Win32");
            fwkList.Add("Fwk.Bases.FrontEnd");
  
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static ReferenceFileList GetFromPath(string path)
        {
            ReferenceFileList wReferenceFileList = new ReferenceFileList();
            ReferenceFile wReferenceFile;
            ///Archivos de todos los proyectos
            String[] wFiles = Directory.GetFiles(path, "*.csproj", SearchOption.AllDirectories);

            foreach (string file in wFiles)
            {
                wReferenceFile = new ReferenceFile();
                wReferenceFile.CsprojFilename = file;
                wReferenceFile.UserFilename = string.Concat(file, ".user");
                if (File.Exists(wReferenceFile.UserFilename))
                {
                    wReferenceFile.UserFileExist = true;
                }
              
                wReferenceFileList.Add(wReferenceFile);
            }

            return wReferenceFileList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        internal static ReferenceFileList GetFromPath(string path, ReferenceType pReferenceType)
        {
            ReferenceFileList wReferenceFileList = new ReferenceFileList();
            ReferenceFile wReferenceFile;
            ///Archivos de todos los proyectos
            String[] wFiles = Directory.GetFiles(path, "*.csproj", SearchOption.AllDirectories);

            foreach (string file in wFiles)
            {
                wReferenceFile = new ReferenceFile();
                wReferenceFile.CsprojFilename = file;
                wReferenceFile.ReferenceType = pReferenceType;
                
                wReferenceFileList.Add(wReferenceFile);
            }

            return wReferenceFileList;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="list"></param>
        void AppendReferences(List<Reference> list)
        {
            string referencesToAdd = string.Join(";", list.ConvertAll(r => r.Path).ToArray());
            XmlDocument doc;
            Project templateContentProject = new Project();
            foreach(ReferenceFile wReferenceFile in this)
            {
                try
                {
                   if (wReferenceFile.UserFileExist)
                    {
                       doc = new XmlDocument();

                        doc.Load(wReferenceFile.UserFilename);
                        XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                        nsManager.AddNamespace("x", doc.DocumentElement.NamespaceURI);

                        XmlNode wXmlNodeReferencePath = doc.DocumentElement.SelectSingleNode(@"//x:PropertyGroup/x:ReferencePath", nsManager);

                        wXmlNodeReferencePath.InnerText = referencesToAdd;
                        doc.Save(wReferenceFile.UserFilename);
                        doc = null;
                    }
                    else
                    {
                        templateContentProject.PropertyGroup.ReferencePath = referencesToAdd;
                        Fwk.HelperFunctions.FileFunctions.SaveTextFile(wReferenceFile.UserFilename, templateContentProject.GetXml().Replace("q1:", string.Empty).Replace(":q1", string.Empty));
                    }

                }
                catch (Exception ex)
                {


                    //Fwk.Logging.StaticLogger.Log(Fwk.Logging.EventType.Error,
                    //    wReferenceFile.Filename,
                    //    ex.Message, "", "");

                    wReferenceFile.Error = true;
                    wReferenceFile.ErrorMessage = ex.Message;
                    
                }


            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootPath"></param>
        /// <param name="list"></param>
        internal static void StartReferencePatch(string rootPath,List<Reference> list)
        {
            ReferenceFileList wReferenceFileList = ReferenceFileList.GetFromPath(rootPath);

            wReferenceFileList.AppendReferences(list);

            FinalizeEvent(wReferenceFileList, new EventArgs());
        }


        /// <summary>
        /// Actualiza solo las versiones del tipo que se pasa por parametro
        /// </summary>
        /// <param name="rootPath">Ruta origen para actualizar recurcivamente</param>
        /// <param name="newVersion"></param>
        /// <param name="pReferenceType">Tipo de referencia a actuializar</param>
        internal static void StartReferenceVersion(string rootPath, string newVersion, ReferenceType pReferenceType)
        {
            ReferenceFileList wReferenceFileList = ReferenceFileList.GetFromPath(rootPath, pReferenceType);
            
            wReferenceFileList.ChangeReferenceVersions(newVersion, pReferenceType);

            FinalizeEvent(wReferenceFileList, new EventArgs());
        }




        void ChangeReferenceVersions(string newVersion,ReferenceType pReferenceType)
        {
          
            XmlDocument doc;
            Project templateContentProject = new Project();
            
            foreach (ReferenceFile wReferenceFile in this)
            {
               
                try
                {
                        doc = new XmlDocument();
                        doc.Load(wReferenceFile.CsprojFilename);

                        XmlNodeList wXmlNode_ReferenceLiast = GetItemGroup(doc);

                        string assemblyName;
                        foreach (XmlNode xmlNode_Reference in wXmlNode_ReferenceLiast)
                        {
                            ///Si esta referencia es del framework
                            assemblyName = xmlNode_Reference.Attributes["Include"].Value.Split(',')[0];

                            switch (pReferenceType)
                            {
                                case ReferenceType.Fwk:
                                    {
                                        if (fwkList.Exists(p => p.Equals(assemblyName)))
                                        {
                                            Fwk.Xml.NodeAttribute.AttributeSet(xmlNode_Reference, "Include", VERSION_TEMPLATE.Replace("$ASSEMBLY$", assemblyName).Replace("$VERSION$", newVersion));
                                            //(xmlNode_Reference.Attributes["Include"]).Value = "";
                                            wReferenceFile.Udated = true;
                                        }
                                        break;
                                    }
                                case ReferenceType.EnterpriseLibrary:
                                    {
                                        if (assemblyName.Contains(EnterpriseLibrary) )
                                        {
                                            Fwk.Xml.NodeAttribute.AttributeSet(xmlNode_Reference, "Include", VERSION_TEMPLATE.Replace("$ASSEMBLY$", assemblyName).Replace("$VERSION$", newVersion));
                                            wReferenceFile.Udated = true;
                                        }
                                        break;
                                    }
                                case ReferenceType.AllusLibs:
                                    {
                                        if (assemblyName.Contains(AllusLibs))
                                        {
                                            Fwk.Xml.NodeAttribute.AttributeSet(xmlNode_Reference, "Include", VERSION_TEMPLATE.Replace("$ASSEMBLY$", assemblyName).Replace("$VERSION$", newVersion));
                                            wReferenceFile.Udated = true;
                                        }
                                        break;
                                    }
                            }
                        }

                        doc.Save(wReferenceFile.CsprojFilename);
                        doc = null;
                  

                }
                catch (Exception ex)
                {
      
                    wReferenceFile.Error = true;
                    wReferenceFile.Udated = false;
                    wReferenceFile.ErrorMessage = ex.Message;

                }
            }
        }

         XmlNodeList GetItemGroup(XmlDocument doc )
         {
             XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
             nsManager.AddNamespace("x", doc.DocumentElement.NamespaceURI);

             XmlNodeList ItemGroup_NodeList = doc.DocumentElement.SelectNodes(@"//x:ItemGroup", nsManager);


             foreach (XmlNode wXmlNode_ItemGroup in ItemGroup_NodeList)
             {
                 XmlNode wXmlNode_Reference = wXmlNode_ItemGroup.SelectSingleNode(@"//x:Reference", nsManager);
                 if (wXmlNode_Reference != null)
                 {
                     return wXmlNode_ItemGroup.ChildNodes;
                 }

             }
             return null;
         }

    }
}
