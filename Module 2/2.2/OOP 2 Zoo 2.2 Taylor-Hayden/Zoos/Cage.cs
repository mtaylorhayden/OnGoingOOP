using Animals;
using CagedItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoos
{
    /// <summary>
    /// The class used to represent the zoo's cage.
    /// </summary>
    public class Cage
    {
        /// <summary>
        /// The list of animals.
        /// </summary>
        private List<ICageable> cagedItems;

        /// <summary>
        /// Initializes a new instance of the cage class.
        /// </summary>
        /// <param name="height"> The height of the cage.</param>
        /// <param name="width"> The width of the cage.</param>
        /// <param name="animalType"> The type of animal in the cage.</param>
        public Cage(int height, int width, Type animalType)
        {
            this.AnimalType = animalType;
            this.Height = height;
            this.Width = width;

            this.cagedItems = new List<ICageable>();
        }

        /// <summary>
        /// Gets or sets the animal type.
        /// </summary>
        public Type AnimalType { get; set; }

        /// <summary>
        /// Gets or sets the height of the cage.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets or set the height of the cage.
        /// </summary>
        public int Width { get; set; }


        /// <summary>
        /// Gets the collection of animals.
        /// </summary>
        public IEnumerable<ICageable> CagedItems
        {
            get
            {
                // The list of animals.
                return cagedItems;
            }
        }

        /// <summary>
        /// Adds the animal to the cage. 
        /// </summary>
        /// <param name="animal"></param>
        public void Add(ICageable cagedItem)
        {
            // Adds an item to the list of caged items.
            this.cagedItems.Add(cagedItem);
        }

        /// <summary>
        /// Removes the animal from the cage.
        /// </summary>
        /// <param name="animal"></param>
        public void Remove(ICageable cagedItem)
        {
            // Removes an item from the list of caged items.
            this.cagedItems.Remove(cagedItem);
        }
    }
}
