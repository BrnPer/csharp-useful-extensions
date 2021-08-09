using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExtensions
{
    public static class DictionaryExtensions
    {
        public static void AddWithOptions<T1, T2>(this Dictionary<T1, T2> dic, T1 key, T2 value, DictionaryOptions options)
        {
            //Check if key exists
            bool keyExists = dic.ContainsKey(key);

            switch (options)
            {
                case DictionaryOptions.DontOverwrite:

                    //If it doesn't add the item
                    if (keyExists == false)
                    {
                        dic.Add(key, value);
                    }

                    //If it does, don't do a thing
                    break;

                case DictionaryOptions.Overwrite:

                    //If key exists
                    if (keyExists == true)
                    {
                        //First remove the key
                        dic[key] = value;
                    }
                    else
                    {
                        //If key don't existe, just add the key
                        dic.Add(key, value);
                    }

                    break;

                case DictionaryOptions.AppendToValue:

                    //If key exists
                    if (keyExists == true)
                    {
                      
                        T2 oldValue;

                        //Get previous value
                        dic.TryGetValue(key, out oldValue);

                        //Append
                        dynamic newValue = (dynamic)oldValue + (dynamic)value;

                        dic[key] = newValue;
                    }
                    else //Se a key existir apenas fazemos add
                    {
                        dic.Add(key, value);
                    }
                    break;

            }
        }
    }

    public enum DictionaryOptions
    {
        /// <summary>
        /// If the key exists in the Dictionary, we won't rewrite it.
        /// <br>If it doesn't exist, we add it.</br>
        /// </summary>
        DontOverwrite,

        /// <summary>
        /// If the key exists in the Dictionary, we rewrite its value.
        /// <br>If it doesn't exist, we add it.</br>
        /// </summary>
        Overwrite,

        /// <summary>
        /// If the key exists in the Dictionary, we append the new value to the current value.
        /// <example>
        /// <br>Example:</br>
        /// <code>
        /// dict["123"]="123";        
        /// dict.AddWithOptions("123", "456", DictionaryOptions.AppendToValue);
        /// </code>
        /// </example>
        /// The value will be "123456".
        /// <br>If it doesn't exist, we add it.</br>
        /// </summary>
        AppendToValue 
    }
}
