﻿using People;

namespace Animals
{
    /// <summary>
    /// The class used to represent a squirrel.
    /// </summary>
    public class Squirrel : Mammal
    {
        /// <summary>
        /// Initializes a new instance of the Squirrel class.
        /// </summary>
        /// <param name="name"> The name of the squirrel.</param>
        /// <param name="age"> The age of the squirrel.</param>
        /// <param name="weight"> The weight of the squirrel.</param>
        public Squirrel(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The baby will weight 17% of the mother.
            this.BabyWeightPercentage = .17 * this.Weight;
        }

        /// <summary>
        /// Makes the squirrel climb and scurry.
        /// </summary>
        public override void Move()
        {
            base.Move();
        }
    }
}
