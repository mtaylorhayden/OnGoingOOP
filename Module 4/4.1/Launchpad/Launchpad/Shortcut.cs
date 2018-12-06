using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Launchpad
{
    /// <summary>
    /// The class used to represent the shortcuts.
    /// </summary>
    public abstract class Shortcut
    {
        /// <summary>
        /// Gets or sets the description of the shortcut.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the path of the shortcut.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets the type of shortcut.
        /// </summary>
        public ShortcutType Type { get; set; }

        /// <summary>
        /// How the shortcut will appear.
        /// </summary>
        /// <returns> The string set to display the shortcut.</returns>
        public string ToString()
        {
            return this.Description;
        }
    }
}
