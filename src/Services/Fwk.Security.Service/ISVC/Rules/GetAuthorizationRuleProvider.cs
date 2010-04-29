
        
using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;
using Fwk.Security;

namespace Fwk.Security.ISVC.GetAuthorizationRules
{

    [Serializable]
    public class GetAuthorizationRulesReq : Request<UsersBEList>
    {
        public GetAuthorizationRulesReq()
        {
            this.ServiceName = "GetAuthorizationRulesService";
        }
    }

    [Serializable]
    public class GetAuthorizationRulesRes : Response<Result>
    {
    }


    #region [BussinesData]


    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        #region [Private Members]

        private List<FwkAuthorizationRuleAux> _Rules;

        public List<FwkAuthorizationRuleAux> Rules
        {
            get { return _Rules; }
            set { _Rules = value; }
        }


        #endregion




    }


    #endregion

}
        