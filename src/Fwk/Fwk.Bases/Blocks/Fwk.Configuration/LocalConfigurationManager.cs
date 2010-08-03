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
                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
            }

            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {
                throw new Exception(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", wBaseConfigFile }));
            }
            Key wKey = wGroup.Keys.GetFirstByName(pPropertyName);
            if (wKey == null)
            {
                throw new Exception(string.Concat(new String[] { "No se encuentra la propiedad ", pPropertyName, " en el grupo de propiedades: ", pGroupName, " del archivo de configuración: ", wBaseConfigFile }));
            }


            //return wKey.Value.Text;

            //if (strProperty.Length == 0)
            //{
            //    /// no encontró nada, lanza excepcion
            //    throw new Exception("Ocurrió una excepción al buscar una propiedad [" + pPropertyName + "]" +
            //        "La misma NO está configurada en ningún repositorio.");
            //}

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
        /// Devuelve el contenido completo de un archivo de configuración
        /// dado el nombre de archivo.
        /// </summary>
        /// <param name="pFileName">Nombre de archivo</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        //public static ConfigurationFile GetConfig_WhihoutAppSetting(string pFileName)
        //{

        //    string wFileContent = string.Empty;
        //    bool wIsNewFile = false;

        //    ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(pFileName);


        //    if (wConfigurationFile == null)
        //    {
        //        wConfigurationFile = new ConfigurationFile();
        //        wIsNewFile = true;
        //    }


        //    SetConfigurationFile(out wConfigurationFile, pFileName);
        //    if (wIsNewFile)
        //    {
        //        wConfigurationFile.FileName = pFileName;
        //        _Repository.AddConfigurationFile(wConfigurationFile);
        //    }



        //    return wConfigurationFile;

        //}
        

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
                ///TODO: manejo de exepcion de configuracion
                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
            }

            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {
                ///TODO: manejo de exepcion de configuracion
                throw new Exception(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", wBaseConfigFile }));
            }


            if (wGroup == null)
            {
                ///TODO: manejo de exepcion de configuracion
                throw new Exception(
                    "El grupo '" + pGroupName + "'. no se encuentra " +
                    "configurado en ninguno de los repositorios. " +
                    "Archivo: '" + wBaseConfigFile + "'.");
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
                ///TODO: ver Ex
                throw new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));

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
            {///TODO: ver Ex
                throw new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));
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
                ///TODO: ver Ex
                throw new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));

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
            {///TODO: ver Ex
                throw new TechnicalException(string.Concat("No tiene permiso para actualizar el archivo ", provider.BaseConfigFile));

            }
        }
    }

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
//    class LocalConfigurationManager2
//    {
//        private static LocalFileHolder _ConfigHolder = null;

//        static LocalConfigurationManager2()
//        {
//            CreateConfigurationHolder();
//        }
//        /// <summary>
//        /// Obtiene una propiedad determinada de un archivo de configuracion .-
//        /// </summary>
//        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
//        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
//        /// <returns>String con la propiedad</returns>
//        /// <Author>Marcelo Oviedo</Author>
//        internal static string GetProperty(string pGroupName, string pPropertyName)
//        {

//            return GetProperty(String.Empty, pGroupName, pPropertyName);

//        }

//        /// <summary>
//        /// Obtiene una propiedad determinada de un archivo de configuracion .-
//        /// </summary>
//        /// <param name="pConfigProvider">Proveedor de configuuracion</param>
//        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
//        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
//        /// <returns>String con la propiedad</returns>
//        /// <Author>Marcelo Oviedo</Author>
//        internal static string GetProperty(string pConfigProvider, string pGroupName, string pPropertyName)
//        {
//            string wBaseConfigFile = String.Empty;


//            if (string.IsNullOrEmpty(pConfigProvider))
//                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName();
//            else
//                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName(pConfigProvider);


//            string strProperty = _ConfigHolder.GetProperty(wBaseConfigFile, pGroupName, pPropertyName);


//            if (strProperty.Length == 0)
//            {
//                /// no encontró nada, lanza excepcion
//                throw new Exception("Ocurrió una excepción al buscar una propiedad [" + pPropertyName + "]" +
//                    "La misma NO está configurada en ningún repositorio.");
//            }

//            return strProperty;

//        }


