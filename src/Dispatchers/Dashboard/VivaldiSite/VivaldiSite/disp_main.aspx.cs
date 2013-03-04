﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VivaldiSite.DAC;
using Fwk.ConfigData;
using Fwk.ConfigSection;
using System.Web.UI.HtmlControls;

namespace VivaldiSite
{
    public partial class disp_main : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsCallback)
                return;
            //if (Request.QueryString["disp_inst"] == null)
            //{
            //    //Response.Redirect(WebUserControlsConstants.NavigateUrl_Home);
            //}
            //string disp_inst = Request.QueryString["disp_inst"].ToString();

            if (!this.IsPostBack)
            {

                string disp_inst = "Healt_Disp_Test";
                DoWork(disp_inst);
            }            
        }

        public void DoWork(string disp_inst)
        {
            

            if (DataCoreDAC.Dispatcher_Exist(disp_inst, null))
            {
                int index = 0;
                fwk_ServiceDispatcher disp = DataCoreDAC.Dispatcher_Get(disp_inst);

                Fwk.Bases.Connector.WebServiceWrapper wrapper = new Fwk.Bases.Connector.WebServiceWrapper();
                wrapper.SourceInfo = disp.Url_URI;
                

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

                DispatcherInfo wDispatcherInfo =null;
                #region retrive info from server 
                try
                {
                     wDispatcherInfo = wrapper.RetriveDispatcherInfo();
                     UpdatePanel1.Visible = false;
                }
                catch (Exception ex)
                {
                    msgError.Text = ex.Message;
                    
                    UpdatePanel1.Visible = true;
                    return;
                }
                if (wDispatcherInfo == null)
                {
                    msgError.Text = "No fue posible establecer conexión con el dispatcher intentelo mas tarde o pongace en contacto con el administrador del mismo";
                    UpdatePanel1.Visible = true;
                    
                    return;
                }
                grid_ServerSettings.DataSource = wDispatcherInfo.AppSettings;
                grid_ServerSettings.DataBind();

                grid_CnnStrings.DataSource = wDispatcherInfo.CnnStringSettings;
                grid_CnnStrings.DataBind();
                #endregion
            }
        }

        protected void grid_ServerSettings_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            DoWork("Healt_Disp_Test");
        }
    }
}