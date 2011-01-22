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
        private System.Guid _ApplicationId;
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
        /// Initializes a new instance of the <see cref="AuthorizationRuleData"/> class with the specified name and expression.
        /// </summary>
        /// <param name="name">The name of the rule</param>
        /// <param name="expression">The expression to evaluate.</param>
        /// <param name="applicationId">Apliocacion  la que pertenece.</param>
        public FwkAuthorizationRule(string name, string expression, Guid applicationId)
            : base(name)
        {
            _Expression = expression;
            _ApplicationId = applicationId;

        }
         /// <summary>
        /// Initializes a new instance of the <see cref="FwkAuthorizationRuleAux"/> class with the specified name and expression.
        /// </summary>
        /// <param name="pFwkAuthorizationRule">Framework rule</param>
        public FwkAuthorizationRule(FwkAuthorizationRuleAux pFwkAuthorizationRule): base(pFwkAuthorizationRule.Name)
            
        {
            _ApplicationId = pFwkAuthorizationRule.ApplicationId;
            _ApplicationName = pFwkAuthorizationRule.ApplicationName;
            _CategoryId = pFwkAuthorizationRule.CategoryId;
            _Expression = pFwkAuthorizationRule.Expression;
           

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
        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public System.Guid ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
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




        /// <summary>
        /// 
        /// </summary>
        public string GetXml()
        {
            throw new NotImplementedException("No se implementa GetXml en esta entidad");
        }
        /// <summary>
        /// 
        /// </summary>
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

    /// <summary>
    /// Lista de reglas de autorizacion
    /// </summary>
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

        public void Populate(FwkAuthorizationRuleAuxList pFwkAuthorizationRuleauxList)
        {
            pFwkAuthorizationRuleauxList.ForEach(a => this.Add(new FwkAuthorizationRule(a)));
        }
    }
    /// <summary>
    /// Categorias de reglass
    /// </summary>
    [Serializable]
    public class FwkCategory:Entity
    {
        int? _ParentCategoryId =0;

        /// <summary>
        /// 
        /// </summary>
        public int? ParentId
        {
            get { return _ParentCategoryId; }
            set { _ParentCategoryId = value; }
        }
        int _CategoryId;

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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

        FwkAuthorizationRuleList _FwkRulesInCategoryList = null;

        /// <summary>
        /// 
        /// </summary>
        public FwkAuthorizationRuleList FwkRulesInCategoryList
        {
            get { return _FwkRulesInCategoryList; }
            set { _FwkRulesInCategoryList = value; }
        }

    }

    /// <summary>
    /// 
    /// </summary>
    [XmlRoot("FwkCategoryList"), SerializableAttribute]
    public class FwkCategoryList : Entities<FwkCategory>
    {
      
    }


    /// <summary>
    /// Esta clace es una auxiliar de FwkAuthorizationRule con la exepcion de que no  hereda de NamedConfigurationElement
    /// lo que la hace serializable .-
    /// </summary>
    [Serializable]
    public class FwkAuthorizationRuleAux : Entity, IAuthorizationRule
    {
        #region Properties
        private string _Expression;
        private System.Guid _ApplicationId;
        private System.String _ApplicationName;
        private System.String _Name;
        private int _CategoryId;

        public System.String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
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
        /// <summary>
        /// 
        /// </summary>
        public System.Guid ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public System.String ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }

        #endregion 

        /// <summary>
        /// Initializes a new instance of the 
        /// <see cref="FwkAuthorizationRuleAux"/> class.
        /// </summary>
        public FwkAuthorizationRuleAux()
        {
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="FwkAuthorizationRuleAux"/> class with the specified name and expression.
        /// </summary>
        /// <param name="pFwkAuthorizationRule">Framework rule</param>
        public FwkAuthorizationRuleAux(FwkAuthorizationRule pFwkAuthorizationRule)
            
        {
            _ApplicationId = pFwkAuthorizationRule.ApplicationId;
            _ApplicationName = pFwkAuthorizationRule.ApplicationName;
            _CategoryId = pFwkAuthorizationRule.CategoryId;
            _Expression = pFwkAuthorizationRule.Expression;
            _Name = pFwkAuthorizationRule.Name;

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizationRuleData"/> class with the specified name and expression.
        /// </summary>
        /// <param name="name">The name of the rule</param>
        /// <param name="expression">The expression to evaluate.</param>
        public FwkAuthorizationRuleAux(string name, string expression)
            
        {
            _Expression = expression;
            _Name = name;

        }
    
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newExpresion"></param>
        public void SetExpression(string newExpresion)
        {
            _Expression = newExpresion;
        }


        
    }

    /// <summary>
    /// Esta clace es una auxiliar de FwkAuthorizationRuleList con la exepcion de que no  hereda de NamedConfigurationElement
    /// lo que la hace serializable .-
    /// </summary>
    [Serializable]
    public class FwkAuthorizationRuleAuxList:Entities<FwkAuthorizationRuleAux>
    {
        public void Populate(FwkAuthorizationRuleList pFwkAuthorizationRuleList)
        {
            pFwkAuthorizationRuleList.ForEach(a=> this.Add(new  FwkAuthorizationRuleAux(a)));  
        }
       

      
    }
}