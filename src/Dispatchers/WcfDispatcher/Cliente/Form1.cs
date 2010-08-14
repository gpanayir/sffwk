using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WcfCommon;

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
            Cliente.ServiceReference1.CompositeType req = new Cliente.ServiceReference1.CompositeType();
            req.Context = new Fwk.Bases.ContextInformation();
            req.Context.HostName = Environment.MachineName;
            
            Survey survey = new Survey();
            survey.Description = "alskflH FLADSKFÑL SFFSADF FSDFSF";
            survey.ModifiedByUserId = 12342134;
            survey.Name = "asd asdsd mdhfghgfh";
            req.EntityField = survey;

            using (Cliente.ServiceReference1.FwkService1Client svcProxy = new Cliente.ServiceReference1.FwkService1Client())
            {
                svcProxy.Open();
                Cliente.ServiceReference1.CompositeType res = svcProxy.ExecuteService(req);
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cliente.ServiceReference2.CompositeType req = new Cliente.ServiceReference1.CompositeType();
            //req.Context = new Fwk.Bases.ContextInformation();
            //req.Context.HostName = Environment.MachineName;

            Survey survey = new Survey();
            survey.Description = "alskflH FLADSKFÑL SFFSADF FSDFSF";
            survey.ModifiedByUserId = 12342134;
            survey.Name = "asd asdsd mdhfghgfh";
            //req.EntityField = survey;

            using (Cliente.ServiceReference2.FwkService2Client svcProxy = new Cliente.ServiceReference2.FwkService2Client ())
            {
                svcProxy.Open();
                object res = svcProxy.ExecuteService(survey);

            }
        }
    }
}
