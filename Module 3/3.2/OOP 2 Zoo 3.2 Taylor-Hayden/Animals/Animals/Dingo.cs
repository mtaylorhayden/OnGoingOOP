﻿using Foods;
using People;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a dingo.
    /// </summary>
    public class Dingo : Mammal
    {
        /// <summary>
        /// Initializes a new instance of the Dingo class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        public Dingo(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.BabyWeightPercentage = 10.0;

            // Changes the eating behavior to bury and eat bone behavior.
            this.EaterBehavior = new BuryAndEatBone();
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public override void Eat(Food food)
        {
            base.Eat(food);

            this.Bark();
        }

        /// <summary>
        /// Makes a barking noise.
        /// </summary>
        private void Bark()
        {
            // Bark in excitement.
        }
    }
}