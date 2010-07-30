using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.DirectoryServices;
using Fwk.Configuration;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using System.DirectoryServices.Protocols;
using System.DirectoryServices.ActiveDirectory;
using Fwk.Exceptions;
using System.DirectoryServices.AccountManagement;
using System.Reflection;
namespace Fwk.Security.ActiveDirectory
{
    /// <summary>
    /// Wrapper base de para interactuar con Servicios de Directorio
    /// 
    /// </summary>
    public class DirectoryServicesBase
    {
        #region Properties
        protected DirectoryEntry _directoryEntrySearchRoot;
        protected string _LDAPPath;
        protected string _LDAPDomain;
        protected string _LDAPUser;
        protected string _LDAPPassword;

        /// <summary>
        ///Ej: 
        ///LDAP://domain/DC=xxx,DC=com
        ///LDAP://CORRSF71NT13.actionlinecba.org/DC=actionlinecba,DC=org
        ///LDAP://Corba362nt01.alcomovistar.com.ar/OU=Movistar Sabattini,dc=alcomovistar,dc=com,dc=ar
        /// </summary>
        public String LDAPPath
        {
            get
            {
                return _LDAPPath;
            }

        }


        /// <summary>
        ///LDAPUser property
        /// </summary>
        public String LDAPUser
        {
            get
            {
                return _LDAPUser;
            }

        }

        /// <summary>
        /// LDAPPassword property
        ///This property is reading the LDAP Password from the config file.
        /// </summary>
        public String LDAPPassword
        {
            get
            {
                return _LDAPPassword;
            }

        }


        /// <summary>
        /// Dominio
        /// </summary>
        public String LDAPDomain
        {
            get
            {
                return _LDAPDomain;
            }

        }
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="memberOf"></param>
        /// <returns></returns>
        public static List<string> GetGroupFromMemberOf(string memberOf)
        {
            int i = 0;
            string[] propAux;
            List<String> list = new List<String>();
            foreach (string prop in memberOf.Split(','))
            {
                propAux = prop.Split('=');

                if (propAux[0].CompareTo("CN") == 0)
                {
                    list.Add(propAux[1]);
                    i++;
                }

            }
            return list;
        }

        /// <summary>
        /// Busca la lista de dominios en una base de datos
        /// </summary>
        /// <param name="cnnStringName">Nombre de la cadena de coneccion configurada</param>
        /// <returns>Lista de DomainsUrl</returns>
        public static List<DomainUrlInfo> DomainsUrl_GetList(string cnnStringName)
        {
            return DomainsUrl_GetList2(System.Configuration.ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString);
        }
        /// <summary>
        /// Busca la lista de dominios en una base de datos.- A diferencia de DomainsUrl_GetList. Este metodo recive como parametro 
        /// la cadena de coneccion y no su nombre de App.config
        /// </summary>
        /// <param name="cnnString">Cadena de coneccion</param>
        /// <returns>Lista de DomainsUrl</returns>
        public static List<DomainUrlInfo> DomainsUrl_GetList2(string cnnString)
        {
            try
            {
                using (SqlDomainURLDataContext dc = new SqlDomainURLDataContext(cnnString))
                {
                    IEnumerable<DomainUrlInfo> list = from s in dc.DomainsUrls
                                                      select
                                                          new DomainUrlInfo
                                                          {
                                                              DomainName = s.DomainName,
                                                              LDAPPath = s.LDAPPath,
                                                              Usr = s.Usr,
                                                              Pwd = s.Pwd,
                                                              Id = s.DomainID,
                                                              SiteName = s.SiteName,
                                                              DomainDN = s.DomainDN
                                                          };
                    return list.ToList<DomainUrlInfo>();
                }
            }
            catch (Exception ex)
            {
                Fwk.Exceptions.TechnicalException te = new Fwk.Exceptions.TechnicalException("Error al intentar obtener la lista de dominios desde la base de datos: ", ex);
                LDAPHelper.SetError(te);
                te.ErrorId = "15004";
                throw te;
            }
        }

        /// <summary>
        /// Establece los valores basicos de error producido en el componente ADHelper
        /// </summary>
        /// <param name="te"></param>
        protected static void SetError(Fwk.Exceptions.TechnicalException te)
        {
            te.Namespace = typeof(ADHelper).Namespace;
            te.Source = "Constructor fwk active directory component";
            te.UserName = Environment.UserName;
            te.UserName = Environment.MachineName;
        }
    }
}
