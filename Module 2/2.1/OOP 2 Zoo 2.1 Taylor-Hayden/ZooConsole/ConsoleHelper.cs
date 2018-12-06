using Accounts;
using Animals;
using People;
using System;
using Zoos;

namespace ZooConsole
{
    /// <summary>
    /// The class used to represent the console helper.
    /// </summary>
    internal static class ConsoleHelper
    {
        /// <summary>
        /// Processes the ADD command.
        /// </summary>
        /// <param name="zoo"> The zoo for the command.</param>
        /// <param name="type"> The type for the add command.</param>
        public static void ProcessAddCommand(Zoo zoo, string type)
        {
            switch (type)
            {
                // If the second command word was animal then...
                case "animal":

                    AddAnimal(zoo);

                    break;
                
                // If the second command word is guest then add the guest to the zoo.
                case "guest":

                    AddGuest(zoo);

                        break;

                    // The default of the process add command.
                    default:
                    throw new Exception("Sorry but this command only supports adding animals or guests.");
            }
        }

        /// <summary>
        /// Show the commands of the console.
        /// </summary>
        /// <param name="zoo"> The zoo being processed.</param>
        /// <param name="type"> The type being processed.</param>
        /// <param name="name"> The name being processed.</param>
        public static void ProcessShowCommand(Zoo zoo, string type, string name)
        {
            ConsoleUtil.InitialUpper(name);

            switch (type)
            {
                case "animal":
                    ShowAnimal(zoo, name);

                    break;

                case "guest":
                    ShowGuest(zoo, name);

                    break;

                default:
                    throw new Exception($"Sorry, but {type} is not a type, Only animals and guests can be shown.");
            }
        }

        /// <summary>
        /// Sets the temperature of the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo that's temperature will be set.</param>
        /// <param name="temperature"> The temperature that will be set to the zoo's temperature.</param>
        public static void SetTemperature(Zoo zoo, string temperature)
        {
            try
            {
                // If the zoo's temperature is between the max and min temp then...
                if (zoo.BirthingRoomTemperature <= BirthingRoom.MaxTemperature && zoo.BirthingRoomTemperature >= BirthingRoom.MinTemperature)
                {
                    // Show the previous temperature of the birthing room.
                    Console.WriteLine($"Previous Temperature : {temperature}");

                    // The new temperature.
                    double newTemperature = zoo.BirthingRoomTemperature;

                    // Show the new temperature of the birthing room.
                    Console.WriteLine($"New Temperature : {newTemperature}");
                }
                else
                {
                    // Warning message.
                    Console.WriteLine("The birthing room temperature must be between 35 and 95 degrees.");
                }
            }
            // Catch the exceptions.
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException)
            {
                Console.WriteLine("A number must be submitted in order to change the temperature.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Please enter a number to change the temperature");
            }
        }

