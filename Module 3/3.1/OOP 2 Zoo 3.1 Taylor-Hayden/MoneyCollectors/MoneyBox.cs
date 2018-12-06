using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    /// <summary>
    /// The class used to represent a moneybox.
    /// </summary>
    public class MoneyBox : MoneyCollector
    {
        /// <summary>
        /// Unlocks the money box.
        /// </summary>
        private void Unlock()
        {

        }

        /// <summary>
        /// Removes money from the money box.
        /// </summary>
        /// <param name="amount"> The amount that could be removed.</param>
        /// <returns> The amount being returned.</returns>
        public override decimal RemoveMoney(decimal amount)
        {
            decimal amountRemoved = base.RemoveMoney(amount);

            return amountRemoved;
        }

        /// <summary>
        /// Locks the money box.
        /// </summary>
        private void Lock()
        {

        }
    }
}
