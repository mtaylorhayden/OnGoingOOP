using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foods;
using People;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class used to represent fish.
    /// </summary>
    public abstract class Fish : Animal
    {
        /// <summary>
        /// Initializes a new instance of the Fish class.
        /// </summary>
        /// <param name="name"> The name of the fish.</param>
        /// <param name="age"> The age of the fish.</param>
        /// <param name="weight"> The weight of the fish.</param>
        public Fish(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // Fish now lays eggs.
            this.BirthBehavior = new LayEggBehavior();

            // The fish can now swim.
            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Swim);

            // Changes the eating behavior to consuming.
            this.EaterBehavior = new ConsumeBehavior();
        }

        /// <summary>
        /// Makes the fish eat.
        /// </summary>
        /// <param name="food"> The food the fish will eat.</param>
        public override void Eat(Food food)
        {
            // While eating, fish gain weight by 5% 
            this.Weight += food.Weight;

            //this.Weight *= .05;
        }
    }
}
