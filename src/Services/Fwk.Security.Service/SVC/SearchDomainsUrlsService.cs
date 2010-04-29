using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.SearchDomainsUrls;
using System.Web.Security;
using System.Collections.Generic;
using Fwk.Security.ActiveDirectory;
using Fwk.Security.BC;
namespace Fwk.Security.SVC
{
    public class SearchDomainsUrlsService : BusinessService<SearchDomainsUrlsRequest, SearchDomainsUrlsResponse>
    {

        public override SearchDomainsUrlsResponse Execute(SearchDomainsUrlsRequest pServiceRequest)
        {
            SearchDomainsUrlsResponse wResponse = new SearchDomainsUrlsResponse();

            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId,pServiceRequest.SecurityProviderName);

            List<DomainUrlInfo> wDomainUrlInfoList = ADHelper.DomainsUrl_GetList(pServiceRequest.ContextInformation.CompanyId);
            wResponse.BusinessData.DomainsNameList = wUserBC.MapListDomainToListString(wDomainUrlInfoList);

            return wResponse;
        }
    }
}
