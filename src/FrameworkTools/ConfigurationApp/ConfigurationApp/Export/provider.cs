using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.ConfigSection;

namespace ConfigurationApp
{
    public partial class provider : UserControl
    {
        ConfigProviderElement Provider;
        public provider()
        {
            InitializeComponent();
        }

        public void Populate(ConfigProviderElement pProvider)
        {
            Provider = pProvider;
            if (pProvider == null) return;
            SetProvider();
        }
        public void SetConnected(bool pIsConnected)
        {
            if (pIsConnected)
                lblConnectionStatus.Text = "Connected";
            else
                lblConnectionStatus.Text = "Disconnected";
        }
        void SetProvider()
        {

            lblConnectionType.Text = Provider.ConfigProviderType.ToString();
            txtAddres.Text = Provider.SourceInfo;
        
            cnnstring.Clear();
            if (Provider.ConfigProviderType == ConfigProviderType.local)
            {
                cnnstring.Visible = false;
                lblAddress.Text = "File :";
                btnView.Visible = true;
            }
            if (Provider.ConfigProviderType == ConfigProviderType.sqldatabase)
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

        private void btnView_Click(object sender, EventArgs e)
        {
            if (string.Compare(lblConnectionType.Text, "Web Service", true) == 0)
                System.Diagnostics.Process.Start("www.yahoo.com.ar");
            else
                System.Diagnostics.Process.Start("explorer.exe", txtAddres.Text);
        } 
    }
}
