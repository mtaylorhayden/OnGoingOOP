using MoneyCollectors;
using People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// The class used to represent a chimpanzee.
    /// </summary>
    public class Chimpanzee : Mammal
    {
        /// <summary>
        /// Initializes a new instance of the Chimpanzee class.
        /// </summary>
        /// <param name="name"> The name of the chimpanzee.</param>
        /// <param name="age"> The age of the chimpanzee.</param>
        /// <param name="weight"> The weight of the chimpanzee.</param>
        public Chimpanzee(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // A baby chimp will weigh 10% of its mothers weight.
            this.BabyWeightPercentage = .1 * this.Weight;
        }
    }
}
