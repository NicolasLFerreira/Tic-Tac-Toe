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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n->That's not a number! Enter one please: ");
                Console.ForegroundColor = ConsoleColor.White;
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
                Console.ForegroundColor = ConsoleColor.White;
                input = IntegerInput();
            }
            return input;
        }
    }
}
