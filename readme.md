# TicTacToe

**Author**: Joshua Taylor
**Version**: 1.0.0

## Overview

TicTacToe is a turn-based game played on a 3x3 grid of squares. Players take
turns marking squares with their unique, single-letter token which shows that
they own that square. Once a player has completed a full row, column, or
diagonal on the board, that player wins the game. If no player has completed
any rows after all of the squares have been taken, then the game ends in a tie.

## Getting Started

TicTacToe targets the .NET Core 2.0 platform. The .NET Core 2.0 SDK can
be downloaded from the following URL for Windows, Linux, and macOS:

https://www.microsoft.com/net/download/

The dotnet CLI utility would then be used to build and run the application:

    cd TicTacToe
    dotnet build
    dotnet run

Additionally, users can build, run, and perform unit testing using Visual
Studio 2017 or greater by opening the solution file at the root of this
repository.

## Example

#### Starting a New Game ####
![New Game Screenshot](/assets/newGameScreenshot.JPG)
#### Taking a Turn ####
![Taking a Turn Screenshot](/assets/turnScreenshot.JPG)
#### Victory ####
![Victory Screenshot](/assets/victoryScreenshot.JPG)

## Architecture

TicTacToe uses C# and the .NET Core 2.0 platform. Squares are stored as an
array of integers representing which player owns that square (or -1 if no
player currently owns that square). Gameplay continues until a winning board
state has been achieved (one player has completed a row, column, or diagonal),
determined using the Board.CheckWinningState() method.

The gameplay UI is handled through a command line interface on the console
provided via the System namespace.

### Data Model

TicTacToe stores the game's state using objects stored in memory from three
primary classes: Game, Board, Player. No data persistence is supported by
this game.

#### Game ####

The Game class contains a single game session's complete state through a
Board object and two Player objects stored as an array. The game class
provides a static method to prompt players for their names and selected
tokens in addition to a method which takes control of the calling thread
to run a game loop until the game's completion. Players are notified of
a winner or a tie depending on the state of the board.

#### Board ####

The Board class represents the 3x3 matrix of squares which the players
take turns marking for themselves. The squares are stored as a
one-dimensional array with 9 elements (3 rows * 3 columns). Methods are
available to check the owner of a particular square (if applicable),
mark a square for a particular player, and to check for a winning game
state.

#### Player ####

The Player class holds information related to each player playing the game.
A string representing the player's given name along with a single character
representing that player's chosen token is stored on objects of this class.
These properties are used by the Board class to draw an ASCII art
representation of the game board as well as by the Game class in order to
tell the players whose turn it is and/or who is the winner of the game.

### Command Line Interface (CLI)

TicTacToe operates as an infinite loop after gathering the player's names
and chosen tokens. Each iteration of the loop has the board written to the
console as well as a prompt for the current player to choose a square from
a selection of 9 squares. Each square has been assigned a number 1-9 which
is used to identify one square from another. Input is provided by the 
keyboard using the .NET System.Console class.

### Game Logic

Each iteration of the game loop has a call to Board.CheckWinningState().
This method checks each column, row, and diagonal for a winner by iterating
through the game's Board object's Squares array. Players are not allowed to
select squares that another player already owns. Once a winner (or a tie) has
been determined using the Board.CheckWinningState() method, the game is over
and prompts if the players would like to play another session. If the game
has not been won yet, this process repeats until there are no more squares,
which is interpreted as a tie.

## Change Log

* 3.23.2018 [Joshua Taylor](mailto:taylor.joshua88@gmail.com) - Initial
release. All tests are passing.