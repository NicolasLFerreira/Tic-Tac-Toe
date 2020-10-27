using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Table
{
    class Table
    {
        // Array that stores the info of the grid
        public Game.Player[,] Matrix = new Game.Player[3, 3];

        // This method creates the plaid pattern
        private void PlaidPattern(int row, int column)
        {
            // Changes the backgrund color according to the number given
            if (row % 2 == 0)
            {
                if (column % 2 == 1) Console.BackgroundColor = ConsoleColor.Gray;
                else Console.BackgroundColor = ConsoleColor.DarkGray;
            }
            else
            {
                if (column % 2 == 0) Console.BackgroundColor = ConsoleColor.Gray;
                else Console.BackgroundColor = ConsoleColor.DarkGray;
            }
        }

        // Method for printing the grid
        public void TableBuild()
        {
            Console.Write("\n|#|");
            // Column number
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"|{i + 1}|");
            }

            Console.WriteLine();
            for (int row = 0; row < 3; row++)
            {
                // Row number
                Console.Write($"|{row + 1}|");
                for (int column = 0; column < 3; column++)
                {
                    // Call for the plaid pattern method
                    PlaidPattern(row, column);

                    // Gets the current position and prints its content with the team's color
                    if (Matrix[row, column] != null)
                    {
                        Console.ForegroundColor = Matrix[row, column].TeamColor;
                        Console.Write($" {Matrix[row, column].Icon} ");
                    }
                    else Console.Write("   ");

                    // Normalizes color
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }
        }

        public void Movement(Game.Player player)
        {
            // Position the player wants to place a piece
            int[] movement = player.Move();

            // Checks if both pieces are of the same team
            while (Matrix[movement[0], movement[1]] != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n-> Occupied position.");
                Console.ForegroundColor = ConsoleColor.White;
                movement = player.Move();
            }
            Matrix[movement[0], movement[1]] = player;
        }

        // Checks if certain cell is null
        public bool IsNull(int row, int column)
        {
            if (Matrix[row, column] != null) return true;
            else return false;
        }

        // Checks possible win conditions, and finishes the game if one of them returns true
        public char CheckWin()
        {
            int total = 0;

            // Row check
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (Matrix[row, column] != null)
                    {
                        total += Matrix[row, column].Value;

                        if (total == 3 || total == 30)
                        {
                            total = 0;
                            return Matrix[row, column].Icon;
                        }
                    }
                }
                total = 0;
            }

            // Column check
            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    if (Matrix[column, row] != null)
                    {
                        total += Matrix[column, row].Value;

                        if (total == 3 || total == 30)
                        {
                            total = 0;
                            return Matrix[column, row].Icon;
                        }
                    }
                }
                total = 0;
            }

            // Diagonal check \
            if (Matrix[0, 0] != null && Matrix[1, 1] != null && Matrix[2, 2] != null) total += Matrix[0, 0].Value + Matrix[1, 1].Value + Matrix[2, 2].Value;
            if (total == 3 || total == 30) return Matrix[1, 1].Icon;

            // Diagonal check /
            if (Matrix[0, 2] != null && Matrix[1, 1] != null && Matrix[2, 0] != null) total += Matrix[0, 2].Value + Matrix[1, 1].Value + Matrix[2, 0].Value;
            if (total == 3 || total == 30) return Matrix[1, 1].Icon;

            return '.';
        }
    }
}
