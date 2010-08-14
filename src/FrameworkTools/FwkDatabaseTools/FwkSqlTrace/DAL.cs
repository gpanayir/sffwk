using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.DataBase;
using System.Data.SqlClient;
using System.Data;

namespace FwkSqlTrace
{
    internal class TraceDAL
    {
        internal static CnnString Connection;
        static List<trace_events> events;

        static TraceDAL()
        {

        }


         static List<TraceView> GetAll()
        {
            List<Trace> tracers = GetAllFromDB();

            if (events == null)
                events = TraceDAL.GetEvents();

            var wTraceViewList = from t in tracers
                                 from ev in events
                                 where (t.EventClass == ev.Trace_event_id)
                                 select new TraceView
                                 {
                                     ApplicationName = t.ApplicationName,
                                     ClientProcessID = t.ClientProcessID,
                                     CPU = t.CPU,
                                     Duration = t.Duration,
                                     EndTime = t.EndTime,
                                     EventClass = t.EventClass,
                                     EventClassName = ev.Name,
                                     LoginName = t.LoginName,
                                     NTUserName = t.NTUserName,
                                     Reads = Convert.ToInt32(t.Reads),
                                     SPID = t.SPID,
                                     TextData = t.TextData,
                                     Writes = Convert.ToInt32(t.Writes)
                                 };

            return wTraceViewList.ToList<TraceView>();
        }

        internal static List<Trace> GetAllFromDB()
        {
            if (events == null)
                events = TraceDAL.GetEvents();
            using (TraceDataContext dc = new TraceDataContext(Connection.ToString()))
            {
                IEnumerable<Trace> listTrace = from t in dc.Traces select t;


                var list = from t in listTrace
                from ev in events
                where (t.EventClass == ev.Trace_event_id)
                select new Trace
                {
                    //RowNumber = t.RowNumber,
                    EventClass = t.EventClass,
                    TextData = t.TextData,
                    ApplicationName = t.ApplicationName,
                    NTUserName = t.NTUserName,
                    LoginName = t.LoginName,
                    CPU = t.CPU,
                    Reads = t.Reads,
                    Writes = t.Writes,
                    Duration = t.Duration,
                    ClientProcessID = t.ClientProcessID,
                    SPID = t.SPID,
                    StartTime = t.StartTime,
                    EndTime = t.EndTime,
                    //BinaryData = t.BinaryData,
                    DatabaseID = t.DatabaseID,
                    DatabaseName = t.DatabaseName,
                    EventSequence = t.EventSequence,
                    HostName = t.HostName,
                    IsSystem = t.IsSystem,
                    LoginSid = t.LoginSid,
                    NTDomainName = t.NTDomainName,
                    ServerName = t.ServerName,
                    RowCounts = t.RowCounts,
                    SessionLoginName = t.SessionLoginName,
                    TransactionID = t.TransactionID,
                    //XactSequence = t.XactSequence,
                    EventSubClass = t.EventSubClass,
                    IntegerData = t.IntegerData,
                    ObjectID = t.ObjectID,
                    Error = t.Error,
                    //GUID = t.GUID,
                    ObjectName = t.ObjectName,
                    DBUserName = t.DBUserName,
                    FileName = t.FileName,
                    MethodName = t.MethodName,
                    OwnerName = t.OwnerName,
                    ProviderName = t.ProviderName,
                    RoleName = t.RoleName,
                    TargetLoginName = t.TargetLoginName,
                    TargetUserName = t.TargetUserName,
                    Severity = t.Severity,
                    State = t.State,
                    //BigintData1 = t.BigintData1,
                    IndexID = t.IndexID,
                    Success = t.Success,
                    LinkedServerName = t.LinkedServerName,
                    ParentName = t.ParentName,
                    BigintData2 = t.BigintData2,
                    IntegerData2 = t.IntegerData2,
                    Handle = t.Handle,
                    RequestID = t.RequestID,
                    LineNumber = t.LineNumber,
                    NestLevel = t.NestLevel,
                    Offset = t.Offset,
                    ObjectType = t.ObjectType,
                    SqlHandle = t.SqlHandle,
                    SourceDatabaseID = t.SourceDatabaseID,
                    EventClassName = t.EventClassName	

                };

              

                //var list = from t in dc.Traces
                //           from ev in events
                //           where (t.EventClass == ev.Trace_event_id)
                //           select new TraceView
                //           {
                //               ApplicationName = t.ApplicationName,
                //               ClientProcessID = t.ClientProcessID,
                //               CPU = t.CPU,
                //               Duration = t.Duration,
                //               EndTime = t.EndTime,
                //               EventClass = t.EventClass,
                //               EventClassName = ev.Name,
                //               LoginName = t.LoginName,
                //               NTUserName = t.NTUserName,
                //               Reads = Convert.ToInt32(t.Reads),
                //               SPID = t.SPID,
                //               TextData = t.TextData,
                //               Writes = Convert.ToInt32(t.Writes)
                //           };


                return list.ToList<Trace>();
            }
        }

        static List<trace_events> GetEvents()
        {
            List<trace_events> list = new List<trace_events>();
            trace_events wtrace_events;
            CnnString cnnStringMaster = Connection.Clone<CnnString>();
            cnnStringMaster.InitialCatalog = "master";

            using (SqlConnection wCnn = new SqlConnection(cnnStringMaster.ToString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.CommandType = CommandType.Text;
                    wCmd.CommandText = "select * from sys.trace_events";
                    wCmd.Connection = wCnn;
                    SqlDataReader reader = wCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        wtrace_events = new trace_events();

                        wtrace_events.Category_id = Convert.ToInt32(reader["category_id"]);
                        wtrace_events.Name = reader["name"].ToString();

                        wtrace_events.Trace_event_id = Convert.ToInt32(reader["trace_event_id"]);
                        list.Add(wtrace_events);
                    }


                    wCnn.Close();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }

        static List<trace_events> GetDatabases()
        {
            List<trace_events> list = new List<trace_events>();
            trace_events wtrace_events;
            CnnString cnnStringMaster = Connection.Clone<CnnString>();
            cnnStringMaster.InitialCatalog = "master";

            using (SqlConnection wCnn = new SqlConnection(cnnStringMaster.ToString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                try
                {
                    wCnn.Open();
                    wCmd.CommandType = CommandType.Text;
                    wCmd.CommandText = "select [name], database_id from sys.databases";
                    wCmd.Connection = wCnn;
                    SqlDataReader reader = wCmd.ExecuteReader();

                    while (reader.Read())
                    {
                        wtrace_events = new trace_events();

                        wtrace_events.Category_id = Convert.ToInt32(reader["name"]);
                        wtrace_events.Name = reader["name"].ToString();

                        wtrace_events.Trace_event_id = Convert.ToInt32(reader["database_id"]);
                        list.Add(wtrace_events);
                    }


                    wCnn.Close();
                    return list;
                }
                catch (Exception ex)
                {
                    throw ex;
                }

            }
        }
    }
}
