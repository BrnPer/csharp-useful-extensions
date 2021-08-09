using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpExtensions
{
    public static class StringExtensions
    {
        public static string ReplaceAll(this string currentValue, List<char> oldChars, char newChar)
        {
            foreach (var oldChar in oldChars)
            {
                currentValue = currentValue.Replace(oldChar, newChar);
            }
            return currentValue;
        }
    }
}
