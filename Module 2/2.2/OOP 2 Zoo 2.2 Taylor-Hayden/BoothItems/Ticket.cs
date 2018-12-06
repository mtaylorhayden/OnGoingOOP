using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoothItems
{
    /// <summary>
    /// The class that represents the toy ticket.
    /// </summary>
    public class Ticket : Item
    {
        /// <summary>
        /// Is the ticket redeemed.
        /// </summary>
        private bool isRedeemed;

        /// <summary>
        /// The serial number of the ticket.
        /// </summary>
        private int serialNumber;

        /// <summary>
        /// Initializes a new instance of the Ticket class.
        /// </summary>
        /// <param name="price"> The price of the ticket.</param>
        /// <param name="serialNumber"> The serial number for the ticket.</param>
        /// <param name="weight"> The weight of the ticket.</param>
        public Ticket(decimal price, int serialNumber, double weight)
            : base(price, weight)
        {
            this.serialNumber = serialNumber;
        }

        /// <summary>
        /// Gets a value indicating whether the ticket is redeemed or not.
        /// </summary>
        public bool IsRedeemed
        {
            get
            {
                return this.isRedeemed;
            }
        }

        /// <summary>
        /// Gets the serial number for the ticket.
        /// </summary>
        public int SerialNumber
        {
            get
            {
                return this.serialNumber;
            }
        }

        /// <summary>
        /// Redeems the ticket.
        /// </summary>
        public bool Redeem()
        {
            bool result = false;

            if (!this.IsRedeemed)
            {
                this.isRedeemed = true;
                result = true;
            }

            return result;
        }
    }
}