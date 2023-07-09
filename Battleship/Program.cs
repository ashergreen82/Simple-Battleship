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
            List<string> battleshipLocation = new List<string>();
            Random rand = new Random();
            /*
            In order to determine the direction of the battleship, I randomly choose a number and that number determines the
            direction of the battleship.  Basically a random letter and number is chosen, and then I simply added
            the letters and numbers in sequence to the location of the battlship string array
            1 - Horizontal
            2 - Vertical
            3 - diagnal, left to right
            4 - diagnal, right to left
            */
            // int direction = rand.Next(1, 4);
            int direction = 4;
            Console.WriteLine($"Direction: {direction}");
            // Here a random number is chosen
            // int randomNumber = rand.Next(1, 11);
            int randomNumber = 8;
            // Here a random letter is chosen
            // string randomLetter = ((char)rand.Next(65, 74)).ToString();
            string randomLetter = ((char)(74)).ToString();
            char randomCharacter = randomLetter[0];
            string location = randomLetter + randomNumber.ToString();
            //battleshipLocation.Add(location);

            List<string> horizontalBattleship(int randomNumber, string randomLetter)
            {
                Console.WriteLine("Horizontal Battleship function executing");
                List<string> battleshipLocation = new List<string>();
                if (randomNumber + 4 > 10)
                {
                    int numberShift = (randomNumber + 4) - 10;
                    randomNumber = randomNumber - numberShift;
                }
                for (int k = randomNumber; k <= randomNumber + 4; k++)
                {
                    battleshipLocation.Add($"{randomLetter}{randomNumber.ToString()}");
                    Console.WriteLine($"{randomLetter}{k}");
                }
                return battleshipLocation;
            }

            List<string> verticalBattleship(int randomNumber, string randomLetter)
            {
                Console.WriteLine("Vertical Battleship function executing");
                List<string> battleshipLocation = new List<string>();
                char randomLetterChar = randomLetter[0];
                int randomLetterAscii = (int)randomLetterChar;
                // int randomLetterAscii = int.Parse(randomLetter);
                if (randomLetterAscii + 4 > 74)
                {
                    int letterShift = (randomLetterAscii + 4) - 74;
                    randomLetterAscii = randomLetterAscii - letterShift;
                    randomLetter = randomLetterAscii.ToString();
                }
                for (int k = randomLetterAscii; k <= randomLetterAscii + 4; k++)
                {
                    battleshipLocation.Add($"{((char)k).ToString()}{randomNumber.ToString()}");
                    Console.WriteLine($"{((char)k).ToString()}{randomNumber}");
                }
                return battleshipLocation;
            }

            List<string> diagnalLeftToRightBattleship(int randomNumber, string randomLetter)
            {
                Console.WriteLine("Diagnal Left to Right Battleship function executing");
                List<string> battleshipLocation = new List<string>();
                char randomLetterChar = randomLetter[0];
                int randomLetterAscii = (int)randomLetterChar;
                // int randomLetterAscii = int.Parse(randomLetter);
                if (randomNumber + 4 > 10)
                {
                    int numberShift = (randomNumber + 4) - 10;
                    randomNumber = randomNumber - numberShift;
                }
                if (randomLetterAscii + 4 > 74)
                {
                    int letterShift = (randomLetterAscii + 4) - 74;
                    randomLetterAscii = randomLetterAscii - letterShift;
                    randomLetter = randomLetterAscii.ToString();
                }
                for (int k = randomLetterAscii; k <= randomLetterAscii + 4; k++)
                {
                    battleshipLocation.Add($"{((char)k).ToString()}{randomNumber.ToString()}");
                    Console.WriteLine($"{((char)k).ToString()}{randomNumber}");
                    randomNumber--;
                }
                return battleshipLocation;
            }

            List<string> diagnalRightToLeftBattleship(int randomNumber, string randomLetter)
            {
                Console.WriteLine("Diagnal Right To Left Battleship function executing");
                List<string> battleshipLocation = new List<string>();
                char randomLetterChar = randomLetter[0];
                int randomLetterAscii = (int)randomLetterChar;
                // int randomLetterAscii = int.Parse(randomLetter);
                if (randomNumber + 4 > 10)
                {
                    int numberShift = (randomNumber + 4) - 10;
                    randomNumber = randomNumber - numberShift;
                }
                if (randomLetterAscii + 4 > 74)
                {
                    int letterShift = (randomLetterAscii + 4) - 74;
                    randomLetterAscii = randomLetterAscii - letterShift;
                    randomLetter = randomLetterAscii.ToString();
                }
                for (int k = randomLetterAscii; k <= randomLetterAscii + 4; k++)
                {
                    battleshipLocation.Add($"{((char)k).ToString()}{randomNumber.ToString()}");
                    Console.WriteLine($"{((char)k).ToString()}{randomNumber}");
                    randomNumber++;
                }
                return battleshipLocation;
            }
            // string location = randomLetter + randomNumber.ToString();

            switch (direction)
            {
                case 1:
                    battleshipLocation = horizontalBattleship(randomNumber, randomLetter);
                    break; 
                case 2:
                    battleshipLocation = verticalBattleship(randomNumber, randomLetter);
                    break;
                case 3:
                    battleshipLocation = diagnalLeftToRightBattleship(randomNumber, randomLetter);
                    break;
                case 4:
                    battleshipLocation = diagnalRightToLeftBattleship(randomNumber, randomLetter);
                    break;
            }

            Console.WriteLine("For each loop executing");
            foreach (string index in battleshipLocation)
            {
                Console.WriteLine($"battleshipoLocations: {index}");
            }

            return battleshipLocation;
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


