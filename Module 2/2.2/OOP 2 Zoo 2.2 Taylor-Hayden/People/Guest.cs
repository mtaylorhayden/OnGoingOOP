using BoothItems;
using Foods;
using System.Collections.Generic;
using VendingMachines;
using MoneyCollectors;
using Accounts;
using System;
using System.Text.RegularExpressions;
using CagedItems;
using Animals;
using Utilities;


namespace People
{
    /// <summary>
    /// The class which is used to represent a guest.
    /// </summary>
    public class Guest : IEater, ICageable
    {
        private Animal adpotedAnimal;

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
            this.adpotedAnimal = this.AdoptedAnimal;
            this.age = age;
            this.bag = new List<Item>();
            this.checkingAccount = checkingAccount;
            this.name = name;
            this.wallet = new Wallet(Color);
            this.wallet.AddMoney(moneyBalance);

            // Set the x and y axis positions.
            this.YPosition = 0;
            this.XPosition = 0;
        }

        /// <summary>
        /// Gets or sets the x position.
        /// </summary>
        public int XPosition { get; set; }

        /// <summary>
        /// Gets or set the y position.
        /// </summary>
        public int YPosition { get; set; }

        /// <summary>
        /// Gets or sets the horizontal direction of the guest.
        /// </summary>
        public HorizontalDirection XDirection { get; set; }

        /// <summary>
        /// Gets or sets the vertical direction of the guest.
        /// </summary>
        public VerticalDirection YDirection { get; set; }

        /// <summary>
        /// Gets or sets the adopted animal of the guest.
        /// </summary>
        public Animal AdoptedAnimal { get; set; }

        /// <summary>
        /// Gets the display size of the guest.
        /// </summary>
        public double DisplaySize
        {
            get
            {
                return 0.6;
            }
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
            set
            {
                // If the age is between 0 and 120 then set, if not, throw exception.
                if(value > 0 && value < 120)
                {
                    this.age = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
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
            set
            {
                this.gender = value;
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
            set
            {
                // The name will be set if it only contains letters and spaces.
                if (Regex.IsMatch(value, @"^[a-zA-Z ]+$"))
                {
                    this.name = value;
                }
                else
                {
                    throw new FormatException("The name must only contain letters and spaces.");
                }
            }
        }

        /// <summary>
        /// Gets the resource key of the guest.
        /// </summary>
        public string ResourceKey
        {
            get
            {
                return "Guest";
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
            set
            {
                this.checkingAccount = value;
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
        /// Overrides the original to string method and sets a new format.
        /// </summary>
        /// <returns> The new formatted string.</returns>
        public override string ToString()
        {
            return string.Format("{0}: {1}, {2} [${3}, {4}/ ${5}, {6}]", this.name, this.gender, this.age, this.wallet.MoneyBalance, this.wallet.WalletColor, this.CheckingAccount.MoneyBalance, this.AdoptedAnimal);

            // Formats the string to present the specific fields.
            //return string.Format($"{this.Name}, { this.Age}, ${this.wallet.MoneyBalance},  ${this.checkingAccount.MoneyBalance}");
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