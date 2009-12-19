using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Bases;

namespace $solutionname$.Common.BE
{
    [XmlInclude(typeof(SampleBE)), Serializable]
    public class SampleBE : Entity
    {
        int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
    }

    [XmlRoot("SampleBEList"), SerializableAttribute]
    public class SampleBEList : Entities<SampleBE>
    {


        public SampleBE GetFirstById(int pId)
        {
            return this.First(p => p.Id == pId);
        }
    }
}
