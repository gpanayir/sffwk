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
            Cliente.ServiceReference1.CompositeType req = new Cliente.ServiceReference1.CompositeType();
            req.Context = new Cliente.ServiceReference1.ContextInformation();
            req.Context.m_HostName = Environment.MachineName;

            Cliente.ServiceReference1.FwkService1Client svc = new Cliente.ServiceReference1.FwkService1Client();
           Cliente.ServiceReference1.CompositeType res = svc.ExecuteService(req);
        }
    }
}
