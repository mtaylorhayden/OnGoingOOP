using Animals.MovingBehavior;
using System;

namespace Animals
{
    /// <summary>
    /// The class used to represent the ClimbBehavior class.
    /// </summary>
    public class ClimbBehavior : IMoveBehavior
    {
        /// <summary>
        /// The random field for animal.
        /// </summary>
        private static Random random = new Random(DateTime.Now.Millisecond);

        /// <summary>
        /// The process of climbing.
        /// </summary>
        private ClimbProcess process;

        /// <summary>
        /// The maximum height.
        /// </summary>
        private int maxHeight;

        /// <summary>
        /// Moves the animal in a climb behavior
        /// </summary>
        /// <param name="animal"> The animal being moved.</param>
        public void Move(Animal animal)
        {
            switch (this.process)
            {
                case ClimbProcess.Climbing:
                    // Set position to lower leftr hand side of cage.
                    // if the animal is climbing
                    // make sure its moving up (set vertical direction)
                    // Move vertically.
                    // if at masx height (random (make sure random number is in the cage.))
                    // switch to gliding. (switch state)
                    break;

                case ClimbProcess.Gliding:
                    // if the animal is gliding
                    // move diagnolly at a steep angle.
                    // if at bottom of cage
                    // switch to scurry.

                    break;

                case ClimbProcess.Scurrying:

                    // if the animal is scurrying
                    // Move horizontally
                    // if animal hits a vertical edge.
                    // Set random max height
                    // Swtich to climbing (Because scurrying happens before climbing)
                    break;
            }
        }
    }
}
