//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using Fwk.Bases;
//using System.Xml.Serialization;
//using System.Xml;
//using System.Drawing;

//namespace Fwk.Tools
//{
//    [Serializable]
//    public class TreeMenu : Entity
//    {
//        MenuItemList _ItemList = new MenuItemList();

//        public MenuItemList ItemList
//        {
//            get { return _ItemList; }
//            set { _ItemList = value; }
//        }
//        MenuImageList _ImageList = new MenuImageList();

//        public MenuImageList ImageList
//        {
//            get { return _ImageList; }
//            set { _ImageList = value; }
//        }

//        public  int GetNewID()
//        {
//            return _ItemList.Max<MenuItem>(p => p.ID) + 1;
//        }
//    }


//    [Serializable]
//    public class MenuItem : Entity
//    {

//        #region Declarations

//        Boolean _Enabled = true;

//        public Boolean Enabled
//        {
//            get { return _Enabled; }
//            set { _Enabled = value; }
//        }



//        String _DisplayName;

//        public String DisplayName
//        {
//            get { return _DisplayName; }
//            set { _DisplayName = value; }
//        }

//        String _AssemblyInfo;

//        public String AssemblyInfo
//        {
//            get { return _AssemblyInfo; }
//            set { _AssemblyInfo = value; }
//        }


//        String _ToolTipInfo;

//        public String ToolTipInfo
//        {
//            get { return _ToolTipInfo; }
//            set { _ToolTipInfo = value; }
//        }

//        private System.Byte[] _Image;
//        [System.Xml.Serialization.XmlElementAttribute("Image", DataType = "base64Binary")]
//        public System.Byte[] Image
//        {
//            get { return _Image; }
//            set { _Image = value; }
//        }

//        private System.Byte[] m_NodeImage;
//        [System.Xml.Serialization.XmlElementAttribute("NodeImage", DataType = "base64Binary")]
//        public System.Byte[] NodeImage
//        {
//            get { return m_NodeImage; }
//            set { m_NodeImage = value; }
//        }

//        private System.Byte[] m_NodeSelectedImage;
//        [System.Xml.Serialization.XmlElementAttribute("NodeSelectedImage", DataType = "base64Binary")]
//        public System.Byte[] NodeSelectedImage
//        {
//            get { return m_NodeSelectedImage; }
//            set { m_NodeSelectedImage = value; }
//        }
//        int? selectedImageIndex;
//        public int? SelectedImageIndex
//        {
//            get { return selectedImageIndex; }
//            set { selectedImageIndex = value; }
//        }

//        int? imageIndex;
//        public int? ImageIndex 
//        {
//            get { return imageIndex; }
//            set { imageIndex = value; }
//        }
//        public string AuthRule { get; set; }
//        #endregion



//        private int _ID;
//        public int ID
//        {
//            get { return _ID; }
//            set { _ID = value; }
//        }
//        private int _ParentID;
//        public int ParentID
//        {
//            get { return _ParentID; }
//            set { _ParentID = value; }
//        }



//        public bool IsCategory { get; set; }

//        public string Category { get; set; }
//    }

//    /// <summary>
//    /// Contiene las columnas de un objeto Table .-
//    /// </summary>
//    [XmlRoot("MenuItemList"), SerializableAttribute]
//    public class MenuItemList : Entities<MenuItem>
//    {

//    }

//    /// <summary>
//    /// Contiene las imagenes del menu
//    /// </summary>
//    [XmlRoot("MenuImageList"), SerializableAttribute]
//    public class MenuImageList : Entities<MenuImage>
//    {
//        public MenuImage Get(int index)
//        { 
//            var item = from s in this where s.Index.Equals(index) select s;

//            return item.FirstOrDefault<MenuImage>();
//        }
//    }

//    [Serializable]
//    public class MenuImage : Entity
//    {

//        int _Index;

//        public int Index
//        {
//            get { return _Index; }
//            set { _Index = value; }
//        }




//        private System.Byte[] m_ImageBytes;
//        [System.Xml.Serialization.XmlElementAttribute("ImageBytes", DataType = "base64Binary")]
//        public System.Byte[] ImageBytes
//        {
//            get { return m_ImageBytes; }
//            set { m_ImageBytes = value; }
//        }

//        private Image m_Image;
//        [System.Xml.Serialization.XmlIgnore()]
//        public Image Image
//        {
//            get
//            {
//                if (ImageBytes != null)
//                    return Fwk.HelperFunctions.TypeFunctions.ConvertByteArrayToImage(ImageBytes);
//                else
//                    return null;

//            }

//        }
//        public void SetIamge(Image i, string extension)
//        {
//            m_ImageBytes = Helper.LoadImage(i, extension);
//        }

        
//    }

//}
