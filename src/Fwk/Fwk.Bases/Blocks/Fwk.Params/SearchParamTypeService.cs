using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Fwk.Params.Back;
using Fwk.Params.BE;
using Fwk.Params.Isvc.SearchParamType;

namespace Fwk.Params.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchParamTypeService : BusinessService<SearchParamTypeReq, SearchParamTypeRes>
    {
        public override SearchParamTypeRes Execute(SearchParamTypeReq pServiceRequest)
        {
            SearchParamTypeRes wRes = new SearchParamTypeRes();


            wRes.BusinessData = ParamDAC.RetriveParamType(pServiceRequest.BusinessData.ParamTypeId,
                 pServiceRequest.BusinessData.Enabled, pServiceRequest.ContextInformation.AppId);
            return wRes;
        }

    }
}

namespace Fwk.Params.Isvc.SearchParamType
{
    [Serializable]
    public class SearchParamTypeReq : Fwk.Bases.Request<Params>
    {

        public SearchParamTypeReq()
        {
            base.ServiceName = "SearchParamTypeService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        /// <summary>
        /// 
        /// </summary>
        public bool? Enabled { get; set; }

        /// <summary>
        /// Tipo de parametro
        /// </summary>
        public int? ParamTypeId{ get; set; }
        
        
        /// <summary>
        /// Param de referencia. Referencia a un parametro padre
        /// </summary>
        public int? ParentId { get; set; }
        
    }


    [Serializable]
    public class SearchParamTypeRes : Fwk.Bases.Response<ParamTypeList>
    {
    }

}
