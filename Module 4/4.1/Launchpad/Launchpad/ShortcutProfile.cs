using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Launchpad
{
    /// <summary>
    /// 
    /// </summary>
    [XmlInclude(typeof(ApplicationShortcut))]
    [XmlInclude(typeof(WebsiteShortcut))]
    [XmlInclude(typeof(DocumentShortcut))]
    [XmlInclude(typeof(FolderShortcut))]
    public class ShortcutProfile
    {
        /// <summary>
        /// The list of shortcuts.
        /// </summary>
        private List<Shortcut> shortcuts = new List<Shortcut>();
        //{
        //    new DocumentShortcut { Description = "Notepad", Path = "notepad.exe", Type = ShortcutType.Document},
        //    new FolderShortcut { Description = "Spotify", Path = @"C:\Users\nebra\AppData\Roaming\Spotify", Type = ShortcutType.Folder},
        //    new WebsiteShortcut { Description = "Canvas", Path = @"https://canvas.ntc.edu", Type = ShortcutType.Website},
        //    new FolderShortcut { Description = "Test", Path = @"C:\Test", Type = ShortcutType.Folder},
        //    new WebsiteShortcut { Description = "Google", Path = @"https://google.com", Type = ShortcutType.Website},
        //    new FolderShortcut { Description = "Notepad++", Path = @"C:\Program Files (x86)\Notepad++", Type = ShortcutType.Folder}
        //};

        /// <summary>
        /// Gets the shortcuts.
        /// </summary>
        public List<Shortcut> Shortcuts
        {
            get
            {
                return this.shortcuts;
            }
        }
    }
}
