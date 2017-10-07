using System.Globalization;

namespace SnakeMess
{
    public class ConsolePoint
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point( int x = 10, int y = 10 )
        {
            X = x; Y = y;
        }

        public Point(Point input)
        {
            X = input.X; Y = input.Y;
        }

        public bool compareTwoPoints(Point x, Point y)
        {
            if ( x.X == y.X && x.Y == y.Y )
                return true;

            return false;
        }
    }
}