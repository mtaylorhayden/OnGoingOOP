using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoothItems
{
    /// <summary>
    /// Represents a item that has been sold.
    /// </summary>
    public abstract class SoldItem
    {
        /// <summary>
        /// The price of the sold item.
        /// </summary>
        private decimal price;

        /// <summary>
        /// Initializes a new instance of the SoldItem class.
        /// </summary>
        /// <param name="price"> The price of the sold item.</param>
        /// <param name="weight"> The weight of the sold item.</param>
        public SoldItem(decimal price, double weight)
        {
            this.price = price;
        }

        /// <summary>
        /// Gets the price of the sold item.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }
        }
    }
}
