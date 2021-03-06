﻿using MoneyCollectors;
using System;

namespace People
{
    /// <summary>
    /// The class which is used to represent a wallet.
    /// </summary>
    [Serializable]
    public class Wallet : IMoneyCollector
    {
        /// <summary>
        /// the money collector for the wallet.
        /// </summary>
        private IMoneyCollector moneyPocket;

        /// <summary>
        /// The wallets delegate.
        /// </summary>
        private Action onBalanceChange;

        /// <summary>
        /// The color of the wallet.
        /// </summary>
        private WalletColor walletColor;

        /// <summary>
        /// Initializes a new instance of the Wallet class.
        /// </summary>
        /// <param name="color">The color of the wallet.</param>
        public Wallet(WalletColor color)
        {
            this.moneyPocket = new MoneyPocket();

            // Plug the handleBalanceChange method into the OnBalanceChange.
            this.moneyPocket.OnBalanceChange += this.HandleBalanceChange;
        }

        /// <summary>
        /// Gets the money balance for the wallet.
        /// </summary>
        public decimal MoneyBalance
        {
            get
            {
                return this.moneyPocket.MoneyBalance;
            }
            set
            {
                this.moneyPocket.MoneyBalance = value;
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
        /// 
        /// </summary>
        private void HandleBalanceChange()
        {
            // Call the wallet's delegate.
            this.onBalanceChange();
        }

        /// <summary>
        /// Gets and sets the color for the wallet.
        /// </summary>
        public WalletColor WalletColor
        {
            get
            {
                return this.walletColor;
            }
            set
            {
                this.walletColor = value;
            }
        }

        /// <summary>
        /// Adds money to the wallet.
        /// </summary>
        /// <param name="amount"> The amount being added to the wallet.</param>
        public void AddMoney(decimal amount)
        {
            this.moneyPocket.AddMoney(amount);
        }

        /// <summary>
        /// Removes the money from the wallet.
        /// </summary>
        /// <param name="amount"> The amount being removed from the wallet.</param>
        /// <returns> The amount removed from the wallet.</returns>
        public decimal RemoveMoney(decimal amount)
        {
            decimal amountRemoved = this.moneyPocket.RemoveMoney(amount);

            return amountRemoved;
        }
    }
}