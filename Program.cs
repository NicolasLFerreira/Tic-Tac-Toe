using System;

namespace TicTacToe
{
    class Program
    {
        static bool play = true;
        static bool win = false;
        static char checkWin;

        // Players instance
        static Game.Player playerX = new Game.Player(true, ConsoleColor.DarkYellow); // 'true' is the X player
        static Game.Player playerO = new Game.Player(false, ConsoleColor.Blue); // 'false' is the O player

        // Table instance
        static Table.Table table = new Table.Table();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            
            // Game variables
            play = true;
            win = false;

            while (play)
            {
                while (!win)
                {
                    table.TableBuild();
                    table.Movement(playerX); // Player X
                    Won(); // Check to see if anyone wins
                    table.TableBuild();
                    table.Movement(playerO); // Player O
                    table.TableBuild();
                    Won();
                }
            }
        }

        public static void Won()
        {
            checkWin = table.CheckWin();
            if (checkWin != '.')
            {
                table.TableBuild();
                win = true;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nCongratulations to player '{checkWin}' for winning the game!");
                Console.WriteLine($"Wish to continue?" +
                                  $"\nYes: 1" +
                                  $"\nNo: 2");
                if (Utilities.Utilities.ValidNumber(1, 2, 0) == 1)
                {
                    play = true;
                    Array.Clear(table.Matrix, 0, table.Matrix.Length);
                }
                else play = false;
            }
        }
    }
}