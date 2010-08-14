using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Diagnostics;
using Fwk.HelperFunctions;

namespace WindowsLogViewer
{

    public class LogDAC
    {
        public static InsertPool TaskPool = new InsertPool();

        /// <summary>
        /// Retorna la fecha mas nueva
        /// </summary>
        static string SelectLastString = "SELECT  MAX(EventLog.TimeGenerated) LastLogtime FROM EventLog WHERE dbo.EventLog.Winlog = '$Winlog$' AND EventLog.AuditMachineName = '$AuditMachineName$'";
        static string InserLog;

        public static void Insert(EventLogEntryCollection pEventLogList, string pWinlog, string pAuditMachineName)
        {
            DateTime wLastLogtime = SelectLastLog(pWinlog, pAuditMachineName);

            foreach (EventLogEntry l in pEventLogList)
            {
                //Solo insertar logs posteriores o donde l.TimeGenerated posterior a wLastLogtime
                //l.TimeGenerated posterior a wLastLogtime
                if (DateTime.Compare(l.TimeGenerated, wLastLogtime) > 0 || wLastLogtime.CompareTo(Fwk.HelperFunctions.DateFunctions.NullDateTime) == 0)
                    Insert(l, pWinlog, pAuditMachineName);
            }
        }

        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pEventLog">EventLogEntry</param>
        /// <returns>void</returns>
        /// <Date>2010-04-19T19:26:41</Date>
        /// <Author>moviedo</Author>
        public static void Insert(EventLogEntry pEventLog, string pWinlog, string pAuditMachineName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("log");
                wCmd = wDataBase.GetStoredProcCommand("EventLog_i");

                wDataBase.AddInParameter(wCmd, "EventGuid", System.Data.DbType.Guid, Guid.NewGuid());

                wDataBase.AddInParameter(wCmd, "Message", System.Data.DbType.String, pEventLog.Message);
                wDataBase.AddInParameter(wCmd, "Winlog", System.Data.DbType.String, pWinlog);
                wDataBase.AddInParameter(wCmd, "AuditMachineName", System.Data.DbType.String, pAuditMachineName);

                wDataBase.AddInParameter(wCmd, "EventID", System.Data.DbType.Decimal, pEventLog.InstanceId);

                wDataBase.AddInParameter(wCmd, "Category", System.Data.DbType.String, pEventLog.Category);

                wDataBase.AddInParameter(wCmd, "MachineName", System.Data.DbType.String, pEventLog.MachineName);

                wDataBase.AddInParameter(wCmd, "Source", System.Data.DbType.String, pEventLog.Source);

                wDataBase.AddInParameter(wCmd, "TimeWritten", System.Data.DbType.DateTime, pEventLog.TimeWritten);

                wDataBase.AddInParameter(wCmd, "TimeGenerated", System.Data.DbType.DateTime, pEventLog.TimeGenerated);

                wDataBase.AddInParameter(wCmd, "UserName", System.Data.DbType.String, pEventLog.UserName);

                wDataBase.AddInParameter(wCmd, "EventLogEntryType", System.Data.DbType.String, pEventLog.EntryType);

                wCmd.CommandType = CommandType.StoredProcedure;



                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="pEventLog">EventLogEntry</param>
        /// <returns>void</returns>
        /// <Date>2010-04-19T19:26:41</Date>
        /// <Author>moviedo</Author>
        public static void Insert(EventLog pEventLog)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("log");
                wCmd = wDataBase.GetStoredProcCommand("EventLog_i");

                wDataBase.AddInParameter(wCmd, "EventGuid", System.Data.DbType.Guid, Guid.NewGuid());

                wDataBase.AddInParameter(wCmd, "Message", System.Data.DbType.String, pEventLog.Message);

                wDataBase.AddInParameter(wCmd, "Winlog", System.Data.DbType.String, pEventLog.WinLog);

                wDataBase.AddInParameter(wCmd, "AuditMachineName", System.Data.DbType.String, pEventLog.AuditMachineName);

                wDataBase.AddInParameter(wCmd, "EventID", System.Data.DbType.Int32, pEventLog.EventID);

                wDataBase.AddInParameter(wCmd, "Category", System.Data.DbType.String, pEventLog.Category);

                wDataBase.AddInParameter(wCmd, "MachineName", System.Data.DbType.String, pEventLog.MachineName);

                wDataBase.AddInParameter(wCmd, "Source", System.Data.DbType.String, pEventLog.Source);

                wDataBase.AddInParameter(wCmd, "TimeWritten", System.Data.DbType.DateTime, pEventLog.TimeWritten);

                wDataBase.AddInParameter(wCmd, "TimeGenerated", System.Data.DbType.DateTime, pEventLog.TimeGenerated);

                wDataBase.AddInParameter(wCmd, "UserName", System.Data.DbType.String, pEventLog.UserName);

                wDataBase.AddInParameter(wCmd, "EventLogEntryType", System.Data.DbType.String, pEventLog.EntryType);

                wCmd.CommandType = CommandType.StoredProcedure;



                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public static void Insert(List<EventLog> pEventLogList, string pWinlog, string pAuditMachineName)
        {
            DateTime wLastLogtime = SelectLastLog(pWinlog, pAuditMachineName);

            foreach (EventLog l in pEventLogList)
            {
                //Solo insertar logs posteriores o donde l.TimeGenerated posterior a wLastLogtime
                //l.TimeGenerated posterior a wLastLogtime
                if (DateTime.Compare(l.TimeGenerated.Value, wLastLogtime) > 0
                    || wLastLogtime.CompareTo(Fwk.HelperFunctions.DateFunctions.NullDateTime) == 0)
                    Insert(l);
            }
        }


        public static DateTime SelectLastLog(string pWinlog, string pAuditMachineName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;
            StringBuilder str = new StringBuilder(SelectLastString);
            str.Replace("$Winlog$", pWinlog);
            str.Replace("$AuditMachineName$", pAuditMachineName);
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("log");

                wCmd = wDataBase.GetStoredProcCommand(str.ToString());


                wCmd.CommandType = CommandType.Text;

                var time = wDataBase.ExecuteScalar(wCmd);

                if (time == System.DBNull.Value)
                    return Fwk.HelperFunctions.DateFunctions.NullDateTime;
                else
                    return (DateTime)wDataBase.ExecuteScalar(wCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// SearchByParam
        /// </summary>
        ///<param name="pEventLog">EventLog</param>
        /// <returns>EventLogList</returns>
        /// <Date>2010-04-21T21:13:46</Date>
        /// <Author>moviedo</Author>
        public static List<EventLog> SearchByParam(EventLogFilter pEventLog, DateTime? pTimeGeneratedEnd)
        {

            Database wDataBase = null;

            DbCommand wCmd = null;

            List<EventLog> wEventLogList = new List<EventLog>();

            EventLog wEventLog;

            try
            {

                wDataBase = DatabaseFactory.CreateDatabase("log");

                wCmd = wDataBase.GetStoredProcCommand("EventLog_sp");

                wDataBase.AddInParameter(wCmd, "Category", System.Data.DbType.String, pEventLog.Category);

                wDataBase.AddInParameter(wCmd, "MachineName", System.Data.DbType.String, pEventLog.MachineName);

                wDataBase.AddInParameter(wCmd, "Source", System.Data.DbType.String, pEventLog.Source);

                if (pEventLog.TimeGenerated !=null)
                wDataBase.AddInParameter(wCmd, "TimeGenerated", System.Data.DbType.DateTime, pEventLog.TimeGenerated.Value);

                wDataBase.AddInParameter(wCmd, "UserName", System.Data.DbType.String, pEventLog.UserName);

                wDataBase.AddInParameter(wCmd, "EventLogEntryType", System.Data.DbType.String, pEventLog.EntryType);

                wDataBase.AddInParameter(wCmd, "Winlog", System.Data.DbType.String, pEventLog.WinLog);

                wDataBase.AddInParameter(wCmd, "AuditMachineName", System.Data.DbType.String, pEventLog.AuditMachineName);

                //TODO: Ver filtro EventID
                if (pEventLog.EventID.Count > 0)
                {
                    wDataBase.AddInParameter(wCmd, "EventID", System.Data.DbType.String,
                        FormatFunctions.GetStringBuilderWhitSeparator<Int64>(pEventLog.EventID, ',').ToString());
                }
                using (IDataReader reader = wDataBase.ExecuteReader(wCmd))
                {

                    while (reader.Read())
                    {

                        wEventLog = new EventLog();
                        wEventLog.EventGuid = (Guid)reader["EventGuid"];

                        if (reader["EventLogEntryType"] != DBNull.Value)
                            wEventLog.EntryType = (EventLogEntryType)Enum.Parse(typeof(EventLogEntryType), reader["EventLogEntryType"].ToString());

                        if (reader["AuditMachineName"] != DBNull.Value)
                            wEventLog.AuditMachineName = reader["AuditMachineName"].ToString();


                        if (reader["Message"] != DBNull.Value)
                            wEventLog.Message = reader["Message"].ToString();

                        if (reader["WinLog"] != DBNull.Value)
                            wEventLog.WinLog = (WindowsLogsType)Enum.Parse(typeof(WindowsLogsType), reader["WinLog"].ToString());

                        if (reader["EventID"] != DBNull.Value)
                            wEventLog.EventID = Convert.ToInt64(reader["EventID"]);

                        if (reader["Category"] != DBNull.Value)
                            wEventLog.Category = reader["Category"].ToString();

                        if (reader["MachineName"] != DBNull.Value)
                            wEventLog.MachineName = reader["MachineName"].ToString();

                        if (reader["Source"] != DBNull.Value)
                            wEventLog.Source = reader["Source"].ToString();

                        if (reader["TimeGenerated"] != DBNull.Value)
                            wEventLog.TimeGenerated = Convert.ToDateTime(reader["TimeGenerated"]);

                        if (reader["UserName"] != DBNull.Value)
                            wEventLog.UserName = reader["UserName"].ToString();




                        wEventLogList.Add(wEventLog);

                    }

                }

                return wEventLogList;

            }

            catch (Exception ex)
            {

                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);

            }

        }


        public static void Insert2(System.Diagnostics.EventLogEntry pEventLogEntry, string pConnectionStringName)
        {

            Database wDataBase = null;
            DbCommand wCmd = null;


            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = new StringBuilder(InserLog);
                str.Replace("$Message$", pEventLogEntry.Message);
                str.Replace("$EventID$", pEventLogEntry.EventID.ToString());
                str.Replace("$Category$", pEventLogEntry.Category);
                str.Replace("$MachineName$", pEventLogEntry.MachineName);
                str.Replace("$Source$", pEventLogEntry.Source);
                str.Replace("$UserName$", pEventLogEntry.UserName);
                str.Replace("$EventLogEntryType$", pEventLogEntry.EntryType.ToString());

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;

                wDataBase.ExecuteNonQuery(wCmd);



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static void Delete(List<EventLog> events)
        {
            foreach (EventLog wEventLog in events)
            {
                Delete(wEventLog.EventGuid);
            }
        }
        public static void Delete(Guid guid)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase("log");
                wCmd = wDataBase.GetStoredProcCommand("EventLog_d");
                wCmd.CommandType = CommandType.StoredProcedure;

                wDataBase.AddInParameter(wCmd, "EventGuid", System.Data.DbType.Guid, guid);
                wDataBase.ExecuteNonQuery(wCmd);


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        static void SetInserLog()
        {

            if (string.IsNullOrEmpty(InserLog))
            {


                System.Text.StringBuilder sb = new System.Text.StringBuilder(5000);
                sb.Append(@"INSERT INTO dbo.EventLog (");
                sb.Append(@"	[Message],");
                sb.Append(@"	EventID,");
                sb.Append(@"	Category,");
                sb.Append(@"	MachineName,");
                sb.Append(@"	Source,");
                sb.Append(@"	TimeWritten,");
                sb.Append(@"	TimeGenerated,");
                sb.Append(@"	UserName,");
                sb.Append(@"	EventLogEntryType");
                sb.Append(@") VALUES ( ");
                sb.Append(@"	$Message$,");
                sb.Append(@"	$EventID$,");
                sb.Append(@"	$Category$,");
                sb.Append(@"	$MachineName$,");
                sb.Append(@"	$Source$,");
                sb.Append(@"	$TimeWritten$,");
                sb.Append(@"	$TimeGenerated$,");
                sb.Append(@"	$UserName$,");
                sb.Append(@"	$EventLogEntryType$ ) ");


                InserLog = sb.ToString();
            }


        }



    }
}
