using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Fwk.Security.Common;
using System.Web.Security;
using Fwk.Exceptions;

namespace Fwk.Security
{
    public partial class FwkMembership
    {

        #region [Roles]

        /// <summary>
        /// Obtiene todos los Roles
        /// The GetAllRoles method calls the RoleProvider.GetAllRoles method of the default role provider to get a list of all the roles from the data source for an application. 
        /// Only the roles for the application that is specified in the ApplicationName property are retrieved.
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>RolList con todos los roles</returns>
        public static RolList GetAllRoles(string providerName)
        {
            Rol r;
            RolList wRoleList = new RolList();

            try
            {
                foreach (string s in Roles.Providers[providerName].GetAllRoles())
                {
                    r = new Rol(s);
                    wRoleList.Add(r);
                }

            }
            catch (System.NullReferenceException)
            {
                TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.RuleProvider_NotExist, providerName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

            return wRoleList;

        }

        /// <summary>
        /// Obtiene una lista de Roles (RolList) de un usuario
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>RolList con los roles del usuario</returns>
        public static RolList GetRolesForUser(String userName, string providerName)
        {
            Rol r;
            RolList wRoleList = new RolList();
            try
            {
                foreach (string s in Roles.Providers[providerName].GetRolesForUser(userName))
                {
                    r = new Rol(s);
                    wRoleList.Add(r);
                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

            return wRoleList;

        }


        /// <summary>
        ///  Crea un nuevo Rol
        /// </summary>
        /// <param name="roleName">Nombre del rol</param>
        /// <param name="description">Descripcion del rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateRole(String roleName, string description, string providerName)
        {
            try
            {
                if (!Roles.RoleExists(roleName))
                {
                    Roles.Providers[providerName].CreateRole(roleName);
                    UpdateRole(roleName, description, providerName);
                }
                else
                {
                    throw new Exception(string.Format(Fwk.Security.Properties.Resource.RoleExist, roleName));

                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Elimina un Rol.- Lanza exepcion si el rol tiene miembros asociados
        /// </summary>
        /// <param name="roleName">Nombre del Rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void DeleteRole(String roleName, string providerName)
        {
            try
            {

                if (Roles.Providers[providerName].GetUsersInRole(roleName).Length == 0)
                    Roles.Providers[providerName].DeleteRole(roleName, true);
                else
                {
                    TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.RoleNotEmpty, roleName));
                    ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                    te.ErrorId = "4006";
                    throw te;

                }
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Actualiza un rol
        /// </summary>
        /// <param name="roleName">Nombre del rol</param>
        /// <param name="description">Descripcion del rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UpdateRole(String roleName, string description, string providerName)
        {

            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            StringBuilder str = new StringBuilder("UPDATE aspnet_Roles SET  Description = '[Description]' WHERE (LoweredRoleName = LOWER('[RoleName]')) AND(ApplicationId = CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]') )");
            Guid id = GetApplication(wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {

                wDataBase = DatabaseFactory.CreateDatabase(GetProvider_ConnectionStringName(providerName));

                str.Replace("[ApplicationId]", id.ToString());
                str.Replace("[Description]", description);
                str.Replace("[RoleName]", roleName);

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;
                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Asigna usuarios a un determinado rol 
        /// </summary>
        /// <param name="rolName">Nombre del rol</param>
        /// <param name="userList">Lista usuarios</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateUsersToRole(string rolName, List<User> userList, string providerName)
        {

            try
            {
                ///var users = from s in userList select s.UserName;
                foreach (User wUser in userList)
                {
                    if (!Roles.Providers[providerName].IsUserInRole(wUser.UserName, rolName))
                    {
                        Roles.Providers[providerName].AddUsersToRoles(new string[] { wUser.UserName }, new string[] { rolName });
                    }
                }

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }

        }

        #endregion
    }
}
