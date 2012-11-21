using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Net;

namespace CentralizedSecurity.W32.Test
{
    public partial class Form1 : Form
    {
        string usr = "moviedo";
        string pwd = "Lincelin4";
        public Form1()
        {
            InitializeComponent();
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                using (ServiceReference1.CoreSecurityClient clientProxy = new ServiceReference1.CoreSecurityClient())
                {


                    string x = clientProxy.Test();

                    MessageBox.Show(x);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {

           
            //try
            //{

            //    SecurityReference.SecuritySoap proxy = null;
            //    //Creo el ChannelFactory
            //    var cf = new ChannelFactory<SecurityReference.SecuritySoap>("SecuritySoap");

            //    //Tomo los elementos del Binding y seteo IncludeTimestamp en false
            //    BindingElementCollection elements = cf.Endpoint.Binding.CreateBindingElements();
            //    //elements.Find<SecurityBindingElement>().IncludeTimestamp = false;
            //    // Creo un nuevo binding con los elementos modificados
            //    CustomBinding newBinding = new CustomBinding(elements);
            //    //Asigno el nuevo binding al Endpoint
            //    cf.Endpoint.Binding = newBinding;
            //    cf.Credentials.UserName.UserName = usr;
            //    cf.Credentials.UserName.Password = pwd;
            //    EndpointAddress endpoint = new EndpointAddress("http://localhost/CentralizedSecurity/security.asmx?");
            //    proxy = cf.CreateChannel(endpoint);
            //    SecurityReference.Retrive_DomainsUrlRequest req = new SecurityReference.Retrive_DomainsUrlRequest();

            //    CentralizedSecurity.W32.Test.SecurityReference.Retrive_DomainsUrlResponse res = proxy.Retrive_DomainsUrl(req);
            //    MessageBox.Show(res.Body.Retrive_DomainsUrlResult);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            //try
            //{

            //    using (SecurityReference.SecuritySoapClient clientProxy = new SecurityReference.SecuritySoapClient())
            //    {
            //        BasicHttpBinding basicHttpBinding = new BasicHttpBinding();

            //        basicHttpBinding.Security.Mode = BasicHttpSecurityMode.TransportCredentialOnly;

            //        basicHttpBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Windows;

            //        //EndpointAddress endpoint = new EndpointAddress("http://localhost/CentralizedSecurity/security.asmx?");
            //        clientProxy.ClientCredentials.Windows.AllowedImpersonationLevel = System.Security.Principal.TokenImpersonationLevel.None;

            //        //clientProxy.ChannelFactory.Credentials.Windows.ClientCredential = System.Net.CredentialCache.DefaultNetworkCredentials;
            //        clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.UserName = usr;
            //        clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.Password = pwd;
            //        clientProxy.ChannelFactory.Credentials.Windows.ClientCredential.Domain = "allus-ar";

            //        //clientProxy.ClientCredentials.Windows.ClientCredential.UserName = "moviedo";
            //        //clientProxy.ClientCredentials.Windows.ClientCredential.Password = "Lincelin4";
            //        //clientProxy.ClientCredentials.Windows.ClientCredential.Domain = "allus-ar";
            //        MessageBox.Show(clientProxy.Retrive_DomainsUrl());
            //    }
            //}
            //catch (Exception t)
            //{
            //    MessageBox.Show(t.Message);
            //}


            //try
            //{
            //    using (SecurityReference.SecuritySoapClient clientProxy = new SecurityReference.SecuritySoapClient())
            //    {
            //        //Creo el ChannelFactory
            //        clientProxy.ClientCredentials.Windows.ClientCredential.UserName = usr;

            //        clientProxy.ClientCredentials.Windows.ClientCredential.Password = pwd;
            //        clientProxy.ClientCredentials.Windows.ClientCredential.Domain = "allus-ar";
            //        //System.Net.NetworkCredential cr = new System.Net.NetworkCredential("moviedo", "3");
            //        //clientProxy.InnerChannel.cre.ClientCertificate.Certificate = certificado;
            //        MessageBox.Show(clientProxy.Retrive_DomainsUrl());


            //    }
            //}
            //catch (Exception t)
            //{
            //    MessageBox.Show(t.Message);
            //}
        }
        //SecurityReference.SecuritySoapClient client = new SecurityReference.SecuritySoapClient();
        private void button2_Click(object sender, EventArgs e)
        {
            
            //using (SecurityReference.SecuritySoapClient client = new SecurityReference.SecuritySoapClient())
            //{
               // client.BeginRetrive_DomainsUrl(Retrive_DomainsUrlCallback, null);
                
            //}
        }

        void Retrive_DomainsUrlCallback(IAsyncResult result)
        {


            //string r = client.EndRetrive_DomainsUrl(result);
            //MessageBox.Show(r);
            //client.Close();
            
        }

      
    }
}
