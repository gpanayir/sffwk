using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Logging;
using Fwk.Bases;
using Fwk.Exceptions;

namespace Fwk.BusinessFacades.Utils
{
    internal static class Audit
    {

        /// <summary>
        /// Genera un log de tipo "Warning" cuando se ha intentado ejecutar
        /// un servicio que está deshabilitado.
        /// </summary>
        /// <param name="pConfig">configuración del servicio.</param>
        public static void LogNotAvailableExcecution(ServiceConfiguration pConfig)
        {
            //Logger wLogger = new Logger();
            //wLogger.Warning("Serive Dispatcher", "Se ha intentado ejecutar un servicio que está configurado como no disponible.");
            //wLogger = null;


            StringBuilder s = new StringBuilder();
            s.AppendLine("<AnyMessage>");
            s.AppendLine("Se ha intentado ejecutar un servicio que está configurado como no disponible.");
            s.AppendLine("Service :");
            s.AppendLine(pConfig.Handler);
            s.AppendLine("</AnyMessage>");

            try
            {
                Fwk.Logging.StaticLogger.Warning("Serive Dispatcher", s.ToString());
            }
            catch { }
            finally
            { s = null; }
        }



        /// <summary>
        /// Genera un log de tipo "Error" cuando se ha producido
        /// un error en la  ejecución del servicio.
        /// </summary>
        /// <param name="pException">excepción.</param>
        /// <param name="pConfig">configuración del servicio.</param>
        public static void LogNonSucessfulExecution(Exception pException, ServiceConfiguration pConfig)
        {
            //Logger wLogger = new Logger();
            //wLogger.Error("Serive Dispatcher", Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pException));
            //wLogger = null;

            StringBuilder s = new StringBuilder();
            s.AppendLine("<AnyMessage>");
            s.AppendLine(Fwk.Exceptions.ExceptionHelper.GetAllMessageException(pException));
            s.AppendLine("</AnyMessage>");

            try
            {
                Fwk.Logging.StaticLogger.Error(
                "Serive Dispatcher",
                  s.ToString());
            }
            catch { }
            finally
            { s = null; }
        }

        /// <summary>
        /// Genera un log de tipo "Error" cuando se ha producido
        /// un error en la  ejecución del servicio.
        /// </summary>
        /// <param name="pServiceError">ServiceError.</param>
        /// <param name="pConfig">configuración del servicio.</param>
        public static void LogNonSucessfulExecution(ServiceError pServiceError, ServiceConfiguration pConfig)
        {
            StringBuilder s = new StringBuilder();
            s.AppendLine("<AnyMessage>");
            s.AppendLine(pServiceError.Message);
            s.AppendLine("</AnyMessage>");

            try
            {
                Fwk.Logging.StaticLogger.Audit(
                pServiceError.Source,
                  s.ToString(),
                pServiceError.UserName,
                pServiceError.Machine);
            }
            catch { }
            finally
            { s = null; }
          

        }


        /// <summary>
        /// Almacena informacion de auditoria.- 
        /// Llama a StaticLogger y carga el log auditando los datos del Request de entrada
        /// </summary>
        /// <param name="pRequest">Request</param>
        /// <param name="wResult">Response</param>
        public static void LogSuccessfulExecution(IServiceContract pRequest, IServiceContract wResult)
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
                Fwk.Logging.StaticLogger.Audit(
                    pRequest.ContextInformation.HostName,
                    s.ToString(),
                    pRequest.ContextInformation.UserName,
                    pRequest.ContextInformation.HostName);
            }
            catch { }
            finally
            { s = null; }

        }
    }
}
