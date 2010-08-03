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
        /// <param name="pConfigProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad a obtener</param>
        /// <returns>String con la propiedad</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static string GetProperty(string pConfigProvider, string pGroupName, string pPropertyName)
        {
            ConfigProviderElement provider = ConfigurationManager.GetProvider(pConfigProvider);


            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile, provider.ApplicationId, provider.CnnStringName);

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
            //return _ConfigHolder.GetConfig(pFileName);
            string wFileContent = string.Empty;
            bool wIsNewFile = false;

            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.BaseConfigFile);

            if (wConfigurationFile == null)
            {
                wConfigurationFile = new ConfigurationFile();
                wIsNewFile = true;
            }

            //Si se opto por configuracion local no es necesario chequear el stado
            if (wConfigurationFile.CheckFileStatus() != Helper.FileStatus.Ok)
            {
                wConfigurationFile = GetConfig(provider.BaseConfigFile, provider.ApplicationId, provider.BaseConfigFile);

                if (wIsNewFile)
                {
                    wConfigurationFile.FileName = provider.BaseConfigFile;
                    _Repository.AddConfigurationFile(wConfigurationFile);
                }
            }


            return wConfigurationFile;
        }


        /// <summary>
        /// Obtiene un grupo determinado en el archivo de configuracion
        /// </summary>
        /// <param name="pConfigProvider">Proveedor de configuuracion</param>
        /// <param name="pGroupName">Nombre del grupo</param>
        /// <returns>Hashtable con los grupos contenidos en el archivo de configuracion</returns>
        /// <Author>Marcelo Oviedo</Author>
        internal static Group GetGroup(string pConfigProvider, string pGroupName)
        {
            ConfigProviderElement provider = ConfigurationManager.GetProvider(pConfigProvider);

            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile, provider.ApplicationId, provider.CnnStringName);

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
        /// <param name="pFileName">Nombre de archivo</param>
        /// <param name="pAppId">Identificador de aplicacion si se espesifica</param>
        /// <param name="pCnnStringName">Nombre de cadena de coneccion.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetConfig(string pFileName, string pAppId, string pCnnStringName)
        {

            string wFileContent = string.Empty;



            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(pFileName);

            if (wConfigurationFile == null)
            {
                wConfigurationFile = GetFromDatabase(pFileName, pAppId, pCnnStringName);
                _Repository.AddConfigurationFile(wConfigurationFile);

            }


            return wConfigurationFile;

        }

        /// <summary>
        /// Busca en la base de datos el archivo de configuracion
        /// </summary>
        /// <param name="pFileName">Nombre de archivo.</param>
        /// <param name="pAppId">Identificador de aplicacion si se espesifica</param>
        /// <param name="pCnnStringName">Nombre de cadena de coneccion.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetFromDatabase(string pFileName, string pAppId, string pCnnStringName)
        {

            ConfigurationFile wConfigurationFile = new ConfigurationFile ();
            wConfigurationFile.Groups = new Groups();
            string groupAuxiliar = string.Empty;
            Group g = null;
            Key k = null;
            wConfigurationFile.FileName = pFileName;

            try
            {
                using (fwk_ConfigMannagerDataContext dc = new fwk_ConfigMannagerDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pCnnStringName].ConnectionString))
                {

                    IEnumerable<fwk_ConfigMannager> fwk_ConfigMannagerList = from s in dc.fwk_ConfigMannagers
                                                                             where s.ConfigurationFileName.Equals(pFileName)
                                                                             && (String.IsNullOrEmpty(pAppId) || s.ConfigurationFileName.Equals(pAppId))


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
                te.ErrorId = "9200";
                throw te;
            }

            return wConfigurationFile;
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
            Set_INSERT();
            System.Text.StringBuilder sqlCommand = new StringBuilder();

            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.BaseConfigFile);
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);
            wGroup.Keys.Add(key);

            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(provider.CnnStringName);


                sqlCommand.Append(_INSERT);
                sqlCommand.Replace("$key$", key.Name);
                sqlCommand.Replace("$encrypted$", key.Encrypted.ToString());
                sqlCommand.Replace("$value$", key.Value.Text);

                sqlCommand.Replace("$ConfigurationFileName$", provider.BaseConfigFile);
                sqlCommand.Replace("$AppId$", provider.ApplicationId);
                sqlCommand.Replace("$group$", wGroup.Name);
                wCmd = wDataBase.GetSqlStringCommand(sqlCommand.ToString());
                wCmd.CommandType = CommandType.Text;

                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "9200";
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

            

            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile, provider.ApplicationId, provider.CnnStringName);

            if (!wConfigurationFile.BaseConfigFile)
            {
                ///TODO: manejo de exepcion de configuracion
                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
            }
            wConfigurationFile.Groups.Add(group);

            Set_INSERT();
            System.Text.StringBuilder sqlCommand = new StringBuilder();


            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(provider.CnnStringName);


                foreach (Key k in group.Keys)
                {
                    sqlCommand.Append(_INSERT);
                    sqlCommand.Replace("$key$", k.Name);
                    sqlCommand.Replace("$encrypted$", k.Encrypted.ToString());
                    sqlCommand.Replace("$value$", k.Value.Text);
                }
                sqlCommand.Replace("$ConfigurationFileName$", provider.BaseConfigFile);
                sqlCommand.Replace("$AppId$", provider.ApplicationId);
                sqlCommand.Replace("$group$", group.Name);
                wCmd = wDataBase.GetSqlStringCommand(sqlCommand.ToString());
                wCmd.CommandType = CommandType.Text;

                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException("Problemas con Fwk.Configuration al realizar operaciones con la base de datos \r\n", ex);
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "9200";
                throw te;
            }
        }

        static string _INSERT;
        static string Set_INSERT()
        {

            if (string.IsNullOrEmpty(_INSERT))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(1000);

                sb.Append(@"	INSERT INTO [fwk_ConfigMannager]");
                sb.Append(@"    ([ConfigurationFileName]");
                sb.Append(@"     ,[AppId]");
                sb.Append(@"     ,[group]");
                sb.Append(@"     ,[key]");
                sb.Append(@"    ,[encrypted]");
                sb.Append(@"    ,[value])");


                sb.Append(@"	VALUES (");

                sb.Append(@"		'$ConfigurationFileName$',");
                sb.Append(@"		'$AppId$',");
                sb.Append(@"		'$group$',");
                sb.Append(@"		'$key$',");
                sb.Append(@"		'$encrypted$',");
                sb.Append(@"		'$value$')");



                _INSERT = sb.ToString();
            }

            return _INSERT;


        }

        internal static void RemoveProperty(ConfigProviderElement provider,  string groupName, string propertyName)
        {
            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.BaseConfigFile);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);

            wConfigurationFile.Groups.Remove(g);
            System.Text.StringBuilder sqlCommand = new StringBuilder("Delete from [fwk_ConfigMannager] where ");
            sqlCommand.AppendLine(string.Concat("ConfigurationFileName = '", provider.BaseConfigFile,"'"));
            sqlCommand.AppendLine(string.Concat("and [group] = '", groupName,"'"));
            sqlCommand.AppendLine(string.Concat("and [key] = '", propertyName, "'"));
            if (!String.IsNullOrEmpty( provider.ApplicationId))
                sqlCommand.AppendLine(string.Concat("and AppId = '", provider.ApplicationId, "'"));
            

            EexeSqlCommand(sqlCommand.ToString(), provider.CnnStringName);
        }

        internal static void RemoveGroup(ConfigProviderElement provider, string groupName)
        {

            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.BaseConfigFile);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);

            wConfigurationFile.Groups.Remove(g);



            System.Text.StringBuilder sqlCommand = new StringBuilder("Delete from [fwk_ConfigMannager] where ");
            sqlCommand.AppendLine(string.Concat("ConfigurationFileName = '", provider.BaseConfigFile, "'"));
            sqlCommand.AppendLine(string.Concat("and [group] = '", groupName, "'"));

            if (!String.IsNullOrEmpty(provider.ApplicationId))
                sqlCommand.AppendLine(string.Concat("and AppId = '", provider.ApplicationId, "'"));

            EexeSqlCommand(sqlCommand.ToString(), provider.CnnStringName);
        }


        static void EexeSqlCommand(string sqlCommand, string cnnStringName)
        {
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
                te.ErrorId = "9200";
                throw te;
            }

        }
    }
}
