using System;
using System.Collections;

namespace Fwk.Configuration.Common
{

	[FlagsAttribute]
	public enum FileStatus
	{
		Ok = 1,
		Expired = 2,
		Inconsistent = 4
	}

	/// <summary>
	/// Clase contenedora de archivos de configuracion y sus estados. Esta clase permite cachear en memoria las configuraciones que
	/// son requeridas por las aplicacioenes. 
	/// </summary>
	/// <Author>Marcelo Oviedo</Author>
	public class ConfigurationRepository
	{
		private Hashtable __Files;


		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		public ConfigurationRepository()
		{
			__Files = new Hashtable();
		}

		/// <summary>
		/// Agrega un configuration file al hashtable.
		/// </summary>
		/// <param name="pConfigurationFile">ConfigurationFile configurado.</param>
		public void AddConfigurationFile (ConfigurationFile pConfigurationFile)
		{	
			if (pConfigurationFile == null)
			{
				throw new Exception ("No hay datos para configurar.");
			}

			if (__Files.Contains(pConfigurationFile.ConfigResult.FileName))
			{
				throw new Exception ("El archivo ya se encuentra configurado");
			}

			__Files.Add(pConfigurationFile.ConfigResult.FileName, pConfigurationFile);
			
		}


		/// <summary>
		/// Obtiene un ConfigurationFile del hashtable.
		/// </summary>
		/// <param name="pFileName">Nombre de archivo.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
		public ConfigurationFile GetConfigurationFile(string pFileName)
		{
			return (ConfigurationFile) __Files[pFileName];
		}

	}

    /// <summary>
    /// Reprecenta un archivo de confuguracion y sus estados en memoria.-
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
	[Serializable]
	public class ConfigurationFile
	{
		private ConfigurationResponse.Result __ConfigResult;
		private DateTime __TimeStamp;

		/// <summary>
		/// Resultado de la invocacíon al webservice.
		/// </summary>
		public ConfigurationResponse.Result ConfigResult
		{
			get
			{
				return __ConfigResult;
			}
			set
			{
				__ConfigResult = value;
				__TimeStamp = DateTime.Now;
			}
		}


		/// <summary>
		/// Fecha y hora de la obtención de la configuración.
		/// </summary>
		public DateTime TimeStamp
		{
			get
			{
				return __TimeStamp;
			}
		}


		/// <summary>
		/// Contenido del archivo desencriptado.
		/// </summary>
		public string DecryptedFileContent
		{
			get 
			{
				string wResult;

				if (__ConfigResult.Encrypted)
                    wResult = Fwk.HelperFunctions.CryptographyFunctions.Decrypt(this.__ConfigResult.FileContent);
				else
					wResult = __ConfigResult.FileContent;

				return wResult;
			}
		}


		/// <summary>
		/// Constructor por defecto.
		/// </summary>
		public ConfigurationFile()
		{
			__TimeStamp = new DateTime(0);
		}


		/// <summary>
		/// Chequea si el archivo expiró.
		/// </summary>
		/// <returns>bool</returns>
		public bool CheckExpiration()
		{
			bool wResult = (this.__ConfigResult.TTL != 0 && this.__TimeStamp.AddSeconds(this.__ConfigResult.TTL) < DateTime.Now);
			return wResult;
		}


		/// <summary>
		/// Devuelve el estado del ConfigurationFile
		/// </summary>
		/// <returns>FileStatus</returns>
		public FileStatus CheckFileStatus()
		{
			FileStatus wResult;

			if (this.__TimeStamp == new DateTime(0))
				wResult = FileStatus.Inconsistent;
			else if (CheckExpiration())
				wResult = FileStatus.Expired;
			else
				wResult = FileStatus.Ok;

			return wResult;
				
		}

	}

}
