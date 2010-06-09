using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.HelperFunctions;
using Fwk.Transaction;
using Fwk.Xml;
using Fwk.ServiceManagement.Xml;
using Fwk.Bases;
using Fwk.Exceptions;

namespace Fwk.ServiceManagement
{
	/// <summary>
	/// Manejador de configuración de servicios que trabaja con un archivo XML como repositorio de configuración.
	/// </summary>
	/// <date>2008-04-07T00:00:00</date>
	/// <author>moviedo</author>
	public sealed class XmlServiceConfigurationManager : IServiceConfigurationManager
	{
        static ServiceConfigurationCollection _Services;
        
        private string _Tag = String.Empty;

        public string Tag
        {
            get { return _Tag; }
            set { _Tag = value; }
        }

		/// <summary>
		/// Constructor por defecto
		/// </summary>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
        public  XmlServiceConfigurationManager()
		{
            _Services = GetAllServices();

		}

		

		#region < IServiceConfiguration Members >


		/// <summary>
		/// Devuelve la configuración de un servicio buscándolo en el repositorio XML.
		/// </summary>
		/// <param name="pServiceName">Nombre del servicio</param>
		/// <returns>configuración del servicio</returns>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
        public ServiceConfiguration GetServiceConfiguration(string pServiceName)
        {
            ServiceConfiguration wResult;
            
            if (!_Services.Contains(pServiceName))
            {
                Exceptions.TechnicalException te = new Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");
                te.Source = "Despachador de servicios";
                te.ErrorId = "7002";
                te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                te.Class = typeof(XmlServiceConfigurationManager).Name;
                te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
                throw te;
            }
        
            wResult = _Services[pServiceName];

            return wResult;

        }

            
        /// <summary>
        /// Busca el archivo BPConfig y lo carga a _Services que es un ServiceConfigurationCollection
        /// </summary>
        /// <returns></returns>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        public ServiceConfigurationCollection GetAllServices()
        {

            try
            {
                _Services = GetServiceConfigurationFromFile();

                return _Services;
            }
            catch (System.IO.IOException ioex)
            {


                string wMessage = string.Concat(
                "Error al inicializar la metadata de los servicios  \r\n",
                "Verifique: \r\n ",
                "Archivo de .config en la seccion Fwk.Bases.Properties.Settings el ",Environment.NewLine,
                "valor de [ServiceConfigurationSourceName],  que la ruta y archivo de metadata sea correcta");


                TechnicalException te = new TechnicalException(wMessage, ioex);
                te.Source = "Despachador de servicios";
                te.ErrorId = "7004";
                te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                te.Class = typeof(XmlServiceConfigurationManager).Name;
                te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
                throw te;


            }
            catch (TechnicalException te)
            {
                throw te;
            }
            catch (Exception ex)
            {
                string strError = string.Concat("Error al inicializar la metadata de los servicios  \r\n "                ,
                "Metadata :", Fwk.Bases.ConfigurationsHelper.ServiceConfigurationSourceName,Environment.NewLine);

                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException(strError.ToString(), ex);
                te.Source = "Despachador de servicios";
                te.ErrorId = "7004";
                te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                te.Class = typeof(XmlServiceConfigurationManager).Name;
                te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
                throw te;
            }
            
        }

		/// <summary>
		/// Actualiza la configuración de un servicio de negocio.
		/// </summary>
		/// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <param name="pServiceName">Nombre del servicio a actualizar.</param>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		public void SetServiceConfiguration(string pServiceName, ServiceConfiguration pServiceConfiguration)
		{

            try
            {
                _Services = GetAllServices();

                if (!_Services.Contains(pServiceName))
                {
                    Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");
                    te.Source = "Despachador de servicios";
                    te.ErrorId = "7002";
                    te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                    te.Class = typeof(XmlServiceConfigurationManager).Name;
                    te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
                    throw te;
                }


                ServiceConfiguration wServiceConfigurationEnDisco = _Services[pServiceName];
                _Services.Remove(wServiceConfigurationEnDisco);
                _Services.Add(pServiceConfiguration);
                SaveServiceConfigFile();
                
            }
            //TODO: controlar errores de carga de wServiceConfigurationEnDisco
            catch (Exception ex)
            {
                throw ex;
            }
		}

		/// <summary>
		/// Almacena la configuración de un nuevo servicio de negocio.
		/// </summary>
		/// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
        public void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration)
        {

            //try
            //{

                if (_Services.Contains(pServiceConfiguration.Name))
                {
                    Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceConfiguration.Name + " ya existe.");
                    te.ErrorId = "7002";
                    te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                    te.Class = typeof(XmlServiceConfigurationManager).Name;
                    te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
                    throw te;
                }

                _Services.Add(pServiceConfiguration);
                SaveServiceConfigFile();
            //}
            ///TODO: controlar errores de carga de wServiceConfigurationEnDisco
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

