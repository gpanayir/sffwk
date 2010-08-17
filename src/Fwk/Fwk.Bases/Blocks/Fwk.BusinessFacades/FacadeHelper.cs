using System;
using System.IO;
using System.Text;
using System.Data;
using Fwk.Configuration;
using Fwk.Logging;
using Fwk.Exceptions;
using Fwk.Transaction;
using Fwk.Bases;
using Fwk.HelperFunctions;
using Fwk.ServiceManagement;
using System.Collections.Generic;

namespace Fwk.BusinessFacades.Utils
{
    /// <summary>
    /// enumeración que define el modo en que se auditará la  ejecución del servicio.
    /// </summary>
    /// <date>2008-04-07T00:00:00</date>
    /// <author>moviedo</author>
    public enum AuditMode
    {
        /// <summary>
        /// Se auditará la  ejecución del servicio, sin importar la configuración del mismo.
        /// </summary>
        Required,
        /// <summary>
        /// Se auditará la  ejecución del servicio si éste está configurado para ser auditado.
        /// </summary>
        Optional,
        /// <summary>
        /// No se auditará la  ejecución del servicio, sin importar la configuración del mismo.
        /// </summary>
        None
    }

    /// <summary>
    /// Provee soporte a las clases que implementan IBusinessFacade.
    /// </summary>
    /// <remarks>
    /// Toda la funcionalidad que sea reutilizable por las distintas fachadas de negocio debe estar implementada por esta clase.
    /// </remarks>
    /// <date>2008-04-07T00:00:00</date>
    /// <author>moviedo</author>
    public sealed class FacadeHelper
    {


        static FacadeHelper()
        {
            //// instanciación del ServiceConfigurationManager.
            //try
            //{
            //    _ServiceConfigurationManager = ObjectProvider.GetServiceConfigurationManager();
            //}
            //catch (TechnicalException ex)
            //{
            //    Fwk.Logging.Event ev = new Event();
            //    ev.LogType = EventType.Error;
            //    ev.Machine = ex.Machine;
            //    ev.User = ex.UserName;
                

            //    ev.Message.Text = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex);

            //    Fwk.Logging.StaticLogger.Log(Fwk.Logging.Targets.TargetType.WindowsEvent, ev, null, null);
            //    ev = null;
            //    throw ex;
            //}


            ////Habilito FileSystemWatcher para detectar cualquie cambio sobre la metadata
            //if (_ServiceConfigurationManager.GetType() == typeof(XmlServiceConfigurationManager))
            //{
            //    watcher = new System.IO.FileSystemWatcher();

            //    watcher.Filter = ObjectProvider._ServiceProviderSection.DefaultProvider.SourceInfo;
            //    watcher.Path = Environment.CurrentDirectory;
            //    watcher.EnableRaisingEvents = true;

            //    watcher.Changed += new FileSystemEventHandler(watcher_Changed);
            //}
        }

        ///// <summary>
        ///// Si algun cambio ocurre en el archivo de metadata
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //static void watcher_Changed(object sender, FileSystemEventArgs e)
        //{

        //    try
        //    {
        //        _ServiceConfigurationManager = ObjectProvider.GetServiceConfigurationManager();
        //    }
        //    catch (TechnicalException ex)
        //    {
        //        Fwk.Logging.Event ev = new Event();
        //        ev.LogType = EventType.Error;
        //        ev.Machine = ex.Machine;
        //        ev.User = ex.UserName;
        //        //ev.Source = "Service Dispatcher";
        //        String str = string.Concat(
        //            "Se intento modificar la metadata de servicios y se arrojo el siguiente error ",
        //            Environment.NewLine,
        //            Fwk.Exceptions.ExceptionHelper.GetAllMessageException(ex),
        //            Environment.NewLine,
        //            " la metadata se encuentra en: ",
        //            Environment.NewLine, e.FullPath);

        //        ev.Message.Text = str;

        //        Fwk.Logging.StaticLogger.Log(Fwk.Logging.Targets.TargetType.WindowsEvent, ev, null, null);

        //    }
        //}

