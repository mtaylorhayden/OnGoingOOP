using BoothItems;
using MoneyCollectors;

namespace People
{
    /// <summary>
    /// That class used to represent a money collecting booth.
    /// </summary>
    public class MoneyCollectingBooth : Booth
    {
        /// <summary>
        /// The price of the tickets.
        /// </summary>
        private decimal ticketPrice;

        /// <summary>
        /// The price of the water bottle.
        /// </summary>
        private decimal waterBottlePrice;

        /// <summary>
        /// The money box for the booth.
        /// </summary>
        private MoneyCollector moneyBox;

        /// <summary>
        /// Initializes a new instance of the MoneyCollectingBooth class.
        /// </summary>
        /// <param name="attendent"> The attendant for the booth.</param>
        /// <param name="ticketPrice"> The price of the tickets.</param>
        /// <param name="waterBottlePrice"> The price of the water bottles.</param>
        public MoneyCollectingBooth(Employee attendant, decimal ticketPrice, decimal waterBottlePrice)
            : base(attendant)
        {
            this.moneyBox = new MoneyCollector();
            this.ticketPrice = ticketPrice;
            this.waterBottlePrice = waterBottlePrice;


            // Creates 5 tickets.
            for (int t = 0; t < 5; t++)
            {
                // Create a variable of type ticket and pass in the correct parameters.
                Ticket ticket = new Ticket(15, t + 1, .01);

                Items.Add(ticket);
            }

            // Creates 5 water bottles.
            for (int w = 0; w < 5; w++)
            {
                // Creates a new water bottle and pass in the correct parameters.
                WaterBottle waterBottle = new WaterBottle(3, w + 1, 1);

                Items.Add(waterBottle);

                this.waterBottlePrice = waterBottle.Price;
            }
        }

        /// <summary>
        /// Gets the money balance for the booth.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                 return this.moneyBox.MoneyBalance;
            }
        }

        /// <summary>
        /// Gets the price of the tickets.
        /// </summary>
        public decimal TicketPrice
        {
            get
            {
                return this.ticketPrice;
            }
        }

        /// <summary>
        /// Gets the price of the water bottles.
        /// </summary>
        public decimal WaterBottlePrice
        {
            get
            {
                return this.waterBottlePrice;
            }
        }

        /// <summary>
        /// The money being added to the moeny collecting booth.
        /// </summary>
        /// <param name="amount"> The amount that could be added to the booth.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyBox.AddMoney(amount);
        }

        /// <summary>
        /// Removes money from the booth.
        /// </summary>
        /// <param name="amount"> The amount being passed into the booth.</param>
        /// <returns> The amount that was removed from the booth.</returns>
        public decimal RemoveMoney(decimal amount)
        {
            decimal amountRemoved = this.moneyBox.RemoveMoney(amount);

            return amountRemoved;
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
                ticket = this.Attendant.FindItem(this.Items, typeof(Ticket)) as Ticket;

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
                waterBottle = this.Attendant.FindItem(this.Items, typeof(WaterBottle)) as WaterBottle;

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
