using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fwk.ConfigData;
using System.Data.Linq;

namespace VivaldiSite.DAC
{
    public class DataCoreDAC
    {
       
        internal static void Dispatcher_Create(fwk_ServiceDispatcher disp)
        {
            using(Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext   ())
            {

                dc.fwk_ServiceDispatchers.InsertOnSubmit(disp);
                dc.SubmitChanges();
            }
        
        }

        internal static bool Dispatcher_Exist(string dispName, string url)
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext())
            {
                if (!string.IsNullOrEmpty(dispName))
                    return dc.fwk_ServiceDispatchers.Any(
                        p=>p.InstanseName.Equals(dispName));


                if (!string.IsNullOrEmpty(url))
                    return dc.fwk_ServiceDispatchers.Any(
                        p => p.InstanseName.Equals(url));
            }
            return true;
        }

        internal static void Dispatcher_Update(string url)
        {
            

        }

        internal static fwk_ServiceDispatcher Dispatcher_Get(string pInstanseName)
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext())
            {
                return dc.fwk_ServiceDispatchers.Where(p => p.InstanseName.Equals(pInstanseName)).FirstOrDefault();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        internal static List<fwk_ServiceDispatcher> Dispatcher_List()
        {
            using (Fwk.ConfigData.FwkDatacontext dc = new Fwk.ConfigData.FwkDatacontext())
            {
                return dc.fwk_ServiceDispatchers.ToList < fwk_ServiceDispatcher>();
            }
        }
    }
}