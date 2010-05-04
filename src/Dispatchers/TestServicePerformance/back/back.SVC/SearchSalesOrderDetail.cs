using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using Fwk.Bases;
using back.Common.BE;

namespace back.Common.ISVC.SearchSalesOrderDetail
{

    #region [Request]
    [Serializable]
    public class SearchSalesOrderDetailReq : Request<Params>
    {
        public SearchSalesOrderDetailReq()
        {
            base.ServiceName = "SearchSalesOrderDetailService";
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
    public class SearchSalesOrderDetailRes : Response<SalesOrderDetailList>
    {
    }

    
    #endregion
}
