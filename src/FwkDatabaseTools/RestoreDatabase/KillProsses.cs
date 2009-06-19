using System;
using System.IO;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Text;

namespace RestoreDatabase
{
    public class KillProceessEngine
    {
        
        private  const string _CnnStringTemplate =  @"Data Source=**Server**;Initial Catalog=master;User ID=**User**;Password=**Password**;";
        
        public static void KillProcess(string wDataBaseName)
        {
            DataTable wDtt = SearchProcess();
            DataRow[] wFilterRows = wDtt.Select("dbname = '" + wDataBaseName.Trim() + "'");

            foreach(DataRow dtr in wFilterRows)
            {
               KillProcessById( dtr["spid"].ToString());

            }

        }
        private static void KillProcessById(string IdProcess)
        {
            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.Text;
                    wCmd.CommandText = "kill " + IdProcess;

                    wCmd.ExecuteNonQuery();

                    wCnn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static DataTable SearchProcess(string wDataBaseName)
        {
            DataTable wDtt = KillProceessEngine.SearchProcess();

            DataRow[] dtrs = wDtt.Select("dbname = '" + wDataBaseName.Trim() + "'");
            DataTable dtt = new DataTable();
            dtt = wDtt.Clone();
            foreach (DataRow wDtrSource in dtrs)
            {
                //DataRow wDtrTarget = dtt.NewRow ();
                dtt.ImportRow(wDtrSource);
            }

            return dtt;

        }
        public static DataTable SearchProcess()
        {
            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                wCnn.StateChange += new StateChangeEventHandler(StateChangeHandler);
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.StoredProcedure;
                    wCmd.CommandText = "sp_who";

                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);
                    DataSet wDs = new DataSet();
                    wDa.Fill(wDs);

                    wCnn.Close();
                    return wDs.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        private static string GetCnnString()
        {
            return System.Configuration.ConfigurationManager.AppSettings["connectionStrings"].ToString();
        }


        public static void RestoreDataBase(string pDataBaseName,string pSourcePatch)
        {
            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                { 
                    wCnn.Open();
                    
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.Text;
                    wCmd.CommandTimeout = 6000;
                  
                    
                    StringBuilder str = new StringBuilder ();
                    str.Append("RESTORE DATABASE ");
                    str.Append("[" + pDataBaseName + "] ");
                    str.Append("FROM  DISK = N");
                    str.Append("'" +pSourcePatch + "' ");
                    str.Append("WITH  FILE = 1,  NOUNLOAD,  REPLACE,  STATS = 10  ");

                    wCmd.CommandText = str.ToString();

                    wCmd.ExecuteNonQuery();

                    wCnn.Close();

                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    if (ex.Number == 3101)
                        throw new Exception("La base de datos que intenta restaurar esta siendo utilizada por otro proceso." + Environment.NewLine + "- Ejecute comando Kill");
                    else
                        throw ex;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public static void BackUpDataBase(string pDataBaseName, string pSourcePatch)
        {
            using (SqlConnection wCnn = new SqlConnection(GetCnnString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.Connection = wCnn;
                    wCmd.CommandType = CommandType.Text;
                    
                    StringBuilder str = new StringBuilder();

                    str.Append("BACKUP DATABASE ");
                    str.Append("[" + pDataBaseName + "]");
                    str.Append("TO  DISK = N");
                    str.Append("'" + pSourcePatch + "' ");
                    str.Append("WITH NOFORMAT, INIT,  NAME = N ");
                    str.Append("'" + pDataBaseName + "-Full Database Backup' , SKIP, NOREWIND, NOUNLOAD,  STATS = 10 GO");

                    wCmd.CommandText = str.ToString();

                    wCmd.ExecuteNonQuery();

                    wCnn.Close();

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }


        public static void StateChangeHandler(object mySender, StateChangeEventArgs myEvent)
        {
            Console.WriteLine("El estado de la conexion cambio de " + myEvent.OriginalState + "a " + myEvent.CurrentState);
        }

        public static void SaveConfig(string pBackUpSource,string pDataBaseName,string pServer,string pUser,string pPassword)
        {
            string wCnnString;
            string _xml = AppDomain.CurrentDomain.BaseDirectory + @"KillProcessConfig.xml";
            DataSet wDts = new DataSet();
            wDts.ReadXml(_xml);

            DataRow[] dtr = wDts.Tables[0].Select("key = 'BackUpSource'");
            dtr[0]["value"] = pBackUpSource;

            dtr = wDts.Tables[0].Select("key = 'connectionStrings'");
            wCnnString = _CnnStringTemplate.Replace("**Server**", pServer);
            wCnnString = wCnnString.Replace("**User**", pUser);
            wCnnString = wCnnString.Replace("**Password**", pPassword);
            dtr[0]["value"] = wCnnString;

            dtr = wDts.Tables[0].Select("key = 'DataBaseName'");
            dtr[0]["value"] = pDataBaseName;

            dtr = wDts.Tables[0].Select("key = 'Server'");
            dtr[0]["value"] = pServer;

            dtr = wDts.Tables[0].Select("key = 'User'");
            dtr[0]["value"] = pUser;

            dtr = wDts.Tables[0].Select("key = 'Password'");
            dtr[0]["value"] = pPassword;


            StreamWriter wFileStream = new StreamWriter(_xml, false, System.Text.Encoding.ASCII);
            wFileStream.Write(wDts.GetXml());
            wFileStream.Close();


        }
        public static DataTable GetConfig()
        {
            string wCnnString;
            string _xml = AppDomain.CurrentDomain.BaseDirectory + @"KillProcessConfig.xml";
            DataSet wDts = new DataSet();
            wDts.ReadXml(_xml);

            return wDts.Tables[0];
        }
    }    

        
}
