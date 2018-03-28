using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        private char _token;

        /// <summary>
        /// The letter used to represent this player on the board
        /// </summary>
        public char Token
        {
            get
            {
                return _token;
            }
            set 
            {
                if (!char.IsLetter(value))
                {
                    throw new ArgumentOutOfRangeException("Player " +
                        $"tokens must be letters", nameof(value));
                }

                _token = char.ToUpper(value);
            }
        }

        private string _name;

        /// <summary>
        /// The given name of this player
        /// </summary>
        public string Name 
        {
            get
            {
                return _name;
            }
            set
            {
                if (value.Length < 1)
                {
                    throw new ArgumentException("Player names must have" +
                        " a length of at least 1 character.");
                }

                _name = value;
            }
        }

        /// <summary>
        /// Constructor for Player
        /// </summary>
        /// <param name="token">The token which is used to represent this player
        /// on the game board</param>
        /// <param name="name">The player's given name</param>
        public Player(char token, string name)
        {
            Token = token;
            Name = name;
        }
    }
}
