using MoneyCollectors;

namespace People
{
    /// <summary>
    /// The class which is used to represent a wallet.
    /// </summary>
    public class Wallet : IMoneyCollector
    {
        /// <summary>
        /// the money collector for the wallet.
        /// </summary>
        private IMoneyCollector moneyPocket;

        /// <summary>
        /// Initializes a new instance of the Wallet class.
        /// </summary>
        /// <param name="color">The color of the wallet.</param>
        public Wallet(WalletColor color)
        {
            this.moneyPocket = new MoneyPocket();
        }

        /// <summary>
        /// Gets the money balance for the wallet.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyPocket.MoneyBalance;
            }
        }

        /// <summary>
        /// Adds money to the wallet.
        /// </summary>
        /// <param name="amount"> The amount being added to the wallet.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyPocket.AddMoney(amount);
        }

        /// <summary>
        /// Removes the money from the wallet.
        /// </summary>
        /// <param name="amount"> The amount being removed from the wallet.</param>
        /// <returns> The amount removed from the wallet.</returns>
        public decimal RemoveMoney(decimal amount)
        {
            decimal amountRemoved = this.moneyPocket.RemoveMoney(amount);

            return amountRemoved;
        }
    }
}