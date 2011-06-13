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
using Fwk.ConfigSection;

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

                pserviError = wResponse.Error;
            }

            catch (Exception ex)
            {
                wResponse = GetResponse(pServiceConfiguration);// (IServiceContract)ReflectionFunctions.CreateInstance(pServiceConfiguration.Response);

                if ((ex.InnerException is TechnicalException))
                {
                    TechnicalException tx = (TechnicalException)ex.InnerException;
                    wResponse.Error = new ServiceError();

                    wResponse.Error.ErrorId = tx.ErrorId;
                    wResponse.Error.Message = tx.Message;
                    wResponse.Error.Source = tx.Source;

                    FillServiceError(wResponse.Error, tx);

                }

                if ((ex.InnerException is FunctionalException))
                {
                    FunctionalException fx = (FunctionalException)ex.InnerException;
                    wResponse.Error = new ServiceError();

                    wResponse.Error.ErrorId = fx.ErrorId;
                    wResponse.Error.Message = fx.Message;
                    wResponse.Error.Source = fx.Source;
                    wResponse.Error.Severity = Enum.GetName(typeof(FunctionalException.ExceptionSeverity), fx.Severity);


                    wResponse.InitializeServerContextInformation();

                    FillServiceError(wResponse.Error, fx);

                }
                if (ex is System.TypeLoadException)
                {

                    System.Text.StringBuilder wMessage = new StringBuilder();
                    wResponse.Error = new ServiceError();

                    wResponse.Error.ErrorId = "7002";
                    wMessage.Append("No se encuentra el o los assemblies para cargar el servicio " + pServiceConfiguration.Name);
                    wMessage.AppendLine("");
                    wMessage.AppendLine(ex.Message);
                    wResponse.Error.Message = wMessage.ToString();
                    FillServiceError(wResponse.Error, ex);

                }

                if (wResponse.Error == null)
                {
                    wResponse.Error = new ServiceError();


                    wResponse.Error.Message = ex.Message;// "No se encuentra configurado el servicio " + pServiceConfiguration.Name;

                    FillServiceError(wResponse.Error, ex);

                }
                pserviError = wResponse.Error;
            }

            #endregion

            pserviError = wResponse.Error;

            #region < Log >

            if (pServiceConfiguration.Audit == true)
            {
                Audit.LogSuccessfulExecution(pRequest, wResponse);
            }
            //Si ocurre un error cualquiera se loguea el mismo
            if (pserviError != null)
                Audit.LogNonSucessfulExecution(pserviError, pServiceConfiguration);
            #endregion




            return wResponse;



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
            pServiceError.Type = pException.GetType().Name;

            //pServiceError.Assembly = "Fwk.BusinessFacades";
            //pServiceError.Class = "FacadeHelper";
            //pServiceError.Namespace = "Fwk.BusinessFacades.Utils";

            pServiceError.UserName = Environment.UserName;
            pServiceError.Machine = Environment.MachineName;

            if (string.IsNullOrEmpty(ConfigurationsHelper.HostApplicationName))
                pServiceError.Source = "Despachador de servicios en " + Environment.MachineName;
            else
                pServiceError.Source = ConfigurationsHelper.HostApplicationName;

            if (pException.InnerException != null)
                pServiceError.InnerMessageException = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pException.InnerException);
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
