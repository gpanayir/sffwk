using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.ConfigSection;
using System.Configuration;
using Fwk.Exceptions;
using System.IO;
using Fwk.Logging;

namespace Fwk.ServiceManagement
{
    /// <summary>
    /// Realiza operaciones CRUD y busquedas de la metadata de servicios
    /// </summary>
    public class ServiceMetadata
    {
        static ServiceProviderSection _ProviderSection;

        /// <summary>
        /// Seccion de metadata .-
        /// </summary>
        public static ServiceProviderSection ProviderSection
        {
            get
            {
                return _ProviderSection;
            }

        }

        static System.Collections.Generic.Dictionary<string, ServiceConfigurationCollection> _Repository;

        static ServiceMetadata()
        {
            try
            {
                _ProviderSection = ConfigurationManager.GetSection("FwkServiceMetadata") as ServiceProviderSection;

            }
            catch(Exception e)
            {
                throw e;
            }

            
            if (_Repository == null)
            {
                _Repository = new Dictionary<string, ServiceConfigurationCollection>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="pServiceName"></param>
        /// <returns></returns>
        public static ServiceConfiguration GetServiceConfiguration(string providerName, string pServiceName)
        {
            ServiceConfiguration svc = null;
            ServiceProviderElement provider = GetProvider(providerName);
            ServiceConfigurationCollection svcList = GetAllServices(provider);
            svc = svcList.GetServiceConfiguration(pServiceName,provider.ApplicationId);


            if (svc == null)
            {
                Exceptions.TechnicalException te = new Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");
                te.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);
                throw te;
            }

            return svc;

        }
        private static FileSystemWatcher watcher;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">Proveedor de la metadata</param>
        /// <returns></returns>
        public static ServiceConfigurationCollection GetAllServices(ServiceProviderElement provider)
        {
            ServiceConfigurationCollection svcList= null;

            //no esta cargado el provider
            if (!_Repository.ContainsKey(provider.Name))
            {
                
                if (provider.ConfigProviderType == ServiceProviderType.xml)
                {
                    svcList = XmlServiceConfigurationManager.GetAllServices(provider.SourceInfo);

                    //Habilito FileSystemWatcher para detectar cualquie cambio sobre la metadata
                    watcher = new System.IO.FileSystemWatcher();
                    watcher.Filter = provider.SourceInfo;
                    watcher.Path = Environment.CurrentDirectory;
                    watcher.EnableRaisingEvents = true;

                    watcher.Changed += new FileSystemEventHandler(watcher_Changed);

                }
                if (provider.ConfigProviderType == ServiceProviderType.sqldatabase)
                {
                    svcList = DatabaseServiceConfigurationManager.GetAllServices(provider.ApplicationId,provider.SourceInfo);
                }

                _Repository.Add(provider.Name, svcList);
            }
            else
                svcList = _Repository[provider.Name];

            return svcList;
        }    

        /// <summary>
        /// Si algun cambio ocurre en el archivo de metadata de algun proveedor xml
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            try
            {
                //Busco todos los providers que esten asociados al mismo archivo. Esta es una situacion qmuy rara pero podria darce
                foreach (ServiceProviderElement provider in _ProviderSection.Providers)
                {
                    if (e.Name.Equals(provider.SourceInfo) && provider.ConfigProviderType == ServiceProviderType.xml)
                        ReloadAllServices(provider);
                }
            }
            catch (TechnicalException ex)
            {
                Fwk.Logging.Event ev = new Event();
                ev.LogType = EventType.Error;
                ev.Machine = ex.Machine;
                ev.User = ex.UserName;
                String str = string.Concat(
                    "Se intento modificar la metadata de servicios y se arrojo el siguiente error ",
                    Environment.NewLine,
                    Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex),
                    Environment.NewLine,
                    " la metadata se encuentra en: ",
                    Environment.NewLine, e.FullPath);

                ev.Message.Text = str;

                Fwk.Logging.StaticLogger.Log(Fwk.Logging.Targets.TargetType.WindowsEvent, ev, null, null);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        static void ReloadAllServices(ServiceProviderElement provider)
        {

            _Repository.Remove(provider.Name);

            if (provider.ConfigProviderType == ServiceProviderType.xml)
            {
                ServiceConfigurationCollection svcList = XmlServiceConfigurationManager.GetAllServices(provider.SourceInfo);

                //Habilito FileSystemWatcher para detectar cualquie cambio sobre la metadata
                watcher = new System.IO.FileSystemWatcher();
                watcher.Filter = provider.SourceInfo;
                watcher.Path = Environment.CurrentDirectory;
                watcher.EnableRaisingEvents = true;

                watcher.Changed += new FileSystemEventHandler(watcher_Changed);

            }


        }    

        public static ServiceConfigurationCollection GetAllServices(string providerName)
        {
            ServiceProviderElement provider = GetProvider(providerName);
            return GetAllServices(provider);

        }

        public static void SetServiceConfiguration(string providerName, string pServiceName, ServiceConfiguration pServiceConfiguration)
        {

            ServiceProviderElement provider = GetProvider(providerName);
            ServiceConfigurationCollection svcList = GetAllServices(provider);
            if (!svcList.Exists(pServiceName, provider.ApplicationId))
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");
                te.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);

                throw te;
            }

