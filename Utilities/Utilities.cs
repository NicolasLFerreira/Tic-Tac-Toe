using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Utilities
{
    class Utilities
    {
        // Method that captures an integer input
        public static int IntegerInput()
        {
            string input = Console.ReadKey().KeyChar.ToString();
            int output;

            while (!int.TryParse(input, out output))
            {
                Console.Write("\nThat's not a number! Enter one please: ");
                input = Console.ReadKey().KeyChar.ToString();
            }
            return output;
        }

        // Method that captures an input from MIN to MAX
        public static int ValidNumber(int min, int max, int special)
        {
            int input = IntegerInput();

            while (input < min || input > max)
            {
                if (input == special) Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"\n-> Please enter a number between {min} and {max}: ");
                Console.ForegroundColor = ConsoleColor.Gray;
                input = IntegerInput();
            }
            input--;
            return input;
        }

        // Continue.
        public static void Continue()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nPress any key to continue...");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadKey();
            Console.Clear();
        }
    }
}
