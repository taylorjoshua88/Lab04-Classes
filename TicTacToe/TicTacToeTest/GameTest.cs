using System;
using Xunit;
using TicTacToe;

namespace TicTacToeTest
{
    public class GameTest
    {
        // Used for Assert.Throws<ArgumentException> in below test
        void CreateGameWithThreePlayersAction()
        {
            Game game = new Game(new Player[] { new Player('A', "Albert"),
                new Player('B', "Bonnie"), new Player('C', "Charlie") });
        }

        [Fact]
        public void CannotCreateGameWithoutTwoPlayers()
        {
            Assert.Throws<ArgumentException>(
                (Action)CreateGameWithThreePlayersAction);
        }

        // Remaining Game methods require console input
    }
}
