using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ProjectReferencesCreator
{
   
    [XmlRoot("Project", Namespace = "http://schemas.microsoft.com/developer/msbuild/2003", IsNullable = false),Serializable]
    public class Project :Fwk.Bases.BaseEntity
    {
        PropertyGroup _PropertyGroup = new PropertyGroup ();
        [XmlElement("PropertyGroup")]
        public PropertyGroup PropertyGroup
        {
            get { return _PropertyGroup; }
            set { _PropertyGroup = value; }
        }
    }

    [XmlInclude(typeof(PropertyGroup)), Serializable]
    public class PropertyGroup : Fwk.Bases.BaseEntity
    {
        string _ReferencePath;
        [XmlElement("ReferencePath")]
        public string ReferencePath
        {
            get { return _ReferencePath; }
            set { _ReferencePath = value; }
        }
        
    }
}
