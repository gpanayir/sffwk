using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fwk.Bases
{
    /// <summary>
    /// Concesva un diccionario estatico de elementos T y los instancia una sola vez
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonFactoryArray<T>
    {
        Dictionary<string, SingletonFactory<T>> _dic = new Dictionary<string, SingletonFactory<T>>();

        /// <summary>
        /// Retorna un objeto tipo T.-
        /// Si esta en el diccionario se retorna esta instancia si no se crea una .- 
       /// Quien crea la instancia y pasa los parametros es la clase SingletonFactory.-
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
       public  T Get(string name)
       {
           T genericObject;
           if (_dic.Keys.Contains(name))
               genericObject = _dic[name].GetObject();
           else
           {
               SingletonFactory<T> sf = new SingletonFactory<T>();
               _dic.Add(name, sf);
               genericObject = sf.GetObject();
           }
           return genericObject;

       }
       /// <summary>
       /// Retorna un objeto tipo T.-
       /// Si esta en el diccionario se retorna esta instancia si no se crea una .- 
       /// Quien crea la instancia y pasa los parametros es la clase SingletonFactory.-
       /// </summary>
       /// <param name="name"></param>
       /// <param name="constructorParams">Parametros del contructor la clase T</param>
       /// <returns></returns>
       public  T Get(string name,object[] constructorParams)
       {
           T genericObject;
           if (_dic.Keys.Contains(name))
               genericObject = _dic[name].GetObject();
           else
           {
               SingletonFactory<T> sf = new SingletonFactory<T>(constructorParams);
               _dic.Add(name, sf);
               genericObject = sf.GetObject();
           }
           return genericObject;

       }
       public void Add(string  name, T objetc)
       {
           SingletonFactory<T> sf = new SingletonFactory<T>();
           sf.SetObject(objetc);
       }

    }
}
