using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.ISVC.DeleteTeam;
using Fwk.Security.BC;


namespace Fwk.Security.SVC
{
    public class DeleteTeamService : BusinessService<DeleteTeamRequest, DeleteTeamResponse>
    {
        public override DeleteTeamResponse Execute(DeleteTeamRequest pServiceRequest)
        {
            //TODO: Cambiar el behaviour y el Isolation Level del servicio
            DeleteTeamResponse wRes = new DeleteTeamResponse();
            TeamBC wTeamBC = new TeamBC(pServiceRequest.ContextInformation.CompanyId);
            wTeamBC.Delete(pServiceRequest.BusinessData.UsersIdList, pServiceRequest.BusinessData.UserInfo);
            return wRes;
        }
    }
}
