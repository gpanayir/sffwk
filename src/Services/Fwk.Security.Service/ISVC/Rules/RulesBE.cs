
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a Prominente Code Generator.
//     Runtime Version:1.0
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
//
//</auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;


namespace Fwk.Security.BE
{
    [XmlRoot("RulesBEList"), SerializableAttribute]
    public class RulesBEList : Entities<RulesBE>
    {
        
    }

    [XmlInclude(typeof(RulesBE)), Serializable]
    public class RulesBE : Entity
    {
        public RulesBE()
        {
        
        }
        public RulesBE(string name, string expression)
        {
            _Name = name.Trim();
            _expression = expression;
        }
        #region [Private Members]
        private System.String _Name;
        private System.String _expression;
        private System.String _ApplicationId;
        private System.String _ApplicationName;

        public System.String ApplicationName
        {
            get { return _ApplicationName; }
            set { _ApplicationName = value; }
        }

        #endregion

        #region [Properties]

        #region [name]

        public System.String Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        #endregion
        #region [expression]
      
        public System.String expression
        {
            get { return _expression; }
            set { _expression = value; }
        }
        #endregion
        #region [ApplicationId]

        public System.String ApplicationId
        {
            get { return _ApplicationId; }
            set { _ApplicationId = value; }
        }
        #endregion
        #endregion

        

        
    }

}