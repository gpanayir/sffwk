using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Fwk.Configuration.Common;
using Fwk.Bases.Properties;
using Fwk.HelperFunctions;
using Fwk.Configuration;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using Fwk.ConfigSection;
using Fwk.Exceptions;

using Fwk.ConfigData;

namespace Fwk.Configuration
{
    /// <summary>
    /// Configuration mannager con origen en base de datos SQL Server.-
    /// </summary>
    class DatabaseConfigMannager
    {
        static ConfigurationRepository _Repository;


        static DatabaseConfigMannager()
        {
            if (_Repository == null)
            {
                _Repository = new ConfigurationRepository();
            }
        }



        /// <summary>
        /// Obtiene una propiedad determinada de un archivo de configuracion .-
        /// </summary>
        /// <param name="configProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetProperty(string configProvider, string pGroupName, string pPropertyName)
        {
            ConfigProviderElement provider = ConfigurationManager.GetProvider(configProvider);

            ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo);

            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {

                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", provider.BaseConfigFile }));
                te.ErrorId = "8006";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }
            Key wKey = wGroup.Keys.GetFirstByName(pPropertyName);
            if (wKey == null)
            {
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra la propiedad ", pPropertyName, " en el grupo de propiedades: ", pGroupName, " del archivo de configuración: ", provider.BaseConfigFile }));
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
        /// <param name="pCnnStringName">Nombre de cadena de coneccion.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static ConfigurationFile GetConfigurationFile(ConfigProviderElement provider)
        {


            return GetConfig(provider, provider.SourceInfo); ;
        }


        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="configProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName">Nombre del grupo</param>
        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static Group GetGroup(string configProvider, string pGroupName)
        {
            ConfigProviderElement provider = ConfigurationManager.GetProvider(configProvider);

            ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo);



            Group wGroup = wConfigurationFile.Groups.GetFirstByName(pGroupName);
            if (wGroup == null)
            {
                TechnicalException te = new TechnicalException(string.Concat(new String[] { "No se encuentra el grupo ", pGroupName, " en el archivo de configuración: ", provider.BaseConfigFile }));
                te.ErrorId = "8006";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(ConfigurationManager));
                throw te;
            }




            return wGroup;
        }


        #region [Private members]




        /// <summary>
        /// Devuelve el contenido completo de un archivo de configuración
        /// dado el nombre de archivo.
        /// </summary>
        /// <param name="provider">Nombre de archivo</param>
        /// <param name="pCnnStringName">Nombre de cadena de coneccion.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetConfig(ConfigProviderElement provider, string pCnnStringName)
        {


            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.Name);

            if (wConfigurationFile == null)
            {
                wConfigurationFile = GetFromDatabase(provider.BaseConfigFile, pCnnStringName);
                wConfigurationFile.ProviderName = provider.Name;
                _Repository.AddConfigurationFile(wConfigurationFile);

            }


