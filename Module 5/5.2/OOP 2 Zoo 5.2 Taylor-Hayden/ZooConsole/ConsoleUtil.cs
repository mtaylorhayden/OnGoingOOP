using Animals;
using ClassLibrary1;
using People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ZooConsole
{
    /// <summary>
    /// The class used to represent the console uti.
    /// </summary>
    internal static class ConsoleUtil
    {
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

        /// <summary>
        /// The type of animal being read.
        /// </summary>
        /// <returns> The type of animal.</returns>
        public static AnimalType ReadAnimalType()
        {
            AnimalType result = AnimalType.Dingo;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("AnimalType");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<AnimalType>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid animal type.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the string.
        /// </summary>
        /// <param name="prompt"> The string being asked for.</param>
        /// <returns>Returns the alphabetic value.</returns>
        public static string ReadAlphabeticValue(string prompt)
        {
            string result = null;

            bool found = false;

            while (!found)
            {
                result = ConsoleUtil.ReadStringValue(prompt);

                if (Regex.IsMatch(result, @"^[a-zA-Z ]+$"))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must contain only letters or spaces.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the value of the double.
        /// </summary>
        /// <param name="prompt"> The value being ask for.</param>
        /// <returns> The double from the string.</returns>
        public static double ReadDoubleValue(string prompt)
        {
            double result = 0;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadStringValue(prompt);

                if (double.TryParse(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must be either a whole number or a decimal number.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the gender of the item.
        /// </summary>
        /// <returns>The Gender of the item.</returns>
        public static Gender ReadGender()
        {

            Gender result = Gender.Female;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("Gender");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<Gender>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid gender.");
                }
            }

            return result;

        }



        /// <summary>
        /// Reads the value of the int.
        /// </summary>
        /// <param name="prompt"> The value being ask for.</param>
        /// <returns> The int from the string.</returns>
        public static int ReadIntValue(string prompt)
        {

            int result = 0;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadStringValue(prompt);

                if (int.TryParse(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must be a whole number.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the value of the string.
        /// </summary>
        /// <param name="prompt"> The value being ask for.</param>
        /// <returns> The string from the string.</returns>
        public static string ReadStringValue(string prompt)
        {

            string result = null;

            bool found = false;

            while (!found)
            {
                Console.Write(prompt + "] ");

                string stringValue = Console.ReadLine().ToLower().Trim();

                Console.WriteLine();

                if (stringValue != string.Empty)
                {
                    result = stringValue;
                    found = true;
                }
                else
                {
                    Console.WriteLine(prompt + " must have a value.");
                }
            }

            return result;
        }

        /// <summary>
        /// Reads the color that was set for the wallet.
        /// </summary>
        /// <returns> The wallet color.</returns>
        public static WalletColor ReadWalletColor()
        {
            WalletColor result = WalletColor.Black;

            string stringValue = result.ToString();

            bool found = false;

            while (!found)
            {
                stringValue = ConsoleUtil.ReadAlphabeticValue("Wallet Color");

                stringValue = ConsoleUtil.InitialUpper(stringValue);

                // If a matching enumerated value can be found...
                if (Enum.TryParse<WalletColor>(stringValue, out result))
                {
                    found = true;
                }
                else
                {
                    Console.WriteLine("Invalid wallet color.");
                }
            }

            return result;
        }

        /// <summary>
        /// Writes out the help details from the console.
        /// </summary>
        /// <param name="command"> The command being executed.</param>
        /// <param name="overview"> A brief description of what the command accomplishes.</param>
        /// <param name="arguements"> The dictionary being used to show help commands.</param>
        public static void WriteHelpDetail(string command, string overview, Dictionary<string, string> arguements)
        {
            // Display the command and overview.
            Console.WriteLine("Command name: " + command);
            Console.WriteLine("Overview: " + overview);

            // Make sure their is a dictionary.
            if(arguements != null)
            {
                // Put the keys in a list.
                List<string> list = new List<string>(arguements.Keys);

                // Give flatten the arguments passed in from the console to display for the user.
                string result = ListUtil.Flatten(list, " ");

                // Display the flatten results.
                Console.WriteLine("Usage: " + command + " " + result);

                // Write out the word parameters.
                Console.WriteLine("Parameters:");

                // For each Key - value PAIR in arguements.
                foreach (KeyValuePair<string, string> kvp in arguements)
                {
                    // Trying to match display.
                    Console.WriteLine(kvp.Key + " " + kvp.Value);

                }
            }
        }

        /// <summary>
        /// Overloaded method, the second option for the WriteHelpDetail method.
        /// </summary>
        /// <param name="command"> The command being executed.</param>
        /// <param name="overview"> A brief description of what the command accomplishes.</param>
        /// <param name="arguements"> The dictionary being used to show help commands.</param>
        /// <param name="argumentUsage"> Details about using the arguement.</param>
        public static void WriteHelpDetail(string command, string overview, string argument, string argumentUsage)
        {
            // Make a new dictionary.
            Dictionary<string, string> keyValues = new Dictionary<string, string>();

            // Add a key and value to the dictionary.
            keyValues.Add(argument, argumentUsage);

            // Call the original WriteHelpDetail to process the commands. 
            ConsoleUtil.WriteHelpDetail(command, overview, keyValues);
        }

        /// <summary>
        /// Overloaded method, the third option for the WriteHelpDetail method.
        /// </summary>
        /// <param name="command"> The command being executed.</param>
        /// <param name="overview"> A brief description of what the command accomplishes.</param>
        public static void WriteHelpDetail(string command, string overview)
        {
            // Call the orginial WriteHelpMethod and tell that the command has no arguments. 
            ConsoleUtil.WriteHelpDetail(command, overview, null);
        }
    }
}
