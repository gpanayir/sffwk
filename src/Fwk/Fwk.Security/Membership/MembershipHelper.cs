using System;
using System.Collections.Generic;
using System.Web.Security;
using Fwk.Security.Common;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Data;
using Microsoft.Practices.EnterpriseLibrary.Security;
using System.Text;
using System.Linq;
namespace Fwk.Security
{
    public partial class FwkMembership
    {
        static  string fwkAuthorizationProviderName = "RuleProvider_Fwk";
        //static string membershipConnectionStringName;
        static FwkActyveDirectory _FwkActyveDirectory;

        static FwkActyveDirectory GetActiveDirectoriInstance(string pDomainName)
        {
            if (_FwkActyveDirectory == null)
            {
                _FwkActyveDirectory = new FwkActyveDirectory(pDomainName);
            }
            return _FwkActyveDirectory;

        }
       
        /// <summary>
        /// Se carga al iniciar la configuracion en <see cref="FwkAuthorizationRuleProviderData"/>
        ///  FwkMembership.ConnectionStringName = this["connectionStringName"].ToString().Trim();
        /// </summary>
        public static string ConnectionStringName;
         static FwkMembership()
        {
             SecuritySettings wSecuritySettings = (SecuritySettings)System.Configuration.ConfigurationManager.GetSection("securityConfiguration");
             if (wSecuritySettings != null)
             {
                 Fwk.Security.Configuration.FwkAuthorizationRuleProviderData data = ((Fwk.Security.Configuration.FwkAuthorizationRuleProviderData)(wSecuritySettings.AuthorizationProviders.Get(fwkAuthorizationProviderName)));
                 if (data != null)
                     ConnectionStringName = data.ConnectionStringName;
             }
        }
        #region [Users]

        public static Boolean ValidateUser(string pUsername, string pPassword, string pDomainName)
        {
            Boolean wIsUserAuthenticated = false;
            _FwkActyveDirectory = GetActiveDirectoriInstance(pDomainName);
            if (_FwkActyveDirectory.ValidateUser(pUsername, pPassword)) // Chequea primero contra el dominio
            {
                wIsUserAuthenticated = Membership.ValidateUser(pUsername, pPassword); // Chequea luego con la base de datos local
            }

            return wIsUserAuthenticated;
        }
        /// <summary>
        /// Verifican que usuario y password sean validos
        /// </summary>
        /// <param name="pUsername"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public static Boolean ValidateUser(string pUsername, string pPassword)
        {
            return Membership.ValidateUser(pUsername, pPassword);
        }

        /// <summary>
        /// Crea un usuario
        /// Si el usuario existe lanza una (System.Web.Security.MembershipCreateUserException ex) 
        /// </summary>
        /// <param name="pUsername">Usuario</param>
        /// <param name="pPassword">Clave</param>
        public static void CreateUser(string pUsername, string pPassword, string pEmail)
        {
            FwkIdentity wFwkIdentity = new FwkIdentity();

            System.Web.Security.Membership.CreateUser(pUsername, pPassword, pEmail);

        }

        /// <summary>
        /// Crea un usuario
        /// </summary>
        /// <param name="pUsername"></param>
        /// <param name="pPassword"></param>
        public static User CreateUser(string pUsername, string pPassword, string pEmail, string pPasswordQuestion, string pPasswordAnswer, Boolean pIsApproved, out MembershipCreateStatus pStatus)
        {
            User wUsuario = null;
            MembershipUser newUser = Membership.CreateUser(pUsername, pPassword, pEmail, pPasswordQuestion, pPasswordAnswer, pIsApproved, out pStatus);
         
            if (newUser != null)
                wUsuario = new User(newUser);
            return wUsuario;

        }

        /// <summary>
        /// Elimina un usuario de la Base de Datos
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        public static void DeleteUser(String pUserName)
        {

            Membership.DeleteUser(pUserName);

        }

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="pFwkUser">User a eliminar</param>
        public static void UpdateUser(User pFwkUser)
        {

            MembershipUser wUser = Membership.GetUser(pFwkUser.UserName);

            wUser.Comment = pFwkUser.Comment;
            wUser.Email = pFwkUser.Email;
            wUser.IsApproved = pFwkUser.IsApproved;

            Membership.UpdateUser(wUser);


        }

