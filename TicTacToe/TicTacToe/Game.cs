using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    /// <summary>
    /// Represents a single game of Tic Tac Toe
    /// </summary>
    public class Game
    {
        public Board GameBoard { get; private set; } = new Board();
        public Player[] Players { get; private set; }

        /// <summary>
        /// Constructor for Game
        /// </summary>
        /// <param name="players">An array of 2 players who will be playing</param>
        public Game(Player[] players)
        {
            if (players.Length != 2)
            {
                throw new ArgumentException("Tic Tac Toe can only be played " +
                    "with a maximum of two players.", nameof(players.Length));
            }
            if (players[0].Token == players[1].Token)
            {
                throw new ArgumentException("Players cannot have the" +
                    " same tokens!");
            }

            Players = players;
        }

        /// <summary>
        /// Interactive (via the console) method of creating a new Game object
        /// using parameters provided by the user.
        /// </summary>
        /// <returns>A new Game object with players created using the information
        /// gathered from the users via the console.</returns>
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

                string playerTokenInput = "";
                while (playerTokenInput.Length != 1)
                {
                    Console.WriteLine($"Please enter a single token letter for player {currentPlayer + 1}:");
                    playerTokenInput = Console.ReadLine();
                }

                try
                {
                    players[currentPlayer] = new Player(playerTokenInput[0], playerName);
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine("\nInvalid token provided. Please only use a single letter.");
                    continue;
                }
                catch (ArgumentException)
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

        /// <summary>
        /// Begins the game loop. This method will block the calling thread
        /// until the game has been completed.
        /// </summary>
        /// <returns>True if the players would like to play another game.</returns>
        public bool BeginLoop()
        {
            // All squares will have been exhausted in 9 turns
            for (int turn = 0; turn < 9; turn++)
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

            // If the number of turns have been exhausted, tell the user that
            // the game has resulted in a tie
            Console.Clear();
            Console.WriteLine(GameBoard.CreateArtString(Players));
            Console.WriteLine("\nThe game has resulted in a tie!");
            Console.WriteLine("Would you like to play again? (Y/N)");

            // Keep reading keys until either Y or N is pressed
            ConsoleKey tieResponse;
            do
            {
                tieResponse = Console.ReadKey(true).Key;
            } while (tieResponse != ConsoleKey.Y && tieResponse != ConsoleKey.N);

            return tieResponse == ConsoleKey.Y;
        }
    }
}
