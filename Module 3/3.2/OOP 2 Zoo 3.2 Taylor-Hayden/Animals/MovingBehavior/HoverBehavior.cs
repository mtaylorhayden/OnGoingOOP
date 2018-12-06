using Animals.MovingBehavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent the HoverBehavior class.
    /// </summary>
    public class HoverBehavior : IMoveBehavior
    {
        /// <summary>
        /// The hovering process.
        /// </summary>
        private HoverProcess process;

        /// <summary>
        /// The random field for animal.
        /// </summary>
        private static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// The number of steps taken.
        /// </summary>
        private int stepCount;

        /// <summary>
        /// Moves the animal in a hovering behavior.
        /// </summary>
        /// <param name="animal"> The animal being moved.</param>
        public void Move(Animal animal)
        {
            switch (this.process)
            {
                case (HoverProcess.Hover):
                
                    // Move a step, which is 5 - 7 steps, in a single direction. One call is 5 - 7 steps.
                    // Make a call to the zoom case.

                    break;

                case (HoverProcess.Zoom):

                    // goes in a single random direction for 7 - 10 steps. 
                    // moves four times its normal step distance.
                    // Calls hover.

                    break;
            }
        }
    }
}
