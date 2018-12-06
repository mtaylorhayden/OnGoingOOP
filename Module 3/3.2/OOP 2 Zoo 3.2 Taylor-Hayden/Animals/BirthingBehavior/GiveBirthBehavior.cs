using Foods;
using People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent the GiveBirthBehavior class.
    /// </summary>
    public class GiveBirthBehavior : IBirthBehavior
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="animal"></param>
        /// <returns></returns>
        public IReproducer Reproduce(Animal animal)
        {
            IReproducer baby = animal.Reproduce();

            this.FeedNewborn(baby as Animal, animal);

            return baby;
        }

        /// <summary>
        /// Feeds a baby eater.
        /// </summary>
        /// <param name="newborn">The eater to feed.</param>
        private void FeedNewborn(IEater newborn, Animal animal)
        {
            // Determine milk weight.
            double milkWeight = animal.Weight * 0.005;

            // Generate milk.
            Food milk = new Food(milkWeight);

            // Feed baby.
            newborn.Eat(milk);

            // Reduce parent's weight.
            animal.Weight -= milkWeight;
        }
    }
}
