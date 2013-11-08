using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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
            req.composite = new ServiceReference1.CompositeType();
            req.composite.Context = new ServiceReference1.ContextInformation();
            req.composite.Context._HostName = Environment.MachineName;
            req.composite.Context._HostTime = System.DateTime.Now;

            SomeCompany.BE.AccountBE account = new SomeCompany.BE.AccountBE();
            account.Name = "alskflH FLADSKFÑL SFFSADF FSDFSF";
            account.Id = 12342134;
            account.TypeId = 1009;
            req.composite.JsonBussinesData = Newtonsoft.Json.JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);

            using (ServiceReference1.FwkService1Client svcProxy = new ServiceReference1.FwkService1Client("FirstEndpoint"))
            {
                svcProxy.Open();
                ServiceReference1.ExecuteServiceResponse res = svcProxy.ExecuteService(req);
                
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cliente.ServiceReference2.CompositeType req = new Cliente.ServiceReference1.CompositeType();
            //req.Context = new Fwk.Bases.ContextInformation();
            //req.Context.HostName = Environment.MachineName;

            //Survey survey = new Survey();
            //survey.Description = "alskflH FLADSKFÑL SFFSADF FSDFSF";
            //survey.ModifiedByUserId = 12342134;
            //survey.Name = "asd asdsd mdhfghgfh";
            ////req.EntityField = survey;

            //using (Cliente.ServiceReference2.FwkService2Client svcProxy = new Cliente.ServiceReference2.FwkService2Client ())
            //{
            //    svcProxy.Open();
            //    object res = svcProxy.ExecuteService(survey);

            //}
        }
    }
}
