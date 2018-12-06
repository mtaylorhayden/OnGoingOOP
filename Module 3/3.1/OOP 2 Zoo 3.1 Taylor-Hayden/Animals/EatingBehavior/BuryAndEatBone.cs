using Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent the BuryAndEatBone class. 
    /// </summary>
    public class BuryAndEatBone : IEatBehavior
    {
        /// <summary>
        /// Eats the food.
        /// </summary>
        /// <param name="eater"> The item that is an eater.</param>
        /// <param name="food"> The food item being ate.</param>
        public void Eat(IEater eater, Food food)
        {
            // Bury's the food.
            this.BuryBone(food);

            // Eats the food.
            this.DigUpAndEatBone();

            // Barks in satisfaction.
            this.Bark();
        }

        /// <summary>
        /// Makes the instance bark.
        /// </summary>
        private void Bark()
        {

        }

        /// <summary>
        /// Makes the instance bury the bone.
        /// </summary>
        /// <param name="bone"> The bone which is a food item, being buried.</param>
        private void BuryBone(Food bone)
        {

        }

        /// <summary>
        /// Digs up the bone and eats it.
        /// </summary>
        private void DigUpAndEatBone()
        {

        }
    }
}