        #region Run services
        /// <summary>
        /// Ejecuta un servicio de negocio dentro de un ámbito transaccional.
        /// </summary>
        /// <param name="pData">XML con datos de entrada.</param>
        /// <param name="serviceConfiguration">configuración del servicio.</param>
        /// <returns>XML con datos de salida del servicio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public static string RunTransactionalProcess(string pData, ServiceConfiguration serviceConfiguration)
        {
            string wResult;
            TransactionScopeHandler wTransactionScopeHandler = CreateTransactionScopeHandler(serviceConfiguration);
            ServiceError wServiceError = null;
            try
            {
                //  ejecución del servicio.
                wTransactionScopeHandler.InitScope();

                wResult = ServiceCalls.RunService(pData, serviceConfiguration, out wServiceError);

                if (wServiceError == null)
                    wTransactionScopeHandler.Complete();
                else
                    wTransactionScopeHandler.Abort();

             
            }
            catch (Exception ex)
            {
                wTransactionScopeHandler.Abort();

                #region < Log >
                if (serviceConfiguration.Audit == true)
                {
                   Audit.LogNonSucessfulExecution(ex, serviceConfiguration);
                }
                #endregion

                throw ex;
            }
            finally
            {
                wTransactionScopeHandler.Dispose();
                wTransactionScopeHandler = null;
            }
            return wResult;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio dentro de un ámbito transaccional.
        /// </summary>
        /// <param name="pRequest">XML con datos de entrada.</param>
        /// <param name="serviceConfiguration">configuración del servicio.</param>
        /// <returns>XML con datos de salida del servicio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public static IServiceContract RunTransactionalProcess(IServiceContract pRequest, ServiceConfiguration serviceConfiguration)
        {
            IServiceContract wResult;
            TransactionScopeHandler wTransactionScopeHandler = CreateTransactionScopeHandler(serviceConfiguration);
            ServiceError wServiceError = null;
            try
            {
                //  ejecución del servicio.
                wTransactionScopeHandler.InitScope();
                wResult = ServiceCalls.RunService(pRequest, serviceConfiguration, out wServiceError);

                if (wServiceError == null)
                    wTransactionScopeHandler.Complete();
                else
                    wTransactionScopeHandler.Abort();

       
            }
            catch (Exception ex)
            {
                wTransactionScopeHandler.Abort();

                #region < Log >
                if (serviceConfiguration.Audit == true)
                {
                    Audit.LogNonSucessfulExecution(ex, serviceConfiguration);
                }
                #endregion

                throw ex;
            }
            finally
            {
                wTransactionScopeHandler.Dispose();
                wTransactionScopeHandler = null;
            }
            return wResult;
        }


        /// <summary>
        /// Ejecuta un servicio de negocio dentro de un ámbito transaccional.
        /// </summary>
        /// <param name="pData">XML con datos de entrada.</param>
        /// <param name="serviceConfiguration">configuración del servicio.</param>
        /// <returns>XML con datos de salida del servicio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public static string RunNonTransactionalProcess(string pData, ServiceConfiguration serviceConfiguration)
        {
            string wResult;
            ServiceError wServiceError = null;
            try
            {
                wResult = ServiceCalls.RunService(pData, serviceConfiguration, out wServiceError);

            }
            catch (Exception ex)
            {
                
                throw ex;
            }

            return wResult;
        }

        /// <summary>
        /// Ejecuta un servicio de negocio dentro de un ámbito transaccional.
        /// </summary>
        /// <param name="pRequest">Request con datos de entrada.</param>
        /// <param name="serviceConfiguration">configuración del servicio.</param>
        /// <returns>XML con datos de salida del servicio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public static IServiceContract RunNonTransactionalProcess(IServiceContract pRequest, ServiceConfiguration serviceConfiguration)
        {
            IServiceContract wResult;
            ServiceError wServiceError = null;
            try
            {
                wResult = ServiceCalls.RunService(pRequest, serviceConfiguration, out wServiceError);
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return wResult;
        }

        #endregion

        
        /// <summary>
        /// Recupera la configuración del servicio de negocio.
        /// </summary>
        /// <remarks>Lee la configuración utilizando un ServiceConfigurationManager del tipo especificado en los settings de la aplicación.</remarks>
        /// <param name="providerName">Nombre del proveedor de la metadata de szervicio</param>
        /// <param name="serviceName">Nombre del servicio de negocio.</param>
        /// <returns>configuración del servicio de negocio.</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public static ServiceConfiguration GetServiceConfiguration(string providerName, string serviceName)
        {
            // obtención de la configuración del servicio.
            ServiceConfiguration wResult = ServiceMetadata.GetServiceConfiguration(providerName, serviceName);
            return wResult;
        }

  

        /// <summary>
        /// Obtiene todos los servicios configurados
        /// </summary>
        /// <returns>ServiceConfigurationCollection</returns>
        public static ServiceConfigurationCollection GetAllServices(string providerName)
        {
            return ServiceMetadata.GetAllServices(providerName);
        }

    
        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        /// <param name="serviceConfiguration"></param>
        public static void SetServiceConfiguration(string providerName, String serviceName, ServiceConfiguration serviceConfiguration)
        {
            ServiceMetadata.SetServiceConfiguration(providerName,serviceName, serviceConfiguration);
        }
       

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceConfiguration"></param>
        public static void AddServiceConfiguration(string providerName, ServiceConfiguration serviceConfiguration)
        {
            ServiceMetadata.AddServiceConfiguration(providerName, serviceConfiguration);
        }
        
      

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName"></param>
        /// <param name="serviceName"></param>
        public static void DeleteServiceConfiguration(string providerName, string serviceName)
        {
            ServiceMetadata.DeleteServiceConfiguration(providerName, serviceName);
        }

        /// <summary>
        /// Obtiene una lista de todas las aplicaciones configuradas en el origen de datos configurado por el 
        /// proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public static List<String> GetAllApplicationsId(string providerName)
        {
           return ServiceMetadata.GetAllApplicationsId(providerName);
        }
        /// <summary>
        /// Valida que el servicio está disponible para ser ejecutado.
        /// </summary>
        /// <param name="serviceConfiguration">configuración del servicio.</param>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        public static void ValidateAvailability(ServiceConfiguration serviceConfiguration, out IServiceContract result)
        {
            result = null;
            // Validación de disponibilidad del servicio.
            if (!serviceConfiguration.Available)
            {
                result = TryGetResultInstance(serviceConfiguration);
                ServiceError wServiceError;

                #region < Log >
                Audit.LogNotAvailableExcecution(serviceConfiguration, out wServiceError);

                #endregion

                result.Error = wServiceError;
            }
        }
        static IServiceContract TryGetResultInstance(ServiceConfiguration serviceConfiguration)
        {
            return (IServiceContract)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(serviceConfiguration.Response);
        }

        #region private methods
        /// <summary>
        /// Crea un ámbito de transacción en base a la configuración del servicio de negocio.
        /// </summary>
        /// <param name="serviceConfiguration">configuración del servicio de negocio.</param>
        /// <returns>ámbito de transacción. <see cref="TransactionScopeHandler"/> </returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        private static TransactionScopeHandler CreateTransactionScopeHandler(ServiceConfiguration serviceConfiguration)
        {
            //Creación del ámbito de la transacción.
            TransactionScopeHandler wResult = new TransactionScopeHandler(serviceConfiguration.TransactionalBehaviour, serviceConfiguration.IsolationLevel, new TimeSpan(0, 0, 0));

            return wResult;

        }

        /// <summary>
        /// Asigna datos a un dataset.
        /// </summary>
        /// <param name="pData">XML para cargar en el dataset.</param>
        /// <param name="pDataSet">Dataset sobre el que se cargará el XML de entrada.</param>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        private static void AssignData(string pData, DataSet pDataSet)
        {
            StringReader wReader = new StringReader(pData);
            pDataSet.ReadXml(wReader);

            wReader.Dispose();
            wReader = null;
        }


        /// <summary>
        /// Ruta prefija donde se deberan obtener los assemblies. 
        /// Por defecto se retorna \bin del servicio
        /// </summary>
        /// <param name="serviceConfiguration"></param>
        /// <returns>Ruta prefijada del servicio</returns>
        private static string GePatch(ServiceConfiguration serviceConfiguration)
        {
            String wAssembliesPath = String.Empty;

            if (serviceConfiguration.ApplicationId != null)
            {
                if (serviceConfiguration.ApplicationId.Length == 0)
                {
                    return String.Empty;
                }
            }
            else
            {
                return String.Empty;
            }


            wAssembliesPath = ConfigurationManager.GetProperty("AssembliesPath",
                                                                serviceConfiguration.
                                                                    ApplicationId);

            //Si no existe tal carpeta por defecto se busca en el \bin de la aplicacion
            if (!Directory.Exists(wAssembliesPath))
                wAssembliesPath = String.Empty;


            return wAssembliesPath;
        }

   

        #endregion
    }
}
