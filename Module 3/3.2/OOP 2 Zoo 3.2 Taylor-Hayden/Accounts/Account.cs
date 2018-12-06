

using MoneyCollectors;

namespace Accounts
{
    /// <summary>
    /// The class used to represent an Account.
    /// </summary>
    public class Account : IMoneyCollector
    {
        /// <summary>
        /// The money balanace for the account.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// 
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
        }

        /// <summary>
        /// Adds money for the account.
        /// </summary>
        /// <param name="amount"></param>
        public void AddMoney(decimal amount)
        {
            this.moneyBalance += amount;
        }

        /// <summary>
        /// Removes money from the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal RemoveMoney(decimal amount)
        {
            this.moneyBalance -= amount;
            return amount;
        }
    }
}
