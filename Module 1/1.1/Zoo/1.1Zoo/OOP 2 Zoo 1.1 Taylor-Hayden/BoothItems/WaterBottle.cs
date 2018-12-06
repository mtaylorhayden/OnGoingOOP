using System.Collections.Generic;

namespace BoothItems
{
    /// <summary>
    /// The class that represents the toy water bottle.
    /// </summary>
    public class WaterBottle
    {
        /// <summary>
        /// The price of the water bottle.
        /// </summary>
        private decimal price;

        /// <summary>
        /// The serial number of the water bottle.
        /// </summary>
        private int serialNumber;

        /// <summary>
        /// The weight of the water bottle.
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the WaterBottle class.
        /// </summary>
        /// <param name="price"> The price of the water bottle.</param>
        /// <param name="serialNumber"> The serial number of the water bottle.</param>
        /// <param name="weight"> The weight of the water bottle.</param>
        public WaterBottle(decimal price, int serialNumber, double weight)
        {
            this.price = price;
            this.serialNumber = serialNumber;
            this.weight = weight; 
        }

        /// <summary>
        /// Gets the price of the water bottle.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
            }
        }

        /// <summary>
        /// Gets the serial number of ticket. 
        /// </summary>
        public int SerialNumber
        {
            get
            {
                return this.serialNumber;
            }
        }

        /// <summary>
        /// Gets the weight of the water bottle.
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
