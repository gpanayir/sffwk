using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Exceptions;
using Fwk.Bases;
using back.BackEnd.DAC;
using back.Common.BE;

using System.Data.Common;
using System.Data;

namespace back.BackEnd.BC
{

    public class SampleBC : BaseBC
    {

        public SampleBC(string x)
            : base(x)
        { }
       
        public SalesOrderDetailList SearchSalesOrderDetail()
        {
            double sqlCallTime;
            double mappingTime;
            return SampleDAC.Search(base.CompanyId, out mappingTime, out sqlCallTime);
        }

    }
}
