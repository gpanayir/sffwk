using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;

namespace Fwk.Security.ISVC.GetUserInfoByName
{
    [Serializable]
    public class GetUserInfoByNameRequest : Request<Params>
    {
        public GetUserInfoByNameRequest()
        {
            this.ServiceName = "GetUserInfoByName";
        }
    }

    [Serializable]
    public class Params : Entity
    {
        /// <summary>
        /// No utilizado para la llamada al servicio solo se pone
        /// por que se debe utilizar si o si una clase en el request.
        /// </summary>
        public string Name;

    }
    [Serializable]
    public class GetUserInfoByNameResponse : Response<Fwk.Security.BE.UserInfo>
    { }
}

