using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using helper = Fwk.HelperFunctions;
using System.ComponentModel;
using System.Diagnostics;
using Fwk.Bases.Debug;

namespace Fwk.Bases
{
    /// <summary>
    /// Clase base que define el comportamiento general de todas las clases tipo Entidad.-
    /// </summary>
    /// <typeparam name="T">Tipo generico que hereda de la clase Entity y que hacepta la clase coleccion en cuestion.-</typeparam>
    /// <Author>Marcelo .F. Oviedo</Author>
    [DebuggerVisualizer(typeof(IEntityVisualizer))]
    [Serializable]
    public  class Entities<T> : List<T>, IEntity where T : Entity
    {
        #region IEntity Members


            //EntityState _EntityState = EntityState.Unchanged;
            ///// <summary>
            ///// Retorna el estado de modificacion actual de la clase 
            ///// </summary>
            //[BrowsableAttribute(false)]
            //public EntityState EntityState
            //{
            //    get
            //    {
            //        return _EntityState;
            //    }
            //    set
            //    {
            //        _EntityState = value;
            //    }
            //}
        /// <summary>
        /// Obtine un xml producto de la serializacion de la coleccion Entities.-
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        public string GetXml()
        {
            return helper.SerializationFunctions.SerializeToXml(this);
        }


        /// <summary>
        /// Obtiene un System.DataSet producto de la deserializacion del objeto.-
        /// </summary>
        /// <returns>System.DataSet</returns>
        public DataSet GetDataSet()
        {
            DataSet wDts = new DataSet();

            String strXml = helper.SerializationFunctions.SerializeToXml(this);
            wDts.ReadXml(new StringReader(strXml));

            return wDts;
        }

        /// <summary>
        /// Metodo estatico que deserializa un objeto a partir del xml correspondiente 
        /// al esquema del objeto.-
        /// </summary>
        /// <param name="pType">Tipo de objeto a deserializar</param>
        /// <param name="pXmlData">Xml con el que se crea el objeto</param>
        /// <returns>object que hereda de Entities</returns>
        [Obsolete("A partir del framework de .net version 2.0 se debe utilizar el metodo generico GetFromXml<IEntity>() ")]
        public static object GetObjectFromXml(Type pType, string pXmlData)
        {
            return helper.SerializationFunctions.DeserializeFromXml(pType, pXmlData);
        }

        /// <summary>
        /// Retorna un objeto a partir de la instancia estatica
        /// </summary>
        /// <typeparam name="TEntities">Tipo de entidad que se decee retornar este es un type gennerico ya que el metodo esta definido en la clase base</typeparam>
        /// <param name="pXmlData">Xml del objeto que se decea retornar</param>
        /// <returns>Entidad  </returns>
        public static TEntities GetFromXml<TEntities>(string pXmlData) where TEntities : Entities<T>
        {

            return (TEntities)helper.SerializationFunctions.DeserializeFromXml(typeof(TEntities), pXmlData);
        }

        /// <summary>
        /// Rellena la clase con los valores del XML 
        /// <param name="pXmlData">Xml con el que se crea el objeto</param>
        /// <summary>
        public void SetXml(string pXmlData)
        {
            helper.SerializationFunctions.DeserializeFromXml(this.GetType(), pXmlData);
        }
        #endregion
       
       

        #region Busqueda
        /// <summary>
        /// 
        /// </summary>
        public Entities()
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public Entities(IEnumerable<T> collection)
            : base(collection)
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="capacity"></param>
        public Entities(int capacity)
            : base(capacity)
        { }

        private SearchEntityArg[] _args;

