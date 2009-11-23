using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Fwk.Bases;
using Fwk.Security.Common;

namespace Fwk.Security
{


    /// <summary>
    /// Represents the configuration data for a
    /// rule that is governed by an 
    /// <see cref="AuthorizationRuleProvider"/>.
    /// </summary>

    public class FwkAuthorizationRule : NamedConfigurationElement, IAuthorizationRule
    {
        private string _Expression;

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
            : base(name)
        {
            _Expression = expression;

        }

        /// <summary>
        /// Gets or sets the expression associated with
        /// this rule.
        /// </summary>
        [ConfigurationProperty("expression", IsRequired = false)]
        public string Expression
        {
            get
            {
                return _Expression;
            }
            set
            {
                _Expression = value;
            }
        }
        int _CategoryId;
        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                _CategoryId = value;
            }
        }


        public void SetExpression(string newExpresion)
        {
            _Expression = newExpresion;
        }


    }

    [Serializable]
    public class FwkAuthorizationRuleAux : Fwk.Bases.Entity, IAuthorizationRule
    {

        public FwkAuthorizationRuleAux()
        { }
        public FwkAuthorizationRuleAux(string name, string expression)
        {
            _Name = name;
            _Expression = expression;
        }

        string _Expression;
        #region IAuthorizationRule Members

        public string Expression
        {
            get { return _Expression; }
            set
            {
                _Expression = value;
            }
        }
        string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
            }
        }
       
        #endregion

        public void SetExpression(string newExpresion)
        {
            _Expression = newExpresion;
        }
    }
    [Serializable]
    public class FwkCategory:Entity
    {
        int? _ParentCategoryId =0;

        public int? ParentId
        {
            get { return _ParentCategoryId; }
            set { _ParentCategoryId = value; }
        }
        int _CategoryId;
        public int CategoryId
        {
            get
            {
                return _CategoryId;
            }
            set
            {
                _CategoryId = value;
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

        List<FwkAuthorizationRuleAux> _FwkRulesInCategoryList = null;

        public List<FwkAuthorizationRuleAux> FwkRulesInCategoryList
        {
            get { return _FwkRulesInCategoryList; }
            set { _FwkRulesInCategoryList = value; }
        }

    }





    

}