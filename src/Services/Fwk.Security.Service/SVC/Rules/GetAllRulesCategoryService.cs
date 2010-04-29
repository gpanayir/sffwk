


using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;

using  Fwk.Security.ISVC.GetAllRulesCategory;

using System.Collections.Generic;
using Fwk.Security;


namespace Fwk.Security.SVC
{

    public class GetAllRulesCategoryService : BusinessService<GetAllRulesCategoryRequest, GetAllRulesCategoryResponse>
    {
        public override GetAllRulesCategoryResponse Execute(GetAllRulesCategoryRequest pServiceRequest)
        {
            GetAllRulesCategoryResponse wRes = new GetAllRulesCategoryResponse();
            RulesCategoryBE wRulesCategoryBE = null;
    
        
            List<FwkCategory> list = Fwk.Security.FwkMembership.GetAllCategories(pServiceRequest.BusinessData .ApplicationName);
             wRes.BusinessData = new RulesCategoryBEList();
            foreach(FwkCategory k in list)
            {
                wRulesCategoryBE = new RulesCategoryBE();
                wRulesCategoryBE.Name = k.Name;
                wRulesCategoryBE.ParentCategoryId = k.ParentId;
                wRulesCategoryBE.CategoryId = k.CategoryId;
                wRulesCategoryBE.RulesBEList = new RulesBEList();
                //Cargo las reglas pertenecientes a la categoria
                foreach (FwkAuthorizationRuleAux rule in k.FwkRulesInCategoryList)
                {
                    wRulesCategoryBE.RulesBEList.Add(new RulesBE(rule.Name, rule.Expression));
                }

                 wRes.BusinessData.Add(wRulesCategoryBE);
            }
            return wRes;
        }
    }
}
        