using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Game
{
    class Player
    {
        public bool Team { get; set; }
        public char Icon { get; set; }
        public ConsoleColor TeamColor { get; set; }
        public int Value { get; set; }

        public Player(bool team, ConsoleColor teamColor)
        {
            Team = team;

            if (team)
            {
                Icon = 'X';
                Value = 1;
            }
            else
            {
                Icon = 'O';
                Value = 10;
            }
            TeamColor = teamColor;
        }
        
        public int[] Move()
        {
            Console.ForegroundColor = TeamColor;
            Console.Write($"\nPLAYER '{Icon}' row: ");
            int row = Utilities.Utilities.ValidNumber(1, 3, 0);
            Console.Write($"\nPLAYER '{Icon}' column: ");
            int column = Utilities.Utilities.ValidNumber(1, 3, 0);
            Console.ForegroundColor = ConsoleColor.Gray;
            return new int[] { row, column };
        }
    }
}
