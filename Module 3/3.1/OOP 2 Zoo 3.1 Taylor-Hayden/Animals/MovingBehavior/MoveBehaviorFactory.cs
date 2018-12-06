using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The factory for the move behavior.
    /// </summary>
    public static class MoveBehaviorFactory
    {
        /// <summary>
        /// Create move behavior.
        /// </summary>
        /// <param name="type"> The type of move behavior.</param>
        /// <returns> A move behavior.</returns>
        public static IMoveBehavior CreateMoveBehavior(MoveBehaviorType type)
        {
            IMoveBehavior moveBehavior = null;

            // Depending on type, change behavior.
            switch (type)
            {
                case MoveBehaviorType.Fly:
                    moveBehavior = new FlyBehavior();
                    break;
                    
                case MoveBehaviorType.Pace:
                    moveBehavior = new PaceBehavior();
                    break;
                    
                case MoveBehaviorType.Swim:
                    moveBehavior = new SwimBehavior();
                    break;
                    
                case MoveBehaviorType.NoMove:
                    moveBehavior = new NoMoveBehavior();
                    break;
            }
            return moveBehavior;
        }
    }
}