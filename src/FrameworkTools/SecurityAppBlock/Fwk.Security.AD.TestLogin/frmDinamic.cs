using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Fwk.Security.ActiveDirectory;
using Fwk.Bases;

using System.Security.Cryptography.X509Certificates;
using Fwk.Exceptions;

namespace Fwk.Security.AD.TestLogin
{
    public partial class frmDinamic : Form
    {
        LDAPHelper _ADHelper;
        IDirectoryService _ADHelperSecure;
        List<DomainUrlInfo> urls;

        public frmDinamic()
        {
            InitializeComponent();
            init();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {

            lblCheckResult.Clear();
            txtError.Clear();
            try
            {
                if (SetAD(false))
                {
                    TechnicalException logError = null;
                    //lblCheckResult.Text = _ADHelper.User_CheckLogin(txtLoginName.Text, txtPassword.Text).ToString();
                    lblCheckResult.Text = _ADHelper.User_Logon(txtLoginName.Text, txtPassword.Text, out logError).ToString();

                    if (logError != null)
                        txtError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(logError);
                    //_ADHelper.User_CheckLogin2(txtLoginName.Text, txtPassword.Text);

                }
            }
            catch (Exception ex)
            {
                txtError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);


            }
        }

        bool SetAD(Boolean pSecure)
        {
            lblURL.Text = string.Empty;

            DomainUrlInfo wDomainUrlInfo = (DomainUrlInfo)cmbDomains.SelectedItem;//urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));

            if (wDomainUrlInfo == null)
            {
                lblCheckResult.Text = "Nombre de dominio incorrecto";
                return false;
            }
            //_ADHelper = new ADHelper(wDomainUrlInfo.LDAPPath, wDomainUrlInfo.Usr, wDomainUrlInfo.Pwd);
            _ADHelper = new LDAPHelper(wDomainUrlInfo.DomainName, "testActiveDirectory", pSecure);

            return true;
        }

        void init()
        {

            try
            {
                urls = ADHelper.DomainsUrl_GetList("testActiveDirectory");//@"Data Source=SANTANA\SQLEXPRESS;Initial Catalog=Logs;Integrated Security=True");
                domainUrlInfoBindingSource.DataSource = urls;
                cmbDomains.SelectedIndex = 1;

                lblURL.Text = ((DomainUrlInfo)cmbDomains.SelectedItem).LDAPPath;
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                btnCheck.Enabled = false;
            }
            //urls = new List<DomainUrlInfo>();
            //DomainUrlInfo wDomainUrlInfo = new DomainUrlInfo();
            //wDomainUrlInfo.DomainName = "allus-ar";
            ////wDomainUrlInfo.Usr = "ReseteoClaveWeb";
            ////wDomainUrlInfo.Pwd = " R3s3t30W3b";
            ////wDomainUrlInfo.Usr = "moviedo";
            ////wDomainUrlInfo.Pwd = "Lincelin8";

            //wDomainUrlInfo.LDAPPath = "LDAP://172.22.12.142:389/DC=allus,DC=ar";
            ////wDomainUrlInfo.LDAPPAth = "LDAP://172.22.12.141/DC=allus,DC=ar";
            //urls.Add(wDomainUrlInfo);
            //wDomainUrlInfo.Usr = "pruebadesarrollo";
            //wDomainUrlInfo.Pwd = "Prueba+456";


            //wDomainUrlInfo = new DomainUrlInfo();
            //wDomainUrlInfo.DomainName = "alco";
            //wDomainUrlInfo.LDAPPath = "LDAP://172.22.12.109/DC=actionlinecba,DC=org";
            //wDomainUrlInfo.Usr = "pruebadesarrollo";
            //wDomainUrlInfo.Pwd = "Prueba+456";
            //urls.Add(wDomainUrlInfo);

            //wDomainUrlInfo = new DomainUrlInfo();
            //wDomainUrlInfo.DomainName = "movistar";
            //wDomainUrlInfo.LDAPPath = "LDAP://10.64.27.5/DC=alcomovistar,DC=com,DC=ar";
            //wDomainUrlInfo.Usr = "pruebadesarrollo";
            //wDomainUrlInfo.Pwd = "Prueba+456";
            //urls.Add(wDomainUrlInfo);




            //wDomainUrlInfo = new DomainUrlInfo();
            //wDomainUrlInfo.DomainName = "allus.pe";
            //wDomainUrlInfo.LDAPPath = "LDAP://10.200.154.5:389/DC=allus,DC=pe";
            //wDomainUrlInfo.Usr = "pruebadesarrollo";
            //wDomainUrlInfo.Pwd = "Prueba+456";
            //urls.Add(wDomainUrlInfo);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DomainUrlInfo wDomainUrlInfo = (DomainUrlInfo)cmbDomains.SelectedItem;//urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));
            if (wDomainUrlInfo == null) return;
            lblURL.Text = wDomainUrlInfo.LDAPPath;

        }

        private void frmDinamic_Load(object sender, EventArgs e)
        {

        }

        private void ResetPwd_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetAD(true))
                {
                    String Pwd = null;
                    if (!String.IsNullOrEmpty(txtPassword.Text))
                        Pwd = txtPassword.Text;
                    _ADHelper.ResetPwd(txtLoginName.Text, Pwd, ForceChange.Checked, UnLock.Checked);
                    lblCheckResult.Text = "Clave Reseteada";
                }
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRootCert("AllusCerts/RootAlcomovistar.cer");
            AddRootCert("AllusCerts/RootAllusArgent.cer");
            AddRootCert("AllusCerts/RootAllusPeru.cer");
        }

        void AddRootCert(String pCertFilePath)
        {
            X509Certificate2 wCertificate = new X509Certificate2(pCertFilePath);
            X509Store wStore = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            wStore.Open(OpenFlags.ReadWrite);
            wStore.Add(wCertificate);
            wStore.Close();

        }


    }


}
