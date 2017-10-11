using System;

namespace SnakeMess
{
    public class GameConsole
    {
        public int BoardHeight { get; set; }
        public int BoardWidth { get; set; }

        public GameConsole()
        {
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            writeConsoleObject('@', 10, 10);
            BoardHeight = Console.WindowHeight;
            BoardWidth = Console.WindowWidth;
        }
        
        public void writeConsoleObject(char write, int x, int y)
        {
            if (write == '$')
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.SetCursorPosition(x, y);
            Console.Write(write);
            
        }


//        public void writeConsoleObject(string write, int x, int y)
//        {
//            Console.SetCursorPosition(x, y);
//            Console.Write(write);
//        }
        
        
    }
}