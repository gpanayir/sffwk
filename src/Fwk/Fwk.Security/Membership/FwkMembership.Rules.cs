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
        /// <param name="roleName">Nombre del rol.</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static List<FwkAuthorizationRule> GetRulesByRole(string roleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetRulesByRole(roleName, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="roleName">Nombre del rol.</param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <returns></returns>
        public static List<FwkAuthorizationRule> GetRulesByRole(string roleName, string applicationName, string connectionStringName)
        {
            List<FwkAuthorizationRule> wAllRules = null;

            try
            {

                wAllRules = GetRulesAuxList(applicationName, connectionStringName);

                var rules_byRol = from s in wAllRules where s.Expression.Contains(string.Concat("R:", roleName.Trim())) select s;

                return rules_byRol.ToList<FwkAuthorizationRule>();

            }
            catch (InvalidOperationException)
            {
             
                TechnicalException te = new TechnicalException(string.Format(Resource.Role_WithoutRules, roleName));
                te.ErrorId = "4002";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        
        /// <summary>
        /// Verifica si alguna regla en la base de datos esta vinculada al rol
        /// </summary>
        /// <param name="roleName">Nombre del rol.</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static bool AnyRulesHasRole(string roleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return AnyRulesHasRole(roleName, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }
        /// <summary>
        /// Verifica si alguna regla en la base de datos esta vinculada al rol
        /// </summary>
        /// <param name="roleName">Nmbre del rol </param>
        /// <param name="applicationName">App Id</param>
        /// <param name="connectionStringName">nombde de cadena de coneccion</param>
        /// <returns></returns>
        public static bool AnyRulesHasRole(string roleName, string applicationName, string connectionStringName)
        {
            List<FwkAuthorizationRule> wAllRules = null;
            try
            {
                wAllRules = GetRulesAuxList(applicationName, connectionStringName);

                return wAllRules.Any<FwkAuthorizationRule>(s => s.Expression.Contains(string.Concat("R:", roleName.Trim())));


            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static FwkAuthorizationRule GetRule(string ruleName, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetRule(ruleName, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

      
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ruleName"></param>
        /// <param name="applicationName"></param>
        /// <param name="connectionStringName"></param>
        /// <returns></returns>
        public static FwkAuthorizationRule GetRule(string ruleName, string applicationName, string connectionStringName)
        {

            aspnet_Rule waspnet_Rule = null;
            try
            {

                Guid wApplicationId = GetApplication(applicationName, connectionStringName);

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                {
                    if (dc.aspnet_Rules.Any<aspnet_Rule>(s => s.name.Equals(ruleName.Trim()) && s.ApplicationId == wApplicationId))
                    {
                        waspnet_Rule = dc.aspnet_Rules.First<aspnet_Rule>(s => s.name.Equals(ruleName.Trim()) && s.ApplicationId == wApplicationId);


                    }
                    return new FwkAuthorizationRule(waspnet_Rule.name,waspnet_Rule.expression,waspnet_Rule.ApplicationId.Value);
                }
            }
            catch (Exception ex)
            {

                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_ProblemGetingData_Error, ruleName), ex);
                te.ErrorId = "4003";
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
            return GetRules(wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

        


        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// Reemplaza aspnet_Rules_s
        /// </summary>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <returns></returns>
        public static NamedElementCollection<FwkAuthorizationRule> GetRules(string applicationName, string connectionStringName)
        {



            FwkAuthorizationRule rule = null;
            NamedElementCollection<FwkAuthorizationRule> wRules = null;
            try
            {

                Guid wApplicationId = GetApplication(applicationName, connectionStringName);

                wRules = new NamedElementCollection<FwkAuthorizationRule>();
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
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
            return GetRulesList(wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <returns></returns>
        public static List<AuthorizationRuleData> GetRulesList(string applicationName, string connectionStringName)
        {


            AuthorizationRuleData rule = null;
            List<AuthorizationRuleData> wRules = null;
            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);
                wRules = new List<AuthorizationRuleData>();
                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
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
               
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

        }

        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static FwkAuthorizationRuleList GetRulesAuxList(string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            return GetRulesAuxList(wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }
        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        /// <returns></returns>
        public static FwkAuthorizationRuleList GetRulesAuxList(string applicationName, string connectionStringName)
        {


            FwkAuthorizationRule rule = null;
            FwkAuthorizationRuleList wRules = null;
            try
            {
               

                Guid wApplicationId = GetApplication(applicationName, connectionStringName);
                wRules = new FwkAuthorizationRuleList();

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
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
                te.ErrorId = "4004";
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
            return ExistRule(pRuleName, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

        /// <summary>
        /// Determina si existe una regla.-
        /// </summary>
        /// <param name="pRuleName">Nombre de la regla</param>
        /// <param name="applicationName">Nombre de la aplicación</param>
        /// <param name="connectionStringName">Nombre de la regla</param>
        /// <returns>boolean</returns>
        public static bool ExistRule(string pRuleName, string applicationName, string connectionStringName)
        {
            bool wExist = false;

            try
            {

                Guid wApplicationId = GetApplication(applicationName, connectionStringName);

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString))
                {
                    wExist = dc.aspnet_Rules.Any(s => s.Equals(pRuleName) && s.ApplicationId == wApplicationId);
                }


                return wExist;
            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_ProblemGetingData_Error, pRuleName), ex);
                te.ErrorId = "4004";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }
        }

    






        /// <summary>
        /// crea una regla rule si es que la regla todavia no existe
        /// </summary>
        ///<param name="rule">aspnet_Rules</param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns>void</returns>
        /// <Date>2010-12-22T11:29:57</Date>
        /// <Author>moviedo</Author>
        public static void CreateRule(FwkAuthorizationRule rule, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            string cnn = GetProvider_ConnectionStringName(wProvider.Name);
           

            CreateRule(rule, wProvider.ApplicationName, cnn);
        }


        /// <summary>
        /// Crea una regla
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        public static void CreateRule(FwkAuthorizationRule rule, string applicationName, string connectionStringName)
        {
            //Verificar si ya existe
            if (FwkMembership.ExistRule(rule.Name, applicationName, connectionStringName))
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_ExistError, rule.Name));
                te.ErrorId = "4004";
                throw te;
            }

            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);

                wDataBase = DatabaseFactory.CreateDatabase(connectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.Rule_i);
                str.Replace("[ApplicationId]", wApplicationId.ToString());
                str.Replace("[rulename]", rule.Name.Trim());
                str.Replace("[expression]", rule.Expression);

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;



                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_Crate_Error, rule.Name), ex);
                te.ErrorId = "4005";
                Fwk.Exceptions.ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                throw te;
            }

        }


      

        /// <summary>
        /// UpdateRule
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        public static void UpdateRule(FwkAuthorizationRule rule, string providerName)
        {
            SqlMembershipProvider wProvider = GetSqlMembershipProvider(providerName);
            UpdateRule(rule, wProvider.ApplicationName, GetProvider_ConnectionStringName(wProvider.Name));
        }

        /// <summary>
        /// UpdateRule
        /// </summary>
        /// <param name="rule"></param>
        /// <param name="applicationName">Nombre de la aplicacion. Coincide con CompanyId en la arquitectura</param>
        /// <param name="connectionStringName">Nombre de cadena de coneccion del archivo de configuracion.-</param>
        private static void UpdateRule(FwkAuthorizationRule rule, string applicationName, string connectionStringName)
        {
            //Verificar si existe
            if (!FwkMembership.ExistRule(rule.Name, applicationName, connectionStringName))
            {
                TechnicalException te = new TechnicalException(string.Format(Resource.Rule_NotExist, rule.Name));
                te.ErrorId = "4004";
                throw te;
            }
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                Guid wApplicationId = GetApplication(applicationName, connectionStringName);

                wDataBase = DatabaseFactory.CreateDatabase(connectionStringName);
                StringBuilder str = new StringBuilder(FwkMembershipScripts.Rule_u);
                str.Replace("[ApplicationId]", wApplicationId.ToString());
                str.Replace("[rulename]", rule.Name.Trim());
                str.Replace("[expression]", rule.Expression);

                wCmd = wDataBase.GetSqlStringCommand(str.ToString());
                wCmd.CommandType = CommandType.Text;



                wDataBase.ExecuteNonQuery(wCmd);

            }
            catch (Exception ex)
            {
                TechnicalException te = new TechnicalException(Fwk.Security.Properties.Resource.MembershipSecurityGenericError, ex);
                ExceptionHelper.SetTechnicalException<FwkMembership>(te);
                te.ErrorId = "4000";
                throw te;
            }
        }

        /// <summary>
        /// Agrega un rol a la expresion de la regla.- Modifica Expression
        /// </summary>
        /// <param name="pRol"></param>
        /// <param name="pRule"></param>
        public static void Rule_AppenRol(Rol pRol, FwkAuthorizationRule pRule)
        {
            RolList rollistAux = null;
            UserList userList = null;

            BuildRolesAndUsers_FromRuleExpression(pRule.Expression, out rollistAux, out userList);

            //Agregar el rol a la regla
            rollistAux.Add(pRol);

            pRule.SetExpression(BuildRuleExpression(rollistAux, userList));
        }

        /// <summary>
        ///  Quita un rol de la expresion de la regla.- Modifica Expression
        /// </summary>
        /// <param name="pRol"></param>
        /// <param name="pRule"></param>
        public static void RemoveRol_From_Rule(Rol pRol, FwkAuthorizationRule pRule)
        {
            RolList rollistAux = null;
            UserList userList = null;

            BuildRolesAndUsers_FromRuleExpression(pRule.Expression, out rollistAux, out userList);

            //Quitar el rol a la regla si es que existe en la regla
            if (rollistAux.Any<Rol>(r => r.RolName.Equals(pRol.RolName)))
            {
                rollistAux.Remove(rollistAux.First<Rol>(r => r.RolName.Equals(pRol.RolName)));

                pRule.SetExpression(BuildRuleExpression(rollistAux, userList));
            }



        }
        #endregion
    }
}
