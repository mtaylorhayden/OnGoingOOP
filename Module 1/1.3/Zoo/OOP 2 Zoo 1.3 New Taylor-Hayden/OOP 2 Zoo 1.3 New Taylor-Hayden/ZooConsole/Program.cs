using Animals;
using People;
using System;
using Zoos;

namespace ZooConsole
{
    /// <summary>
    /// The program for the zoo console.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The como zoo.
        /// </summary>
        private static Zoo zoo;

        /// <summary>
        /// The main program for creating the zoo.
        /// </summary>
        /// <param name="args"> The arguments for the program.</param>
        public static void Main(string[] args)
        {
            Console.Title = "Object-Oriented Programming 2: Zoo";

            Console.WriteLine("Welcome to the Como Zoo!");

            bool exit = false;

            string command;

            zoo = Zoo.NewZoo();

            while (!exit)
            {
                Console.Write("]");

                command = Console.ReadLine();

                // Create a string array variable called commandwords and set it to the result of splitting the command.
                string[] commandWords = command.Split();

                // Lowers the letters and trims any extra whitespace. 
                command = command.ToLower().Trim();

                switch (commandWords[0])
                {
                    // If you write "exit", then it will exit the program.
                    case "exit":
                        exit = true;

                        break;

                    // If you write anything besides exit then you will get this warning.
                    default:
                        Console.WriteLine("Warning, the command you wrote is not valid.");

                        break;

                    // If you write "new" then you will create a new zoo.
                    case "restart":
                        zoo.BirthingRoomTemperature = 77;
                        Console.WriteLine("A new Como Zoo has been created");

                        break;

                    // If you write "help" then you will see the following...
                    case "help":
                        Console.WriteLine("Known commands:");
                        Console.WriteLine("HELP: Shows a list of known commands.");
                        Console.WriteLine("EXIT: Exits the application.");
                        Console.WriteLine("RESTART: Creates a new Zoo.");
                        Console.WriteLine("TEMP: Sets the birthing room temperature.");
                        Console.WriteLine("SHOW ANIMAL [animal name]: Displays information for specified animal.");
                        Console.WriteLine("GUEST [guest name]: Displays information for specified guest.");

                        break;

                    // If you write "temp" you will see the folowing...
                    case "temperature":
                        // Try this code.
                        try
                        {
                            // temperature is the zoo's birthing room temperature.
                            double temperature = zoo.BirthingRoomTemperature;

                            // Set the birthing rooms temperature to the value of the second item in the commandWords array.
                            // Parse the string as a double.
                            zoo.BirthingRoomTemperature = Double.Parse(commandWords[1]);

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
                            break;
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
                        break;

                    // If you write show.
                    case "show":
                        try
                        {
                            switch (commandWords[1])
                            {
                                // If you write guest.
                                case "guest":
                                    try
                                    {
                                        {
                                            // Captializes the first letter of the string.
                                            string guestName = InitialUpper(commandWords[2]);

                                            // Finds the animal by name.
                                            Guest guestFound = zoo.FindGuest(guestName);

                                            if (guestFound != null)
                                            {
                                                Console.WriteLine("The following guest was found: " + (guestFound));
                                            }
                                            else
                                            {
                                                Console.WriteLine("The guest could not be found.");
                                            }
                                            break;
                                        }
                                    }
                                    // Catch the exceptions.
                                    catch (ArgumentOutOfRangeException ex)
                                    {
                                        Console.WriteLine(ex.Message);
                                    }
                                    catch (FormatException)
                                    {
                                        Console.WriteLine("Must be letters.");
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        Console.WriteLine("Must be the name of a guest in the list of guests..");
                                    }
                                    break;

                                // If you write animal.
                                case "animal":
                                    {
                                        try
                                        {
                                            // Captializes the first letter of the string.
                                            string animalName = InitialUpper(commandWords[2]);

                                            // Finds the animal by name.
                                            Animal animalFound = zoo.FindAnimal(animalName);

                                            if (animalFound != null)
                                            {
                                                Console.WriteLine("The following animal was found: " + (animalFound));
                                            }
                                            else
                                            {
                                                Console.WriteLine("The animal could not be found.");
                                            }
                                            break;
                                        }

                                        // Catch the exceptions.
                                        catch (ArgumentOutOfRangeException ex)
                                        {
                                            Console.WriteLine(ex.Message);
                                        }
                                        catch (FormatException)
                                        {
                                            Console.WriteLine("Must be letters.");
                                        }
                                        catch (IndexOutOfRangeException)
                                        {
                                            Console.WriteLine("Must be the name of an animal in the zoo.");
                                        }
                                        break;
                                    }
                            }
                        }
                        // Catch the exceptions.
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Must be lower case letters.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Statement must say animal.");
                        }
                        break;
                }
            }

        }
        /// <summary>
        /// Makes the first letter of any string capital.
        /// </summary>
        /// <param name="value"> The string that will be capitalized.</param>
        /// <returns> The string that has had its first letter capitalized.</returns>
        public static string InitialUpper(string value)
        {
            string guestName = null;

            if (value.Length > 0 && value != null)
            {
                guestName = char.ToUpper(value[0]) + value.Substring(1);
            }
            return guestName;
        }
    }
}
