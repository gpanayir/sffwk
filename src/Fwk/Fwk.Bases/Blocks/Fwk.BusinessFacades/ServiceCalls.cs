using System;
using System.Collections.Generic;
using System.Text;
using Fwk.Bases;
using Fwk.Exceptions;
using Fwk.HelperFunctions;
using Fwk.ServiceManagement;

namespace Fwk.BusinessFacades.Utils
{
    internal  class ServiceCalls
    {


     
        /// <summary>
        /// Ejecuta el servicio de negocio.
        /// </summary>
        /// <param name="pRequest">Request de entrada que se pasa al servicio</param>
        /// <param name="pServiceConfiguration">configuración del servicio.</param>
        /// <param name="pserviError">serviError</param> 
        /// <returns>XML que representa el resultado de la  ejecución del servicio.</returns>
        /// <date>2007-08-07T00:00:00</date>
        /// <author>moviedo</author>
        public static IServiceContract 
            RunService
            (IServiceContract pRequest, 
            ServiceConfiguration pServiceConfiguration, 
            out ServiceError pserviError)
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

                wMessage.Append("Mensage original :");
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
                if (pserviError == null)
                    Audit.LogSuccessfulExecution(pRequest, wResponse);
                else
                    Audit.LogNonSucessfulExecution(pserviError, pServiceConfiguration);

            }
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
        public static string RunService(string pData, ServiceConfiguration pServiceConfiguration, out ServiceError pserviError)
        {
            IServiceContract wRequest = null;
            IServiceContract wResponse = null;

            // Obtencion del Request.
            wRequest = (IServiceContract)ReflectionFunctions.CreateInstance(pServiceConfiguration.Request);

            if (wRequest == null)
            {
                System.Text.StringBuilder wMessage = new StringBuilder();

                wMessage.Append(" Verifique que este assemblie se encuentra en el host del despachador de servicios");
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
        private static void FillServiceError(ServiceError pServiceError, Exception pException)
        {
            pServiceError.Type = pException.GetType().Name;
            pServiceError.Assembly = "Fwk.BusinessFacades";
            pServiceError.Class = "FacadeHelper";
            pServiceError.Namespace = "Fwk.BusinessFacades.Utils";

            pServiceError.UserName = Environment.UserName;
            pServiceError.Machine = Environment.MachineName;
            pServiceError.Source = "Despachador de servicios en " + Environment.MachineName;
            if (pException.InnerException != null)
                pServiceError.InnerMessageException =    Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pException.InnerException);
        }
        /// <summary>
        /// Completa el error del que va dentro del Request con informacion de :
        /// Assembly, Class, Namespace, UserName,  InnerException, etc
        /// </summary>
        /// <param name="pMessage">Mensage personalizado</param>
        /// <param name="pErrorId">Id del Error</param>
        /// <param name="pException">Alguna Exception que se quiera incluir</param>
        /// <date>2007-08-07T00:00:00</date>
        /// <author>moviedo</author> 
        private static TechnicalException GetTechnicalException(String pMessage, String pErrorId, Exception pException)
        {
            TechnicalException te = new TechnicalException(pMessage, pException);

            te.ErrorId = pErrorId;
            te.Assembly = "Fwk.BusinessFacades";
            te.Class = "ServiceCall";
            te.Namespace = "Fwk.BusinessFacades.Utils";

            //te.UserName = Environment.UserName;
            te.Machine = Environment.MachineName;
            te.Source = "Despachador de servicios en " + Environment.MachineName;

           

            return te;
        }

        /// <summary>
        /// Obtiene un objeto Response :: IServiceContract
        /// </summary>
        /// <param name="pServiceConfiguration"><see cref="ServiceConfiguration"/></param>
        /// <returns>IServiceContract</returns>
        private static IServiceContract GetResponse(ServiceConfiguration pServiceConfiguration)
        {
            IServiceContract wResponse = (IServiceContract)ReflectionFunctions.CreateInstance(pServiceConfiguration.Response);

            //No se puede cargar el request
            if (wResponse == null)
            {
                System.Text.StringBuilder wMessage = new StringBuilder();

                wMessage.Append("El servicio " + pServiceConfiguration.Handler);
                wMessage.AppendLine(" no se puede ejecutar debido a que esta faltando el assembly ");
                wMessage.Append(pServiceConfiguration.Response);
                wMessage.Append(" en el despachador de servicio");

                throw GetTechnicalException(wMessage.ToString(), "7002", null);
            }
            return wResponse;
        }
    }
}
