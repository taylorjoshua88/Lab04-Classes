using System;
using Xunit;
using TicTacToe;

namespace TicTacToeTest
{
    public class PlayerTest
    {
        [Fact]
        public void CanSetName()
        {
            // Arrange
            Player player = new Player('X', "Jill");
            string oldName = string.Copy(player.Name);

            // Act
            player.Name = "Jacob";

            // Assert
            Assert.NotEqual(oldName, player.Name);
        }

        [Fact]
        public void CannotSetEmptyName()
        {
            // Arrange ---
            // This test is to validate the Name setter, not the Player
            // constructor. Creating a good player object ensures this test
            // applies specifically to the setter and not something else
            Player player = new Player('G', "June");

            // Act + Assert
            Assert.Throws<ArgumentException>(() => player.Name = "");
        }

        [Fact]
        public void CanSetToken()
        {
            // Arrange
            Player player = new Player('@', "Jack");
            char oldToken = player.Token;

            // Act
            player.Token = 'F';

            // Assert
            Assert.NotEqual(oldToken, player.Token);
        }

        [Theory]
        [InlineData('2')]
        [InlineData('5')]
        [InlineData(' ')]
        [InlineData('\t')]
        public void TokenValidationTest(char badToken)
        {
            // Arrange ---
            // This test is to validate the Token setter, not the Player
            // constructor. Creating a good player object ensures this test
            // applies specifically to the setter and not something else
            Player player = new Player('G', "June");

            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(
                () => player.Token = badToken);
        }

        // NOTE(taylorjoshua88): Could include tests for getting Name and Token
        //                       but this would likely be overkill for the
        //                       purposes of this assignment.
    }
}
