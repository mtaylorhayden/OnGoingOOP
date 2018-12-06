using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent PaceBehavior.
    /// </summary>
    public class PaceBehavior : IMoveBehavior
    {
        /// <summary>
        /// Moves an animal.
        /// </summary>
        /// <param name="animal"> The animal being moved.</param>
        public void Move(Animal animal)
        {
            // Moves the animal left or right by the animal's move distance.
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);
        }   
    }
}
