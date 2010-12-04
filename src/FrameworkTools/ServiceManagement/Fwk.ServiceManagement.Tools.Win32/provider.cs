using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.ConfigSection;

namespace Fwk.ServiceManagement.Tools.Win32
{
    public partial class provider : UserControl
    {
        ServiceProviderElement Provider;
        public provider()
        {
            InitializeComponent();
        }

        public void Populate(ServiceProviderElement pProvider)
        {
            Provider = pProvider;
        }

        void SetProvider()
        {

            lblConnectionType.Text = Provider.ProviderType.ToString();
            txtAddres.Text = Provider.SourceInfo;
            txtApplicationId.Text = Provider.ApplicationId;
            cnnstring.Clear();
            if (Provider.ProviderType == ServiceProviderType.xml)
            {
                cnnstring.Visible = false;
                lblAddress.Text = "File :";
                btnView.Visible = true;
            }
            if (Provider.ProviderType == ServiceProviderType.sqldatabase)
            {
                btnView.Visible = false;
                lblAddress.Text = "Connection string";
                if (System.Configuration.ConfigurationManager.ConnectionStrings[Provider.SourceInfo] != null)
                {
                    Fwk.DataBase.CnnString c = new Fwk.DataBase.CnnString(Provider.SourceInfo, System.Configuration.ConfigurationManager.ConnectionStrings[Provider.SourceInfo].ConnectionString);
                    cnnstring.Populate(c);
                    cnnstring.Visible = true;
                }

            }
        } 
    }
}
