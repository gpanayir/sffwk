
using System;
using System.Data;
using System.Web.Security;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security.ISVC.GetAllRules;





namespace Fwk.Security.SVC
{

    /// <summary>
    /// 
    /// </summary>
    public class GetAllRulesService : BusinessService<GetAllRulesReq, GetAllRulesRes>
    {
        //TODO:Limpiar este codigo
        public override GetAllRulesRes Execute(GetAllRulesReq pServiceRequest)
        {
            GetAllRulesRes wRes = new GetAllRulesRes();

            //if(string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            FwkAuthorizationRuleList rules = FwkMembership.GetRulesAuxList(pServiceRequest.SecurityProviderName);
            
            wRes.BusinessData = rules;
            // foreach (FwkAuthorizationRule rule in rules)
            //{
            //    wRulesBE = new RulesBE();
            //    wRulesBE.expression = rule.Expression;
            //    wRulesBE.Name = rule.Name;
            //     wRes.BusinessData.Add(wRulesBE);
            //}

            
            return wRes;
        }
    }
}
