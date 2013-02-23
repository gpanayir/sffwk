using System;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;
using Fwk.Configuration;
using Fwk.Logging;
using Fwk.Exceptions;
using Fwk.Transaction;
using Fwk.Bases;
using Fwk.HelperFunctions;
using Fwk.ServiceManagement;
using System.Collections.Generic;
using Fwk.ConfigSection;
using Fwk.ConfigData;

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
        Required=0,
        /// <summary>
        /// Se auditará la  ejecución del servicio si éste está configurado para ser auditado.
        /// </summary>
        Optional=1,
        /// <summary>
        /// No se auditará la  ejecución del servicio, sin importar la configuración del mismo.
        /// </summary>
        None=2
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
        internal static fwk_ServiceDispatcher ServiceDispatcherConfig=null;
        internal static bool Stopped = true;

        /// <summary>
        /// 
        /// </summary>
        static FacadeHelper()
        {
            String stringMessage = string.Empty;
            ReloadConfig(out stringMessage);
        }

        /// <summary>
        /// Permite volver a cargar la configuracion si es que en el inicio estatico no lo hiso correctamente
        /// </summary>
        internal static void ReloadConfig(out String stringMessage)
        {
            stringMessage = string.Empty;
            if (Stopped)
            {

                try
                {
                    //ConnectionString donde proviene la configuracion del Service Dispatcher
                    ConfigurationsHelper.ServiceDispatcherConnection = System.Configuration.ConfigurationManager.AppSettings["ServiceDispatcherConnection"];
                    string serviceDispatcherName = System.Configuration.ConfigurationManager.AppSettings["ServiceDispatcherName"];
                    if (!String.IsNullOrEmpty(ConfigurationsHelper.ServiceDispatcherConnection) ||
                        !String.IsNullOrEmpty(serviceDispatcherName))
                    {
                        if (System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationsHelper.ServiceDispatcherConnection] == null)
                        {
                            TechnicalException te = new TechnicalException(string.Concat("No se puede encontrar la cadena de conexión : ", ConfigurationsHelper.ServiceDispatcherConnection));
                            ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                            te.ErrorId = "8200";
                            stringMessage = Audit.LogDispatcherErrorConfig(te).Message;
                        }
                        using (FwkDatacontext context = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[ConfigurationsHelper.ServiceDispatcherConnection].ConnectionString))
                        {
                            ServiceDispatcherConfig = context.fwk_ServiceDispatchers.Where(s => s.InstanseName.Equals(serviceDispatcherName.Trim())).FirstOrDefault();

                            if (ServiceDispatcherConfig == null)
                            {
                                TechnicalException te = new TechnicalException(string.Concat("No se puede encontrar la configuracion del despachador de servicio en la base de datos\r\nCadena de conexión : ", ConfigurationsHelper.ServiceDispatcherConnection));
                                ExceptionHelper.SetTechnicalException<DatabaseConfigManager>(te);
                                te.ErrorId = "7009";
                                stringMessage = Audit.LogDispatcherErrorConfig(te).Message;
                            }
                        }

                        ConfigurationsHelper.HostApplicationName = ServiceDispatcherConfig.InstanseName;
                        Stopped = false;
                    }
                    else
                    {
                        Stopped = true;

                        stringMessage = Audit.LogDispatcherErrorConfig(null).Message;
                    }
                }
                catch (Exception ex)
                {
                    Stopped = true;

                    stringMessage = Audit.LogDispatcherErrorConfig(ex).Message;
                }
            }
        }

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

            //  ejecución del servicio.
            wTransactionScopeHandler.InitScope();

            wResult = RunService(pData, serviceConfiguration, out wServiceError);

            if (wServiceError == null)
                wTransactionScopeHandler.Complete();
            else
                wTransactionScopeHandler.Abort();



            wTransactionScopeHandler.Dispose();
            wTransactionScopeHandler = null;

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

            //  ejecución del servicio.
            wTransactionScopeHandler.InitScope();
            wResult = RunService(pRequest, serviceConfiguration, out wServiceError);

            if (wServiceError == null)
                wTransactionScopeHandler.Complete();
            else
                wTransactionScopeHandler.Abort();


            wTransactionScopeHandler.Dispose();
            wTransactionScopeHandler = null;

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
            ServiceError wServiceError = null;
            return RunService(pData, serviceConfiguration, out wServiceError);
            
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
            ServiceError wServiceError = null;
            return RunService(pRequest, serviceConfiguration, out wServiceError);
        }



        /// <summary>
        /// Ejecuta el servicio de negocio.
        /// </summary>
        /// <param name="pRequest">Request de entrada que se pasa al servicio</param>
        /// <param name="pServiceConfiguration">configuración del servicio.</param>
        /// <param name="pserviError">serviError</param> 
        /// <returns>XML que representa el resultado de la  ejecución del servicio.</returns>
        /// <date>2007-08-07T00:00:00</date>
        /// <author>moviedo</author>
        static IServiceContract RunService(IServiceContract pRequest, ServiceConfiguration pServiceConfiguration, out ServiceError pserviError)
        {
            IServiceContract wResponse = null;

            try
            {
                pRequest.InitializeServerContextInformation();
                // obtención del Response.
                Type wServiceType = ReflectionFunctions.CreateType(pServiceConfiguration.Handler);

                object wServiceInstance = Activator.CreateInstance(wServiceType);
                wResponse =
                    (wServiceType.GetMethod("Execute").Invoke(wServiceInstance, new object[] { pRequest }) as
                     IServiceContract);

                wResponse.InitializeServerContextInformation();


            }

            #region [manage Exception]
            catch (System.IO.FileNotFoundException ex)
            {

                wResponse = GetResponse(pServiceConfiguration);// (IServiceContract)ReflectionFunctions.CreateInstance(pServiceConfiguration.Response);

                wResponse.Error = new ServiceError();
                System.Text.StringBuilder wMessage = new StringBuilder();

                wResponse.Error.ErrorId = "7003";

                #region Message
                wMessage.Append("El despachador de servicio no pudo encontrar alguna de los siguientes assemblies \r\n");

                wMessage.Append("o alguna de sus dependencias: \r\n");

                wMessage.Append("Servicio: ");
                wMessage.Append(pServiceConfiguration.Handler);
                wMessage.Append(Environment.NewLine);

                wMessage.Append("Request: ");
                wMessage.Append(pServiceConfiguration.Request);
                wMessage.Append(Environment.NewLine);

                wMessage.Append("Response: ");
                wMessage.Append(pServiceConfiguration.Response);
                wMessage.Append(Environment.NewLine);

                wMessage.Append("Mensaje original :");
                wMessage.Append(Environment.NewLine);
                wMessage.Append(ex.Message);
                #endregion

                wResponse.Error.Message = wMessage.ToString();
                FillServiceError(wResponse.Error, ex);

            }
            catch (System.Reflection.TargetInvocationException ex)
            {
                wResponse = GetResponse(pServiceConfiguration);
                wResponse.Error = GetServiceError(ex.InnerException);

            }
            catch (TypeLoadException tl)
            {
                wResponse = GetResponse(pServiceConfiguration);
                System.Text.StringBuilder wMessage = new StringBuilder();
                wResponse.Error = new ServiceError();

                wResponse.Error.ErrorId = "7002";
                wMessage.Append("No se encuentra el o los assemblies para cargar el servicio " + pServiceConfiguration.Name);
                wMessage.AppendLine();
                wMessage.AppendLine(tl.Message);
                wResponse.Error.Message = wMessage.ToString();
                FillServiceError(wResponse.Error, tl);
            }
            catch (Exception ex)
            {
                wResponse = GetResponse(pServiceConfiguration);// (IServiceContract)ReflectionFunctions.CreateInstance(pServiceConfiguration.Response);
                wResponse.Error = GetServiceError(ex);
            }

            #endregion

            pserviError = wResponse.Error;

            #region < Log >
            if ((AuditMode)FacadeHelper.ServiceDispatcherConfig.AuditMode == AuditMode.Required)
                Audit.LogSuccessfulExecution(pRequest, wResponse);
            else
            {
                if (pServiceConfiguration.Audit == true )
                {
                    Audit.LogSuccessfulExecution(pRequest, wResponse);
                }
            }
            //Si ocurre un error cualquiera se loguea el mismo
            if (wResponse.Error != null)
                Audit.LogNonSucessfulExecution(pRequest, wResponse);//, pServiceConfiguration);
            #endregion




            return wResponse;

        }

        static ServiceError GetServiceError(Exception e)
        {
            ServiceError err = null;
            if ((e is TechnicalException))
            {
                TechnicalException tx = (TechnicalException)e;
                err = new ServiceError();

                err.ErrorId = tx.ErrorId;
                err.Message = tx.Message;
                err.Source = tx.Source;

                FillServiceError(err, tx);

            }

            if ((e is FunctionalException))
            {
                FunctionalException fx = (FunctionalException)e;
                err = new ServiceError();
                err.ErrorId = fx.ErrorId;
                err.Message = fx.Message;
                err.Source = fx.Source;
                err.Severity = Enum.GetName(typeof(FunctionalException.ExceptionSeverity), fx.Severity);
                FillServiceError(err, fx);

            }
            //if (e is System.TypeLoadException)
            //{

            //    System.Text.StringBuilder wMessage = new StringBuilder();
            //    err = new ServiceError();

            //    err.ErrorId = "7002";
            //    wMessage.Append("No se encuentra el o los assemblies para cargar el servicio " + pServiceConfiguration.Name);
            //    wMessage.AppendLine();
            //    wMessage.AppendLine(e.Message);
            //    err.Message = wMessage.ToString();
            //    FillServiceError(err, e);

            //}

            if (err == null)
            {
                err = new ServiceError();
                if (e.InnerException != null)
                    e = e.InnerException;
                err.Message = e.Message;
                FillServiceError(err, e);
            }
            return err;
        }


        /// <summary>
        /// Ejecuta el servicio de negocio.
        /// </summary>
        /// <param name="pData">XML con datos de entrada.</param>
        /// <param name="pServiceConfiguration">configuración del servicio.</param>
        /// <param name="pserviError"></param>
        /// <returns>XML que representa el resultado de la  ejecución del servicio.</returns>
        /// <date>2007-08-07T00:00:00</date>
        /// <author>moviedo</author>
        static string RunService(string pData, ServiceConfiguration pServiceConfiguration, out ServiceError pserviError)
        {
            IServiceContract wRequest = null;
            IServiceContract wResponse = null;

            // Obtencion del Request.
            wRequest = (IServiceContract)ReflectionFunctions.CreateInstance(pServiceConfiguration.Request);

            if (wRequest == null)
            {
                System.Text.StringBuilder wMessage = new StringBuilder();

                wMessage.Append("Verifique que este assemblie se encuentra en el host del despachador de servicios");
                wMessage.Append("El servicio " + pServiceConfiguration.Handler);
                wMessage.AppendLine(" no se puede ejecutar debido a que esta faltando el assembly ");
                wMessage.Append(pServiceConfiguration.Request);
                wMessage.Append(" en el despachador de servicio");

                throw GetTechnicalException(wMessage.ToString(), "7002", null);
            }

            wRequest.SetXml(pData);
            wRequest.InitializeServerContextInformation();


            wResponse = RunService(wRequest, pServiceConfiguration, out pserviError);


            return wResponse.GetXml();
        }


        /// <summary>
        /// Completa el error del que va dentro del Request con informacion de :
        /// Assembly, Class, Namespace, UserName,  InnerException, etc
        /// </summary>
        /// <param name="pServiceError"></param>
        /// <param name="pException"></param>
        static void FillServiceError(ServiceError pServiceError, Exception pException)
        {
            if (ExceptionHelper.GetFwkExceptionTypes(pException) != FwkExceptionTypes.OtherException)
                pServiceError.Type = ExceptionHelper.GetFwkExceptionTypesName(pException);
            else
                pServiceError.Type = pException.GetType().Name;

            pServiceError.UserName = Environment.UserName;
            pServiceError.Machine = Environment.MachineName;
            if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                pServiceError.Source = "Despachador de servicios en " + Environment.MachineName;
            else
                pServiceError.Source = ConfigurationsHelper.HostApplicationName;

            //if (pException.InnerException != null)
             pServiceError.InnerMessageException = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pException);
        }
        /// <summary>
        /// Completa el error del que va dentro del Request con informacion de :
        /// Assembly, Class, Namespace, UserName,  InnerException, etc
        /// </summary>
        /// <param name="pMessage">Mensaje personalizado</param>
        /// <param name="pErrorId">Id del Error</param>
        /// <param name="pException">Alguna Exception que se quiera incluir</param>
        /// <date>2007-08-07T00:00:00</date>
        /// <author>moviedo</author> 
        internal static TechnicalException GetTechnicalException(String pMessage, String pErrorId, Exception pException)
        {
            TechnicalException te = new TechnicalException(pMessage, pException);

            te.ErrorId = pErrorId;
            te.Assembly = "Fwk.Bases";
            te.Class = "FacadeHelper";
            te.Namespace = "Fwk.BusinessFacades.Utils";

            //te.UserName = Environment.UserName;
            te.Machine = Environment.MachineName;

            if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                te.Source = "Despachador de servicios en " + Environment.MachineName;
            else
                te.Source = ConfigurationsHelper.HostApplicationName;

            return te;
        }

        /// <summary>
        /// Obtiene un objeto Response :: IServiceContract
        /// </summary>
        /// <param name="pServiceConfiguration"><see cref="ServiceConfiguration"/></param>
        /// <returns>IServiceContract</returns>
         static IServiceContract GetResponse(ServiceConfiguration pServiceConfiguration)
        {
            IServiceContract wResponse;
            try
            {
                wResponse = (IServiceContract)ReflectionFunctions.CreateInstance(pServiceConfiguration.Response);
            }
            catch (Exception ex)
            {
                System.Text.StringBuilder wMessage = new StringBuilder();

                wMessage.Append("El servicio " + pServiceConfiguration.Handler);
                wMessage.AppendLine(" no se puede ejecutar debido a que esta faltando el assembly ");
                wMessage.Append(pServiceConfiguration.Response);
                wMessage.Append(" en el despachador de servicio");

                throw GetTechnicalException(wMessage.ToString(), "7003", ex);
            }


            return wResponse;
        }


        #endregion

        #region ServiceConfiguration

        /// <summary>
        /// Recupera la configuración del servicio de negocio.
        /// </summary>
        /// <remarks>Lee la configuración utilizando un ServiceConfigurationManager del tipo especificado en los settings de la aplicación.</remarks>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
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
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>  
        /// <returns>ServiceConfigurationCollection</returns>
        public static ServiceConfigurationCollection GetAllServices(string providerName)
        {
            return ServiceMetadata.GetAllServices(providerName);
        }

    
        /// <summary>
        /// Actualiza la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <param name="serviceName"></param>
        /// <param name="serviceConfiguration"></param>
        public static void SetServiceConfiguration(string providerName, String serviceName, ServiceConfiguration serviceConfiguration)
        {
            ServiceMetadata.SetServiceConfiguration(providerName,serviceName, serviceConfiguration);
        }
       

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
        /// <param name="serviceConfiguration"></param>
        public static void AddServiceConfiguration(string providerName, ServiceConfiguration serviceConfiguration)
        {
            ServiceMetadata.AddServiceConfiguration(providerName, serviceConfiguration);
        }
        
      

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de la metadata de servicio</param>
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
        /// Obtiene info del proveedor de metadata
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de metadata de servicios.-</param>
        /// <returns></returns>
        public static MetadataProvider GetProviderInfo(string providerName)
        {
            ServiceProviderElement provider = ServiceMetadata.ProviderSection.GetProvider(providerName);
            if (provider == null)
            {
                if (string.IsNullOrEmpty(providerName))
                    throw GetTechnicalException("No se encuentra configurado un proveedor de metadatos de servicios por defecto en el despachador de servicios \r\n", "7201", null);
                else
                    throw GetTechnicalException(string.Format("No se encuentra configurado el proveedor de metadatos de servicios con el nombre {0} en el despachador de servicios \r\n", providerName),"7201", null);
            }

            return new MetadataProvider(provider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static List<MetadataProvider> RetriveProviders()
        {
            List<MetadataProvider> list = new List<MetadataProvider>();
            foreach (ServiceProviderElement providerElement in ServiceMetadata.ProviderSection.Providers)
            {
                list.Add(new MetadataProvider(providerElement));
            }
            return list;
        }
        #endregion

        
        /// <summary>
        /// Valida que el servicio está disponible para ser ejecutado.
        /// </summary>
        /// <param name="serviceConfiguration">configuración del servicio.</param>
        /// <param name="result"></param>
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
