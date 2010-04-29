
        
using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.GetAllRulesCategory
{

    [Serializable]
    public class GetAllRulesCategoryRequest : Request<Param>
    {
        public GetAllRulesCategoryRequest()
        {
            this.ServiceName = "GetAllRulesCategoryService";
        }
    }


    #region [BussinesData]

    [XmlRoot("Param"), SerializableAttribute]
    public class Param : Entity
    {
        private System.String _ApplicationName;

        public System.String ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }
        
    }

 

    #endregion


    [Serializable]
    public class GetAllRulesCategoryResponse : Response<RulesCategoryBEList>
    {
    }
}
        