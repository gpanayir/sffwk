using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;


namespace Fwk.Security.Cryptography.Config
{
    /// <summary>
    /// ConfigProvider . 
    /// 
    ///
    /// </summary>
    /// <date>2006/09/02</date>
    /// <author>moviedo</author>
    [Serializable]
    public class CypherProviderElement : ConfigurationElement
    {
        #region <constructor>
        /// <summary>
        /// Constructor de RuleElement.
        /// </summary>
        public CypherProviderElement() { }
        #endregion

        #region <public properties>
        /// <summary>
        /// Nombre de la regla. Es el identificador de una regla
        /// por lo tanto este nombre no debe repetirse.
        /// </summary>
        [ConfigurationProperty("name", IsRequired = true, IsKey = true), StringValidator(InvalidCharacters = @" ~!@#$%^&*()[]{}/;'""|\")]
        public string Name
        {
            get
            {
                return (string)this["name"];
            }
            set { this["name"] = value; }
        }
        /// <summary>
        ///
        /// file o sqldata
        /// </summary>
         [ConfigurationProperty("type", IsRequired = true, IsKey = false),
         StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public String Type
        {
            get
            {
                return (string)this["type"];
            }
            set { this["type"] = value; }
        }

        


        
        /// <summary>
        /// if type = file -->  text file 
         /// if type = sqldata cnn string name
        /// </summary>
        [ConfigurationProperty("source", IsRequired = false, IsKey = false),
         StringValidator(InvalidCharacters = @"~!@#$%^&*[]{};'""|")]
        public string Source
        {
            get
            {
                return (string)this["source"];
            }
            set { this["source"] = value; }
        }
        //public override string ToString()
        //{
        //    return string.Concat("Cuenta: ", this.Cuenta, "Subarea: ", this.ProviderName);
        //}

        #endregion
        //string cnnStringName;

        //public string CnnStringName
        //{
        //    get
        //    {
                
        //        return cnnStringName;
        //    }
        //    set
        //    {
                
        //        cnnStringName = value;
        //        if (ConfigurationManager.ConnectionStrings[cnnStringName]!=null)
        //            cnnString = ConfigurationManager.ConnectionStrings[cnnStringName].ConnectionString;
        //    }
        //}
      
       
        //string cnnString;
        //public string CnnString
        //{
        //    get
        //    {
        //        //if (String.IsNullOrEmpty(cnnString))
        //        //    cnnString = ConfigurationManager.ConnectionStrings["meucci"].ConnectionString;
        //        return cnnString;
        //    }
            
        //}
       
    }
}
