using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionItems
{
    /// <summary>
    /// The abstract class for concession items.
    /// </summary>
    public abstract class ConcessionItem
    {
        /// <summary>
        /// The level of concession items.
        /// </summary>
        private double level;

        /// <summary>
        /// Gets and sets the level of the concession item.
        /// </summary>
        protected double Level
        {
            get
            {
                return this.level;
            }
            set
            {
                value = this.level;
            }
        }

        /// <summary>
        /// Consumes the concession item.
        /// </summary>
        public abstract void Consume();
    }
}
