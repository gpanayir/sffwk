using System;
using System.Xml;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Fwk.Bases;
using Fwk.HelperFunctions;
using System.Configuration;


namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
	public partial class frmServices : Fwk.Bases.FrontEnd.FrmBase
	{
     
		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		public frmServices()
		{
			InitializeComponent();
            cnfg();
            ctrlService1.ShowAction = Action.Query;
		}


		#region < Actions methods >

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                
                ucbServiceGrid1.Services = base.GetAllServices();
                lblConnectionStatus.Text= "Connected";
            }
            catch(Exception ex)
            {
               
                base.ExceptionViewer.Show(ex);
                lblConnectionStatus.Text = "Disconnected";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddService();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditService();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteService();
        }



		/// <summary>
		/// Crea una nueva configuración de servicio de negocio.
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
        private void AddService()
        {
            if (ucbServiceGrid1.Services == null)
            {
                base.MessageViewer.Show("Debe conectarce al despachaor de servicio antes de ejecutar esta operación");
                return;
            }

            ServiceConfiguration wServiceNew = new ServiceConfiguration();
            if (frmEdit.ShowNew(ref wServiceNew) == DialogResult.OK)
            {
                wServiceNew.CreatedUserName = Environment.UserName;
                wServiceNew.CreatedDateTime = System.DateTime.Now;
                ucbServiceGrid1.Add(wServiceNew);
                
                base.AddServiceConfiguration(wServiceNew);
            }
        }

		/// <summary>
		/// Edita una configuración de servicio de negocio.
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		private void EditService()
		{
            if (ucbServiceGrid1.Services == null)
            {
                base.MessageViewer.Show("Debe conectarce al despachaor de servicio antes de ejecutar esta operación");
                return;
            }
            if (ucbServiceGrid1.CurentServiceConfiguration == null)
            {
                base.MessageViewer.Show("Seleccione un servicio para configurar");
                return;
            }
            ServiceConfiguration wServiceClon = ucbServiceGrid1.CurentServiceConfiguration;
            if (frmEdit.ShowEdit(wServiceClon) == DialogResult.OK)
            {
                base.SetServiceConfiguration(ucbServiceGrid1.CurentServiceConfiguration.Name, wServiceClon);
                ucbServiceGrid1.Update(wServiceClon);
               
            }
            ucbServiceGrid1_OnClickServiceHandler(ucbServiceGrid1.CurentServiceConfiguration);   
		}

		/// <summary>
		/// Elimina configuración de servicio de negocio.
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		private void DeleteService()
		{
            if (ucbServiceGrid1.Services == null)
            {
                base.MessageViewer.Show("Debe conectarce al despachaor de servicio antes de ejecutar esta operación");
                return;
            }
            if (ucbServiceGrid1.CurentServiceConfiguration == null)
            {
                base.MessageViewer.Show("Seleccione un servicio para configurar");
                return;
            }
            base.MessageViewer.MessageBoxIcon = Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Question;
            base.MessageViewer.MessageBoxButtons = MessageBoxButtons.OKCancel;
            DialogResult wDialogResult = base.MessageViewer.Show("Confirma la eliminación de la configuración del servicio " + ucbServiceGrid1.CurentServiceConfiguration.Name);
            base.SetMessageViewInfoDefault();
            if (wDialogResult == DialogResult.OK)
            {
               
                ucbServiceGrid1.RemoveCurrent();
                base.DeleteServiceConfiguration(ucbServiceGrid1.CurentServiceConfiguration.Name);
            }


		}

		#endregion

        private void ucbServiceGrid1_OnClickServiceHandler(ServiceConfiguration pServiceConfiguration)
        {
           
            ctrlService1.EntityParam = pServiceConfiguration;
            ctrlService1.Populate();

        }




        void cnfg()
        {
            lblConnectionStatus.Text = "Diconect";
            System.Configuration.Configuration wConfiguration = null;
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();

            configFile.ExeConfigFilename = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
            wConfiguration = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);
            ConfigurationSectionGroup wConfigurationSectionGroup = wConfiguration.GetSectionGroup("applicationSettings");
            ConfigurationSection wSection = wConfigurationSectionGroup.Sections.Get("Fwk.Bases.Properties.Settings");

            ClientSettingsSection wClientSettingsSection = (System.Configuration.ClientSettingsSection)wSection;

            //Recorre las bases
            foreach (SettingElement wSetting in wClientSettingsSection.Settings)
            {
                if (String.Compare(wSetting.Name.Trim(),"wrapper",true) ==0)
                {
                    if (wSetting.Value.ValueXml.InnerXml.Trim().ToLower().Contains("local"))
                        lblConnectionType.Text = "Local";

                    if (wSetting.Value.ValueXml.InnerXml.Trim().ToLower().Contains("webservice"))
                        lblConnectionType.Text = "Web Service";


                    if (wSetting.Value.ValueXml.InnerXml.Trim().ToLower().Contains("remoting"))
                        lblConnectionType.Text = "Remoting win service";

                }
                



            }
            //Recorre ServiceManagement
            wSection = wConfigurationSectionGroup.Sections.Get("Fwk.Bases.Properties.Settings");
            wClientSettingsSection = (System.Configuration.ClientSettingsSection)wSection;


            foreach (SettingElement wSetting in wClientSettingsSection.Settings)
            {
                if (String.Compare(wSetting.Name.Trim(), "ServiceConfigurationManagerType", true) == 0)
                {
                        lblMetadata.Text = wSetting.Value.ValueXml.InnerXml.Split(',')[0];
                }


                if (string.Compare(lblConnectionType.Text, "Web Service", true) == 0)
                {
                    if (String.Compare(wSetting.Name.Trim(), "WebServiceDispatcherUrl", true) == 0)
                    {
                        txtAddres.Text = wSetting.Value.ValueXml.InnerXml;
                    }
                }

                if (string.Compare(lblConnectionType.Text, "Local", true) ==0)
                {
                    if (String.Compare(wSetting.Name.Trim(), "ServiceConfigurationSourceName", true) == 0)
                    {
                        txtAddres.Text = wSetting.Value.ValueXml.InnerXml;
                    }
                }
                
            }


        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            frmAssemblyExplorer f = new frmAssemblyExplorer();
            f.ShowDialog();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            
          
             if (string.Compare(lblConnectionType.Text, "Web Service", true) == 0)
                 System.Diagnostics.Process.Start("www.yahoo.com.ar");
            else
                 System.Diagnostics.Process.Start("explorer.exe", txtAddres.Text);

        }

       
       

      

       
	}
}