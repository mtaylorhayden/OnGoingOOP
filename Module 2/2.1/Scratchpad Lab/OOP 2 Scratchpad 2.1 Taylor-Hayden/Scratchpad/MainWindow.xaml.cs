using System.Windows;
using Airports;
using People;

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

            this.peopleListBox.ItemsSource = this.dfw.People;

            this.dfw.AddPerson(11, "Suzi");

            this.dfw.AddPerson(23, "Sam");

        }


        private void addPersonButton_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();

            Window window = new PersonWindow(person);

            if (window.ShowDialog() == true)
            {

                this.dfw.AddPerson(person);

                this.peopleListBox.ItemsSource = null;

                this.peopleListBox.ItemsSource = this.dfw.People;
            }
        }
    }
}