using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    /// <summary>
    /// The class used to represent the money collector.
    /// </summary>
    [Serializable]
    public abstract class MoneyCollector : IMoneyCollector
    {
        /// <summary>
        /// The current amount of money.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// 
        /// </summary>
        private Action onBalanceChange;

        /// <summary>
        /// Gets the current amount of money.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
            set
            {
                if (this.OnBalanceChange != null)
                {
                    this.OnBalanceChange();
                }
                    this.moneyBalance = value;
            }
        }

        /// <summary>
        /// Gets or sets the on balance change.
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
        /// Adds a specified amount of money to the wallet.
        /// </summary>
        /// <param name="amount">The amount of money to add.</param>
        public void AddMoney(decimal amount)
        {
            this.MoneyBalance += amount;
        }

        /// <summary>
        /// Removes a specified amount of money from the wallet.
        /// </summary>
        /// <param name="amount">The amount of money to remove.</param>
        /// <returns>The money that was removed.</returns>
        public virtual decimal RemoveMoney(decimal amount)
        {
            decimal amountRemoved;

            // If there is enough money in the wallet...
            if (this.MoneyBalance >= amount)
            {
                // Return the requested amount.
                amountRemoved = amount;
            }
            else
            {
                // Otherwise return all the money that is left.
                amountRemoved = this.MoneyBalance;
            }

            // Subtract the amount removed from the wallet's money balance.
            this.MoneyBalance -= amountRemoved;

            return amountRemoved;
        }
    }
}
