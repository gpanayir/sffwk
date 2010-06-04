using System;
using System.Data;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.GetAllRulesCategory;


namespace Fwk.Security.SVC
{
    /// <summary>
    /// Busca todas las cateegorias de un provider
    /// Por cada categoria tambien trae las reglas asociadas
    /// </summary>
    public class GetAllRulesCategoryService : BusinessService<GetAllRulesCategoryReq, GetAllRulesCategoryRes>
    {
        public override GetAllRulesCategoryRes Execute(GetAllRulesCategoryReq pServiceRequest)
        {
            GetAllRulesCategoryRes wRes = new GetAllRulesCategoryRes();
           
    
        
            wRes.BusinessData = Fwk.Security.FwkMembership.GetAllCategories(pServiceRequest.SecurityProviderName);
            //wRes.BusinessData = new FwkCategoryList();
            //foreach(FwkCategory k in list)
            //{
            //    FwkCategory = new RulesCategoryBE();
            //    wRulesCategoryBE.Name = k.Name;
            //    wRulesCategoryBE.ParentCategoryId = k.ParentId;
            //    wRulesCategoryBE.CategoryId = k.CategoryId;
            //    wRulesCategoryBE.RulesBEList = new RulesBEList();
            //    //Cargo las reglas pertenecientes a la categoria
            //    foreach (FwkAuthorizationRule rule in k.FwkRulesInCategoryList)
            //    {
            //        wRulesCategoryBE.RulesBEList.Add(new RulesBE(rule.Name, rule.Expression));
            //    }

            //     wRes.BusinessData.Add(wRulesCategoryBE);
            //}
            return wRes;
        }
    }
}
        