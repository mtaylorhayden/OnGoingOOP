using System.Collections.Generic;
using Airplanes;

namespace Airports
{
    /// <summary>
    /// The class which is used to represent an airport.
    /// </summary>
    public class Airport
    {
        /// <summary>
        /// A list of the airplanes currently located within the airport.
        /// </summary>
        private List<Airplane> airplanes = new List<Airplane>();

        /// <summary>
        /// Gets or sets a list of the airplanes currently located within the airport.
        /// </summary>
        public List<Airplane> Airplanes
        {
            get
            {
                return this.airplanes;
            }

            set
            {
                this.airplanes = value;
            }
        }
    }
}