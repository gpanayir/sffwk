using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;
using System.Data;

namespace Fwk.Wizard
{
  

    internal static class HelperFunctions 
    {

        /// <summary>
        /// Genera un string con el contenido del InnerException .-
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public static String GetAllMessageException(Exception ex)
        {
            
            StringBuilder wMessage = new StringBuilder();
            wMessage.Append(ex.Message);
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                wMessage.AppendLine("Source: ");
                wMessage.AppendLine(ex.Source);
                wMessage.AppendLine();
                wMessage.AppendLine("Message: ");
                wMessage.AppendLine(ex.Message);
            }
            return wMessage.ToString();
        }

        /// <summary>
        /// Abre un archivo de texto
        /// </summary>
        /// <param name="pFileName">Nombre completo del archivo</param>
        /// <returns></returns>
        public static string OpenTextFile(string pFileName)
        {
            using (StreamReader sr = File.OpenText(pFileName))
            {
                string retString = sr.ReadToEnd();
                sr.Close();

                return retString;
            }

        }

    }







    /// <summary>
    /// 
    /// </summary>
    public class UserDefinedTypesBack 
    {
        CnnString _CnnString;
        private UserDefinedTypes _UserDefinedTypes;

        public UserDefinedTypes UserDefinedTypes
        {
            get { return _UserDefinedTypes; }
            set { _UserDefinedTypes = value; }
        }
        private String _GetUserDefinedTypesQuery;

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="pCnnString"></param>
        public UserDefinedTypesBack(CnnString pCnnString)
            
        {
            _CnnString = pCnnString;
           
            _GetUserDefinedTypesQuery = GetQuery();
            _UserDefinedTypes = LoadUserDefinedTypes();
        }

        /// <summary>
        /// Carga los tipos definidos por el usuario
        /// </summary>
        /// <returns>Tables </returns>
         UserDefinedTypes LoadUserDefinedTypes()
        {

            DataTable wDttTypes = null;
            UserDefinedType wUserDefinedType;
            UserDefinedTypes wUserDefinedTypes = new UserDefinedTypes();
       
            try
            {
                wDttTypes = GetUserDefinedTypesFromDataBase();
                wDttTypes.TableName = "Types";
                foreach (DataRow oDtr in wDttTypes.Rows)
                {
                    wUserDefinedType = new UserDefinedType();
                    wUserDefinedType.Name = oDtr["Name"].ToString();
                    wUserDefinedType.Nullable = Convert.ToBoolean(oDtr["Nullable"]);
                    wUserDefinedType.Length = Convert.ToInt32(oDtr["Length"]);
                    wUserDefinedType.NumericPrecision = Convert.ToInt32(oDtr["NumericPrecision"]);
                    wUserDefinedType.Schema = oDtr["Schema"].ToString();
                    wUserDefinedType.SystemType = oDtr["SystemType"].ToString();

                    wUserDefinedTypes.Add(wUserDefinedType);
                }


                wDttTypes.Dispose();
                wDttTypes = null;

      
                return wUserDefinedTypes;

            }
            catch (Exception ex)
            { throw ex; }

        }

        DataTable GetUserDefinedTypesFromDataBase()
        {
            using (SqlConnection wCnn = new SqlConnection(_CnnString.ToString()))
            using (SqlCommand wCmd = new SqlCommand())
            {
                DataSet wDs = new DataSet();
                SqlParameter wParam = new SqlParameter();
                try
                {

                    wParam = new SqlParameter();

                    wCnn.Open();

                    wCmd.CommandType = CommandType.Text;

                    wCmd.CommandText = _GetUserDefinedTypesQuery;

                    wCmd.Connection = wCnn;
                    SqlDataAdapter wDa = new SqlDataAdapter(wCmd);

                    wDa.Fill(wDs);
                    wCnn.Close();
                    return wDs.Tables[0];
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
            }
        }


        String GetQuery()
        {

            StringBuilder sb = new StringBuilder(5000);

            sb.Append(@"SELECT");
            sb.Append(Environment.NewLine);
            sb.Append(@"st.name AS [Name],");
            sb.Append(Environment.NewLine);
            sb.Append(@"sst.name AS [Schema],");
            sb.Append(Environment.NewLine);
            sb.Append(@"baset.name AS [SystemType],");
            sb.Append(Environment.NewLine);
            sb.Append(@"CAST(CASE WHEN baset.name IN (N'nchar', N'nvarchar') AND st.max_length <> -1 ");
            sb.Append(Environment.NewLine);
            sb.Append(@"THEN st.max_length/2 ELSE st.max_length END AS int) AS [Length],");
            sb.Append(Environment.NewLine);
            sb.Append(@"CAST(st.precision AS int) AS [NumericPrecision],");
            sb.Append(Environment.NewLine);
            sb.Append(@"CAST(st.scale AS int) AS [NumericScale],");
            sb.Append(Environment.NewLine);
            sb.Append(@"st.is_nullable AS [Nullable]");
            sb.Append(Environment.NewLine);
            sb.Append(@"FROM  sys.types AS st");
            sb.Append(Environment.NewLine);
            sb.Append(@"INNER JOIN sys.schemas AS sst ON sst.schema_id = st.schema_id");
            sb.Append(Environment.NewLine);
            sb.Append(@"LEFT OUTER JOIN sys.types AS baset ON baset.user_type_id = st.system_type_id ");
            sb.Append(Environment.NewLine);
            sb.Append(@"and baset.user_type_id = baset.system_type_id");
            sb.Append(Environment.NewLine);
            sb.Append(@"WHERE");
            sb.Append(Environment.NewLine);
            sb.Append(@"(st.schema_id!=4 and st.system_type_id!=240 and st.user_type_id != st.system_type_id)");
            sb.Append(Environment.NewLine);
            sb.Append(@"ORDER BY");
            sb.Append(Environment.NewLine);
            sb.Append(@"[Schema] ASC,[Name] ASC");
            sb.Append(Environment.NewLine);


            return sb.ToString();
        }

    }

    /// <summary>
    /// Coleccion de tipos de datos de SQL que son deficidos por el usuario
    /// </summary>
    [XmlRoot("UserDefinedTypes"), SerializableAttribute]
    public class UserDefinedTypes : List<UserDefinedType>
    {



        ///// <summary>
        ///// Obtiene una UserDefinedType de la coleccion de UserDefinedTypes .-
        ///// </summary>
        ///// <param name="pUserDefinedTypeName">Nombre del tipo definido por el usuario-</param>
        ///// <returns>UserDefinedType</returns>
        public UserDefinedType GetUserDefinedType(string pUserDefinedTypeName)
        {
            UserDefinedType wUserDefinedType = null;
            if(this.Exists(p => p.Name.Equals(pUserDefinedTypeName)))
                wUserDefinedType = this.First<UserDefinedType>(p => p.Name.Equals(pUserDefinedTypeName));

            return wUserDefinedType;

        }
    }

    /// <summary>
    /// Clase que reprecenta la un tipodefinido por el usuario.- Es un tipo de dato customizado.-
    /// </summary>
    [XmlInclude(typeof(UserDefinedType)), Serializable]
    public class UserDefinedType 
    {
        private string _Name;
        private string _Schema;
        private Int32 _Length;
        private Int32 _NumericPrecision;
        private string _SystemType;


        private Boolean _Nullable;

        /// <summary>
        /// Nombre del tipo
        /// </summary>
        public UserDefinedType()
        {
        }
        /// <summary>
        /// Tipo del sistema que conforma el tiipo de dato definido por el usuario.-
        /// </summary>
        public string SystemType
        {
            get { return _SystemType; }
            set { _SystemType = value; }
        }
        /// <summary>
        /// Nombre del tipo definido por el usuario.-
        /// </summary>
        [XmlElement(ElementName = "Name", IsNullable = true, DataType = "string")]
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        /// <summary>
        /// Esquema al que pertenece el tipo definido por el usuario.-
        /// </summary>
        [XmlElement(ElementName = "Schema", IsNullable = true, DataType = "string")]
        public string Schema
        {
            get { return _Schema; }
            set { _Schema = value; }
        }

        /// <summary>
        /// Largo del tipo definido por el usuario.-
        /// </summary>
        public Int32 Length
        {
            get { return _Length; }
            set { _Length = value; }
        }

        /// <summary>
        /// Precicion
        /// </summary>
        public Int32 NumericPrecision
        {
            get { return _NumericPrecision; }
            set { _NumericPrecision = value; }
        }


        /// <summary>
        /// indica si este tipo de datos acepta nulos o no.-
        /// </summary>
        public Boolean Nullable
        {
            get { return _Nullable; }
            set { _Nullable = value; }
        }
    }
}
