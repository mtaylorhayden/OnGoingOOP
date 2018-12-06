using System;
using System.Collections.Generic;
using BoothItems;
using MoneyCollectors;

namespace People
{
    /// <summary>
    /// The class which is used to represent a booth.
    /// </summary>
    public abstract class Booth : MoneyCollector
    {
        /// <summary>
        /// The list of all the items.
        /// </summary>
        private List<Item> items;

        /// <summary>
        /// The employee currently assigned to be the attendant of the booth.
        /// </summary>
        private Employee attendant;

        /// <summary>
        /// The price of a ticket.
        /// </summary>
        private decimal ticketPrice;

        /// <summary>
        /// The price of the water bottle.
        /// </summary>
        private decimal waterBottlePrice;

        /// <summary>
        /// Initializes a new instance of the Booth class.
        /// </summary>
        /// <param name="attendant">The employee to be the booth's attendant.</param>
        /// <param name="ticketPrice">The price of a ticket.</param>
        /// <param name="waterBottlePrice"> The price of the water bottle.</param>
        public Booth(Employee attendant)
        {
            this.attendant = attendant;
            //this.ticketPrice = ticketPrice;

            this.items = new List<Item>();
        }

        /// <summary>
        /// Gets the attedant.
        /// </summary>
        protected Employee Attendant
        {
            get
            {
                return this.attendant;
            }
        }

        /// <summary>
        /// Gets the list of items.
        /// </summary>
        protected List<Item> Items
        {
            get
            {
                return this.items;
            }
        }
    }
}