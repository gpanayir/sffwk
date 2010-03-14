using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Fwk.HelperFunctions.Caching;
using Fwk.Bases;
using WcfCommon;

namespace WcfDispatcher
{
    // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in App.config.
    


    [ServiceContract]
    public interface IFwkService1
    {
        [OperationContract]
        CompositeType ExecuteService(CompositeType composite);
    }


    [DataContract]
    [KnownType(typeof(Survey))]
    public class CompositeType
    {
 
        private ContextInformation _ContextField;
        private IEntity _EntityField;
        private CacheSettings _CacheField;


        [DataMember(IsRequired = false, Name = "Context", Order = 0)]
        public ContextInformation Context
        {
            get { return _ContextField; }
            set { _ContextField = value; }
        }


        [DataMember()]
        public IEntity EntityField
        {
            get { return _EntityField; }
            set { _EntityField = value; }
        }

        [DataMember(IsRequired = false, Name = "Cache", Order = 2)]
        public CacheSettings CacheField
        {
            get { return _CacheField; }
            set { _CacheField = value; }
        }
    }
}
