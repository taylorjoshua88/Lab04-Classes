using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            for (;;)
            {
                Game game = Game.CreateGameInteractive();

                // BeginLoop returns true if the players would like
                // to play a new game; otherwise, break out
                if (!game.BeginLoop())
                {
                    break;
                }
            }
        }
    }
}
