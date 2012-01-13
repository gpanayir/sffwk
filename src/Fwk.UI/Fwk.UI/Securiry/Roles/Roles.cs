using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Fwk.Security.Common;

namespace Fwk.UI.Security.Controls
{
    [XmlInclude(typeof(RolGrid)), Serializable]
    public class RolGrid
    {

        public RolGrid() { }

        public RolGrid(Rol pRol) 
        {
            _RolName = pRol.RolName;
            _Description = pRol.Description;
   
        }
        public Rol GetRol()
        {
            return new Rol (_RolName,_Description);
        }
        public RolGrid(string pname)
        {
            _RolName = pname;
        }
        public RolGrid(string name, string description)
        {
            _RolName = name;
            _Description = description;
        }
        String _RolName;

        public String RolName
        {
            get { return _RolName; }
            set { _RolName = value; }
        }
        String _Description;
        public String Description
        {
            get { return _Description; }
            set { _Description = value; }
        }
        bool _Checked = false;

        public bool Checked
        {
            get { return _Checked; }
            set { _Checked = value; }
        }
        public override string ToString()
        {
            return _RolName;
        }

    }
    [XmlRoot("RolList"), SerializableAttribute]
    public class RolGridList : List<RolGrid>
    {
        public RolGridList()
        { }

        public RolGridList(RolList pRolList)
        {

            IEnumerable<RolGrid> selectedList = from r in pRolList select new RolGrid { Description = r.Description, RolName = r.RolName };
            this.AddRange(selectedList);

        }

    }
}
