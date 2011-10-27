using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fwk.CheckLogging.fwksec;

namespace Fwk.CheckLogging.Modules.Admin
{
    public partial class Domain_User_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        void LoadUser()
        {

            fwksec.ActiveDirectory proxy = new Fwk.CheckLogging.fwksec.ActiveDirectory();

            if (proxy.User_Exist(txtUserName.Text, ""))
                throw new Exception("no existe");


            ActiveDirectoryGroup[] groups =  proxy.Retrive_User_Groups(txtUserName.Text,"");


        }
    }
}
