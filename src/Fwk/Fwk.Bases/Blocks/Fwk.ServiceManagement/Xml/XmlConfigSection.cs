using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Fwk.ServiceManagement.Xml
{

	/// <summary>
    /// Sección de configuración para el administrador de configuración de servicios con repositorio XML.
	/// </summary>
	/// <date>2008-04-14T00:00:00</date>
	/// <author>moviedo</author>
	internal class XmlConfigSection : ConfigurationSection
	{
		#region <public properties>

		/// <summary>
		/// Ruta del repositorio XML.
		/// </summary>
		/// <remarks>
        /// Si esta propiedad no se setea en la configuración de la aplicación el valor por defecto depende del tipo de aplicación:
		/// <list type="bullet">
		/// <item>Aplicaciones Windows: [raiz del servicio] + @"\BPConfig.xml"</item>
		/// <item>Aplicaciones Web: [raiz del directorio] + @"\BPConfig.xml"</item>
		/// </list>
		/// </remarks>
		/// <date>2008-04-10T00:00:00</date>
		/// <author>moviedo</author>
		[ConfigurationProperty("ConfigurationFilePath", DefaultValue = "BPConfig.xml")]
		public string ConfigurationFilePath
		{
			get
			{
				string wResult = (string)base["ConfigurationFilePath"];
				return wResult;
			}
			set
			{
				base["ConfigurationFilePath"] = value;
			}
		}
		#endregion
	}
}
