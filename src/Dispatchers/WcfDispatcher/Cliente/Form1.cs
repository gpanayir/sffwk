using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using Health.Isvc.RetrivePatients;
using Health.BE;
using Newtonsoft.Json;
using Fwk.HelperFunctions;
using Fwk.Bases;
using Fwk.Bases.Connector;


namespace Cliente
{
    public partial class Form1 : Form
    {
        WCFWrapper_01 _WCFWrapper_01 =null;
        WCFWrapper_02 _WCFWrapper_02 = null;
        ServiceReference1.FwkServiceClient svcProxy;
        public Form1()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
             _WCFWrapper_01 = new WCFWrapper_01();
             _WCFWrapper_02 = new WCFWrapper_02();
            _WCFWrapper_01.SourceInfo = "net.tcp://localhost:8001/FwkService";
            _WCFWrapper_02.SourceInfo = "net.tcp://localhost:8001/FwkService";

        }
     
        private void btn_RetrivePatientsReq1_Click(object sender, EventArgs e)
        {
            //ServiceReference1.ExecuteServiceRequest req = new ServiceReference1.ExecuteServiceRequest();

            //SomeCompany.BE.AccountBE account = new SomeCompany.BE.AccountBE();
            //account.Name = "alskflH FLADSKFÑL SFFSADF FSDFSF";
            //account.Id = 12342134;
            //account.TypeId = 1009;
            //req.jsonRequets = Newtonsoft.Json.JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);
            //checkProxy();

            //ServiceReference1.ExecuteServiceResponse res = svcProxy.ExecuteService(req);


            RetrivePatientsReq req = new RetrivePatientsReq();

            req.BusinessData.Id = 1;
            req.ContextInformation.UserId = "hylux";
            req.ContextInformation.AppId = "ddsadsa";

            RetrivePatientsRes res = _WCFWrapper_01.ExecuteService<RetrivePatientsReq, RetrivePatientsRes>(req);
           

            if (res.Error != null)
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message);


            txtResponse.Text = res.BusinessData.GetXml();
             
            
        }
        void checkProxy()
        {
            if(svcProxy==null)
            {
                svcProxy = new ServiceReference1.FwkServiceClient("FirstEndpoint");
                svcProxy.Open();
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

            EndpointAddress address = new EndpointAddress("net.tcp://localhost:8001/FwkService");
            using (ServiceReference1.FwkServiceClient svcProxy = new ServiceReference1.FwkServiceClient(binding, address))
            {
                svcProxy.Open();
                ServiceReference1.ExecuteServiceResponse res = svcProxy.ExecuteService(req);


            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

            RetrivePatientsReq req = new RetrivePatientsReq();

            req.BusinessData.Id = 1;
            req.ContextInformation.UserId = "hylux";
            req.ContextInformation.AppId = "ddsadsa";

            RetrivePatientsRes res = _WCFWrapper_02.ExecuteService<RetrivePatientsReq, RetrivePatientsRes>(req);


            if (res.Error != null)
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message);


            txtResponse.Text = res.BusinessData.GetXml();
        }


        public static PatientList RetrivePatients(int? IdPersona)
        {
            RetrivePatientsReq req = new RetrivePatientsReq();

            req.BusinessData.Id = IdPersona;
            req.ContextInformation.UserId = "hylux";

            req.ContextInformation.AppId = "ddsadsa";

            RetrivePatientsRes res = req.ExecuteService<RetrivePatientsReq, RetrivePatientsRes>(req);
           

            if (res.Error != null)
                MessageBox.Show(Fwk.Exceptions.ExceptionHelper.ProcessException(res.Error).Message);
            return res.BusinessData;
        }

        private void button4_Click(object sender, EventArgs e)
        {
             RetrivePatientsReq req = new RetrivePatientsReq();

            req.BusinessData.Id = 33;
            req.ContextInformation.UserId = "hylux";

            req.ContextInformation.AppId = "ddsadsa";
            String jsonRequets = Newtonsoft.Json.JsonConvert.SerializeObject(req, Formatting.None);
            Type t = ReflectionFunctions.CreateType("Health.Isvc.RetrivePatients.RetrivePatientsReq,SomeCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
         Type reqType =   Type.GetType("Health.Isvc.RetrivePatients.RetrivePatientsReq,SomeCompany, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null");
            

         var wRequest = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonRequets, reqType, new JsonSerializerSettings());
         //IServiceContract wRequest2 = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonRequets, typeof(IServiceContract), new JsonSerializerSettings());   
        }

    }
}
