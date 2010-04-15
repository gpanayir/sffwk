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
    /// <summary>
    /// 
    /// </summary>
    public partial class FwkMembership
    {
        //static  string fwkAuthorizationProviderName_Default = "RuleProvider_Fwk";
        static Dictionary<string, string> providerCnnStrings;
      

        static SecuritySettings wSecuritySettings;

         static FwkMembership()
        {
             wSecuritySettings = (SecuritySettings)System.Configuration.ConfigurationManager.GetSection("securityConfiguration");
       
        }


        #region [Users]

      
        /// <summary>
        /// Verifican que usuario y password sean validos
        /// </summary>
        /// <param name="pUsername"></param>
        /// <param name="pPassword"></param>
         /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
         public static Boolean ValidateUser(string pUsername, string pPassword, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return wProvider.ValidateUser(pUsername, pPassword);
        }

        /// <summary>
        /// Crea un usuario
        /// Si el usuario existe lanza una (System.Web.Security.MembershipCreateUserException ex) 
        /// </summary>
        /// <param name="pUsername">Usuario</param>
        /// <param name="pPassword">Clave</param>
        /// <param name="pEmail">Email</param>
         /// <param name="providerName">Nombre del proveedor de membership</param>
            public static void CreateUser(string pUsername, string pPassword, string pEmail, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            //TODO: Ver por que esta declaracion  FwkIdentity
            //FwkIdentity wFwkIdentity = new FwkIdentity();

            wProvider.CreateUser(pUsername, pPassword, pEmail);

        }

        /// <summary>
        /// Crea un usuario
        /// Si el usuario existe lanza una (System.Web.Security.MembershipCreateUserException ex) 
        /// </summary>
        /// <param name="pUsername">Usuario</param>
        /// <param name="pPassword">Clave</param>   
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateUser(string pUsername, string pPassword, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            //TODO: Ver por que esta declaracion  FwkIdentity
            //FwkIdentity wFwkIdentity = new FwkIdentity();            

            wProvider.CreateUser(pUsername, pPassword);
        }

    
        /// <summary>
        /// Crea un usuario
        /// </summary>
        /// <param name="pUsername"></param>
        /// <param name="pPassword"></param>
        /// <param name="pEmail"></param>
        /// <param name="pPasswordQuestion"></param>
        /// <param name="pPasswordAnswer"></param>
        /// <param name="pIsApproved"></param>
        /// <param name="pStatus"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static User CreateUser(string pUsername, 
            string pPassword, 
            string pEmail, 
            string pPasswordQuestion, 
            string pPasswordAnswer, 
            Boolean pIsApproved, 
            out MembershipCreateStatus pStatus, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            User wUsuario = null;
            MembershipUser newUser = wProvider.CreateUser(pUsername, pPassword, pEmail, pPasswordQuestion, pPasswordAnswer, pIsApproved, out pStatus);
         
            if (newUser != null)
                wUsuario = new User(newUser);
            return wUsuario;

        }

        /// <summary>
        /// Elimina un usuario de la Base de Datos
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void DeleteUser(String pUserName, string providerName)
        {
            if (string.IsNullOrEmpty(provider))
                Membership.Providers[provider].DeleteUser(pUserName, true);
            else
                Membership.DeleteUser(pUserName);

        }

        /// <summary>
        /// Actualiza un usuario
        /// </summary>
        /// <param name="pFwkUser">User a eliminar</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UpdateUser(User pFwkUser, string providerName)
        {

            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);


            MembershipUser wUser = wProvider.GetUser(pFwkUser.UserName, false);//Membership.GetUser(pFwkUser.UserName);

            wUser.Comment = pFwkUser.Comment;
            wUser.Email = pFwkUser.Email;
            wUser.IsApproved = pFwkUser.IsApproved;

            //Membership.UpdateUser(wUser);
            
            wProvider.UpdateUser(wUser);


        }

        

        /// <summary>
        /// Actualiza informacion de un usuario. Incluso el nombre
        /// </summary>
        /// <param name="pFwkUser">Usuario con los nuevos datos </param>
        /// <param name="userName">Nombre de usuario a modificar. Nombre del usuario actual</param>
        /// <param name="pConnectionStringName">Cadena de coneccion de las Membership provider</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UpdateUser(User pFwkUser, string userName, string provider)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(provider);
            
            try
            {
                
                MembershipUser wUser = wProvider.GetUser(userName,false);

                wUser.Comment = pFwkUser.Comment;
                wUser.Email = pFwkUser.Email;
                wUser.IsApproved = pFwkUser.IsApproved;

                wProvider.UpdateUser(wUser);
                

            }
            catch (Exception ex)
            {
                throw ex;
            }

            ///Actualiza nombre de usuario
            StringBuilder str = new StringBuilder("UPDATE aspnet_Users SET  UserName = '[newUserName]',  LoweredUserName = '[loweredNewUserName]'  WHERE (UserName = '[userName]')");

            Database wDataBase = null;
            DbCommand wCmd = null;
            try
            {

                wDataBase = DatabaseFactory.CreateDatabase(GetSqlMembershipProvider_ConnectionStringName(wProvider.Name));
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
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static List<User> GetAllUsers(string providerName)
        {
            SqlMembershipProvider provider = GetSqlMembershipProvider(providerName);
            User wUserByApp;
            List<User> wUsersList = new List<User>();
            int totalRec=0;
            try
            {
              
                foreach (MembershipUser wMembershipUser in provider.GetAllUsers(0,0,out totalRec))
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
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>User</returns>
        public static User GetUser(String pUserName, string providerName)
        {
          
            MembershipUser wUser = GetMembershipUser(pUserName, providerName);
            // block the user
            if (wUser != null)
            {
                return new User(wUser);
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, pUserName)
                    );
                te.ErrorId = "4000";
                throw te;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static MembershipUser GetMembershipUser(String pUserName, string providerName)
        {
            SqlMembershipProvider wRrovider = GetSqlMembershipProvider(providerName);
            MembershipUser wMembershipUser = wRrovider.GetUser(pUserName, false);
            // block the user
            if (wMembershipUser != null)
            {
                return wMembershipUser;
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, pUserName)
                    );
                te.ErrorId = "4000";
                throw te;
            }


        }

        /// <summary>
        /// Bloquea un Usuario
        /// </summary>
        /// <param name="pUserName">Nombre del usuario que se desea bloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UnApproveUser(String pUserName, string providerName)
        {
            SqlMembershipProvider wRrovider = GetSqlMembershipProvider(providerName);
            MembershipUser wUser = GetMembershipUser(pUserName, providerName);

            // block the user
            if (wUser != null)
            {
                wUser.IsApproved = false;
                wRrovider.UpdateUser(wUser);
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, pUserName)
                    );
                te.ErrorId = "4000";
                throw te;
            }

        }

        /// <summary>
        /// Desbloquea un usuario
        /// </summary>
        /// <param name="pUserName">Nombre del usuario a desbloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void ApproveUser(String pUserName, string providerName)
        {
            SqlMembershipProvider wRrovider = GetSqlMembershipProvider(providerName);
            MembershipUser wUser = GetMembershipUser(pUserName, providerName);

            // block the user
            if (wUser != null)
            {
                wUser.IsApproved = true;
                wRrovider.UpdateUser(wUser);

            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, pUserName)
                    );
                te.ErrorId = "4000";
                throw te;
            }
        }


        /// <summary>
        /// Toma como entrada un nombre de usuario y actualiza el campo en el origen de datos que asigna a la propiedad 
        /// IsLockedOut el valor false. 
        /// El método UnlockUser devuelve true si el registro para el usuario suscrito se actualiza correctamente; de lo contrario, false.
        /// </summary>
        /// <param name="pUserName">Nombre del usuario a desbloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static bool UnlockUser(String pUserName, string providerName)
        {

            MembershipUser wUser = GetMembershipUser(pUserName,  providerName);
            
          
            // block the user
            if (wUser != null)
            {
                return wUser.UnlockUser();
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, pUserName)
                    );
                te.ErrorId = "4000";
                throw te;
            }
            
        }

      

        /// <summary>
        /// Resetea el Password de un usuario
        /// </summary>
        /// <param name="pUserName">Nombre del Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>Password auto generado</returns>
        public static String ResetUserPassword(String pUserName, string providerName)
        {
            String wNewPassword;

            MembershipUser wUser = Membership.GetUser(pUserName);
            // block the user
            if (wUser != null)
            {
                wNewPassword = wUser.ResetPassword();
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, pUserName)
                    );
                te.ErrorId = "4000";
                throw te;
            }

            return wNewPassword;
        }

        /// <summary>
        /// Cambia el password de un usuario
        /// </summary>
        /// <param name="pUserName">Nombre del Usuario</param>
        /// <param name="pOldPassword">Password Viejo</param>
        /// <param name="pNewPassword">Password Nuevo</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>Bool indicando el resultado de la operación</returns>
        public static Boolean ChangeUserPassword(String pUserName, String pOldPassword, String pNewPassword, string providerName)
        {
            MembershipUser wUser = Membership.GetUser(pUserName);

            return wUser.ChangePassword(pOldPassword, pNewPassword);

        }

        /// <summary>
        /// Obtiene una lista de usuarios de un determinado rol.- Solo obtiene nombre de usuario
        /// </summary>
        /// <param name="pRoleName">Nombre del rol</param>
        /// <returns>lista de <see cref="User"/> </returns>
        public static List<User> GetUsersInRole(String pRoleName, string providerName)
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
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>lista de <see cref="User"/> </returns>
        public static List<User> GetUsersDetailedInRole(String pRoleName, string providerName)
        {

            User wUserByApp;
            List<User> wUsersList = new List<User>();
            try
            {
                
                foreach (string userName in Roles.GetUsersInRole(pRoleName))
                {

                    wUserByApp = FwkMembership.GetUser(userName, providerName); 
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
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateRolesToUser(RolList pRolList, String pUserName, string providerName)
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
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUserFromRole(String pUserName, String pRoleName, string providerName)
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
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUserFromRoles(String pUserName, RolList pRolList, string providerName)
        {
            try
            {
                foreach (Rol rol in pRolList)
                {
                    if (Roles.IsUserInRole(pUserName, rol.RolName))
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
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUsersFromRole(String[] pUsersName, String pRoleName, string providerName)
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
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUsersFromRoles(String[] pUsersName, RolList pRolList, string providerName)
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

        

        


        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        static Fwk.Exceptions.TechnicalException GetTechnicalException(string msg)
        {
            Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException(msg);
            te.Assembly = typeof(FwkMembership).GetType().Namespace;
            te.Class = typeof(FwkMembership).GetType().Name;
            te.Source = "Security";
            te.UserName = Environment.UserName;
            return te;
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



        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static SqlMembershipProvider GetSqlMembershipProvider(string providerName)
        {
            if (string.IsNullOrEmpty(providerName))
                return (SqlMembershipProvider)Membership.Provider;
            else
                return (SqlMembershipProvider)Membership.Providers[providerName];


        }

        /// <summary>
        /// Obtiene la cadena de coneccion relacionada al proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static string GetSqlMembershipProvider_ConnectionStringName(string providerName)
        {

            if (wSecuritySettings != null)
            {
                Fwk.Security.Configuration.FwkAuthorizationRuleProviderData wProviderData;
                if (string.IsNullOrEmpty(providerName))
                    wProviderData = ((Fwk.Security.Configuration.FwkAuthorizationRuleProviderData)(wSecuritySettings.AuthorizationProviders.Get(Membership.Provider.Name)));
                else
                    wProviderData = ((Fwk.Security.Configuration.FwkAuthorizationRuleProviderData)(wSecuritySettings.AuthorizationProviders.Get(providerName)));

                if (wProviderData != null)
                {
                    return wProviderData.ConnectionStringName;
                }
            }
            return string.Empty;
        }
    }
}
