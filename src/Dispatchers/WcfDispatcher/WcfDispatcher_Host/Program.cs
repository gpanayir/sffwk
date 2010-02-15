using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WcfDispatcher;

namespace WcfDispatcher_Host
{
    //WcfSvcHost.exe /service:D:\Projects\Allus\Bigbang\trunk\tools\WcfDispatcher\WcfDispatcher_Host\bin\Debug\WcfDispatcher.dll /config:D:\Projects\Allus\Bigbang\trunk\tools\WcfDispatcher\WcfDispatcher_Host\App.config
    class Program
    {
        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(FwkService1));
            host.Open(); 
            Console.WriteLine("the host is open");
            Console.ReadLine();

        }
    }
}
