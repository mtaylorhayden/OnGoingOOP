using Animals;
using People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoos;

namespace ZooConsole
{
    /// <summary>
    /// The class used to represent the console helper.
    /// </summary>
    internal static class ConsoleHelper
    {
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
