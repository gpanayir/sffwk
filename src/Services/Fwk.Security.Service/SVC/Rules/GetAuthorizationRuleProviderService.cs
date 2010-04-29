
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Prominente Code Generator.
//     Runtime Version:1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;

using Fwk.Security.ISVC.GetAuthorizationRules;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Fwk.Security;
using System.Web.Security;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Collections;
using System.Linq;

namespace Fwk.Security.SVC
{

    public class GetAuthorizationRulesService : BusinessService<GetAuthorizationRulesReq, GetAuthorizationRulesRes>
    {
        public override GetAuthorizationRulesRes Execute(GetAuthorizationRulesReq pServiceRequest)
        {
            GetAuthorizationRulesRes wRes = new GetAuthorizationRulesRes();


            List<FwkAuthorizationRuleAux> rules = FwkMembership.GetRulesAuxList(Membership.ApplicationName, pServiceRequest.SecurityProviderName);



             wRes.BusinessData.Rules = rules;

            return wRes;
        }

       
    }
}
        