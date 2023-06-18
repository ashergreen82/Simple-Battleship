using System.Collections.Generic;
using System;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setup the playing board
            Dictionary<string, string> gameBoard = GameBoardSetup();

            //Display the gameboard
            DisplayGameBoard(gameBoard);
            Console.ReadLine();
           
            /*
            string? keyboardInput = Console.ReadLine();
            if (!String.IsNullOrEmpty(keyboardInput))
            {
                Console.WriteLine($"You typed: \"{keyboardInput}\". Good for you!  I am sooooo proud of you!");
            }
            else if (String.IsNullOrEmpty(keyboardInput))
            {
                Console.WriteLine("You didn't type anything, are you ok?  Is everything all right?");
            }
            else if (keyboardInput == null)
            {
                Console.WriteLine("NULL?  How the hell did you manage to return a NULL?");
            }
            */
        }

        public static Dictionary<string, string> GameBoardSetup()
        {
            // Function body goes here
            Dictionary<string, string> gameBoard = new Dictionary<string, string>();

            for (int j = 65; j <= 75; j++)
            {
                for (int i = 0; i <= 10; i++)
                {
                    gameBoard.Add($"{Convert.ToChar(j)}{i}", "X");
                }
            }
            return gameBoard;
        }

        public static void DisplayGameBoard(Dictionary<string, string> gameBoard)
        {
            // Print the column labels
            Console.Write("  "); // Space for row labels
            for (int i = 0; i <= 10; i++)
            {
                Console.Write($" {i} ");
            }
            Console.Write("\n");

            // Print the rows
            for (int j = 65; j <= 75; j++)
            {
                // Print the row label
                Console.Write($"{Convert.ToChar(j)} ");

                // Print the cells
                for (int i = 0; i <= 10; i++)
                {
                    string key = $"{Convert.ToChar(j)}{i}";
                    if (i >= 10)
                    {
                        Console.Write($"  {gameBoard[key]} ");
                    }
                    else
                    {
                        Console.Write($" {gameBoard[key]} ");
                    }
                }
                Console.Write("\n"); // Move to the next line
            }
        }
    }
}


