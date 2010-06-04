
        
using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.GetAllRulesCategory
{

    [Serializable]
    public class GetAllRulesCategoryReq : Request<DummyContract>
    {
        public GetAllRulesCategoryReq()
        {
            this.ServiceName = "GetAllRulesCategoryService";
        }
    }




    [Serializable]
    public class GetAllRulesCategoryRes : Response<FwkCategoryList>
    {
    }
}
        