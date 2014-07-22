using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Diagnostics;

namespace WcfDispatcher
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class FwkService : IFwkService
    {
        int x = 0            ;
        String sessionId = string.Empty;
        Fwk.BusinessFacades.SimpleFacade fw = new Fwk.BusinessFacades.SimpleFacade();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        /// <param name="jsonRequets"></param>
        /// <returns></returns>
         string IFwkService.ExecuteService(String providerName, String serviceName, String jsonRequets)
        {
            x = x + 1;
            
            System.Diagnostics.Trace.WriteLine(String.Concat(OperationContext.Current.SessionId," " ,x));
            return fw.ExecuteServiceJson(providerName, serviceName, jsonRequets);

        }


    }


    


}
