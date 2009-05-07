using System;
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
using Fwk.Bases.Connector.SingleService;

public partial class edit : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			ViewState.Add("formaction", Request["formaction"]);
			ViewState.Add("bpname", Request["bpname"]);

			foreach (string wName in Enum.GetNames(typeof(TransactionalBehaviour)))
			{
				cboTransactionalBehaviour.Items.Add(wName);
			}

			foreach (string wName in Enum.GetNames(typeof(IsolationLevel)))
			{
				cboIsolationLevel.Items.Add(wName);
			}

			cboTransactionalBehaviour.SelectedIndex = 0;
			cboIsolationLevel.SelectedIndex = 0;


			if (ViewState["formaction"].ToString() == "edit")
			{
				Fwk.Bases.ServiceConfiguration wServiceConfiguration = ((ServiceConfigurationCollection)Application["DataSource"])[ViewState["bpname"].ToString()];
                string wTransactionalBehaviourName = Enum.GetName(typeof(TransactionalBehaviour), wServiceConfiguration.TransactionalBehaviour);
				string wIsolationLevelName = Enum.GetName(typeof(IsolationLevel), wServiceConfiguration.IsolationLevel);


				txtName.ReadOnly = true;

				txtName.Text = wServiceConfiguration.Name;
				txtDescription.Text = wServiceConfiguration.Description;

				txtHandler.Text = wServiceConfiguration.Handler;
				txtRequest.Text = wServiceConfiguration.Request;
				txtResponse.Text = wServiceConfiguration.Response;

				cboTransactionalBehaviour.SelectedIndex = cboTransactionalBehaviour.Items.IndexOf(cboTransactionalBehaviour.Items.FindByText(wTransactionalBehaviourName));
				cboIsolationLevel.SelectedIndex = cboIsolationLevel.Items.IndexOf(cboIsolationLevel.Items.FindByText(wIsolationLevelName));

				ckAudit.Checked = wServiceConfiguration.Audit;
				ckAvailable.Checked = wServiceConfiguration.Available;
                chkCacheable.Checked = wServiceConfiguration.Cacheable;
				txtTimeout.Text = wServiceConfiguration.Timeout.ToString();
			}
		}
		
	}

	protected void btnOk_Click(object sender, EventArgs e)
	{
		Save();
	}
	protected void btnCancel_Click(object sender, EventArgs e)
	{
		Cancel();
	}

	#region < Private methods >

	private ServiceConfiguration SetDataInProcess()
	{
		ServiceConfiguration wResult = new ServiceConfiguration();

		wResult.Name = txtName.Text;
		wResult.Description = txtDescription.Text;
		wResult.Handler = txtHandler.Text;
		wResult.Request = txtRequest.Text;
		wResult.Response = txtResponse.Text;
		wResult.TransactionalBehaviour = (TransactionalBehaviour)Enum.Parse(typeof(TransactionalBehaviour), cboTransactionalBehaviour.Text);
		wResult.IsolationLevel = (IsolationLevel)Enum.Parse(typeof(IsolationLevel), cboIsolationLevel.Text);
		wResult.Audit = ckAudit.Checked;
		wResult.Available = ckAvailable.Checked;
		wResult.Timeout = Convert.ToInt32(txtTimeout.Text);
        wResult.Cacheable= chkCacheable.Checked;

		return wResult;

	}


	private void Save()
	{
		// Instanciacion del ServiceConfigurationManager.
		IServiceConfigurationManager wServiceConfigurationManager = ObjectProvider.GetServiceConfigurationManager();

		if (ViewState["formaction"].ToString() == "new")
			wServiceConfigurationManager.AddServiceConfiguration(SetDataInProcess());
		else
			wServiceConfigurationManager.SetServiceConfiguration(SetDataInProcess());

		Server.Transfer("~/processes.aspx?reload=true");
	}

	private void Cancel()
	{
		Server.Transfer("~/processes.aspx?reload=false");
	}

	#endregion
}
