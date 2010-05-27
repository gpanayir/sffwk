using System;
using System.Data;
using System.Collections.Generic;
using System.Web.Security;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.DeleteRole;
using Fwk.Exceptions;
using Fwk.Security.Common;


namespace Fwk.Security.SVC
{
    public class DeleteRoleService : BusinessService<DeleteRoleReq, DeleteRoleRes>
    {
        public override DeleteRoleRes Execute(DeleteRoleReq pServiceRequest)
        {
            Rol wRol;
            DeleteRoleRes wRes = new DeleteRoleRes();

            //if (string.IsNullOrEmpty(pServiceRequest.SecurityProviderName))
            //    pServiceRequest.SecurityProviderName = Membership.ApplicationName;

            if (FwkMembership.GetUsersInRole(pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName).Count != 0)
            {
                throw new FunctionalException(string.Format("El rol {0} contiene usuarios asociados.-", pServiceRequest.BusinessData.RolName));
            }


            aspnet_Rule waspnet_Rule;

            //Elimino todas las asociciones de las reglas al rol.- Se modificara el valor Expression de la regla
            List<FwkAuthorizationRuleAux> ruleListAux = FwkMembership.GetRulesByRole(pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName);

            foreach (FwkAuthorizationRuleAux rulesAux in ruleListAux)
            {
                waspnet_Rule = new aspnet_Rule();
                wRol = new Rol(pServiceRequest.BusinessData.RolName);
                FwkMembership.RuleRemoveRol(wRol, rulesAux);
                waspnet_Rule.name = rulesAux.Name;
                waspnet_Rule.expression = rulesAux.Expression;
                FwkMembership.UpdateRule(waspnet_Rule, pServiceRequest.SecurityProviderName);
            }

            FwkMembership.DeleteRole(pServiceRequest.BusinessData.RolName, pServiceRequest.SecurityProviderName);
            return wRes;
        }
    }
}
