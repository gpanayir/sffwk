using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Fwk.Bases;
using Fwk.Caching;

namespace WcfDispatcher
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in App.config.
    


    [ServiceContract]
    public interface IFwkService1
    {
        [OperationContract]
        String ExecuteService(String providerName, String serviceName, String jsonRequets);
    }


    [DataContract]
    public class CompositeType
    {
 
        private ContextInformation _ContextField;
        private String ServiceName { get; set; }
        private String _JsonBussinesData;
        
        [DataMember(IsRequired = false, Name = "Context", Order = 0)]
        public ContextInformation Context
        {
            get { return _ContextField; }
            set { _ContextField = value; }
        }


        [DataMember()]
        public String JsonBussinesData
        {
            get { return _JsonBussinesData; }
            set { _JsonBussinesData = value; }
        }
       
    }
}
