using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Launchpad
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The shortcut profile.
        /// </summary>
        private ShortcutProfile shortcutProfile;

        /// <summary>
        /// The main window.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            // Instantiate a new shortcutProfile.
            this.shortcutProfile = new ShortcutProfile();
        }

        /// <summary>
        /// Populate the list box.
        /// </summary>
        private void PopulateListBox()
        {
            this.shortcutsListBox.ItemsSource = this.shortcutProfile.Shortcuts;
        }

        /// <summary>
        /// When the list box is double clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void shortcutsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get the selected item and cast it as a shortcut.
            Shortcut newShortcut = this.shortcutsListBox.SelectedItem as Shortcut;

            Process process = new Process();
            process.StartInfo.FileName = newShortcut.Path;

            if (newShortcut is DocumentShortcut)
            {
                process.StartInfo.Arguments = (newShortcut as DocumentShortcut).Arguments;

            }
            else if (newShortcut is ApplicationShortcut)
            {
                process.StartInfo.UseShellExecute = true;
                process.StartInfo.WorkingDirectory = (newShortcut as ApplicationShortcut).WorkingFolder;
            }
            try
            {
                process.Start();
            }
            catch
            {
                MessageBox.Show("Could not launch the process.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ///// <summary>
        ///// When you click the save button.
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void saveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    // Create an xml serializer.
        //    XmlSerializer formatter = new XmlSerializer(shortcutProfile.GetType());

        //    using (Stream stream = File.Create(@"C:\Users\nebra\Dropbox\Semester 3\OOP 2\OOP\Module 4\4.1\Launchpad\Launchpad\Launchpad.xml"))
        //    {
        //        formatter.Serialize(stream, shortcutProfile);
        //    } 
        //}

        /// <summary>
        /// When the window loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (Stream stream = File.OpenRead(@"C:\Users\nebra\Dropbox\Semester 3\OOP 2\OOP\Module 4\4.1\Launchpad\Launchpad\Launchpad.xml"))
            {
                this.shortcutProfile = new XmlSerializer(typeof(ShortcutProfile)).Deserialize(stream) as ShortcutProfile;
            }

            // Make the list box populated when the window is loaded.
            // Items don't appear with a name or determine which shortcut is which?
            this.PopulateListBox();
        }
    }
}
