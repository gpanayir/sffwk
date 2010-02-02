//using System;
//using Fwk.Bases;
//using System.Xml.Serialization;
//using System.Collections.Generic;

//namespace Fwk.CodeGenerator.Common
//{
//    /// <summary>
//    /// Coleccion de objetos Template, hereda de System.Collections.Generic.List<>
//    /// </summary>
//    public class Templates : Entities<Template>
//    {

//        /// <summary>
//        /// Obtienen una tabla determinada en la coleccion de tablas.-
//        /// </summary>
//        /// <param name="pTemplateName">Nombre de la tabla.-</param>
//        /// <returns></returns>
//        private Template GetTemplate(string pTemplateName)
//        {
//            foreach (Template wTemplate in this)
//            {
//                if (pTemplateName == wTemplate.Name)
//                {
//                    return wTemplate;
//                }
//            }
//            return null;
            
//        }
//        public Template GetTemplate(TemplateProviderEnum pTemplateProviderEnum)
//        {
//            string str = Enum.GetName(typeof(TemplateProviderEnum), pTemplateProviderEnum);

//            return GetTemplate(str);
//        }

      
//    }

//    /// <summary>
//    /// Descripción breve de Tabla.
//    /// </summary>
    
//    public class Template : Entity
//    {

//        #region Atributos

//        private Keys _Keys;
        
//        private string _Name;
     

//        #endregion

//        public Template()
//        {
//            _Keys = new Keys();
//        }

//        #region Propiedades
       
//        /// <summary>
//        /// Nombre del template
//        /// </summary>
//        public string Name
//        {
//            get { return _Name; }
//            set { _Name = value; }
//        }
//        /// <summary>
//        /// Claves del template 
//        /// </summary>
//        public Keys Keys
//        {
//            get { return _Keys; }
//            set { _Keys = value; }
//        }
      



//        #endregion

        
        
//    }
//    /// <summary>
//    /// Coleccion de objetos Template, hereda de System.Collections.Generic.List<>
//    /// </summary>
//    public class Keys : Entities<Key>
//    {

//        /// <summary>
//        /// Obtienen una tabla determinada en la coleccion de tablas.-
//        /// </summary>
//        /// <param name="pTemplateName">Nombre de la tabla.-</param>
//        /// <returns></returns>
//        public Key GetKey(string pName)
//        {
//            foreach (Key o in this)
//            {
//                if (pName == o.Name)
//                {
//                    return o;
//                }
//            }
//            return null;

//        }



//    }
//    public class Key : Entity
//    {
//        private string _Name;

//        public string Name
//        {
//            get { return _Name; }
//            set { _Name = value; }
//        }
//        private string _TextContent;
//        private ITemplateAtributes _TemplateAtribute;

//        public ITemplateAtributes TemplateAtribute
//        {
//            get { return _TemplateAtribute; }
//            set { _TemplateAtribute = value; }
//        }
        
//        /// <summary>
//        /// Es el template en si.- este atributo se llama Body en el xml.-
//        /// </summary>
//        public string TextContent
//        {
//            get { return _TextContent; }
//            set { _TextContent = value; }
//        }

        
//        /// <summary>
//        /// Genera una nueva Key a partir de esta 
//        /// </summary>
//        /// <param name="pCloneName">Nombre para la nueva Key</param>
//        /// <returns>Key</returns>
//        public Key Clone(string pCloneName)
//        {
//            Key wKey = new Key();

//            wKey._Name = pCloneName;
//            wKey._TextContent = this._TextContent;
//            return wKey;
//        }
//    }

//    public class StoreProcedureTemplate : ITemplateAtributes
//    {

//        private string _Name;
//        private string _Description;
//        private string _Body;

//        /// <summary>
//        /// Cuerpo del atributo
//        /// </summary>
//        public string Body
//        {
//            get { return _Body; }
//            set { _Body = value; }
//        }
//        /// <summary>
//        /// Descripcion.-
//        /// </summary>
//        public string Description
//        {
//            get { return _Description; }
//            set { _Description = value; }
//        }

//        /// <summary>
//        /// Nombre del template
//        /// </summary>
//        public string Name
//        {
//            get { return _Name; }
//            set { _Name = value; }
//        }
//    }

//    public interface ITemplateAtributes
//    {
//        string Description { get; set; }
//        string Name { get; set; }
//        string Body { get; set; }
//    }

//}

