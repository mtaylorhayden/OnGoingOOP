using Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent the ShowAffectionBehavior class.
    /// </summary>
    public class ShowAffectionBehavior : IEatBehavior
    {
        /// <summary>
        /// Eats the food.
        /// </summary>
        /// <param name="eater"> The eater eating the food.</param>
        /// <param name="food"> The food being ate,</param>
        public void Eat(IEater eater, Food food)
        {
            // Eats the food.

            // Happy they ate food.
            this.ShowAffection();
        }

        /// <summary>
        /// Shows affection, only done by weak creatures.
        /// </summary>
        private void ShowAffection()
        {
            // The creature showing emotion, a weak behavior, only done by betas.
        }
    }
}
