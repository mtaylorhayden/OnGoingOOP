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

                        ConsoleHelper.SetTemperature(zoo, commandWords[1]);

                        break;

                    // If you write show.
                    case "show":
                        try
                        {
                            ConsoleHelper.ProcessShowCommand(zoo, commandWords[1], commandWords[2]);

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
    }
}
