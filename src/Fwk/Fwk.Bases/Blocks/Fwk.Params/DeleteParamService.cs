using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using Fwk.Bases;
using Fwk.Params.Back;
using Fwk.Params.BE;
using Fwk.Params.Isvc.DeleteParam;


namespace Fwk.Params.Svc
{
    /// <summary>
    /// 
    /// </summary>
    public class DeleteParametroService : BusinessService<DeleteParamReq, DeleteParamRes>
    {
        public override DeleteParamRes Execute(DeleteParamReq pServiceRequest)
        {
            DeleteParamRes wRes = new DeleteParamRes();
            ParametroBC wParametroBC = new ParametroBC(pServiceRequest.ContextInformation.CompanyId);
            wParametroBC.Delete(pServiceRequest.BusinessData.IdParametro, pServiceRequest.BusinessData.Name);
            return wRes;
        }

       
    }
}

namespace Fwk.Params.Isvc.DeleteParam
{
    [Serializable]
    public class DeleteParamReq : Fwk.Bases.Request<Params>
    {

        public DeleteParamReq()
        {
            base.ServiceName = "DeleteParamService";
        }
    }

    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        int _Id;

        public int IdParametro
        {
            get { return _Id; }
            set { _Id = value; }
        }

    }



    [Serializable]
    public class DeleteParamRes : Fwk.Bases.Response<DummyContract>
    {
    }

}