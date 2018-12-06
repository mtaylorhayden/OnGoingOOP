using People;

namespace Animals
{
    /// <summary>
    /// The class which is used to represent a hummingbird.
    /// </summary>
    public class Hummingbird : Bird
    {
        /// <summary>
        /// Initializes a new instance of the Hummingbird class.
        /// </summary>
        /// <param name="name">The name of the animal.</param>
        /// <param name="age">The age of the animal.</param>
        /// <param name="weight">The weight of the animal (in pounds).</param>
        public Hummingbird(string name, int age, double weight, Gender gender)
            : base(name, age, weight, gender)
        {
            this.BabyWeightPercentage = 17.5;
        }

        /// <summary>
        /// Overrides the virtual display size method in the animal class.
        /// </summary>
        public override double DisplaySize
        {
            get
            {
                // If the animal is a baby then make a smaller display size.
                return this.Age == 0 ? 0.6 : 0.4;
            }
        }

        /// <summary>
        /// Make the hummingbird hover.
        /// </summary>
        public override void Move()
        {
            base.Move();
        }
    }
}