


using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security.ISVC.DeleteRulesCategory;
using Fwk.Security;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{
    /// <summary>
    /// Elimina una categoriua y sus subvategorias asocoadas de forma recursiva
    /// </summary>
    public class DeleteRulesCategoryService : BusinessService<DeleteRulesCategoryRequest, DeleteRulesCategoryResponse>
    {
        public override DeleteRulesCategoryResponse Execute(DeleteRulesCategoryRequest pServiceRequest)
        {
            DeleteRulesCategoryResponse wRes = new DeleteRulesCategoryResponse();
            FwkMembership.RemoveCategory(pServiceRequest.BusinessData.CategoryId.Value, pServiceRequest.SecurityProviderName);  
            return wRes;
        }
    }
}
        