using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using Fwk.Exceptions;
using Fwk.HelperFunctions;

using Fwk.Caching;


using Fwk.Bases;
using back.Common.ISVC.SearchSalesOrderDetail;
using back.Common.BE;

namespace TestServicePerformance
{

    public class ControllerTest : Fwk.Bases.ClientServiceBase
    {
        public static FwkSimpleStorageBase<Store> Storage = new FwkSimpleStorageBase<Store>();
   

        public  SalesOrderDetailList Execute()
        {
            SearchSalesOrderDetailReq wRequest = new SearchSalesOrderDetailReq();
            SearchSalesOrderDetailRes wResponse;



            wResponse = this.ExecuteService<SearchSalesOrderDetailReq, SearchSalesOrderDetailRes>(wRequest);

            if (wResponse.Error != null)
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(wResponse.Error);

            return wResponse.BusinessData;
        }

      
    }
}
