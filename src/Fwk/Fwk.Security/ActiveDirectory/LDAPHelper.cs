using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Security;
using System.Data.Linq;
using System.Collections.Specialized;
using System.DirectoryServices.ActiveDirectory;
using Fwk.Exceptions;

namespace Fwk.Security.ActiveDirectory
{
    public class LDAPHelper : DirectoryServicesBase, IDirectoryService
    {
        private LdapWrapper _LdapWrapper;
        private DomainUrlInfo _DomainUrlInfo;
        private DomainController _DomainController;

        #region Constructors

        public LDAPHelper (String pDomainName, String pConnString) : this(pDomainName, pConnString, false) { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pDomainName">Nombre corto del dominio, por ej "ALCO"</param>
        /// <param name="pConnString">Nombre de la cadena conexión de la base de datos de la tabla UrlDomains</param>
        /// <param name="pSecure">Especifica si establece una conexión SSL</param>
        public LDAPHelper (String pDomainName, String pConnString, Boolean pSecure) 
        {
            _LdapWrapper = new LdapWrapper();

            String conn = System.Configuration.ConfigurationManager.ConnectionStrings[pConnString].ConnectionString;

            List<DomainUrlInfo> wDomainList = DomainsUrl_GetList2(conn);
            if (wDomainList == null)
            {
                throw new Fwk.Exceptions.TechnicalException("Error al intentar obtener la lista de dominios: La lista se encuentra vacía.");
            }
            
            _DomainUrlInfo = wDomainList.First<DomainUrlInfo>(p => p.DomainName == pDomainName);
            if (_DomainUrlInfo == null)
            {
                throw new Fwk.Exceptions.TechnicalException("No se encontró la información del dominio especificado");
            }

            List<DomainController> wDCList = GetDomainControllersByDomainId(conn, _DomainUrlInfo.Id);
            if (wDCList == null || wDCList.Count == 0)
            {
                throw new Fwk.Exceptions.TechnicalException("No se encuentra configurado ningún controlador de dominio para el sitio especificado.");
            }

            // Prueba de conectarse a algún controlador de dominio disponible, siempre arranando del primero. debería 
            // TODO: reemplazarse por un sistema de prioridad automática para que no intente conectarse primero a los funcionales conocidos
            LdapException wLastExcept = GetDomainController(pSecure, wDCList);
            if (_DomainController == null)
            {
                throw new Fwk.Exceptions.TechnicalException("No se encontró ningún controlador de dominio disponible para el sitio especificado.", wLastExcept);
            }

        }
        #endregion

        #region Interface Methods

        /// <summary>
        /// Obtiene un usuario de LDAP por nombre
        /// </summary>
        public ADUser User_Get_ByName(string pUserName)
        {
            ADUser wADUser;
            String wFilter;
            String[] wAttributes;
            LdapEntryList wResults;

            // Parámetros de búsqueda
            wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
            wAttributes = new String[0]; // array vacío, para que traiga todos los disponibles
            wResults = new LdapEntryList();

            // Busca y verifica que exista el usuario
            if (_LdapWrapper.Search(wFilter, wAttributes, wResults) > 0)
            {
                wADUser = new ADUser(wResults.First<LdapEntry>());
                return wADUser;
            }
            return null;
        }

        /// <summary>
        /// Devuelve true o false según el usuario especificado exista en LDAP
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        public bool User_Exists(string pUserName)
        {
            String wFilter;
            Int32 wTotal;
            wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
            wTotal = _LdapWrapper.Search(wFilter, null, null); // attributos y resultado en null.. solo cuenta la cantidad
            return (wTotal == 0);
        }

        /// <summary>
        /// Obtiene la lista de Grupos de LDAP a los que pertenece el usuario
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        public List<ADGroup> User_SearchGroupList(string pUserName)
        {
            List<ADGroup> wGroups = null;
            String wFilter;
            String[] wAttributes;
            LdapEntryList wResults;

            ADGroup wADGroup;

            // Parámetros de búsqueda
            wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
            wAttributes = new String[1]; // array vacío, para que traiga todos los disponibles
            wAttributes[0] = ADProperties.MEMBEROF;
            wResults = new LdapEntryList();

            // Busca y verifica que exista el usuario
            if (_LdapWrapper.Search(wFilter, wAttributes, wResults) > 0)
            {
                LdapEntry wUser = wResults.First<LdapEntry>();
                if (wUser.ContainsKey(ADProperties.MEMBEROF))
                {
                    foreach (String wGrp in wUser[ADProperties.MEMBEROF])
                    {
                        foreach (string wG in GetGroupFromMemberOf(wGrp))
                        {
                            wADGroup = Group_GetByName(wG);
                            if (wADGroup != null)
                                wGroups.Add(wADGroup);
                        }                        
                    }
                }
            }
            return null; 
        }

        /// <summary>
        /// Autentica un usuario
        /// </summary>
        /// <param name="pUserName">Nombre de usuario</param>
        /// <param name="pPassword">Clave</param>
        public LoginResult User_CheckLogin(string pUserName, string pPassword)
        {

            String wFilter;
            String[] wAttributes;
            LdapEntryList wResults;

            // Parámetros de búsqueda
            wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
            wAttributes = new String[3];
            wAttributes[0] = ADProperties.USERACCOUNTCONTROL;
            wAttributes[1] = ADProperties.PWDLASTSET;
            wAttributes[2] = "lockoutTime"; // TODO: agregar "lockoutTime" a la clase ADProperties;
            wResults = new LdapEntryList();

            // Busca y verifica que exista el usuario
            if (_LdapWrapper.Search(wFilter, wAttributes, wResults) == 0)
            {
                return LoginResult.LOGIN_USER_DOESNT_EXIST;
            }

            // Verifica que la cuenta no esté deshabilitada
            Int32 wUserAccountControl = Convert.ToInt32(wResults.First()[ADProperties.USERACCOUNTCONTROL].First());
            Int32 wUserAccountControlDisabled = Convert.ToInt32(ADAccountOptions.UF_ACCOUNTDISABLE);
            if ((wUserAccountControl & wUserAccountControlDisabled) != 0)
            {
                return LoginResult.LOGIN_USER_ACCOUNT_INACTIVE;
            }

            if (wResults.First().ContainsKey("lockoutTime"))
            {
                Int64 wLockOutTime = Convert.ToInt64(wResults.First()["lockoutTime"].First());
                if (wLockOutTime > 0)
                {
                    return LoginResult.LOGIN_USER_ACCOUNT_LOCKOUT;
                }
            }

            // Verifica que no deba cambiar la clave
            Int64 wPwdLastSet = Convert.ToInt64(wResults.First()[ADProperties.PWDLASTSET].First());
            if (wPwdLastSet == 0)
            {
                return LoginResult.ERROR_PASSWORD_MUST_CHANGE;
            }

            // Autentica
            try
            {
                if (!_LdapWrapper.Bind(_DomainController.HostName, _DomainUrlInfo.DomainDN, pUserName, pPassword, false))
                {
                    return LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;
                }
            }
            catch (LdapAuthenticationException)
            {
                return LoginResult.LOGIN_USER_OR_PASSWORD_INCORRECT;                
            }

            // Pasó hasta acá, login OK
            return LoginResult.LOGIN_OK;
        }

        /// <summary>
        /// Obtiene un Grupo de LDAP, dado un nombre
        /// </summary>
        public ADGroup Group_GetByName(string pName)
        {
            String wFilter;
            String[] wAttributes;
            LdapEntryList wResults;

            // Parámetros de búsqueda
            wFilter = String.Format("(&(objectClass=group)(sAMAccountName={0}))", pName);
            wAttributes = new String[0]; // todos lso atributos disponibles
            wResults = new LdapEntryList(); // buffer de resultados

            // Busca y verifica que exista el usuario
            if (_LdapWrapper.Search(wFilter, wAttributes, wResults) == 0)
            {
                return new ADGroup(wResults.First<LdapEntry>());
            }
            return null;
        }

        /// <summary>
        /// Obtiene la lista completa de grupos del LDAP
        /// </summary>
        public List<ADGroup> Groups_GetAll()
        {
            List<ADGroup> wGroups = null;
            String wFilter;
            String[] wAttributes;
            LdapEntryList wResults;

            ADGroup wADGroup;

            // Parámetros de búsqueda
            wFilter = "(&(objectClass=group))";
            wAttributes = new String[0]; // array vacío, para que traiga todos los disponibles
            wResults = new LdapEntryList();

            // Busca y verifica que exista el usuario
            if (_LdapWrapper.Search(wFilter, wAttributes, wResults) > 0)
            {
                foreach (LdapEntry wGrp in wResults)
                {
                    wADGroup = new ADGroup(wGrp);
                    if (wADGroup != null)
                        wGroups.Add(wADGroup);
                }
            }
            return null;
        }

        /// <summary>
        /// Resetea la clave de un usuario de LDAP
        /// </summary>
        /// <param name="pUserName">Nombre de usuario de la cuenta a la que se resetea la clave</param>
        /// <param name="pNewPwd">Nuevo Password, en caso de ser NULL, no se resetea la cuenta, se realizan el resto de las acciones</param>
        /// <param name="pForceChangeOnFirstLogon">Cuando es true, fuerza al usuario a cambiar la clave especificada en el próximo login</param>
        /// <param name="pUnlockAccount">Cuando es true, desbloquea la cuenta</param>
        public void ResetPwd(string pUserName, string pNewPwd, bool pForceChangeOnFirstLogon, bool pUnlockAccount)
        {
            String wUserDN = GetUserDN(pUserName);
            _LdapWrapper.SetPassword(wUserDN, pNewPwd, pForceChangeOnFirstLogon, pUnlockAccount);
        }

        #endregion

        #region Métodos Privados

        /// <summary>
        /// Obtiene el nombre distinguido de la entrada de LDAP, para un usuario específico
        /// </summary>
        /// <param name="pUserName">Nombre de Usuario</param>
        private String GetUserDN(string pUserName)
        {

            String pUserDN;
            String wFilter;
            String[] wAttributes;
            LdapEntryList wResults;

            // parámetros de búsqueda
            wFilter = String.Format("(&(objectClass=user)(sAMAccountName={0}))", pUserName);
            wAttributes = new String[10];
            wAttributes[0] = ADProperties.DISTINGUISHEDNAME;
            wResults = new LdapEntryList();

            if (_LdapWrapper.Search(wFilter, wAttributes, wResults) == 0)
            {
                throw new TechnicalException("No se encuentra el usuario");
            }
            pUserDN = wResults.First()[ADProperties.DISTINGUISHEDNAME].First();
            return pUserDN;
        }

        /// <summary>
        /// Obtiene la lista de controladores de dominio para un DomainID especificado
        /// </summary>
        private List<DomainController> GetDomainControllersByDomainId(String pConnString, Int32 pDomainId)
        {
            try
            {
                using (SqlDomainControllersDataContext dc = new SqlDomainControllersDataContext(pConnString))
                {
                    IEnumerable<DomainController> list = from s in dc.DomainControllers
                                                         where s.DomainId == pDomainId
                                                          select
                                                          new DomainController
                                                          {
                                                              DomainId = s.DomainId,
                                                              HostName = s.DCHostName,
                                                              Id = s.DCId,
                                                              Ip = s.DCIp
                                                          };
                     return list.ToList<DomainController>();
                }
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al intentar obtener la lista de dominios desde la base de datos: ", ex);
                LDAPHelper .SetError(te);
                te.ErrorId = "15004";
                throw te;
            }
        }

        /// <summary>
        /// Recibe una lista de controladores de dominio, trata de estaclecer conexión con alguno de ellos. 
        /// Retorna una lista de expceciones de los intentos fallidos
        /// </summary>
        /// <param name="pSecure">Especifica si debe establecer conexion SSL</param>
        /// <param name="wDCList">Lista de controladores de dominio</param>
        private LdapException GetDomainController(Boolean pSecure, List<DomainController> wDCList)
        {
            LdapException wLastExcept = null;
            foreach (DomainController wDC in wDCList)
            {
                try
                {
                    if (_LdapWrapper.Bind(wDC.HostName, _DomainUrlInfo.DomainDN, _DomainUrlInfo.Usr, _DomainUrlInfo.Pwd, pSecure))
                    {
                        _DomainController = wDC;
                        break;
                    }
                }
                catch (LdapAuthenticationException ex)
                {
                    // si no autentica, es porque está mal la info Usr y Pwd
                    throw ex;
                }
                catch (LdapException ex)
                {
                    // si entra por acá es porque no pudo conectar, continuo con el siguiente
                    //throw;
                    wLastExcept = ex;
                }
            }
            return wLastExcept;
        }

        #endregion
    }
}
