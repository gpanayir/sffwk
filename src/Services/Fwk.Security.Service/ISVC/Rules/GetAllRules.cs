using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;


namespace Fwk.Security.ISVC.GetAllRules
{
    [Serializable]
    public class GetAllRulesReq : Request<Param>
    {
        public GetAllRulesReq()
		{
			this.ServiceName = "GetAllRulesService";
		}
    }

    #region [BussinesData]

    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {

        private System.String _ApplicationName;

        public System.String ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }
        
                

    }

    #endregion

    [Serializable]
    public class GetAllRulesRes : Response<RulesBEList>
    {
    }
}
