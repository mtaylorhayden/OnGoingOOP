﻿using System.Collections.Generic;

namespace BoothItems
{
    /// <summary>
    /// The class that represents the toy water bottle.
    /// </summary>
    public class WaterBottle : Item
    {
        /// <summary>
        /// The serial number of the water bottle.
        /// </summary>
        private int serialNumber;

        /// <summary>
        /// Initializes a new instance of the WaterBottle class.
        /// </summary>
        /// <param name="price"> The price of the water bottle.</param>
        /// <param name="serialNumber"> The serial number of the water bottle.</param>
        /// <param name="weight"> The weight of the water bottle.</param>
        public WaterBottle(decimal price, int serialNumber, double weight)
            : base(price, weight)
        {
            this.serialNumber = serialNumber;
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
    }
}
