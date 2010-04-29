using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.ISVC.GetUnassignedUsersByParam;
using Fwk.Security;
using Fwk.Security.BC;



namespace Fwk.Security.SVC
{
    public class GetUnassignedUsersByParamService : BusinessService<GetUnassignedUsersByParamRequest, GetUnassignedUsersByParamResponse>
    {

        public override GetUnassignedUsersByParamResponse Execute(GetUnassignedUsersByParamRequest pServiceRequest)
        {
            GetUnassignedUsersByParamResponse wRes = new GetUnassignedUsersByParamResponse();

            if (!String.IsNullOrEmpty(pServiceRequest.BusinessData.FirstName))
            {
                pServiceRequest.BusinessData.FirstName = Fwk.Bases.Enums.GetSearchTypeValue(pServiceRequest.BusinessData.FirstName,
                                                                                             pServiceRequest.BusinessData.SearchtypeName);
            }

            if (!String.IsNullOrEmpty(pServiceRequest.BusinessData.LastName))
            {
                pServiceRequest.BusinessData.LastName = Fwk.Bases.Enums.GetSearchTypeValue(pServiceRequest.BusinessData.LastName,
                                                                                            pServiceRequest.BusinessData.SearchtypeName);
            }

            if (!String.IsNullOrEmpty(pServiceRequest.BusinessData.Name))
            {
                pServiceRequest.BusinessData.Name = Fwk.Bases.Enums.GetSearchTypeValue(pServiceRequest.BusinessData.Name,
                                                                                         pServiceRequest.BusinessData.SearchtypeName);
            }
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
             wRes.BusinessData = wUserBC.GetUnassignedUsersByParam(pServiceRequest.BusinessData);


            return wRes;
        }

    }
}