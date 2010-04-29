using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.ISVC.SearchUnassignedUsers;
using Fwk.Security;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class SearchUnassignedUsersService : BusinessService<SearchUnassignedUsersRequest, SearchUnassignedUsersResponse>
    {
        public override SearchUnassignedUsersResponse Execute(SearchUnassignedUsersRequest pServiceRequest)
        {
            SearchUnassignedUsersResponse wRes = new SearchUnassignedUsersResponse();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
            wRes.BusinessData = wUserBC.SearchUnassignedUsers();
            return wRes;
        }

    }
}
