using System;
using System.Xml;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Diagnostics;

namespace CodeGenerator
{
    public class CodeGeneratorCommon
    {
        

        public static string OpenTextFile(string pPath)
        {
            FileStream fs = null;
            StreamReader sr = null;
            try
            {
                fs = new FileStream(pPath, FileMode.Open, FileAccess.Read);
                sr = new StreamReader(fs);
                return sr.ReadToEnd();
            }
            catch (System.IO.DirectoryNotFoundException )
            {
                throw new Exception("Acegurece que esten los templates completos donde se encuentra el ejecutable de la aplicacion");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //finally
            //{
            //    fs.Close();
            //    sr.Close();
            //}
        }



        public enum SelectedObject
        {
            Tables = 0,
            StoreProcedures = 1,
            Schema = 2
        }
        public enum TemplateType
        {
            StoreProcedure = 0,
            DataAccesComponent = 1,
            BussinesEntity = 2,
            Namespaces = 3
        }
        public static Boolean ValidateFileByExtencion(string pExtencion, string pFullNemeFile)
        {
            if (!System.IO.File.Exists(pFullNemeFile)) return false;
            if (pFullNemeFile.Length > 3)
            {
                if (pFullNemeFile.Substring(pFullNemeFile.Length - 3, 3).ToLower() != pExtencion.ToLower()) return false;
            }
            else
                return false;

            return true;

        }

        public static void CreateEventLog()
        {
            String Source = "CodeGenerator";
            if (!EventLog.SourceExists(Source, Environment.MachineName))
            {
                EventLog.CreateEventSource(Source, Source);
            }

        }

        public static void WriteEntryEventLog(String pMessage, Exception pException, int pEventID,EventLogEntryType pEventLogEntryType)
        {
            String LogName = "CodeGenerator";

            // Insert into event log
            EventLog Log = new EventLog();
            Log.Source = LogName;

            pMessage += Environment.NewLine + GetAllMessageException(pException);
            Log.WriteEntry(pMessage, pEventLogEntryType,pEventID);

        }

        public static String GetAllMessageException(Exception ex)
        {
            StringBuilder wMessage = new StringBuilder();
            wMessage.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                wMessage.Append(ex.Message);
            }
            return wMessage.ToString();
        }

    }


   
}
