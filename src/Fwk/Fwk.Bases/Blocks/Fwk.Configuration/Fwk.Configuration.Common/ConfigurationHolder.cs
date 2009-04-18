using System;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Xml;
using System.Text;
using System.Collections;
using System.Configuration;
using Fwk.Bases.Properties;
using Fwk.HelperFunctions;

namespace Fwk.Configuration.Common
{

	
	/// <summary>
	/// Summary description for ConfigurationHolder.
	/// </summary>
	public class ConfigurationHolder: MarshalByRefObject
	{

		private ConfigurationRepository _ConfigData;

		/// <summary>
		/// Constructor por defecto
		/// </summary>
		public ConfigurationHolder()
		{
		}

		/// <summary>
		/// Redefinición de InitializeLifetimeService para configuración personalizada.
		/// </summary>
		/// <returns>Object</returns>
		public override Object InitializeLifetimeService()
		{
			ILease wlease = (ILease) base.InitializeLifetimeService();

			if (wlease.CurrentState == LeaseState.Initial)
			{
                int wSecs = Convert.ToInt32(ConfigurationManager.DefaultProvider.LifeTime);


				wlease.InitialLeaseTime = TimeSpan.FromSeconds(wSecs);
				wlease.RenewOnCallTime = TimeSpan.FromSeconds(wSecs);
			}

			return wlease;

		}


		/// <summary>
		/// Devuelve un grupo de un BaseConfigFile
		/// </summary>
		/// <param name="pBaseConfigFileName">Nombre del archivo</param>
		/// <param name="pGroupName">Nombre del grupo</param>
		/// <returns>Hashtable</returns>
		public Hashtable GetGroup (string pBaseConfigFileName, string pGroupName)
		{
			Hashtable ht = null;
			string valueToRet;
			ConfigurationFile wConfigurationFile = this.GetConfig(pBaseConfigFileName);

			if (!wConfigurationFile.ConfigResult.BaseConfigFile)
			{
				throw new Exception ("El archivo solicitado no es un archivo de configuración válido.");
			}

			XmlDocument wDoc = new XmlDocument();
			wDoc.LoadXml(wConfigurationFile.DecryptedFileContent);

			XmlElement wGroupElement = this.GetGroupElement(wDoc, pGroupName);
			
			if(wGroupElement != null)
			{
				// heurística de la capacidad de las tablas de hash
				ht = new Hashtable(Convert.ToInt32(wGroupElement.ChildNodes.Count * 1.75));
				foreach(XmlElement elem in wGroupElement.ChildNodes)
				{
					// toma el valor devuelto
					valueToRet = elem.InnerText;

					// agrego el valor
					ht.Add(elem.GetAttribute("name"), valueToRet);
				}
			}

			return ht;

		}

		/// <summary>
		/// Devuelve una propidedad de un grupo de un BaseConfigFile
		/// </summary>
		/// <param name="pBaseConfigFileName">Nombre de archivo</param>
		/// <param name="pGroupName">Nombre de grupo</param>
		/// <param name="pPropertyName">Nombre de propiedad</param>
		/// <returns>string</returns>
		public string GetProperty (string pBaseConfigFileName, string pGroupName, string pPropertyName)
		{
			ConfigurationFile wConfigurationFile = this.GetConfig(pBaseConfigFileName);

			if (!wConfigurationFile.ConfigResult.BaseConfigFile)
			{
				throw new Exception ("El archivo solicitado no es un archivo de configuración válido.");
			}


			XmlDocument wDoc = new XmlDocument();
			
			
			wDoc.LoadXml(wConfigurationFile.DecryptedFileContent);


			string wResult = String.Empty;

			/// verifica que haya un nodo padre para todos
			/// los grupos
			if(wDoc.DocumentElement != null)
			{
				/// prepara la consulta XPath
				StringBuilder sbXPath =  new StringBuilder("Group[@name='");
				sbXPath.Append(pGroupName);
				sbXPath.Append("']/Key[@name='");
				sbXPath.Append(pPropertyName);
				sbXPath.Append("']");

				/// realiza la consulta
				XmlElement wNode = (XmlElement) wDoc.DocumentElement.SelectSingleNode(sbXPath.ToString());

				if (wNode != null)			
					wResult = wNode.InnerText;

				wNode = null;
				sbXPath = null;

			}

			wConfigurationFile = null;
			wDoc = null;

			return wResult;

		}


