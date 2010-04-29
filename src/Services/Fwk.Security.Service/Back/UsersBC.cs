using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Security;
using Fwk.Bases;
using Fwk.Exceptions;
using Fwk.Security.BE;
using System.Data;
using Fwk.Security.Common;
using System.Web.Security;
using Fwk.Security;
using System.Linq;
using Fwk.Security.ISVC.GetUserAdditionalAttributesValues;
using Fwk.Security.ActiveDirectory;
using System.Security.Authentication;
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
        /// <param name="pRolList">Roles del usuario</param>
        /// <returns>UserId del nuevo usuario.</returns>
        public void Create(UsersBE pUserBE, RolList pRolList)
        {
            MembershipCreateStatus wStatus;
            Validate(pUserBE, true);
            UpdateModifiedSignature(pUserBE);

            if (!String.IsNullOrEmpty(pUserBE.PasswordQuestion) && (!String.IsNullOrEmpty(pUserBE.Answer)))
            {
                FwkMembership.CreateUser(pUserBE.Name, pUserBE.Password, pUserBE.Mail, pUserBE.PasswordQuestion, pUserBE.Answer, pUserBE.IsApproved.Value, out wStatus,_ProviderName);
                //Preguntamos por el valor de Wstatus para ver como proseguimos.
                switch (wStatus)
                {
                    case MembershipCreateStatus.Success:
                        UsersDAC.Create(pUserBE,CompanyId);
                        break;
                    case MembershipCreateStatus.DuplicateUserName:
                        throw new FunctionalException(String.Format("Ya existe un usuario con el nombre \'{0}\'", pUserBE.Name));
                    default:
                        break;
                }
            }
            else
            {
                FwkMembership.CreateUser(pUserBE.Name, pUserBE.Password, pUserBE.Mail);
                UsersDAC.Create(pUserBE,CompanyId);
            }
            if (pRolList != null)
                FwkMembership.CreateRolesToUser(pRolList, pUserBE.Name,_ProviderName);
        }

        /// <summary>
        /// Actualiza los datos del usuario.
        /// </summary>
        /// <param name="pUserBE"></param>
        public void Update(UsersBE pUserBE, RolList pRolList)
        {

            Validate(pUserBE, false);


            ///Update Bigbang Security.User
            UsersDAC.Update(pUserBE,this.CompanyId);

            User user = new User(pUserBE.Name);



            user.IsApproved = pUserBE.IsApproved.Value;
            //user.Password = pUserBE.Password;
            user.QuestionPassword = pUserBE.PasswordQuestion;
            user.AnswerPassword = pUserBE.Answer;
            user.Email = pUserBE.Mail;





            FwkMembership.UpdateUser(user, pUserBE.Name);

            if (pRolList != null)
            {
                RolList usrRoles = FwkMembership.GetRolesForUser(pUserBE.Name,_ProviderName);
                FwkMembership.RemoveUserFromRoles(pUserBE.Name, usrRoles,_ProviderName);
                FwkMembership.CreateRolesToUser(pRolList, pUserBE.Name,_ProviderName);


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

            UsersBE wUserBE = UsersDAC.GetByName(pUserName,CompanyId);
            wUserBE.MustChangePassword = false;
            UsersDAC.Update(wUserBE,_ProviderName);

        }
        /// <summary>
        /// Obtiene información sobre los usuarios activos.
        /// </summary>
        /// <returns></returns>
        public UserInfoList GetAllActiveUsersInfo()
        {
            UserInfoList usersInfoList = new UserInfoList();

            using (IDataReader reader = UsersDAC.GetAllActiveUsersInfo(this.CompanyId))
            {

                while (reader.Read())
                {
                    UserInfo userInfo = new UserInfo();
                    userInfo.Name = Convert.ToString(reader["name"]);
                    userInfo.UserId = Convert.ToInt32(reader["UserID"]);
                    userInfo.FullName = Convert.ToString(reader["FullName"]);
                    usersInfoList.Add(userInfo);
                }
            }
            return usersInfoList;
        }

        /// <summary>
        /// Valida los campos del usuario.
        /// </summary>
        /// <param name="pUserBE">UsersBE a validar.</param>
        /// <param name="pIsNewUser">Si es nuevo se verifica de otra forma</param>
        private void Validate(UsersBE pUserBE, bool pIsNewUser)
        {

            //Validación

            //Nombre vacio
            if (String.IsNullOrEmpty(pUserBE.Name))
            {
                throw new FunctionalException(null, "NullOrEmptyField", "ValidationExceptionMessage", "Nombre usuario");
            }



            if (pIsNewUser)
            {
                //Nombre ya existente
                if (UsersDAC.ExistsWithName(pUserBE.Name,this.CompanyId))
                {
                    throw new FunctionalException(String.Format("Ya existe un usuario con el nombre \'{0}\'", pUserBE.Name));
                }


            }

        }

        /// <summary>
        /// Actualiza la marca de modificación del objeto, se utiliza antes de guardar.
        /// </summary>
        /// <param name="pUserBE">UsersBE a actualizar.</param>
        private void UpdateModifiedSignature(UsersBE pUserBE)
        {

            //Todo: Implementar la obtención real del ID del usuario que está modificando el objeto.
            pUserBE.ModifiedDate = DateTime.Now;
            pUserBE.ModifiedByUserId = 1;

        }

        /// <summary>
        /// Cambia la vigencia usuario solo en bigbang
        /// </summary>
        /// <param name="pUserBE">UsersBE a eliminar</param>
        public void ChangeActiveFlag(string pUserName, bool pIsActive)
        {

            // al usuario de las Security no se lo puede eliminar, puede tener registros vinculados
            // se lo debe anular de alguna forma
            UsersDAC.ActiveFlag(pUserName, pIsActive,CompanyId);
        }

        public UserInfo GetUserInfoByName(string userName)
        {
            UserInfo wUserInfo = UsersDAC.GetUserInfoByName(userName, CompanyId);

            if (wUserInfo == null)
            {
                throw new FunctionalException("No se encontró ningún usuario");
            }

            RolList wRolList = FwkMembership.GetRolesForUser(userName,_ProviderName);
            wUserInfo.Roles = wRolList.GetArrayNames();
            return wUserInfo;
        }

        /// <summary>
        ///  Este metodo es para se usado cuano la autenticacion es integrada con windows
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserInfo AuthenticateUser(string userName)
        {
            UserInfo wUserInfo = null;
            User wUser = Fwk.Security.FwkMembership.GetUser(userName,_ProviderName);

            if (wUser == null)
                throw new FunctionalException("No es un usuario registrado en Bigbang para ingresar al sistema.");

            if (!wUser.IsApproved)
                throw new FunctionalException(string.Format("El usuario '{0}' no es un usuario aprobado. Pongase en contacto con su administrador de bigbang.", userName));

            wUserInfo = GetUserInfoByName(userName);

            if (wUserInfo != null)
            {
                //wUserInfo.Roles = System.Web.Security.Roles.GetRolesForUser(userName);

                //El sistema verifica si el usuario se encuentra vigente.
                if (!wUserInfo.ActiveFlag)
                {
                    //Y no cumple con la condición. El sistema informa la situación.
                    //El mensaje a mostrar es el siguiente: “El usuario ingresado no se encuentra vigente”. Se cancela el CU
                    throw new FunctionalException("El usuario ingresado no se encuentra vigente.");
                }
            }

            return wUserInfo;
        }

        /// <summary>
        /// Este metodo es para se usado cuano la autenticacion es solo de bigbang
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <returns></returns>
        public UserInfo AuthenticateUser(string pUserName, string pPassword)
        {

            bool wValidateUser = Fwk.Security.FwkMembership.ValidateUser(pUserName, pPassword,_ProviderName);

            if (wValidateUser == false)
            {
                throw new FunctionalException("Nombre de usuario o contraseña no válida. Verifique sus datos por favor, e intentelo nuevamente.");
            }

            return this.AuthenticateUser(pUserName);

        }

        /// <summary>
        /// Este metodo es para se usado cuano la autenticacion contra LDAP
        /// </summary>
        /// <param name="pUserName"></param>
        /// <param name="pPassword"></param>
        /// <param name="pDomain"></param>
        /// <returns></returns>
        public UserInfo AuthenticateUser(string pUserName, string pPassword, string pDomain)
        {

            ADHelper wADHelper = new Fwk.Security.ActiveDirectory.ADHelper(pDomain);
            LoginResult wLoginResult = wADHelper.User_CheckLogin(pUserName, pPassword);
            switch (wLoginResult)
            {
                case LoginResult.LOGIN_OK:
                    //pasa
                    break;
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

            UserInfo wUserInfo = this.AuthenticateUser(pUserName);

            // Se baja el Flag MustChangePassword porque es solo para autenticación Mixta, no importa el valor que tenga
            wUserInfo.MustChangePassword = false;

            return wUserInfo;
        }


        public  UsersBEList SearchUnassignedUsers()
        {
            return UsersDAC.SearchUnassignedUsers(CompanyId);
        }

        public  UsersBEList GetUnassignedUsersByParam(Fwk.Security.ISVC.GetUnassignedUsersByParam.UsersBE pUsersBE)
        {
            return UsersDAC.GetUnassignedUsersByParam(pUsersBE,CompanyId);
        }

        public  UserAdditionalAttributesBEList GetUserAdditionalAttributes_ByParam(bool? pActiveFlag)
        {
            UserAdditionalAttributesBEList wBE = new UserAdditionalAttributesBEList();
            wBE = UsersDAC.GetUserAdditionalAttributes_ByParam(pActiveFlag,CompanyId);

            return wBE;

        }

        internal  void SaveUserAdditionalAttributes(UserAdditionalAttributesBEList pUserAdditionalAttributesBEList)
        {
            // se obtienen los nuevos
            List<UserAdditionalAttributesBE> wNew = (from item in pUserAdditionalAttributesBEList
                                                     where item.AttributesState == EntityState.Added
                                                     select item).ToList<UserAdditionalAttributesBE>();
            // los eliminados
            List<UserAdditionalAttributesBE> wDeleted = (from item in pUserAdditionalAttributesBEList
                                                         where item.AttributesState == EntityState.Deleted
                                                         select item).ToList<UserAdditionalAttributesBE>();

            // los eliminados
            List<UserAdditionalAttributesBE> wChanged = (from item in pUserAdditionalAttributesBEList
                                                         where item.AttributesState == EntityState.Changed
                                                         select item).ToList<UserAdditionalAttributesBE>();

            UsersDAC.UserAdditionalAttributes_InsertBatch(wNew, CompanyId);
            UsersDAC.UserAdditionalAttributes_DeleteBatch(wDeleted,this.CompanyId);
            UsersDAC.UserAdditionalAttributes_UpdateBatch(wChanged, CompanyId);


        }

        internal  UserAdditionalAttributesValuesBEList GetUserAdditionalAttributesValues_ByParam(GetUserAdditionalAttributesValues_ByParamRequest pServiceRequest)
        {
            return UsersDAC.GetUserAdditionalAttributesValues_ByParam(pServiceRequest.BusinessData.UserAttributeId, pServiceRequest.BusinessData.UserId, pServiceRequest.BusinessData.ActiveFlag, CompanyId);
        }

        internal  Boolean GetUserAdditionalAttributesValues_ByUserAttributeId(Int32 pUserAttributeId)
        {
            return UsersDAC.UserAdditionalAttributesValues_Exist_ByUserAttributeId(pUserAttributeId, CompanyId);
        }

        internal  void SaveUserAdditionalAttributesValues(UserAdditionalAttributesValuesBEList pUserAdditionalAttributesValuesBEList)
        {
            UsersDAC.SaveUserAdditionalAttributesValuesBatch(pUserAdditionalAttributesValuesBEList, CompanyId);
        }

        internal  void UpdateUserAdditionalAttributes(UserAdditionalAttributesValuesBEList pUserAdditionalAttributesValuesBEList)
        {
            UsersDAC.UpdateUserAdditionalAttributesValuesBatch(pUserAdditionalAttributesValuesBEList, CompanyId);
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


        internal void Create(DataTable pDataToImport, string pServerName, string pDataBaseName,
            Fwk.Security.ISVC.CreateUsersBatch.ColumnsMappingBEList pColumnsMappingBEList,
            Boolean pImportFromDB, out DataTable pImportedErrorsTable, out DataTable pImportedRepeatedTable,
            out int pTotalSuccefull, out int pTotalErrors, out int pTotalRepeated)
        {
            pImportedErrorsTable = null;
            pImportedRepeatedTable = null;
            pTotalSuccefull = 0;
            pTotalErrors = 0;
            pTotalRepeated = 0;


            if ((pDataToImport == null) && (pDataToImport.Rows.Count > 0))
            {


            }



        }
    }
}