using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using System.Configuration;
using Fwk.Bases;
using Fwk.Security.Common;
using System.Xml.Serialization;

namespace Fwk.Security
{


    /// <summary>
    /// Represents the configuration data for a
    /// rule that is governed by an 
    /// <see cref="AuthorizationRuleProvider"/>.
    /// </summary>
    [Serializable]
    public class FwkAuthorizationRule :  NamedConfigurationElement, IAuthorizationRule,Fwk.Bases.IEntity
    {
        private string _Expression;
        private System.String _ApplicationId;
        private System.String _ApplicationName;
       

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
        public System.String ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }


        public System.String ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newExpresion"></param>
        public void SetExpression(string newExpresion)
        {
            _Expression = newExpresion;
        }



        #region IEntity Members IBaseEntity Members

        public System.Data.DataSet GetDataSet()
        {
            throw new NotImplementedException("No se implementa GetDataSet en esta entidad");
        }

      

        

        public string GetXml()
        {
            throw new NotImplementedException("No se implementa GetXml en esta entidad");
        }

        public void SetXml(string pXmlData)
        {
            throw new NotImplementedException("No se implementa SetXml en esta entidad");
        }

        #endregion

        #region ICloneable Members

        /// <summary>
        /// Crea una copia espejo de la clase.-
        /// </summary>
        /// <returns></returns>
        public FwkAuthorizationRule Clone()
        {
            return (FwkAuthorizationRule)((ICloneable)this).Clone();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
         object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }

    [XmlRoot("FwkAuthorizationRuleList"), SerializableAttribute]
    public class FwkAuthorizationRuleList : List<FwkAuthorizationRule>, IEntity
    {
        #region IEntity Members

        public System.Data.DataSet GetDataSet()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IBaseEntity Members

        public string GetXml()
        {
            throw new NotImplementedException();
        }

        public void SetXml(string pXmlData)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            throw new NotImplementedException();
        }

        #endregion
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

        List<FwkAuthorizationRule> _FwkRulesInCategoryList = null;

        public List<FwkAuthorizationRule> FwkRulesInCategoryList
        {
            get { return _FwkRulesInCategoryList; }
            set { _FwkRulesInCategoryList = value; }
        }

    }





    

}