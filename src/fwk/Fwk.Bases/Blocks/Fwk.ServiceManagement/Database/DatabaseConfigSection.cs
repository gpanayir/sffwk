using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;

namespace Fwk.ServiceManagement
{
	/// <summary>
	/// Sección de configuración para el administrador de configuración de servicios con repositorio en base de datos.
	/// </summary>
	/// <date>2008-04-14T00:00:00</date>
	/// <author>moviedo</author>
	internal class DatabaseConfigSection : ConfigurationSection
	{
		#region <public properties>

		/// <summary>
		/// Cadena de conexión para acceder a la base de datos que sirve de repositorio de configuración.
		/// </summary>
		/// <remarks>
		/// Si esta propiedad no se setea en la configuración de la aplicación el valor por defecto es "BPConfig". Este valor es usado por <see cref="DatabaseServiceConfigurationManager"/> para conectarse al repositorio.
		/// </remarks>
		/// <date>2008-04-10T00:00:00</date>
		/// <author>moviedo</author>
		[ConfigurationProperty("ConnectionName", DefaultValue = "BPConfig")]
		public string ConnectionName
		{
			get
			{
				string wResult = (string)base["ConnectionName"];
				return wResult;
			}
			set
			{
				base["ConnectionName"] = value;
			}
		}
		#endregion
	}
}
