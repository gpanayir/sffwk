using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System;
using System.Collections.Generic;
using Fwk.Bases;
using System.Xml.Serialization;
using System.Xml;
using Fwk.Security.BE;
using Fwk.Security.Common;

namespace Fwk.Security.ISVC.CreateUsersBatch
{

    [Serializable]
    public class CreateUsersBatchRequest : Request<Param>
    {
        public CreateUsersBatchRequest()
        {
            this.ServiceName = "CreateUsersBatchService";
        }
    }
    [XmlInclude(typeof(Param)), Serializable]
    public class Param : Entity
    {
        private String _ServerName;
        private String _DataBaseName;
        private ColumnsMappingBEList _MappingList;
        private System.Data.DataTable _DataToImport;
        private Boolean _ImportFromDB;


		public Boolean ImportFromDB
		{
			get
			{
				return _ImportFromDB;
			}
			set
			{
				_ImportFromDB = value;
			}
		}

		public System.Data.DataTable DataToImport
		{
			get
			{
				return _DataToImport;
			}
			set
			{
				_DataToImport = value;
			}
		}

		public ColumnsMappingBEList MappingList
		{
			get
			{
				return _MappingList;
			}
			set
			{
				_MappingList = value;
			}
		}

		public String DataBaseName
		{
			get
			{
				return _DataBaseName;
			}
			set
			{
				_DataBaseName = value;
			}
		}

		public String ServerName
		{
			get
			{
				return _ServerName;
			}
			set
			{
				_ServerName = value;
			}
		}
    }

    [Serializable]
    public class CreateUsersBatchResponse : Response<Result>
    {
    }

    [XmlInclude(typeof(Result)), Serializable]
    public class Result : Entity
    {
        private System.Data.DataTable _ImportedErrorsTable;
        private System.Data.DataTable _ImportedRepeatedTable;        		
        private Int32 _RecordsImportedSuccessfully;
        private Int32 _ImportedRepeated;
        private Int32 _ImportedErrors;


        public System.Data.DataTable ImportedRepeatedTable
        {
            get
            {
                return _ImportedRepeatedTable;
            }
            set
            {
                _ImportedRepeatedTable = value;
            }
        }

		public Int32 ImportedErrors
		{
			get
			{
				return _ImportedErrors;
			}
			set
			{
				_ImportedErrors = value;
			}
		}

		public Int32 ImportedRepeated
		{
			get
			{
				return _ImportedRepeated;
			}
			set
			{
				_ImportedRepeated = value;
			}
		}

		public Int32 SuccefullImportedRecords
		{
			get
			{
                return _RecordsImportedSuccessfully;
			}
			set
			{
                _RecordsImportedSuccessfully = value;
			}
		}

		public System.Data.DataTable ImportedErrorsTable
		{
			get
			{
				return _ImportedErrorsTable;
			}
			set
			{
				_ImportedErrorsTable = value;
			}
		}
    }

    #region [ColumnsMappingBEList]
    //Existe una BE similar en el Front, que se utiliza en el Front

    [XmlRoot("ColumnsMappingBEList"), SerializableAttribute]
    public class ColumnsMappingBEList : Entities<ColumnsMappingBE>
    {

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

        public ColumnsMappingBE()
        { }

    }

    #endregion

    #region [ImportedErrorsBEList]

    [XmlRoot("ImportedErrorsBEList"), SerializableAttribute]
    public class ImportedErrorsBEList : Entities<ImportedErrorsBE>
    {

    }

    [XmlInclude(typeof(ImportedErrorsBE)), Serializable]
    public class ImportedErrorsBE : Entity
    {
    }

    #endregion


}
