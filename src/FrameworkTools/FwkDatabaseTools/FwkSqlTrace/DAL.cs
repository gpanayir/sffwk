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


        internal static List<TraceView> GetAll()
        {
            List<Trace> trecers = GetAllFromDB();

            if (events == null)
                events = TraceDAL.GetEvents();

            var wTraceViewList = from t in trecers
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

        static List<Trace> GetAllFromDB()
        {
            using (TraceDataContext dc = new TraceDataContext(Connection.ToString()))
            {
                var list = from t in dc.Traces select t;
                //from ev in events
                //where (t.EventClass == ev.Trace_event_id)
                //select new Trace
                //{
                //    ApplicationName = t.ApplicationName,
                //    BinaryData = t.BinaryData,
                //    ClientProcessID = t.ClientProcessID,
                //    CPU = t.CPU,
                //    Duration = t.Duration,
                //    EndTime = t.EndTime,
                //    EventClass = t.EventClass,
                //    EventClassName = t.EventClassName,
                //    LoginName = t.LoginName,
                //    NTUserName = t.NTUserName,
                //    Reads = t.Reads,
                //    RowNumber = t.RowNumber,
                //    SPID = t.SPID,
                //    TextData = t.TextData,
                //    Writes = t.Writes
                //};


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
    }
}
