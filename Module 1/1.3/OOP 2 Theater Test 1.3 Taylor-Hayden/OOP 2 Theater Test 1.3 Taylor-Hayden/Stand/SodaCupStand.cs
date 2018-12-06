using ConcessionItems;
using MoneyCollectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stands
{

    /// <summary>
    /// The class used to represent a soda cup stand
    /// </summary>
    public class SodaCupStand : MoneyCollectingStand
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
        /// 
        /// </summary>
        /// <param name="itemPrice"></param>
        /// <param name="moneyBox"></param>
        public SodaCupStand(decimal itemPrice, IMoneyCollector moneyBox)
            : base(itemPrice, "soda", moneyBox)
        {
            this.itemPrice = itemPrice;
            this.moneyBox = new MoneyCollector(this.MoneyBalance);
        }


        /// <summary>
        /// Buys a soda cup.
        /// </summary>
        /// <param name="payment"> The payment for the soda cup.</param>
        /// <returns></returns>
        public SodaCup BuySodaCup(decimal payment)
        {
            SodaCup soda = new SodaCup();

            return soda;
        }
    }
}
