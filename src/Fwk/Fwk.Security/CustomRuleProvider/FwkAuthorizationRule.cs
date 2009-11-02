using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Fwk.Bases;

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
        #endregion
    }
    [Serializable]
    public class FwkCategory
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

        List<FwkRulesInCategory> _FwkRulesInCategoryList = null;

        public List<FwkRulesInCategory> FwkRulesInCategoryList
        {
            get { return _FwkRulesInCategoryList; }
            set { _FwkRulesInCategoryList = value; }
        }

    }





    [Serializable]
    public class FwkRulesInCategory
    {
        #region [Private Members]
        private System.Int32? mi_CategoryId;
        private System.String msz_RuleName;
        private System.String msz_ApplicationId;

        #endregion

        #region [Properties]

        #region [CategoryId]
       
        public System.Int32? CategoryId
        {
            get { return mi_CategoryId; }
            set { mi_CategoryId = value; }
        }
        #endregion
        #region [RuleName]
       
        public System.String RuleName
        {
            get { return msz_RuleName; }
            set { msz_RuleName = value; }
        }
        #endregion
        #region [ApplicationId]
       
        public System.String ApplicationId
        {
            get { return msz_ApplicationId; }
            set { msz_ApplicationId = value; }
        }
        #endregion
        #endregion

        
    }

}