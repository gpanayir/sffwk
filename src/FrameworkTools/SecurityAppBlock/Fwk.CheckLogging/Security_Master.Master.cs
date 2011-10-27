using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace Security
{
    public partial class Security_Master : System.Web.UI.MasterPage
    {
  

        protected void Page_Load(object sender, EventArgs e)
        {
             SessionMannager.Session(Session);
        }
        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            FormsAuthentication.SignOut();

            SessionMannager.Session(Session).Clear();
            
        }
    }
}
