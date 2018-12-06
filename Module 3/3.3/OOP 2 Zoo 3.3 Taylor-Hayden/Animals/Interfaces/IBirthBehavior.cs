using People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The interface used to implement birth behavior.
    /// </summary>
    public interface IBirthBehavior
    {
        /// <summary>
        /// The type of birth.
        /// </summary>
        /// <param name="reproducer"> The item which is a reproducer.</param>
        /// <param name="baby"> The baby being born.</param>
        IReproducer Reproduce(Animal animal);
    }
}
