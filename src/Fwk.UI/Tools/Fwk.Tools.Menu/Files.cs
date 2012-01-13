using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace Fwk.UI.Controls.Menu
{
    [XmlInclude(typeof(MenuFile)), Serializable]
    public class MenuFile:Fwk.Bases.Entity
    {
        public MenuFile()
        { }

        public MenuFile(System.IO.FileInfo file)
        {
            name = file.Name;
            fullName = file.FullName;
            _Saved = true;
        }

        bool _FileExist = true;

        public bool FileExist
        {
            get { return _FileExist; }
            set { _FileExist = value; }
        }
        string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        string fullName;

        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }
        bool _Saved = true;

        public bool Saved
        {
            get { return _Saved; }
            set { _Saved = value; }
        }
        ToolBar _Toolbar = new ToolBar ();
        

        public ToolBar Toolbar
        {
            get { return _Toolbar; }
            set { _Toolbar = value; }
        }
        MenuNavBar _MenuBar = new MenuNavBar();
        public MenuNavBar MenuBar
        {
            get { return _MenuBar; }
            set { _MenuBar = value; }
        }

    }
    [XmlRoot("MenuFileList"), SerializableAttribute]
    public class MenuFileList : Fwk.Bases.Entities<MenuFile>
    { }
}
