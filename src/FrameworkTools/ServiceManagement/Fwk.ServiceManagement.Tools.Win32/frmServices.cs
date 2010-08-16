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
using Fwk.ConfigSection;
using Fwk.Exceptions;


namespace Fwk.ServiceManagement.Tools.Win32
{
    /// <summary>
    /// 
    /// </summary>
	public partial class frmServices : Fwk.Bases.FrontEnd.FrmBase
	{   
        string _AuxServiceName;
        public static WrapperProviderElement CurrentProvider;
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

                ucbServiceGrid1.Services = base.GetAllServices(frmServices.CurrentProvider.Name);
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
                try
                {
                    ucbServiceGrid1.Add(wServiceNew);


                    base.AddServiceConfiguration(CurrentProvider.Name,wServiceNew);
                }
                catch(Exception ex)
                {
                    base.MessageViewer.Show(ex.Message);
                }
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
             _AuxServiceName  = ucbServiceGrid1.CurentServiceConfiguration.Name;
            if (frmEdit.ShowEdit(ucbServiceGrid1.CurentServiceConfiguration) == DialogResult.OK)
            {
                base.SetServiceConfiguration(CurrentProvider.Name,_AuxServiceName, ucbServiceGrid1.CurentServiceConfiguration);
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
                base.DeleteServiceConfiguration(CurrentProvider.Name, ucbServiceGrid1.CurentServiceConfiguration.Name);
            }


		}

		#endregion

        private void ucbServiceGrid1_OnClickServiceHandler(ServiceConfiguration pServiceConfiguration)
        {
           
            ctrlService1.EntityParam = pServiceConfiguration;
            ctrlService1.Populate();

        }


        static WrapperProviderSection _ProviderSection;

        void cnfg()
        {
            try
            {
                _ProviderSection = ConfigurationManager.GetSection("FwkWrapper") as WrapperProviderSection;
                if (_ProviderSection == null)
                {
                    TechnicalException te = new TechnicalException(string.Concat("No se puede cargar la configuracion del wrapper en el cliente, verifique si existe la seccion [FwkWrapper] en el archivo de configuracion."));
                    te.ErrorId = "6000";
                    Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(frmServices));
                    throw te;
                }

            }
            catch (System.Configuration.ConfigurationErrorsException)
            {

                TechnicalException te = new TechnicalException(string.Concat("No se puede cargar la configuracion del wrapper en el cliente, verifique si existe la seccion [FwkWrapper] en el archivo de configuracion."));
                te.ErrorId = "6000";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(frmServices));
                throw te;
            }



            lblConnectionStatus.Text = "Diconect";
           



            lblConnectionType.Text = _ProviderSection.DefaultProvider.WrapperProviderType.ToString();
            txtAddres.Text = _ProviderSection.DefaultProvider.SourceInfo;



            ComboBox cb = (ComboBox)cmbProviders.Control;

            foreach (WrapperProviderElement p in _ProviderSection.Providers)
            {
                cb.Items.Add(p.Name);
            }

            cmbProviders.SelectedIndex = 0;
            CurrentProvider =_ProviderSection.GetProvider(cmbProviders.SelectedItem.ToString());
            cb.SelectedValueChanged += new EventHandler(cb_SelectedValueChanged);
        }

        void cb_SelectedValueChanged(object sender, EventArgs e)
        {

            CurrentProvider = _ProviderSection.GetProvider(cmbProviders.SelectedItem.ToString());
            lblMetadata.Text = CurrentProvider.WrapperProviderType.ToString();
            txtAddres.Text = CurrentProvider.SourceInfo;


            try
            {
                
                
                ucbServiceGrid1.Services = base.GetAllServices(CurrentProvider.Name);
                lblConnectionStatus.Text = "Connected";
            }
            catch (Exception ex)
            {

                base.ExceptionViewer.Show(ex);
                lblConnectionStatus.Text = "Disconnected";
                ucbServiceGrid1.Services = null;
                
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

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmNewProvider frmbox = new frmNewProvider (CurrentProvider);
            frmbox.ShowDialog();
        }

       
       

      

       
	}
}