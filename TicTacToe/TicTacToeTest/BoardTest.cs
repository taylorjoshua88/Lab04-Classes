using System;
using Xunit;
using TicTacToe;

namespace TicTacToeTest
{
    public class BoardTest
    {
        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 1)]
        [InlineData(7, 1)]
        [InlineData(8, 1)]
        [InlineData(4, 0)]
        public void MarkSquareTest(int markedIndex, int markingPlayer)
        {
            // Arrange
            Board board = new Board();

            // Act
            board.MarkSquare(markedIndex, markingPlayer);

            // Assert
            // NOTE(taylorjoshua88): It would be better to store the original
            //                       state of the board and then assert against
            //                       that to ensure we aren't simply observing
            //                       default assignment. Using markingPlayer
            //                       values > 0 should avoid this risk for now.
            Assert.Equal(markingPlayer, board.Squares[markedIndex]);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 1)]
        [InlineData(7, 1)]
        [InlineData(8, 1)]
        [InlineData(4, 0)]
        public void CheckSquareTest(int markedIndex, int markingPlayer)
        {
            // Arrange
            Board board = new Board();

            // Act
            board.MarkSquare(markedIndex, markingPlayer);

            // Assert
            Assert.Equal(markingPlayer, board.CheckSquare(markedIndex));
        }

        [Theory]
        [InlineData(0, 1, 0)]
        [InlineData(2, 0, 1)]
        [InlineData(4, 1, 1)]
        [InlineData(6, 0, 0)]
        public void CannotRemarkSquareTest(int markedIndex,
            int markingPlayer, int remarkingPlayer)
        {
            // Arrange
            Board board = new Board();
            board.MarkSquare(markedIndex, markingPlayer);

            // Act + Assert
            Assert.Throws<ArgumentException>(
                () => board.MarkSquare(markedIndex, remarkingPlayer));
        }
    }
}
