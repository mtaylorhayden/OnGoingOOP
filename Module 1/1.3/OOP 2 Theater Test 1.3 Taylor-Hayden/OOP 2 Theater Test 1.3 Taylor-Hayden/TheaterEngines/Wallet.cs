using MoneyCollectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TheaterEngine
{
    /// <summary>
    /// The class used to represent a wallet.
    /// </summary>
    public class Wallet
    {
        /// <summary>
        /// 
        /// </summary>
        private IMoneyCollector moneyPocket;

        /// <summary>
        /// 
        /// </summary>
        private string color;

        /// <summary>
        /// 
        /// </summary>
        public Wallet(string color, decimal moneyBalance)
        {
            this.color = color;
            this.moneyPocket = new MoneyCollector(moneyBalance);
            // moneyBalance = this.MoneyBalance;
        }

        /// <summary>
        /// The color of the wallet. 
        /// </summary>
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                value = this.color;
            }
        }

        /// <summary>
        /// The wallets money balance.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyPocket.MoneyBalance;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="amountToAdd"></param>
        public void AddMoney(decimal amountToAdd)
        {
            this.moneyPocket.AddMoney(amountToAdd);
        }

        /// <summary>
        /// The money being removed.
        /// </summary>
        /// <param name="amountToRemove"> The amount trying to be removed.</param>
        /// <returns> The amount that was removed. </returns>
        public decimal RemoveMoney(decimal amountToRemove)
        {
            decimal moneyRemoved = this.moneyPocket.RemoveMoney(amountToRemove);

            return moneyRemoved;
        }

    }
}
