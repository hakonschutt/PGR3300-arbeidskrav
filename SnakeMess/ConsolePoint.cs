using System.Globalization;

namespace SnakeMess
{
    public class ConsolePoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        // Sets point position
        public ConsolePoint( int x = 10, int y = 10 )
        {
            X = x; Y = y;
        }

        // Sets point position based on another point objet
        public ConsolePoint(ConsolePoint input)
        {
            X = input.X; Y = input.Y;
        }

        // Compares two points
        public static bool CompareTwoPoints(ConsolePoint x, ConsolePoint y)
        {
            if ( x.X == y.X && x.Y == y.Y )
                return true;

            return false;
        }
    }
}