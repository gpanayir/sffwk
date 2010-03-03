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
        SingletonFactoryArray<DomainsUrl> domainFactory = new SingletonFactoryArray<DomainsUrl>();
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
                lblCheckResult.Text = _ADHelper.User_CheckLogin(txtLoginName.Text, txtPassword.Text).ToString();
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
                DomainsUrl wDomainsUrl = urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));
                _ADHelper = new ADHelper (wDomainsUrl.LDAPPAth,txtLoginName.Text, txtPassword.Text);
                //_ADHelper.User_Exists(txtLoginName.Text);
                lblCheckResult.Text = _ADHelper.User_CheckLogin(txtLoginName.Text, txtPassword.Text).ToString();
            }
        }

        bool SetAD()
        {
            DomainsUrl wDomainsUrl = urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));
            
            if (wDomainsUrl == null)
            {
                lblCheckResult.Text = "Nombre de dominio incorrecto";
                return false;
            }
            _ADHelper = new ADHelper(wDomainsUrl.LDAPPAth, wDomainsUrl.Usr, wDomainsUrl.Pwd);
            return true;
        }
        
        void init()
        {
            urls = new List<DomainsUrl>();
            DomainsUrl wDomainsUrl = new DomainsUrl();
            wDomainsUrl.DomainName = "alco";
            wDomainsUrl.LDAPPAth = "LDAP://172.22.12.109/DC=actionlinecba,DC=org";
            urls.Add(wDomainsUrl);

            wDomainsUrl = new DomainsUrl();
            wDomainsUrl.DomainName = "movistar";
            wDomainsUrl.LDAPPAth = "LDAP://10.64.27.5/DC=alcomovistar,DC=com,DC=ar";
            urls.Add(wDomainsUrl);

            wDomainsUrl = new DomainsUrl();
            wDomainsUrl.DomainName = "allus-ar";
            //wDomainsUrl.Usr = "ReseteoClaveWeb";
            //wDomainsUrl.Pwd = " R3s3t30W3b";
            wDomainsUrl.Usr = "moviedo";
            wDomainsUrl.Pwd = "Lincelin8";
            //wDomainsUrl.LDAPPAth = "LDAP://172.22.12.142/DC=allus,DC=ar";
            wDomainsUrl.LDAPPAth = "LDAP://172.22.12.142:389/DC=allus,DC=ar";
            //wDomainsUrl.LDAPPAth = "LDAP://172.22.12.141/DC=allus,DC=ar";
            
            urls.Add(wDomainsUrl); 
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
        string _LDAPPAth;

        public string LDAPPAth
        {
            get { return _LDAPPAth; }
            set { _LDAPPAth = value; }
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
