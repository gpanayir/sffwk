using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web.Security;
using Fwk.Security.Common;
using System.Data;

namespace Fwk.Security
{
    public partial class FwkMembership
    {
        #region [Users]


        /// <summary>
        /// Verifican que usuario y password sean validos
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static Boolean ValidateUser(string userName, string password, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            return wProvider.ValidateUser(userName, password);
        }

        /// <summary>
        /// Crea un usuario
        /// Si el usuario existe lanza una (System.Web.Security.MembershipCreateUserException ex) 
        /// </summary>
        /// <param name="userName">Usuario</param>
        /// <param name="password">Clave</param>
        /// <param name="email">Email</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateUser(string userName, string password, string email, string providerName)
        {
            //SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            //TODO: Ver por que esta declaracion  FwkIdentity
            //FwkIdentity wFwkIdentity = new FwkIdentity();
            MembershipCreateStatus status;
            //wProvider.CreateUser(userName, password, email, string.Empty, string.Empty, true, status);
            FwkMembership.CreateUser(userName, password, email, string.Empty, string.Empty, true, out  status, providerName);
        }

        /// <summary>
        /// Crea un usuario
        /// Si el usuario existe lanza una (System.Web.Security.MembershipCreateUserException ex) 
        /// </summary>
        /// <param name="userName">Usuario</param>
        /// <param name="password">Clave</param>   
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateUser(string userName, string password, string providerName)
        {
            //SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            //TODO: Ver por que esta declaracion  FwkIdentity
            //FwkIdentity wFwkIdentity = new FwkIdentity();            
            MembershipCreateStatus s;
            CreateUser(userName, password, string.Empty, string.Empty, string.Empty, true, out s, providerName);
        }


        /// <summary>
        /// Crea un usuario
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="passwordQuestion"></param>
        /// <param name="passwordAnswer"></param>
        /// <param name="isApproved"></param>
        /// <param name="pStatus"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static User CreateUser(string userName,
            string password,
            string email,
            string passwordQuestion,
            string passwordAnswer,
            Boolean isApproved,
            out MembershipCreateStatus pStatus, 
            string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            User wUsuario = null;
            MembershipUser newUser = wProvider.CreateUser(userName, password, email, passwordQuestion, passwordAnswer, isApproved,Guid.NewGuid(), out pStatus);

            if (newUser != null)
                wUsuario = new User(newUser);
            return wUsuario;

        }

        /// <summary>
        /// Elimina un usuario de la Base de Datos
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void DeleteUser(String userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            wProvider.DeleteUser(userName, true);
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
        public static void UpdateUser(User pFwkUser, string userName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);

            try
            {

                MembershipUser wUser = wProvider.GetUser(userName, false);

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

                wDataBase = DatabaseFactory.CreateDatabase(GetProvider_ConnectionStringName(wProvider.Name));
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
            int totalRec = 0;
            try
            {

                foreach (MembershipUser wMembershipUser in provider.GetAllUsers(0, 0, out totalRec))
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
        /// <param name="userName">Nombre del Usuario que se desea obtener</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>User</returns>
        public static User GetUser(String userName, string providerName)
        {

            MembershipUser wUser = GetMembershipUser(userName, providerName);
            // block the user
            if (wUser != null)
            {
                return new User(wUser);
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, userName)
                    );
                te.ErrorId = "4000";
                throw te;
            }


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static MembershipUser GetMembershipUser(String userName, string providerName)
        {
            SqlMembershipProvider wRrovider = GetSqlMembershipProvider(providerName);
            MembershipUser wMembershipUser = wRrovider.GetUser(userName, false);
            // block the user
            if (wMembershipUser != null)
            {
                return wMembershipUser;
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, userName)
                    );
                te.ErrorId = "4000";
                throw te;
            }


        }

