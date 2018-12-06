using BoothItems;
using Foods;
using System.Collections.Generic;
using VendingMachines;

namespace People
{
    /// <summary>
    /// The class which is used to represent a guest.
    /// </summary>
    public class Guest : IEater
    {
        /// <summary>
        /// A bag with items.
        /// </summary>
        private List<Item> bag;

        /// <summary>
        /// The age of the guest.
        /// </summary>
        private int age;

        /// <summary>
        /// The name of the guest.
        /// </summary>
        private string name;

        /// <summary>
        /// The guest's wallet.
        /// </summary>
        private Wallet wallet;

        /// <summary>
        /// Initializes a new instance of the Guest class.
        /// </summary>
        /// <param name="name">The name of the guest.</param>
        /// <param name="age">The age of the guest.</param>
        /// <param name="moneyBalance">The initial amount of money to put into the guest's wallet.</param>
        /// <param name="walletColor">The color of the guest's wallet.</param>
        public Guest(string name, int age, decimal moneyBalance, string walletColor)
        {
            this.age = age;
            this.name = name;
            this.wallet = new Wallet(walletColor);
            this.wallet.AddMoney(moneyBalance);
            this.bag = new List<Item>();
        }

        /// <summary>
        /// Gets the age of the guest.
        /// </summary>
        public int Age
        {
            get
            {
                return this.age;
            }
        }

        /// <summary>
        /// Gets the name of the guest.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
        }

        /// <summary>
        /// Gets the weight of the guest.
        /// </summary>
        public double Weight
        {
            get
            {
                // Confidential.
                return 0.0;
            }
        }

        /// <summary>
        /// Eats the specified food.
        /// </summary>
        /// <param name="food">The food to eat.</param>
        public void Eat(Food food)
        {
            // Eat the food.
        }

        /// <summary>
        /// Overrides the original to string method and sets a new format.
        /// </summary>
        /// <returns> The new formatted string.</returns>
        public override string ToString()
        {
            // Formats the string to present the specific fields.
            return string.Format($"{this.Name}, ${this.wallet.MoneyBalance}, { this.Age}");
        }

        /// <summary>
        /// Feeds the specified eater.
        /// </summary>
        /// <param name="eater">The eater to be fed.</param>
        /// <param name="animalSnackMachine">The animal snack machine from which to buy food.</param>
        public void FeedAnimal(IEater eater, VendingMachine animalSnackMachine)
        {
            // Find food price.
            decimal price = animalSnackMachine.DetermineFoodPrice(eater.Weight);

            // Get money from wallet.
            decimal payment = this.wallet.RemoveMoney(price);

            // Buy food.
            Food food = animalSnackMachine.BuyFood(payment);

            // Feed animal.
            eater.Eat(food);
        }

        /// <summary>
        /// Visits the information booth.
        /// </summary>
        /// <param name="informationBooth"> The booth being visited.</param>
        public void VisitInformationBooth(GivingBooth informationBooth)
        {
            // Gets the map.
            Map map = informationBooth.GiveFreeMap();

            // Gets  the coupon book.
            CouponBook couponBook = informationBooth.GiveFreeCouponBook();

            bag.Add(map);
            bag.Add(couponBook);
        }

        /// <summary>
        /// Visits the ticket booth.
        /// </summary>
        /// <param name="ticketBooth"> The ticket booth that will be visited.</param>
        /// <returns> The ticket from the ticket booth.</returns>
        public Ticket VisitTicketBooth(MoneyCollectingBooth ticketBooth)
        {
            // Gets the ticket price and stores it in the amount.
            decimal amount = ticketBooth.TicketPrice;

            // Calls the wallet's remove money.
            decimal removedMoney = this.wallet.RemoveMoney(amount);

            // Sells the ticket.
            Ticket ticket = ticketBooth.SellTicket(removedMoney);

            // Get the water price.
            decimal waterPrice = ticketBooth.WaterBottlePrice;

            // Remove money from the wallet.
            decimal money = this.wallet.RemoveMoney(waterPrice);

            // Sells the water.
            WaterBottle waterBottle = ticketBooth.SellWaterBottle(waterPrice);

            // Add the water bottle to your bag.
            bag.Add(waterBottle);

            return ticket;
        }
    }
}