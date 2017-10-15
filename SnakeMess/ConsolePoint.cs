namespace SnakeMess
{
    public class ConsolePoint
    {
        
        public int X { get; set; } 
        public int Y { get; set; }
        
        public ConsolePoint(int x = 10, int y = 10) { X = x; Y = y; }
        
        public ConsolePoint(ConsolePoint input) { X = input.X; Y = input.Y; }

        
        public static bool CompareTwoPoints(ConsolePoint point1, ConsolePoint point2)
        {
            if ( point1.X == point2.X && point1.Y == point2.Y )
                return true;

            return false;
        }    
      
    }        
}