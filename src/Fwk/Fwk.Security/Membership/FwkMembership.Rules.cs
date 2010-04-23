using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data;
using System.Data.Common;
using Fwk.Security.Common;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Fwk.Security.Properties;
using Fwk.Exceptions;

namespace Fwk.Security
{
    public partial class FwkMembership
    {
        #region [Rules]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRoleName">Nombre del rol.</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesByRole(string pRoleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetRulesByRole(pRoleName, wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRoleName">Nombre del rol.</param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="pConnectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesByRole(string pRoleName, string applicationName, string pConnectionStringName)
        {
            List<FwkAuthorizationRuleAux> wAllRules = null;

            try
            {

                wAllRules = GetRulesAuxList(applicationName, pConnectionStringName);

                var rules_byRol = from s in wAllRules where s.Expression.Contains(string.Concat("R:", pRoleName.Trim())) select s;

                return rules_byRol.ToList<FwkAuthorizationRuleAux>();

            }
            catch (InvalidOperationException)
            {
             
                TechnicalException te = new TechnicalException(string.Format(Resource.Role_WithoutRules, pRoleName));
                te.ErrorId = "4002";
                te.Source = "FwkMembership blok";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        /// <summary>
        /// Verifica si alguna regla en la base de datos esta vinculada al rol
        /// </summary>
        /// <param name="pRoleName">Nombre del rol.</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static bool AnyRulesHasRole(string pRoleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return AnyRulesHasRole(pRoleName, wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }
        /// <summary>
        /// Verifica si alguna regla en la base de datos esta vinculada al rol
        /// </summary>
        /// <param name="pRoleName">Nmbre del rol </param>
        /// <param name="applicationName">App Id</param>
        /// <param name="pConnectionStringName">nombde de cadena de coneccion</param>
        /// <returns></returns>
        public static bool AnyRulesHasRole(string pRoleName, string applicationName, string pConnectionStringName)
        {
            List<FwkAuthorizationRuleAux> wAllRules = null;
            try
            {
                wAllRules = GetRulesAuxList(applicationName, pConnectionStringName);

                return wAllRules.Any<FwkAuthorizationRuleAux>(s => s.Expression.Contains(string.Concat("R:", pRoleName.Trim())));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static aspnet_Rule GetRule(string ruleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetRule(ruleName, wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="applicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static aspnet_Rule GetRule(string ruleName, string applicationName, string pConnectionStringName)
        {

            aspnet_Rule waspnet_Rule = null;
            try
            {

                Guid wApplicationId = GetApplication(applicationName, pConnectionStringName);

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    if (dc.aspnet_Rules.Any<aspnet_Rule>(s => s.name.Equals(ruleName.Trim()) && s.ApplicationId == wApplicationId))
                    {
                        waspnet_Rule = dc.aspnet_Rules.First<aspnet_Rule>(s => s.name.Equals(ruleName.Trim()) && s.ApplicationId == wApplicationId);


                    }
                    return waspnet_Rule;
                }
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_ProblemGetingData_Error, ruleName), ex);
                te.ErrorId = "4003";
                te.Source = "FwkMembership blok";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }
           
        }

        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static NamedElementCollection<FwkAuthorizationRule> GetRules(string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetRules(wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }

        


        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// Reemplaza aspnet_Rules_s
        /// </summary>
        /// <param name="pConnectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <returns></returns>
        public static NamedElementCollection<FwkAuthorizationRule> GetRules(string applicationName, string pConnectionStringName)
        {



            FwkAuthorizationRule rule = null;
            NamedElementCollection<FwkAuthorizationRule> wRules = null;
            try
            {

                Guid wApplicationId = GetApplication(applicationName, pConnectionStringName);

                wRules = new NamedElementCollection<FwkAuthorizationRule>();
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    var aspnet_Rules = from s in dc.aspnet_Rules where s.ApplicationId == wApplicationId select s;

                    foreach (aspnet_Rule aspnet_Rule in aspnet_Rules.ToList<aspnet_Rule>())
                    {
                        rule = new FwkAuthorizationRule();
                        rule.Name = aspnet_Rule.name.Trim();
                        rule.Expression = aspnet_Rule.expression;


                        wRules.Add(rule);
                    }
                }


                return wRules;
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_ProblemGetingAlls_Error, applicationName), ex);
                te.ErrorId = "4003";
                te.Source = "FwkMembership blok";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="providerName"></param>
        /// <returns></returns>
        public static List<AuthorizationRuleData> GetRulesList(string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetRulesList(wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }

        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="pConnectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <returns></returns>
        public static List<AuthorizationRuleData> GetRulesList(string applicationName, string pConnectionStringName)
        {


            AuthorizationRuleData rule = null;
            List<AuthorizationRuleData> wRules = null;
            try
            {
                Guid wApplicationId = GetApplication(applicationName, pConnectionStringName);
                wRules = new List<AuthorizationRuleData>();
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    var aspnet_Rules = from s in dc.aspnet_Rules where s.ApplicationId == wApplicationId select s;

                    foreach (aspnet_Rule aspnet_Rule in aspnet_Rules.ToList<aspnet_Rule>())
                    {
                        rule = new AuthorizationRuleData();
                        rule.Name = aspnet_Rule.name.Trim();
                        rule.Expression = aspnet_Rule.expression;
                        wRules.Add(rule);
                    }
                }




                return wRules;
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_ProblemGetingAlls_Error, applicationName), ex);
                te.ErrorId = "4004";
                te.Source = "FwkMembership blok";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

        }

        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesAuxList(string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetRulesAuxList(wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }
        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="pConnectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesAuxList(string applicationName, string pConnectionStringName)
        {


            FwkAuthorizationRuleAux rule = null;
            List<FwkAuthorizationRuleAux> wRules = null;
            try
            {
                Guid wApplicationId = GetApplication(applicationName, pConnectionStringName);
                wRules = new List<FwkAuthorizationRuleAux>();
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    var aspnet_Rules = from s in dc.aspnet_Rules where s.ApplicationId == wApplicationId select s;

                    foreach (aspnet_Rule aspnet_Rule in aspnet_Rules.ToList<aspnet_Rule>())
                    {
                        rule = new FwkAuthorizationRuleAux();
                        rule.Name = aspnet_Rule.name.Trim();
                        rule.Expression = aspnet_Rule.expression;
                        wRules.Add(rule);
                    }
                }



                return wRules;
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_ProblemGetingAlls_Error, applicationName), ex);
                te.ErrorId = "4004";
                te.Source = "FwkMembership blok";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

        }


        /// <summary>
        /// Determina si existe una regla.-
        /// </summary>
        /// <param name="pRuleName">Nombre de la regla</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>boolean</returns>
        public static bool ExistRule(string pRuleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return ExistRule(pRuleName, wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }

        /// <summary>
        /// Determina si existe una regla.-
        /// </summary>
        /// <param name="pName">Nombre de la regla</param>
        /// <param name="pConnectionStringName">Nombre de la regla</param>
        /// <returns>boolean</returns>
        public static bool ExistRule(string pRuleName, string applicationName, string pConnectionStringName)
        {
            bool wExist = false;

            try
            {

                Guid wApplicationId = GetApplication(applicationName, pConnectionStringName);

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    wExist = dc.aspnet_Rules.Any(s => s.Equals(pRuleName) && s.ApplicationId == wApplicationId);
                }


                return wExist;
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_ProblemGetingData_Error, pRuleName), ex);
                te.ErrorId = "4004";
                te.Source = "FwkMembership blok";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }
        }

    






