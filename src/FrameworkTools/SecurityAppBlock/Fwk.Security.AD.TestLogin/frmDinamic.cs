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
        List<DomainUrlInfo> urls;
       
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
                    //_ADHelper.User_CheckLogin2(txtLoginName.Text, txtPassword.Text);
                 
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

            DomainUrlInfo wDomainUrlInfo = (DomainUrlInfo)comboBox1.SelectedItem;//urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));
            
            if (wDomainUrlInfo == null)
            {
                lblCheckResult.Text = "Nombre de dominio incorrecto";
                return false;
            }
            _ADHelper = new ADHelper(wDomainUrlInfo.LDAPPath, wDomainUrlInfo.Usr, wDomainUrlInfo.Pwd);
            
            return true;
        }
        
        void init()
        {
           
            try
            {
                urls = ADHelper.DomainsUrl_GetList("testActiveDirectory");//@"Data Source=SANTANA\SQLEXPRESS;Initial Catalog=Logs;Integrated Security=True");
                domainUrlInfoBindingSource.DataSource = urls;
                comboBox1.SelectedIndex = 0;

                lblURL.Text = ((DomainUrlInfo)comboBox1.SelectedItem).LDAPPath;
            }
            catch (Exception ex)
            {
                lblCheckResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException( ex);
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
            DomainUrlInfo wDomainUrlInfo = (DomainUrlInfo)comboBox1.SelectedItem;//urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));
            if (wDomainUrlInfo == null) return;
            lblURL.Text = wDomainUrlInfo.LDAPPath;

        }

        private void frmDinamic_Load(object sender, EventArgs e)
        {

        }


    }

   
}
