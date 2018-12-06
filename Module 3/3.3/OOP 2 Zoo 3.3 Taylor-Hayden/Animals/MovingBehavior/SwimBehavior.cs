using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent SwimBehavior.
    /// </summary>
    public class SwimBehavior : IMoveBehavior
    {
        /// <summary>
        /// Moves the animal.
        /// </summary>
        /// <param name="animal"> The animal being moved.</param>
        public void Move(Animal animal)
        {
            // Moves the animal horizontally.
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

            // Moves the animal vertically.
            MoveHelper.MoveVertically(animal, animal.MoveDistance / 2);
        }
    }
}
