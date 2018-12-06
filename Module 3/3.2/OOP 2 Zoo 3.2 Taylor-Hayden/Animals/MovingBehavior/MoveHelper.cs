using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The different ways an animal can move are stored in this class.
    /// </summary>
    public static class MoveHelper
    {
        /// <summary>
        /// Moves the animal horizontally.
        /// </summary>
        /// <param name="animal"> The animal being moved.</param>
        /// <param name="moveDistance"> The distance the animal will be moved.</param>
        public static void MoveHorizontally(Animal animal, int moveDistance)
        {
            // If the left/right directiopn is right then...
            if (animal.XDirection == HorizontalDirection.Right)
            {
                // If the distance being moved to the right is greater than the limits then...
                if (animal.XPosition + animal.MoveDistance > animal.XPositionMax)
                {
                    // Sets the left/right position to the maximum left/right position.
                    animal.XPosition = animal.XPositionMax;

                    // Sets the direction to left.
                    animal.XDirection = HorizontalDirection.Left;
                }
                else
                {
                    // Sets the left/right direction plus the move distance.
                    animal.XPosition += animal.MoveDistance;
                }
            }
            else
            {
                // If you try and move the left/right position past 0 then...
                if (animal.XPosition - animal.MoveDistance < 0)
                {
                    animal.XPosition = 0;
                    animal.XDirection = HorizontalDirection.Right;
                }
                // Makes the animal go further right.
                else
                {
                    animal.XPosition -= animal.MoveDistance;
                }
            }
        }

        /// <summary>
        /// Moves the animal vertically.
        /// </summary>
        /// <param name="animal"> The animal being moved.</param>
        /// <param name="moveDistance"> The distance the animal will be moved.</param>
        public static void MoveVertically(Animal animal, int moveDistance)
        {
            // Is the animals direction down.
            if (animal.YDirection == VerticalDirection.Down)
            {
                // If the animal is being moved within the cage towards the downward position.
                if (animal.YPosition + moveDistance > animal.YPositionMax)
                {
                    // The animal's position is at the end of the cage.
                    animal.YPosition = animal.YPositionMax;

                    // Changes the animal's direction.
                    animal.YDirection = VerticalDirection.Up;
                }
                else
                {
                    // Move the animal in the downward position.
                    animal.YPosition += moveDistance;
                }
            }
            else
            {
                // The animal hits the top of the cage.
                if (animal.YPosition - moveDistance < 0)
                {
                    // Changes the animals direction downward.
                    animal.YPosition = 0;
                    animal.YDirection = VerticalDirection.Down;
                }
                // Makes the animal go further right. 
                else
                {
                    // Moves the animal upwards.
                    animal.YPosition -= moveDistance;
                }
            }
        }
    }
}
