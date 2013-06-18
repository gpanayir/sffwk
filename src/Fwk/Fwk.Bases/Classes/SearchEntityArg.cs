//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Fwk.Bases
//{
//    /// <summary>
//    /// 
//    /// </summary>
//    [Serializable]
//    public class SearchEntityArg
//    {
//        private string _property;
//        private string _value;
//        private Boolean _ignoreCaseForValue = false;

       

     

//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="pProperty">Nombre de la propiedad a buscar</param>
//        /// <param name="pValue">Valor con el que se va a comparar</param>
//        public SearchEntityArg(string pProperty, string pValue)
//        {
//            this._property = pProperty;
//            this._value = pValue;
//        }

//         /// <summary>
//         /// 
//         /// </summary>
//        /// <param name="pProperty">Nombre de la propiedad a buscar</param>
//        /// <param name="pValue">Valor con el que se va a comparar</param>
//         /// <param name="pIgnoreCaseForValue">Indica </param>
//        public SearchEntityArg(string pProperty, string pValue,Boolean pIgnoreCaseForValue)
//        {
//            this._property = pProperty;
//            this._value = pValue;
//            this.IgnoreCaseForValue = pIgnoreCaseForValue;
//        }

//        /// <summary>
//        /// Nombre de la propiedad donde se buscará.
//        /// </summary>
//        public string NameProperty
//        {
//            get { return _property; }
//            set { _property = value; }
//        }

//        /// <summary>
//        /// Valor a buscar dentro de la Propiedad. 
//        /// </summary>
//        public string Value
//        {
//            get { return _value; }
//            set { _value = value; }
//        }

//        /// <summary>
//        /// Indica si se tienen en cuenta las mayusculas y minusculas par ala comparacion del valor
//        /// </summary>
//        public Boolean IgnoreCaseForValue
//        {
//            get { return _ignoreCaseForValue; }
//            set { _ignoreCaseForValue = value; }
//        }
//    }
//}
