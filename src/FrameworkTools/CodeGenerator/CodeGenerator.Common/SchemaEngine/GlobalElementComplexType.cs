using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.ComponentModel;

namespace Fwk.CodeGenerator.Common
{
    public class GlobalElementComplexType
    {
        private decimal _MaxOccurs=0;
        #region --[constructor]--
        public GlobalElementComplexType(XmlSchemaComplexType pDefinition, decimal pMaxOcurs)
        {
            _Definition = pDefinition;
            _MaxOccurs = pMaxOcurs;
            _ChildElementsNames = new List<string>();
            
        }
         
        #endregion

        #region --[private members]--
        // Definicion del elemento.
        private XmlSchemaComplexType _Definition;

       
        
        // Nombre del complexType.
        private string _Name;

        // Incluir en Dataset?.
        private bool _IncludeInDataSet = true;

        private List<string> _ChildElementsNames;
        private List<TreeNode> _ChildElements;

       
        #endregion

        #region --[public properties]--
        /// <summary>
        /// Nombre del complexType.
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set {_Name = value; }
        }

        /// <summary>
        /// Incluir en Dataset?.
        /// </summary>
        public bool IncludeInDataSet
        {
            get { return _IncludeInDataSet; }
            set { _IncludeInDataSet = value; }
        }

        public List<string> ChildElementsNames
        {
            get { return _ChildElementsNames; }
            set { _ChildElementsNames = value; }
        }
        public List<TreeNode> ChildElements
        {
            get { return _ChildElements; }
            set { _ChildElements = value; }
        }
        public XmlSchemaComplexType Definition
        {
            get { return _Definition; }
            set { _Definition = value; }
        }
        public decimal MaxOccurs
        {
            get { return _MaxOccurs; }
            set { _MaxOccurs = value; }
        }
        public string MaxOccursString
        {
            get { return _Definition.Particle.MaxOccursString; }
            set { _Definition.Particle.MaxOccursString = value; }
        }
        #endregion
    }
}
