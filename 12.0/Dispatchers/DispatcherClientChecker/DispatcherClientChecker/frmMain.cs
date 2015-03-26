﻿using Fwk.Bases;
using Fwk.ConfigSection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DispatcherClientChecker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        void Init()
        {

            List<wrap_provider> providers = new List<wrap_provider>();
            foreach (WrapperProviderElement p in Fwk.Bases.WrapperFactory.ProviderSection.Providers)
            {
                providers.Add(new wrap_provider(p));
            }
            wrapproviderBindingSource.DataSource = providers;
            comboProviders.Refresh();

            setWrapper();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void comboProviders_SelectedIndexChanged(object sender, EventArgs e)
        {
            setWrapper();
        }
        IServiceWrapper selectedWrapper = null;
        void setWrapper()
        {
            wrap_provider w = comboProviders.SelectedItem as wrap_provider;
            selectedWrapper = Fwk.Bases.WrapperFactory.GetWrapper(w.Name);
            StringBuilder str = new StringBuilder("Wrapper name: " + w.Name);
            str.AppendLine();
            str.AppendLine("SourceInfo: " + w.SourceInfo);
            str.AppendLine("WrapperProviderType: " + w.WrapperProviderType);
            str.AppendLine("ApplicationId: " + w.ApplicationId);
            textBox1.Text = str.ToString();

        }

        private void btnGetAllServices_Click(object sender, EventArgs e)
        {
            try
            {
                ServiceConfigurationCollection res = selectedWrapper.GetAllServices();

                if (rndJSON.Checked)
                    txtResult.Text = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson<ServiceConfigurationCollection>(res);
                else
                    txtResult.Text = res.GetXml();
            }
            catch (Exception ex)
            {
                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

        }

        private void btnGetAllApplicationsId_Click(object sender, EventArgs e)
        {
            try
            {
                var list = selectedWrapper.GetAllApplicationsId();
                if (rndJSON.Checked)
                    txtResult.Text = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson(typeof(List<String>), list);
                else
                    txtResult.Text = Fwk.HelperFunctions.SerializationFunctions.SerializeToXml(list);
            }
            catch (Exception ex)
            {
                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }
        }

        private void btnRetriveDispatcherInfo_Click(object sender, EventArgs e)
        {
            try
            {
                var res = selectedWrapper.RetriveDispatcherInfo();
                if (rndJSON.Checked)
                    txtResult.Text = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson<DispatcherInfo>(res);
                else
                    txtResult.Text = res.GetXml();
            }
            catch (Exception ex)
            {
                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }

        }

        private void btnGetProviderInfo_Click(object sender, EventArgs e)
        {
            try
            {
                var res = selectedWrapper.GetProviderInfo("");
                if (rndJSON.Checked)
                    txtResult.Text = Fwk.HelperFunctions.SerializationFunctions.SerializeObjectToJson<MetadataProvider>(res);
                else
                    txtResult.Text = res.GetXml();
            }
            catch (Exception ex)
            {
                txtResult.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);
            }


        }
    }


    public class wrap_provider
    {
        private WrapperProviderElement p;

        public wrap_provider(WrapperProviderElement p)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.ApplicationId = p.AppId;
            this.Name = p.Name;
            this.WrapperProviderType = p.WrapperProviderType;
            this.SourceInfo = p.SourceInfo;

        }
        // Summary:
        //     Identificador de aplicacion para buscarlo en la base de datos

        public string ApplicationId { get; set; }
        //
        // Summary:
        //     Nombre de la regla. Es el identificador de una regla por lo tanto este nombre
        //     no debe repetirse.
        public string Name { get; set; }

        //
        // Summary:
        //     Proveedor de seguridad de usuarios reglas y roles, con la que ocorreran los
        //     servicios
        public string SecurityProviderName { get; set; }
        //
        // Summary:
        //     Archivo contenedor de la configuracion
        public string SourceInfo { get; set; }




        public string WrapperProviderType { get; set; }
    }
}
