using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using Fwk.Configuration;
using Fwk.Exceptions;
using System.Diagnostics;
using Fwk.Blocking;


namespace Fwk.Blocking
{
    /// <summary>
    /// Marca base de blocking .- Si decea implementar su propia clase de marcas haga heredadr su 
    /// clase de IBlockingMark e implemente una clase IBlockingEngine para la nueva definicion 
    /// de marca personalizada.
    /// </summary>
    /// <Auhor>moviedo</Auhor>
    public class BlockingMarkBase : IBlockingMark
    {
        #region Private members
        private Boolean m_AlreadyExists;
        private DateTime? m_DueDate;
        private String msz_Process;
        private Guid? m_FwkGuid;
        private Int32? m_BlockingId;
        //private Int32? m_BlockingTime;
        private String m_User;
        private Int32? m_TTL;
        private String m_TableName = "BlockingMarks";
        private String m_Attribute;
        private String m_AttValue;

       
        #endregion

        #region Constructors
        public String AttValue
        {
            get { return m_AttValue; }
            set { m_AttValue = value; }
        }

        public String Attribute
        {
            get { return m_Attribute; }
            set { m_Attribute = value; }
        }
        /// <summary>
        /// Constructor que asigna un nombre de tabla de modo de tratar con una tabla que no 
        /// sea la por defecto de blocking.
        /// Este constructor genera un nuevo valor de GUID
        /// </summary>
        /// <param name="pTableName">Nombre de tabla de marcas personalizadas.-</param>
        public BlockingMarkBase(String pTableName)
        {
            m_TableName = pTableName;
            m_FwkGuid = Guid.NewGuid();
            //Set default values
            SetValues();
        }

        /// <summary>
        /// Constructor que asigna un nombre de tabla de modo de tratar con una tabla que no 
        /// sea la por defecto de blocking.
        /// </summary>
        /// <param name="pGuid">Guid para el caso en que ya sea conocido este valor. Generalmente cuando
        /// la marca ya existe en la BD.
        /// </param>
        public BlockingMarkBase(Guid? pGuid, String pTableName)
       {
           m_TableName = pTableName;
           m_FwkGuid = pGuid;
           SetValues();
       }


        /// <summary>
        /// Constructor por defecto 
        /// </summary>
        /// <param name="pGuid">Guid para el caso en que ya sea conocido este valor. Generalmente cuando
        /// la marca ya existe en la BD.
        /// </param>
        public BlockingMarkBase(Guid pGuid)
        {
            m_FwkGuid = pGuid;
            SetValues();
        }

        /// <summary>
        /// Constructor por defecto 
        /// este constructor genera un nuevo valor Guid par ala marca.
        /// Es utilizado para crear una marca por defecto.-
        /// </summary>
        public BlockingMarkBase()
        {
            m_FwkGuid = Guid.NewGuid();
            SetValues();
        }

        #endregion

        #region Properties
        /// <summary>
        /// 
        /// </summary>
        public Int32? BlockingId
        {
            get { return m_BlockingId; }
            set { m_BlockingId = value; }
        }

        /// <summary>
        /// Nombre del proceso de nogocio que requiere el bloqueo
        /// </summary>
        public String Process
        {
            get { return msz_Process; }
            set { msz_Process = value; }
        }

        /// <summary>
        /// Guid del Contexto de Bloqueo.- (solo lectura)
        /// </summary>
        public Guid? FwkGuid
        {
            get { return m_FwkGuid; }
            set { m_FwkGuid = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? DueDate
        {
            get { return m_DueDate; }
            //set { m_DueDate = value; }
        }

        /// <summary>
        /// Indica si la marca existe en la base de datos.
        /// </summary>
        public Boolean AlreadyExists
        {
            get { return m_AlreadyExists; }
            set { m_AlreadyExists = value; }
        }

        /// <summary>
        /// Time-To-Live del contexto de bloqueo.-
        /// </summary>
        public Int32? TTL
        {
            get { return m_TTL; }
            set
            {
                m_TTL = value;
                m_DueDate = System.DateTime.Now.AddSeconds(Convert.ToDouble(m_TTL));
            }
        }

        //        /// <summary>
        //        /// Tiempo de espera antes de lanzar una excepcion cuando
        //        /// se esta esperando que se liberen marcas de bloqueo.-
        //        /// </summary>
        //public int? BlockingTime
        //{
        //    get { return m_BlockingTime; }
        //    set { m_BlockingTime = value; }
        //}

        /// <summary>
        /// Usuario que efectua el bloqueo.-
        /// </summary>
        public string User
        {
            get { return m_User; }
            set { m_User = value; }
        }

        /// <summary>
        /// Nombre de la tabla de bloqueo.- 
        /// </summary>
        public string TableName
        {
            get { return m_TableName; }
        }

        
        #endregion

        #region Private Methods
        /// <summary>
        /// Setea los valores por defecto.-
        /// </summary>
        private void SetValues()
        {
            m_TTL = 15; /* Seconds */
            //m_BlockingTime = 0;
            m_User = String.Empty;
           
        }
        #endregion

    }
}
