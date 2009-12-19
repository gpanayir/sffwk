//----------------------------
// 
//----------------------------

using System;
using System.Data;
using System.Collections.Generic;
using Fwk.Bases;
using $solutioname$.Common.BE;
using $solutioname$.BackEnd.BC;
using $solutioname$.Common.ISVC.Sample;




namespace $solutioname$.SVC
{
    public class SampleService : BusinessService<SampleReq, SampleRes>
    {
        public override SampleRes Execute(SampleReq req)
        {
            SampleRes res = new SampleRes();


            //----------------------------
            // Implement your code here..
            //----------------------------


            return res;
        }
    }
}
