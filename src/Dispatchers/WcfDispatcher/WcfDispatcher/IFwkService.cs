using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using Fwk.Bases;
using Fwk.Caching;

//http://msdn.microsoft.com/en-us/library/ee939340.aspx
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
        private String _JsonBusinesData;
        
        [DataMember(IsRequired = false, Name = "Context", Order = 0)]
        public ContextInformation Context
        {
            get { return _ContextField; }
            set { _ContextField = value; }
        }


        [DataMember()]
        public String JsonBusinesData
        {
            get { return _JsonBusinesData; }
            set { _JsonBusinesData = value; }
        }
       
    }
}
