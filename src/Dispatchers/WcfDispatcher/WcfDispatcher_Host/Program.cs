using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using WcfDispatcher;

namespace WcfDispatcher_Host
{
    //WcfSvcHost.exe /service:D:\Projects\Allus\pelsoft\trunk\tools\WcfDispatcher\WcfDispatcher_Host\bin\Debug\WcfDispatcher.dll /config:D:\Projects\Allus\pelsoft\trunk\tools\WcfDispatcher\WcfDispatcher_Host\App.config
    class Program
    {
        static void Main(string[] args)
        {


            //Uri wUri = new Uri("net.tcp://santana:8001/FwkService1");

            //using (ServiceHost host = new ServiceHost(typeof(FwkService1), wUri))
            //{
            //    host.Open();

            //    Console.Write("OLECRAM SERVICE...");
            //    Console.ReadLine();
            //}
            //using (ServiceHost host = new ServiceHost(typeof(FwkService1)))
            //{
            //    host.Open();

            //    Console.Write("OLECRAM SERVICE...1");
            //    Console.ReadLine();
            //}

            using (ServiceHost host = new ServiceHost(typeof(FwkService2)))
            {
                host.Open();

                Console.Write("OLECRAM SERVICE...2");
                Console.ReadLine();
            }
        }

        void SetNetTcpBinding(ServiceHost host)
        {

            NetTcpBinding tcpBinding = new NetTcpBinding();
            Uri wUri = new Uri("net.tcp://santana:8001/FwkService1");
            tcpBinding.TransactionFlow = true;

            host.AddServiceEndpoint(typeof(IFwkService1), tcpBinding, wUri);
            host.Open();
        }

    }


}