        /// <summary>
        /// Actualiza informacion de un usuario
        /// </summary>
        /// <param name="pFwkUser">Usuario con los nuevos datos </param>
        /// <param name="userName">Nombre de usuario a modificar</param>
        public static void UpdateUser(User pFwkUser, string userName)
        {
            UpdateUser(pFwkUser, userName, ConnectionStringName);
        }

        /// <summary>
        /// Actualiza informacion de un usuario
        /// </summary>
        /// <param name="pFwkUser">Usuario con los nuevos datos </param>
        /// <param name="userName">Nombre de usuario a modificar</param>
        /// <param name="pConnectionStringName">Cadena de coneccion de las Membership provider</param>
        public static void UpdateUser(User pFwkUser, string userName, string pConnectionStringName)
        {
            try
            {
                MembershipUser wUser = Membership.GetUser(userName);

                wUser.Comment = pFwkUser.Comment;
                wUser.Email = pFwkUser.Email;
                wUser.IsApproved = pFwkUser.IsApproved;

                Membership.UpdateUser(wUser);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            StringBuilder str = new StringBuilder("UPDATE aspnet_Users SET  UserName = '[newUserName]',  LoweredUserName = '[loweredNewUserName]'  WHERE (UserName = '[userName]')");

            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                str.Replace("[newUserName]", pFwkUser.UserName);
                str.Replace("[loweredNewUserName]", pFwkUser.UserName.ToLower());
                str.Replace("[userName]", pFwkUser.UserName.ToLower());

                wCmd.CommandType = CommandType.Text;


                wDataBase.ExecuteNonQuery(wCmd);






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
            // block the user
            if (wUser == null)
            {
                return null;
            }
            else
            {
                return new User(wUser);
            }
        }

        /// <summary>
        /// Bloquea un Usuario
        /// </summary>
        /// <param name="pUserName">Nombre del usuario que se desea bloquear</param>
        public static void UnApproved(String pUserName)
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
        public static void Approved(String pUserName)
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
        /// Obtiene una lista de usuarios de un determinado rol.- Solo obtiene nombre de usuario
        /// </summary>
        /// <param name="pRoleName">Nombre del rol</param>
        /// <returns>lista de <see cref="User"/> </returns>
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
        /// Obtiene una lista de usuarios con sus detalles pertenecientes a un determinado rol
        /// </summary>
        /// <param name="pRoleName">Nombre del rol</param>
        /// <returns>lista de <see cref="User"/> </returns>
        public static List<User> GetUsersDetailedInRole(String pRoleName)
        {

            User wUserByApp;
            List<User> wUsersList = new List<User>();
            try
            {
                foreach (string userName in Roles.GetUsersInRole(pRoleName))
                {

                    wUserByApp =  FwkMembership.GetUser(userName); 
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
                    if (!Roles.IsUserInRole(pUserName, rol.RolName))
                    {
                        Roles.AddUserToRoles(pUserName, new string[] { rol.RolName });
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
                if (!String.IsNullOrEmpty(pRoleName))
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

        /// <summary>
        ///  Obtiene el mensaje de error (Ingles)
        /// </summary>
        /// <param name="status">MembershipCreateStatus</param>
        /// <returns>Mensaje de error</returns>
        public static string GetErrorMessage(MembershipCreateStatus status)
        {
            switch (status)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Username already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A username for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
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
        /// <param name="pRoleName"></param>
        public static void CreateRole(String pRoleName)
        {

            CreateRole(pRoleName,string.Empty,Membership.ApplicationName,ConnectionStringName);
        }

        /// <summary>
        /// Crea un nuevo Rol
        /// </summary>
        /// <param name="pRoleName"></param>
        /// <param name="pDescription"></param>
        public static void CreateRole(String pRoleName,string pDescription)
        {
            CreateRole(pRoleName, pDescription, Membership.ApplicationName, ConnectionStringName);
        }
      
        /// <summary>
        /// Crea un nuevo Rol
        /// </summary>
        /// <param name="pRoleName">Nombre del Rol</param>
        public static void CreateRole(String pRoleName, string pDescription,string pApplicationName, string pConnectionStringName)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRoleName"></param>
        /// <param name="pDescription"></param>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        public static void UpdateRole(String pRoleName, string pDescription,string pApplicationName, string pConnectionStringName)
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
        public static void CreateUsersToRole(string pRolName, List<User> pUserList)
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

        #region [Rules]
       
        public static aspnet_Rule GetRule(string ruleName, string pApplicationName)
        {
            return GetRule(ruleName,pApplicationName, ConnectionStringName);
        }

        public static aspnet_Rule GetRule(string ruleName, string pApplicationName, string pConnectionStringName)
        {

            aspnet_Rule waspnet_Rule;
            try
            {

                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    waspnet_Rule = dc.aspnet_Rules.First<aspnet_Rule>(s => s.name.Equals(ruleName.Trim()) && s.ApplicationId == wApplicationId);
                    return waspnet_Rule;
                }
            }
            catch (InvalidOperationException)
            {
                ///TODO: mejorar manejo de Exception GetRule
                throw new Exception(string.Concat("Error al intentar obtener los valores de la relgla: " + ruleName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// </summary>
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        /// <returns></returns>
        public static NamedElementCollection<FwkAuthorizationRule> GetRules(string pApplicationName)
        {
            return GetRules(pApplicationName, ConnectionStringName);
        }
       

        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// Reemplaza aspnet_Rules_s
        /// </summary>
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        /// <returns></returns>
        public static NamedElementCollection<FwkAuthorizationRule> GetRules(string pApplicationName, string pConnectionStringName)
        {

            ///TODO: Eliminar aspnet_Rules_s
           
            FwkAuthorizationRule rule = null;
            NamedElementCollection<FwkAuthorizationRule> wRules = null;
            try
            {

                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

                wRules = new NamedElementCollection<FwkAuthorizationRule>();
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    var aspnet_Rules = from s in dc.aspnet_Rules where s.ApplicationId == wApplicationId select s;

                    foreach (aspnet_Rule aspnet_Rule in aspnet_Rules.ToList<aspnet_Rule>())
                    {
                        rule = new FwkAuthorizationRule();
                        rule.Name = aspnet_Rule.name;
                        rule.Expression = aspnet_Rule.expression;


                        wRules.Add(rule);
                    }
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
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesAuxList(string pApplicationName, string pConnectionStringName)
        {

            Database wDataBase = null;
            DbCommand wCmd = null;
            FwkAuthorizationRuleAux rule = null;
            List<FwkAuthorizationRuleAux> wRules = null;
            try
            {

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                wCmd = wDataBase.GetStoredProcCommand("aspnet_Rules_s");

                wDataBase.AddInParameter(wCmd, "ApplicationName", System.Data.DbType.String, pApplicationName);

                IDataReader reader = wDataBase.ExecuteReader(wCmd);
                wRules = new List<FwkAuthorizationRuleAux>();
                while (reader.Read())
                {
                    rule = new FwkAuthorizationRuleAux(reader["Name"].ToString().Trim(), reader["Expression"].ToString());
                    //rule.Name = reader["Name"].ToString().Trim();
                    //rule.Expression = reader["Expression"].ToString();
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
            bool wExist = false;
            ///TODO: Eliminar aspnet_Rules_g_Exist
            try
            {
                
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                  wExist =   dc.aspnet_Rules.Any( s => s.Equals(pRuleName) && s.ApplicationId == wApplicationId );
                }


                return wExist;
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
        public static void CreateRules(FwkAuthorizationRule paspnet_Rules, string pApplicationName, string pConnectionStringName)
        {


            ///TODO: Eliminar aspnet_Rules_i
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.Rule_i);
                str.Replace("[ApplicationId]", wApplicationId.ToString());
                str.Replace("[rulename]", paspnet_Rules.Name.Trim());
                str.Replace("[expression]", paspnet_Rules.Expression);

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;



                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region [Application]

        /// <summary>
        /// Retorna el GUID de la aplicación
        /// </summary>
        /// <param name="pApplicationName">Nombre de la aplicación</param>
        /// <returns>GUID de la aplicacion</returns>
        public static string GetApplicationID(String pApplicationName)
        {

            String wApplicationId = String.Empty;
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                wDataBase = DatabaseFactory.CreateDatabase(FwkMembership.ConnectionStringName);
                wCmd = wDataBase.GetStoredProcCommand("[aspnet_Personalization_GetApplicationId]");

                /// ApplicationName
                wDataBase.AddInParameter(wCmd, "ApplicationName", System.Data.DbType.String, pApplicationName);


                wDataBase.AddOutParameter(wCmd, "ApplicationId", System.Data.DbType.Guid, 64);

                wDataBase.ExecuteScalar(wCmd);

                wApplicationId = Convert.ToString(wDataBase.GetParameterValue(wCmd, "ApplicationId"));

                return wApplicationId;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
