using System;
using System.Collections.Generic;

namespace BoothItems
{
    /// <summary>
    /// The class that represents the toy map.
    /// </summary>
    public class Map
    { 
        /// <summary>
        /// The date the map was issued.
        /// </summary>
        private DateTime dateIssued;

        /// <summary>
        /// The weight of the map.
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the Map class.
        /// </summary>
        /// <param name="weight"> The weight of the map.</param>
        /// <param name="dateIssued"> The date the map was issued.</param>
        public Map(double weight, DateTime dateIssued)
        {
            this.weight = weight;
            this.dateIssued = dateIssued;
        }

        /// <summary>
        /// Gets the date the map was issued.
        /// </summary>
        public DateTime DateIssued
        {
            get
            {
                return this.dateIssued;
            }
        }

        /// <summary>
        /// Gets the weight of the map.
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
