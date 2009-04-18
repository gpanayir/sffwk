using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Fwk.Xml
{
    /// <summary>
    /// Manejo de CData.
    /// </summary>
    /// <Author>moviedo</Author>
    /// <Date>28-12-2005</Date>
    //public class CData
    //{
    //    /// <summary>
    //    /// Crea y agrega una seccion CDATA en un nodo.
    //    /// </summary>
    //    /// <param name="pnode">El nodo al que se le agregara la seccion CDATA.</param>
    //    public static void CDATASectionCreateAndAdd(XmlNode pnode)
    //    {
    //        CDATASectionCreateAndAdd(pnode, "");
    //    }

    //    /// <summary>
    //    /// Crea y agrega una seccion CDATA en un nodo.
    //    /// </summary>
    //    /// <param name="pnode">El nodo al que se le agregara la seccion CDATA.</param>
    //    /// <param name="pCDATASectionValue">El contenido de la seccion CDATA.</param>
    //    public static void CDATASectionCreateAndAdd(XmlNode pnode, string pCDATASectionValue)
    //    {
    //        XmlCDataSection wNewCDataSection = pnode.OwnerDocument.CreateCDataSection(pCDATASectionValue);
    //        pnode.AppendChild(wNewCDataSection);
    //    }
    //}
    [Serializable]
    public class CData : IXmlSerializable
    {

        private string text;

        public CData()

        { }

        public CData(string text)
        {

            this.text = text;

        }

        public string Text
        {

            get { return text; }
             set {  text = value; }

        }

        XmlSchema IXmlSerializable.GetSchema()
        {

            return null;

        }

        void IXmlSerializable.ReadXml(XmlReader reader)
        {

            this.text = reader.ReadString();

        }

        void IXmlSerializable.WriteXml(XmlWriter writer)
        {

            writer.WriteCData(this.text);

        }

        #region Statics

        /// <summary>
        /// Crea y agrega una seccion CDATA en un nodo.
        /// </summary>
        /// <param name="pnode">El nodo al que se le agregara la seccion CDATA.</param>
        public static void CDATASectionCreateAndAdd(XmlNode pnode)
        {
            CDATASectionCreateAndAdd(pnode, "");
        }

        /// <summary>
        /// Crea y agrega una seccion CDATA en un nodo.
        /// </summary>
        /// <param name="pnode">El nodo al que se le agregara la seccion CDATA.</param>
        /// <param name="pCDATASectionValue">El contenido de la seccion CDATA.</param>
        public static void CDATASectionCreateAndAdd(XmlNode pnode, string pCDATASectionValue)
        {
            XmlCDataSection wNewCDataSection = pnode.OwnerDocument.CreateCDataSection(pCDATASectionValue);
            pnode.AppendChild(wNewCDataSection);
        }
        #endregion

    }

}
