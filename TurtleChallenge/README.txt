The game is setup from the GameSettings.txt file. It should work with any settings file in this format but it will not be able to handle bad data e.g setting a turtle or a mine out of bounds.

There is multiple input files that achieve differewnt outcomes in the code. There are:

	MovesFail -- Turtle hits mine and the game ends.
	MovesInvalidInput -- Turtle doesn't win or lose but highlights that the game handles bad moves inputs.
	MovesNoExitOrMine -- Turtle doesn't win or lose.
	MovesOutOfBounds -- Turtle doesn't win or lose but hightlights that they cant go out of bounds.
	MovesWin -- Turtle exits and win stopping game there.