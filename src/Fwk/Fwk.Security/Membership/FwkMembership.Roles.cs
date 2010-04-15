using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Fwk.Security.Common;
using System.Web.Security;

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
                foreach (string s in Roles.GetAllRoles())
                {
                    r = new Rol(s);
                    wRoleList.Add(r);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wRoleList;

        }

        /// <summary>
        /// Obtiene una lista de Roles (RolList) de un usuario
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>RolList con los roles del usuario</returns>
        public static RolList GetRolesForUser(String pUserName, string providerName)
        {
            Rol r;
            RolList wRoleList = new RolList();
            try
            {
                foreach (string s in Roles.GetRolesForUser(pUserName))
                {
                    r = new Rol(s);
                    wRoleList.Add(r);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wRoleList;

        }

        /// <summary>
        /// Crea un nuevo Rol
        /// </summary>
        /// <param name="pRoleName"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        //public static void CreateRole(String pRoleName)
        //{

        //    CreateRole(pRoleName,string.Empty,Membership.ApplicationName,ConnectionStringName);
        //}

        /// <summary>
        /// Crea un nuevo Rol
        /// </summary>
        /// <param name="pRoleName">Nombre del rol</param>
        /// <param name="pDescription">Descripcion del rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        //public static void CreateRole(String pRoleName, string pDescription, string providerName)
        //{
        //    CreateRole(pRoleName, pDescription, Membership.ApplicationName, ConnectionStringName);
        //}

        /// <summary>
        ///  Crea un nuevo Rol
        /// </summary>
        /// <param name="pRoleName">Nombre del rol</param>
        /// <param name="pDescription">Descripcion del rol</param>
        /// <param name="pApplicationName">Nombre de la aplicaciom</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateRole(String pRoleName, string pDescription, string providerName)
        {
            try
            {
                if (!Roles.RoleExists(pRoleName))
                {
                    Roles.CreateRole(pRoleName);
                    UpdateRole(pRoleName, pDescription, pApplicationName, pConnectionStringName);
                }
                else
                {
                    throw new Exception(string.Format(Fwk.Security.Properties.Resource.RoleExist, pRoleName));

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Elimina un Rol
        /// </summary>
        /// <param name="pRoleName">Nombre del Rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void DeleteRole(String pRoleName, string providerName)
        {
            try
            {
                if (Roles.GetUsersInRole(pRoleName).Length == 0)
                    Roles.DeleteRole(pRoleName);
                else
                    throw new Exception(string.Format(Fwk.Security.Properties.Resource.RoleNotEmpty, pRoleName));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Actualiza un rol
        /// </summary>
        /// <param name="pRoleName">Nombre del rol</param>
        /// <param name="pDescription">Descripcion del rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UpdateRole(String pRoleName, string pDescription, string providerName)
        {


            StringBuilder str = new StringBuilder("UPDATE aspnet_Roles SET  Description = '[Description]' WHERE (LoweredRoleName = LOWER('[RoleName]')) AND(ApplicationId = CONVERT (UNIQUEIDENTIFIER,'[ApplicationId]') )");
            Guid id = GetApplication(pApplicationName, pConnectionStringName);
            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);

                str.Replace("[ApplicationId]", id.ToString());
                str.Replace("[Description]", pDescription);
                str.Replace("[RoleName]", pRoleName);

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;
                wDataBase.ExecuteNonQuery(wCmd);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Asigna usuarios a un determinado rol 
        /// </summary>
        /// <param name="pRolName">Nombre del rol</param>
        /// <param name="pUserList">Lista usuarios</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateUsersToRole(string pRolName, List<User> pUserList, string providerName)
        {

            try
            {
                foreach (User wUser in pUserList)
                {
                    if (!Roles.IsUserInRole(wUser.UserName, pRolName))
                    {
                        Roles.AddUserToRoles(wUser.UserName, new string[] { pRolName });
                    }
                }

            }
            catch (Exception ex)
            {
                //FwkMessageView.Show(ex, "CreateRole", System.Windows.Forms.MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                throw ex;
            }

        }

        #endregion
	}
}
