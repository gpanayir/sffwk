using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.GetAllActiveUsersInfo
{
    [Serializable]
    public class GetAllActiveUsersInfoRequest: Request<Dummy>
    {
        public GetAllActiveUsersInfoRequest()
        {
            this.ServiceName = "GetAllActiveUsersInfoService";
        }
    }

    [Serializable]
    public class Dummy : Entity
    {
        /// <summary>
        /// No utilizado para la llamada al servicio solo se pone
        /// por que se debe utilizar si o si una clase en el request.
        /// </summary>
        public string DummyData;

    }
    [Serializable]
    public class GetAllActiveUsersInfoResponse : Response<UserInfoList>
    {
    }
}
