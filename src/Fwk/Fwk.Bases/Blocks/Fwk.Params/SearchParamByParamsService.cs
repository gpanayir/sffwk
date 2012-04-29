using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Fwk.Params.Back;
using Fwk.Params.BE;
using Fwk.Params.Isvc.SearchParams;

namespace Fwk.Params.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class SearchParamsService : BusinessService<SearchParamsReq, SearchParamsRes>
    {
        public override SearchParamsRes Execute(SearchParamsReq pServiceRequest)
        {
            SearchParamsRes wRes = new SearchParamsRes();


            wRes.BusinessData = ParametroDAC.GetByParams(pServiceRequest.BusinessData.IdTipoParametro,
                pServiceRequest.BusinessData.IdParametroRef, pServiceRequest.BusinessData.Vigente,
                pServiceRequest.ContextInformation.CompanyId);
            return wRes;
        }

    }
}

namespace Fwk.Params.Isvc.SearchParams
{
    [Serializable]
    public class SearchParamsReq : Fwk.Bases.Request<Params>
    {

        public SearchParamsReq()
        {
            base.ServiceName = "SearchParamsService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        bool? vigente;

        public bool? Vigente
        {
            get { return vigente; }
            set { vigente = value; }
        }

        int? _IdTipoParametro;

        public int? IdTipoParametro
        {
            get { return _IdTipoParametro; }
            set { _IdTipoParametro = value; }
        }
        int? _IdParametroRef;

        public int? IdParametroRef
        {
            get { return _IdParametroRef; }
            set { _IdParametroRef = value; }
        }
    }


    [Serializable]
    public class SearchParamsRes : Fwk.Bases.Response<ParamList>
    {
    }

}
