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
    public class Ticket
    {
        /// <summary>
        /// Is the ticket redeemed.
        /// </summary>
        private bool isRedeemed;

        /// <summary>
        /// The price of the ticket.
        /// </summary>
        private decimal price;

        /// <summary>
        /// The serial number of the ticket.
        /// </summary>
        private int serialNumber;

        /// <summary>
        /// The weight of the ticket.
        /// </summary>
        private double weight;

        /// <summary>
        /// Initializes a new instance of the Ticket class.
        /// </summary>
        /// <param name="price"> The price of the ticket.</param>
        /// <param name="serialNumber"> The serial number for the ticket.</param>
        /// <param name="weight"> The weight of the ticket.</param>
        public Ticket(decimal price, int serialNumber, double weight)
        {
            this.price = price;
            this.serialNumber = serialNumber;
            this.weight = weight;
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
        /// Gets the price for the ticket.
        /// </summary>
        public decimal Price
        {
            get
            {
                return this.price;
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
        /// Gets the weight of the ticket.
        /// </summary>
        public double Weight
        {
            get
            {
                return this.weight;
            }
        }

        /// <summary>
        /// Redeems the ticket.
        /// </summary>
        public void Redeem()
        {
            isRedeemed = true;
        }
    }
}
