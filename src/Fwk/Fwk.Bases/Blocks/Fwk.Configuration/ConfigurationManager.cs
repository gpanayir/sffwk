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
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static string GetProperty(string configProvider, string pGroupName, string pPropertyName)
        {



            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;


            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetProperty(configProvider,pGroupName,pPropertyName);
                    }
             
                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigMannager.GetProperty(configProvider ,pGroupName, pPropertyName);
                    }
                case ConfigProviderType.servicewrapper:
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
        /// <param name="configProvider">Nombre del proveedor configurado</param>
        /// <returns></returns>
        public static ConfigurationFile GetConfigurationFile(string configProvider)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;


            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetConfigurationFile(provider); 
                    }
                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigMannager.GetConfigurationFile(provider); 
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return null;
                        
                    }
            }
            return null;
        }

        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="pGroupName">Nombre del grupo a obtener</param>
        /// <returns>Group</returns>
        /// <Author>Marcelo Oviedo</Author>
        public static Group GetGroup(string configProvider, string pGroupName)
        {

            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.GetGroup(configProvider, pGroupName);
                    }
              
                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigMannager.GetGroup(provider.BaseConfigFile, provider.BaseConfigFile);
                    }
                case ConfigProviderType.servicewrapper:
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
        //public static Helper.FileStatus GetFileVersionStatus(string pFileName, string pClientVersion)
        //{

        //    if (_DefaultProvider.ConfigProviderType == ConfigProviderType.remote)
        //    {
        //        return RemoteConfigurationManager.GetFileVersionStatus(pFileName, pClientVersion);
        //    }
            
        //    else 
        //    {
        //        TechnicalException te = new TechnicalException(string.Concat("Operacion no valida para un proveedor de configuracion del tipo: ", _DefaultProvider.ConfigProviderType.ToString()));
        //        te.ErrorId = "8100";
        //        Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
        //        throw te;
        //    }
        //}
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
        /// <param name="providerName">Nombre del proveedor de configuracion</param>
        /// <returns></returns>
        internal static ConfigProviderElement GetProvider(string providerName)
        {
           if (string.IsNullOrEmpty(providerName))
                return _DefaultProvider;
            else
                return _ConfigProvider.GetProvider(providerName);
           
        }


        /// <summary>
        /// Crea una propiedad en un grupo determinado
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        /// <param name="key"></param>
        internal static void AddProperty(string configProvider, string groupName,Key key)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return ;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.AddProperty(provider, key, groupName);
                        break;
                    }
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigMannager.AddProperty(provider, key, groupName);
                        break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return ;
                    }
            }
        }

        /// <summary>
        /// Agrega un grupo al archivo de configuracion.-
        /// Si el grupo existe se retorna una TecnicalExeption 
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="group">Objeto tipo Grupo que se agregara</param>
        internal static void AddGroup(string configProvider, Group group)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return ;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.AddGroup(provider, group); break;
                    }
               
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigMannager.AddGroup(provider, group); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return ;
                    }
            }
        }



        /// <summary>
        /// Elimina una propiedad u objeto key
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        /// <param name="propertyName">Nombre de la propiedad o key.name</param>
        internal static void RemoveProperty(string configProvider, string groupName, string propertyName)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.RemoveProperty(provider, groupName, propertyName); break;
                    }

                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigMannager.RemoveProperty(provider, groupName, propertyName); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return;
                    }
            }
        }

        /// <summary>
        /// Elimina un grupo
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        internal static void RemoveGroup(string configProvider, string groupName)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.RemoveGroup(provider, groupName); break;
                    }
            
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigMannager.RemoveGroup(provider, groupName); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return;
                    }
            }
        }

        /// <summary>
        /// Cançmbia el nombre de un grupo
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        /// <param name="newGroupName"></param>
        internal static void ChangeGroupName(string configProvider, string groupName, string newGroupName)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.ChangeGroupName(provider, groupName, newGroupName); break;
                    }
             
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigMannager.ChangeGroupName(provider, groupName,newGroupName); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return;
                    }
            }
        }

        /// <summary>
        /// Realiza cambios a una propiedad.-
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="property">Propiedad actualizada. Este objeto puede contener todos sus valores modifcados</param>
        /// <param name="propertyName">Nombre de la propiedad que se mofdifico.- Este valor es el original sin modificacion</param>
        internal static void ChangeProperty(string configProvider, string groupName, Key property, string propertyName)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        LocalFileConfigurationManager.ChangeProperty(provider, groupName, property, propertyName); break;
                    }
               
                case ConfigProviderType.sqldatabase:
                    {
                        DatabaseConfigMannager.ChangeProperty(provider, groupName, property, propertyName); break;
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return;
                    }
            }
        }


        /// <summary>
        /// Vuelve a cargar el archivo de configuracion desde el origen de datos
        /// </summary>
        /// <param name="configProvider">Nombre del proveedor configurado</param>
        /// <returns></returns>
        public static ConfigurationFile RefreshConfigurationFile(string configProvider)
        {
            ConfigProviderElement provider = GetProvider(configProvider);
            if (provider == null) return null;
            switch (provider.ConfigProviderType)
            {
                case ConfigProviderType.local:
                    {
                        return LocalFileConfigurationManager.RefreshConfigurationFile(provider); 
                    }
                case ConfigProviderType.sqldatabase:
                    {
                        return DatabaseConfigMannager.RefreshConfigurationFile(provider); 
                    }
                case ConfigProviderType.servicewrapper:
                    {
                        return null;
                    }
            }
            return null;
        }
    }
    

}