            ServiceConfiguration wServiceConfigurationEnMemoria = svcList.GetServiceConfiguration(pServiceName,provider.ApplicationId);
            svcList.Remove(wServiceConfigurationEnMemoria);
            svcList.Add(pServiceConfiguration);

            if (provider.ConfigProviderType == ServiceProviderType.xml)
                XmlServiceConfigurationManager.SetServiceConfiguration(provider.SourceInfo, svcList);
        }


        public static void AddServiceConfiguration(string providerName, ServiceConfiguration pServiceConfiguration)
        {
            ServiceProviderElement provider = GetProvider(providerName);

            ServiceConfigurationCollection svcList = GetAllServices(provider);

            if (svcList.Exists(pServiceConfiguration.Name, provider.ApplicationId))
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceConfiguration.Name + " ya existe.");
                te.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);
                throw te;
            }

            

            svcList.Add(pServiceConfiguration);

            if (provider.ConfigProviderType == ServiceProviderType.xml)
                XmlServiceConfigurationManager.AddServiceConfiguration(pServiceConfiguration, provider.SourceInfo, svcList);
        }

        public static void DeleteServiceConfiguration(string providerName, string pServiceName)
        {

            ServiceProviderElement provider = GetProvider(providerName);
            ServiceConfigurationCollection svcList = GetAllServices(provider);
            if (!svcList.Exists(pServiceName, provider.ApplicationId))
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");
                te.ErrorId = "7002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);

                throw te;
            }
            ServiceConfiguration wServiceConfigurationEnMemoria = svcList.GetServiceConfiguration(pServiceName,provider.ApplicationId);
            svcList.Remove(wServiceConfigurationEnMemoria);

            if (provider.ConfigProviderType == ServiceProviderType.xml)
                XmlServiceConfigurationManager.DeleteServiceConfiguration(provider.SourceInfo, svcList);

        }

        static ServiceProviderElement GetProvider(string providerName)
        {
            ServiceProviderElement provider = _ProviderSection.GetProvider(providerName);

            if (string.IsNullOrEmpty(provider.SourceInfo))
            {
                System.Text.StringBuilder wMessage = new StringBuilder();
                wMessage.Append("Error al inicializar la metadata de los servicios  \r\n");
                wMessage.Append("El atributo SourceInfo no puede estar vasio.  \r\n");
                wMessage.AppendLine("Verifique el archivo de configuración en la sección FwkServiceMetadata el ");
                wMessage.AppendLine("atributo [type] y [SourceInfo]  posibles :");
                wMessage.AppendLine("Si tipo es XML espesifique nombre de archivo  ");
                wMessage.AppendLine("Si tipo es sqldatabase  espesifique nombre de connetionstring \r\n");


                TechnicalException te = new TechnicalException(wMessage.ToString());
                te.ErrorId = "7004";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<ServiceMetadata>(te);

                throw te;

            }

            return provider;
        }
    }
}
