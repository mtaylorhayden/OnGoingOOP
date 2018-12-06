using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The interface for th move behvaior class.
    /// </summary>
    public interface IMoveBehavior
    {
        /// <summary>
        /// Moves an animal.
        /// </summary>
        /// <param name="animal"> The animal being moved.</param>
        void Move(Animal animal);
    }
}
