
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
using Fwk.Security.ISVC.CreateTeam;
using Fwk.Security.BC;



namespace Fwk.Security.SVC
{

    public class CreateTeamService : BusinessService<CreateTeamRequest, CreateTeamResponse>
    {
        public override CreateTeamResponse Execute(CreateTeamRequest pServiceRequest)
        {
            CreateTeamResponse wRes = new CreateTeamResponse();
            
            Fwk.Security.BE.TeamBEList wTeamBEList = new Fwk.Security.BE.TeamBEList();

            wTeamBEList = Fwk.Security.BE.TeamBEList.GetTeamBEListFromXml(pServiceRequest.BusinessData.GetXml());
            TeamBC wTeamBC = new TeamBC(pServiceRequest.ContextInformation.CompanyId);
            wTeamBC.Insert(wTeamBEList);

             wRes.BusinessData.TeamBEList = wTeamBEList;

            return wRes; 
        }
    }
}
        