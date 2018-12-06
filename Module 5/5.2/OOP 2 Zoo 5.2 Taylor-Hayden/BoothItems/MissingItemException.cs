using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoothItems
{
    /// <summary>
    /// The class used to represent a missing item exception.
    /// </summary>
    public class MissingItemException : Exception
    {
        /// <summary>
        /// The exception explaining that an item is missing.
        /// </summary>
        /// <param name="message"> The message explaining the missing item.</param>
        public MissingItemException(string message)
            : base(message)
        {
            
        }
    }
}
