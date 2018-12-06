﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;
using Accounts;
using Animals;
using BoothItems;
using Microsoft.Win32;
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
        /// The file will always be saved as Autosave.zoo.
        /// </summary>
        private const string AutoSaveFileName = "Autosave.zoo";

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
        /// The button used to add an animal to the list box.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void addAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Get the selected animal type from the list box.
                AnimalType animalType = (AnimalType)this.animalTypeComboBox.SelectedItem;

                // Create an animal based on the type.  
                Animal animal = AnimalFactory.CreateAnimal(animalType, "Yoooo", 17, 71, Gender.Female);

                // Make a new window with the new animal.
                AnimalWindow animalWindow = new AnimalWindow(animal);

                // If the dialog box is shown then add the animal to the list and repopulate the screen with the updated list.
                if (animalWindow.ShowDialog() == true)
                {
                    zoo.AddAnimal(animal);

                    //PopulateAnimalListBox();
                }
                else
                {
                    // If the above code doesn't work, do nothing.
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You must choose an animal type before you can add an animal.");
            }
        }

        /// <summary>
        /// Adds the guest into the zoo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addGuestButton_Click(object sender, RoutedEventArgs e)
        {
            // Create an account for the guest.
            Account accout = new Account();

            // Create a sample guest for the window.
            Guest guest = new Guest("jimmyboiii", 34, 1738, WalletColor.Black, Gender.Male, accout);

            // Try selling a ticket to the guest, and adding the guest into the zoo.
            try
            {
                // Sell a ticket to the guest.
                Ticket ticket = zoo.SellTicket(guest);

                // Add the guest to the window.

                GuestWindow guestWindow = new GuestWindow(guest);

                // If the dialog is shown, add the guest to the zoo, and populate the list box.
                if (guestWindow.ShowDialog() == true)
                {
                    // Adds the guest to the zoo.
                    zoo.AddGuest(guest, ticket);

                    //PopulateGuestListBox();
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The button used to adopt an animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void adoptAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Gets the guest from the list box.
            Guest guest = (Guest)this.guestListBox.SelectedItem;

            // Gets the animal from the list box.
            Animal animal = (Animal)this.animalListBox.SelectedItem;

            // Set the animal to guest's adopted animal.
            guest.AdoptedAnimal = animal;

            // Find the animals cage.
            Cage animalCage = zoo.FindCage(animal.GetType());

            // Add the guest to the cage.
            animalCage.Add(guest);

            // Load the guest into the list box.
            //this.PopulateGuestListBox();
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

            //this.PopulateGuestListBox();
        }

        /// <summary>
        /// When you double click on the animal box you can change its attributes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void animalListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get the selected item and cast it as an animal.
            Animal animal = (Animal)animalListBox.SelectedItem;

            // If the animal is not null then create a new animal window.
            if (animal != null)
            {
                AnimalWindow animalWindow = new AnimalWindow(animal);

                // If the dialog box is shown, re-populate the animal list box.
                if (animalWindow.ShowDialog() == true)
                    if (animal.IsPregnant == true)
                    {
                        // Remove the animal from the zoo.
                        zoo.RemoveAnimal(animal);

                        // Add the animal back into the zoo. 
                        zoo.AddAnimal(animal);
                    }
                {
                    //PopulateAnimalListBox();
                }
            }
        }

        /// <summary>
        /// The method that attaches delegates.
        /// </summary>
        private void AttachDelegates()
        {
            // Plugs the OnBirthingRoomTemperatureChange into the HandleBirthingRoomTemperatureChange.
            this.zoo.onBirthingRoomTemperatureChange += this.HandleBirthingRoomTemperatureChange;

            // Plug the handleGuest methods into appropriate delegates.
            this.zoo.OnAddGuest += this.HandleGuestAdded;
            this.zoo.OnRemoveGuest += this.HandleGuestRemoved;

            // Plug the handleAnimal methods into the delegates.
            this.zoo.OnAddAnimal += this.HandleAnimalAdded;
            this.zoo.OnRemoveAnimal += this.HandleAnimalRemove;

            // Call must be made at the end of the method.
            this.zoo.OnDeserialized();
        }

        /// <summary>
        /// The button that births an aniaml.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void birthAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Births the baby.
            zoo.BirthAnimal();

            // Repopulates the animal list box.
            //PopulateAnimalListBox();
        }

        /// <summary>
        /// Changes the behavior of an animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeBehaviorButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the animal selected from the list box.
            Animal animal = (Animal)this.animalListBox.SelectedItem;

            // Gets the behavior selected from the combo box.
            MoveBehaviorType behavior = (MoveBehaviorType)this.changeBehaviorComboBox.SelectedItem;

            if (animal != null && behavior != null)
            {
                // Create an IMoveBehavior using the MoveBehaviorFactory. 
                IMoveBehavior newBehavior = MoveBehaviorFactory.CreateMoveBehavior(behavior);

                // Set the aniaml's behavior to the new behavior.
                animal.MoveBehavior = newBehavior;
            }
        }

        /// <summary>
        /// Clears the window.
        /// </summary>
        private void ClearWindow()
        {
            // Clears both list boxes
            // START HERE
            //animalListBox.Items.Clear();
            guestListBox.Items.Clear();

            //animalListBox.ItemsSource = null;
            //guestListBox.ItemsSource = null;
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
                this.zoo.BirthingRoomTemperature--;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You cannot decrease the temperature any further.");
            }
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

            if (guest != null && animal != null)
            {
                guest.FeedAnimal(animal, this.zoo.AnimalSnackMachine);

                //PopulateAnimalListBox();
                //PopulateGuestListBox();
            }
            else
            {
                MessageBox.Show("You must choose both a guest and an animal to feed an animal.");
            }
            guestListBox.SelectedItem = guest;
            animalListBox.SelectedItem = animal;
        }

        /// <summary>
        /// When you double click the combo box you can edit the attributes of the guest.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void guestListBox_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Get the selected item and cast it as a guest.
            Guest guest = (Guest)guestListBox.SelectedItem;

            // If guest isn't null then create a new guest window.
            if (guest != null)
            {
                GuestWindow guestWindow = new GuestWindow(guest);

                // If the guest window was created then re-populate the list box.
                if (guestWindow.ShowDialog() == true)
                {
                    //PopulateGuestListBox();
                }
            }
        }

        /// <summary>
        /// Changes the birthing room temperature.
        /// </summary>
        /// <param name="previousTemp"></param>
        /// <param name="currentTemp"></param>
        private void HandleBirthingRoomTemperatureChange(double previousTemp, double currentTemp)
        {
            // Make the temperature border height relative to the temperature of the birthing room.
            temperatureBorder.Height = this.zoo.BirthingRoomTemperature * 2;

            // Change the temperature label content relative to the temperature of the birthing room.
            temperatureLabel.Content = this.zoo.BirthingRoomTemperature;

            // temperatureLabel.Content = string.Format("{0:0.0}", this.zoo.BirthingRoomTemperature);

            // Displays the temperature.
            temperatureLabel.Content = $"{this.zoo.BirthingRoomTemperature.ToString("N1")} °F";

            // Changes the color of the temperature border.
            double colorLevel = ((this.zoo.BirthingRoomTemperature - BirthingRoom.MinTemperature) * 255) / (BirthingRoom.MaxTemperature - BirthingRoom.MinTemperature);

            this.temperatureBorder.Background = new SolidColorBrush(Color.FromRgb(
                Convert.ToByte(colorLevel),
                Convert.ToByte(255 - colorLevel),
                Convert.ToByte(255 - colorLevel)));
        }

        /// <summary>
        /// Adds the animal to the window.
        /// </summary>
        /// <param name="animal"> The animal being added.</param>
        private void HandleAnimalAdded(Animal animal)
        {
            this.animalListBox.Items.Add(animal);

            animal.OnTextChange += this.UpdateAnimalDisplay;
        }

        /// <summary>
        /// Removes the animal from the window.
        /// </summary>
        /// <param name="animal"> The animal being removed.</param>
        private void HandleAnimalRemove(Animal animal)
        {
            this.animalListBox.Items.Remove(animal);

            animal.OnTextChange += this.UpdateAnimalDisplay;
        }

        /// <summary>
        /// Adds the guest.
        /// </summary>
        /// <param name="guest"></param>
        private void HandleGuestAdded(Guest guest)
        {
            // Add the guest to the list box.
            this.guestListBox.Items.Add(guest);

            // Plug the updateGuestDisplay method into the delegate.
            guest.OnTextChange += this.UpdateGuestDisplay;
        }

        /// <summary>
        /// Removes the guest.
        /// </summary>
        /// <param name="guest"></param>
        private void HandleGuestRemoved(Guest guest)
        {
            // Remove the guest from the list box.
            this.guestListBox.Items.Remove(guest);

            // Unplug the updaetGuestDisplay method.
            guest.OnTextChange -= this.UpdateGuestDisplay;
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
                this.zoo.BirthingRoomTemperature++;
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("You cannot increase the temperature any further.");
            }
        }

        /// <summary>
        /// The button that loads the saved zoo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new OpenFileDialog item.
            OpenFileDialog openFile = new OpenFileDialog();

            // Set the dialog's filter to the following string.
            openFile.Filter = "Zoo save-game files (*.zoo)|*.zoo";

            // Show the dialog.
            openFile.ShowDialog();

            // If the dialog was opened.
            if (openFile.ShowDialog() == true)
            {
                // Clear the window and load the zoo.
                this.ClearWindow();
                this.LoadZoo(openFile.FileName);

                this.AttachDelegates();
            }
        }

        /// <summary>
        /// Loads the zoo.
        /// </summary>
        /// <param name="fileName"> The name of the file being loaded.</param>
        private bool LoadZoo(string fileName)
        {
            bool result = true;

            try
            {
                // Sets the current zoo to the loaded zoo.
                this.zoo = Zoo.LoadFromFile(fileName);

                // Set the window's title.
                this.SetWindowTitle(fileName);

                // Populate both list boxes.
                //this.PopulateAnimalListBox();

                result = false;
            }
            catch
            {
                MessageBox.Show("File could not be loaded.");
            }
            return result;
        }

        ///// <summary>
        ///// Populates the animal list box.
        ///// </summary>
        //private void PopulateAnimalListBox()
        //{
        //    animalListBox.ItemsSource = null;

        //    animalListBox.ItemsSource = zoo.Animals;
        //}

        /// <summary>
        /// The button used to remove the animal from the zoo.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void removeAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the animal from the list box and cast it as an animal.
            Animal animal = this.animalListBox.SelectedItem as Animal;

            // If the animal exists, ask the user if they are sure they want to remove it.
            if (animal != null)
            {
                if (MessageBox.Show(string.Format("Are you sure you want to remove animal: {0}?", animal.Name), "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes) ;

                zoo.RemoveAnimal(animal);

               // PopulateAnimalListBox();
            }
            else
            {
                MessageBox.Show("Please select an animal to remove.");
            }
        }

        /// <summary>
        /// The button used to remove the guest from the zoo.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void removeGuestButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the guest from the listbox and cast it as a guest.
            Guest guest = this.guestListBox.SelectedItem as Guest;

            // If the guest was selected, ask the user if they're sure they want to remove it.
            if (guest != null)
            {
                if (MessageBox.Show(string.Format("Are you sure you want to remove guest : {0}?", guest.Name), "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes) ;

                zoo.RemoveGuest(guest);

            }
            else
            {
                MessageBox.Show("Please select a guest to remove.");
            }
        }

        /// <summary>
        /// The button that restarts the zoo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void restartButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to start over?", "Confirmation", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                // Clear the window and load a new zoo.
                this.ClearWindow();
                this.zoo = Zoo.NewZoo();

                // Attaches the delegates.
                this.AttachDelegates();

                // Set the title of the window.
                this.SetWindowTitle(this.Title = "Object-Oriented Programming 2: Zoo");
            }
            else
            {
                MessageBox.Show("Zoo was not reset");
            }
        }

        /// <summary>
        /// The button that saves the zoo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new saveFileDialog object.
            SaveFileDialog saveFile = new SaveFileDialog();

            // Set the dialog's filter to the following string.
            saveFile.Filter = "Zoo save-game files (*.zoo)|*.zoo";

            // Show dialog.
            saveFile.ShowDialog();

            // If the result of showing the dialog is true...
            if (saveFile.ShowDialog() == true)
            {
                // Save the zoo and pass in the FileName property.
                this.SaveZoo(saveFile.FileName);
            }
        }

        /// <summary>
        /// Saves the zoo.
        /// </summary>
        /// <param name="fileName"> The name of the file the zoo will be saved as.</param>
        private void SaveZoo(string fileName)
        {
            // Saves using a binary formatter.
            this.zoo.SaveToFile(fileName);

            // Changes the name of the window.
            this.SetWindowTitle(fileName);
        }

        /// <summary>
        /// Sets the title of the window.
        /// </summary>
        /// <param name="fileName"></param>
        private void SetWindowTitle(string fileName)
        {
            // Set the title of the window using the current file name
            this.Title = string.Format("Object-Oriented Programming 2: Zoo [{0}]", Path.GetFileName(fileName));
        }

        /// <summary>
        /// Launches the cage window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void showCageButton_Click(object sender, RoutedEventArgs e)
        {
            // Gets the animal from the animal list box.
            Animal animal = (Animal)animalListBox.SelectedItem;

            // Find the cage based on the animal's type.
            Cage cage = zoo.FindCage(animal.GetType());

            // If an animal was selected, create a new cage window and put the animal in the cage.
            if (animal != null)
            {
                CageWindow cageWindow = new CageWindow(cage);


                cageWindow.Show();
                //if (cageWindow.ShowDialog() == true)
                //{
                //}
            }
            // Ask user to select an animal.
            else
            {
                MessageBox.Show("Please select an aniaml to put in the cage.");
            }
        }

        /// <summary>
        /// The button used to unadopt an animal.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void unadpotAnimalButton_Click(object sender, RoutedEventArgs e)
        {
            // Gets the selected guest from the guest list box.
            Guest guest = (Guest)this.guestListBox.SelectedItem;

            // Finds the cage of the guest's adopted animal's type.
            Cage animalCage = zoo.FindCage(guest.AdoptedAnimal.GetType());

            // Remove the guest from the cage.
            animalCage.Remove(guest);

            // Clear the guest's adopted animal.
            guest.AdoptedAnimal = null;
        }

        /// <summary>
        /// Updates the animals displays.
        /// </summary>
        /// <param name="animal"> The animal being changed.</param>
        private void UpdateAnimalDisplay(Animal animal)
        {
            int index = this.animalListBox.Items.IndexOf(animal);

            if (index >= 0)
            {   
                // disconnect the guest
                this.animalListBox.Items.RemoveAt(index);

                // create new guest item in the same spot 
                this.animalListBox.Items.Insert(index, animal);

                // re-select the guest 
                this.animalListBox.SelectedItem = this.animalListBox.Items[index];
            }
        }

        /// <summary>
        /// Updates the guest displays.
        /// </summary>
        /// <param name="guest"></param>
        private void UpdateGuestDisplay(Guest guest)
        {
            int index = this.guestListBox.Items.IndexOf(guest);

            if (index >= 0)
            {   
                // disconnect the guest
                this.guestListBox.Items.RemoveAt(index);

                // create new guest item in the same spot 
                this.guestListBox.Items.Insert(index, guest);

                // re-select the guest 
                this.guestListBox.SelectedItem = this.guestListBox.Items[index];
            }
        }

        /// <summary>
        /// Loads the zoo.
        /// </summary>
        /// <param name="sender"> Not available.</param>
        /// <param name="e"> The parameter is not used.</param>
        private void window_Loaded(object sender, RoutedEventArgs e)
        {
            // Load the zoo.
            bool result = this.LoadZoo(AutoSaveFileName);



            // if the result of that method is false call the zoo's NewZoo method.
            if (result == true)
            {
                // Makes a new zoo.
                this.zoo = Zoo.NewZoo();

                // Attaches the delegates.
                this.AttachDelegates();
            }

            // Starts the Temperature label off at the label.
            temperatureLabel.Content = $"{this.zoo.BirthingRoomTemperature.ToString("N1")} °F";

            // Set the temperature border height.
            temperatureBorder.Height = this.zoo.BirthingRoomTemperature * 2;

            // Populates the animal list box full of the list of animals.
            // this.PopulateAnimalListBox();

            // Populates the guest list box full of the list of guests.
            //this.PopulateGuestListBox();

            // Gets the type of animals for the animal type combo box.
            this.animalTypeComboBox.ItemsSource = Enum.GetValues(typeof(AnimalType));

            // Fill the combo box with the MoveBehaviorType collection's values.
            this.changeBehaviorComboBox.ItemsSource = Enum.GetValues(typeof(MoveBehaviorType));

            // Attaches the delegates.
            this.AttachDelegates();
        }

        /// <summary>
        /// When the window is closing save it.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Save the zoo under this file name.
            this.SaveZoo(AutoSaveFileName);
        }
    }
}
