using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.ISVC.Team;
using Fwk.Security.BC;

namespace Fwk.Security.SVC
{
    public class AssembleTeamService : BusinessService<AssembleTeamRequest, AssembleTeamResponse>
    {
        public override AssembleTeamResponse Execute(AssembleTeamRequest pServiceRequest)
        {
            AssembleTeamResponse wResponse = new AssembleTeamResponse();
            TeamBC wTeamBC = new TeamBC(pServiceRequest.ContextInformation.CompanyId);
            if (pServiceRequest.BusinessData.UsersIdList.Count > 0)
            {
                wTeamBC.Delete(pServiceRequest.BusinessData.UsersIdList, pServiceRequest.BusinessData.UserInfo);
            }

            if (pServiceRequest.BusinessData.TeamBEList.Count > 0)
            {
                wTeamBC.Insert(pServiceRequest.BusinessData.TeamBEList);
            }

            wResponse.BusinessData.TeamBEList = pServiceRequest.BusinessData.TeamBEList;

            return wResponse;
        }
    }
}
