﻿

using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Principal;

//using Fwk.Security.Configuration;
using System.Collections.Specialized;


namespace Fwk.Security
{
    /// <summary>
    /// Represents an authorization provider that evaluates
    /// boolean expressions to determine whether 
    /// <see cref="System.Security.Principal.IPrincipal"/> objects
    /// are authorized.
    /// </summary>
    public class FwkAuthorizationRuleProvider : IAuthorizationProvider
    {
        private readonly IDictionary<string, IAuthorizationRule> authorizationRules;

      
        /// <summary>
        /// Initialize an instance of the <see cref="AuthorizationRuleProvider"/> class.
        /// </summary>
        /// <param name="authorizationRules">The collection of rules.</param>
        public FwkAuthorizationRuleProvider(FwkAuthorizationRuleList authorizationRules)
        {
            if (authorizationRules == null) throw new ArgumentNullException("authorizationRules");

            this.authorizationRules = CreateRulesDictionary<FwkAuthorizationRule>(authorizationRules); 
        }

        /// <summary>
        /// Esta sobrecarga obtiene las reglas atravez de la base de datos. 
        /// Para obtener el origen de datos utiliza la configuracion del membership provider configurado
        /// </summary>
        /// <param name="proividerName">Nombre del membership provider</param>
        public FwkAuthorizationRuleProvider(string proividerName)
        {
            List<FwkAuthorizationRule> authorizationRules = FwkMembership.GetRules(proividerName);

            this.authorizationRules = CreateRulesDictionary<FwkAuthorizationRule>(authorizationRules);
        }

        /// <summary>
        /// Evaluates the specified authority against the specified context.
        /// </summary>
        /// <param name="principal">Must be an <see cref="IPrincipal"/> object.</param>
        /// <param name="ruleName">The name of the rule to evaluate.</param>
        /// <returns><c>true</c> if the expression evaluates to true,
        /// otherwise <c>false</c>.</returns>
        public  bool Authorize(IPrincipal principal, string ruleName)
        {


            if (principal == null) throw new ArgumentNullException("principal");
            if (ruleName == null || ruleName.Length == 0) throw new ArgumentNullException("ruleName");



            //InstrumentationProvider.FireAuthorizationCheckPerformed(principal.Identity.Name, ruleName);
            bool expressionEmpty = false;
            BooleanExpression booleanExpression = GetParsedExpression(ruleName, expressionEmpty);
            if (expressionEmpty) return false;
            if (booleanExpression == null)
            {
                throw new InvalidOperationException(string.Format(Fwk.Security.Properties.Resource.AuthorizationRuleNotFoundMsg, ruleName));
            }

            bool result = booleanExpression.Evaluate(principal);

            //if (result == false)
            //{
            //    InstrumentationProvider.FireAuthorizationCheckFailed(principal.Identity.Name, ruleName);
            //}
            return result;
        }

        /// <summary>
        /// Obtiele la lista de reglas relacionadas al proveedor
        /// </summary>
        /// <returns></returns>
        public FwkAuthorizationRuleList GetAuthorizationRules()
        {
            FwkAuthorizationRuleList list = new FwkAuthorizationRuleList();
            if (authorizationRules == null) return null;
            if (authorizationRules.Count == 0) return list;

            var a = from s in authorizationRules.Values select new FwkAuthorizationRule { Name = s.Name, Expression = s.Expression };
            list.AddRange(a.ToList<FwkAuthorizationRule>());
            return list;
        } 

        BooleanExpression GetParsedExpression(string ruleName, bool expEmpty)
        {
            expEmpty = false;
            IAuthorizationRule rule = null;
            authorizationRules.TryGetValue(ruleName, out rule);
            if (rule == null) return null;

            if (string.IsNullOrEmpty(rule.Expression)) expEmpty = true;

            Parser parser = new Parser();

            return parser.Parse(rule.Expression);
        }

        static IDictionary<string, IAuthorizationRule> CreateRulesDictionary<T>(IEnumerable<T> rulesCollection) where T : IAuthorizationRule
        {
            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();


            foreach (IAuthorizationRule ruleData in rulesCollection)
            {
                authorizationRules.Add(ruleData.Name, ruleData);
            }

            return authorizationRules;
        }

        static IDictionary<string, IAuthorizationRule> CreateRulesList<T>(IEnumerable<T> rulesCollection) where T : IAuthorizationRule
        {
            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();


            foreach (IAuthorizationRule ruleData in rulesCollection)
            {
                authorizationRules.Add(ruleData.Name, ruleData);
            }

            return authorizationRules;
        }
    }
}