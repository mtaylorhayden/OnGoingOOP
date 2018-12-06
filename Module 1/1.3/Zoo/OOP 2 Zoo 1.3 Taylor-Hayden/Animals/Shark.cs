using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// Used to represent the shark class.
    /// </summary>
    public class Shark : Fish
    {
        /// <summary>
        /// Initializes a new instance of the Shark class.
        /// </summary>
        /// <param name="name"> The name of the shark.</param>
        /// <param name="age"> The age of the shark.</param>
        /// <param name="weight"> The weight of the shark.</param>
        public Shark(string name, int age, double weight)
            : base(name, age, weight)
        {
            this.BabyWeightPercentage = this.Weight * .18;
        }

        /// <summary>
        /// Gets the percentage of weight gained for each pound of food eaten.
        /// </summary>
        protected override double WeightGainPercentage
        {
            get
            {
                return 0;
            }
        }
    }
}
