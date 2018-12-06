using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooConsole
{
    /// <summary>
    /// The class used to represent the console uti.
    /// </summary>
    internal static class ConsoleUtil
    {
        /// <summary>
        /// Makes the first letter of any string capital.
        /// </summary>
        /// <param name="value"> The string that will be capitalized.</param>
        /// <returns> The string that has had its first letter capitalized.</returns>
        public static string InitialUpper(string value)
        {
            string guestName = null;

            if (value.Length > 0 && value != null)
            {
                guestName = char.ToUpper(value[0]) + value.Substring(1);
            }
            return guestName;
        }
    }
}
