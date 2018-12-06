using System;
using System.Collections.Generic;
using BoothItems;

namespace People
{
    /// <summary>
    /// The class which is used to represent a booth.
    /// </summary>
    public class Booth
    {
        /// <summary>
        /// The list of coupon books.
        /// </summary>
        private List<CouponBook> couponBooks;

        /// <summary>
        /// The list of maps.
        /// </summary>
        private List<Map> maps;

        /// <summary>
        /// The list of tickets.
        /// </summary>
        private List<Ticket> tickets;

        /// <summary>
        /// The list of water bottles.
        /// </summary>
        private List<WaterBottle> waterBottles;

        /// <summary>
        /// The employee currently assigned to be the attendant of the booth.
        /// </summary>
        private Employee attendant;

        /// <summary>
        /// The amount of money currently in the booth.
        /// </summary>
        private decimal moneyBalance;

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
            //// DateTime today = new DateTime(2018, 6, 9);

            // Creates a list of coupon books.
            this.couponBooks = new List<CouponBook>();

            // Make 5 coupon books and stop at 5.
            for (int c = 0; c < 5; c++)
            {
                // Create a variable of type coupon book and pass in the correct parameters.
                CouponBook couponBook = new CouponBook(DateTime.Now, DateTime.Now.AddYears(1), 0.8);
                
                // Add the coupon book to the list of coupon books.
                this.couponBooks.Add(couponBook);
            }

            // Creates a new list of maps.
            this.maps = new List<Map>();

            // Make 10 maps.
            for (int m = 0; m < 10; m++)
            {
                // Create a variable of type map and pass in the correct parameters.
                Map map = new Map(.5, DateTime.Now);

                this.maps.Add(map);
            }

            // Creates a new list of tickets.
            this.tickets = new List<Ticket>();

            // Creates 5 tickets.
            for (int t = 0; t < 5; t++)
            {
                // Create a variable of type ticket and pass in the correct parameters.
                Ticket ticket = new Ticket(15, t + 1, .01);

                this.tickets.Add(ticket);
            }

            // Creates a list of water bottles.
            this.waterBottles = new List<WaterBottle>();

            // Creates 5 water bottles.
            for (int w = 0; w < 5; w++)
            {
                // Creates a new water bottle and pass in the correct parameters.
                WaterBottle waterBottle = new WaterBottle(3, w + 1, 1);

                this.waterBottles.Add(waterBottle);

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
            couponBook = attendant.FindCouponBook(couponBooks);

            return null;
        }

        /// <summary>
        /// Gives a free map away.
        /// </summary>
        /// <returns> The map that will be given away.</returns>
        public Map GiveFreeMap()
        {
            Map map = null;

            // Find the map.
            map = attendant.FindMap(maps);

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
            if (payment == TicketPrice)
            {
                // Find the ticket from the list of tickets.
                ticket = attendant.FindTicket(tickets);

                // If the ticket was bought.
                if(ticket != null)
                {
                    // Add the payment to the money balance.
                    this.moneyBalance += payment;
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
            if(payment == waterBottlePrice)
            {
                waterBottle = attendant.FindWaterBottler(waterBottles);

                // If the bottle was bought then add the money to the booths money balance.
                if(waterBottle != null)
                {
                    this.moneyBalance += payment;
                }
            }
            
            return waterBottle;
        }

        /// <summary>
        /// Adds a specified amount of money to the booth.
        /// </summary>
        /// <param name="amount">The amount of money to add.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyBalance += amount;
        }
    }
}