        /// <summary>
        /// Bloquea un Usuario
        /// </summary>
        /// <param name="userName">Nombre del usuario que se desea bloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UnApproveUser(String userName, string providerName)
        {
            SqlMembershipProvider wRrovider = GetSqlMembershipProvider(providerName);
            MembershipUser wUser = GetMembershipUser(userName, providerName);

            // block the user
            if (wUser != null)
            {
                wUser.IsApproved = false;
                wRrovider.UpdateUser(wUser);
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, userName)
                    );
                te.ErrorId = "4000";
                throw te;
            }

        }

        /// <summary>
        /// Desbloquea un usuario
        /// </summary>
        /// <param name="userName">Nombre del usuario a desbloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void ApproveUser(String userName, string providerName)
        {
            SqlMembershipProvider wRrovider = GetSqlMembershipProvider(providerName);
            MembershipUser wUser = GetMembershipUser(userName, providerName);

            // block the user
            if (wUser != null)
            {
                wUser.IsApproved = true;
                wRrovider.UpdateUser(wUser);

            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, userName)
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
        /// <param name="userName">Nombre del usuario a desbloquear</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static bool UnlockUser(String userName, string providerName)
        {

            MembershipUser wUser = GetMembershipUser(userName, providerName);


            // block the user
            if (wUser != null)
            {
                return wUser.UnlockUser();
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, userName)
                    );
                te.ErrorId = "4000";
                throw te;
            }

        }



        /// <summary>
        /// Resetea el Password de un usuario
        /// </summary>
        /// <param name="userName">Nombre del Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>Password auto generado</returns>
        public static String ResetUserPassword(String userName, string providerName)
        {
            String wNewPassword;

            MembershipUser wUser = GetMembershipUser(userName, providerName);
            // block the user
            if (wUser != null)
            {
                wNewPassword = wUser.ResetPassword();
            }
            else
            {
                Fwk.Exceptions.TechnicalException te = GetTechnicalException(
                    string.Format(Fwk.Security.Properties.Resource.UserNotExist, userName)
                    );
                te.ErrorId = "4000";
                throw te;
            }

            return wNewPassword;
        }

        /// <summary>
        /// Cambia el password de un usuario
        /// </summary>
        /// <param name="userName">Nombre del Usuario</param>
        /// <param name="pOldPassword">Password Viejo</param>
        /// <param name="pNewPassword">Password Nuevo</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>Bool indicando el resultado de la operación</returns>
        public static Boolean ChangeUserPassword(String userName, String pOldPassword, String pNewPassword, string providerName)
        {
            MembershipUser wUser = GetMembershipUser(userName, providerName);

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
                foreach (string s in Roles.Providers[providerName].GetUsersInRole(pRoleName))
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
                foreach (string userName in Roles.Providers[providerName].GetUsersInRole(pRoleName))
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
        /// <param name="userName">Usuario</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void CreateRolesToUser(RolList pRolList, String userName, string providerName)
        {

            try
            {
                Roles.Providers[providerName].AddUsersToRoles(new string[] { userName }, pRolList.GetArrayNames() );

                //foreach (Rol rol in pRolList)
                //{
                //    if (!Roles.Providers[providerName].IsUserInRole(userName, rol.RolName))
                //    {
                //        //Roles.AddUserToRoles(userName, new string[] { rol.RolName });

                //        Roles.Providers[providerName].AddUsersToRoles(new string[] { userName }, new string[] { rol.RolName });
                //    }
                //}

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
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="pRoleName">Nombre de Rol</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUserFromRole(String userName, String pRoleName, string providerName)
        {
            try
            {
                if (!String.IsNullOrEmpty(pRoleName))
                    Roles.Providers[providerName].RemoveUsersFromRoles(new string[] { userName }, new string[] { pRoleName });

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Quita a un usuario de una lista de Roles
        /// </summary>
        /// <param name="userName">Nombre de Usuario</param>
        /// <param name="pRolList">Lista de Nombres de Roles</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void RemoveUserFromRoles(String userName, RolList pRolList, string providerName)
        {
            try
            {
                foreach (Rol rol in pRolList)
                {
                    if (Roles.IsUserInRole(userName, rol.RolName))
                        //Roles.RemoveUserFromRoles(userName, new string[] { rol.RolName });
                        Roles.Providers[providerName].RemoveUsersFromRoles(new string[] { userName }, pRolList.GetArrayNames());

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
               // Roles.RemoveUsersFromRole(pUsersName, pRoleName);
                Roles.Providers[providerName].RemoveUsersFromRoles(pUsersName, new string[] { pRoleName });
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
                Roles.Providers[providerName].RemoveUsersFromRoles(pUsersName, pRolList.GetArrayNames());
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }





        #endregion
    }
}
