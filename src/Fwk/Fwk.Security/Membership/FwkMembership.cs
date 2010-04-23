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
using System.Web.Configuration;
using System.Configuration;
using Fwk.Security.Properties;
using Fwk.Exceptions;
namespace Fwk.Security
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FwkMembership
    {
        //static  string fwkAuthorizationProviderName_Default = "RuleProvider_Fwk";
        static Dictionary<string, string> providerCnnStrings;
      

        static SecuritySettings _SecuritySettings;
        static MembershipSection _MembershipSection;
        static FwkMembership()
        {
            _SecuritySettings = (SecuritySettings)System.Configuration.ConfigurationManager.GetSection("securityConfiguration");
            _MembershipSection = (MembershipSection)System.Configuration.ConfigurationManager.GetSection("system.web/membership");
            providerCnnStrings = new Dictionary<string, string>();
        }


        /// <summary>
        /// Obtiene la lista de proovedores membership
        /// </summary>
        /// <returns></returns>
        public static List<string> GetAllMembershipProviderNameArray()
        {
            List<string> list = new List<string>();
            foreach (MembershipProvider m in Membership.Providers)
            {
                list.Add(m.Name);
            }

            return list;
        }



        /// <summary>
        /// Esta fncion permite encontrar el proveedor Sql configurado por medio de su nombre
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static SqlMembershipProvider GetSqlMembershipProvider(string providerName)
        {
            SqlMembershipProvider wSqlMembershipProvider;

            if (string.IsNullOrEmpty(providerName))
                wSqlMembershipProvider = (SqlMembershipProvider)Membership.Provider;
            else
                wSqlMembershipProvider = (SqlMembershipProvider)Membership.Providers[providerName];

            if (wSqlMembershipProvider == null)
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.ProviderNameNotFound, providerName));
                te.ErrorId = "4001";
                te.Source = "FwkMembership blok";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

            return wSqlMembershipProvider;

        }

        /// <summary>
        /// Obtiene la cadena de coneccion relacionada al proveedor
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        static string GetProvider_ConnectionStringName(string providerName)
        {

            //if (_SecuritySettings != null)
            //{
            //    Fwk.Security.Configuration.FwkAuthorizationRuleProviderData wProviderData;
            //    if (string.IsNullOrEmpty(providerName))
            //        wProviderData = ((Fwk.Security.Configuration.FwkAuthorizationRuleProviderData)(_SecuritySettings.AuthorizationProviders.Get(Membership.Provider.Name)));
            //    else
            //        wProviderData = ((Fwk.Security.Configuration.FwkAuthorizationRuleProviderData)(_SecuritySettings.AuthorizationProviders.Get(providerName)));

            //    if (wProviderData != null)
            //    {
            //        return wProviderData.ConnectionStringName;
            //    }
            //}
            if (string.IsNullOrEmpty(providerName))
            {
                if (providerCnnStrings.ContainsKey(Membership.Provider.Name))
                    return providerCnnStrings[Membership.Provider.Name];
            }
            else
            {
                if (providerCnnStrings.ContainsKey(providerName))
                    return providerCnnStrings[providerName];
            }

            if (_MembershipSection != null)
            {
                ProviderSettings wProviderSettings;
            
               
                if (string.IsNullOrEmpty(providerName))
                    wProviderSettings = ((ProviderSettings)(_MembershipSection.Providers[Membership.Provider.Name]));
                else
                     wProviderSettings = ((ProviderSettings)(_MembershipSection.Providers[providerName]));

                providerCnnStrings.Add(providerName, wProviderSettings.Parameters["connectionStringName"].ToString());

                if (wProviderSettings != null)
                {
                    return providerCnnStrings[providerName]; 
                }
            }
            return string.Empty;
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


      
    }
}
