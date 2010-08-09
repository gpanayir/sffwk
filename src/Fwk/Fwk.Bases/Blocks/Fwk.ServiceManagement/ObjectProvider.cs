using System;
using System.Collections.Generic;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.Bases;
using Fwk.Exceptions;
using System.Configuration;

namespace Fwk.ServiceManagement
{

	/// <summary>
	/// Proveedor de instancias de implementaciones de ISrviceConfigurationManager.
	/// </summary>
	/// <remarks>
    /// Recupera el tipo a instanciar de los settings de la aplicación.
	/// </remarks>
	/// <date>2008-04-10T00:00:00</date>
	/// <author>moviedo</author>
	public class ObjectProvider
	{

        static ServiceProviderSection _ServiceProviderSection;

		/// <summary>
		/// Instancia una clase implementadora de IServiceConfigurationManager.
		/// </summary>
        /// <remarks>Recupera el tipo a instanciar de los settings de la aplicación.</remarks>
        /// <returns>Administrador de configuración de servicio.</returns>
		/// <date>2008-04-10T00:00:00</date>
		/// <author>moviedo</author>
        public static IServiceConfigurationManager GetServiceConfigurationManager()
		{
            return GetServiceConfigurationManager(string.Empty);
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static IServiceConfigurationManager GetServiceConfigurationManager(string providerName)
        {
            try
            {
                if (_ServiceProviderSection == null)
                {
                    _ServiceProviderSection = ConfigurationManager.GetSection("FwkServiceMetadata") as ServiceProviderSection;
                }

                ServiceProviderElement provider = _ServiceProviderSection.GetProvider(providerName);

                if(string.IsNullOrEmpty(provider.SourceInfo))
                {
                    System.Text.StringBuilder wMessage = new StringBuilder();
                    wMessage.Append("Error al inicializar la metadata de los servicios  \r\n");
                    wMessage.Append("El atributo SourceInfo no puede estar vasio.  \r\n");
                    wMessage.AppendLine("Verifique el archivo de configuracion en la seccion FwkServiceMetadata el ");
                    wMessage.AppendLine("atributo [type] y [SourceInfo]  posibles :");
                    wMessage.AppendLine("Si tipo es XML espesifique nombre de archivo  ");
                    wMessage.AppendLine("Si tipo es sqldatabase  espesifique nombre de connexionstring \r\n");


                    TechnicalException te = new TechnicalException(wMessage.ToString());
                    te.ErrorId = "7004";
                    te.Assembly = typeof(ObjectProvider).AssemblyQualifiedName;
                    te.Class = typeof(ObjectProvider).Name;
                    te.Namespace = typeof(ObjectProvider).Namespace;

                    throw te;

                }
        

                if (provider.ConfigProviderType == ServiceProviderType.xml)
                    return new XmlServiceConfigurationManager(provider.SourceInfo);
                else
                    return new DatabaseServiceConfigurationManager(provider.SourceInfo);
            }
            catch (TypeInitializationException e1)
            {
                System.Text.StringBuilder wMessage = new StringBuilder();
                wMessage.Append("Error al inicializar la metadata de los servicios  \r\n");
                       wMessage.AppendLine("Verifique el archivo de configuracion en la seccion FwkServiceMetadata el \r\n");
                wMessage.AppendLine("atributo [type] y [SourceInfo]  posibles :");
                wMessage.AppendLine("Si tipo es XML espesifique nombre de archivo  ");
                wMessage.AppendLine("Si tipo es sqldatabase  espesifique nombre de connexionstring \r\n");
                

                TechnicalException te = new TechnicalException(wMessage.ToString(), e1);
                te.ErrorId = "7004";
                te.Assembly = typeof(ObjectProvider).AssemblyQualifiedName;
                te.Class = typeof(ObjectProvider).Name;
                te.Namespace = typeof(ObjectProvider).Namespace;

                throw te;
            }

            catch (System.Reflection.TargetInvocationException e3)
            {
                if (e3.InnerException.GetType() == typeof(TechnicalException))
                {
                    throw (TechnicalException)e3.InnerException;
                }
                throw e3;
            }

        }
	}
}
