using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Xml.Serialization;
using Fwk.Transaction;

namespace Fwk.Bases
{
	/// <summary>
    /// Colección de configuraciones de servicios de negocio.
	/// </summary>
	/// <remarks>
	/// Permite búsquedas indexadas por nombre de servicio (<see cref="ServiceConfiguration.Name"/>).
	/// </remarks>
	/// <date>2008-04-10T00:00:00</date>
	/// <author>moviedo</author>
    [XmlRoot("ServiceConfigurationCollection"), SerializableAttribute]
	public class ServiceConfigurationCollection :  KeyedCollection<string, ServiceConfiguration> 
	{
        /// <summary>
        /// Devuelve la propiedad a usar como clave.
        /// </summary>
        /// <param name="pItem">La configuración de servicio de la que se quiere extraer el valor clave.</param>
        /// <date>2008-04-10T00:00:00</date>
        /// <author>moviedo</author>
        protected override string GetKeyForItem(ServiceConfiguration pItem)
        {
            return pItem.Name;
        }
       
	}
    

	/// <summary>
	/// Clase que contiene la configuración de un servicio de negocio.
	/// </summary>
	/// <date>2008-04-07T00:00:00</date>
	/// <author>moviedo</author>
    [XmlInclude(typeof(ServiceConfiguration)), Serializable]
    public class ServiceConfiguration : BaseEntity
	{

        string _Name;
        string _Description;
        string _Handler;
        string _Request;
        string _Response;
        bool _Available;
        bool _Audit;
        TransactionalBehaviour _TransactionalBehaviour;
        IsolationLevel _IsolationLevel;
        int _Timeout;
        bool _Cacheable;
        private string _FolderRepositoryKey;
        private string _CreatedUserName;

        public string CreatedUserName
        {
            get { return _CreatedUserName; }
            set { _CreatedUserName = value; }
        }
        private DateTime _CreatedDateTime;

        public DateTime CreatedDateTime
        {
            get { return _CreatedDateTime; }
            set { _CreatedDateTime = value; }
        }
		/// <summary>
		/// Nombre del servicio de negocio.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
        [XmlAttribute("name")]
		public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

		/// <summary>
		/// Descripción del servicio de negocio.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
		public string Description
		{
			get { return _Description; }
			set { _Description = value; }
		}

		/// <summary>
		/// Nombre completo de la clase del servicio y nombre del assembly.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
		public string Handler
		{
			get { return _Handler; }
			set { _Handler = value; }
		}

		/// <summary>
		/// Nombre completo del request del servicio y nombre del assembly.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
		public string Request
		{
			get { return _Request; }
			set { _Request = value; }
		}

		/// <summary>
		/// Nombre completo del response del servicio y nombre del assembly.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
		public string Response
		{
			get { return _Response; }
			set { _Response = value; }
		}

		/// <summary>
		/// Indica si el servicio está disponible para ser ejecutedo.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
		public bool Available
		{
			get { return _Available; }
			set { _Available = value; }
		}

		/// <summary>
		/// Indica si la  ejecución del servicio debe ser auditadao.el servicio está disponible para ser ejecutedo.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
		public bool Audit
		{
			get { return _Audit; }
			set { _Audit = value; }
		}

		/// <summary>
		/// Opciones de comportamiento del ámbito transaccional.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
        public TransactionalBehaviour TransactionalBehaviour
		{
            get { return _TransactionalBehaviour; }
            set { _TransactionalBehaviour = value; }
		}


		/// <summary>
		/// Nivel de aislamiento de la transacción.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
        public IsolationLevel IsolationLevel
		{
			get { return _IsolationLevel; }
			set { _IsolationLevel = value; }
		}


		/// <summary>
		/// Tiempo máximo de espera para transacción en segundos.
		/// </summary>
		/// <date>2008-04-07T00:00:00</date>
		/// <author>moviedo</author>
		public int Timeout
		{
			get { return _Timeout; }
			set { _Timeout = value; }
		}

        /// <summary>
        /// Indica si el resultado del servicio de almacena en cache.
        /// </summary>
        /// <date>2006-10-27T00:00:00</date>
        /// <author>moviedo</author>
        public bool Cacheable
        {
            get { return _Cacheable; }
            set { _Cacheable = value; }
        }
        
		
        /// <summary>
        /// 
        /// </summary>
        public string FolderRepositoryKey
        {
            get { return _FolderRepositoryKey; }
            set { _FolderRepositoryKey = value; }
        }

       

        #region [Methods]
        /// <summary>
        /// Metodo estatico que retorna un objeto ServiceConfiguration apartir de un xml.-
        /// </summary>
        /// <param name="pXml">String con el xml</param>
        /// <returns>ServiceConfiguration</returns>
        public static ServiceConfiguration GetServiceConfigurationFromXml(String pXml)
        {
            return ServiceConfiguration.GetFromXml<ServiceConfiguration>(pXml);
        }
        /// <summary>
        /// Realiza un clon del objeto
        /// </summary>
        /// <returns></returns>
        public ServiceConfiguration Clone()
        {
            return (ServiceConfiguration)base.Clone();
        }
        /// <summary>
        /// Sobreescribe el metodo para retornar informacion del servicio
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder wStringBuilder = new StringBuilder();
            wStringBuilder.AppendLine("Service: ");
            wStringBuilder.AppendLine(_Name);

            wStringBuilder.AppendLine(" Handler: ");
            wStringBuilder.AppendLine(_Handler);

            wStringBuilder.AppendLine(" Request: ");
            wStringBuilder.AppendLine(_Request);
            wStringBuilder.AppendLine(" Response: ");
            wStringBuilder.AppendLine(_Response);
            wStringBuilder.AppendLine(" Cacheable: ");
            wStringBuilder.AppendLine(_Cacheable.ToString());
            wStringBuilder.AppendLine(" Isolation Level: ");
            wStringBuilder.AppendLine(Enum.GetName(typeof(IsolationLevel), _IsolationLevel));
            wStringBuilder.AppendLine(" Transactional Behaviour: ");
            wStringBuilder.AppendLine(Enum.GetName(typeof(IsolationLevel), _TransactionalBehaviour));

            wStringBuilder.AppendLine(string.Concat(" Creation info: user:" , _CreatedUserName, "Date: " ,_CreatedDateTime.ToString()));
            return wStringBuilder.ToString();
        }
        #endregion
	}
}
