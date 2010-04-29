
using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security;
using  Fwk.Security.ISVC.GetAllRules;
using System.Web.Security;
using System.Collections.Generic;




namespace Fwk.Security.SVC
{
    public class GetAllRulesService : BusinessService<GetAllRulesReq, GetAllRulesRes>
    {
        public override GetAllRulesRes Execute(GetAllRulesReq pServiceRequest)
        {
            GetAllRulesRes wRes = new GetAllRulesRes();

            if(string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
                pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            List<FwkAuthorizationRuleAux> rules = FwkMembership.GetRulesAuxList(pServiceRequest.BusinessData.ApplicationName, pServiceRequest.SecurityProviderName);
            RulesBE wRulesBE;
             wRes.BusinessData = new RulesBEList();
            foreach (FwkAuthorizationRuleAux rule in rules)
            {
                wRulesBE = new RulesBE();
                wRulesBE.expression = rule.Expression;
                wRulesBE.Name = rule.Name;
                 wRes.BusinessData.Add(wRulesBE);
            }

            
            return wRes;
        }
    }
}
