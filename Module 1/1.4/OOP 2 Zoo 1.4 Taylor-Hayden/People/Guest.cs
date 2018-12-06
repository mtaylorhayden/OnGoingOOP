using BoothItems;
using Foods;
using System.Collections.Generic;
using VendingMachines;
using MoneyCollectors;
using Accounts;

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
        /// The checking account for the guest.
        /// </summary>
        private IMoneyCollector checkingAccount;

        /// <summary>
        /// The gender of the guest.
        /// </summary>
        private Gender gender;

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
        /// <param name="Color">The color of the guest's wallet.</param>
        public Guest(string name, int age, decimal moneyBalance, WalletColor Color, Gender gender, IMoneyCollector checkingAccount)
        {

            this.checkingAccount = checkingAccount;
            //this.checkingAccount.AddMoney(2500.00m);
            this.age = age;
            this.bag = new List<Item>();
            this.name = name;
            this.wallet = new Wallet(Color);
            this.wallet.AddMoney(moneyBalance);
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
        /// Sets the gender of the guest.
        /// </summary>
        public Gender Gender
        {
            get
            {
                return gender;
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
        /// Gets the checking account for the guest.
        /// </summary>
        public IMoneyCollector CheckingAccount
        {
            get
            {
                return this.checkingAccount;
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
            return string.Format($"{this.Name}, { this.Age}, ${this.wallet.MoneyBalance},  ${this.checkingAccount.MoneyBalance}");
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

            // If you don't have enough money for the food.
            if(wallet.MoneyBalance < price)
            {
                // Withdrawl ten times the amount.
                this.WithdrawMoney(price * 10);
            }

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
            // Get the water price.
            decimal waterPrice = ticketBooth.WaterBottlePrice;

            // If you can't affoard a water bottle.
            if (wallet.MoneyBalance < waterPrice)
            {
                this.WithdrawMoney(waterPrice * 2);
            }

            // Gets the ticket price and stores it in the amount.
            decimal amount = ticketBooth.TicketPrice;

            // If you can't affoard a ticket.
            if (wallet.MoneyBalance < amount)
            {
                this.WithdrawMoney(amount * 2);
            }

            // Calls the wallet's remove money.
            decimal removedMoney = this.wallet.RemoveMoney(amount);

            // Sells the ticket.
            Ticket ticket = ticketBooth.SellTicket(removedMoney);

            // Remove money from the wallet.
            decimal money = this.wallet.RemoveMoney(waterPrice);

            // Sells the water.
            WaterBottle waterBottle = ticketBooth.SellWaterBottle(waterPrice);

            // Add the water bottle to your bag.
            bag.Add(waterBottle);

            return ticket;
        }

        /// <summary>
        /// Gets the wallet for the guest.
        /// </summary>
        public Wallet Wallet
        {
            get
            {
                return wallet;
            }
        }

        /// <summary>
        /// Withdraws the money from the guest.
        /// </summary>
        /// <param name="amount"> The amount that could be withdrawn.</param>
        public void WithdrawMoney(decimal amount)
        {
            decimal removedMoney = this.CheckingAccount.RemoveMoney(amount);

            this.Wallet.AddMoney(removedMoney);
        }
    }
}