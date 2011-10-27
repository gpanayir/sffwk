using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Security.Usercontrol
{
    public partial class News_Search_Control : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSeach_Click(object sender, ImageClickEventArgs e)
        {
           
            string url = string.Format(WebUserControlsConstants.NavigateUrl_News, this.txtSearch.Text);
            Response.Redirect(url);

        }
    }
}