using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            // Players instance
            Game.Player playerX = new Game.Player(true, ConsoleColor.DarkYellow); // 'true' is the X player
            Game.Player playerO = new Game.Player(false, ConsoleColor.Blue); // 'false' is the O player

            // Table instance
            Table.Table table = new Table.Table();

            // Other variables
            bool play = true;
            bool win = false;
            char checkWin;

            while (play)
            {
                while (!win)
                {
                    // Player X
                    table.TableBuild();
                    table.Movement(playerX);

                    // Check to see if anyone wins
                    checkWin = table.CheckWin();
                    if (checkWin != '.')
                    {
                        win = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nCongratulations to player '{checkWin}' for winning the game!");
                        Console.WriteLine($"Wish to continue?" +
                                          $"Yes: 1" +
                                          $"No: 2");
                        if (Utilities.Utilities.ValidNumber(1, 2, 0) == 1)
                        {
                            play = true;
                            Array.Clear(table.Matrix, 0, table.Matrix.Length);
                        }
                        else play = false;
                    }

                    // Player Y
                    table.TableBuild();
                    table.Movement(playerO);
                    table.TableBuild();

                    // Check to see if anyone wins
                    checkWin = table.CheckWin();
                    if (checkWin != '.')
                    {
                        win = true;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nCongratulations to player '{checkWin}' for winning the game!");
                        Console.WriteLine($"Wish to continue?" +
                                          $"Yes: 1" +
                                          $"No: 2");
                        if (Utilities.Utilities.ValidNumber(1, 2, 0) == 1)
                        {
                            play = true;
                            Array.Clear(table.Matrix, 0, table.Matrix.Length);
                        }
                        else play = false;
                    }

                    Utilities.Utilities.Continue();
                }
            }
        }
    }
}