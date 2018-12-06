using Foods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    /// <summary>
    /// Implenents the IEatBehavior interface.
    /// </summary>
    public interface IEatBehavior
    {
        /// <summary>
        /// The eating behavior for the eater.
        /// </summary>
        /// <param name="eater"> The item eating.</param>
        /// <param name="food"> The food being ate.</param>
        void Eat(IEater eater, Food food);
    }
}
