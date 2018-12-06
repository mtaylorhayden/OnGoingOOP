using System;
using Airports;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Object Oriented Programming 2: Scratchpad";

            Airport dfw = null;

            bool exit = false;

            while (!exit)
            {
                string line = Console.ReadLine();

                string[] commandWords = line.Split();

                switch(commandWords[0])
                {
                    case "exit":
                        exit = true;

                        break;
                    case "new":
                        dfw = new Airport();

                        break;
                    case "parking":
                        try
                        {
                        dfw.ParkingCost = decimal.Parse(commandWords[1]);
                        }
                        catch (NullReferenceException)
                        {
                            Console.WriteLine("Please create an airport before setting its parking cost.");
                        }
                        catch (FormatException)
                        {
                            Console.WriteLine("Please enter a valid number for parking cost.");
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Please enter a number between 0 and 100 for parking cost.");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;

                }
                
            }
        }
    }
}
