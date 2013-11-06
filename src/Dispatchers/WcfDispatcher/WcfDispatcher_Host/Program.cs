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


            //Uri wUri = new Uri("net.tcp://santana:8001/FwkService1");

            //using (ServiceHost host = new ServiceHost(typeof(FwkService1), wUri))
            //{
            //    host.Open();

            //    Console.Write("OLECRAM SERVICE...");
            //    Console.ReadLine();
            //}
            using (ServiceHost host = new ServiceHost(typeof(FwkService1)))
            {
                host.Open();
                
                Console.Write("OLECRAM SERVICE...1");
                Console.WriteLine("STATE:" + host.State.ToString());
                Console.WriteLine();
                Console.WriteLine("BaseAddresses");

                Console.WriteLine("....................................................");
                Console.WriteLine();
                foreach (var url in host.BaseAddresses)
                {
                    Console.WriteLine(url.AbsoluteUri.ToString());
                }
                Console.WriteLine();
                Console.WriteLine("Endpoints");
                Console.WriteLine("....................................................");
                Console.WriteLine();
                foreach (var ep in ((System.ServiceModel.ServiceHostBase)(host)).Description.Endpoints)
                {
                    Console.WriteLine("Name " + ep.Name);
                    Console.WriteLine("Address " + ep.Address.ToString());
                    Console.WriteLine("Name " + ep.Binding.Name);
                    Console.WriteLine();
                }
                
                Console.ReadLine();
            }

            //using (ServiceHost host = new ServiceHost(typeof(FwkService2)))
            //{
            //    host.Open();

            //    Console.Write("OLECRAM SERVICE...2");
            //    Console.ReadLine();
            //}
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
