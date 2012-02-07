using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace Fwk.Tools.SurveyMenu
{
    [Serializable]
    public class MenuItemSurvey : MenuItem
    {
        private System.Byte[] m_TypeImage;
        [System.Xml.Serialization.XmlElementAttribute("TypeImage", DataType = "base64Binary")]
        public System.Byte[] TypeImage
        {
            get { return m_TypeImage; }
            set { m_TypeImage = value; }
        }
        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        private int _ParentID;
        public int ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }

    }
    [XmlRoot("MenuItemSurveyList"), SerializableAttribute]
    public class MenuItemSurveyList : Entities<MenuItemSurvey>
    {
        /// <summary>
        /// Metodo estatico que retorna un objeto MenuItemSurveyList apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>MenuItemSurveyList</returns>
        public static MenuItemSurveyList GetMenuItemSurveyListFromXml(String pXml)
        {
            return MenuItemSurveyList.GetFromXml<MenuItemSurveyList>( pXml);
        }
    }
}
