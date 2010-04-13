using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace EasyDirectoryReplace
{
    [XmlInclude(typeof(ReplacePattern)), Serializable]
    public class ReplacePattern :Entity
    {
        string _TextOld;

        public string TextOld
        {
            get { return _TextOld; }
            set { _TextOld = value; }
        }
        string _TextNew;

        public string TextNew
        {
            get { return _TextNew; }
            set { _TextNew = value; }
        }
        bool _ReplaceContent;

        public bool ReplaceContent
        {
            get { return _ReplaceContent; }
            set { _ReplaceContent = value; }
        }

    }
    [XmlInclude(typeof(ReplacePattern)), Serializable]
    public class ReplacePaternList : Entities<ReplacePattern>
    { }


}
