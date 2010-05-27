using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.Security;
using System.Security.Authentication;
using System.Data.SqlClient;
using Fwk.Security;
using Fwk.Bases;
using Fwk.Exceptions;
using Fwk.Security.BE;
using Fwk.Security.Common;
using Fwk.Security.ActiveDirectory;
using Fwk.Security.DAC;

namespace Fwk.Security.BC
{
    /// <summary>
    /// 
    /// </summary>
    public class UserBC:Fwk.Bases.BaseBC
    {
        string _ProviderName;
        public UserBC(string pCompanyId,string pProviderName)
            : base(pCompanyId)
        {
            _ProviderName = pProviderName;
        }


        /// <summary>
        /// Crea un nuevo usuario.
        /// </summary>
        /// <param name="pUserBE">UsuarioBE a crear</param>
        /// <param name="CustomParameters">Lista de parametros customizados</param>        
        /// <param name="pRolList">Roles del usuario</param>
        /// <param name="pCustomUserTable">Nombre de la tabla customizada</param>
        /// <returns>UserId del nuevo usuario.</returns>
        public void Create(User pUserBE, List<SqlParameter> CustomParameters, RolList pRolList, String pCustomUserTable)
        {
            SqlMembershipProvider wProvider = FwkMembership.GetSqlMembershipProvider(_ProviderName);
                        

            // nuevo GUID para el usuario
            Guid wUserGUID = Guid.NewGuid();
            MembershipCreateStatus pStatus = MembershipCreateStatus.UserRejected;

            // se inserta en las membership el nuevo usuario
            MembershipUser wNewUser = wProvider.CreateUser(pUserBE.UserName, pUserBE.Password, pUserBE.Email,
                                                          pUserBE.QuestionPassword, pUserBE.AnswerPassword,
                                                          pUserBE.IsApproved, wUserGUID, out pStatus);


            // se inserta el usuario custom
            if (pStatus == MembershipCreateStatus.Success)
            {
                UsersDAC.Create(pUserBE, CustomParameters, _ProviderName, pCustomUserTable);
                // se insertan los roles
                if (pRolList != null)
                    FwkMembership.CreateRolesToUser(pRolList, pUserBE.UserName, _ProviderName);
            }
            else
            {
                String wError = String.Format("No se puede crear el usuario \'{0}\': {1}", pUserBE.UserName, FwkMembership.GetErrorMessage(pStatus));
                throw new FunctionalException(wError);
            }
        }

        /// <summary>
        /// Actualiza los datos del usuario.
        /// </summary>
        /// <param name="pUserBE">Usuario que se desea actualizar</param>
        /// <param name="CustomParameters">Parametros para la tabla customizada</param>
        /// <param name="pRolList">Lista de roles para actualizar</param>
        /// <param name="pCustomUserTable">Nombre de la tabla customizada</param>
        public void Update(User pUserBE, List<SqlParameter> CustomParameters, RolList pRolList, String pCustomUserTable)
        {
            Validate(pUserBE, false);
            
            ///Update Bigbang Security.User
            UsersDAC.Update(pUserBE, CustomParameters, _ProviderName, pCustomUserTable);
            // Actualizacion del usuario de las membership
            FwkMembership.UpdateUser(pUserBE, _ProviderName);
            
            // Se actualizan los roles que posee el usuario
            if (pRolList != null)
            {
                RolList usrRoles = FwkMembership.GetRolesForUser(pUserBE.UserName,_ProviderName);
                FwkMembership.RemoveUserFromRoles(pUserBE.UserName, usrRoles, _ProviderName);
                FwkMembership.CreateRolesToUser(pRolList, pUserBE.UserName, _ProviderName);
            }
        }             

