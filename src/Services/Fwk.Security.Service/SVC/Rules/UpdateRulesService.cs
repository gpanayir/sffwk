using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.ISVC.UpdateRules;

using Fwk.Security.BE;
using Fwk.Security;


namespace Fwk.Security.SVC
{

    public class UpdateRulesService : BusinessService<UpdateRulesRequest, UpdateRulesResponse>
    {
        public override UpdateRulesResponse Execute(UpdateRulesRequest pServiceRequest)
        {
            UpdateRulesResponse wRes = new UpdateRulesResponse();



            foreach (RulesBE item in pServiceRequest.BusinessData.RulesBEList)
            {
                aspnet_Rule waspRule = new aspnet_Rule();

                waspRule.expression = item.expression;
                waspRule.name = item.Name;
                // Update de la Regla
                FwkMembership.UpdateRule(waspRule, pServiceRequest.BusinessData.ApplicationName);
            }


            return wRes;
        }
    }
}
