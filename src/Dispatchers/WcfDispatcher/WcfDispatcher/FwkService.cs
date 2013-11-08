using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfDispatcher
{
    // NOTE: If you change the class name "Service1" here, you must also update the reference to "Service1" in App.config.
    public class FwkService1 : IFwkService1
    {

        Fwk.BusinessFacades.SimpleFacade fw = new Fwk.BusinessFacades.SimpleFacade();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        /// <param name="jsonRequets"></param>
        /// <returns></returns>
        string IFwkService1.ExecuteService(String providerName, String serviceName, String jsonRequets)
        {
            return fw.ExecuteServiceJson(providerName, serviceName, jsonRequets);

        }


        //CompositeType IFwkService1.ExecuteService(CompositeType composite)
        //{
        //    CompositeType r = new CompositeType();

        //    return r;
        //}



    }


    //public class FwkService2 : IFwkService2
    //{


    //    #region IFwkService2 Members

    //    public T ExecuteService<T>(T pReq)
    //    {
    //        object x = null;
    //        T data = (T)x;
    //        return data;
    //    }

    //    #endregion

        
    //}


}