        /// <summary>
        /// Cambia la password.-
        /// Si pOldPassword es = null se resetea y luego se asigna pNewPassword
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        /// <param name="pOldPassword">Password anterior.- Si es en String.Empty se resetea</param>
        /// <param name="pNewPassword">Nueva password</param>
        public void ChangePassword(string pUserName, string pOldPassword, string pNewPassword)
        {
            if (string.IsNullOrEmpty(pOldPassword))
            {
                try
                {
                    pOldPassword = FwkMembership.ResetUserPassword(pUserName,_ProviderName);
                }
                catch (System.Web.Security.MembershipPasswordException)
                {
                    FwkMembership.UnlockUser(pUserName,_ProviderName);
                    pOldPassword = FwkMembership.ResetUserPassword(pUserName,_ProviderName);
                }
                catch (Exception er)
                {
                    throw er;
                }
            }

            if (!FwkMembership.ChangeUserPassword(pUserName,
                pOldPassword,
                pNewPassword, _ProviderName))
            {
                throw new Fwk.Exceptions.FunctionalException("La contraseña anterior es incorrecta .-");
            }

            //UsersBE wUserBE = UsersDAC.GetByName(pUserName, _ProviderName);
            //wUserBE.MustChangePassword = false;
            //UsersDAC.Update(wUserBE,_ProviderName);
        }
        
        /// <summary>
        /// Valida si el usuario existe.
        /// </summary>
        /// <param name="pUserBE">UsersBE a validar.</param>
        /// <param name="pIsNewUser">Si es nuevo se verifica de otra forma</param>
        private void Validate(User pUserBE,Boolean pIsNewUser)
        {
            //Validación de existencia de usuario
            //Nombre vacio
            if (String.IsNullOrEmpty(pUserBE.UserName))
            {
                throw new FunctionalException(null, "NullOrEmptyField", "ValidationExceptionMessage", "Nombre de usuario");
            }

            if (pIsNewUser)
            {   //Nombre ya existente

                User wUser = FwkMembership.GetUser(pUserBE.UserName, _ProviderName);
                // si el usuario es != null entonces existe.
                if (wUser == null)
                    throw new FunctionalException(String.Format("Ya existe un usuario con el nombre \'{0}\'", pUserBE.UserName));
            }
        }

        /// <summary>
        /// Obtiene la informacion de un usuario y su Custom de un usuario, junto a sus roles
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="CustomParameters"></param>
        /// <param name="pCustomUserStoreProcedure"></param>
        /// <param name="pRolList"></param>
        /// <returns></returns>
        public DataSet GetUserInfoByName(String pUserName, List<SqlParameter> CustomParameters,
                                         String pCustomUserStoreProcedure, out RolList pRolList, User pUser)
        {
            DataSet wUserInfo = null;

            pUser = FwkMembership.GetUser(pUserName, _ProviderName);

            if (CustomParameters != null)
            {
                if (CustomParameters.Count > 0)
                {
                    wUserInfo = UsersDAC.GetUser(_ProviderName, CustomParameters, pCustomUserStoreProcedure);

                    if (wUserInfo == null)
                    {
                        throw new FunctionalException("No se encontró ningún usuario");
                    }
                }
            }
            pRolList = FwkMembership.GetRolesForUser(pUserName, _ProviderName);

            return wUserInfo;
        }

        /// <summary>
        ///  Este metodo es usa cuando la autenticacion es integrada (con windows)
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>        
        public DataSet AuthenticateUser(String pUserName, List<SqlParameter> CustomParameters,
                                         String pCustomUserStoreProcedure, out RolList pRolList, User pUser)
        {
            //UserInfo wUserInfo = null;
            User wUser = Fwk.Security.FwkMembership.GetUser(pUserName,_ProviderName);
            DataSet wUserCustom;

            if (wUser == null)
                throw new FunctionalException("No es un usuario registrado para ingresar al sistema.");

            if (!wUser.IsApproved)
                throw new FunctionalException(string.Format("El usuario '{0}' no es un usuario aprobado. Pongase en contacto con su administrador.", pUserName));

            wUserCustom = GetUserInfoByName(pUserName, CustomParameters,
                                            pCustomUserStoreProcedure, out pRolList, pUser);

            pRolList = FwkMembership.GetRolesForUser(pUserName, _ProviderName);

            return wUserCustom;
        }

