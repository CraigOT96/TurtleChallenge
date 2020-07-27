using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleChallenge.Classes
{
    public class Turtle
    {
        public string Direction { get; set; }
        public string Location { get; set; }
        public bool IsDead { get; set; } = false;
        public void ChangeDirection()
        {
            switch (Direction)
            {
                case "N":
                    Direction = "E";
                    break;
                case "E":
                    Direction = "S";
                    break;
                case "S":
                    Direction = "W";
                    break;
                case "W":
                    Direction = "N";
                    break;
            }
        }

        public int[] GetNewLocation()
        {
            int[] Coordinates = Location.Split(',').Select(h => Int32.Parse(h)).ToArray();

            switch (Direction)
            {
                case "N":
                    Coordinates[1] = Coordinates[1] - 1;
                    break;
                case "E":
                    Coordinates[0] = Coordinates[0] + 1;
                    break;
                case "S":
                    Coordinates[1] = Coordinates[1] + 1;
                    break;
                case "W":
                    Coordinates[0] = Coordinates[0] - 1;
                    break;
            }

            return Coordinates;
        }

        public void MoveTurtle()
        {
            int[] Coordinates = GetNewLocation();

            Location = Coordinates[0] + "," + Coordinates[1];
        }
    }
}
