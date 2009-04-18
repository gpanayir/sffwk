using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security;

namespace Fwk.Security
{
  

/// <summary>
    /// Represents the configuration data for a
    /// rule that is governed by an 
    /// <see cref="AuthorizationRuleProvider"/>.
    /// </summary>
    public class FwkAuthorizationRule :  IAuthorizationRule
    {
        private  string _Expression ;

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="AuthorizationRuleData"/> class.
        /// </summary>
        public FwkAuthorizationRule()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationRuleData"/> class with the specified name and expression.
        /// </summary>
        /// <param name="name">The name of the rule</param>
        /// <param name="expression">The expression to evaluate.</param>
        public FwkAuthorizationRule(string name, string expression) 
        {
            _Expression = expression;
            _Name = name;
        }

        /// <summary>
        /// Gets or sets the expression associated with
        /// this rule.
        /// </summary>
		
		public string Expression
		{
			get
			{
				return _Expression;
			}
			set
			{
				_Expression= value;
			}
		}
        string _Name;
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
            }
        }

    }
}
