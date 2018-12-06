using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionItems
{
    /// <summary>
    /// The class used to represent popcorn.
    /// </summary>
    public class Popcorn : ConcessionItem
    {
        /// <summary>
        /// Says if the popcorn is buttered.
        /// </summary>
        private bool isButtered;

        /// <summary>
        /// The level of salt.
        /// </summary>
        private int saltLevel;

        /// <summary>
        /// Initializes a new instance of the popcorn class.
        /// </summary>
        public Popcorn()
        {
            this.Level = 100;


        }

        /// <summary>
        /// Gets the isButtered field.
        /// </summary>
        public bool IsButtered
        {
            get
            {
                return this.isButtered;
            }
        }

        /// <summary>
        /// Gets the is salted value for the popcorn.
        /// </summary>
        public bool IsSalted
        {
            get
            {
                if(this.saltLevel > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Gets the saltlevel of the popcorn.
        /// </summary>
        public int SaltLevel
        {
            get
            {
                return this.saltLevel;
            }
        }

        /// <summary>
        /// Adds butter to the popcorn.
        /// </summary>
        public void AddButter()
        {
            this.isButtered = true;
        }

        /// <summary>
        /// Adds salt to the popcorn.
        /// </summary>
        public void AddSalt()
        {
            // Increment level by 1.
            this.saltLevel++;
        }

        /// <summary>
        /// Consumes the popcorn.
        /// </summary>
        public override void Consume()
        {
            // Decrease level by 10.
            this.Level -= 10;
        }
    }
}
