using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        // Should probably be protected internal, but keeping
        // as public for ease of unit testing
        public int[] Squares { get; private set; } =
            new int[9] { -1, -1, -1, -1, -1, -1, -1, -1, -1 };

        /// <summary>
        /// Marks a square (1-9) for one of the players (0-1)
        /// </summary>
        /// <param name="squareIndex">The number of the square as it appears
        /// within the game's interface (1-9)</param>
        /// <param name="playerIndex">The index for the player to mark the
        /// square for (0-1)</param>
        public void MarkSquare(int squareIndex, int playerIndex)
        {
            // Validate that parameters exist on the board and refer
            // to an actual player
            if (squareIndex < 1 || squareIndex > 9)
            {
                throw new ArgumentOutOfRangeException("Square indexes can " +
                    "only be a number 1-9", nameof(squareIndex));
            }
            if (playerIndex < 0 || playerIndex > 1)
            {
                throw new ArgumentOutOfRangeException("There should" +
                    " only be two players in a game of Tic Tac Toe",
                    nameof(playerIndex));
            }
            // The square was already marked by a player; do not allow this
            if (Squares[squareIndex - 1] >= 0)
            {
                throw new ArgumentException("Attempted to re-mark a square " +
                    "which has already been marked by a player", nameof(squareIndex));
            }

            // Squares are referenced in the game starting at 1, not 0
            Squares[squareIndex - 1] = playerIndex;
        }

        /// <summary>
        /// Check who owns a specific square by the square's index as it
        /// appears in the game's interface (1-9) 
        /// </summary>
        /// <param name="squareIndex">A square's index as it appears
        /// in the game's interface (1-9)</param>
        /// <returns>The player index (0-1) of the player who owns that square
        /// or -1 if no player owns that square</returns>
        public int CheckSquare(int squareIndex)
        {
            // Validate that parameter refers to an actual square
            if (squareIndex < 1 || squareIndex > 9)
            {
                throw new ArgumentOutOfRangeException("Square indexes can " +
                    "only be a number 1-9", nameof(squareIndex));
            }

            return Squares[squareIndex - 1];
        }

        /// <summary>
        /// Check if the game board is in a winning state (one player has
        /// completed a row, column, or diagonal)
        /// </summary>
        /// <returns>The player's index (0-1) who has won or -1 if the board
        /// is not in a winning state</returns>
        public int CheckWinningState()
        {
            // Check rows
            for (int rowStart = 0; rowStart < 9; rowStart += 3)
            {
                if (Squares[rowStart] < 0)
                {
                    continue;
                }
                if (Squares[rowStart] == Squares[rowStart + 1] &&
                    Squares[rowStart + 1] == Squares[rowStart + 2])
                {
                    return Squares[rowStart];
                }
            }

            // Check columns
            for (int colStart = 0; colStart < 3; colStart++)
            {
                if (Squares[colStart] == Squares[colStart + 3] &&
                    Squares[colStart + 3] == Squares[colStart + 6])
                {
                    if (Squares[colStart] < 0)
                    {
                        continue;
                    }
                    return Squares[colStart];
                }
            }

            // Check diagonals
            if ((Squares[0] == Squares[4] && Squares[4] == Squares[8]) ||
                (Squares[2] == Squares[4] && Squares[4] == Squares[6]))
            {
                return Squares[4];
            }

            // Nobody has won yet
            return -1;
        }

        /// <summary>
        /// Create an ASCII-art representation of the board's state as a string
        /// </summary>
        /// <param name="players">An array of players playing the game. Used
        /// to determine which token to display on taken squares.</param>
        /// <returns>String with ASCII art representing the current board state</returns>
        public string CreateArtString(Player[] players)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int row = 0; row < 3; row++)
            {
                for (int column = 0; column < 3; column++)
                {
                    int playerIndex = Squares[row * 3 + column];

                    // If the square hasn't been marked yet, then output
                    // the number of the square 1-9, otherwise output
                    // the player who owns that square's token
                    char squareToken = playerIndex < 0 ? 
                        (row * 3 + column + 1).ToString()[0] :
                        players[playerIndex].Token;

                    stringBuilder.Append($"|{squareToken}|");
                }

                stringBuilder.AppendLine();
            }

            return stringBuilder.ToString();
        }
    }
}
