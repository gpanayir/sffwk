using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;


namespace Cliente
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ServiceReference1.ExecuteServiceRequest req = new ServiceReference1.ExecuteServiceRequest();
           
            SomeCompany.BE.AccountBE account = new SomeCompany.BE.AccountBE();
            account.Name = "alskflH FLADSKFÑL SFFSADF FSDFSF";
            account.Id = 12342134;
            account.TypeId = 1009;
            req.jsonRequets = Newtonsoft.Json.JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);

            using (ServiceReference1.FwkServiceClient svcProxy = new ServiceReference1.FwkServiceClient("FirstEndpoint"))
            {
                svcProxy.Open();
                ServiceReference1.ExecuteServiceResponse res = svcProxy.ExecuteService(req);
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.ExecuteServiceRequest req = new ServiceReference1.ExecuteServiceRequest();

            SomeCompany.BE.AccountBE account = new SomeCompany.BE.AccountBE();
            account.Name = "alskflH FLADSKFÑL SFFSADF FSDFSF";
            account.Id = 12342134;
            account.TypeId = 1009;
            req.jsonRequets = Newtonsoft.Json.JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);


            NetTcpBinding binding = new NetTcpBinding();
            binding.Name = "tcp";

            EndpointAddress address = new EndpointAddress ("net.tcp://localhost:8001/FwkService");
            using (ServiceReference1.FwkServiceClient svcProxy = new ServiceReference1.FwkServiceClient(binding, address))
            {
                svcProxy.Open();
                ServiceReference1.ExecuteServiceResponse res = svcProxy.ExecuteService(req);


            }

        }
    }
}