        /// <summary>
        /// crea una regla rule
        /// </summary>
        ///<param name="paspnet_Rules">aspnet_Rules</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>void</returns>
        /// <Date>2008-12-22T11:29:57</Date>
        /// <Author>moviedo</Author>
        public static void CreateRule(FwkAuthorizationRule paspnet_Rules, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            CreateRule(paspnet_Rules, wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }


        /// <summary>
        /// Crea una regla
        /// </summary>
        /// <param name="paspnet_Rules"></param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="pConnectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        public static void CreateRule(FwkAuthorizationRule paspnet_Rules, string applicationName, string pConnectionStringName)
        {



            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                Guid wApplicationId = GetApplication(applicationName, pConnectionStringName);

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
                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_Crate_Error, paspnet_Rules.Name), ex);
                te.ErrorId = "4005";
                te.Source = "FwkMembership blok";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

        }


      

        /// <summary>
        /// UpdateRule
        /// </summary>
        /// <param name="paspnet_Rules"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UpdateRule(aspnet_Rule paspnet_Rules, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            UpdateRule(paspnet_Rules, wProvider.ApplicationName, GetProvider_ConnectionStringName(providerName));
        }

        /// <summary>
        /// UpdateRule
        /// </summary>
        /// <param name="paspnet_Rules"></param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="pConnectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        private static void UpdateRule(aspnet_Rule paspnet_Rules, string applicationName, string pConnectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                Guid wApplicationId = GetApplication(applicationName, pConnectionStringName);

                wDataBase = DatabaseFactory.CreateDatabase(pConnectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.Rule_u);
                str.Replace("[ApplicationId]", wApplicationId.ToString());
                str.Replace("[rulename]", paspnet_Rules.name.Trim());
                str.Replace("[expression]", paspnet_Rules.expression);

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
        /// Agrega un rol a la expresion de la regla.- Modifica Expression
        /// </summary>
        /// <param name="pRol"></param>
        /// <param name="pRule"></param>
        public static void Rule_AppenRol(Rol pRol, FwkAuthorizationRuleAux pRule)
        {
            RolList rollistAux = null;
            UserList userList = null;

            Fwk.Security.FwkMembershipScripts.BuildRolesAndUsers_FromRuleExpression(pRule.Expression, out rollistAux, out userList);

            //Agregar el rol a la regla
            rollistAux.Add(pRol);

            pRule.SetExpression(Fwk.Security.FwkMembershipScripts.BuildRuleExpression(rollistAux, userList));
        }

        /// <summary>
        ///  Quita un rol de la expresion de la regla.- Modifica Expression
        /// </summary>
        /// <param name="pRol"></param>
        /// <param name="pRule"></param>
        public static void RuleRemoveRol(Rol pRol, FwkAuthorizationRuleAux pRule)
        {
            RolList rollistAux = null;
            UserList userList = null;

            Fwk.Security.FwkMembershipScripts.BuildRolesAndUsers_FromRuleExpression(pRule.Expression, out rollistAux, out userList);

            //Quitar el rol a la regla si es que existe en la regla
            if (rollistAux.Any<Rol>(r => r.RolName.Equals(pRol.RolName)))
            {
                rollistAux.Remove(rollistAux.First<Rol>(r => r.RolName.Equals(pRol.RolName)));

                pRule.SetExpression(Fwk.Security.FwkMembershipScripts.BuildRuleExpression(rollistAux, userList));
            }



        }
        #endregion
    }
}
