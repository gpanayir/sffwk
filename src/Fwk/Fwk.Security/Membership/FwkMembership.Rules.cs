using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Security
{
    public partial class FwkMembership
    {
        #region [Rules]

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRoleName"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesByRole(string pRoleName, string providerName)
        {
            return GetRulesByRole(pRoleName, Membership.ApplicationName, GetSqlMembershipProvider_ConnectionStringName(providerName));
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pRoleName"></param>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesByRole(string pRoleName, string pApplicationName, string pConnectionStringName)
        {
            List<FwkAuthorizationRuleAux> wAllRules = null;

            try
            {

                wAllRules = GetRulesAuxList(pApplicationName, pConnectionStringName);

                var rules_byRol = from s in wAllRules where s.Expression.Contains(string.Concat("R:", pRoleName.Trim())) select s;

                return rules_byRol.ToList<FwkAuthorizationRuleAux>();

            }
            catch (InvalidOperationException)
            {
                ///TODO: mejorar manejo de Exception GetRule
                throw new Exception(string.Concat("Error al intentar obtener las reglas vinculadas al rol: " + pRoleName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        /// <summary>
        /// Verifica si alguna regla en la base de datos esta vinculada al rol
        /// </summary>
        /// <param name="pRoleName"></param>
        /// <param name="providerName">Nombre del proveedor de membership</param>
        /// <returns></returns>
        public static bool AnyRulesHasRole(string pRoleName, string providerName)
        {
            return AnyRulesHasRole(pRoleName, providerName, GetSqlMembershipProvider_ConnectionStringName(providerName));
        }
        /// <summary>
        /// Verifica si alguna regla en la base de datos esta vinculada al rol
        /// </summary>
        /// <param name="pRoleName">Nmbre del rol </param>
        /// <param name="pApplicationName">App Id</param>
        /// <param name="pConnectionStringName">nombde de cadena de coneccion</param>
        /// <returns></returns>
        public static bool AnyRulesHasRole(string pRoleName, string pApplicationName, string pConnectionStringName)
        {
            List<FwkAuthorizationRuleAux> wAllRules = null;
            try
            {
                wAllRules = GetRulesAuxList(pApplicationName, pConnectionStringName);

                return wAllRules.Any<FwkAuthorizationRuleAux>(s => s.Expression.Contains(string.Concat("R:", pRoleName.Trim())));


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static aspnet_Rule GetRule(string ruleName)
        {
            return GetRule(ruleName, Membership.ApplicationName, ConnectionStringName);
        }

        public static aspnet_Rule GetRule(string ruleName, string pApplicationName)
        {
            return GetRule(ruleName, pApplicationName, ConnectionStringName);
        }

        public static aspnet_Rule GetRule(string ruleName, string pApplicationName, string pConnectionStringName)
        {

            aspnet_Rule waspnet_Rule = null;
            try
            {

                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    if (dc.aspnet_Rules.Any<aspnet_Rule>(s => s.name.Equals(ruleName.Trim()) && s.ApplicationId == wApplicationId))
                    {
                        waspnet_Rule = dc.aspnet_Rules.First<aspnet_Rule>(s => s.name.Equals(ruleName.Trim()) && s.ApplicationId == wApplicationId);


                    }
                    return waspnet_Rule;
                }
            }
            catch (InvalidOperationException)
            {
                //TODO: mejorar manejo de Exception GetRule
                throw new Exception(string.Concat("Error al intentar obtener los valores de la relgla: " + ruleName));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// </summary>
        /// <returns></returns>
        public static NamedElementCollection<FwkAuthorizationRule> GetRules()
        {
            return GetRules(Membership.ApplicationName, ConnectionStringName);
        }

        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// </summary>
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        /// <returns></returns>
        public static NamedElementCollection<FwkAuthorizationRule> GetRules(string pApplicationName)
        {
            return GetRules(pApplicationName, ConnectionStringName);
        }


        /// <summary>
        /// Obtiene las reglas de una determinada aplicacion
        /// Reemplaza aspnet_Rules_s
        /// </summary>
        /// <param name="pConnectionStringName"></param>
        /// <param name="pApplicationName"></param>
        /// <returns></returns>
        public static NamedElementCollection<FwkAuthorizationRule> GetRules(string pApplicationName, string pConnectionStringName)
        {



            FwkAuthorizationRule rule = null;
            NamedElementCollection<FwkAuthorizationRule> wRules = null;
            try
            {

                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

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
                throw ex;
            }

        }

        public static List<AuthorizationRuleData> GetRulesList(string pApplicationName)
        {
            return GetRulesList(pApplicationName, ConnectionStringName);
        }

        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static List<AuthorizationRuleData> GetRulesList(string pApplicationName, string pConnectionStringName)
        {


            AuthorizationRuleData rule = null;
            List<AuthorizationRuleData> wRules = null;
            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);
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
                throw ex;
            }

        }

        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesAuxList(string pApplicationName)
        {
            return GetRulesAuxList(pApplicationName, ConnectionStringName);
        }
        /// <summary>
        /// Retorna una lista de reglas de una determinada coneccion 
        /// </summary>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        /// <returns></returns>
        public static List<FwkAuthorizationRuleAux> GetRulesAuxList(string pApplicationName, string pConnectionStringName)
        {


            FwkAuthorizationRuleAux rule = null;
            List<FwkAuthorizationRuleAux> wRules = null;
            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);
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
                throw ex;
            }

        }
        /// <summary>
        /// Determina si existe una regla.-
        /// </summary>
        /// <param name="pName">Nombre de la regla</param>
        /// <param name="pConnectionStringName">Nombre de la regla</param>
        /// <returns>boolean</returns>
        public static bool ExistRule(string pRuleName, string pApplicationName, string pConnectionStringName)
        {
            bool wExist = false;

            try
            {

                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

                using (Fwk.Security.RuleProviderDataContext dc = new Fwk.Security.RuleProviderDataContext(System.Configuration.ConfigurationManager.ConnectionStrings[pConnectionStringName].ConnectionString))
                {
                    wExist = dc.aspnet_Rules.Any(s => s.Equals(pRuleName) && s.ApplicationId == wApplicationId);
                }


                return wExist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Determina si existe una regla.-
        /// </summary>
        /// <param name="pName">Nombre de la regla</param>
        /// <param name="pConnectionStringName">Nombre de la regla</param>
        /// <returns>boolean</returns>
        public static bool ExistRule(string pRuleName, string pApplicationName)
        {
            return ExistRule(pRuleName, pApplicationName, FwkMembership.ConnectionStringName);
        }





        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="paspnet_Rules">aspnet_Rules</param>
        /// <returns>void</returns>
        /// <Date>2008-12-22T11:29:57</Date>
        /// <Author>moviedo</Author>
        public static void CreateRule(FwkAuthorizationRule paspnet_Rules)
        {
            CreateRule(paspnet_Rules, Membership.ApplicationName, FwkMembership.ConnectionStringName);
        }

        /// <summary>
        /// Insert
        /// </summary>
        ///<param name="paspnet_Rules">aspnet_Rules</param>
        /// <returns>void</returns>
        /// <Date>2008-12-22T11:29:57</Date>
        /// <Author>moviedo</Author>
        public static void CreateRule(FwkAuthorizationRule paspnet_Rules, string pApplicationName)
        {
            CreateRule(paspnet_Rules, pApplicationName, FwkMembership.ConnectionStringName);
        }


        /// <summary>
        /// Crea una regla
        /// </summary>
        /// <param name="paspnet_Rules"></param>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        public static void CreateRule(FwkAuthorizationRule paspnet_Rules, string pApplicationName, string pConnectionStringName)
        {



            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

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
                throw ex;
            }

        }


        /// <summary>
        /// UpdateRule
        /// </summary>
        /// <param name="paspnet_Rules"></param>
        public static void UpdateRule(aspnet_Rule paspnet_Rules)
        {
            UpdateRule(paspnet_Rules, Membership.ApplicationName, FwkMembership.ConnectionStringName);
        }

        /// <summary>
        /// UpdateRule
        /// </summary>
        /// <param name="paspnet_Rules"></param>
        /// <param name="pApplicationName"></param>
        public static void UpdateRule(aspnet_Rule paspnet_Rules, string pApplicationName)
        {
            UpdateRule(paspnet_Rules, pApplicationName, FwkMembership.ConnectionStringName);
        }

        /// <summary>
        /// UpdateRule
        /// </summary>
        /// <param name="paspnet_Rules"></param>
        /// <param name="pApplicationName"></param>
        /// <param name="pConnectionStringName"></param>
        private static void UpdateRule(aspnet_Rule paspnet_Rules, string pApplicationName, string pConnectionStringName)
        {
            Database wDataBase = null;
            DbCommand wCmd = null;

            try
            {
                Guid wApplicationId = GetApplication(pApplicationName, pConnectionStringName);

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
