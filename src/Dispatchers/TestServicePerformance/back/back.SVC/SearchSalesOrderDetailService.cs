//----------------------------
// 
//----------------------------

using System;
using System.Data;
using System.Collections.Generic;
using Fwk.Bases;
using back.Common.BE;
using back.BackEnd.BC;
using back.Common.ISVC.SearchSalesOrderDetail;
using System.Collections;




namespace back.BackEnd.SVC
{
    public class SearchSalesOrderDetailService : BusinessService<SearchSalesOrderDetailReq, SearchSalesOrderDetailRes>
    {
        public override SearchSalesOrderDetailRes Execute(SearchSalesOrderDetailReq req)
        {
            SearchSalesOrderDetailRes res = new SearchSalesOrderDetailRes();


            SampleBC BC = new SampleBC(req.ContextInformation.AppId);
            Measures m = null;
            res.BusinessData.SalesOrderDetailList = BC.SearchSalesOrderDetail(out m );

            res.BusinessData.Times = m;
            return res;
        }
    }
}
