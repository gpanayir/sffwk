using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.UpdateRules
{
    [Serializable]
    public class UpdateRulesRequest : Request<Param>
    {
        public UpdateRulesRequest()
		{
            this.ServiceName = "UpdateRulesService";
		}
    }



    #region [BussinesData]
    [XmlInclude(typeof(Param)), Serializable]
    public class Param:Entity
    {
        RulesBEList _RulesBEList = new RulesBEList();
        string _ApplicationName;

        public string ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }
        public RulesBEList RulesBEList
        {
            get { return _RulesBEList; }
            set { _RulesBEList = value; }
        }

    }
    

    #endregion


    [Serializable]
    public class UpdateRulesResponse : Response<Result>
    {

    }
    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
    }
}
