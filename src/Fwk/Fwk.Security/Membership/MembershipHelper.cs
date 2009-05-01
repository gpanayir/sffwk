﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Security.Principal;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Caching;
using System.Windows.Forms;
using System.Web.Security;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;

namespace Fwk.Security
{
    public class FwkMembership
    {
        static FwkActyveDirectory _FwkActyveDirectory;

        static FwkActyveDirectory GetActiveDirectoriInstance(string pDomainName)
        {
            if (_FwkActyveDirectory == null)
            {
                _FwkActyveDirectory = new FwkActyveDirectory(pDomainName);
            }
            return _FwkActyveDirectory;

        }
       
        public static string ConnectionStringName;

        #region [Users]

        public static Boolean ValidateUser(string pUsername, string pPassword,string pDomainName)
        {
            Boolean wIsUserAuthenticated = false;
            _FwkActyveDirectory = GetActiveDirectoriInstance(pDomainName);
            if (_FwkActyveDirectory.ValidateUser(pUsername, pPassword)) // Chequea primero contra el dominio
            {
                wIsUserAuthenticated = Membership.ValidateUser(pUsername, pPassword); // Chequea luego con la base de datos local
            }

            return wIsUserAuthenticated;
        }

        public static Boolean ValidateUser(string pUsername, string pPassword )
        {
            return  Membership.ValidateUser(pUsername, pPassword);
        }

        /// <summary>
        /// Crea un usuario
        /// </summary>
        /// <param name="pUsername"></param>
        /// <param name="pPassword"></param>
        public static void CreateUser(string pUsername, string pPassword, string pEmail)
        {
            FwkIdentity wFwkIdentity = new FwkIdentity();

            try
            {
        
                //MembershipCreateStatus wStatus = MembershipCreateStatus.UserRejected;
                System.Web.Security.Membership.CreateUser(pUsername, pPassword, pEmail);

                
            }
            catch (Exception ex)
            {
                //FwkMessageView.Show(ex, "CreateUser", System.Windows.Forms.MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                throw ex;
            }
        }

