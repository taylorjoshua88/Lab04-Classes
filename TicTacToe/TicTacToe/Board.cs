using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        // Should probably be protected internal, but keeping
        // as public for ease of unit testing
        public int[] Squares { get; private set; } = new int[9];

        public void MarkSquare(int squareIndex, int playerIndex)
        {
            throw new NotImplementedException();
        }

        public int CheckSquare(int squareIndex)
        {
            throw new NotImplementedException();
        }
    }
}