        ///// <summary>
        ///// 
        ///// </summary>
        //public SearchEntityArg[] Arguments
        //{
        //    get { return _args; }
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            return new List<T>(base.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<T> ToIList()
        {
            return new List<T>(base.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool Exists(SearchEntityArg[] args)
        {
            _args = args;
            return base.Exists(findObject);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public bool Exists(SearchEntityArg arg)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return Exists(args.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool Exists(List<SearchEntityArg> args)
        {
            return Exists(args.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Find(SearchEntityArg[] args)
        {
            _args = args;
            return base.Find(findObject);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public T Find(SearchEntityArg arg)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return Find(args.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public T Find(List<SearchEntityArg> args)
        {
            return Find(args.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public int FindIndex(SearchEntityArg[] args)
        {
            _args = args;
            return base.FindIndex(findObject);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public int FindIndex(SearchEntityArg arg)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return FindIndex(args.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public int FindIndex(List<SearchEntityArg> args)
        {
            return FindIndex(args.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int FindIndex(SearchEntityArg[] args, int startIndex)
        {
            _args = args;
            return base.FindIndex(startIndex, findObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int FindIndex(SearchEntityArg arg, int startIndex)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return FindIndex(args.ToArray(), startIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int FindIndex(List<SearchEntityArg> args, int startIndex)
        {
            return FindIndex(args.ToArray(), startIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindIndex(SearchEntityArg[] args, int startIndex, int count)
        {
            _args = args;
            return base.FindIndex(startIndex, count, findObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindIndex(SearchEntityArg arg, int startIndex, int count)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return FindIndex(args.ToArray(), startIndex, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindIndex(List<SearchEntityArg> args, int startIndex, int count)
        {
            return FindIndex(args.ToArray(), startIndex, count);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public T FindLast(SearchEntityArg[] args)
        {
            _args = args;
            return base.FindLast(findObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public T FindLast(SearchEntityArg arg)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return FindLast(args.ToArray());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public T FindLast(List<SearchEntityArg> args)
        {
            return FindLast(args.ToArray());
        }
/// <summary>
/// 
/// </summary>
/// <param name="args"></param>
/// <param name="startIndex"></param>
/// <returns></returns>
        public int FindLastIndex(SearchEntityArg[] args, int startIndex)
        {
            _args = args;
            return base.FindLastIndex(startIndex, findObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int FindLastIndex(SearchEntityArg arg, int startIndex)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return FindLastIndex(args.ToArray(), startIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public int FindLastIndex(List<SearchEntityArg> args, int startIndex)
        {
            return FindLastIndex(args.ToArray(), startIndex);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindLastIndex(SearchEntityArg[] args, int startIndex, int count)
        {
            _args = args;
            return base.FindLastIndex(startIndex, count, findObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindLastIndex(SearchEntityArg arg, int startIndex, int count)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return FindLastIndex(args.ToArray(), startIndex, count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <param name="startIndex"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public int FindLastIndex(List<SearchEntityArg> args, int startIndex, int count)
        {
            return FindLastIndex(args.ToArray(), startIndex, count);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool TrueForAll(SearchEntityArg[] args)
        {
            _args = args;
            return base.TrueForAll(findObject);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public bool TrueForAll(SearchEntityArg arg)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return TrueForAll(args.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public bool TrueForAll(List<SearchEntityArg> args)
        {
            return TrueForAll(args.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        public Entities<T> FindAll(SearchEntityArg arg)
        {
            List<SearchEntityArg> args = new List<SearchEntityArg>();
            args.Add(arg);
            return FindAll(args.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Entities<T> FindAll(List<SearchEntityArg> args)
        {
            return FindAll(args.ToArray());
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public Entities<T> FindAll(SearchEntityArg[] args)
        {
            _args = args;
            T[] items = base.FindAll(findObject).ToArray();
            return new Entities<T>(items);
        }

        

        private bool findObject(T item)
        {
            if (_args == null)
                return false;

            int numArgs = _args.Length;

            if (numArgs == 0)
                return false;

            int numSuccesses = 0;

            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(item, true);
            object valueProp;
            PropertyDescriptor propDesc;
            foreach (SearchEntityArg wSearchEntityArg in _args)
            {
                propDesc = properties.Find(wSearchEntityArg.NameProperty, true);
                if (propDesc != null)
                {
                    valueProp = propDesc.GetValue(item);
                    if (valueProp != null)
                    {
                        if (wSearchEntityArg.IgnoreCaseForValue)
                        {
                            #region [Converir todo a Mayusculas y comparar]
                            if (valueProp.ToString().ToUpper().Equals(wSearchEntityArg.Value.ToUpper()))
                            {
                                numSuccesses += 1;
                            }
                            else
                            {
                                return false;
                            }
                            #endregion
                        }
                        else
                        {
                            #region [Comparar directamente]
                            if (valueProp.ToString().Equals(wSearchEntityArg.Value))
                            {
                                numSuccesses += 1;
                            }
                            else
                            {
                                return false;
                            }
                            #endregion
                        }

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(wSearchEntityArg.Value))
                        {
                            numSuccesses += 1;
                        }
                        else
                        {
                            return false;
                        }

                    }
                }
            }

            if (numArgs.Equals(numSuccesses))
                return true;
            else
                return false;
        }


        #endregion


        #region ICloneable Members

        /// <summary>
        /// Clona el contrato de servicio
        /// </summary>
        /// <typeparam name="TEntities">Tipo de Entities que implementa IEntity </typeparam>
        /// <returns></returns>
        public TEntities Clone<TEntities>() where TEntities : Entities<T>
        {
            return (TEntities)Fwk.HelperFunctions.SerializationFunctions.Deserialize(this.GetType(), this.GetXml());
        }
        /// <summary>
        /// Crea una copia espejo de la clase.-
        /// </summary>
        /// <returns></returns>
        public Entities<T> Clone()
        {
            return (Entities<T>)((ICloneable)this).Clone();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion

        #region ToString
        /// <summary>
        /// Returns a <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"></see> that represents the current <see cref="T:System.Object"></see>.
        /// </returns>
        public override string ToString()
        {
            string s = this.GetType().Name + " Collection" + System.Environment.NewLine;
            foreach (T Item in this)
            {
                s += Item.ToString() + System.Environment.NewLine;
            }
            return s;
        }
        #endregion 
    }

    [DebuggerVisualizer(typeof(IEntityVisualizer))]
    [Serializable]
    public class BaseEntities<T> : List<T>, IBaseEntity where T : BaseEntity
    {
        /// <summary>
        /// Obtine un xml producto de la serializacion de la coleccion Entities.-
        /// </summary>
        /// <returns>string con el xml de la serializacion</returns>
        public string GetXml()
        {
            return helper.SerializationFunctions.SerializeToXml(this);
        }

        /// <summary>
        /// Rellena la clase con los valores del XML 
        /// <param name="pXmlData">Xml con el que se crea el objeto</param>
        /// <summary>
        public void SetXml(string pXmlData)
        {
            helper.SerializationFunctions.DeserializeFromXml(this.GetType(), pXmlData);
        }
        #region ICloneable Members

        /// <summary>
        /// Clona el contrato de servicio
        /// </summary>
        /// <typeparam name="TEntities">Tipo de Entities que implementa IEntity </typeparam>
        /// <returns></returns>
        public TEntities Clone<TEntities>() where TEntities : BaseEntities<T>
        {
            return (TEntities)Fwk.HelperFunctions.SerializationFunctions.Deserialize(this.GetType(), this.GetXml());
        }
        /// <summary>
        /// Crea una copia espejo de la clase.-
        /// </summary>
        /// <returns></returns>
        public BaseEntities<T> Clone()
        {
            return (BaseEntities<T>)((ICloneable)this).Clone();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}
