using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Security.Modules.Admin;

namespace Security.Usercontrol
{
    public partial class News_ItemList_Link : System.Web.UI.UserControl
    {
        string NewsId = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        //internal void Populate(NewsInfo pNew)
        //{

        //    NewsId = pNew.Id.ToString();
        //    this.lblTitle.Text = pNew.Title;
        //    this.lblTitle.NavigateUrl = string.Format(WebUserControlsConstants.NavigateUrl_Admin_NewsUpdate, pNew.Id.ToString());
        //    this.btnEdit.PostBackUrl = string.Format(WebUserControlsConstants.NavigateUrl_Admin_NewsUpdate, pNew.Id.ToString());
        //    //HiddenField1.Value = pNew.Id.ToString();
        //}

        protected void btnRemove_Click(object sender, ImageClickEventArgs e)
        {
      

        }

     

        protected void btnEdit_Click(object sender, ImageClickEventArgs e)
        {

        }

    }
}