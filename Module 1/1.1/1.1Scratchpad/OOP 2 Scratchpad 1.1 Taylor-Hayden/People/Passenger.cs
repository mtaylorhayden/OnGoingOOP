using System.Collections.Generic;

namespace People
{
    /// <summary>
    /// The class which is used to represent a passenger.
    /// </summary>
    public class Passenger : Person
    {
        /// <summary>
        /// A list of the bags currently held by the passenger.
        /// </summary>
        private List<Baggage> bags = new List<Baggage>();

        /// <summary>
        /// Gets or sets a list of the bags currently held by the passenger.
        /// </summary>
        public List<Baggage> Bags
        {
            get
            {
                return this.bags;
            }

            set
            {
                this.bags = value;
            }
        }
    }
}