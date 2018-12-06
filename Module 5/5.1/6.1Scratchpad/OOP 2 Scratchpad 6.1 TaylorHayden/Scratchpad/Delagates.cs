using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratchpad
{
    /// <summary>
    /// Defines a custom area delegate type for calculating.
    /// </summary>
    /// <param name="radius"> The radius of the circle.</param>
    /// <returns> The area of the circle.</returns>
    public delegate double CalculateAreaDelegate(int radius);
}