		/// <summary>
		/// Elimina la configuración de un servicio de negocio.
		/// </summary>
        /// <param name="pServiceName">Nombre del servicio.</param>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		public void DeleteServiceConfiguration(string pServiceName)
        {
            ServiceConfiguration wServiceConfigurationEnDisco = null;
            //try
            //{
                
                if (!_Services.Contains(pServiceName))
				{
                    Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");

                    te.ErrorId = "7002";
                    te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                    te.Class = typeof(XmlServiceConfigurationManager).Name;
                    te.Namespace = typeof(XmlServiceConfigurationManager).Namespace; 
                    
                    throw te;
				}
                 wServiceConfigurationEnDisco = _Services[pServiceName];
                _Services.Remove(wServiceConfigurationEnDisco);
                
                SaveServiceConfigFile();
            //}
            ///TODO: controlar errores de carga de wServiceConfigurationEnDisco
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

		}

		#endregion

		#region < Private methods >

		/// <summary>
		/// Busca la configuración de un servicio.
		/// </summary>
        /// <param name="pServiceName">Nombre del servicio de negocio.</param>
		/// <param name="pDocument">Documento con el contenido del repositorio XML.</param>
		/// <returns>Nodo que contiene la configuración del servicio.</returns>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
		private XmlElement GetXMLServiceNode(string pServiceName, XmlDocument pDocument)
		{
			XmlElement wNode;
			// realiza la consulta XPath
			string wXPath = "Service[@name='" + pServiceName + "']";
			wNode = (XmlElement)pDocument.DocumentElement.SelectSingleNode("Services").SelectSingleNode(wXPath);

			if (wNode == null)
			{
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");

                te.ErrorId = "7002";
                te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
                te.Class = typeof(XmlServiceConfigurationManager).Name;
                te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;

                throw te;
			}

			return wNode;
		}

		/// <summary>
		/// Recupera el repositorio XML.
		/// </summary>
		/// <returns>Documento con el contenido del repositorio XML.</returns>
		/// <date>2007-02-10T00:00:00</date>
		/// <author>moviedo</author>
        private XmlDocument GetXMLServiceConfigurationDocument()
		{
			XmlDocument wDocument;
			wDocument = new XmlDocument();
            
            if(_Tag.Length == 0)
			    wDocument.Load(GetXMLRepositoryPath());
            else
                wDocument.Load(_Tag);

			return wDocument;
		}
        /// <summary>
        /// Recupera ServiceConfigurationCollection.
        /// </summary>
        /// <returns>Documento con el contenido del repositorio XML.</returns>
        /// <date>2007-02-10T00:00:00</date>
        /// <author>moviedo</author>
        private ServiceConfigurationCollection GetServiceConfigurationFromFile()
        {

            String xml = FileFunctions.OpenTextFile(GetXMLRepositoryPath());
            ServiceConfigurationCollection list =
                (ServiceConfigurationCollection)SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xml);
            return list;
        }

		/// <summary>
		/// Devuelve la ruta al repositorio XML.
		/// </summary>
		/// <returns>Ruta al repositorio XML.</returns>
		/// <date>2007-07-13T00:00:00</date>
		/// <author>moviedo</author>
        public static string GetXMLRepositoryPath()
        {
            //Si existe el archivo 
            if (System.IO.File.Exists(Fwk.Bases.ConfigurationsHelper.ServiceConfigurationSourceName))
                return Fwk.Bases.ConfigurationsHelper.ServiceConfigurationSourceName;

            //Si no existe se puede ser q se trate de un servicio y los servicios no usan la carpeta de ejecucion como entorno de ejecucion


            string file =
              System.IO.Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase,
            System.IO.Path.GetFileName(Fwk.Bases.ConfigurationsHelper.ServiceConfigurationSourceName));

            if (System.IO.File.Exists(file))
                return file;

             System.Text.StringBuilder wMessage = new StringBuilder();
            wMessage.Append("Error al inicializar la metadata de los servicios  \r\n");
            
            //Si no existia por q estaba en blanco
            if(string.IsNullOrEmpty( Fwk.Bases.ConfigurationsHelper.ServiceConfigurationSourceName))

            {
                wMessage.Append("verifique \r\n");
                wMessage.AppendLine("Archivo de configuracion en la seccion Fwk.Bases.Properties.Settings el ");
                wMessage.AppendLine("valor de [ServiceConfigurationSourceName] no esta confugurado el nombre del archivo de metadata de servicios.-");
            }
           
             //Si llego hasta aqui directamente no existia
             wMessage.Append("No se puede encontrar el archivo ");
             wMessage.Append(Fwk.Bases.ConfigurationsHelper.ServiceConfigurationSourceName);
            
             wMessage.AppendLine("Revice el archivo de configuracion en la seccion Fwk.Bases.Properties.Settings el ");
             wMessage.AppendLine("valor de [ServiceConfigurationSourceName].-");


            TechnicalException te = new TechnicalException(wMessage.ToString());

            te.Source ="Despachador de servicios";
            te.ErrorId = "7004";
            te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
            te.Class = typeof(XmlServiceConfigurationManager).Name;
            te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
            throw te;

        }


        

        /// <summary>
        /// 
        /// </summary>
        private void SaveServiceConfigFile()
        {
            String xml = SerializationFunctions.SerializeToXml(_Services);
            //TODO: Ver errores de permisos de archivo
            HelperFunctions.FileFunctions.SaveTextFile(GetXMLRepositoryPath(), xml,false);
        
        }
		#endregion




     

        
    }
}
