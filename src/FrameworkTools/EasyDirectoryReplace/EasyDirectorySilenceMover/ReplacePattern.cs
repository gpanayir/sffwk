using System;
using System.Collections.Generic;

using System.Text;
using Fwk.Bases;
using System.Xml.Serialization;

namespace EasyDirectoryReplace
{
    [XmlInclude(typeof(ReplacePattern)), Serializable]
    public class ReplacePattern :Entity
    {
        string _From;

        public string From
        {
            get { return _From; }
            set { _From = value; }
        }
        string _To;

        public string To
        {
            get { return _To; }
            set { _To = value; }
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