//        /// <summary>
//        /// Obtiene un ConfigurationFile <see cref="ConfigurationFile" atravez de su nombre/>
//        /// </summary>
//        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
//        /// <returns><see cref="ConfigurationFile"/></returns>
//        /// <Author>Marcelo Oviedo</Author>
//        internal static ConfigurationFile GetConfigurationFile(string pFileName)
//        {
//            return _ConfigHolder.GetConfig(pFileName);
//        }



//        /// <summary>
//        /// Obtiene un grupo determinado en el archivo de configuracion
//        /// </summary>
//        /// <param name="pGroupName"></param>
//        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
//        /// <Author>Marcelo Oviedo</Author>
//        internal static Group GetGroup(string pGroupName)
//        {
//            return GetGroup(string.Empty, pGroupName);

//        }
//        /// <summary>
//        /// Obtiene un grupo determinado en el archivo de configuracion
//        /// </summary>
//        /// <param name="pConfigProvider">Proveedor de configuuracion</param>
//        /// <param name="pGroupName"></param>
//        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
//        /// <Author>Marcelo Oviedo</Author>
//        internal static Group GetGroup(string pConfigProvider, string pGroupName)
//        {

//            string wBaseConfigFile = string.Empty;

//            if (string.IsNullOrEmpty(pConfigProvider))
//                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName();
//            else
//                wBaseConfigFile = ConfigurationManager.GetBaseConfigFileName(pConfigProvider);

//            Group wGroup = _ConfigHolder.GetGroup(wBaseConfigFile, pGroupName);

//            if (wGroup == null)
//            {
//                throw new Exception(
//                    "El grupo '" + pGroupName + "'. no se encuentra " +
//                    "configurado en ninguno de los repositorios. " +
//                    "Archivo: '" + wBaseConfigFile + "'.");
//            }

//            return wGroup;
//        }


//        #region [Private members]


//        /// <summary>
//        /// Operacion que retorna una instancia de la clase <see cref="LocalHolder"/> 
//        /// utilizando un patron Singlenton
//        /// </summary>
//        /// <returns><see cref="LocalHolder"/> </returns>
//        /// <Author>Marcelo Oviedo</Author>
//        private static void CreateConfigurationHolder()
//        {
//            if (_ConfigHolder == null)
//            {
//                _ConfigHolder = new LocalFileHolder();
//            }

//        }
//        #endregion
//    }


//    /// <summary>
//    /// Esta clase tiene la funcionalidad del ConfigurationHolder <see cref="ConfigurationHolder"/> clase remoeable que esta hosteada en el servicio de windows Configuration Provider
//    /// por otro lado y al mismo tiempo realiza las tareas que soportan los web metodos del servicio web Configuration Service.
//    /// Estas tareas se agrupan en la clase LocalHolder para que todo lo que concierna a configuracion sea llevado acabo localmente y 
//    /// no alla nececidad de servicios adicionales.-
//    /// </summary>
//    /// <Author>Marcelo Oviedo</Author>
//    class LocalFileHolder
//    {
//        private FileConfigurationRepository _FileConfigurationRepository;

//        public LocalFileHolder()
//        {
//            if (_FileConfigurationRepository == null)
//            {
//                _FileConfigurationRepository = new FileConfigurationRepository();
//            }
//        }



//        /// <summary>
//        /// Devuelve una propidedad de un grupo de un BaseConfigFile
//        /// </summary>
//        /// <param name="pBaseConfigFileName">Nombre de archivo</param>
//        /// <param name="pGroupName">Nombre de grupo</param>
//        /// <param name="pPropertyName">Nombre de propiedad</param>
//        /// <returns>string</returns>
//        public string GetProperty(string pBaseConfigFileName, string pGroupName, string pPropertyName)
//        {
//            ConfigurationFile wConfigurationFile = this.GetConfig(pBaseConfigFileName);

//            if (!wConfigurationFile.BaseConfigFile)
//            {
//                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
//            }

//            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
//            if (wGroup == null)
//            {
//                throw new Exception(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", pBaseConfigFileName }));
//            }
//            Key wKey = wGroup.Keys.GetFirstByName(pPropertyName);
//            if (wKey == null)
//            {
//                throw new Exception(string.Concat(new String[] { "No se encuentra la propiedad ", pPropertyName, " en el grupo de propiedades: ", pGroupName, " del archivo de configuración: ", pBaseConfigFileName }));
//            }


