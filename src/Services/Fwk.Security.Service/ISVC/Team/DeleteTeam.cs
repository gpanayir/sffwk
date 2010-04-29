using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.DeleteTeam
{
    [Serializable]
    public class DeleteTeamRequest : Request<Param>
    {
        public DeleteTeamRequest()
        {
            this.ServiceName = "DeleteTeamService";
        }
    }

    #region [BussinesData]


    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]

        private List<Int32> _UsersIdList;
        private UserInfo _UserInfo;

        #endregion

        #region [Properties]

        public List<Int32> UsersIdList
        {
            get { return _UsersIdList; }
            set { _UsersIdList = value; }
        }

        public UserInfo UserInfo
        {
            get { return _UserInfo; }
            set { _UserInfo = value; }
        }

        #endregion
    }

    #endregion


    [Serializable]
    public class DeleteTeamResponse : Request<Result>
    {

    }

    #region [BussinesData]


    [XmlInclude(typeof(Param)), Serializable]
    public class Result : Entity
    {
        #region [Private Members]

        private String _Dummy;


        #endregion

        #region [Properties]

        public String Dummy
        {
            get { return _Dummy; }
            set { _Dummy = value; }
        }

        #endregion


    }


    #endregion

}