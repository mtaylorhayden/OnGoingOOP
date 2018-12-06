using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcessionItems
{
    /// <summary>
    /// The class used to represent a soda cup.
    /// </summary>
    public class SodaCup : ConcessionItem
    {
        /// <summary>
        /// The flavor of the soda.
        /// </summary>
        private string flavor;

        /// <summary>
        /// Fills the cup of soda.
        /// </summary>
        /// <param name="flavor"> The flavor of the soda.</param>
        public void Fill(string flavor)
        {
            // Set the soda level to 100.
            this.Level = 100;

            // Set the flavor of the soda to the passed in flavor.
            this.flavor = flavor;
        }

        /// <summary>
        /// Consumes the soda.
        /// </summary>
        public override void Consume()
        {
            // Decrease the soda's level by 10.
            this.Level -= 10;
        }
    }
}
