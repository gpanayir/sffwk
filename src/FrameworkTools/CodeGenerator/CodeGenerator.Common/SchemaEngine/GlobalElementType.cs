using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Windows.Forms;
using System.ComponentModel;

namespace Fwk.CodeGenerator.Common
{
    public class GlobalElementType<T> 
    {
        #region --[constructor]--
        public GlobalElementType(XmlSchemaElement pDefinition)
        {
            _Definition = pDefinition;
        }
        #endregion

        #region --[private members]--
        // Definicion del elemento.
        private XmlSchemaElement _Definition;

        // Lista de valores posibles.
        private List<T> _PosibleValues;

        // Valor minimo que puede asumir.
        private T _MinValue;

        // Valor maximo que puede asumir.
        private T _MaxValue;

        // Unico valor que puede asumir.
        private T _ForcedValue;

        // Invalidar Validacion.
        private bool _Invalidate = false;
        #endregion

        #region --[public properties]--
        /// <summary>
        /// Nombre del elemento.
        /// </summary>
        public string Name
        {
            get { return _Definition.QualifiedName.Name; }
        }

        /// <summary>
        /// Tipo de dato del elemento.
        /// </summary>
        public string DataType
        {
            get { return _Definition.ElementSchemaType.Datatype.ValueType.ToString(); }
        }

        /// <summary>
        /// Lista de valores posibles.
        /// </summary>
        public List<T> PosibleValues
        {
            get { return _PosibleValues; }
            set { _PosibleValues = value; }
        }

        /// <summary>
        /// Es nulable?
        /// </summary>
        public bool Nullable
        {
            get { return _Definition.IsNillable; }
            set { _Definition.IsNillable = value; }
        }

        /// <summary>
        /// Cantidad minima de ocurrencias.
        /// </summary>
        public decimal MinOccurs
        {
            get { return _Definition.MinOccurs; }
            set { _Definition.MinOccurs = value; }
        }

        /// <summary>
        /// Cantidad maxima de ocurrencias.
        /// </summary>
        public decimal MaxOccurs
        {
            get { return _Definition.MaxOccurs; }
            set { _Definition.MaxOccurs = value; }
        }

        /// <summary>
        /// Valor maximo que puede asumir.
        /// </summary>
        public T MaxValue
        {
            get { return _MaxValue; }
            set { _MaxValue = value; }
        }

        /// <summary>
        /// Valor minimo que puede asumir.
        /// </summary>
        public T MinValue
        {
            get { return _MinValue; }
            set { _MinValue = value; }
        }

        /// <summary>
        /// Unico valor que puede asumir.
        /// </summary>
        public T ForcedValue
        {
            get { return _ForcedValue; }
            set { _ForcedValue = value; }
        }

        /// <summary>
        /// Definicion del elemento.
        /// </summary>
        public XmlSchemaElement Definition
        {
            get { return _Definition; }
        }

        // Invalidar Validacion.
        public bool Invalidate
        {
            get { return _Invalidate; }
            set { _Invalidate = value; }
        }
        #endregion
    }
}
