using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    class Game
    {
        public Board GameBoard { get; private set; } = new Board();
        public Player[] Players { get; private set; }

        public Game(char firstPlayerToken, string firstPlayerName,
            char secondPlayerToken, string secondPlayerName)
        {
            if (firstPlayerToken == secondPlayerToken)
            {
                throw new ArgumentException("Players cannot have the" +
                    " same character marks");
            }

            Players = new Player[2]
            {
                new Player(firstPlayerToken, firstPlayerName),
                new Player(secondPlayerToken, secondPlayerName)
            };
        }

        public Game(Player[] players)
        {
            if (players[0].Token == players[1].Token)
            {
                throw new ArgumentException("Players cannot have the" +
                    " same tokens!");
            }

            Players = players;
        }

        public static Game CreateGameInteractive()
        {
            Player[] players = new Player[2];
            int currentPlayer = 0;

            Console.Clear();
            Console.WriteLine("Welcome to Tic-Tac-Toe!");

            while (currentPlayer < 2)
            {
                Console.WriteLine($"\n\nPlease enter player {currentPlayer + 1}'s name:");
                string playerName = Console.ReadLine();

                Console.WriteLine($"Please enter a token for player {currentPlayer + 1}:");
                char playerToken = Console.ReadKey().KeyChar;

                try
                {
                    players[currentPlayer] = new Player(playerToken, playerName);
                }
                catch (ArgumentOutOfRangeException e)
                {
                    Console.WriteLine("\nInvalid token provided. Please only use letters.");
                    continue;
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine("Please type a name with at least 1 letter.");
                    continue;
                }
                
                // Make sure the players do not share the same token
                if (players[0]?.Token == players[1]?.Token)
                {
                    Console.WriteLine("\nPlayers cannot share the same token.");
                    Console.WriteLine("Please press a key to try again...");
                    Console.ReadKey();
                    continue;
                }

                currentPlayer++;
            }

            return new Game(players);
        }

        public bool BeginLoop()
        {
            for (;;)
            {
                int currentPlayer = 0;

                while (currentPlayer < 2)
                {
                    Console.Clear();
                    Console.WriteLine(GameBoard.CreateArtString(Players));
                    Console.WriteLine($"It is {Players[currentPlayer].Name}'s turn!");
                    Console.WriteLine($"Your squares are marked with {Players[currentPlayer].Token}");
                    Console.WriteLine("Please enter a square to mark " +
                        "corresponding to how it appears above:");

                    try
                    {
                        GameBoard.MarkSquare(
                            Convert.ToInt32(Console.ReadLine()), currentPlayer);
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.WriteLine("Please only enter a number 1-9");
                        Console.WriteLine("Please press a key to try again...");
                        Console.ReadKey(true);
                        continue;
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine("That square is already marked!");
                        Console.WriteLine("Please press a key to try again...");
                        Console.ReadKey(true);
                        continue;
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Could not understand your input.");
                        Console.WriteLine("Please try again with a number 1-9");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey(true);
                        continue;
                    }

                    // Check for a winner
                    int winner = GameBoard.CheckWinningState();
                    if (winner >= 0)
                    {
                        Console.Clear();
                        Console.WriteLine(GameBoard.CreateArtString(Players));
                        Console.WriteLine("\nCongratulations!");
                        Console.WriteLine($"{Players[currentPlayer].Name} has won!");
                        Console.WriteLine("Would you like to play again? (Y/N)");

                        // Keep reading keys until either Y or N is pressed
                        ConsoleKey response;
                        do
                        {
                            response = Console.ReadKey(true).Key;
                        } while (response != ConsoleKey.Y && response != ConsoleKey.N);

                        return response == ConsoleKey.Y;
                    }

                    currentPlayer++;
                }
            }
        }
    }
}
