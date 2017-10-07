using System;

namespace SnakeMess
{    
    public class Console
    {

        private int _width;
        private int _height;
        
        public int BoardWidth
        {
            get { return _width; }
            set{ _width = Console.WindowHeight; }
        }

        public int BoardHeight
        {
            get { return _height; }
            set{ _height = Console.WindowHeight; }
        }

        public Console() 
        {
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            writeConsolePoint(true, 10, 10, "@");
        }

        public void writeConsolePoint(bool isGreen, int x, int y, String character)
        {
            if (isGreen)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;
            
            Console.SetCursorPosition(x, y);
            Console.Write(character);            
        }

        public void writeConsolePoint(int x, int y, String character)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(character);
        }

        public bool checkQuitGame( ConsoleKeyInfo cki )
        {
            if (cki.Key == ConsoleKey.Escape)
                return true;
            return false;
        }

        public bool checkPauseGame( ConsoleKeyInfo cki, bool pauseState)
        {
            if (cki.Key == ConsoleKey.Spacebar)
                return !pauseState;

            return pauseState;
        }

        public int checkDirectionChange( ConsoleKeyInfo cki, int last )
        {
            if (cki.Key == ConsoleKey.UpArrow && last != 2)
                return 0;
            else if (cki.Key == ConsoleKey.RightArrow && last != 3)
                return 1;
            else if (cki.Key == ConsoleKey.DownArrow && last != 0)
                return 2;
            else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
                return 3;

            return -1; 
        } 
    }
}