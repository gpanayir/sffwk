using System;
using System.Data;
using System.Web.Security;
using System.Collections.Generic;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.SearchPelsofters;
using Fwk.Security.Common;
using Fwk.Security.DAC;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class SearchPelsoftersService : BusinessService<SearchPelsoftersReq, SearchPelsoftersRes>
    {
        public override SearchPelsoftersRes Execute(SearchPelsoftersReq pServiceRequest)
        {
            SearchPelsoftersRes wRes = new SearchPelsoftersRes();
            UserBC wBC = new UserBC(pServiceRequest.ContextInformation.CompanyId,pServiceRequest.SecurityProviderName);

            //if (string.IsNullOrEmpty(pServiceRequest.BusinessData.ApplicationName))
            //    pServiceRequest.BusinessData.ApplicationName = Membership.ApplicationName;

            wRes.BusinessData.UserList = wBC.GetPelsofter();
            

            return wRes;
        }
    }
}