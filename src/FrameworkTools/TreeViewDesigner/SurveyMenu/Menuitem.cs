using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;

namespace Fwk.Tools
{




    [Serializable]
    public class MenuItem : Entity
    {
    
        #region Declarations

        Boolean _Enabled = true;

        public Boolean Enabled
        {
            get { return _Enabled; }
            set { _Enabled = value; }
        }
       

       
        String _DisplayName;

        public String DisplayName
        {
            get { return _DisplayName; }
            set { _DisplayName = value; }
        }

        String _AssemblyInfo;

        public String AssemblyInfo
        {
            get { return _AssemblyInfo; }
            set { _AssemblyInfo = value; }
        }


        String _ToolTipInfo;

        public String ToolTipInfo
        {
            get { return _ToolTipInfo; }
            set { _ToolTipInfo = value; }
        }

        private System.Byte[] _Image;
        [System.Xml.Serialization.XmlElementAttribute("Image", DataType = "base64Binary")]
        public System.Byte[] Image
        {
            get { return _Image; }
            set { _Image = value; }
        }

        private System.Byte[] m_NodeImage;
        [System.Xml.Serialization.XmlElementAttribute("NodeImage", DataType = "base64Binary")]
        public System.Byte[] NodeImage
        {
            get { return m_NodeImage; }
            set { m_NodeImage = value; }
        }

        private System.Byte[] m_NodeSelectedImage;
        [System.Xml.Serialization.XmlElementAttribute("NodeSelectedImage", DataType = "base64Binary")]
        public System.Byte[] NodeSelectedImage
        {
            get { return m_NodeSelectedImage; }
            set { m_NodeSelectedImage = value; }
        }
        int m_NodeSelectedImageIndex;
        public int NodeSelectedImageIndex
        {
            get { return m_NodeSelectedImageIndex; }
            set { m_NodeSelectedImageIndex = value; }
        }

        int m_NodeImageIndexImageIndex;
        public int NodeImageIndex
        {
            get { return m_NodeImageIndexImageIndex; }
            set { m_NodeImageIndexImageIndex = value; }
        }
        public string AuthRule { get; set; }    
        #endregion



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



        public bool IsCategory { get; set; }

        public string Category { get; set; }
    }

    /// <summary>
    /// Contiene las columnas de un objeto Table .-
    /// </summary>
    [XmlRoot("MenuItemList"), SerializableAttribute]
    public class MenuItemList : Entities<MenuItem>
    {
       
    }


    [Serializable]
    public class MenuImage : Entity
    {

        int _Index;

        public int Index
        {
            get { return _Index; }
            set { _Index = value; }
        }

        


        private System.Byte[] m_Image;
        [System.Xml.Serialization.XmlElementAttribute("Image", DataType = "base64Binary")]
        public System.Byte[] Image
        {
            get { return m_Image; }
            set { m_Image = value; }
        }
    }


    /// <summary>
    /// Contiene las imagenes del menu
    /// </summary>
    [XmlRoot("MenuImageList"), SerializableAttribute]
    public class MenuImageList : Entities<MenuImage>
    {
        
    }

}