        /// <summary>
        /// Elimina un usuario de la Base de Datos
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        public static void DeleteUser(String pUserName)
        {
            try
            {
                Membership.DeleteUser(pUserName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene una lista de usuarios
        /// </summary>
        /// <returns></returns>
        public static List<User> GetAllUsers()
        {
            User wUserByApp;
            List<User> wUsersList = new List<User>();
            try
            {
                
                foreach (MembershipUser wMembershipUser in Membership.GetAllUsers())
                {
                    wUserByApp = new User(wMembershipUser);
                    wUsersList.Add(wUserByApp);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wUsersList;

        }

        /// <summary>
        /// Obtiene un usuario
        /// </summary>
        /// <param name="pUserName">Nombre del Usuario que se desea obtener</param>
        /// <returns>User</returns>
        public static User GetUser(String pUserName)
        {
            MembershipUser wUser = Membership.GetUser(pUserName);

            return new User(wUser);
        }

        /// <summary>
        /// Bloquea un Usuario
        /// </summary>
        /// <param name="pUserName">Nombre del usuario que se desea bloquear</param>
        public static void LockUser(String pUserName)
        {
            MembershipUser wUser = Membership.GetUser(pUserName);

            // block the user
            if (wUser != null)
            {
                wUser.IsApproved = false;
                Membership.UpdateUser(wUser);
            }
                       
        }

        /// <summary>
        /// Desbloquea un usuario
        /// </summary>
        /// <param name="pUserName">Nombre del usuario a desbloquear</param>
        public static void UnLockUser(String pUserName)
        {

            MembershipUser wUser = Membership.GetUser(pUserName);

            // block the user
            if (wUser != null)
            {
                wUser.IsApproved = true;
                Membership.UpdateUser(wUser);
            }
        }
               
        /// <summary>
        /// Resetea el Password de un usuario
        /// </summary>
        /// <param name="pUserName">Nombre del Usuario</param>
        /// <returns>Password auto generado</returns>
        public static String ResetUserPassword(String pUserName)
        {
            String wNewPassword;

            MembershipUser wUser = Membership.GetUser(pUserName);
            // block the user
            if (wUser != null)
                wNewPassword = wUser.ResetPassword();
            else
                wNewPassword = String.Empty;

            return wNewPassword;
        }

        /// <summary>
        /// Cambia el password de un usuario
        /// </summary>
        /// <param name="pUserName">Nombre del Usuario</param>
        /// <param name="pOldPassword">Password Viejo</param>
        /// <param name="pNewPassword">Password Nuevo</param>
        /// <returns>Bool indicando el resultado de la operación</returns>
        public static Boolean ChangeUserPassword(String pUserName, String pOldPassword, String pNewPassword)
        {
            MembershipUser wUser = Membership.GetUser(pUserName);

            return wUser.ChangePassword(pOldPassword, pNewPassword);

        }
        
        /// <summary>
        /// Obtiene una lista de usuarios en un determinado rol
        /// </summary>
        /// <param name="pRoleName"></param>
        /// <returns></returns>
        public static List<User> GetUsersInRole(String pRoleName)
        {

            User wUserByApp;
            List<User> wUsersList = new List<User>();
            try
            {
                foreach (string s in Roles.GetUsersInRole(pRoleName))
                {
                    wUserByApp = new User(s);
                    wUsersList.Add(wUserByApp);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return wUsersList;

        }
        
        /// <summary>
        /// Asigna roles a un usuario
        /// </summary>
        /// <param name="pRolList">Lista de roles</param>
        /// <param name="pUserName">Usuario</param>
        public static void CreateRolesToUser(RolList pRolList, String pUserName)
        {
          
            try
            {
                foreach (Rol rol in pRolList)
                {
                    if (!Roles.IsUserInRole(pUserName,rol.RolName))
                    {
                        Roles.AddUserToRoles(pUserName ,new string[] { rol.RolName });                     
                    }
                }

            }
            catch (Exception ex)
            {
                //FwkMessageView.Show(ex, "CreateRole", System.Windows.Forms.MessageBoxButtons.OK, Fwk.Bases.FrontEnd.Controls.MessageBoxIcon.Error);
                throw ex;
            }
          
        }

        /// <summary>
        /// Quita a un usuario de un rol
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        /// <param name="pRoleName">Nombre de Rol</param>
        public static void RemoveUserFromRole(String pUserName, String pRoleName)
        {
            try
            {
                if(!String.IsNullOrEmpty(pRoleName))
                    Roles.RemoveUserFromRole(pUserName, pRoleName);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }        
        }

        /// <summary>
        /// Quita a un usuario de una lista de Roles
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        /// <param name="pRolList">Lista de Nombres de Roles</param>
        public static void RemoveUserFromRoles(String pUserName, RolList pRolList)
        {
            try
            {
                foreach (Rol rol in pRolList)
                {
                    if (!Roles.IsUserInRole(pUserName, rol.RolName))
                        Roles.RemoveUserFromRoles(pUserName, new string[] { rol.RolName });
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Quita un array de usuarios de un Rol
        /// </summary>
        /// <param name="pUsersName">Array de usuario</param>
        /// <param name="pRoleName">Nombre del Rol</param>
        public static void RemoveUsersFromRole(String[] pUsersName, String pRoleName)
        {
            try
            {
                Roles.RemoveUsersFromRole(pUsersName, pRoleName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Quita una array de Usuarios de una lista de Roles
        /// </summary>
        /// <param name="pUsersName">Array de Nombres</param>
        /// <param name="pRolList">Lista de Roles</param>
        public static void RemoveUsersFromRoles(String[] pUsersName, RolList pRolList)
        {
            try
            {
                Roles.RemoveUsersFromRoles(pUsersName, pRolList.GetArrayNames());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

      
                

        #endregion

        #region [Roles]

        /// <summary>
        /// Obtiene todos los Roles
        /// </summary>
        /// <returns>RolList con todos los roles</returns>
        public static RolList GetAllRoles()
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
        /// <returns>RolList con los roles del usuario</returns>
        public static RolList GetRolesForUser(String pUserName)
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
        /// <param name="pRoleName">Nombre del Rol</param>
        public static void CreateRole(String pRoleName)
        {
            try
            {
                if (!Roles.RoleExists(pRoleName))
                {
                    Roles.CreateRole(pRoleName);
                   
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
        public static void DeleteRole(String pRoleName)
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

        #endregion

        #region [Rules]

        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// </summary>
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        /// <returns></returns>
        public static NamedElementCollection<AuthorizationRuleData> GetRules(string pApplicationName)
        {
            return GetRules(pApplicationName, ConnectionStringName);
        }

        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// </summary>
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        /// <returns></returns>
        static NamedElementCollection<AuthorizationRuleData> GetRules( string pApplicationName,string pConnectionStringName)
        {

            Database wDataBase = null;
            DbCommand wCmd = null;
            AuthorizationRuleData rule = null;
            NamedElementCollection<AuthorizationRuleData> wRules = null;
            try
            {

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                wCmd = wDataBase.GetStoredProcCommand("aspnet_Rules_s");

                wDataBase.AddInParameter(wCmd, "ApplicationName", System.Data.DbType.String, pApplicationName);

                IDataReader reader = wDataBase.ExecuteReader(wCmd);
                wRules = new NamedElementCollection<AuthorizationRuleData>();
                while (reader.Read())
                {
                    rule = new AuthorizationRuleData();
                    rule.Name = reader["Name"].ToString().Trim();
                    rule.Expression = reader["Expression"].ToString();
                    wRules.Add(rule);
                }

                return wRules;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static List<AuthorizationRuleData> GetRulesList(string pApplicationName)
        {
            return GetRulesList(pApplicationName, ConnectionStringName);
        }

        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static List<AuthorizationRuleData> GetRulesList(string pApplicationName, string pConnectionStringName)
        {

            Database wDataBase = null;
            DbCommand wCmd = null;
            AuthorizationRuleData rule = null;
            List<AuthorizationRuleData> wRules = null;
            try
            {

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                wCmd = wDataBase.GetStoredProcCommand("aspnet_Rules_s");

                wDataBase.AddInParameter(wCmd, "ApplicationName", System.Data.DbType.String, pApplicationName);

                IDataReader reader = wDataBase.ExecuteReader(wCmd);
                wRules = new List<AuthorizationRuleData>();
                while (reader.Read())
                {
                    rule = new AuthorizationRuleData();
                    rule.Name = reader["Name"].ToString().Trim();
                    rule.Expression = reader["Expression"].ToString();
                    wRules.Add(rule);
                }

                return wRules;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Determina si existe una regla.-
        /// </summary>
        /// <param name="pName">Nombre de la regla</param>
        /// <param name="pConnectionStringName">Nombre de la regla</param>
        /// <returns>boolean</returns>
        public static bool ExistRule(string pRuleName, string pApplicationName, string pConnectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                wCmd = wDataBase.GetStoredProcCommand("aspnet_Rules_g_Exist");

                wDataBase.AddInParameter(wCmd, "name", System.Data.DbType.String, pRuleName);
                wDataBase.AddInParameter(wCmd, "ApplicationName", System.Data.DbType.String, pApplicationName);

                wDataBase.AddOutParameter(wCmd, "exist", System.Data.DbType.Boolean,1);

                wDataBase.ExecuteNonQuery(wCmd);


                return (bool)wDataBase.GetParameterValue(wCmd, "exist"); ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Determina si existe una regla.-
        /// </summary>
        /// <param name="pName">Nombre de la regla</param>
        /// <param name="pConnectionStringName">Nombre de la regla</param>
        /// <returns>boolean</returns>
        public static bool ExistRule(string pRuleName, string pApplicationName)
        {
            return ExistRule(pRuleName, pApplicationName, FwkMembership.ConnectionStringName);
        }

        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="paspnet_Rules">aspnet_Rules</param>
        /// <returns>void</returns>
        /// <Date>2008-12-22T11:29:57</Date>
        /// <Author>moviedo</Author>
        public static void CreateRules(FwkAuthorizationRule paspnet_Rules, string pApplicationId)
        {
            CreateRules(paspnet_Rules, pApplicationId, FwkMembership.ConnectionStringName);
        }

        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="paspnet_Rules">aspnet_Rules</param>
        /// <returns>void</returns>
        /// <Date>2008-12-22T11:29:57</Date>
        /// <Author>moviedo</Author>
        public static void CreateRules(FwkAuthorizationRule paspnet_Rules, string pApplicationId, string pConnectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                wCmd = wDataBase.GetStoredProcCommand("[aspnet_Rules_i]");

                /// name
                wDataBase.AddInParameter(wCmd, "name", System.Data.DbType.String, paspnet_Rules.Name);
                /// expression
                wDataBase.AddInParameter(wCmd, "expression", System.Data.DbType.String, paspnet_Rules.Expression);
                /// ApplicationName
                wDataBase.AddInParameter(wCmd, "ApplicationName", System.Data.DbType.String, pApplicationId);

                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }

        #endregion
    }
}
