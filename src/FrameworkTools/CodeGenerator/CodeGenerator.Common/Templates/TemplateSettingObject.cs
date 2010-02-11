using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;

namespace CodeGenerator.Back.Common
{
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class TemplateSettingObject
    {
        private NamespacesPattern _TableDataGateway;
        private StoreProceduresPattern _StoreProcedures;
        private Entities _Entities;
        private MethodsName _MethodsName;
        private Methods _Methods;
        private String _FullFileName;
        private Others _OthersSettings;

        public Others OthersSettings
        {
            get { return _OthersSettings; }
            set { _OthersSettings = value; }
        }
        public  StoreProceduresPattern StoreProcedures
        {
            get { return _StoreProcedures; }
            set { _StoreProcedures = value; }
        }


        public NamespacesPattern Namespaces
        {
            get { return _TableDataGateway; }
            set { _TableDataGateway = value; }
        }



        public MethodsName MethodsName
        {
            get { return _MethodsName; }
            set { _MethodsName = value; }
        }



        public Entities Entities
        {
            get { return _Entities; }
            set { _Entities = value; }
        }


        public Methods Methods
        {
            get { return _Methods; }
            set { _Methods = value; }
        }

        public String FullFileName
        {
            get { return _FullFileName; }
            set { _FullFileName = value; }
        }

        public String FileName
        {
            get { return System.IO.Path.GetFileName(_FullFileName); ; }
           
        }
        public TemplateSettingObject()
        {
            _TableDataGateway = new NamespacesPattern();
            _StoreProcedures = new StoreProceduresPattern();
            _Entities = new Entities();
            _MethodsName = new MethodsName();
            _Methods = new Methods();
            _OthersSettings = new Others();
        }
        public TemplateSettingObject Clone()
        {
            TemplateSettingObject wTemplateSettingObject = new TemplateSettingObject();

            wTemplateSettingObject._MethodsName = this._MethodsName;
            wTemplateSettingObject._StoreProcedures  = this._StoreProcedures;
            wTemplateSettingObject._TableDataGateway = this._TableDataGateway;
            wTemplateSettingObject._Entities = this.Entities;
            wTemplateSettingObject._Methods = this._Methods;
            wTemplateSettingObject._MethodsName = this._MethodsName;
            wTemplateSettingObject._FullFileName = this._FullFileName;
            wTemplateSettingObject._OthersSettings = this._OthersSettings;
            return wTemplateSettingObject;
        }
    }


    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class NamespacesPattern
    {
        private String _BusinessEntities = "BackEnd.BusinessEntities";
        private String _InterfaceServices = "InterfaceServices";
        private String _BusinessService = "BackEnd.BusinessService";
        private String _BusinessComponents = "BackEnd.BusinessComponents";
        private String _DataAccessComponent = "BackEnd.DataAccessComponents";
        private String _TableDataGateway = "BackEnd.TableDataGateway";

        [Description("SVC Namespace")]
        public String BusinessService
        {
            get { return _BusinessService; }
            set { _BusinessService = value; }
        }
        [Description("BC Namespace")]
        [Category("Namespaces")]
        public String BusinessComponents
        {
            get { return _BusinessComponents; }
            set { _BusinessComponents = value; }
        }


        [Description("DAC Namespace")]
        [Category("Namespaces")]
        public String DataAccessComponent
        {
            get { return _DataAccessComponent; }
            set { _DataAccessComponent = value; }
        }
        [Description("TDG Namespace")]
        [Category("Namespaces")]
        public String TableDataGateway
        {
            get { return _TableDataGateway; }
            set { _TableDataGateway = value; }
        }


        [Description("ISVC Namespace")]
        [Category("Namespaces")]
        public String InterfaceServices
        {
            get { return _InterfaceServices; }
            set { _InterfaceServices = value; }
        }

        [Description("Entities Namespace")]
        [Category("Namespaces")]
        public String BusinessEntities
        {
            get { return _BusinessEntities; }
            set { _BusinessEntities = value ; }
        }



        public override string ToString()
        {
            return "Inserte aquí un prefijo al Namespace de cada componente";
        }
    }

   

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Entities
    {
        String _CollectionsSufix = "List";

        [Description("Indica como se identifican las clases tipo Entities. ej: ClienteSBE")]
        public String CollectionsSufix
        {
            get { return _CollectionsSufix; }
            set { _CollectionsSufix = value; }
        }
        
        String _EntitySufix = "BE";
        

        [Description("Indica como se identifican las clases tipo Entity. ej: ClienteBE")]
        public String EntitySufix
        {
            get { return _EntitySufix; }
            set { _EntitySufix = value; }
        }

        private String _BusinessDataSufix = "Collection";
        [Description("Indica como se identifican las clases tipo Entity pero dentro de una interfaz de servicio. ej: ClienteBE")]
        public String BusinessDataSufix
        {
            get { return _BusinessDataSufix; }
            set { _BusinessDataSufix = value; }
        }

        private String _BusinessDataCollectionSufix = "List";
        [Description("Indica como se identifican las clases tipo Entities pero dentro de una interfaz de servicio. ej: ClienteBE")]
        public String BusinessDataCollectionSufix
        {
            get { return _BusinessDataCollectionSufix; }
            set { _BusinessDataCollectionSufix = value; }
        }


        public override string ToString()
        {
            return "Define el prefijo o sufijo de las clases IEntity. ej: ClientBE para la entidad  ClientList para su colección.";
        }


    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Others
    {
        String _ConnectionStringKey = "ConnectionStringKey";

        public String ConnectionStringKey
        {
            get { return _ConnectionStringKey; }
            set { _ConnectionStringKey = value; }
        }

        public override string ToString()
        {

            return String.Empty;
        }
    }
    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class MethodsName
    {
        String _Insert = "Insert";
        public String Insert
        {
            get { return _Insert; }
            set { _Insert = value; }
        }

        String _Delete = "Delete";
        public String Delete
        {
            get { return _Delete; }
            set { _Delete = value; }
        }

        String _Update = "Update";
        public String Update
        {
            get { return _Update; }
            set { _Update = value; }
        }

        String _GetAll = "GetAll";
        public String GetAll
        {
            get { return _GetAll; }
            set { _GetAll = value; }
        }

        String _GetByParam = "GetByParam";
        public String GetByParam
        {
            get { return _GetByParam; }
            set { _GetByParam = value; }
        }

        String _GetAllPaginated = "GetAllPaginated";
        public String GetAllPaginated
        {
            get { return _GetAllPaginated; }
            set { _GetAllPaginated = value; }
        }

        public override string ToString()
        {
            //return "Methods name to use in generated backend code";
            return "Nombre de los métodos para los componentes de backend";
        }
    }



    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class StoreProceduresPattern
    {
        private String _DeleteSufix = "_d";

        public String DeleteSufix
        {
            get { return _DeleteSufix; }
            set { _DeleteSufix = value; }
        }
        private String _UpdateSufix = "_u";

        public String UpdateSufix
        {
            get { return _UpdateSufix; }
            set { _UpdateSufix = value; }
        }
        private String _InsertSufix = "_i";

        public String InsertSufix
        {
            get { return _InsertSufix; }
            set { _InsertSufix = value; }
        }
        private String _GetByParamSufix = "_g";

        public String GetByParamSufix
        {
            get { return _GetByParamSufix; }
            set { _GetByParamSufix = value; }
        }
        private String _GetAllSufix = "_s";

        public String GetAllSufix
        {
            get { return _GetAllSufix; }
            set { _GetAllSufix = value; }
        }

        String _GetAllPaginated = "_sp";
        public String GetAllPaginated
        {
            get { return _GetAllPaginated; }
            set { _GetAllPaginated = value; }
        }

        public override string ToString()
        {
            //return "Store procedure sufix pattern";
            return "Sufijos o prefijos de los SPs. Ej: Insert_i";
        }

    }

    [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
    public class Methods
    {
        private Boolean _IncludeInsert = true;

        public Boolean IncludeInsert
        {
            get { return _IncludeInsert; }
            set { _IncludeInsert = value; }
        }
        private Boolean _IncludeDelete = true;

        public Boolean IncludeDelete
        {
            get { return _IncludeDelete; }
            set { _IncludeDelete = value; }
        }
        private Boolean _IncludeUpdate = true;

        public Boolean IncludeUpdate
        {
            get { return _IncludeUpdate; }
            set { _IncludeUpdate = value; }
        }
        private Boolean _IncludeGetAll = true;

        public Boolean IncludeGetAll
        {
            get { return _IncludeGetAll; }
            set { _IncludeGetAll = value; }
        }
        private Boolean _IncludeGetByParam = true;

        public Boolean IncludeGetByParam
        {
            get { return _IncludeGetByParam; }
            set { _IncludeGetByParam = value; }
        }
        private Boolean _IncludeGetPaginated = true;

        public Boolean IncludeGetPaginated
        {
            get { return _IncludeGetPaginated; }
            set { _IncludeGetPaginated = value; }
        }


        private Boolean _GenerateBatch = true;
        
        
        [Description("Establece si se insertan en forma de batch")]
        public Boolean GenerateBatch
        {
            get { return _GenerateBatch; }
            set { _GenerateBatch = value; }
        }


        public override string ToString()
        {
            return "Configuracion de motodos en el backend";
        }
    }

}
