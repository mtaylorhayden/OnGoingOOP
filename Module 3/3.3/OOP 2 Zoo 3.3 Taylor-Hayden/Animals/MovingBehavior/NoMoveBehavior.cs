using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent NoMoveBehavior.
    /// </summary>
    public class NoMoveBehavior : IMoveBehavior
    {
        /// <summary>
        /// Makes an animal move or not move.
        /// </summary>
        /// <param name="animal"> The animal being moved, or not moved.</param>
        public void Move(Animal animal)
        {
            // Animal will not move.
        }
    }
}
