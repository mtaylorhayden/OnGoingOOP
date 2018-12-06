using Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent the ConsumeBehavior class.
    /// </summary>
    public class ConsumeBehavior : IEatBehavior
    {
        /// <summary>
        /// Eats the food.
        /// </summary>
        /// <param name="eater"> The instance eating the food.</param>
        /// <param name="food"> The food being ate.</param>
        public void Eat(IEater eater, Food food)
        {
            // Increase animal's weight as a result of eating food.
            eater.Weight += food.Weight * (eater.WeightGainPercentage / 100);
        }
    }
}
