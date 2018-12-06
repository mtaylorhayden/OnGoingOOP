using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using People;

namespace Animals
{
    /// <summary>
    /// The class used to represent the kangaroo.
    /// </summary>
    public class Kangaroo : Mammal
    {
        /// <summary>
        /// Initializes a new instance of the Kangaroo class.
        /// </summary>
        /// <param name="name"> The name of the kangaroo.</param>
        /// <param name="age"> The age of the kangaroo.</param>
        /// <param name="weight"> The weight of the kangaroo.</param>
        public Kangaroo(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The baby will weigh 13% of the mothers weight.
            this.BabyWeightPercentage = .13 * this.Weight;
        }

        /// <summary>
        /// Makes the kangaroo hop.
        /// </summary>
        public override void Move()
        {
            base.Move();
        }
    }
}
