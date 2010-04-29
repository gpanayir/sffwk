using System;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Collections.Generic;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.Team
{
    [Serializable]
    public class AssembleTeamRequest : Request<Param>
    {
        public AssembleTeamRequest()
        {
            this.ServiceName = "AssembleTeamService";
        }
    }

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        #region [Private Members]

        private List<Int32> _UsersIdList;
        private TeamBEList _TeamBEList;
        private UserInfo _UserInfo;

        #endregion

        #region [Properties]

        public List<Int32> UsersIdList
        {
            get { return _UsersIdList; }
            set { _UsersIdList = value; }
        }

        public TeamBEList TeamBEList
        {
            get { return _TeamBEList; }
            set { _TeamBEList = value; }
        }

        public UserInfo UserInfo
        {
            get { return _UserInfo; }
            set { _UserInfo = value; }
        }

        #endregion
    }
    [Serializable]
    public class AssembleTeamResponse : Response<Result>
    {
    }

    [Serializable]
    public class Result : Entity
    {
        TeamBEList mTeamBEList;

        public TeamBEList TeamBEList
        {
            get { return mTeamBEList; }
            set { mTeamBEList = value; }
        }
    }
}