		/// <summary>
		/// Devuelve el contenido completo de un archivo de configuración
		/// dado el nombre de archivo.
		/// </summary>
		/// <param name="pFileName">Nombre de archivo</param>
		/// <returns>ConfigurationFile</returns>
		public ConfigurationFile GetConfig(string pFileName)
		{

			string wFileContent = string.Empty;
			bool wIsNewFile = false;

			if (_ConfigData == null)
			{
				_ConfigData = new ConfigurationRepository();
			}

			ConfigurationFile wConfigurationFile = _ConfigData.GetConfigurationFile(pFileName);

			if (wConfigurationFile == null)
			{
				wConfigurationFile = new ConfigurationFile();
				wIsNewFile = true;
			}
            
			if (wConfigurationFile.CheckFileStatus() != FileStatus.Ok)
			{
				this.SetConfigurationFile(wConfigurationFile, pFileName);
				if (wIsNewFile && wConfigurationFile.ConfigResult.Cacheable) 
				{
					_ConfigData.AddConfigurationFile(wConfigurationFile);
				}
			}

			
			return wConfigurationFile;
            
		}


		/// <summary>
		/// Compara version del archivo especificado para determinar
		/// si es necesario actualizar.
		/// </summary>
		/// <param name="pFileName">Nombre de archivo</param>
		/// <param name="pClientVersion">Version del archivo en el cliente</param>
		/// <returns>FileStatus</returns>
		public FileStatus GetFileVersionStatus (string pFileName, string pClientVersion)
		{
            ConfigurationWebService.ConfigurationService wService = new ConfigurationWebService.ConfigurationService();
			FileStatus wResult = (FileStatus) wService.GetFileVersionStatus(pFileName, pClientVersion);
			
			wService.Dispose();
			wService = null;

			return wResult;
		}


		/// <summary>
		/// Devuelve un elemento representativo de un grupo.
		/// </summary>
		/// <param name="pDocument">Documento xml</param>
		/// <param name="pGroupName">Nombre del grupo</param>
		/// <returns>XmlElement</returns>
		private XmlElement GetGroupElement(XmlDocument pDocument, string pGroupName)
		{
			XmlElement retNode;

			if(pDocument.DocumentElement == null)
				return null;

			StringBuilder sbXPath =  new StringBuilder("Group[@name='");
			sbXPath.Append(pGroupName);
			sbXPath.Append("']");

			retNode = (XmlElement) pDocument.DocumentElement.SelectSingleNode(sbXPath.ToString());

			return retNode;
		}


		/// <summary>
		/// Configura un ConfigurationFile.
		/// </summary>
		/// <param name="pConfigurationFile">Objeto a configurar.</param>
		/// <param name="pFileName">Nombre de archivo.</param>
		public void SetConfigurationFile (ConfigurationFile pConfigurationFile, string pFileName)
		{
			ConfigurationResponse.Result wResult = (ConfigurationResponse.Result) SerializationFunctions.DeserializeFromXml(typeof(ConfigurationResponse.Result), InvokeService(pFileName));
			pConfigurationFile.ConfigResult = wResult;
			wResult = null;
		}
		
		/// <summary>
		/// Invoca al web service de configuración.
		/// </summary>
		/// <param name="pFileName">Nombre de archivo.</param>
		/// <returns>string</returns>
		private string InvokeService(string pFileName)
		{
            ConfigurationWebService.ConfigurationService wService = new ConfigurationWebService.ConfigurationService();
			string wResult = wService.GetConfig(pFileName);
			
			wService.Dispose();
			wService = null;

			return wResult;
		}

	}
}
