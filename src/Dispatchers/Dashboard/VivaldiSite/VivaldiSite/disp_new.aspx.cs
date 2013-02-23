using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VivaldiSite
{
    public partial class disp_new : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsCallback)
                return;
            if (!this.IsPostBack)
            {


                //cmbWrapperType.DataSource = ParametroDAC.GetByParams((int)Health.BE.Enums.TipoParametroEnum.Paices, null, true, string.Empty);
                //cmbWrapperType.DataBind();



                //cmbWrapperType.Attributes.Add("onchange", "javascript:return country_changed('" + cmbWrapperType.ClientID + "');");

                //cmbWrapperType.SelectedValue = "11000";




                //string stringbtnAcept = Page.ClientScript.GetCallbackEventReference(this, "'" + btnAcept.ClientID + "'", "ReceiveServerData_btnAcept", "null");
                //btnAcept.Attributes["onclick"] = stringbtnAcept;
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}