        /// <summary>
        /// Este metodo es para se usado cuano la autenticacion es solo de bigbang
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public DataSet AuthenticateUser(String pUserName, String pPassword, List<SqlParameter> CustomParameters,
                                         String pCustomUserStoreProcedure, out RolList pRolList, User pUser)
        {
            
            bool wValidateUser = Fwk.Security.FwkMembership.ValidateUser(pUserName, pPassword,_ProviderName);

            if (wValidateUser == false)
            {
                throw new FunctionalException("Nombre de usuario o contraseña no válida. Verifique sus datos por favor, e intentelo nuevamente.");
            }

            return this.AuthenticateUser(pUserName,CustomParameters,pCustomUserStoreProcedure, out pRolList, pUser);

        }

        /// <summary>
        /// Este metodo es para se usado cuano la autenticacion contra LDAP
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pDomain"></param>
        /// <returns></returns>
        public DataSet AuthenticateUser(String pUserName, String pPassword, String pDomain,List<SqlParameter> pCustomParameters,
                                         String pCustomUserStoreProcedure, out RolList pRolList, User pUser)
        {

            ADHelper wADHelper = new Fwk.Security.ActiveDirectory.ADHelper(pDomain);
            LoginResult wLoginResult = wADHelper.User_CheckLogin(pUserName, pPassword);
            switch (wLoginResult)
            {
                //case LoginResult.LOGIN_OK:
                //    //pasa
                //    break;
                case LoginResult.ERROR_PASSWORD_EXPIRED:
                    throw new AuthenticationException("La clave ha expirado.");
                    break;
                case LoginResult.ERROR_PASSWORD_MUST_CHANGE:
                    throw new AuthenticationException("El usuario debe cambiar la clave.");
                    break;
                case LoginResult.LOGIN_USER_ACCOUNT_INACTIVE:
                    throw new AuthenticationException("La cuenta se encuentra deshabilitada.");
                    break;
                case LoginResult.LOGIN_USER_ACCOUNT_LOCKOUT:
                    throw new AuthenticationException("La cuenta se encuentra bloqueada.");
                    break;
                case LoginResult.LOGIN_USER_DOESNT_EXIST:
                    throw new AuthenticationException("Error en nombre de usuario y/o clave.");
                    break;
                case LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT:
                    throw new AuthenticationException("Error en nombre de usuario y/o clave.");
                    break;
                default:
                    throw new FunctionalException("Error desconocido.");
                    break;
            }

            return this.AuthenticateUser(pUserName, pCustomParameters, pCustomUserStoreProcedure, out pRolList, pUser);

            //// Se baja el Flag MustChangePassword porque es solo para autenticación Mixta, no importa el valor que tenga
            //wUserInfo.MustChangePassword = false;

            //return wUserInfo;
        }
      
        public  List<String> MapListDomainToListString(List<DomainUrlInfo> pDomainUrlInfoList)
        {
            List<String> wDomainNamesList = new List<String>();

            foreach (DomainUrlInfo wItem in pDomainUrlInfoList)
            {
                wDomainNamesList.Add(wItem.DomainName.ToUpper());
            }

            return wDomainNamesList;
        }

        
        public DataSet GetUser(String pUserName,List<SqlParameter> pCustomParameters,
                                         String pCustomUserStoreProcedure, User pUser)
        {
            DataSet wResult = null;
            pUser =FwkMembership.GetUser(pUserName, _ProviderName);

            // Verficación de parametros customizables
            if (pCustomParameters != null)
            {
                if (pCustomParameters.Count > 0)
                {
                    wResult = UsersDAC.GetUser(_ProviderName, pCustomParameters, pCustomUserStoreProcedure);
                }
            }
            
            return wResult;
        }

        public DataSet GetAllUser(UserList pUserList, String pCustomUserStoreProcedure)
        {
            DataSet wResult = null;

            // Se obtienen los usuarios de las memberships
            pUserList.AddRange(FwkMembership.GetAllUsers(_ProviderName));

            // Se obtienen los usuarios Custom
            if(pCustomUserStoreProcedure != String.Empty)
                wResult = UsersDAC.GetAllUsers(_ProviderName, pCustomUserStoreProcedure);

            return wResult;
        }
    }
}