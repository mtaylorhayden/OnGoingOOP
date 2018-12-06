using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stands
{
    /// <summary>
    /// The base class used to represent a stand.
    /// </summary>
    public class Stand
    {
        /// <summary>
        /// The number of items sold.
        /// </summary>
        private int itemCountSold;

        /// <summary>
        /// The type of item.
        /// </summary>
        private string itemType;

        /// <summary>
        /// Initiliazes a new instance of the stand class.
        /// </summary>
        /// <param name="itemType"> The type of item for the stand.</param>
        public Stand(string itemtype)
        {
            this.itemType = itemtype;
        }

        /// <summary>
        /// Gets the amount of items sold.
        /// </summary>
        public int ItemCountSold
        {
            get
            {
                return this.itemCountSold;
            }
        }

        /// <summary>
        /// Gets the type of the item.
        /// </summary>
        public string ItemType
        {
            get
            {
                return this.itemType;
            }
        }
    }
}
