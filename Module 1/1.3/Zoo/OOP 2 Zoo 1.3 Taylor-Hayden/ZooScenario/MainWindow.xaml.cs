using System.Windows;
using System.Windows.Controls;
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
        private Zoo comoZoo;

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

            this.CreateComoZoo();
        }

        /// <summary>
        /// Creates an instance of the zoo class and configures it as the Como Zoo.
        /// </summary>
        private void CreateComoZoo()
        {
            // Create an instance of the Zoo class.
            this.comoZoo = new Zoo("Como Zoo", 1000, 4, 0.75m, 15.00m, 3640.25m, new Employee("Sam", 42), new Employee("Flora", 98), 3);

            // Add money to the animal snack machine.
            this.comoZoo.AnimalSnackMachine.AddMoney(42.75m);

            // Define an animal variable.
            Animal animal;

            // Create a new Dingo and add him to the list of animals.
            animal = new Dingo("Dolly", 4, 35.3);

            animal.MakePregnant();

            this.comoZoo.AddAnimal(animal);

            // Create a new Dingo and add him to the list of animals.
            animal = new Dingo("Dixie", 3, 33.8);

            animal.MakePregnant();

            this.comoZoo.AddAnimal(animal);

            // Create a new platypus and add him to the list of animals.
            animal = new Platypus("Patty", 2, 15.5);

            animal.MakePregnant();

            this.comoZoo.AddAnimal(animal);

            // Create a new Hummingbird and add him to the list of animals.
            animal = new Hummingbird("Harold", 1, 0.5);

            this.comoZoo.AddAnimal(animal);

            // Create a new chimp and add him to the list of animals.
            animal = new Chimpanzee("Noah", 12, 500);

            this.comoZoo.AddAnimal(animal);

            // Create a new eagle and add him to the list of animals.
            animal = new Eagle("Tracy", 300, 10);

            this.comoZoo.AddAnimal(animal);

            // Create a new kangaroo and add him to the list of animals.
            animal = new Kangaroo("Jeff", 25, 30);

            this.comoZoo.AddAnimal(animal);

            // Create a new ostrich and add him to the list of animals.
            animal = new Ostrich("Jake", 40, 200);

            this.comoZoo.AddAnimal(animal);

            // Create a new shark and add him to the list of animals.
            animal = new Shark("Max", 23, 185);

            this.comoZoo.AddAnimal(animal);

            // Create a new squirrel and them to the list.
            animal = new Squirrel("Matt", 21, 200);

            this.comoZoo.AddAnimal(animal);

            // Create a guest.
            Guest guest = new Guest("Greg", 44, 150.35m, "Brown");

            // Add the guest and sell the ticket to the guest.
            this.comoZoo.AddGuest(guest, this.comoZoo.SellTicket(guest));

            // Create a guest.
            guest = new Guest("Darla", 11, 25.25m, "Salmon");

            // Add the guest and sell the ticket to the guest.
            this.comoZoo.AddGuest(guest, this.comoZoo.SellTicket(guest));
        }

        /// <summary>
        /// The button to admit the guest.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void admitGuestButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a guest.
            Guest guest = new Guest("Ethel", 42, 30, "Salmon");

            // Sell the ticket to the guest.
            BoothItems.Ticket ticket = this.comoZoo.SellTicket(guest);
        }

        /// <summary>
        /// The button to feed the animal.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void feedAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Greg feeds the ostrich.
            Guest greg = this.comoZoo.FindGuest("Greg");
            Animal ostrich = this.comoZoo.FindAnimal(typeof(Ostrich));

            greg.FeedAnimal(ostrich, this.comoZoo.AnimalSnackMachine);
        }

        /// <summary>
        /// The button to increase the temperature field of the birthing room.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void increaseTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            this.comoZoo.BirthingRoomTemperature++;

            temperatureBorder.Height = this.comoZoo.BirthingRoomTemperature * 2;

            temperatureLabel.Content = this.comoZoo.BirthingRoomTemperature;
        }

        /// <summary>
        /// The button to decrease the temperature field of the birthing room.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void decreaseTemperatureButton_Click(object sender, RoutedEventArgs e)
        {
            this.comoZoo.BirthingRoomTemperature--;

            temperatureBorder.Height = this.comoZoo.BirthingRoomTemperature * 2;

            temperatureLabel.Content = this.comoZoo.BirthingRoomTemperature;
        }
    }
}