            return wConfigurationFile;

        }

        /// <summary>
        /// Busca en la base de datos el archivo de configuracion
        /// </summary>
        /// <param name="pFileName">Nombre de archivo.</param>
        /// <param name="pCnnStringName">Nombre de cadena de coneccion.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetFromDatabase(string pFileName, string pCnnStringName)
        {

            ConfigurationFile wConfigurationFile = new ConfigurationFile();
            wConfigurationFile.Groups = new Groups();
            string groupAuxiliar = string.Empty;
            Group g = null;
            Key k = null;
            wConfigurationFile.FileName = pFileName;

            if (System.Configuration.ConfigurationManager.ConnectionStrings[pCnnStringName] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", pCnnStringName));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }
            try
            {

                using (FwkDatacontext dc = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[pCnnStringName].ConnectionString))
                {

                    IEnumerable<fwk_ConfigMannager> fwk_ConfigMannagerList = from s in dc.fwk_ConfigMannagers
                                                                             where s.ConfigurationFileName.Equals(pFileName)

                                                                             select s;



                    foreach (fwk_ConfigMannager fwk_Config in fwk_ConfigMannagerList.OrderBy(p => p.group))
                    {
                        if (!groupAuxiliar.Equals(fwk_Config.group))
                        {
                            groupAuxiliar = Convert.ToString(fwk_Config.group);
                            g = new Group();
                            g.Name = groupAuxiliar;
                            wConfigurationFile.Groups.Add(g);
                        }

                        k = new Key();
                        k.Encrypted = Convert.ToBoolean(fwk_Config.encrypted);
                        k.Name = Convert.ToString(fwk_Config.key);
                        k.Value.Text = Convert.ToString(fwk_Config.value);


                        g.Keys.Add(k);
                    }

                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }

            return wConfigurationFile;
        }


        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="key"></param>
        /// <param name="groupName">Nombre del gruop que contiene las propiedades</param>
        internal static void AddProperty(ConfigProviderElement provider, Key key, string groupName)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }
            System.Text.StringBuilder sqlCommand = new StringBuilder();

            ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo);  //_Repository.GetConfigurationFile(provider.BaseConfigFile);
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);
            wGroup.Keys.Add(key);



            fwk_ConfigMannager confg;
            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo].ConnectionString))
                {

                    confg = new fwk_ConfigMannager();
                    confg.ConfigurationFileName = provider.BaseConfigFile;
                    confg.key = key.Name;
                    confg.encrypted = key.Encrypted;
                    confg.value = key.Value.Text;
                    confg.group = groupName;

                    dc.fwk_ConfigMannagers.InsertOnSubmit(confg);


                    dc.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="group">Grupo</param>
        internal static void AddGroup(ConfigProviderElement provider, Group group)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }
            ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo);


            wConfigurationFile.Groups.Add(group);
            fwk_ConfigMannager confg;

            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo].ConnectionString))
                {
                    foreach (Key k in group.Keys)
                    {
                        confg = new fwk_ConfigMannager();
                        confg.ConfigurationFileName = provider.BaseConfigFile;
                        confg.key = k.Name;
                        confg.encrypted = k.Encrypted;
                        confg.value = k.Value.Text;
                        confg.group = group.Name;
                        dc.fwk_ConfigMannagers.InsertOnSubmit(confg);

                    }
                    dc.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }
        }



        /// <summary>
        /// Elimina una porpiedad de la cinfuguracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Gupo al que pertenece la propiedad</param>
        /// <param name="propertyName">Nombre de la propiedad</param>
        internal static void RemoveProperty(ConfigProviderElement provider, string groupName, string propertyName)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo); //_Repository.GetConfigurationFile(provider.BaseConfigFile);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);
            Key k = g.Keys.GetFirstByName(propertyName);
            g.Keys.Remove(k);
            System.Text.StringBuilder sqlCommand = new StringBuilder("Delete from [fwk_ConfigMannager] where ");
            sqlCommand.AppendLine(string.Concat("ConfigurationFileName = '", provider.BaseConfigFile, "'"));
            sqlCommand.AppendLine(string.Concat("and [group] = '", groupName, "'"));
            sqlCommand.AppendLine(string.Concat("and [key] = '", propertyName, "'"));
            //if (!String.IsNullOrEmpty( provider.ApplicationId))
            //    sqlCommand.AppendLine(string.Concat("and AppId = '", provider.ApplicationId, "'"));


            EexeSqlCommand(sqlCommand.ToString(), provider.SourceInfo);
        }

        /// <summary>
        /// Elimina un grupo de la configuracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo a eliminar</param>
        internal static void RemoveGroup(ConfigProviderElement provider, string groupName)
        {

            ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);

            wConfigurationFile.Groups.Remove(g);



            System.Text.StringBuilder sqlCommand = new StringBuilder("Delete from [fwk_ConfigMannager] where ");
            sqlCommand.AppendLine(string.Concat("ConfigurationFileName = '", provider.BaseConfigFile, "'"));
            sqlCommand.AppendLine(string.Concat("and [group] = '", groupName, "'"));

            //if (!String.IsNullOrEmpty(provider.ApplicationId))
            //    sqlCommand.AppendLine(string.Concat("and AppId = '", provider.ApplicationId, "'"));

            EexeSqlCommand(sqlCommand.ToString(), provider.SourceInfo);
        }


        static void EexeSqlCommand(string sqlCommand, string cnnStringName)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", cnnStringName));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }

            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(cnnStringName);


                wCmd = wDataBase.GetSqlStringCommand(sqlCommand);
                wCmd.CommandType = CommandType.Text;

                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }

        }

        /// <summary>
        /// Cambia el nombre de un grupo.-
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo</param>
        /// <param name="newGroupName">Nuevo nombre del grupo</param>
        internal static void ChangeGroupName(ConfigProviderElement provider, string groupName, string newGroupName)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }

            ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo);



            try
            {

                using (FwkDatacontext dc = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo].ConnectionString))
                {


                    var configs = dc.fwk_ConfigMannagers.Where(p =>
                          p.group.Equals(groupName)
                          && p.ConfigurationFileName.Equals(provider.BaseConfigFile));

                    foreach (fwk_ConfigMannager confg in configs)
                    {
                        confg.group = newGroupName;
                    }
                    dc.SubmitChanges();
                }


            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;

            }
        }

        /// <summary>
        /// Realiza cambios a una propiedad.-
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="property">Propiedad actualizada. Este objeto puede contener todos sus valores modifcados</param>
        /// <param name="propertyName">Nombre de la propiedad que se mofdifico.- Este valor es el original sin modificacion</param>
        internal static void ChangeProperty(ConfigProviderElement provider, string groupName, Key property, string propertyName)
        {
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }

            ConfigurationFile wConfigurationFile = GetConfig(provider, provider.SourceInfo);


            try
            {
                using (FwkDatacontext dc = new FwkDatacontext(System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo].ConnectionString))
                {

                    var prop = dc.fwk_ConfigMannagers.Where(p =>

                            p.key.Equals(propertyName, StringComparison.OrdinalIgnoreCase)
                            && p.group.Equals(groupName, StringComparison.OrdinalIgnoreCase)
                          && p.ConfigurationFileName.Equals(provider.BaseConfigFile, StringComparison.OrdinalIgnoreCase)).FirstOrDefault<fwk_ConfigMannager>();

                    prop.value = property.Value.Text;
                    prop.encrypted = property.Encrypted;
                    prop.key = property.Name;
                    dc.SubmitChanges();
                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;

            }
        }


        /// <summary>
        /// Vuelve a cargar el archivo de configuracion desde el origen de datos
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <returns></returns>
        internal static ConfigurationFile RefreshConfigurationFile(ConfigProviderElement provider)
        {
            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.Name);
            if (wConfigurationFile != null)
            {
                _Repository.RemoveConfigurationFile(wConfigurationFile);
                wConfigurationFile = null;
            }

            wConfigurationFile = GetFromDatabase(provider.BaseConfigFile, provider.SourceInfo);
            _Repository.AddConfigurationFile(wConfigurationFile);

            return wConfigurationFile;
        }
    }
}
