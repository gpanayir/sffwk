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
namespace Fwk.Security.AD.TestLogin
{
    public partial class frmDinamic : Form
    {
        ADHelper _ADHelper;
        List<DomainsUrl> urls;
       
        public frmDinamic()
        {
            InitializeComponent();
            init();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            try
            {
                if (SetAD())
                {
                    lblCheckResult.Text = _ADHelper.User_CheckLogin(txtLoginName.Text, txtPassword.Text).ToString();
                 
                }
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                
      
            }
        }

        bool SetAD()
        {
            lblURL.Text = string.Empty;

            DomainsUrl wDomainsUrl = (DomainsUrl)comboBox1.SelectedItem;//urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));
            //lblURL.Text = wDomainsUrl.LDAPPath;
            if (wDomainsUrl == null)
            {
                lblCheckResult.Text = "Nombre de dominio incorrecto";
                return false;
            }
            _ADHelper = new ADHelper(wDomainsUrl.LDAPPath, wDomainsUrl.Usr, wDomainsUrl.Pwd);
            
            return true;
        }
        
        void init()
        {
            urls = new List<DomainsUrl>();
            DomainsUrl wDomainsUrl = new DomainsUrl();


            wDomainsUrl.DomainName = "allus-ar";
            //wDomainsUrl.Usr = "ReseteoClaveWeb";
            //wDomainsUrl.Pwd = " R3s3t30W3b";
            //wDomainsUrl.Usr = "moviedo";
            //wDomainsUrl.Pwd = "Lincelin8";

            wDomainsUrl.LDAPPath = "LDAP://172.22.12.142:389/DC=allus,DC=ar";
            //wDomainsUrl.LDAPPAth = "LDAP://172.22.12.141/DC=allus,DC=ar";
            urls.Add(wDomainsUrl);
            wDomainsUrl.Usr = "pruebadesarrollo";
            wDomainsUrl.Pwd = "Prueba+456";


            wDomainsUrl = new DomainsUrl();
            wDomainsUrl.DomainName = "alco";
            wDomainsUrl.LDAPPath = "LDAP://172.22.12.109/DC=actionlinecba,DC=org";
            wDomainsUrl.Usr = "pruebadesarrollo";
            wDomainsUrl.Pwd = "Prueba+456";
            urls.Add(wDomainsUrl);

            wDomainsUrl = new DomainsUrl();
            wDomainsUrl.DomainName = "movistar";
            wDomainsUrl.LDAPPath = "LDAP://10.64.27.5/DC=alcomovistar,DC=com,DC=ar";
            wDomainsUrl.Usr = "pruebadesarrollo";
            wDomainsUrl.Pwd = "Prueba+456";
            urls.Add(wDomainsUrl);

            
         

            wDomainsUrl = new DomainsUrl();
            wDomainsUrl.DomainName = "allus.pe";
            wDomainsUrl.LDAPPath = "LDAP://10.200.154.5:389/DC=allus,DC=pe";
            wDomainsUrl.Usr = "pruebadesarrollo";
            wDomainsUrl.Pwd = "Prueba+456";
            urls.Add(wDomainsUrl);

            domainsUrlBindingSource.DataSource = urls;
            comboBox1.SelectedIndex =0;

            lblURL.Text = ((DomainsUrl)comboBox1.SelectedItem).LDAPPath;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DomainsUrl wDomainsUrl = (DomainsUrl)comboBox1.SelectedItem;//urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));
            if (wDomainsUrl == null) return;
            lblURL.Text = wDomainsUrl.LDAPPath;

        }


    }

    internal class DomainsUrl 

    {
        string _DomainName;

        public string DomainName
        {
            get { return _DomainName; }
            set { _DomainName = value; }
        }
        string _LDAPPath;

        public string LDAPPath
        {
            get { return _LDAPPath; }
            set { _LDAPPath = value; }
        }
        string usr;

        public string Usr
        {
            get { return usr; }
            set { usr = value; }
        }
        string pwd;

        public string Pwd
        {
            get { return pwd; }
            set { pwd = value; }
        }
    }
}
