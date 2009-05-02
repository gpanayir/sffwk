using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Fwk.ServiceManagement;
using Fwk.Bases;

public partial class processes : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			btnDelete.Attributes.Add("onclick", "return confirm('Confirma la eliminacion de la configuracion del Servicio');");

			if (Request["reload"] != null && Convert.ToBoolean(Request["reload"].ToString()))
			{
				GetAllProcesses();
			}
			else
			{
				PerformBinding();
			}

		}
	}

	protected void btnConnect_Click(object sender, EventArgs e)
	{
		GetAllProcesses();
	}

	#region < Private methods >
	/// <summary>
	/// Elimina configuración de servicio de negocio.
	/// </summary>
	/// <date>2006-02-13T00:00:00</date>
	/// <author>moviedo</author>
	private void DeleteProcess()
	{
        IServiceConfigurationManager wServiceConfigurationManager = ObjectProvider.GetServiceConfigurationManager();
        wServiceConfigurationManager.DeleteServiceConfiguration(grdProcesses.SelectedDataKey.Value.ToString());
		GetAllProcesses();
	}

	/// <summary>
	/// Busca todas las configuraciones de servicios de negocio.
	/// </summary>
	/// <date>2006-02-13T00:00:00</date>
	/// <author>moviedo</author>
	private void GetAllProcesses()
	{
		// Instanciacion del ServiceConfigurationManager.
		IServiceConfigurationManager wServiceConfigurationManager = ObjectProvider.GetServiceConfigurationManager();
		Application["DataSource"] = wServiceConfigurationManager.GetAllServices();
        
        
		PerformBinding();
	}

	private void PerformBinding()
	{
		grdProcesses.DataSource = Application["DataSource"];
		this.DataBind();
	}


	#endregion

	protected void grdProcesses_SelectedIndexChanged(object sender, EventArgs e)
	{
	}

	protected void btnAdd_Click(object sender, EventArgs e)
	{
		Server.Transfer("~/edit.aspx?formaction=new");
	}

	protected void btnDelete_Click(object sender, EventArgs e)
	{
		this.DeleteProcess();
	}
	protected void btnEdit_Click(object sender, EventArgs e)
	{
		Server.Transfer("~/edit.aspx?formaction=edit&bpname=" + grdProcesses.SelectedDataKey.Value.ToString());
	}

	protected void grdProcesses_PageIndexChanging(object sender, GridViewPageEventArgs e)
	{
		grdProcesses.PageIndex = e.NewPageIndex;
		PerformBinding();

	}
}
