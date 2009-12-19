using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Fwk.Bases;

namespace $solutioname$.Common.ISVC
{
    
    #region [Request]
    [Serializable]
    public class SearchSurveyByParamRequest : Request<Params>
    {
        public SearchSurveyByParamRequest()
        {
            base.ServiceName = "SearchSurveyByParamService";
        }
    }

     #region [BussinesData]
    [XmlInclude(typeof(Params)), Serializable]
    public class Params : Entity
    {
    }
    
    #endregion
    #endregion

    #region [Response]
    [Serializable]
    public class CreateSurveyResultResponse : Response<Result>
    {
    }

    #region [BussinesData]

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
     

    }

    #endregion
    #endregion
}
