using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Fwk.HelperFunctions;
using Fwk.Bases;
using System.Collections;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace Fwk.UI.Common
{

    /// <summary>
    /// Clase con helpers para Fwk libs. 
    /// </summary>
    public class HelperFunctions
    {
        public static class Masck
        {
            static string spesialCharacters = "#aAD";
            public static string GetBigbangMasck(string input)
            {
                StringBuilder resultMASCK = new StringBuilder();
                //D
                //            ##/######/##
                //AA/AAAAAAA/AA
                //AA##A#-##-(AAA)
                //aa##aaAA[###]
                //aa\AAA\aa
                //A2#2A1A1-A2-(A3)
                //A21#50a20
                Char[] inputMASCK = input.ToCharArray();

                if (inputMASCK.Length == 1)
                {
                    if (inputMASCK[0].CompareTo('D') == 0)
                        resultMASCK.Append("dd/MM/yyyy");
                }



                for (int i = 0; i < inputMASCK.Length; i++)
                {
                    if (!spesialCharacters.Contains(inputMASCK[i]))
                    {
                        resultMASCK.Append(inputMASCK[i]);
                        continue;
                    }

                    if (inputMASCK[i].CompareTo('a') == 0)
                    {
                        i = ProcessAlpha(inputMASCK, resultMASCK, i, inputMASCK[i], '_');
                        continue;
                    }
                    if ((inputMASCK[i].CompareTo('A') == 0))
                    {
                        i = ProcessAlpha(inputMASCK, resultMASCK, i, inputMASCK[i], 'a');
                        continue;
                    }

                    if (inputMASCK[i].CompareTo('#') == 0)
                    {
                        i = ProcessAlpha(inputMASCK, resultMASCK, i, inputMASCK[i], '9');
                        continue;
                    }



                }

                return resultMASCK.ToString();


            }
            /// <summary>
            /// Inserta N caracteres a partir de la posicion = Index
            /// </summary>
            /// <param name="inputMASCK">Cadena original de entrada</param>
            /// <param name="index">posicion donde se detecto un numero q indica insercion de N caracteres</param>
            /// <param name="resultMASCK">cadena resultado</param>
            /// <param name="character">Valor de caracter</param>
            /// <param name="endPosition">Posicion retornada indicando donde continuar leyendo los caracteres en el ciclo for principal</param>
            static void IsnsertChar(Char[] inputMASCK, int index, StringBuilder resultMASCK, char character, out int endPosition)
            {
                int numberValue;


                GetNumber(inputMASCK, index + 1, out numberValue, out endPosition);
                for (int i = 0; i <= numberValue - 1; i++)
                {
                    resultMASCK.Append(character);
                }
            }

            /// <summary>
            /// Retorna el entero
            /// </summary>
            /// <param name="array"></param>
            /// <param name="start">posicion desde donde se comienza a</param>
            /// <param name="number"></param>
            /// <param name="endPosition"></param>
            static void GetNumber(Char[] array, int startPosition, out int numberValue, out int endPosition)
            {
                //Lista q contiene la concatenacion de enteros detectados en el ciclo for.
                StringBuilder numberAux = new StringBuilder();
                //La posicion final es = inicio de conteo hasta la cantidad de numeros
                endPosition = startPosition - 1;


                for (int i = startPosition; i < array.Length; i++)
                {
                    //si es un numero lo agrego a la lista de numero
                    if (TypeFunctions.IsInteger(array[i].ToString()))
                    {
                        numberAux.Append(array[i].ToString());
                        endPosition++;
                    }
                    else
                    {
                        break;
                    }

                }

                numberValue = Convert.ToInt32(numberAux.ToString());

            }


            static int ProcessAlpha(Char[] inputMASCK, StringBuilder resultMASCK, int index, char sourceChar, char destChar)
            {
                int endPosition = 0;


                if (inputMASCK[index].CompareTo(sourceChar) == 0)
                {
                    if (index == inputMASCK.Length - 1)
                    {
                        resultMASCK.Append(destChar);
                        return index;
                    }
                    //Solo inserto la a si el caracter proximo es tambien a
                    if (inputMASCK[index + 1].CompareTo(sourceChar) == 0)
                    {
                        resultMASCK.Append(destChar);

                    }
                    //Si el caracter proximo es numerico
                    if (TypeFunctions.IsInteger(inputMASCK[index + 1].ToString()))
                    {

                        IsnsertChar(inputMASCK, index, resultMASCK, destChar, out endPosition);
                        index = endPosition;
                    }
                    //Si llego hasta aqui es que es algun caracter cualquiera que no reporecenta logica
                    resultMASCK.Append(destChar);
                }
                return index;
            }
        }

        /// <summary>
        /// Clase con Helpers para las enumeraciones.
        /// </summary>
        public class Enumerations
        {

            #region [Fields]

            /// <summary>
            /// Cache interno utilizado para almacenar las busquedas
            /// ya hechas y no utilizar reflection todo el tiempo.
            /// </summary>
            private static Hashtable _descriptionsCache = new Hashtable();
            private static Hashtable _enumValuesCache = new Hashtable();

            #endregion

            #region [Public Methods]

            /// <summary>
            /// Obtiene el valor del attributo tipo <see cref="System.ComponentModel.DescriptionAttribute"/>
            /// asignado al valor de la enumeración pasado, sino se encuentra este valor devuelve 
            /// ToString() del valor.
            /// </summary>
            /// <typeparam name="TEnum">Tipo de la enumeración.</typeparam>
            /// <param name="enumValue">Valor de la enumeración.</param>
            /// <returns>Cadena de texto obtenida.</returns>
            public static string GetDescription<TEnum>(TEnum enumValue)
            {

                if (_descriptionsCache.ContainsKey(enumValue))
                {
                    return (string)_descriptionsCache[enumValue];
                }

                FieldInfo fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

                DescriptionAttribute[] attributes =
                    (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    _descriptionsCache.Add(enumValue, attributes[0].Description);
                    _enumValuesCache.Add(attributes[0].Description, enumValue);
                    return attributes[0].Description;
                }

                return enumValue.ToString();

            }


            /// <summary>
            /// Obtiene el valor de la enumeración TEnum correspondiente a la 
            /// descripción pasada por parametros.
            /// </summary>
            /// <typeparam name="TEnum">Tipo de la enumeración.</typeparam>
            /// <param name="enumValueDescription">Descripción del valor de la enumeración.</param>
            /// <exception cref="ArgumentException">Si no se encuentra nigún valor con la descripción en TEnum.</exception>
            /// <returns>Valor de la enumeración correspondiente a la descripción.</returns>
            public static TEnum GetEnumValueFromDescription<TEnum>(string enumValueDescription)
            {

                if (_enumValuesCache.ContainsKey(enumValueDescription))
                {
                    return (TEnum)_enumValuesCache[enumValueDescription];
                }

                TEnum[] enumValues = (TEnum[])Enum.GetValues(typeof(TEnum));

                foreach (TEnum enumValue in enumValues)
                {
                    if (GetDescription<TEnum>(enumValue) == enumValueDescription)
                    {

                        return (TEnum)enumValue;

                    }

                }

                throw new ArgumentException(
                    "No existen un valor de en la enumeración correspondiente a la descripción pasada.");
            }
            #endregion

        }

        public static void AddtoPanel(Control pControlToAdd, Control pContainerControl)
        {

            if (pContainerControl.Contains(pControlToAdd)) return;
            
            pControlToAdd.Location = new System.Drawing.Point(1, 1);
            pControlToAdd.Width = pContainerControl.Width - 60;
            pControlToAdd.Height = pContainerControl.Height - 60;
            pControlToAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                   | System.Windows.Forms.AnchorStyles.Left)
                   | System.Windows.Forms.AnchorStyles.Right)));
            pContainerControl.Controls.Clear();
            pContainerControl.Controls.Add(pControlToAdd);

        }


        public delegate void DelegateWithOutAndRefParameters(out Exception ex);
     
        public static Form GetMDIParent(ContainerControl pContainerControl)
        {
            if (pContainerControl.ParentForm == null)
                return null;
            if (!pContainerControl.ParentForm.IsMdiChild)
                return pContainerControl.ParentForm;
            else
            {
                return (GetMDIParent(pContainerControl.ParentForm));
            }

        }
    
    }
}
