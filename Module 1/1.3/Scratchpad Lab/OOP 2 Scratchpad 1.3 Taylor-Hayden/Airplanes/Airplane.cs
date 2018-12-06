using System.Collections.Generic;
using People;

namespace Airplanes
{
    /// <summary>
    /// The class which is used to represent an airplane.
    /// </summary>
    public class Airplane
    {
        /// <summary>
        /// A list of the passengers currently located within the airplane.
        /// </summary>
        private List<Passenger> passengers = new List<Passenger>();

        /// <summary>
        /// Gets or sets a list of the passengers currently located within the airplane.
        /// </summary>
        public List<Passenger> Passengers
        {
            get
            {
                return this.passengers;
            }

            set
            {
                this.passengers = value;
            }
        }
    }
}