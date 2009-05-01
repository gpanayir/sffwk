using System.ComponentModel;
using System.Text;

namespace ConfigurationApp
{
    /// <summary>
    /// Clase qque reprecenta un clave de configuracion
    /// </summary>
    internal class Key
    {
        private string _GroupName;
        private string _Name;
        private string _Value;
        private string _FileName;

        /// <summary>
        /// Nombre del archivo al que pertenece
        /// </summary>
        [Description("Nombre del archivo al que pertenece")]
        public string FileName
        {
            get { return _FileName; }
            
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name">Nombre</param>
        /// <param name="GroupName">Nombre del grupo al pertenece</param>
        /// <param name="FileName">Nombre del grupo al pertenece</param>
        public Key(string Name, string GroupName, string FileName)
        {
            _Name = Name;
            _GroupName = GroupName;
            _FileName = FileName;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Name">Nombre del Setting</param>
        public Key(string Name)
        {
            _Name = Name;

        }
        [Description("Nombre del al que pertenece")]
        public string GroupName
        {
            get { return _GroupName; }

        }
        [Description("Nombre de clave")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }

        }

        [Description("Valor de configuracion que asume")]
        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

    }
}