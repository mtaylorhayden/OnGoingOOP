using MoneyCollectors;

namespace Stands
{
    /// <summary>
    /// The class used to represent a money collecting stand.
    /// </summary>
    public class MoneyCollectingStand : Stand, IMoneyCollector
    {
        /// <summary>
        /// The price of the item.
        /// </summary>
        private decimal itemPrice;

        /// <summary>
        /// The box of money.
        /// </summary>
        public IMoneyCollector moneyBox;

        /// <summary>
        /// Initializes a new instance of the money collecting stand class.
        /// </summary>
        /// <param name="itemPrice"> The price of the item.</param>
        /// <param name="itemType"> The item's type.</param>
        /// <param name="moneyBox"> The box full of money.</param>
        public MoneyCollectingStand(decimal itemPrice, string itemType, IMoneyCollector moneyBox)
            : base(itemType)
        {
            this.itemPrice = itemPrice;
            this.moneyBox = moneyBox;
        }

        /// <summary>
        /// Gets the price of the item.
        /// </summary>
        public decimal ItemPrice
        {
            get
            {
                return this.itemPrice;
            }
        }

        /// <summary>
        /// Gets the moeney balanace.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                // Call the MoneyBalance property on the containted IMoneyCollector.
                return this.moneyBox.MoneyBalance;
            }
        }

        /// <summary>
        /// Adds money to the money collecting stand.
        /// </summary>
        /// <param name="amountToAdd"> The amount to be added.</param>
        public void AddMoney(decimal amountToAdd)
        {
            // Call the add money on the containted IMoneyCollector.
            this.moneyBox.AddMoney(amountToAdd);
        }

        /// <summary>
        /// Removes money from the stand.
        /// </summary>
        /// <param name="amountToRemove"> The amount to be removed.</param>
        /// <returns> The amount that was removed.</returns>
        public decimal RemoveMoney(decimal amountToRemove)
        {
            // Call the remove money on the containted IMoneyCollector.
            decimal removedMoney = this.moneyBox.RemoveMoney(amountToRemove);

            return removedMoney;
        }
    }
}
