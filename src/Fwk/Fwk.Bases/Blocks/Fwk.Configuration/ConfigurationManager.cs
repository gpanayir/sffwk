using System;
using System.Collections;
using Fwk.Configuration.Common;
using Fwk.Bases.Properties;
using Fwk.ConfigSection;
using Fwk.Exceptions;

namespace Fwk.Configuration
{
	/// <summary>
	/// Clase principal que se utiliza para obtener cualquier configuracion tanto local como remota contenida
	/// en los archivos de configuracion.
	/// <remarks>Los parametros necesarios para su correcto funcionamiento son los que se
    /// allan en el App.Config que utilize el ConfigurationManager tales como:
    /// BaseConfigFile
    /// RemotingConfigFile : indica el archivo de configuracion necesario para la configuracion  del servicio remoto.
    /// IsLocal: determina si el ambito de configuracion es atravez del servicio remoto (Configuration Provider) 
    /// o es local (sin servicio alguno)
    /// </remarks>
	/// </summary>
    /// <Author>Marcelo Oviedo</Author>
	public class ConfigurationManager
	{

        static ConfigProviderSection _ConfigProvider;

        /// <summary>
        /// 
        /// </summary>
        public static ConfigProviderSection ConfigProvider
        {
            get { return _ConfigProvider; }
           
        }
        static ConfigProviderElement _DefaultProvider;

        /// <summary>
        /// Proveedor configurado como por defecto
        /// </summary>
        public static ConfigProviderElement DefaultProvider
        {
            get { return _DefaultProvider; }
            
        }

