
         using System;
        using System.Collections.Generic;
        using Fwk.Bases;
        using System.Xml.Serialization;

namespace Fwk.Security.ISVC.UpdateActiveFlagUser
{

    [Serializable]
    public class UpdateActiveFlagUserReq : Request<Param>
    {
        public UpdateActiveFlagUserReq()
        {
            this.ServiceName = "UpdateActiveFlagUserSerivice";
        }
    }


    #region [BussinesData]

   

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]

 
     
        private String _UserName;
        private System.Boolean _ActiveFlag;

        #endregion

        #region [Properties]

      
        public String UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }





        public Boolean ActiveFlag
        {
            get { return _ActiveFlag; }
            set { _ActiveFlag = value; }
        }

      

        #endregion

        
    }

    #endregion


    [Serializable]
    public class UpdateActiveFlagUserRes : Response<Result>
    {
    }
    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {


    }

}
        