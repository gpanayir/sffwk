using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.HelperFunctions;
using Fwk.Transaction;
using Fwk.Xml;
//using Fwk.ServiceManagement.Xml;
using Fwk.Bases;
using Fwk.Exceptions;

namespace Fwk.ServiceManagement
{
    /// <summary>
    /// Manejador de configuración de servicios que trabaja con un archivo XML como repositorio de configuración.
    /// </summary>
    /// <date>2008-04-07T00:00:00</date>
    /// <author>moviedo</author>
    public sealed class XmlServiceConfigurationManager
    {
        //static ServiceConfigurationCollection _Services;

        //string _XmlConfigFile = String.Empty;

        /// <summary>
        /// Constructor que no busca en el .config. Carga todos los servicios directamente del archivo pasado por parametros
        /// </summary>
        /// <param name="xmlConfigFile">archivo de servicios</param>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        //public XmlServiceConfigurationManager(string xmlConfigFile)
        //{

        //    _XmlConfigFile = xmlConfigFile;

        //    LoadAllServices(_XmlConfigFile);
        //}

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        //public XmlServiceConfigurationManager()
        //{

        //}



        #region < IServiceConfiguration Members >


        /// <summary>
        /// Devuelve la configuración de un servicio buscándolo en el repositorio XML.
        /// </summary>
        /// <param name="pServiceName">Nombre del servicio</param>
        /// <returns>configuración del servicio</returns>
        /// <date>2008-04-07T00:00:00</date>
        /// <author>moviedo</author>
        //public static ServiceConfiguration GetServiceConfiguration(string pServiceName)
        //{
        //    ServiceConfiguration wResult;

        //    if (!_Services.Contains(pServiceName))
        //    {
        //        Exceptions.TechnicalException te = new Exceptions.TechnicalException("El servicio " + pServiceName + " no se encuentra configurado.");
        //        te.Source = "Despachador de servicios";
        //        te.ErrorId = "7002";
        //        te.Assembly = typeof(XmlServiceConfigurationManager).AssemblyQualifiedName;
        //        te.Class = typeof(XmlServiceConfigurationManager).Name;
        //        te.Namespace = typeof(XmlServiceConfigurationManager).Namespace;
        //        throw te;
        //    }

        //    wResult = _Services[pServiceName];

        //    return wResult;

        //}

        /// <summary>
        /// Busca el archivo BPConfig y lo carga a _Services que es un ServiceConfigurationCollection
        /// </summary>
        /// <returns></returns>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        internal static ServiceConfigurationCollection GetAllServices(string xmlConfigFile)
        {

            return LoadAllServices(xmlConfigFile);

        }

        /// <summary>
        /// Busca el archivo  lo carga a _Services que es un ServiceConfigurationCollection
        /// </summary>
        ///<param name="xmlConfigFile"></param>
        ///<param name="refresh">Indica si se vuelven a cargar los archivos</param>
        /// <returns></returns>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        static ServiceConfigurationCollection LoadAllServices(string xmlConfigFile)
        {

            try
            {
                
                String xml = FileFunctions.OpenTextFile(xmlConfigFile);
                return (ServiceConfigurationCollection)SerializationFunctions.DeserializeFromXml(typeof(ServiceConfigurationCollection), xml);

            }
            catch (System.IO.IOException ioex)
            {


                string wMessage = string.Concat(
                "Error al inicializar la metadata de los servicios  \r\n",
                "Verifique: \r\n ",
                "Archivo de .config en la seccion FwkServiceMetadata el ", Environment.NewLine,
                "valor de [sourceinfo],  que la ruta y archivo de metadata sea correcta");


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
                string strError = string.Concat("Error al inicializar la metadata de los servicios  \r\n ",
                "Metadata :", xmlConfigFile, Environment.NewLine);

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
        internal static void SetServiceConfiguration(string xmlConfigFile, ServiceConfigurationCollection services)
        {

            SaveServiceConfigFile(xmlConfigFile, services);
          
        }

        /// <summary>
        /// Almacena la configuración de un nuevo servicio de negocio.
        /// </summary>
        /// <param name="pServiceConfiguration">configuración del servicio de negocio.</param>
        /// <date>2007-07-13T00:00:00</date>
        /// <author>moviedo</author>
        internal static void AddServiceConfiguration(ServiceConfiguration pServiceConfiguration, string xmlConfigFile, ServiceConfigurationCollection services)
        {

            
            SaveServiceConfigFile(xmlConfigFile, services);
           
        }

        /// <summary>
        /// Elimina la configuración de un servicio de negocio.
        /// </summary>
        /// <param name="xmlConfigFile">Nombre del archivo que contiene la metadata.</param>
        /// <param name="services">Repositorio de servicios enmemoria.</param>
        /// <date>2010-08-11T00:00:00</date>
        /// <author>moviedo</author>
        internal static void DeleteServiceConfiguration(string xmlConfigFile, ServiceConfigurationCollection services)
        {
            SaveServiceConfigFile(xmlConfigFile, services);
        }

        #endregion

        #region < Private methods >





        /// <summary>
        /// Guarda los cambios en el archivo
        /// </summary>
        /// <param name="xmlConfigFile">Nombre del archivo que contiene la metadata.</param>
        /// <param name="services">Repositorio de servicios enmemoria.</param>
        static void SaveServiceConfigFile(string xmlConfigFile, ServiceConfigurationCollection services)
        {
            String xml = SerializationFunctions.SerializeToXml(services);
            try
            {
                HelperFunctions.FileFunctions.SaveTextFile(xmlConfigFile, xml, false);
            }

            catch (System.UnauthorizedAccessException)
            {

                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", xmlConfigFile));
                te.ErrorId = "7100";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<XmlServiceConfigurationManager>(te);
                throw te;
            }

        }
        #endregion







    }
}
