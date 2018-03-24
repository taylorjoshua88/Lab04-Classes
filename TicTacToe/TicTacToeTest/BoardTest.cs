using System;
using Xunit;
using TicTacToe;
using System.Text;

namespace TicTacToeTest
{
    public class BoardTest
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 1)]
        [InlineData(7, 1)]
        [InlineData(8, 1)]
        [InlineData(9, 1)]
        [InlineData(4, 0)]
        public void MarkSquareTest(int markedIndex, int markingPlayer)
        {
            // Arrange
            Board board = new Board();

            // Act
            board.MarkSquare(markedIndex, markingPlayer);

            // Assert
            // NOTE(taylorjoshua88): Board.MarkSquare references board indexes
            //                       as they are displayed in-game, not as
            //                       they are stored in memory (zero-indexed)
            Assert.Equal(markingPlayer, board.Squares[markedIndex - 1]);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 1)]
        [InlineData(4, 1)]
        [InlineData(5, 1)]
        [InlineData(6, 1)]
        [InlineData(7, 1)]
        [InlineData(8, 1)]
        [InlineData(9, 1)]
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
        [InlineData(1, 1, 0)]
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

        [Fact]
        public void CanCheckDiagonalVictory()
        {
            // Arrange
            Board board = new Board();

            // Act
            board.MarkSquare(1, 1);
            board.MarkSquare(5, 1);
            board.MarkSquare(9, 1);

            // Assert
            Assert.Equal(1, board.CheckWinningState());
        }

        [Fact]
        public void CanCheckHorizontalVictory()
        {
            // Arrange
            Board board = new Board();

            // Act
            board.MarkSquare(4, 1);
            board.MarkSquare(5, 1);
            board.MarkSquare(6, 1);

            // Assert
            Assert.Equal(1, board.CheckWinningState());
        }

        [Fact]
        public void CanCheckVerticalVictory()
        {
            // Arrange
            Board board = new Board();

            // Act
            board.MarkSquare(2, 0);
            board.MarkSquare(5, 0);
            board.MarkSquare(8, 0);

            // Assert
            Assert.Equal(0, board.CheckWinningState());
        }

        [Fact]
        public void CannotGiveFalseVictory()
        {
            // Arrange
            Board board = new Board();

            // Act
            board.MarkSquare(1, 1);
            board.MarkSquare(2, 0);
            board.MarkSquare(3, 0);
            board.MarkSquare(4, 0);
            board.MarkSquare(5, 1);
            board.MarkSquare(6, 1);
            board.MarkSquare(7, 1);
            board.MarkSquare(8, 0);
            board.MarkSquare(9, 0);

            // Assert
            Assert.Equal(-1, board.CheckWinningState());
        }

        [Fact]
        public void CanCreateArtString()
        {
            // Arrange
            Board board = new Board();

            Player[] players = new Player[2] {
                new Player('B', "Bob"),
                new Player('J', "Joan")
            };

            StringBuilder expectedStringBuilder = new StringBuilder();
            expectedStringBuilder.AppendLine("|1||2||3|");
            expectedStringBuilder.AppendLine("|J||5||6|");
            expectedStringBuilder.AppendLine("|7||8||9|");

            // Act
            board.MarkSquare(4, 1);

            // Assert
            Assert.Equal(expectedStringBuilder.ToString(),
                board.CreateArtString(players));
        }
    }
}
