using System;
using System.Reflection;
using System.ComponentModel;

namespace Fwk.HelperFunctions
{
    /// <summary>
    /// Clase que permite obtener informacion de los assemblies atraves de reflection.-
    /// </summary>
	public class ReflectionFunctions
	{
		static private string[] GetStringsFromAssemblyString(string pAssemblyString)
		{
            return pAssemblyString.Split(','); 

		}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAssemblyString"></param>
        /// <returns></returns>
		static public string GetAssemblyNameFromAssemblyString(string pAssemblyString)
		{
			string wResult = GetStringsFromAssemblyString(pAssemblyString)[1];
			return wResult;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAssemblyString"></param>
        /// <param name="pPatch"></param>
        /// <returns></returns>
        static public object CreateInstanceLoadFile(string pAssemblyString, string pPatch)
        {
            string wClassName;
            string wAssemblyName;

            ExtractTypeInformation(pAssemblyString, out wClassName, out wAssemblyName);

            if (!wAssemblyName.Substring(wAssemblyName.Length - 4).Contains(".dll"))
            {
                wAssemblyName = wAssemblyName + ".dll";
            }

            Assembly wAssembly = Assembly.LoadFile(pPatch + wAssemblyName);
            object wResult = wAssembly.CreateInstance(wClassName, true);

        

            return wResult;

        }

        /// <summary>
        /// Carga un ensamblado a partir de su nombre largo.
        /// </summary>
        /// <param name="pAssemblyString"></param>
        /// <returns></returns>
	    static public object CreateInstance(string pAssemblyString)
        {
            string wClassName;
            string wAssembly;

            ExtractTypeInformation(pAssemblyString, out wClassName, out wAssembly);

            // crea el objeto dinámicamente
            object wResult = CreateInstanceLoad(wClassName,  wAssembly);

            return wResult;


        }

        /// <summary>
        /// Carga un ensamblado a partir de su nombre largo.
        /// </summary>
        /// <param name="pClassName">Nombre de la clase</param>
        /// <param name="pAssemblyName">Nombre del ensamblado</param>
        /// <returns>Instancia del objeto</returns>
        static public object CreateInstanceLoad(string pClassName, string pAssemblyName)
        {
            Assembly wAssembly = Assembly.Load(pAssemblyName);
            object wResult = wAssembly.CreateInstance(pClassName, true);
          
            return wResult;
        }

    

		private static void ExtractTypeInformation(string pAssemblyString, out string pClassName, out string pAssembly)
		{
			// Divide el assemblyString según la coma y guarda el resultado
			// en un array
			string[] wParts = GetStringsFromAssemblyString(pAssemblyString);

			// Verifica que el array tenga 2 partes
			if (wParts.Length < 2)
			{
				throw new Exception("Assembly mal configurado.");
			}

			// Toma las partes del assemblyArray en dos strings separados
			pClassName = wParts[0].Trim();
			pAssembly = wParts[1].Trim();

			// Verifica que el string strNamespaceClass tenga al menos un punto
			if (pClassName.IndexOf(".") < 0)
			{
				throw new Exception("Assembly mal configurado.");
			}
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pAssemblyString"></param>
        /// <returns></returns>
        static public Type CreateType(string pAssemblyString)
        {


            string wClassName;
            string wAssemblyName;
            ExtractTypeInformation(pAssemblyString, out wClassName, out wAssemblyName);

            // crea el tipo dinámicamente
            Type wResult = CreateType(wClassName, wAssemblyName);

            return wResult;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="pClassName"></param>
        /// <param name="pAssemblyName"></param>
        /// <returns></returns>
		static public Type CreateType(string pClassName, string pAssemblyName)
		{
			Assembly wAssembly = Assembly.Load(pAssemblyName);
			Type wResult = wAssembly.GetType(pClassName, true);

			return wResult;
		}
       
        /// <summary>
        /// Crea un tipo dinamicamente a partir del nombre un archivo.-
        /// </summary>
        /// <param name="pAssemblyString">Concatenacion de ClassName + , + AssemblyName</param>
        /// <param name="pPath">Ruta del archivo</param>
        /// <returns>Type definido por ClassName</returns>
        static public Type CreateTypeFromFile(string pAssemblyString,String pPath)
		{
           

			string wClassName;
			string wAssemblyName;
            ExtractTypeInformation(pAssemblyString, out wClassName, out wAssemblyName);

            if (!wAssemblyName.Substring(wAssemblyName.Length - 4).Contains(".dll"))
            {
                wAssemblyName = wAssemblyName + ".dll";
            }
            Assembly wAssembly = Assembly.LoadFile(pPath + wAssemblyName);
            Type wResult = wAssembly.GetType(wClassName, true);

			// crea el tipo dinámicamente
            //Type wResult = CreateType(wClassName, pPath + wAssembly);

			return wResult;
		}

        /// <summary>
        /// Retorna el valor de una propiedad.-
        /// Generalmente utilizado cuando el nombre de la propiedad es generada dinamicamente y no se sabe en 
        /// desing time que propiedad sera utilizada de un objeto.-
        /// </summary>
        /// <typeparam name="T">Tipo de la propiedad a retornar</typeparam>
        /// <param name="pSourceObject">Objeto que contiene la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad</param>
        /// <returns>Valor de la propiedad</returns>
        public static T GetPropertieValue<T>(object pSourceObject, string pPropertyName)
        {
            object wPropValue = null;
            PropertyDescriptorCollection pProperties = TypeDescriptor.GetProperties(pSourceObject, true);
            PropertyDescriptor pPropDesc;

            pPropDesc = pProperties.Find(pPropertyName, true);
            if (pPropDesc != null)
            {
                wPropValue = pPropDesc.GetValue(pSourceObject);
            }


            return (T)wPropValue;
        }

        /// <summary>
        /// Retorna el valor de una propiedad.-
        /// Generalmente utilizado cuando el nombre de la propiedad es generada dinamicamente y no se sabe en 
        /// desing time que propiedad sera utilizada de un objeto.-
        /// </summary>
        /// <typeparam name="T">Tipo de la propiedad a retornar</typeparam>
        /// <param name="pSourceObject">Objeto que contiene la propiedad</param>
        /// <param name="pPropertyName">Nombre de la propiedad</param>
        /// <returns>Valor de la propiedad</returns>
        public static T GetPropertieValue<T>(Type pSourceObject, string pPropertyName)
        {
            object wPropValue = null;
            PropertyDescriptorCollection pProperties = TypeDescriptor.GetProperties(pSourceObject, true);
            PropertyDescriptor pPropDesc;

            pPropDesc = pProperties.Find(pPropertyName, true);
            if (pPropDesc != null)
            {
                wPropValue = pPropDesc.GetValue(pSourceObject);
            }


            return (T)wPropValue;
        }

        /// <summary>
        ///  Efectua un mapeo de todas las propiedades de un objeto a otro 
        ///  el mapeo solo lo hace de los atributos del tipo T, esto es debido a que 
        ///  puede pasarce como T una interfaf y los objetos source y destino ser de distinto tipo
        ///  
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="spurce"></param>
        /// <param name="target"></param>
        public static void MapProperties<T>(T source, ref T target)
        {

            PropertyInfo wPropertyInfo_target;
            PropertyInfo wPropertyInfo_source;
            foreach (PropertyInfo wPropertyInfo in typeof(T).GetProperties())
            {


                if (wPropertyInfo.CanWrite && wPropertyInfo.CanRead)
                {
                    
                    wPropertyInfo_source = source.GetType().GetProperty(wPropertyInfo.Name);
                    if (wPropertyInfo_source != null)//Si es null es por que tal propiedad no existe en el objeto destino
                    {
                        wPropertyInfo_target = target.GetType().GetProperty(wPropertyInfo.Name);
                        object wSourceValue = wPropertyInfo_source.GetValue(source, null);
                        if (wPropertyInfo_target.CanWrite && wPropertyInfo_target.CanRead)
                        {
                            wPropertyInfo_target.SetValue(target, wSourceValue, null);
                        }
                    }

                }
            }
        }

	}
}
