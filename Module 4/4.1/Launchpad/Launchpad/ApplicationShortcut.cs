using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Launchpad
{
    /// <summary>
    /// Shortcuts for the applications.
    /// </summary>
    public class ApplicationShortcut : Shortcut
    {
        /// <summary>
        /// The folder for the application.
        /// </summary>
        public string WorkingFolder { get; set; }
    }
}
