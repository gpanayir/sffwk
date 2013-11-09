using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDispatcher
{
    
    public class FwkService : IFwkService
    {

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
            return fw.ExecuteServiceJson(providerName, serviceName, jsonRequets);

        }


    }


    


}
