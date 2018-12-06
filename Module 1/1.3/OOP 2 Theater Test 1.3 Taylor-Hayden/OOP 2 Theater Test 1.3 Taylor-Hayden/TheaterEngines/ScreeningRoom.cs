using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheaterEngine
{
    /// <summary>
    /// The class which is used to represent a theater.
    /// </summary>
    public class ScreeningRoom
    {
        /// <summary>
        /// The indicator of whether or not the screening room is 3D capable.
        /// </summary>
        private bool is3dCapable;

        /// <summary>
        /// The movie currently showing in the screening room.
        /// </summary>
        private Movie nowShowing;

        /// <summary>
        /// The seating capacity of the screening room.
        /// </summary>
        private int seatingCapacity;

        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="is3dCapable">An indicator of whether or not the screening room
        /// is able to show 3D movies.</param>
        /// <param name="seatingCapacity">The maximum number of guests allowed in the
        /// screening room at a single time.</param>
        public ScreeningRoom(bool is3dCapable, int seatingCapacity)
        {
            this.is3dCapable = is3dCapable;
            this.seatingCapacity = seatingCapacity;
        }

        /// <summary>
        /// Gets or sets a value indicating whether or not the screening room is 3D capable.
        /// </summary>
        public bool Is3dCapable
        {
            get
            {
                return this.is3dCapable;
            }

            set
            {
                this.is3dCapable = value;
            }
        }

        /// <summary>
        /// Gets or sets the currently-playing movie.
        /// </summary>
        public Movie NowShowing
        {
            get
            {
                return this.nowShowing;
            }

            set
            {
                this.nowShowing = value;
            }
        }

        /// <summary>
        /// Gets or sets the seating capacity of the screening room.
        /// </summary>
        public int SeatingCapacity
        {
            get
            {
                return this.seatingCapacity;
            }

            set
            {
                this.seatingCapacity = value;
            }
        }
    }
}