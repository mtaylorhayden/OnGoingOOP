using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    public interface IMoneyCollector
    {
        /// <summary>
        /// Gets the money balance.
        /// </summary>
        decimal MoneyBalance
        {
            get;
        }

        /// <summary>
        /// Adds money to the money collector.
        /// </summary>
        /// <param name="amount"> The amount that could be added.</param>
        void AddMoney(decimal amount);

        /// <summary>
        /// Removes money from the money collector.
        /// </summary>
        /// <param name="amount"></param>
        /// <returns> The amount removed.</returns>
        decimal RemoveMoney(decimal amount);
    }
}
