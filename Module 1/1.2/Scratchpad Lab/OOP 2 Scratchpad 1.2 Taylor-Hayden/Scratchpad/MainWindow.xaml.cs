using System.Windows;
using Airports;

namespace Scratchpad
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The Dallas/Fort Worth Airport airport.
        /// </summary>
        private Airport dfw = new Airport();

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }
    }
}