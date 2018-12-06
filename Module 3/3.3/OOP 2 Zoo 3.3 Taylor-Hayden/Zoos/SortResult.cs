using Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoos
{
    /// <summary>
    /// The class used to represent the SortResult class.
    /// </summary>
    public class SortResult
    {
        /// <summary>
        /// Gets or sets the list of aniamls.
        /// </summary>
        public List<Animal> Animals { get; set; }

        /// <summary>
        /// Gets or sets the compare count.
        /// </summary>
        public int CompareCount { get; set; }

        /// <summary>
        /// Gets or sets the millisecond count.
        /// </summary>
        public double ElapsedMilliseconds { get; set; }

        /// <summary>
        /// Gets or sets the swap count.
        /// </summary>
        public int SwapCount { get; set; }
    }
}
