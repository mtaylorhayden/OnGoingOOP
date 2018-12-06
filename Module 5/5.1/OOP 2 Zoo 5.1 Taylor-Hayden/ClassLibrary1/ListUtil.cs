using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    /// <summary>
    /// The class used to represent the static ListUtil class.
    /// </summary>
    public static class ListUtil
    {
        /// <summary>
        /// The class used to make things more compact.
        /// </summary>
        /// <param name="list"> The list being seperated.</param>
        /// <param name="separator"> The space in the string using to seperate.</param>
        /// <returns></returns>
        public static string Flatten(IEnumerable<string> list, string separator)
        {
            // Create a string variable.
            string result = null;

            // Go through the list of objects.
            foreach (object s in list)
            {
                // If result plus result is null then return s, otherwise return separator + s. 
                result += result == null ? s : separator + s;
            }

            return result;
        }
    }
}
