using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Logging;
using Fwk.Bases;
using Fwk.Exceptions;

namespace Fwk.BusinessFacades.Utils
{
    static class Audit
    {

        /// <summary>
        /// Genera un log de tipo "Warning" cuando se ha intentado ejecutar
        /// un servicio que está deshabilitado.
        /// </summary>
        /// <param name="pConfig">configuración del servicio.</param>
        /// <param name="pServiceError">pServiceError </param> 
        internal static void LogNotAvailableExcecution(ServiceConfiguration pConfig, out ServiceError pServiceError)
        {
             pServiceError = new ServiceError();


            StringBuilder s = new StringBuilder();
     
            s.AppendLine("Se ha intentado ejecutar un servicio que está configurado como no disponible.");
            s.AppendLine("Service :");
            s.AppendLine(pConfig.Handler);
            pServiceError.Type = typeof(TechnicalException).Name;
            pServiceError.Message = s.ToString();
            pServiceError.ErrorId = "7006";
            pServiceError.Assembly = "Fwk.BusinessFacades";
            pServiceError.Class = "FacadeHelper";
            pServiceError.Namespace = "Fwk.BusinessFacades";
            pServiceError.UserName = Environment.UserName;
            pServiceError.Machine = Environment.MachineName;
            try
            {
                /// TODO: ver prefijo del log
                Event ev = new Event(EventType.Error,Fwk.Bases.ConfigurationsHelper.HostApplicationName, pServiceError.GetXml(), pServiceError.Machine, pServiceError.UserName);
                Fwk.Logging.StaticLogger.Log(ev);
            }
            catch { }
           
        }



        /// <summary>
        /// Genera un log de tipo "Error" cuando se ha producido
        /// un error en la  ejecución del servicio.
        /// </summary>
        /// <param name="pException">excepción.</param>
        /// <param name="pConfig">configuración del servicio.</param>
        internal static void LogNonSucessfulExecution(Exception pException, ServiceConfiguration pConfig)
        {
            ServiceError pServiceError = new ServiceError();
            pServiceError.Message = Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pException);
            

            LogNonSucessfulExecution(pServiceError,pConfig);
      
        }

        /// <summary>
        /// Genera un log de tipo "Error" cuando se ha producido
        /// un error en la  ejecución del servicio.
        /// </summary>
        /// <param name="pServiceError">ServiceError.</param>
        /// <param name="pConfig">configuración del servicio.</param>
        internal static void LogNonSucessfulExecution(ServiceError pServiceError, ServiceConfiguration pConfig)
        {
            try
            {
                Event ev = new Event(EventType.Error, Fwk.Bases.ConfigurationsHelper.HostApplicationName, pServiceError.GetXml(), pServiceError.Machine, pServiceError.UserName);
                ///TODO: Ver prefijos de logs
                Fwk.Logging.StaticLogger.Log(ev);
            }
            catch { }
        }


        /// <summary>
        /// Almacena informacion de auditoria.- 
        /// Llama a StaticLogger y carga el log auditando los datos del Request de entrada
        /// </summary>
        /// <param name="pRequest">Request</param>
        /// <param name="wResult">Response</param>
        internal static void LogSuccessfulExecution(IServiceContract pRequest, IServiceContract wResult)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("<Request>");
            s.AppendLine(pRequest.GetXml());
            s.AppendLine("</Request>");
            s.AppendLine("<Response>");
            s.AppendLine(wResult.GetXml());
            s.AppendLine("</Response>");

            try
            {
                ///TODO: Ver prefijos de logs
                Event ev = new Event(EventType.Audit, Fwk.Bases.ConfigurationsHelper.HostApplicationName, s.ToString(), pRequest.ContextInformation.HostName, pRequest.ContextInformation.UserName);
                Fwk.Logging.StaticLogger.Log(ev);
                    
            }
            catch { }
            finally
            { s = null; }

        }
    }
}
