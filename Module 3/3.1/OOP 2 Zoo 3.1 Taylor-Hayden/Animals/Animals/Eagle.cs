using People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent an eagle.
    /// </summary>
    public class Eagle : Bird
    {
        /// <summary>
        /// Initializes a new instance of the Eagle class.
        /// </summary>
        /// <param name="name"> The name of the eagle.</param>
        /// <param name="age"> The age of the eagle.</param>
        /// <param name="weight"> The weight of the eagle.</param>
        public Eagle(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The baby will weight 25% of the mothers weight.
            this.BabyWeightPercentage = .25 * this.Weight;
        }
    }
}
