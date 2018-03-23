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
    }
}
