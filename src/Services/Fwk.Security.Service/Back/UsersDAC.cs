
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Prominente Code Generator.
//     Runtime Version:1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using Fwk.Bases;
using Fwk.Security.BE;
using Fwk.Exceptions;
using Fwk.Security;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;
using System.Configuration;
//using Unassigned = Fwk.Security.ISVC.GetUnassignedUsersByParam;
using System.Web.Security;
using Fwk.Security.Common;

namespace Fwk.Security.DAC
{
    /// <summary>
    /// Clase DAC para Usuarios.
    /// </summary>
    /// <Date>2008-12-03T14:54</Date>
    /// <Author>FWK</Author>
    public class UsersDAC : Fwk.Bases.BaseDAC
    {
        #region [Alta, Baja, Modificación]

        public static void Create(User pUser, List<SqlParameter> pCustomParametersToInsert,
                                  String pProviderName, String pCustomUserTable)
        {
            String wConnectionString = FwkMembership.GetProvider_ConnectionStringName(pProviderName);

            // Se inserta en la Tabla Custom
            // El usuario custom debe tomar de la tabla membership el GUID para su usuario.
            using (SqlConnection wCnn = new SqlConnection(wConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pCustomUserTable + "_i", wCnn))
            {
                try
                {
                    wCmd.CommandType = CommandType.StoredProcedure;

                    if (pCustomParametersToInsert != null)
                    {
                        if (pCustomParametersToInsert.Count != 0)
                        {
                            wCmd.Parameters.AddRange(pCustomParametersToInsert.ToArray());

                            wCnn.Open();
                            wCmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
                }
            }
        }

        public static void Update(User pUserBE, List<SqlParameter> pCustomParametersToUpdate,
                                  String pProviderName, String pCustomUserTable)
        {
            String wConnectionString = FwkMembership.GetProvider_ConnectionStringName(pProviderName);

            // Se actualiza en la Tabla Custom
            
            using (SqlConnection wCnn = new SqlConnection(wConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pCustomUserTable + "_u", wCnn))
            {
                try
                {
                    wCmd.CommandType = CommandType.StoredProcedure;

                    if (pCustomParametersToUpdate != null)
                    {
                        if (pCustomParametersToUpdate.Count != 0)
                        {
                            wCmd.Parameters.AddRange(pCustomParametersToUpdate.ToArray());

                            wCnn.Open();
                            wCmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
                }
            }
        }

        /// <summary>
        /// Elimina un usuario segun los parametros customizados
        /// </summary>
        /// <param name="pUserBE">Usuario a eliminar</param>
        /// <param name="pCustomParameters">Parametros custoizados por los que se borrara al usuario de la tabla custom</param>
        /// <param name="pProviderName">Nombre del provider</param>
        /// <param name="pCustomUserTable">Nombre de la tabla customizada</param>
        public static void Delete(User pUserBE, List<SqlParameter> pCustomParameters,
                                  String pProviderName, String pCustomUserTable)
        {
            String wConnectionString = FwkMembership.GetProvider_ConnectionStringName(pProviderName);
                       
            
            using (SqlConnection wCnn = new SqlConnection(wConnectionString))
            using (SqlCommand wCmd = new SqlCommand(pCustomUserTable + "_d", wCnn))
            {
                try
                {
                    wCmd.CommandType = CommandType.StoredProcedure;

                    if (pCustomParameters != null)
                    {
                        if (pCustomParameters.Count != 0)
                        {
                            wCmd.Parameters.AddRange(pCustomParameters.ToArray());

                            wCnn.Open();
                            wCmd.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
                }
            }
        }

        #endregion

        #region [Search]
      
        /// <summary>
        /// Metodo para Search
        /// </summary>
        /// <param name="pUsersBE"></param>
        /// <param name="pProviderName"></param>
        /// <param name="pCustomParameters"></param>
        /// <param name="pCustomUserStoreProcedure"></param>
        /// <returns></returns>
        public static DataSet SearchByParams(String pProviderName,
                                             List<SqlParameter> pCustomParameters, String pCustomUserStoreProcedure)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;
            DataSet wDSResult = null;

            try
            {
                String wConnectionString = FwkMembership.GetProvider_ConnectionStringName(pProviderName);

                wDatabase = DatabaseFactory.CreateDatabase(wConnectionString);
                wCmd = wDatabase.GetStoredProcCommand(pCustomUserStoreProcedure);
                wCmd.Parameters.AddRange(pCustomParameters.ToArray());

                wDSResult = wDatabase.ExecuteDataSet(wCmd);

                return wDSResult;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }
        
        #endregion

        #region [GET]

        /// <summary>
        /// Obtiene un usuario segun los parametros
        /// </summary>
        /// <param name="pProviderName">Nombre del proveedor de seguridad</param>
        /// <param name="pCustomParameters"></param>
        /// <param name="pCustomUserStoreProcedure"></param>
        /// <returns></returns>
        public static DataSet GetUser(String pProviderName,List<SqlParameter> pCustomParameters, String pCustomUserStoreProcedure)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;
            DataSet wDSResult = null;
            String wConnectionString = String.Empty;

            try
            {
                wConnectionString = FwkMembership.GetProvider_ConnectionStringName(pProviderName);

                wDatabase = DatabaseFactory.CreateDatabase(wConnectionString);
                wCmd = wDatabase.GetStoredProcCommand(pCustomUserStoreProcedure);
                wCmd.Parameters.AddRange(pCustomParameters.ToArray());

                wDSResult = wDatabase.ExecuteDataSet(wCmd);

                                
                return wDSResult;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios Custom
        /// </summary>
        /// <param name="pProviderName">Nombre del proveedor de seguridad</param>
        /// <param name="pCustomUserStoreProcedure">Nombre del Store procedure que se debe ejecutar</param>
        /// <returns></returns>
        public static DataSet GetAllUsers(String pProviderName,String pCustomUserStoreProcedure)
        {
            Database wDatabase = null;
            DbCommand wCmd = null;
            DataSet wDSResult = null;
            String wConnectionString = String.Empty;

            try
            {
                wConnectionString = FwkMembership.GetProvider_ConnectionStringName(pProviderName);

                wDatabase = DatabaseFactory.CreateDatabase(wConnectionString);
                wCmd = wDatabase.GetStoredProcCommand(pCustomUserStoreProcedure);                

                wDSResult = wDatabase.ExecuteDataSet(wCmd);
                
                return wDSResult;
            }
            catch (Exception ex)
            {
                throw Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }
        }

        #endregion
    }
}