        /// <summary>
        /// Adds the animal.
        /// </summary>
        /// <param name="zoo"> The zoo being added.</param>
        private static void AddAnimal(Zoo zoo)
        {
            // Creates a dingo with all of the inputted values.
            Animal animal = new Dingo("Joey", 43, 344, Gender.Male);

            bool success = false;

            AnimalType animalType = ConsoleUtil.ReadAnimalType();

            animal = AnimalFactory.CreateAnimal(animalType, "null", 1, 1, Gender.Male);

            // Sets the name for the animal.
            while (!success)
            {

                try
                {
                    // Gets the name and makes it upper case. 

                    animal.Name = ConsoleUtil.ReadAlphabeticValue("Name");
                    animal.Name = ConsoleUtil.InitialUpper(animal.Name);

                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Value must only contain letters and spaces.");
                }
            }

            success = false;

            // Sets the gender for the animal.
            while (!success)
            {
                try
                {
                    animal.Gender = ConsoleUtil.ReadGender();

                    success = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            success = false;

            // Sets the age for the animal.
            while (!success)
            {
                try
                {
                    animal.Age = ConsoleUtil.ReadIntValue("Age");

                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Value must be between 0 and 100.");

                }
            }

            success = false;

            // Sets the weight for the animal.
            while (!success)
            {
                try
                {
                    animal.Weight = ConsoleUtil.ReadDoubleValue("Weight");

                    success = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Value must be between 0 and 1000.");
                }
            }

            zoo.AddAnimal(animal);

            ShowAnimal(zoo, animal.Name);
        }

        /// <summary>
        /// Adds the guest into the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo that will have the guest.</param>
        public static void AddGuest(Zoo zoo)
        {
            Account account = new Account();

            Wallet wallet = new Wallet(WalletColor.Black);

            Guest guest = new Guest("Bro", 455, 0m, WalletColor.Black, Gender.Female, account);

            bool success = false;

            // Sets the name for the guest.
            while (!success)
            {
                try
                {
                    // Gets the name and makes it upper case. 
                    guest.Name = ConsoleUtil.ReadAlphabeticValue("Name");
                    guest.Name = ConsoleUtil.InitialUpper(guest.Name);

                    success = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            success = false;

            // Sets the gender for the guest.
            while (!success)
            {
                try
                {
                    guest.Gender = ConsoleUtil.ReadGender();

                    success = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            success = false;

            // Sets the age for the guest.
            while (!success)
            {
                try
                {
                    guest.Age = ConsoleUtil.ReadIntValue("Age");

                    success = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            success = false;

            // Sets the wallets money balance for the guest.
            while (!success)
            {
                try
                {
                    // Cast double into a decimal.
                    decimal amount = (decimal)ConsoleUtil.ReadDoubleValue("amount");

                    // Add the value inot the wallet.
                    guest.Wallet.AddMoney(amount);

                    success = true; 
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            success = false;

            // Sets the wallets color for the guest.
            while (!success)
            {
                try
                {
                    wallet.WalletColor = ConsoleUtil.ReadWalletColor();

                    success = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            success = false;

            // Sets the account's money balance for the guest.
            while (!success)
            {
                try
                {
                    // Cast double into a decimal.
                    decimal checking = (decimal)ConsoleUtil.ReadDoubleValue("checking");

                    // Add the value inot the wallet.
                    guest.CheckingAccount.AddMoney(checking);

                    success = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }

            // Sells the guest a ticket if they have enough money, then adds them to the zoo.
            zoo.AddGuest(guest, zoo.SellTicket(guest));

            // Shows the guest on the screen.
            ShowGuest(zoo, guest.Name);
        }

        /// <summary>
        /// Does the remove command.
        /// </summary>
        /// <param name="zoo"> The zoo from which the animal will be removed from.</param>
        /// <param name="type"> The type of animal being removed.</param>
        /// <param name="name"> The name of the animal being removed.</param>
        public static void ProcessRemoveCommand(Zoo zoo, string type, string name)
        {
            switch (type)
            {
                // If the type is animal...
                case "animal":

                    // Capitalizes the first letter of the name variable. 
                    string upperName = ConsoleUtil.InitialUpper(name);

                    // Removes the animal from the zoo based on their name.
                    RemoveAnimal(zoo, upperName);

                    break;

                // If the type is guest...
                case "guest":

                    // Capitalizes the first letter of the name variable.
                    string upperGuest = ConsoleUtil.InitialUpper(name);

                    // Removes the guest from the zoo based on their name.
                    RemoveGuest(zoo, upperGuest);

                    break;
                
                // Otherwise display error.
                default:

                    Console.WriteLine("This command only supoorts removing animals.");

                    break;
            }
        }

        /// <summary>
        /// Removes the animal from the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo from which the animal will be removed from.</param>
        /// <param name="type"> The type of animal being removed.</param>
        private static void RemoveAnimal(Zoo zoo, string name)
        {
            // Find the animal based on the entered name.
            Animal foundAnimal = zoo.FindAnimal(name);
            
            // If the animal was found, remove the animal, and display verification message.
            if(foundAnimal != null)
            {
                zoo.RemoveAnimal(foundAnimal);

                Console.WriteLine("The animal was removed from the zoo.");

                
            }
            // If the animal wasn't found, display error message.
            else
            {
                Console.WriteLine("Animal could not be found.");
            }
        }

        /// <summary>
        /// Removes the guest from the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo from which the guest will be removed from.</param>
        /// <param name="name"> The name of the guest being removed.</param>
        private static void RemoveGuest(Zoo zoo, string name)
        {
            // Find the guest based on the entered name.
            Guest guest = zoo.FindGuest(name);

            // If the animal was found, remove the animal, and display verification message.
            if (guest != null)
            {
                zoo.RemoveGuest(guest);

                Console.WriteLine("The guest was removed from the zoo.");
            }
            // If the animal wasn't found, display error message.
            else
            {
                Console.WriteLine("Guest could not be found.");
            }
        }

        /// <summary>
        /// Shows the animal in the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo the animal is in.</param>
        /// <param name="name"> The name of the animal.</param>
        private static void ShowAnimal(Zoo zoo, string name)
        {
            try
            {
                // Finds the animal by name.
                Animal animalFound = null;

                string animalName = ConsoleUtil.InitialUpper(name);

                animalFound = zoo.FindAnimal(animalName);

                if (animalFound != null)
                {
                    Console.WriteLine("The following animal was found: " + (animalFound));
                }
                else
                {
                    Console.WriteLine("The animal could not be found.");
                }
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("Must enter a valid command.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Must be letters.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Must be the name of an animal.");
            }
        }

        /// <summary>
        /// Shows the guest in the zoo.
        /// </summary>
        /// <param name="zoo"> The zoo that guest is in.</param>
        /// <param name="name"> The name of the guest.</param>
        private static void ShowGuest(Zoo zoo, string name)
        {
            try
            {
                Guest guestFound = null;

                string guestName = ConsoleUtil.InitialUpper(name);

                guestFound = zoo.FindGuest(guestName);

                if (guestFound != null)
                {
                    Console.WriteLine("The following guest was found: " + (guestFound));
                }
                else
                {
                    Console.WriteLine("The guest could not be found");
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("Must be letters.");
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Must be the name of a guest in the list of guests..");
            }
        }
    }
}
