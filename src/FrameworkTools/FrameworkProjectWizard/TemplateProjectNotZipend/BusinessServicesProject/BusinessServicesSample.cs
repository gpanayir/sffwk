using System;
using System.Data;
using Fwk.Bases;
using $BackendNamespace$.BE;
using $BackendNamespace$.BC;
using $CommonNamespace$;

namespace $BackendNamespace$.SVC
{

    /// <summary>
    /// Put your service description here.-
    /// </summary>
    public class BusinessServicesSample : BusinessService<SampleRequest, SampleResponse>
    {
        public override SampleResponse Execute(SampleRequest pServiceRequest)
        {
            SampleResponse wRes = new SampleResponse();

            //----------------------------
            // Implement your code here..
            //----------------------------


            wRes.Result.SomeValueToReturn = 0;

            return wRes;
        }
    }
}
