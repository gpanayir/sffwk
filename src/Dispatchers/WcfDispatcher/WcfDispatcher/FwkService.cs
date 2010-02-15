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
       

        #region IFwkService1 Members

        public CompositeType ExecuteService(CompositeType composite)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    public class FwkService2 : IFwkService2
    {


        

        #region IFwkService2 Members

        public Fwk.Bases.IServiceContract ExecuteService(Fwk.Bases.IServiceContract pReq)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
