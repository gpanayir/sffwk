using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.UpdateRules
{
    [Serializable]
    public class UpdateRulesReq : Request<Param>
    {
        public UpdateRulesReq()
		{
            this.ServiceName = "UpdateRulesService";

		}
    }



    #region [BussinesData]
    [XmlInclude(typeof(Param)), Serializable]
    public class Param:Entity
    {
        FwkAuthorizationRuleAuxList _Rules = new FwkAuthorizationRuleAuxList();

        public FwkAuthorizationRuleAuxList FwkAuthorizationRuleList
        {
            get { return _Rules; }
            set { _Rules = value; }
        }

    }
    

    #endregion


    [Serializable]
    public class UpdateRulesRes : Response<DummyContract>
    {

    }
    
}
