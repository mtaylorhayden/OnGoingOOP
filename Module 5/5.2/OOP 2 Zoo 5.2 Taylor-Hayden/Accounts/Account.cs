

using MoneyCollectors;
using System;

namespace Accounts
{
    /// <summary>
    /// The class used to represent an Account.
    /// </summary>
    [Serializable]
    public class Account : IMoneyCollector
    {
        /// <summary>
        /// The money balanace for the account.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// The onBalanceChange field.
        /// </summary>
        private Action onBalanceChange;

        /// <summary>
        /// 
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
            set
            {
                if (OnBalanceChange != null)
                {
                    // Tried calling field instead of the property.
                    this.onBalanceChange();
                }
                this.moneyBalance = value;
            }
        }

        /// <summary>
        /// Gets or set the on balance change delegate.
        /// </summary>
        public Action OnBalanceChange
        {
            get
            {
                return this.onBalanceChange;
            }
            set
            {
                this.onBalanceChange = value;
            }
        }

        /// <summary>
        /// Adds money for the account.
        /// </summary>
        /// <param name="amount"></param>
        public void AddMoney(decimal amount)
        {
            this.MoneyBalance += amount;
        }

        /// <summary>
        /// Removes money from the account.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public decimal RemoveMoney(decimal amount)
        {
            this.MoneyBalance -= amount;
            return amount;
        }
    }
}
