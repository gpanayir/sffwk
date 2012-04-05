
using System;
using System.Data;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Security;
using Fwk.Security.ISVC.ResetUserPassword;
using System.Web.Security;
using Fwk.Security.Common;
using Fwk.Security.BC;
using System.Xml.Serialization;


namespace Fwk.Security.SVC
{

    /// <summary>
    /// Este servicio permite resetear la clave de un usuario 
    /// </summary>
    public class ResetUserPassword : BusinessService<ResetUserPasswordReq, ResetUserPasswordRes>
    {
        public override ResetUserPasswordRes Execute(ResetUserPasswordReq pServiceRequest)
        {
            ResetUserPasswordRes wRes = new ResetUserPasswordRes();
            UserBC wUserBC = new UserBC(pServiceRequest.ContextInformation.CompanyId, pServiceRequest.SecurityProviderName);
            wUserBC.ResetPassword(pServiceRequest.BusinessData.UserName, pServiceRequest.BusinessData.NewPassword);
            return wRes;
        }
    }
}

namespace Fwk.Security.ISVC.ResetUserPassword
{

    [Serializable]
    public class ResetUserPasswordReq : Request<Param>
    {
        public ResetUserPasswordReq()
        {
            this.ServiceName = "ResetUserPasswordService";
        }
    }


    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        public String UserName {get;set;}
        public String NewPassword { get; set; }
    }


    [Serializable]
    public class ResetUserPasswordRes : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
    }

   

}
