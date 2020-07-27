using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace TurtleChallenge.Classes
{
    public class MineField
    {
        public MineSquare[,] Board { get; set; }
        public Turtle GameTurtle { get; set; }
        public bool IsGameWon { get; set; } = false;

        public void SetupBoard(int x, int y)
        {
            Board = new MineSquare[x, y];

            for (int i = 0; i < Board.GetLength(0); i++)
            {
                for (int j = 0; j < Board.GetLength(1); j++)
                {
                    Board[i, j] = new MineSquare();
                }
            }
        }

        public void SetupExit(int x, int y)
        {
            Board[x, y].IsExit = true;
        }

        public void SetupTurtle(int x, int y)
        {
            Board[x, y].IsTurtle = true;
        }

        public void SetupMines(string[] mines)
        {
            foreach (string mine in mines)
            {
                string[] MineLocation = mine.Split(' ');

                Board[int.Parse(MineLocation[0]), int.Parse(MineLocation[1])].IsMine = true;
            }
        }

        public void MoveTurtle()
        {
            switch (GameTurtle.Direction)
            {
                case "N":
                    ValidMove();
                    break;
                case "E":
                    ValidMove();
                    break;
                case "S":
                    ValidMove();
                    break;
                case "W":
                    ValidMove();
                    break;
            }
        }

        public void RotateTurtle()
        {
            GameTurtle.ChangeDirection();
        }

        public void PrintBoard()
        {
            Console.WriteLine(RowSeperator(Board.GetLength(0)));

            for (int i = 0; i < Board.GetLength(1); i++)
            {
                for (int j = 0; j < Board.GetLength(0); j++)
                {
                    Console.Write("| " + PrintSquare(j, i) + " |");
                }

                Console.WriteLine();

                Console.WriteLine(RowSeperator(Board.GetLength(0)));
            }
        }

        public string PrintSquare(int x, int y)
        {
            if (Board[x, y].IsExit)
            {
                return "E";
            }
            else if (Board[x, y].IsMine)
            {
                return "M";
            }
            else if (Board[x, y].IsTurtle)
            {
                return "T";
            }
            else
            {
                return " ";
            }
        }

        public string RowSeperator (int count)
        {
            string LineBreaker = "";

            for(int i = 0; i < count; i++)
            {
                LineBreaker += "-----";
            }

            return LineBreaker;
        }

        public void ValidMove()
        {
            if(CheckIfOutOfBounds())
            {
                Console.WriteLine("Move would put turtle out of bounds, invalid move.");
            }
            else
            {
                int[] currentLocation = GameTurtle.Location.Split(',').Select(h => Int32.Parse(h)).ToArray();

                int[] newLocation = GameTurtle.GetNewLocation();

                GameTurtle.MoveTurtle();

                Board[currentLocation[0], currentLocation[1]].IsTurtle = false;
                Board[newLocation[0], newLocation[1]].IsTurtle = true;

                if(Board[newLocation[0], newLocation[1]].IsMine)
                {
                    Console.WriteLine("The turtle stepped on a mine!");
                    Board[newLocation[0], newLocation[1]].IsMine = false;
                    GameTurtle.IsDead = true;
                }
                else if (Board[newLocation[0], newLocation[1]].IsExit)
                {
                    Console.WriteLine("The turtle made it to the exit!");
                    Board[newLocation[0], newLocation[1]].IsExit = false;
                    IsGameWon = true;
                }
                else
                {
                    Console.WriteLine("The turtle moved safely!");
                }
            }
        }

        public bool CheckIfOutOfBounds()
        {
            int[] Coordinates = GameTurtle.GetNewLocation();

            if(Coordinates[0] < 0 || Coordinates[1] < 0)
            {
                return true;
            }

            return false;
        }
    }
}
