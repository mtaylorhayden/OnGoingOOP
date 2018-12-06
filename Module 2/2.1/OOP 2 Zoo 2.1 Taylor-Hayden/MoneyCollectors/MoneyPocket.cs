using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyCollectors
{
    /// <summary>
    /// The class used to represent a MoneyPocket.
    /// </summary>
    public class MoneyPocket : MoneyCollector
    {
        /// <summary>
        /// Unfolds the money pocket.
        /// </summary>
        private void Unfold()
        {

        }

        /// <summary>
        /// Removes money from the money pocket.
        /// </summary>
        /// <param name="amount"> The amount being passed to the money pocket.</param>
        /// <returns> The amount being passed back.</returns>
        public override decimal RemoveMoney(decimal amount)
        {
            decimal moneyRemoved = base.RemoveMoney(amount);

            return moneyRemoved;
        }

        /// <summary>
        /// Folds the money pocket.
        /// </summary>
        private void Fold()
        {

        }
    }
}
