using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    /// <summary>
    /// The class used to represent a money collector
    /// </summary>
    public class MoneyCollector : IMoneyCollector
    {
        /// <summary>
        /// The money balance.
        /// </summary>
        private decimal moneyBalance;

        /// <summary>
        /// Initializes a new instance of the MoneyCollector class.
        /// </summary>
        /// <param name="initialMoneyBalance"> How much money it starts with.</param>
        public MoneyCollector(decimal initialMoneyBalance)
        {
            this.moneyBalance = initialMoneyBalance;
        }

        /// <summary>
        /// Gets the amount of money from the money collector.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyBalance;
            }
        }

        /// <summary>
        /// Adds money to the money collector.
        /// </summary>
        /// <param name="amountToAdd"> The amount that will be added.</param>
        public void AddMoney(decimal amountToAdd)
        {
            this.moneyBalance += amountToAdd;
        }

        /// <summary>
        /// Removes money from the money collector.
        /// </summary>
        /// <param name="amountToRemove"> The amount that was removed.</param>
        /// <returns></returns>
        public decimal RemoveMoney(decimal amountToRemove)
        {
            decimal amountRemoved;

            if(this.MoneyBalance >= amountToRemove)
            {
                this.moneyBalance -= amountToRemove;

                amountRemoved = amountToRemove;

                return amountRemoved;
            }
            else
            {
                amountRemoved = this.moneyBalance - amountToRemove;

                return amountRemoved;
            }
        }
    }
}
