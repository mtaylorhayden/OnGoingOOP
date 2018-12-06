using System;
using System.Collections.Generic;
using BoothItems;
using MoneyCollectors;

namespace People
{
    /// <summary>
    /// The class which is used to represent a booth.
    /// </summary>
    public class Booth : MoneyCollector
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
        /// The box for all of the bottles.
        /// </summary>
        private bool bottleBox;

        /// <summary>
        /// Initializes a new instance of the Booth class.
        /// </summary>
        /// <param name="attendant">The employee to be the booth's attendant.</param>
        /// <param name="ticketPrice">The price of a ticket.</param>
        /// <param name="waterBottlePrice"> The price of the water bottle.</param>
        public Booth(Employee attendant, decimal ticketPrice, decimal waterBottlePrice)
        {
            this.attendant = attendant;
            this.ticketPrice = ticketPrice;

            this.items = new List<Item>();

            // Make 5 coupon books and stop at 5.
            for (int c = 0; c < 5; c++)
            {
                // Create a variable of type coupon book and pass in the correct parameters.
                CouponBook couponBook = new CouponBook(DateTime.Now, DateTime.Now.AddYears(1), 0.8);

                this.items.Add(couponBook);
            }

            // Make 10 maps.
            for (int m = 0; m < 10; m++)
            {
                // Create a variable of type map and pass in the correct parameters.
                Map map = new Map(.5, DateTime.Now);

                this.items.Add(map);
            }

            // Creates 5 tickets.
            for (int t = 0; t < 5; t++)
            {
                // Create a variable of type ticket and pass in the correct parameters.
                Ticket ticket = new Ticket(15, t + 1, .01);

                this.items.Add(ticket);
            }

            // Creates 5 water bottles.
            for (int w = 0; w < 5; w++)
            {
                // Creates a new water bottle and pass in the correct parameters.
                WaterBottle waterBottle = new WaterBottle(3, w + 1, 1);

                this.items.Add(waterBottle);

                this.waterBottlePrice = waterBottle.Price;
            }
        }

        /// <summary>
        /// Gets the ticket price.
        /// </summary>
        public decimal TicketPrice
        {
            get
            {
                return this.ticketPrice;
            }
        }

        /// <summary>
        /// Gets the price of the water bottle.
        /// </summary>
        public decimal WaterBottlePrice
        {
            get
            {
                return this.waterBottlePrice;
            }
        }

        /// <summary>
        /// Gives a coupon book away for free.
        /// </summary>
        /// <returns> The coupon book that is being given away.</returns>
        public CouponBook GiveFreeCouponBook()
        {
            CouponBook couponBook = null;

            // Find the coupon book.
            couponBook = this.attendant.FindItem(this.items, typeof(CouponBook)) as CouponBook;

            return couponBook;
        }

        /// <summary>
        /// Gives a free map away.
        /// </summary>
        /// <returns> The map that will be given away.</returns>
        public Map GiveFreeMap()
        {
            Map map = null;

            // Find the map.
            map = this.attendant.FindItem(this.items, typeof(Map)) as Map;

            return map;
        }

        /// <summary>
        /// Sells the ticket.
        /// </summary>
        /// <param name="payment"> The payment for the ticket.</param>
        /// <returns> The ticket that was sold.</returns>
        public Ticket SellTicket(decimal payment)
        {
            Ticket ticket = null;

            // If the payment is equal to the ticket price.
            if (payment == this.TicketPrice)
            {
                // Find the ticket from the list of tickets.
                ticket = this.attendant.FindItem(this.items, typeof(Ticket)) as Ticket;

                // If the ticket was bought.
                if (ticket != null)
                {
                    // Add the payment to the money balance.
                    this.AddMoney(payment);
                }
            }

            return ticket;
        }

        /// <summary>
        /// Sells the water bottle.
        /// </summary>
        /// <param name="payment"> The payment for the water bottle.</param>
        /// <returns> The water bottle that was sold.</returns>
        public WaterBottle SellWaterBottle(decimal payment)
        {
            WaterBottle waterBottle = null;

            // If the payment is equal to the price of the water bottle.
            if (payment == this.waterBottlePrice)
            {
                waterBottle = this.attendant.FindItem(this.items, typeof(WaterBottle)) as WaterBottle;

                // If the bottle was bought then add the money to the booths money balance.
                if (waterBottle != null)
                {
                    // Add the payment to the money balance.
                    this.AddMoney(payment);
                }
            }
            
            return waterBottle;
        }
    }
}