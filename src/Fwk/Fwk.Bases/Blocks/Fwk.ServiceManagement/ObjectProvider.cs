using System;
using System.Collections.Generic;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.Bases;
using Fwk.Exceptions;

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
		/// <summary>
		/// Instancia una clase implementadora de IServiceConfigurationManager.
		/// </summary>
        /// <remarks>Recupera el tipo a instanciar de los settings de la aplicación.</remarks>
        /// <returns>Administrador de configuración de servicio.</returns>
		/// <date>2008-04-10T00:00:00</date>
		/// <author>moviedo</author>
        public static IServiceConfigurationManager GetServiceConfigurationManager()
		{
            // Instanciación del ServiceConfigurationManager.
            try
            {
                IServiceConfigurationManager wResult = (IServiceConfigurationManager)
                    ReflectionFunctions.CreateInstance(Fwk.Bases.ConfigurationsHelper.ServiceConfigurationManagerType);
                return wResult;
            }
            catch (TypeInitializationException e1)
            {
                System.Text.StringBuilder wMessage = new StringBuilder();
                wMessage.Append("Error al inicializar la metadata de los servicios  \r\n");
                wMessage.Append("verifique: \r\n");
                wMessage.AppendLine("Archivo de configuracion en la seccion Fwk.Bases.Properties.Settings el ");
                wMessage.AppendLine("atributo [ServiceConfigurationManagerType] = tipo, valores posibles :");
                wMessage.AppendLine("Si tipo es XML  [XmlServiceConfigurationManager]  ");
                wMessage.AppendLine("Si tipo es database  [DatabaseServiceConfigurationManager] ");

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
