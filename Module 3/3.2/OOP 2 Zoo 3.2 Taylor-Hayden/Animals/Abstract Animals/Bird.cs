using People;
using System.Reflection;
using Utilities;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a bird.
    /// </summary>
    public abstract class Bird : Animal, IHatchable
    {

        /// <summary>
        /// Initializes a new instance of the Bird class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        public Bird(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            // The bird now lays eggs.
            this.BirthBehavior = new LayEggBehavior();

            // This gives the bird the a flying behavior.
            this.MoveBehavior = MoveBehaviorFactory.CreateMoveBehavior(MoveBehaviorType.Fly);

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
                return 5.0;
            }
        }

        /// <summary>
        /// Hatches from its egg.
        /// </summary>
        public void Hatch()
        {
            // Break out of egg.
        }
    }
}