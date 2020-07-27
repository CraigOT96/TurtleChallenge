using System;
using System.IO;
using TurtleChallenge.Classes;

namespace TurtleChallenge
{
    class Program
    {
        public static MineField Board;

        static void Main(string[] args)
        {
            Console.WriteLine("Setting up game board!");

            SetupGame();

            Console.WriteLine("Reading moves!");
            
            PlayGame();

            Console.ReadKey();
        }

        public static void PlayGame()
        {
            //string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DataFiles\\MovesFail.txt"));
            //string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DataFiles\\MovesInvalidInput.txt"));
            //string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DataFiles\\MovesNoExitOrMine.txt"));
            //string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DataFiles\\MovesOutOfBounds .txt"));
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DataFiles\\MovesWin.txt"));

            foreach (string line in lines)
            {
                if(line == "R")
                {
                    Board.GameTurtle.ChangeDirection();
                    Console.WriteLine("The turtle changed direction!");
                }
                else if (line == "M")
                {
                    Board.MoveTurtle();

                    if(Board.IsGameWon)
                    {
                        Console.WriteLine("Game is won, congratualtions!");
                        Board.PrintBoard();
                        break;
                    }
                    else if (Board.GameTurtle.IsDead)
                    {
                        Console.WriteLine("Game is over, better luck next time!");
                        Board.PrintBoard();
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid move!");
                }

                Board.PrintBoard();
            }
        }

        public static void SetupGame()
        {
            string[] lines = File.ReadAllLines(Path.Combine(Directory.GetCurrentDirectory(), "DataFiles\\GameSettings.txt"));

            Board = new MineField();

            string[] BoardDimensions = lines[0].Split(',');

            Board.SetupBoard(int.Parse(BoardDimensions[0]), int.Parse(BoardDimensions[1]));

            Console.WriteLine("Board Setup with dimensions " + lines[0] + "!");

            Turtle GameTurtle = new Turtle();

            GameTurtle.Direction = lines[2];
            GameTurtle.Location = lines[1];

            string[] TurtleLocation = lines[1].Split(',');

            Board.SetupTurtle(int.Parse(TurtleLocation[0]), int.Parse(TurtleLocation[1]));

            Board.GameTurtle = GameTurtle;

            Console.WriteLine("Turtle Setup at location " + lines[1] + " in direction " + lines[2] + "!");

            string[] BoardExit = lines[3].Split(',');

            Board.SetupExit(int.Parse(BoardExit[0]), int.Parse(BoardExit[1]));

            Console.WriteLine("Board exit at " + lines[3] + "!");

            string[] MineLocations = lines[4].Split(',');

            Board.SetupMines(MineLocations);

            Console.WriteLine("Mine(s) setup at " + lines[4] + "!");

            Board.PrintBoard();

            Console.WriteLine("Game Setup!");
        }
    }
}
