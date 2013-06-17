using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using EasyDirectoryReplace;
using Fwk.HelperFunctions;

namespace EasyDirectorySilenceMover
{
    class Program
    {
       
        static void Main(string[] args)
        {
            //ReplacePaternList s = new ReplacePaternList();
            //ReplacePattern p = new ReplacePattern();
            //p.From = @"d:\SourceTest\";
            //    p.To     = @"d:\SourceTest2\";
            //    s.Add(p);
            //    FileFunctions.SaveTextFile("setting.xml", s.GetXml(), true);
             Engine wEngine = new Engine();
             wEngine.Start();
             Console.WriteLine("Proceso de backup finalizado");
             Console.Read();
        }
    }


    internal class Engine
    {
        string logFileFullName= String.Empty;

        bool validateRes = true;
        public Engine()
        {
            logFileFullName = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "{0}_LogFile.xml");
        }

        internal void Start()
        {
            ReplacePaternList list = null;
            try
            {
                string xmlSetting = Fwk.HelperFunctions.FileFunctions.OpenTextFile("setting.xml");

                list = ReplacePaternList.GetFromXml<ReplacePaternList>(xmlSetting);
            }
            catch (Exception ex)
            {

                Log(String.Concat("Problemas al cargar  setting: /r/n", ex.Message), true);
                validateRes = false;
            }

            if (validateRes)
            {
                foreach (ReplacePattern patthern in list)
                {
                    Log("------------------------------------------------------------------------",false);
                    if (Directory.Exists(patthern.From) == false)
                    {
                        Log(String.Concat("Ruta From no existe: ", patthern.From), true);
                        validateRes = false;
                    }

                    if (Directory.Exists(patthern.To) == false)
                    {
                        Log(String.Concat("Ruta To no existe: ", patthern.To), true);
                        validateRes = false;
                    }
                    if (validateRes)
                    {
                        DoWork(patthern);
                    }
                    validateRes = true;
                    
                }
            }


        }


        void DoWork(ReplacePattern patthern)
        {

            DirectoryInfo subDirSource = new DirectoryInfo(patthern.From);
            String subDestination = Path.Combine(patthern.To, subDirSource.Name);

            Log("Iinicio proceso de copia",false);
            Copy(subDirSource, subDestination);

            DirectoryInfo subDirDestination = new DirectoryInfo(subDestination);
            subDestination = Path.Combine(patthern.From, subDirSource.Name);

            Log("Iinicio proceso de check archivos eliminados", false);
            DirectoryInfo[] wSubDirectories = subDirDestination.GetDirectories("*", SearchOption.TopDirectoryOnly);
            foreach (DirectoryInfo subDirTo in wSubDirectories)
            {
                RemoveInExistents(subDirSource, subDirTo);
            }
            
        }

        void Copy(DirectoryInfo dirSource, String destinationRoot)
        {
            Log("copiando dir : " + dirSource.FullName, false);
            if (Directory.Exists(destinationRoot) == false)
                Directory.CreateDirectory(destinationRoot);
            FileInfo[] wFiles = dirSource.GetFiles("*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo f in wFiles)
            {
                f.CopyTo(Path.Combine(destinationRoot, f.Name), true);
            }
            String[] wSubDirectories = Directory.GetDirectories(dirSource.FullName, "*", SearchOption.TopDirectoryOnly);
            foreach (string dir in wSubDirectories)
            {
                DirectoryInfo subDirSource = new DirectoryInfo(dir);
                String subDestination = Path.Combine(destinationRoot, subDirSource.Name);
                Copy(subDirSource, subDestination);
            }
        }



        void RemoveInExistents(DirectoryInfo dirSource, DirectoryInfo dirTo)
        {
            string root = GetRoot(dirSource, dirTo);

            if (Directory.Exists(root) == false)
            {
                Directory.Delete(dirTo.FullName);
                return;
            }


            FileInfo[] wFiles = dirTo.GetFiles("*", SearchOption.TopDirectoryOnly);

            foreach (FileInfo f in wFiles)
            {
                if(!File.Exists(Path.Combine(root, f.Name)))
                {
                    f.Delete();
                }

            }

            DirectoryInfo[] wSubDirectories = dirTo.GetDirectories("*", SearchOption.TopDirectoryOnly);
            foreach (DirectoryInfo subDirTo in wSubDirectories)
            {
               
                 root = GetRoot(dirSource, subDirTo);

                 if (Directory.Exists(root) == false)
                 {

                     RemoveRecursive(subDirTo);

                 }
                 else
                 {
                     RemoveInExistents(dirSource, subDirTo);
                 }
            }
        }
        void RemoveRecursive(DirectoryInfo subDirTo )
        {
            foreach (FileInfo f in subDirTo.GetFiles("*", SearchOption.TopDirectoryOnly))
            {
                   f.Delete();
            }
            DirectoryInfo[] wSubDirectories = subDirTo.GetDirectories("*", SearchOption.TopDirectoryOnly);
            foreach (DirectoryInfo d in wSubDirectories)
            {
                RemoveRecursive(d);
            }
            subDirTo.Delete();
        }
        string GetRoot(DirectoryInfo dirSource, DirectoryInfo subDirTo)
        {
            int index = subDirTo.FullName.IndexOf(dirSource.Name);
            string root = subDirTo.FullName.Substring(index, subDirTo.FullName.Length - index);

            root = Path.Combine(dirSource.Parent.FullName, root);

            return root;
        }


        


        void Log(string msg, bool logOnFile)
        {
            if (logOnFile)
            {
                string filename = string.Format(logFileFullName, FileFunctions.Get_Year_Mont_Day_String(DateTime.Now, '-'));

                StringBuilder str = new StringBuilder();
                str.AppendLine("--------------------------------------------------------------------------------------------------");
                str.AppendLine(String.Concat("DATE: ", System.DateTime.Now.ToString()));
                str.AppendLine();
                str.AppendLine(msg);

                str.AppendLine("--------------------------------------------------------------------------------------------------");

                FileFunctions.SaveTextFile(filename, str.ToString(), true);
            }

            Console.WriteLine(msg);
        }
    }
}
