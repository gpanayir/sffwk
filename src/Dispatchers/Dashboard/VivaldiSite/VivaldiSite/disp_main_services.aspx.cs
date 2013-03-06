using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Fwk.ConfigSection;
using VivaldiSite.DAC;
using Fwk.ConfigData;
using Fwk.Bases;

namespace VivaldiSite
{
    public partial class disp_main_services : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {  
            
            if (Request.QueryString["disp_inst"] == null)
            {
                //Response.Redirect(WebUserControlsConstants.NavigateUrl_Home);
            }
            string disp_inst = Request.QueryString["disp_inst"].ToString();

            if (DataCoreDAC.Dispatcher_Exist(disp_inst, null))
            {
              
                fwk_ServiceDispatcher disp = DataCoreDAC.Dispatcher_Get(disp_inst);
                txtUrl.Text = disp.Url_URI;
                GetAllServices(disp.Url_URI);
            }

        }



        ServiceConfigurationCollection GetAllServices(string url_URI)
        {
            Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
            wrapper.SourceInfo = url_URI;

            ServiceConfigurationCollection services = null;
            #region retrive info from server
            try
            {
                services = wrapper.GetAllServices();
                UpdatePanel1.Visible = false;
            }
            catch (Exception ex)
            {
                msgError.Text = ex.Message;

                UpdatePanel1.Visible = true;
                return null;
            }
            #endregion

            if (services == null)
            {
                msgError.Text = "No fue posible establecer conexión con el dispatcher intentelo mas tarde o pongace en contacto con el administrador del mismo";
                UpdatePanel1.Visible = true;

                return null;
            }
            return services;
        }
    }
}