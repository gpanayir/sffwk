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
    internal class ReferenceFile :Fwk.Bases.Entity
    {
        /// <summary>
        /// BigBang.BackEnd.Campaing.BC.csproj.user
        /// </summary>
        string filename;

        public string Filename
        {
            get { return filename; }
            set { filename = value; }
        }
 

        public string PrjName
        {
            get {

               
               return System.IO.Path.GetFileName(filename).Replace(".csproj.user", string.Empty);

            }
       
        }
        

        public string PrjPath
        {
            get
            {

             
                return System.IO.Path.GetFullPath(filename);

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
        bool fileExist = false;

        public bool FileExist
        {
            get { return fileExist; }
            set { fileExist = value; }
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
    }

    
    internal class ReferenceFileList : Fwk.Bases.Entities<ReferenceFile>
    {
        public static event EventHandler FinalizeEvent;



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
                wReferenceFile.Filename = string.Concat(file, ".user");
                if (File.Exists(wReferenceFile.Filename))
                {

                  
                    wReferenceFile.FileExist = true;
                    
                }
              
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
                   if (wReferenceFile.FileExist)
                    {
                       doc = new XmlDocument();

                        doc.Load(wReferenceFile.Filename);
                        XmlNamespaceManager nsManager = new XmlNamespaceManager(doc.NameTable);
                        nsManager.AddNamespace("x", doc.DocumentElement.NamespaceURI);

                        XmlNode wXmlNodeReferencePath = doc.DocumentElement.SelectSingleNode(@"//x:PropertyGroup/x:ReferencePath", nsManager);

                        wXmlNodeReferencePath.InnerText = referencesToAdd;
                        doc.Save(wReferenceFile.Filename);
                        doc = null;
                    }
                    else
                    {
                        templateContentProject.PropertyGroup.ReferencePath = referencesToAdd;
                        Fwk.HelperFunctions.FileFunctions.SaveTextFile(wReferenceFile.Filename, templateContentProject.GetXml().Replace("q1:", string.Empty).Replace(":q1", string.Empty));
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


        internal static void Start(string rootPath,List<Reference> list)
        {
            ReferenceFileList wReferenceFileList = ReferenceFileList.GetFromPath(rootPath);

            wReferenceFileList.AppendReferences(list);

            FinalizeEvent(wReferenceFileList, new EventArgs());
        }
    }
}
