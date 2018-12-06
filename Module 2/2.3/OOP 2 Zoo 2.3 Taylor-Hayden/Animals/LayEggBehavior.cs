using People;

namespace Animals
{
    /// <summary>
    /// The class used to represent the LayEggBehavior class.
    /// </summary>
    public class LayEggBehavior : IBirthBehavior
    {
        public IReproducer Reproduce(Animal animal)
        {
            IReproducer baby = this.LayEgg(animal);

            if(baby is IHatchable)
            {
                this.HatchEgg(baby as IHatchable);
            }

            return baby;
        }

        /// <summary>
        /// Hatches an egg.
        /// </summary>
        /// <param name="egg">The egg to hatch.</param>
        private void HatchEgg(IHatchable egg)
        {
            // Hatch the egg.
            egg.Hatch();
        }

        /// <summary>
        /// Lays an egg.
        /// </summary>
        /// <returns>The resulting egg.</returns>
        private IReproducer LayEgg(Animal animal)
        {
            // Gave Lay egg animal parameter, might be wrong?
            return animal.Reproduce();
        }
    }
}
