using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    /// <summary>
    /// The interface for money collectors.
    /// </summary>
    public interface IMoneyCollector
    {
        decimal MoneyBalance
        {
            get;
        }

        /// <summary>
        /// Adds money to the money collector.
        /// </summary>
        /// <param name="amountToAdd"> The amount that will be added.</param>
        void AddMoney(decimal amountToAdd);

        /// <summary>
        /// Removes money from the money collector.
        /// </summary>
        /// <param name="amountToRemove"> Removes this amount.</param>
        /// <returns> The amount that was removed.</returns>
        decimal RemoveMoney(decimal amountToRemove);
    }
}
