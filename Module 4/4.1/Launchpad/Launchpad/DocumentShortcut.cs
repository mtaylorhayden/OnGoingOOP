using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Launchpad
{
    /// <summary>
    /// The class used to represent the document shortcut.
    /// </summary>
    public class DocumentShortcut: ApplicationShortcut
    {
        /// <summary>
        /// Gets or sets the arguments for the shortcut
        /// </summary>

        public string Arguments { get; set; }
    }
}
