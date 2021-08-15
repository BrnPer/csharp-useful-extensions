using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExtensions
{
    public static class DbDataReaderExtensions
    {

        public static T GetValue<T>(this DbDataReader reader, string fieldName, T defaultValue)
        {
            //Get the field from the reader
            var field = reader[fieldName];

            //If the field is empty, return the default value
            if (field == null) return defaultValue;

            //Get the field value
            string value = field.ToString();

            dynamic returnValue;

            switch (Type.GetTypeCode(typeof(T)))
            {
                case TypeCode.DateTime: //If type is DateTime

                    DateTime temp;
                    var couldParseDateTime = DateTime.TryParse(value, out temp);

                    //If could convert, return the converted value;
                    //Otherwise returns default value
                    returnValue = couldParseDateTime == true ? (dynamic)temp : defaultValue;

                    break;
                case TypeCode.String:

                    //Trim the value and return it
                    value = value.TrimStart().TrimEnd();
                    returnValue = (dynamic)value;
                    break;


                default: //If none of the types, return default value
                    returnValue = defaultValue;
                    break;
            }

            return returnValue;
        }
    }

}
