using People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent an Ostrich.
    /// </summary>
    public sealed class Ostrich : Bird
    {
        /// <summary>
        /// Initializes a new instance of the Ostrich class.
        /// </summary>
        /// <param name="name"> The name of the ostrich.</param>
        /// <param name="age"> The age of the ostrich.</param>
        /// <param name="weight"> The weight of the ostrich.</param>
        public Ostrich(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The babys weight is 30% of its mother's weight.
            this.BabyWeightPercentage = .3 * this.Weight;
        }

        /// <summary>
        /// Makes the ostrich move with its legs instead of flying.
        /// </summary>
        public override void Move()
        {
            base.Move();
        }
    }
}
