using System;

namespace TicTacToe
{
    class Program
    {
        // Game variables
        static bool _play = true;
        static char _checkWin;
        static int _choice;

        // Players instance
        static Game.Player _playerX = new Game.Player(true, ConsoleColor.DarkRed); // 'true' is the X player
        static Game.Player _playerO = new Game.Player(false, ConsoleColor.Magenta); // 'false' is the O player

        // Table instance
        static Table.Table _table = new Table.Table();

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            _play = true;

            while (_play)
            {
                _table.TableBuild();
                _table.Movement(_playerX); // Player X
                _play = Win(); // Check to see if anyone wins

                if (!_play) break;

                _table.TableBuild();
                _table.Movement(_playerO); // Player O
                _table.TableBuild();
                _play = Win();
                Console.Clear();
            }
        }

        public static bool Win()
        {
            _checkWin = _table.CheckWin();
            if (_checkWin != '.')
            {
                // Prints the final table and 
                _table.TableBuild();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nCongratulations to player '{_checkWin}' for winning the game!" +
                                  $"\nWish to continue?" +
                                  $"\nYes: 1" +
                                  $"\nNo: 2");

                // Asks for input and resets / quits the program depending on the choice
                _choice = Utilities.Utilities.ValidNumber(1, 2, 0);
                if (_choice == 1)
                {
                    _table = new Table.Table();
                    return true;
                }
                else return false;
            }
            return true;
        }
    }
}