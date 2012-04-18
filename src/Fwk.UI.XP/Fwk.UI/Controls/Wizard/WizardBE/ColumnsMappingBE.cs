using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;

namespace Fwk.UI.Controls.Wizard.BE
{

    #region [ColumnsMappingBEList]
    //Existe una BE similar en el Front, que se utiliza en el Front

    [XmlRoot("ColumnsMappingBEList"), SerializableAttribute]
    public class ColumnsMappingBEList : Entities<ColumnsMappingBE>
    {
        /// <summary>
        /// Metodo estatico que retorna un objeto Team_gList apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>Team_gList</returns>
        public static ColumnsMappingBEList GetColumnsMappingBEListFromXml(String pXml)
        {
            return GetFromXml<ColumnsMappingBEList>(pXml);
        }

    }

    [XmlInclude(typeof(ColumnsMappingBE)), Serializable]
    public class ColumnsMappingBE : Entity
    {
        private String _ColumnSource;
        private String _ColumnTarget;
        private String _ColumnTargetDBName;
        private String _ColumnSourceDBName;
        private Boolean _Required;


        public Boolean Required
        {
            get
            {
                return _Required;
            }
            set
            {
                _Required = value;
            }
        }

        [XmlElement(ElementName = "ColumnSourceDBName", DataType = "string")]
        public String ColumnSourceDBName
        {
            get
            {
                return _ColumnSourceDBName;
            }
            set
            {
                _ColumnSourceDBName = value;
            }
        }

        [XmlElement(ElementName = "ColumnTargetDBName", DataType = "string")]
        public String ColumnTargetDBName
        {
            get
            {
                return _ColumnTargetDBName;
            }
            set
            {
                _ColumnTargetDBName = value;
            }
        }

        [XmlElement(ElementName = "ColumnTarget", DataType = "string")]
        public String ColumnTarget
        {
            get
            {
                return _ColumnTarget;
            }
            set
            {
                _ColumnTarget = value;
            }
        }

        [XmlElement(ElementName = "ColumnSource", DataType = "string")]
        public String ColumnSource
        {
            get
            {
                return _ColumnSource;
            }
            set
            {
                _ColumnSource = value;
            }
        }

        #region [Constructores]

        public ColumnsMappingBE(String pColumnSource, String pColumnSourceDBName, String pColumnTarget, String pColumnTargetDBName, Boolean pRequired)
        {
            _ColumnSource = pColumnSource;
            _ColumnTarget = pColumnTarget;
            _ColumnTargetDBName = pColumnTargetDBName;
            _ColumnSourceDBName = pColumnSourceDBName;
            _Required = pRequired;
        }

        public ColumnsMappingBE(String pColumnSource, String pColumnTarget)
        {
            _ColumnSource = pColumnSource;
            _ColumnTarget = pColumnTarget;
        }
        
        public ColumnsMappingBE(String pColumnSource, String pColumnTarget, Boolean pIsRequired)
        {
            _ColumnSource = pColumnSource;
            _ColumnTarget = pColumnTarget;
            _Required = pIsRequired;
        }

        public ColumnsMappingBE()
        { }

        #endregion

        public static ColumnsMappingBE GetColumnsMappingBEFromXml(String pXml)
        {
            return (ColumnsMappingBE)Entity.GetFromXml<ColumnsMappingBE>(pXml);
        }

    }

    #endregion

}
