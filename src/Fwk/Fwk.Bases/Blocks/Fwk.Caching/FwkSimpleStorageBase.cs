using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.IsolatedStorage;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fwk.Caching
{

    /// <summary>
    /// Clase base que permite un almacenamiento en el IsolatedStorageFile.- 
    /// Esta clase no nececita configuracion de cache de ningun tipo.-
    /// </summary>
    /// <example>
    /// <para>Crear una clase que herede de FwkSimpleStorageBase para el caso en que deseemos implementar 
    /// una inicializacion personalizada de nuestro objeto.-
    /// </para> 
    /// <code>
    /// <![CDATA[
    ///     internal class MyStorageSetting : FwkSimpleStorageBase<Cliente>
    ///     {
    ///         public override void InitObject()
    ///         {
    ///             _Object = new Store();
    ///             _Object.Nombre = "Pepe";
    ///         }
    ///     }
    /// ]]>
    /// </code>   
    /// <para>Usar directamente la clase FwkSimpleStorageBase 
    /// </para> 
    /// <code>
    /// <![CDATA[
    /// 
    ///     public FwkSimpleStorageBase _Store = new FwkSimpleStorageBase<Cliente>();
    /// ]]>
    /// </code>    
    /// </example>
    [Serializable]
    public class FwkSimpleStorageBase<T>
    {
        string CONFIG_FILE = AppDomain.CurrentDomain.FriendlyName;



        T _Object;

        /// <summary>
        /// Contiene las conecciones a bases de datos
        /// </summary>
        public T StorageObject
        {
            get { return _Object; }

        }

        /// <summary>
        /// Generalkmente se usa desde el Load del formulario
        /// <example>
        /// <code>
        /// <![CDATA[
        /// private void Form1_Load(object sender, EventArgs e)
        /// {
        ///     _Storage.Load();
        ///     txtNombre.Text= _Storage.StorageObject.Nombre;
        /// ]]>
        /// </code>    
        /// </example>
        /// </summary>
        public void Load()
        {
            try
            {
                IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();

                //Si no hay datos para este usuario
                if (userStore.GetFileNames(CONFIG_FILE).Length == 0)
                {
                    //Limpio el diccionario por si contien algo
                    InitObject();
                    return;

                }
                //Abro el stream con la informacion serializada del diccionario desde el IsolatedStorage
                IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(CONFIG_FILE, FileMode.Open, userStore);
                _Object = DeSerializeDictionary(userStream);
            }
            catch (FileNotFoundException)//si ocurre algun error construyo una coneccion por defecto
            {
                InitObject();

                Save();

            }

        }

        public void Clear()
        {
            //_Object = null;
            Save();
        }

        /// <summary>
        /// Generalmente utilizado desde un FormClosing 
        /// <example>
        /// <code>
        /// <![CDATA[
        /// private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        /// {
        ///      _Storage.StorageObject.Nombre = txtNombre.Text;
        ///     _Storage.Save();
        ///     
        /// ]]>
        /// </code>    
        /// </example>
        /// </summary>
        public void Save()
        {

            // Crear archivo que se pueda almacenar en el Isolated Storage
            IsolatedStorageFile userStore = IsolatedStorageFile.GetUserStoreForAssembly();

            IsolatedStorageFileStream userStream = new IsolatedStorageFileStream(CONFIG_FILE, FileMode.Create, userStore);

            //Serializa el diccionario y guarda el contenido binario en el stream
            SerializeDictionary(userStream, _Object);

        }

        /// <summary>
        /// Deserializa: Convierte el stream a una lista de coneciones
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="dict"></param>
        T DeSerializeDictionary(FileStream fs)
        {

            T obj;

            // Crea  un BinaryFormatter para realizar la serializacion
            BinaryFormatter bf = new BinaryFormatter();

            try
            {
                //Convierte el stream a un T
                obj = (T)bf.Deserialize(fs);

            }

            catch (System.Runtime.Serialization.SerializationException)
            {

                obj = (T)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(typeof(T).AssemblyQualifiedName);

            }

            finally
            {

                fs.Close();
            }

            return obj;

        }
        /// <summary>
        /// Serializa en binario el la lista de conecciones
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="dict"></param>
        private static void SerializeDictionary(FileStream fs, T dict)
        {
            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();
            // Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, dict);
            // Close the file
            fs.Close();
        }


        /// <summary>
        /// Metodo que permite inicializar el objeto de manera personalizada al sobreescribirlo.- Si no se sobreescribe
        /// el meto solo realiza una instancioacion de <see cref="T"/>
        /// </summary>
        public virtual void InitObject()
        {
            _Object = (T)Fwk.HelperFunctions.ReflectionFunctions.CreateInstance(typeof(T).AssemblyQualifiedName);
        }

    }
}
