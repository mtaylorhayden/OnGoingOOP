﻿using Foods;
using People;
using System;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a mammal.
    /// </summary>
    [Serializable]
    public abstract class Mammal : Animal
    {
        /// <summary>
        /// Initializes a new instance of the Mammal class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        public Mammal(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The animal now gives birth.
            this.BirthBehavior = new GiveBirthBehavior();

            // The mammal now has a pace behavior.
            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Pace);

            // Changes the eating behavior to consuming.
            this.EaterBehavior = new ConsumeBehavior();

        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        public override double WeightGainPercentage
        {
            get
            {
                return 15.0;
            }
        }

        /// <summary>
        /// Creates another reproducer of its own type.
        /// </summary>
        /// <returns>The resulting baby reproducer.</returns>
        public override IReproducer Reproduce()
        {
            // Create a baby reproducer.
            IReproducer baby = base.Reproduce();

            // If the animal is not a platypus and baby is an eater...
            if (this.GetType() != typeof(Platypus) && baby is IEater)
            {
                // Feed the baby.
                this.FeedNewborn(baby as IEater);
            }

            return baby;
        }

        /// <summary>
        /// Feeds a baby eater.
        /// </summary>
        /// <param name="newborn">The eater to feed.</param>
        private void FeedNewborn(IEater newborn)
        {
            // Determine milk weight.
            double milkWeight = this.Weight * 0.005;

            // Generate milk.
            Food milk = new Food(milkWeight);

            // Feed baby.
            newborn.Eat(milk);

            // Reduce parent's weight.
            this.Weight -= milkWeight;
        }
    }
}