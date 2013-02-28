using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VivaldiSite.DAC;
using Fwk.ConfigData;
using Fwk.ConfigSection;

namespace VivaldiSite
{
    public partial class disp_main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
          
            //if (Request.QueryString["disp_inst"] == null)
            //{
            //    //Response.Redirect(WebUserControlsConstants.NavigateUrl_Home);
            //}
            //string disp_inst = Request.QueryString["disp_inst"].ToString();
            string disp_inst = "Healt_Disp_Test";
            DoWork(disp_inst);
            
        }

        public void DoWork(string disp_inst)
        {
            

            if (DataCoreDAC.Dispatcher_Exist(disp_inst, null))
            {
                int index = 0;
                fwk_ServiceDispatcher disp = DataCoreDAC.Dispatcher_Get(disp_inst);

                Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
                wrapper.SourceInfo = disp.Url_URI;
                DispatcherInfo wDispatcherInfo = wrapper.RetriveDispatcherInfo();

                txtInstanceName.Text = disp.InstanseName;
                txtIp.Text = disp.HostIp;
                txtPort.Text = disp.Port.ToString();
                txtServerName.Text = disp.HostName;
                txtUrl.Text = disp.Url_URI;
                txtCompany.Text = disp.CompanyName;

                ListItem item = cmbAuditMode.Items.FindByValue(disp.AuditMode.ToString());
                if (item != null)
                {
                    index = cmbAuditMode.Items.IndexOf(item);
                    cmbAuditMode.SelectedIndex = index;
                }
                else
                {
                    cmbAuditMode.SelectedIndex = 0;
                }

                if (disp.Port == null)
                {
                    cmbWrapperType.SelectedIndex = 0; // web service
                }
                else
                {
                    cmbAuditMode.SelectedIndex = 1; // remoting
                }



            


            }
        }
    }
}