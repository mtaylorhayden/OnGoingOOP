using System;
using Airports;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Object Oriented Programming 2: Scratchpad";

            bool exit = false;

            while (!exit)
            {
                string command = Console.ReadLine();


                switch(command)
                {
                    case "exit":
                        exit = true;

                        break;
                    case "new":
                        Airport dfw = new Airport();

                        break;

                }
                
            }
        }
    }
}
