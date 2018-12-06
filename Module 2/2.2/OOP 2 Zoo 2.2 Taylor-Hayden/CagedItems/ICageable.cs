using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace CagedItems
{
    /// <summary>
    /// The interface used to make other objects cageable.
    /// </summary>
    public interface ICageable
    {
        /// <summary>
        /// Gets the display size for the cageable object. 
        /// </summary>
        double DisplaySize
        {
            get;
        }

        /// <summary>
        /// Gets the resource key for the cages.
        /// </summary>
        string ResourceKey
        {
            get;
        }

        /// <summary>
        /// The left/right position for the object.
        /// </summary>
        int XPosition
        {
            get;
        }

        /// <summary>
        /// The up/down/ position for the object.
        /// </summary>
        int YPosition
        {
            get;
        }

        /// <summary>
        /// The direction on the x axsis.
        /// </summary>
        HorizontalDirection XDirection
        {
            get;
        }

        /// <summary>
        /// The direction on the y axsis.
        /// </summary>
        VerticalDirection YDirection
        {
            get;
        }
    }
}
