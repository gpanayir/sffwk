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
using Fwk.Bases.Blocks.Fwk.Configuration;
using Fwk.Bases.Blocks.Fwk.Configuration.config;

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


            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile, provider.SourceInfo);

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


            return  GetConfig(provider.BaseConfigFile,  provider.SourceInfo); ;
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

            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile,  provider.SourceInfo);

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
        /// <param name="pCnnStringName">Nombre de cadena de coneccion.</param>
        /// <returns><see cref="ConfigurationFile"/></returns>
        /// <Author>Marcelo Oviedo</Author>
        static ConfigurationFile GetConfig(string pFileName, string pCnnStringName)
        {

  
            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(pFileName);

            if (wConfigurationFile == null)
            {
                wConfigurationFile = GetFromDatabase(pFileName,  pCnnStringName);
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
        static ConfigurationFile GetFromDatabase(string pFileName,  string pCnnStringName)
        {

            ConfigurationFile wConfigurationFile = new ConfigurationFile ();
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

                using (configdataDataContext dc = new configdataDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pCnnStringName].ConnectionString))
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
            Set_INSERT();
            System.Text.StringBuilder sqlCommand = new StringBuilder();

            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile,  provider.SourceInfo);  //_Repository.GetConfigurationFile(provider.BaseConfigFile);
            Group wGroup = wConfigurationFile.Groups.GetFirstByName(groupName);
            wGroup.Keys.Add(key);

            Database wDataBase = null;
            DbCommand wCmd = null;
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(provider.SourceInfo);


                sqlCommand.Append(_INSERT);
                sqlCommand.Replace("$key$", key.Name);
                sqlCommand.Replace("$encrypted$", key.Encrypted.ToString());
                sqlCommand.Replace("$value$", key.Value.Text);

                sqlCommand.Replace("$ConfigurationFileName$", provider.BaseConfigFile);
                //sqlCommand.Replace("$AppId$", provider.ApplicationId);
                sqlCommand.Replace("$group$", wGroup.Name);
                wCmd = wDataBase.GetSqlStringCommand(sqlCommand.ToString());
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
        /// 
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="group">Grupo</param>
        internal static void AddGroup(ConfigProviderElement provider, Group group)
        {

            

            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile,  provider.SourceInfo);

            if (!wConfigurationFile.BaseConfigFile)
            {
                ///TODO: manejo de exepcion de configuracion
                throw new Exception("El archivo solicitado no es un archivo de configuración válido.");
            }
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }
            wConfigurationFile.Groups.Add(group);

            Set_INSERT();
            System.Text.StringBuilder sqlCommand = new StringBuilder();


            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(provider.SourceInfo);


                foreach (Key k in group.Keys)
                {
                    sqlCommand.Append(_INSERT);
                    sqlCommand.Replace("$key$", k.Name);
                    sqlCommand.Replace("$encrypted$", k.Encrypted.ToString());
                    sqlCommand.Replace("$value$", k.Value.Text);
                }
                sqlCommand.Replace("$ConfigurationFileName$", provider.BaseConfigFile);
                //sqlCommand.Replace("$AppId$", provider.ApplicationId);
                sqlCommand.Replace("$group$", group.Name);
                wCmd = wDataBase.GetSqlStringCommand(sqlCommand.ToString());
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

        static string _INSERT;
        static void Set_INSERT()
        {

            if (string.IsNullOrEmpty(_INSERT))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(1000);

                sb.Append(@"	INSERT INTO [fwk_ConfigMannager]");
                sb.Append(@"    ([ConfigurationFileName]");
                //sb.Append(@"     ,[AppId]");
                sb.Append(@"     ,[group]");
                sb.Append(@"     ,[key]");
                sb.Append(@"    ,[encrypted]");
                sb.Append(@"    ,[value])");


                sb.Append(@"	VALUES (");

                sb.Append(@"		'$ConfigurationFileName$',");
                //sb.Append(@"		'$AppId$',");
                sb.Append(@"		'$group$',");
                sb.Append(@"		'$key$',");
                sb.Append(@"		'$encrypted$',");
                sb.Append(@"		'$value$')");



                _INSERT = sb.ToString();
            }



        }
        static string _UPDATE_GROUP;
        static void Set_UPDATE_GROUP()
        {

            if (string.IsNullOrEmpty(_UPDATE_GROUP))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(1000);

                sb.Append(@"	UPDATE  [fwk_ConfigMannager]");

                sb.Append(@" SET   [group] = '$newgroupname$'");

                sb.Append(@"	WHERE ");

                sb.Append(@"[ConfigurationFileName] =	'$ConfigurationFileName$'");
                //sb.Append(@" AND	[AppId] =	'$AppId$'");
                sb.Append(@" AND	[group] =	'$group$'");





                _UPDATE_GROUP = sb.ToString();
            }

       


        }
        static string _UPDATE_PROP;
        static void Set_UPDATE_PROP()
        {

            if (string.IsNullOrEmpty(_UPDATE_PROP))
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder(1000);

                sb.Append(@"	UPDATE  [fwk_ConfigMannager]");

                
                sb.Append(@" SET    [key] = '$newkeyname$'");
                sb.Append(@"    ,[encrypted]= '$encrypted$'");
                sb.Append(@"    ,[value] = '$value$'");

                sb.Append(@"	WHERE ");

                sb.Append(@" [ConfigurationFileName] =	'$ConfigurationFileName$'");
                //sb.Append(@" AND	[AppId] =	'$AppId$'");
                sb.Append(@" AND	[group] =	'$group$'");
                sb.Append(@" AND	[key] =	    '$key$'");




                _UPDATE_PROP = sb.ToString();
            }



        }

        /// <summary>
        /// Elimina una porpiedad de la cinfuguracion
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Gupo al que pertenece la propiedad</param>
        /// <param name="propertyName">Nombre de la propiedad</param>
        internal static void RemoveProperty(ConfigProviderElement provider,  string groupName, string propertyName)
        {
            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile,  provider.SourceInfo); //_Repository.GetConfigurationFile(provider.BaseConfigFile);
            Group g = wConfigurationFile.Groups.GetFirstByName(groupName);
            Key k = g.Keys.GetFirstByName(propertyName);
            g.Keys.Remove(k);
            System.Text.StringBuilder sqlCommand = new StringBuilder("Delete from [fwk_ConfigMannager] where ");
            sqlCommand.AppendLine(string.Concat("ConfigurationFileName = '", provider.BaseConfigFile,"'"));
            sqlCommand.AppendLine(string.Concat("and [group] = '", groupName,"'"));
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

            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile,  provider.SourceInfo);
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
            Set_UPDATE_GROUP();
            System.Text.StringBuilder sqlCommand = new StringBuilder();

            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile,  provider.SourceInfo);
            

            Database wDataBase = null;
            DbCommand wCmd = null;
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(provider.SourceInfo);


                sqlCommand.Append(_UPDATE_GROUP);
                sqlCommand.Replace("$newgroupname$", newGroupName);
                sqlCommand.Replace("$group$", groupName);
                sqlCommand.Replace("$ConfigurationFileName$", provider.BaseConfigFile);
                //sqlCommand.Replace("$AppId$", provider.ApplicationId);
                
                wCmd = wDataBase.GetSqlStringCommand(sqlCommand.ToString());
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
        /// Realiza cambios a una propiedad.-
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <param name="groupName">Nombre del grupo donde se encuentra la propiedad</param>
        /// <param name="property">Propiedad actualizada. Este objeto puede contener todos sus valores modifcados</param>
        /// <param name="propertyName">Nombre de la propiedad que se mofdifico.- Este valor es el original sin modificacion</param>
        internal static void ChangeProperty(ConfigProviderElement provider,  string groupName,Key property, string propertyName)
        {
            Set_UPDATE_PROP();
            System.Text.StringBuilder sqlCommand = new StringBuilder();

            ConfigurationFile wConfigurationFile = GetConfig(provider.BaseConfigFile,  provider.SourceInfo);


            Database wDataBase = null;
            DbCommand wCmd = null;
            if (System.Configuration.ConfigurationManager.ConnectionStrings[provider.SourceInfo] == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Problemas con Fwk.Configuration, no se puede encontrar la cadena de conexión: ", provider.SourceInfo));
                ExceptionHelper.SetTechnicalException<DatabaseConfigMannager>(te);
                te.ErrorId = "8200";
                throw te;
            }
            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(provider.SourceInfo);


                sqlCommand.Append(_UPDATE_PROP);
                sqlCommand.Replace("$newkeyname$", property.Name);
                sqlCommand.Replace("$key$", propertyName);
                sqlCommand.Replace("$group$", groupName);
                sqlCommand.Replace("$ConfigurationFileName$", provider.BaseConfigFile);
                //sqlCommand.Replace("$AppId$", provider.ApplicationId);
                sqlCommand.Replace("$encrypted$", property.Encrypted.ToString());
                sqlCommand.Replace("$value$", property.Value.Text );


                wCmd = wDataBase.GetSqlStringCommand(sqlCommand.ToString());
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
        /// Vuelve a cargar el archivo de configuracion desde el origen de datos
        /// </summary>
        /// <param name="provider">Proveedor de configuracion</param>
        /// <returns></returns>
        internal static ConfigurationFile RefreshConfigurationFile(ConfigProviderElement provider)
        {
            ConfigurationFile wConfigurationFile = _Repository.GetConfigurationFile(provider.BaseConfigFile);
            if (wConfigurationFile == null)
            {
                TechnicalException te = new TechnicalException(string.Concat("Error al intentar eremover un archivo de configuracion: El archivo ", provider.BaseConfigFile, " no se encuentra"));
                te.ErrorId = "8012";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException(te, typeof(DatabaseConfigMannager));
                throw te;
            }
            _Repository.RemoveConfigurationFile(wConfigurationFile);
            wConfigurationFile = null;
            wConfigurationFile = GetFromDatabase(provider.BaseConfigFile, provider.SourceInfo);
            _Repository.AddConfigurationFile(wConfigurationFile);

            return wConfigurationFile;
        }
    }
}
