

using System;
using System.Collections.Generic;
using System.Security.Principal;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Fwk.Security.Configuration;

namespace Fwk.Security
{
    /// <summary>
    /// Represents an authorization provider that evaluates
    /// boolean expressions to determine whether 
    /// <see cref="System.Security.Principal.IPrincipal"/> objects
    /// are authorized.
    /// </summary>
    [ConfigurationElementType(typeof(FwkAuthorizationRuleProviderData))]
    public class FwkAuthorizationRuleProvider : AuthorizationProvider
    {
        private readonly IDictionary<string, IAuthorizationRule> authorizationRules;

        /// <summary>
        /// Initialize an instance of the <see cref="AuthorizationRuleProvider"/> class.
        /// </summary>
        /// <param name="authorizationRules">The collection of rules.</param>
        public FwkAuthorizationRuleProvider(IDictionary<string, IAuthorizationRule> authorizationRules)
        {
            if (authorizationRules == null) throw new ArgumentNullException("authorizationRules");

            this.authorizationRules = authorizationRules;
        }
        /// <summary>
        /// Initialize an instance of the <see cref="AuthorizationRuleProvider"/> class.
        /// </summary>
        /// <param name="authorizationRules">The collection of rules.</param>
        public FwkAuthorizationRuleProvider(List<IAuthorizationRule> authorizationRules)
        {
            if (authorizationRules == null) throw new ArgumentNullException("authorizationRules");

            this.authorizationRules = CreateRulesDictionary(authorizationRules); ;
        }
        /// <summary>
        /// Initialize an instance of the <see cref="AuthorizationRuleProvider"/> class.
        /// </summary>
        /// <param name="authorizationRules">The collection of rules.</param>
        public FwkAuthorizationRuleProvider(List<FwkAuthorizationRuleAux> authorizationRules)
        {
            if (authorizationRules == null) throw new ArgumentNullException("authorizationRules");

            this.authorizationRules = CreateRulesDictionary(authorizationRules); ;
        }

        /// <summary>
        /// Evaluates the specified authority against the specified context.
        /// </summary>
        /// <param name="principal">Must be an <see cref="IPrincipal"/> object.</param>
        /// <param name="ruleName">The name of the rule to evaluate.</param>
        /// <returns><c>true</c> if the expression evaluates to true,
        /// otherwise <c>false</c>.</returns>
        public override bool Authorize(IPrincipal principal, string ruleName)
        {
            
            
            if (principal == null) throw new ArgumentNullException("principal");
            if (ruleName == null || ruleName.Length == 0) throw new ArgumentNullException("ruleName");

            

            InstrumentationProvider.FireAuthorizationCheckPerformed(principal.Identity.Name, ruleName);
            bool expressionEmpty = false;
            BooleanExpression booleanExpression = GetParsedExpression(ruleName, expressionEmpty);
            if (expressionEmpty) return false;
            if (booleanExpression == null)
            {
                throw new InvalidOperationException(string.Format(Fwk.Security.Properties.Resource.AuthorizationRuleNotFoundMsg, ruleName));
            }

            bool result = booleanExpression.Evaluate(principal);

            if (result == false)
            {
                InstrumentationProvider.FireAuthorizationCheckFailed(principal.Identity.Name, ruleName);
            }
            return result;
        }

        private BooleanExpression GetParsedExpression(string ruleName,bool expEmpty)
        {
             expEmpty = false;
            IAuthorizationRule rule = null;
            authorizationRules.TryGetValue(ruleName, out rule);
            if (rule == null) return null;

            if (string.IsNullOrEmpty(rule.Expression)) expEmpty = true;
                
            Parser parser = new Parser();

            return parser.Parse(rule.Expression);
        }

        static IDictionary<string, IAuthorizationRule> CreateRulesDictionary
            (IEnumerable<IAuthorizationRule> rulesCollection)
        {
            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();


            foreach (FwkAuthorizationRule ruleData in rulesCollection)
            {
                authorizationRules.Add(ruleData.Name, ruleData);
            }

            return authorizationRules;
        }


        static IDictionary<string, IAuthorizationRule> CreateRulesDictionary
           (List<IAuthorizationRule> rulesCollection)
        {
            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();


            foreach (IAuthorizationRule ruleData in rulesCollection)
            {
                authorizationRules.Add(ruleData.Name, ruleData);
            }

            return authorizationRules;
        }



        static IDictionary<string, IAuthorizationRule> CreateRulesDictionary
         (List<FwkAuthorizationRuleAux> rulesCollection)
        {
            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();


            foreach (FwkAuthorizationRuleAux ruleData in rulesCollection)
            {
                authorizationRules.Add(ruleData.Name, ruleData);
            }

            return authorizationRules;
        }
    }
}