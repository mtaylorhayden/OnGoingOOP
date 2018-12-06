using System;
using System.Windows;
using System.Windows.Media;
using Accounts;
using Animals;
using People;
using Zoos;

namespace ZooScenario
{
    /// <summary>
    /// Contains interaction logic for MainWindow.xaml.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.StyleCop.CSharp.NamingRules", "SA1300:ElementMustBeginWithUpperCaseLetter", Justification = "Event handlers may begin with lower-case letters.")]
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Minnesota's Como Zoo.
        /// </summary>
        private Zoo zoo;

        /// <summary>
        /// Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();

            // Compiler Directive.
#if DEBUG
            this.Title += "[DEBUG]";
#endif
        }

        /// <summary>
        /// The button to admit the guest.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void admitGuestButton_Click(object sender, RoutedEventArgs e)
        {
            Account account = new Account();

            // Create a guest.
            Guest guest = new Guest("Ethel", 42, 30, WalletColor.Salmon, Gender.Female, account);

            // Sell the ticket to the guest.
            BoothItems.Ticket ticket = this.zoo.SellTicket(guest);

            try
            {
                this.zoo.AddGuest(guest, ticket);
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.PopulateGuestListBox();
        }

        /// <summary>
        /// The button to feed the animal.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void feedAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Greg feeds the ostrich.
            //Guest greg = this.zoo.FindGuest("Greg");
            //Animal ostrich = this.zoo.FindAnimal(typeof(Ostrich));

            Guest guest = (Guest)this.guestListBox.SelectedItem;

            Animal animal = (Animal)this.animalListBox.SelectedItem;

            if(guest != null && animal != null)
            {
                guest.FeedAnimal(animal, this.zoo.AnimalSnackMachine);

                PopulateAnimalListBox();
                PopulateGuestListBox();
            }
            else
            {
                MessageBox.Show("You must choose botha guest and an animal to feed an animal.");
            }
            guestListBox.SelectedItem = guest;
            animalListBox.SelectedItem = animal;
        }

        /// <summary>
        /// Controls the birthing room temperatures.
        /// </summary>
        /// <param name="increase"> The number the temp will increase.</param>
        private void ConfigureBirthingRoomControls(int increase)
        {
            {
                // Increase the birthing room temperature.
                this.zoo.BirthingRoomTemperature += increase;

                // Make the temperature border height relative to the temperature of the birthing room.
                temperatureBorder.Height = this.zoo.BirthingRoomTemperature * 2;

                // Change the temperature label content relative to the temperature of the birthing room.
                temperatureLabel.Content = this.zoo.BirthingRoomTemperature;

                // temperatureLabel.Content = string.Format("{0:0.0}", this.zoo.BirthingRoomTemperature);

                // Displays the temperature.
                temperatureLabel.Content = $"{this.zoo.BirthingRoomTemperature.ToString("N1")} °F";

                // The temperature label now contains the ° symbol.
                // temperatureLabel.Content += " °F";

                // Changes the color of the temperature border.
                double colorLevel = ((this.zoo.BirthingRoomTemperature - BirthingRoom.MinTemperature) * 255) / (BirthingRoom.MaxTemperature - BirthingRoom.MinTemperature);

                this.temperatureBorder.Background = new SolidColorBrush(Color.FromRgb(
                    Convert.ToByte(colorLevel),
                    Convert.ToByte(255 - colorLevel),
                    Convert.ToByte(255 - colorLevel)));
            }
        }

        /// <summary>
        /// Populates the animal list box.
        /// </summary>
        private void PopulateAnimalListBox()
        {
            animalListBox.ItemsSource = null;

            animalListBox.ItemsSource = zoo.Animals;
        }

        /// <summary>
        /// Populates the guest box.
        /// </summary>
        private void PopulateGuestListBox()
        {
            guestListBox.ItemsSource = null;

            guestListBox.ItemsSource = zoo.Guests;
        }

        /// <summary>
        /// The button to decrease the temperature.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void decreaseTemperature_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ConfigureBirthingRoomControls(-1);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You cannot decrease the temperature any further.");                
            }
        }

        /// <summary>
        /// The button to increase the temperature.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void increaseTemperature_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.ConfigureBirthingRoomControls(1);
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You cannot increase the temperature any further.");
            }
        }

        /// <summary>
        /// Loads the zoo.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            this.zoo = Zoo.NewZoo();

            // Set the temperature border height.
            temperatureBorder.Height = this.zoo.BirthingRoomTemperature * 2;

            this.PopulateAnimalListBox();

            this.PopulateGuestListBox();
        }
    }
}