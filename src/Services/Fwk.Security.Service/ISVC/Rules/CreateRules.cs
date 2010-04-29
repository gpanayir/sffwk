using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.CreateRules
{
	
	[Serializable]
    public class CreateRulesRequest : Request<RulesBE>
	{
		public CreateRulesRequest()
		{
			this.ServiceName = "CreateRulesService";
		}
	}
    [Serializable]
    public class CreateRulesResponse : Response<RulesBE>
    {
    }



    
	
	
}
       