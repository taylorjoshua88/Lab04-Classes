using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        private char _token;
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

        public Player(char token, string name)
        {
            Token = token;
            Name = name;
        }
    }
}
