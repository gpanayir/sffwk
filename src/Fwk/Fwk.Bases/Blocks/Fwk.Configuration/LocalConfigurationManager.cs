using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.Configuration.Common;
using Fwk.Bases.Properties;
using Fwk.HelperFunctions;
using Fwk.ConfigSection;
using Fwk.Exceptions;

namespace Fwk.Configuration
{    
    /// <summary>
    /// Clase que permite obtener informacion de un archivo de configuracion ubicado localmente donde la aplicacion
    /// esta corriendo sin nececidad de configurar y tener disponible los servicios de configuracion :
    /// <Configuration Provider (Win Service que hostea la clase remota ConfigurationHolder<see cref="ConfigurationHolder"/>)
    /// Configuration Service (Web Service)
    /// <remarks>
    /// Es necesario para que funcione la configuracion local tener en la aplicacion cliente un archivo de configuracion valido en disco
    /// y en la ruta donde esta corriendo la aplicacion. 
    /// </remarks>
    /// </summary>
    /// <Author>Marcelo Oviedo</Author>
    class LocalFileConfigurationManager
    {
        static ConfigurationRepository _Repository;

        static LocalFileConfigurationManager()
        {
            if (_Repository == null)
            {
                _Repository = new ConfigurationRepository();
            }
        }



        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="pConfigProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetProperty(string pConfigProvider, string pGroupName, string pPropertyName)
        {
            string wBaseConfigFile = String.Empty;


            if (string.IsNullOrEmpty(pConfigProvider))
                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName();
            else
                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName(pConfigProvider);


            //string strProperty = _ConfigHolder.GetProperty(wBaseConfigFile, pGroupName, pPropertyName); // antes


            ConfigurationFile wConfigurationFile = GetConfig(wBaseConfigFile);

            if (!wConfigurationFile.BaseConfigFile)
            {
                TechnicalException te = new TechnicalException("El archivo solicitado no es un archivo de configuración válido.");
                te.ErrorId = "8005";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", wBaseConfigFile }));
                te.ErrorId = "8006";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }
            Key wKey = wGroup.Keys.GetFirstByName(pPropertyName);
            if (wKey == null)
            {
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra la propiedad ", pPropertyName, " en el grupo de propiedades: ", pGroupName, " del archivo de configuración: ", wBaseConfigFile }));
                te.ErrorId = "8007";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

            return wKey.Value.Text;

        }


        /// <summary>
        /// Obtiene un ConfigurationFile <see cref="ConfigurationFile" atravez de su nombre/>
        /// </summary>
        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static ConfigurationFile GetConfigurationFile(string pFileName)
        {
            
            string wFileContent = string.Empty;
            bool wIsNewFile = false;

            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(pFileName);

            if (wConfigurationFile == null)
            {
                wConfigurationFile = new ConfigurationFile();
                wIsNewFile = true;
            }

            //Si se opto por configuracion local no es necesario chequear el stado
            if (wConfigurationFile.CheckFileStatus() != Helper.FileStatus.Ok)
            {
                SetConfigurationFile(out wConfigurationFile, pFileName);

                if (wIsNewFile)
                {
                    wConfigurationFile.FileName = pFileName;
                    _Repository.AddConfigurationFile(wConfigurationFile);
                }
            }


            return wConfigurationFile;
        }

       

        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pConfigProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName"></param>
        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static Group GetGroup(string pConfigProvider, string pGroupName)
        {

            string wBaseConfigFile = string.Empty;

            if (string.IsNullOrEmpty(pConfigProvider))
                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName();
            else
                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName(pConfigProvider);

     
            ConfigurationFile wConfigurationFile = GetConfig(wBaseConfigFile);

            if (!wConfigurationFile.BaseConfigFile)
            {
                TechnicalException te = new TechnicalException("El archivo solicitado no es un archivo de configuración válido.");
                te.ErrorId = "8005";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {
          
 
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", wBaseConfigFile }));
                te.ErrorId = "8006";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }


            return wGroup;
        }


        internal static void RemoveConfigManager(string pFileName)
        {

            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(pFileName);
            _Repository.RemoveConfigurationFile(wConfigurationFile);

        }

        internal static bool ExistConfigurationFile(string pFileName)
        {
            return _Repository.ExistConfigurationFile(pFileName);

        }

        #region [Private members]

        /// <summary>
        /// Devuelve el contenido completo de un archivo de configuración
        /// dado el nombre de archivo.
        /// </summary>
        /// <param name="pFileName">Nombre de archivo</param>
        /// <returns>ConfigurationFile</returns>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetConfig(string pFileName)
        {

            string wFileContent = string.Empty;
            bool wIsNewFile = false;



            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(pFileName);

            if (wConfigurationFile == null)
            {
                wConfigurationFile = new ConfigurationFile();
                wIsNewFile = true;
            }

            //Si se opto por configuracion local no es necesario chequear el stado
            //if (wConfigurationFile.CheckFileStatus() != Helper.FileStatus.Ok)
            //{
                SetConfigurationFile(out wConfigurationFile, pFileName);

                if (wIsNewFile)
                {
                    wConfigurationFile.FileName = pFileName;
                    _Repository.AddConfigurationFile(wConfigurationFile);
                }
            //}


            return wConfigurationFile;

        }

        /// <summary>
        /// Agrega nuevamente los gupos al ConfigurationFile
        /// </summary>
        /// <param name="pConfigurationFile">Objeto a configurar.</param>
        /// <param name="pFileName">Nombre de archivo.</param>
        /// <Author>Marcelo Oviedo</Author>
        static void SetConfigurationFile(out ConfigurationFile pConfigurationFile, string pFileName)
        {

            string wFullFileName;
            if (System.IO.File.Exists(pFileName))
            {
                wFullFileName = pFileName;
            }
            else
            {
               
                //Application.StartupPath
                wFullFileName = System.IO.Path.Combine(System.Reflection.Assembly.GetExecutingAssembly().Location, pFileName);
            }

            pConfigurationFile = Common.Helper.GetConfig(wFullFileName, null);

        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="key"></param>
        /// <param name="groupName"></param>
        internal static void AddProperty(ConfigProviderElement provider, Key key, string groupName)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile);
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);
            wGroup.Keys.Add(key);

            try
            {

                FileFunctions.SaveTextFile(provider.BaseConfigFile, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {

                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <param name="group"></param>
        internal static void AddGroup(ConfigProviderElement provider, Group group)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile);
            wConfigurationFile.Groups.Add(group);

            try
            {
                FileFunctions.SaveTextFile(provider.BaseConfigFile, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {
                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }

        }

        internal static void RemoveProperty(ConfigProviderElement provider, string groupName, string propertyName)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile);
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);
            Key k = wGroup.Keys.GetFirstByName(propertyName);
            wGroup.Keys.Remove(k);

            try
            {
                FileFunctions.SaveTextFile(provider.BaseConfigFile, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {
                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;

            }
        }

        internal static void RemoveGroup(ConfigProviderElement provider, string groupName)
        {
            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.BaseConfigFile);
           Group g = wConfigurationFile.Groups.GetFirstByName(groupName);

            wConfigurationFile.Groups.Remove(g);

            try
            {
                FileFunctions.SaveTextFile(provider.BaseConfigFile, wConfigurationFile.GetXml(), false);
            }
            catch (System.UnauthorizedAccessException)
            {
                TechnicalException te = new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
                te.ErrorId = "8008";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }
        }
    }

    

}
