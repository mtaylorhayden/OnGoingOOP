using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class used to represent FlyBehavior.
    /// </summary>
    public class FlyBehavior : IMoveBehavior
    {
        /// <summary>
        /// Moves an animal.
        /// </summary>
        /// <param name="animal"> The animal being moved.</param>
        public void Move(Animal animal)
        {
            // Moves the animal horizontally.
            MoveHelper.MoveHorizontally(animal, animal.MoveDistance);

            //If the left / right directiopn is right then...
            if (animal.XDirection == HorizontalDirection.Right)
            {
                //If the distance being moved to the right is greater than the limits then...
                if (animal.XPosition + animal.MoveDistance > animal.XPositionMax)
                {
                    //Sets the left / right position to the maximum left / right position.
                    animal.XPosition = animal.XPositionMax;

                    //Sets the direction to left.
                    animal.XDirection = HorizontalDirection.Left;

                    if (animal.YDirection == VerticalDirection.Up)
                    {
                        animal.YPosition -= 10;

                        animal.YDirection = VerticalDirection.Down;
                    }
                    else
                    {
                        animal.YPosition += 10;

                        animal.YDirection = VerticalDirection.Up;
                    }
                }
                else
                {
                    // Sets the left/right direction plus the move distance.
                    animal.XPosition += animal.MoveDistance;

                    if (animal.YDirection == VerticalDirection.Up)
                    {
                        animal.YPosition -= 10;

                        animal.YDirection = VerticalDirection.Down;
                    }
                    else
                    {
                        animal.YPosition += 10;

                        animal.YDirection = VerticalDirection.Up;
                    }
                }
            }
            else
            {
                //If you try and move the left/ right position past 0 then...
                if (animal.XPosition - animal.MoveDistance < 0)
                {
                    animal.XPosition = 0;
                    animal.XDirection = HorizontalDirection.Right;
                    if (animal.YDirection == VerticalDirection.Up)
                    {
                        animal.YPosition -= 10;

                        animal.YDirection = VerticalDirection.Down;
                    }
                    else
                    {
                        animal.YPosition += 10;

                        animal.YDirection = VerticalDirection.Up;
                    }
                }
                // Makes the animal go further right.
                else
                {
                    animal.XPosition -= animal.MoveDistance;
                }

                if (animal.YDirection == VerticalDirection.Up)
                {
                    animal.YPosition -= 10;

                    animal.YDirection = VerticalDirection.Down;
                }
                else
                {
                    animal.YPosition += 10;

                    animal.YDirection = VerticalDirection.Up;
                }
            }
        }
    }
}