//            return wKey.Value.Text;

//        }

//        /// <summary>
//        /// Devuelve el contenido completo de un archivo de configuración
//        /// dado el nombre de archivo.
//        /// </summary>
//        /// <param name="pFileName">Nombre de archivo</param>
//        /// <returns>ConfigurationFile</returns>
//        /// <Author>Marcelo Oviedo</Author>
//        public ConfigurationFile GetConfig(string pFileName)
//        {

//            string wFileContent = string.Empty;
//            bool wIsNewFile = false;



//            ConfigurationFile wConfigurationFile = _FileConfigurationRepository.GetConfigurationFile(pFileName);

//            if (wConfigurationFile == null)
//            {
//                wConfigurationFile = new ConfigurationFile();
//                wIsNewFile = true;
//            }

//            //Si se opto por configuracion local no es necesario chequear el stado
//            if (wConfigurationFile.CheckFileStatus() != Helper.FileStatus.Ok)
//            {
//                this.SetConfigurationFile(out wConfigurationFile, pFileName);

//                if (wIsNewFile)
//                {
//                    wConfigurationFile.FileName = pFileName;
//                    _FileConfigurationRepository.AddConfigurationFile(wConfigurationFile);
//                }
//            }


//            return wConfigurationFile;

//        }

//        /// <summary>
//        /// Devuelve el contenido completo de un archivo de configuración
//        /// dado el nombre de archivo.
//        /// </summary>
//        /// <param name="pFileName">Nombre de archivo</param>
//        /// <returns>ConfigurationFile</returns>
//        /// <Author>Marcelo Oviedo</Author>
//        public ConfigurationFile GetConfig_WhihoutAppSetting(string pFileName)
//        {

//            string wFileContent = string.Empty;
//            bool wIsNewFile = false;



//            ConfigurationFile wConfigurationFile = _FileConfigurationRepository.GetConfigurationFile(pFileName);

//            if (wConfigurationFile == null)
//            {
//                wConfigurationFile = new ConfigurationFile();
//                wIsNewFile = true;
//            }


//            this.SetConfigurationFile(out wConfigurationFile, pFileName);

//            if (wIsNewFile)
//            {
//                wConfigurationFile.FileName = pFileName;
//                _FileConfigurationRepository.AddConfigurationFile(wConfigurationFile);
//            }



//            return wConfigurationFile;

//        }


//        /// <summary>
//        /// Devuelve un grupo de un BaseConfigFile
//        /// </summary>
//        /// <param name="pBaseConfigFileName">Nombre del archivo</param>
//        /// <param name="pGroupName">Nombre del grupo</param>
//        /// <returns>Group</returns>
//        public Group GetGroup(string pBaseConfigFileName, string pGroupName)
//        {

//            ConfigurationFile wConfigurationFile = this.GetConfig(pBaseConfigFileName);

//            if (!wConfigurationFile.BaseConfigFile)
//            {
//                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
//            }

//            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
//            if (wGroup == null)
//            {
//                throw new Exception(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", pBaseConfigFileName }));
//            }
//            return wGroup;
//        }





//        /// <summary>
//        /// Agrega nuevamente los gupos al ConfigurationFile
//        /// </summary>
//        /// <param name="pConfigurationFile">Objeto a configurar.</param>
//        /// <param name="pFileName">Nombre de archivo.</param>
//        /// <Author>Marcelo Oviedo</Author>
//        public void SetConfigurationFile(out ConfigurationFile pConfigurationFile, string pFileName)
//        {

//            string wFullFileName;
//            if (System.IO.File.Exists(pFileName))
//            {
//                wFullFileName = pFileName;
//            }
//            else
//            {
//                //Application.StartupPath
//                wFullFileName = System.IO.Path.Combine(Environment.CurrentDirectory, pFileName);
//            }

//            pConfigurationFile = Common.Helper.GetConfig(wFullFileName, null);



//        }


//        public void RemoveConfigManager(string pFileName)
//        {

//            ConfigurationFile wConfigurationFile = _FileConfigurationRepository.GetConfigurationFile(pFileName);
//            _FileConfigurationRepository.RemoveConfigurationFile(wConfigurationFile);

//        }
//        public bool ExistConfigurationFile(string pFileName)
//        {
//            return _FileConfigurationRepository.ExistConfigurationFile(pFileName);

//        }
//    }
}
