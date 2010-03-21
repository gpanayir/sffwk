using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.DataBase;

namespace FwkSqlTrace
{
    internal class TraceDAL
    {
        internal static CnnString Connection;
        internal static List<Trace> GetAll()
        {
            using (TraceDataContext dc = new TraceDataContext(Connection.ToString()))
            {
                var list = from t in dc.Traces select t;

                return list.ToList<Trace>();
            }
        }
    }
}
