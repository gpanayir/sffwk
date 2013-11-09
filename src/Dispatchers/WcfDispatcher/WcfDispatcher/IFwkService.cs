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
    [ServiceContract]
    public interface IFwkService
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
