using System.Windows;
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

            // Create Dolly.
            animal = new Dingo("Dolly", 4, 35.3);

            // Make Dolly pregnant.
            animal.MakePregnant();

            // Add Dolly to the zoo's animal list.
            this.comoZoo.AddAnimal(animal);

            // Create Dixie.
            animal = new Dingo("Dixie", 3, 33.8);

            // Make Dixie pregnant.
            animal.MakePregnant();

            // Add Dixie to the zoo's animal list.
            this.comoZoo.AddAnimal(animal);

            // Create Patty.
            animal = new Platypus("Patty", 2, 15.5);

            // Make Patty pregnant.
            animal.MakePregnant();

            // Add Patty to the zoo's animal list.
            this.comoZoo.AddAnimal(animal);

            // Create Harold.
            animal = new Hummingbird("Harold", 1, 0.5);

            // Add Harold to the zoo's animal list.
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

            // Add the guest using the ticket.
            this.comoZoo.AddGuest(guest, ticket);
        }
    }
}