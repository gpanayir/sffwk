
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
        using System.Collections.Generic;
        using Fwk.Bases;
        using System.Xml.Serialization;
using Fwk.Security.BE;

namespace Fwk.Security.ISVC.UpdateRulesCategory
{

    [Serializable]
    public class UpdateRulesCategoryRequest : Request<RulesCategoryBE>
    {
        public UpdateRulesCategoryRequest()
        {
            this.ServiceName = "UpdateRulesCategoryService";
        }
    }



    [Serializable]
    public class UpdateRulesCategoryResponse : Response<RulesCategoryBE>
    {
    }
     
}
        