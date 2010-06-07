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
        /// <param name="pUser">UsuarioBE a crear</param>
        /// <param name="CustomParameters">Lista de parametros customizados</param>        
        /// <param name="pRolList">Roles del usuario</param>
        /// <param name="pCustomUserTable">Nombre de la tabla customizada</param>
        /// <returns>UserId del nuevo usuario.</returns>
        public void Create(User pUser,RolList pRolList)
        {
                        
            //TODO: Ver tema de nuevo GUID para el usuario 
            //Guid wUserGUID = Guid.NewGuid();

            MembershipCreateStatus pStatus = MembershipCreateStatus.UserRejected;

            // se inserta en las membership el nuevo usuario
            User wNewUser = FwkMembership.CreateUser(pUser.UserName, pUser.Password, pUser.Email,
                                                          pUser.QuestionPassword, pUser.AnswerPassword,
                                                          pUser.IsApproved, out pStatus,_ProviderName);

            // se inserta el usuario custom
            if (pStatus == MembershipCreateStatus.Success)
            {
                //UsersDAC.Create(pUser, CustomParameters, _ProviderName, pCustomUserTable);
                // Se insertan los roles
                if (pRolList != null)
                    FwkMembership.CreateRolesToUser(pRolList, pUser.UserName, _ProviderName);
            }
            else
            {
                TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_Created_Error_Message, pUser.UserName,pStatus));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4008";
                throw te;

            }
        }

        /// <summary>
        /// Actualiza los datos del usuario.
        /// </summary>
        /// <param name="pUser">Usuario que se desea actualizar.</param>
        /// <param name="userName">Nombre no modificado del usuario.- El nuevo nombre de usuario en caso de modifucacion 
        /// va en el parametro pUser </param>
        /// <param name="pRolList">Lista de roles para actualizar</param>
        /// <param name="pCustomUserTable">Nombre de la tabla customizada</param>
        public void Update(User pUser,string userName,  RolList pRolList)
        {
            Validate(pUser, false);
            
           
            // Actualizacion del usuario de las membership
            FwkMembership.UpdateUser(pUser,userName, _ProviderName);
            
            // Se actualizan los roles que posee el usuario
            if (pRolList != null)
            {
                RolList usrRoles = FwkMembership.GetRolesForUser(pUser.UserName,_ProviderName);
                FwkMembership.RemoveUserFromRoles(pUser.UserName, usrRoles, _ProviderName);
                FwkMembership.CreateRolesToUser(pRolList, pUser.UserName, _ProviderName);
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
                
                TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_InvalidCredentialsMessage, pUserName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4007";
                throw te;

            }

            //UsersBE wUserBE = UsersDAC.GetByName(pUserName, _ProviderName);
            //wUserBE.MustChangePassword = false;
            //UsersDAC.Update(wUserBE,_ProviderName);
        }
        
        /// <summary>
        /// Valida si el usuario existe. y si no le falta el nombre
        /// </summary>
        /// <param name="pUser">UsersBE a validar.</param>
        /// <param name="pIsNewUser">Si es nuevo se verifica de otra forma</param>
        void Validate(User pUser,Boolean pIsNewUser)
        {
            //Validación de existencia de usuario
            //Nombre vacio
            if (String.IsNullOrEmpty(pUser.UserName))
            {
                throw new FunctionalException(null, "NullOrEmptyField", "ValidationExceptionMessage", "Nombre de usuario");
            }

            if (pIsNewUser)
            { 
                //Nombre ya existente
                User wUser = FwkMembership.GetUser(pUser.UserName, _ProviderName);
                
                TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_NotExist, pUser.UserName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4007";
                throw te;

                
                
            }
        }

        /// <summary>
        /// Obtiene la informacion de un usuario y su Custom de un usuario, junto a sus roles
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pRolList"></param>
        /// <returns></returns>
        public void GetUserByParams(String pUserName,out User pUser  , out RolList pRolList)
        {
           

            pUser = FwkMembership.GetUser(pUserName, _ProviderName);

            //if (CustomParameters != null)
            //{
            //    if (CustomParameters.Count > 0)
            //    {
            //        wUserInfo = UsersDAC.GetUser(_ProviderName, CustomParameters, pCustomUserStoreProcedure);

            //        if (wUserInfo == null)
            //        {
            //            throw new FunctionalException("No se encontró ningún usuario");
            //        }
            //    }
            //}
            pRolList = FwkMembership.GetRolesForUser(pUserName, _ProviderName);

          
        }

     
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pUser"></param>
        /// <returns></returns>
        public bool AuthenticateUser(String pUserName, String pPassword, out User pUser)
        {
            pUser = Fwk.Security.FwkMembership.GetUser(pUserName, _ProviderName);


            if (pUser == null)
            {
                TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_NotExist, pUserName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4007";
                throw te;

            }


            bool wValidateUser = Fwk.Security.FwkMembership.ValidateUser(pUserName, pPassword, _ProviderName);

            if (wValidateUser == false)
            {

                TechnicalException te = new TechnicalException(string.Format(Fwk.Security.Properties.Resource.User_InvalidCredentialsMessage, pUserName));
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4007";
                throw te;
            }
            return wValidateUser;
        }

        /// <summary>
        /// Este metodo es para se usado cuano la autenticacion contra LDAP
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pDomain"></param>
        /// <returns></returns>
        public LoginResult AuthenticateUser_AD(String pUserName, String pPassword, String pDomain)
        {


            ADHelper wADHelper = StaticsValues.Find_ADHelper(pDomain);
           
            LoginResult wLoginResult = wADHelper.User_CheckLogin(pUserName, pPassword);
            return wADHelper.User_CheckLogin(pUserName, pPassword);

            //switch (wLoginResult)
            //{
            //    //case LoginResult.LOGIN_OK:
            //    //    //pasa
            //    //    break;
            //    case LoginResult.ERROR_PASSWORD_EXPIRED:
            //        throw new AuthenticationException("La clave ha expirado.");
            //        break;
            //    case LoginResult.ERROR_PASSWORD_MUST_CHANGE:
            //        throw new AuthenticationException("El usuario debe cambiar la clave.");
            //        break;
            //    case LoginResult.LOGIN_USER_ACCOUNT_INACTIVE:
            //        throw new AuthenticationException("La cuenta se encuentra deshabilitada.");
            //        break;
            //    case LoginResult.LOGIN_USER_ACCOUNT_LOCKOUT:
            //        throw new AuthenticationException("La cuenta se encuentra bloqueada.");
            //        break;
            //    case LoginResult.LOGIN_USER_DOESNT_EXIST:
            //        throw new AuthenticationException("Error en nombre de usuario y/o clave.");
            //        break;
            //    case LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT:
            //        throw new AuthenticationException("Error en nombre de usuario y/o clave.");
            //        break;
            //    default:
            //        throw new FunctionalException("Error desconocido.");
            //        break;
            //}

            //return true;//this.AuthenticateUser(pUserName,pUserName,out pUser);

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


        public User GetUser(String pUserName)
        {

            User wUser = FwkMembership.GetUser(pUserName, _ProviderName);

            // Verficación de parametros customizables
            //if (pCustomParameters != null)
            //{
            //    if (pCustomParameters.Count > 0)
            //    {
            //        wResult = UsersDAC.GetUser(_ProviderName, pCustomParameters, pCustomUserStoreProcedure);
            //    }
            //}

            return wUser;
        }

        public UserList GetAllUser()
        {
          

            // Se obtienen los usuarios de las memberships
            UserList pUserList = new UserList();
            pUserList.AddRange(FwkMembership.GetAllUsers(_ProviderName));

            // Se obtienen los usuarios Custom
            //if(pCustomUserStoreProcedure != String.Empty)
            //    wResult = UsersDAC.SearchAllUsers(_ProviderName, pCustomUserStoreProcedure);

            return pUserList;
        }
    }
}