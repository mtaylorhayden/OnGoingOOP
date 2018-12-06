using System;
using People;
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
            
            while (!exit)
            {
                Console.Write("]");

                command = Console.ReadLine();

                // Lowers the letters and trims any extra whitespace. 
                command = command.ToLower().Trim();

                switch (command)
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
                    case "new":
                        zoo = new Zoo("Como Zoo", 1000, 4, 0.75m, 15.00m, 3640.25m, new Employee("Sam", 42), new Employee("Flora", 98), 3);
                        Console.WriteLine("A new Como Zoo has been created");

                        break;

                    // If you write "help" then you will see the following...
                    case "help":
                        Console.WriteLine("Known commands:");
                        Console.WriteLine("HELP: Shows a list of known commands.");
                        Console.WriteLine("EXIT: Exits the application.");
                        Console.WriteLine("NEW: Creates the ComoZoo.");

                        break;
                }
            }
        }
    }
}
