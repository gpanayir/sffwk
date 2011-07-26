using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fwk.Security.ActiveDirectory;
using Fwk.Exceptions;

namespace Fwk.CheckLogging
{
    public partial class _Default : System.Web.UI.Page
    {
        LDAPHelper _ADHelper;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            lblError.Text = "NO Error";
            try
            {
                if (SetAD(false))
                {
                    TechnicalException logError = null;
                    //lblCheckResult.Text = _ADHelper.User_CheckLogin(txtLoginName.Text, txtPassword.Text).ToString();
                    lblResult.Text = _ADHelper.User_Logon(txtUsr.Text, txtpassword.Text, out logError).ToString();

                    if (logError != null)
                        lblError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(logError);
                    else
                        lblError.Text = "NO Error";

                    //_ADHelper.User_CheckLogin2(txtLoginName.Text, txtPassword.Text);

                }
            }
            catch (Exception ex)
            {
                lblError.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);


            }
        }



        bool SetAD(Boolean pSecure)
        {
            //lblURL.Text = string.Empty;

            //DomainUrlInfo wDomainUrlInfo = (DomainUrlInfo)cmbDomains.SelectedItem;//urls.Find(p => p.DomainName.Equals(txtDomain.Text,StringComparison.CurrentCultureIgnoreCase));

            //if (wDomainUrlInfo == null)
            //{
            //    lblCheckResult.Text = "Nombre de dominio incorrecto";
            //    return false;
            //}
            //_ADHelper = new ADHelper(wDomainUrlInfo.LDAPPath, wDomainUrlInfo.Usr, wDomainUrlInfo.Pwd);
            //_ADHelper = new LDAPHelper(wDomainUrlInfo.DomainName, "testActiveDirectory", pSecure);
            _ADHelper = new LDAPHelper(txtDomain.Text, "testActiveDirectory", pSecure, false);

            return true;
        }
    }
}
