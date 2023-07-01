﻿using System.Collections.Generic;
using System;
using System.Security.Cryptography.X509Certificates;

namespace BattleShip
{
    class Program
    {
        static void Main(string[] args)
        {
            // Introduction and getting the user info
            string userName = GetUserInfo();

            // Setup the playing board
            Dictionary<string, string> gameBoard = GameBoardSetup();

            // Select a random coordinates for the location of the battleship
            List<string> battleshipLocation = generateBattleshipLocation();
            Console.WriteLine($"This is the location of the battleship: {string.Join(", ", battleshipLocation)}");

            // Display the gameboard
            DisplayGameBoard(gameBoard);

            // Ask for user input
            string userInput = GetUserInput();
            Console.WriteLine($"You entered: {userInput}");
            
        }

        public static List<string> generateBattleshipLocation()
        {
            List<string> battleshipLocations = new List<string>();
            Random rand = new Random();
            int direction = rand.Next(1, 4);
            Console.WriteLine($"Direction: {direction}");
            // int randomNumber = rand.Next(1, 11);
            int randomNumber = 8;
            string randomLetter = ((char)rand.Next(65, 74)).ToString();
            char randomCharacter = randomLetter[0];
            string location = randomLetter + randomNumber.ToString();
            //battleshipLocations.Add(location);
            
            List<string> horizontalBattleship(int randomNumber, string randomLetter)
            {
                List<string> battleshipLocation = new List<string>();
                if (randomNumber + 4 > 10)
                {
                    int numbershift = (randomNumber + 4) - 10;
                    randomNumber = randomNumber - numbershift;
                }
                for (int k = randomNumber; k <= randomNumber + 4; k++)
                {
                    battleshipLocation.Add($"{randomLetter}{randomNumber.ToString()}");
                    Console.WriteLine($"{randomLetter}{k}");
                }
                return battleshipLocations;
            }

            List<string> verticalBattleship(int randomNumber, string randomLetter)
            {
                List<string> battleshipLocation = new List<string>();
                if (randomNumber + 4 > 10)
                {
                    int numbershift = (randomNumber + 4) - 10;
                    randomNumber = randomNumber - numbershift;
                }
                for (int k = randomNumber; k <= randomNumber + 4; k++)
                {
                    battleshipLocation.Add($"{randomLetter}{randomNumber.ToString()}");
                    Console.WriteLine($"{randomLetter}{k}");
                }
                return battleshipLocations;
            }

            /*for (int j = (int)randomCharacter; j <= (int)randomCharacter + 4; j++)
                {
                    for (int k = randomNumber; k <= randomNumber + 4; k++)
                    {
                        // gameBoard.Add($"{Convert.ToChar(j)}{i}", "X");
                        Console.WriteLine($"{Convert.ToChar(j)}{k}");
                    }
                }*/
            // string location = randomLetter + randomNumber.ToString();
            battleshipLocations = horizontalBattleship(randomNumber, randomLetter);

            foreach (string index in battleshipLocations)
            {
                Console.WriteLine(index);
            }

            return battleshipLocations;
        }
        
        public static string GetUserInfo()
        {
            do
            {
                Console.WriteLine("Hello! Welcome to Simple Battleship");
                Console.Write("What is your name? ");
                string userName = Console.ReadLine()!;
                Console.WriteLine();

                if (userName.Length > 0)
                {
                    Console.WriteLine($"Hello {userName}, let's get started");
                    return userName;
                }
                
            } while (true);
            
        }
        public static string GetUserInput()
        {
            do
            {
                Console.WriteLine();
                Console.Write("Please enter the Coordinates: ");
                string userInput = Console.ReadLine()!;
                Console.WriteLine();

                if (userInput.Length > 0 && userInput.Length <= 3)
                {
                    userInput = userInput.ToUpper();
                    char character = userInput[0];
                    int characterCheck = (int)character;
                    int number;
                    string CharacterNumber = userInput.Substring(1);
                    if (int.TryParse(CharacterNumber, out number))
                    {
                        if (characterCheck >= 65 && characterCheck <= 74 && number >= 0 && number <= 10)
                        {
                            return userInput;
                        }
                    }                   
                }

            } while (true);

        }
        public static Dictionary<string, string> GameBoardSetup()
        {
            // Function body goes here
            Dictionary<string, string> gameBoard = new Dictionary<string, string>();

            for (int j = 65; j <= 74; j++)
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
            for (int j = 65; j <= 74; j++)
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


