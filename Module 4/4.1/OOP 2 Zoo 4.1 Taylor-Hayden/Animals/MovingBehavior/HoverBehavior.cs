using Animals.MovingBehavior;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class used to represent the HoverBehavior class.
    /// </summary>
    [Serializable]
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
            // define a move distance variable
            int moveDistance;

            if (this.stepCount == 0)
            {
                this.NextProcess(animal);
            }

            this.stepCount--;

            switch (this.process)
            {

                // if the current process is hovering
                case (HoverProcess.Hover):

                        // the animal moves at a normal pace, so set the move distance variable to the animal's move distance
                        moveDistance = animal.MoveDistance;

                    // the animal moves randomly on each step, so give the animal a random horizontal and vertical direction
                    animal.XDirection = random.Next(0, 2) == 0 ? HorizontalDirection.Right : HorizontalDirection.Left;
                    animal.YDirection = random.Next(0, 2) == 0 ? VerticalDirection.Up : VerticalDirection.Down; 

                        this.process = HoverProcess.Zoom;

                    break;

                case (HoverProcess.Zoom):
                    // if there are no more steps to take (step count is at 0), switch to the next process

                        moveDistance = animal.MoveDistance * 4;
                    break;
            }
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

            MoveHelper.MoveVertically(animal, animal.MoveDistance);
        }

        /// <summary>
        /// Changes the behavior process.
        /// </summary>
        /// <param name="animal"></param>
        private void NextProcess(Animal animal)
        {
            // if the current process is hovering
            if (this.process == HoverProcess.Hover)
            {
                // switch to zooming
                this.process = HoverProcess.Zoom;

                // set the step count to a random number between 5 and 8, inclusive
                this.stepCount = random.Next(5, 8);

                // Gets a random horizontal and vertical direction.
                animal.XDirection = random.Next(0, 2) == 0 ? HorizontalDirection.Right : HorizontalDirection.Left;
                animal.YDirection = random.Next(0, 2) == 0 ? VerticalDirection.Up : VerticalDirection.Down;
            }
            else
            {
                // Switch hover.
                this.process = HoverProcess.Hover;

                // set the step count to a random number between 7 and 10, inclusive
                this.stepCount = random.Next(7, 10);
            }
        }
    }
}
