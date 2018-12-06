using MoneyCollectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConcessionItems;

namespace Stands
{
    /// <summary>
    /// The class used to represent a popcorn stand.
    /// </summary>
    public class PopcornStand : MoneyCollectingStand
    {
        /// <summary>
        /// 
        /// </summary>
        private decimal itemPrice;

        /// <summary>
        /// 
        /// </summary>
        private MoneyCollector moneyBox;

        /// <summary>
        /// Initializes a new instance of the popcorn stand class.
        /// </summary>
        /// <param name="itemPrice"> The price of the items.</param>
        /// <param name="moneyBox"> The box for money.</param>
        public PopcornStand(decimal itemPrice, IMoneyCollector moneyBox)
            : base(itemPrice, "popcorn", moneyBox)
        {
            base.moneyBox = moneyBox;
            this.itemPrice = itemPrice;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public Popcorn BuyPopcorn(decimal payment)
        {
            return null;
        }
    }
}