        static ConfigurationManager()
        {
            _ConfigProvider = System.Configuration.ConfigurationManager.GetSection("FwkConfigProvider") as ConfigProviderSection;
            _DefaultProvider = _ConfigProvider.DefaultProvider;

        }

        
        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion Usa proveedor de confuiguraciones establecido por defecto.-
        /// </summary>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static string GetProperty(string pGroupName, string pPropertyName)
        {
            return GetProperty(string.Empty, pGroupName, pPropertyName);
        }

        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="pConfigProvider">Nombre del proveedor de configuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static string GetProperty(string pConfigProvider, string pGroupName, string pPropertyName)
        {



            ConfigProviderElement provider = GetProvider(pConfigProvider);
            if (provider == null) return null;


            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetProperty(pConfigProvider,pGroupName,pPropertyName);
                    }
                case ConfigProviderType.remote:
                    {
                        return RemoteConfigurationManager.GetProperty(pGroupName, pPropertyName);
                    }
                case ConfigProviderType.database:
                    {
                        return DatabaseConfigMannager.GetProperty(pConfigProvider ,pGroupName, pPropertyName);
                    }
                case ConfigProviderType.service:
                    {
                        return null;
                    }
            }
            return null;
        }
      

        /// <summary>
        /// Obtiene un ConfigurationFile <see cref="ConfigurationFile" atravez de su nombre/>
        /// </summary>
        /// <param name="pFileName">Nombre del archivo xml con la configuracion</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        //public static ConfigurationFile GetConfigurationFile(string pFileName)
        //{
        // return   GetConfigurationFromProvider(_DefaultProvider.Name);

        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pConfigProvider">Nombre del proveedor configurado</param>
        /// <returns></returns>
        public static ConfigurationFile GetConfigurationFile(string pConfigProvider)
        {
            ConfigProviderElement provider = GetProvider(pConfigProvider);
            if (provider == null) return null;


            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetConfigurationFile(provider); 
                    }
                case ConfigProviderType.remote:
                    {
                        return RemoteConfigurationManager.GetConfigurationFile(provider.BaseConfigFile); 
                    }
                case ConfigProviderType.database:
                    {
                        return DatabaseConfigMannager.GetConfigurationFile(provider); 
                    }
                case ConfigProviderType.service:
                    {
                        return null;
                        
                    }
            }
            return null;
        }

        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pConfigProvider">Nombre del proveedor de configuracion</param>
        /// <param name="pGroupName">Nombre del grupo a obtener</param>
        /// <returns>Group</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Group GetGroup(string pConfigProvider, string pGroupName)
        {

            ConfigProviderElement provider = GetProvider(pConfigProvider);
            if (provider == null) return null;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetGroup(pConfigProvider, pGroupName);
                    }
                case ConfigProviderType.remote:
                    {
                        ///TODO: Ver esta sobregcarga
                        return RemoteConfigurationManager.GetGroup(pGroupName);
                    }
                case ConfigProviderType.database:
                    {
                        return DatabaseConfigMannager.GetGroup(provider.BaseConfigFile, provider.BaseConfigFile);
                    }
                case ConfigProviderType.service:
                    {
                        return null;
                    }
            }
            return null;
        }

        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pGroupName"></param>
        /// <returns>Group </returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Group GetGroup(string pGroupName)
        {
            return GetGroup(string.Empty, pGroupName);
        }

        #region Operaciones validas solo para configuraciones remotas.-

        /// <summary>
        /// Obtiene la vercion de un archivo de configuracion para determinar el estado en el que se
        /// encuentra
        /// </summary>
        /// <param name="pFileName">Nombre del archivo</param>
        /// <param name="pClientVersion">Version del archivo del lado del cliente</param>
        /// <Author>Marcelo Oviedo</Author>
        public static Helper.FileStatus GetFileVersionStatus(string pFileName, string pClientVersion)
        {

            if (_DefaultProvider.ConfigProviderType == ConfigProviderType.remote)
            {
                return RemoteConfigurationManager.GetFileVersionStatus(pFileName, pClientVersion);
            }
            
            else 
            {
                TechnicalException te = new TechnicalException(string.Concat("Operacion no valida para un proveedor de configuracion del tipo: ", _DefaultProvider.ConfigProviderType.ToString()));
                te.ErrorId = "8100";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }
        }
        #endregion 


        #region Metodos privados
       

        /// <summary>
        /// Metodo que lee el en el App.Config la Key = BaseConfigFile para obtener el nombre del archivo de configuracion
        /// utilizado
        /// </summary>
        /// <returns>String con el nombre del archivo</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetBaseConfigFileName()
        {
            return GetBaseConfigFileName(string.Empty);
        }


        /// <summary>
        /// Metodo que lee el en el App.Config la Key = BaseConfigFile para obtener el nombre del archivo de configuracion
        /// utilizado
        /// </summary>
        /// <param name="pProviderName">Nombre del proveedor de configuracion</param>
        /// <returns>String con el nombre del archivo</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetBaseConfigFileName(string pProviderName)
        {
          
           if (_ConfigProvider.GetProvider(pProviderName).BaseConfigFile == string.Empty)
            {
                TechnicalException te = new TechnicalException(string.Concat("Falta el nombre artchivo de configuracion no espesificado en el proveedor de configuracion ", pProviderName, " . Ver archivo .config de la aplicacion"));
                te.ErrorId = "8010";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;

            }
            
            return _ConfigProvider.GetProvider(pProviderName).BaseConfigFile;

        }
	    #endregion

        /// <summary>
        /// Obtiene uin configuration provider por su nombre
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static ConfigProviderElement GetProvider(string name)
        {
           if (string.IsNullOrEmpty(name))
                return _DefaultProvider;
            else
                return _ConfigProvider.GetProvider(name);
           
        }



        internal static void AddProperty(string pConfigProvider, string groupName,Key key)
        {
            ConfigProviderElement provider = GetProvider(pConfigProvider);
            if (provider == null) return ;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.AddProperty(provider, key, groupName);
                        break;
                    }
                case ConfigProviderType.remote:
                    {
                        RemoteConfigurationManager.AddProperty(provider, key, groupName);
                        break;
                    }
                case ConfigProviderType.database:
                    {
                        DatabaseConfigMannager.AddProperty(provider, key, groupName);
                        break;
                    }
                case ConfigProviderType.service:
                    {
                        return ;
                    }
            }
        }

        internal static void AddGroup(string pConfigProvider, Group group)
        {
            ConfigProviderElement provider = GetProvider(pConfigProvider);
            if (provider == null) return ;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.AddGroup(provider, group); break;
                    }
                case ConfigProviderType.remote:
                    {
                        RemoteConfigurationManager.AddGroup(provider, group); break;
                    }
                case ConfigProviderType.database:
                    {
                        DatabaseConfigMannager.AddGroup(provider, group); break;
                    }
                case ConfigProviderType.service:
                    {
                        return ;
                    }
            }
        }




        internal static void RemoveProperty(string pConfigProvider, string groupName, string propertyName)
        {
            ConfigProviderElement provider = GetProvider(pConfigProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.RemoveProperty(provider, groupName, propertyName); break;
                    }
                case ConfigProviderType.remote:
                    {
                        RemoteConfigurationManager.RemoveProperty(provider, groupName, propertyName); break;
                    }
                case ConfigProviderType.database:
                    {
                        DatabaseConfigMannager.RemoveProperty(provider, groupName, propertyName); break;
                    }
                case ConfigProviderType.service:
                    {
                        return;
                    }
            }
        }

        internal static void RemoveGroup(string pConfigProvider, string groupName)
        {
            ConfigProviderElement provider = GetProvider(pConfigProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.RemoveGroup(provider, groupName); break;
                    }
                case ConfigProviderType.remote:
                    {
                        RemoteConfigurationManager.RemoveGroup(provider, groupName); break;
                    }
                case ConfigProviderType.database:
                    {
                        DatabaseConfigMannager.RemoveGroup(provider, groupName); break;
                    }
                case ConfigProviderType.service:
                    {
                        return;
                    }
            }
        }
    }
    

}
