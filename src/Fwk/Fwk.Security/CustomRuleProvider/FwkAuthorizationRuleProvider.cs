

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

            BooleanExpression booleanExpression = GetParsedExpression(ruleName);
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

        private BooleanExpression GetParsedExpression(string ruleName)
        {
            IAuthorizationRule rule = null;
            authorizationRules.TryGetValue(ruleName, out rule);
            if (rule == null) return null;

            string expression = rule.Expression;
            Parser parser = new Parser();

            return parser.Parse(expression);
        }
    }
}