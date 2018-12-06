using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoothItems
{
    /// <summary>
    /// The class used to represent an item.
    /// </summary>
    public abstract class Item : SoldItem
    {
        /// <summary>
        /// The weight of the item.
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the Item class.
        /// </summary>
        /// <param name="price"> The price of the item.</param>
        /// <param name="weight"> The weight of the item.</param>
        public Item(decimal price, double weight)
            : base(price, weight)
        {
            this.weight = weight;
        }

        /// <summary>
        /// Gets the weight of the item.
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }
        }
    }
}
