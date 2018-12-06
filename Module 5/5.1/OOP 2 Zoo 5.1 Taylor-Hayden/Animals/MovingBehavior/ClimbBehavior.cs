using Animals.MovingBehavior;
using System;

namespace Animals
{
    /// <summary>
    /// The class used to represent the ClimbBehavior class.
    /// </summary>
    [Serializable]
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

            // Doesn't climb left edge.
            switch (this.process)
            {
                case ClimbProcess.Scurrying:

                    // Move horizontally
                    MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

                    // if animal hits a vertical edge.
                    if ((animal.MoveDistance + animal.XPosition) > animal.XPositionMax)
                    {

                        animal.XPosition = animal.XPositionMax;
                        this.NextProcess(animal);

                    }
                    // if the animal will hit a vertical wall (either right or left), set the animal to the edge and switch to the next process
                    if ((animal.XPosition - animal.MoveDistance) < 0)
                    {
                        animal.XPosition = 0;
                        this.NextProcess(animal);
                    }
                    break;

                case ClimbProcess.Climbing:

                    // make sure its moving up (set vertical direction)
                    animal.YDirection = Utilities.VerticalDirection.Up;

                    MoveHelper.MoveVertically(animal, animal.MoveDistance);

                    if ((animal.YPosition - animal.MoveDistance) < this.maxHeight)
                    {
                        // Change animals direction.
                        animal.YDirection = Utilities.VerticalDirection.Down;

                        // If the animal was going right, make it go left.
                        if (animal.XDirection == Utilities.HorizontalDirection.Left)
                        {
                            animal.XDirection = Utilities.HorizontalDirection.Right;
                        }
                        // If the animal was going left, make it go right.
                        else
                        {
                            animal.XDirection = Utilities.HorizontalDirection.Left;
                        }
                        // switch to gliding. (switch state)
                        this.NextProcess(animal);
                    }

                    break;

                case ClimbProcess.Gliding:

                        // move diagnolly at a steep angle.
                        MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

                        // Move vertically at twice the distance.
                        MoveHelper.MoveVertically(animal, animal.MoveDistance * 2);

                        // if at bottom of cage
                        if ((animal.YPosition + animal.MoveDistance) > animal.YPositionMax)
                        {
                            // switch to scurry.
                            this.NextProcess(animal);
                        }
                    
                    break;


            }
        }

        /// <summary>
        /// Helps switch the process.
        /// </summary>
        /// <param name="animal"></param>
        private void NextProcess(Animal animal)
        {
            // if the current process is climbing.
            if (this.process == ClimbProcess.Climbing)
            {
                // Switch to gliding.
                this.process = ClimbProcess.Gliding;
            }

            // if the current process is falling, switch to scurrying
            else if (this.process == ClimbProcess.Gliding)
            {
                this.process = ClimbProcess.Scurrying;
            }

            // if the current process is scurrying
            else if (this.process == ClimbProcess.Scurrying)
            {
                int lowerMax = Convert.ToInt32(Math.Floor(Convert.ToDouble(animal.YPositionMax) * 0.15));
                int higherMax = Convert.ToInt32(Math.Floor(Convert.ToDouble(animal.YPositionMax) * 0.85));

                // set max height to a random value between the lowest max and the highest max
                // Set random max height
                this.maxHeight = random.Next(lowerMax, higherMax);

                // switch to climbing
                this.process = ClimbProcess.Climbing;
            }
        }
    }
}
