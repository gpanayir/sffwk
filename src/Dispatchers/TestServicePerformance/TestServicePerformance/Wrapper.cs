using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;

namespace TestServicePerformance
{
    internal class RemotingWrapper

    {
        Fwk.Remoting.FwkRemoteObject _RemoteObj;

        internal Fwk.Remoting.FwkRemoteObject RemoteObj
        {
            get { return _RemoteObj; }
        }

        internal void Init(string server, string port, string objectUri)
        {
           
            string url = string.Concat("tcp://",server,":",port,@"/",objectUri);
            Init( url); 
        }

        internal void Init(string url)
        {
            if (_RemoteObj != null)
                _RemoteObj = null;
       
             _RemoteObj = (Fwk.Remoting.FwkRemoteObject)Activator.GetObject(typeof(Fwk.Remoting.FwkRemoteObject), url);
        }



    }
}
