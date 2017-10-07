using System;

namespace SnakeMess
{    
    public class Console
    {

        private int _width;
        private int _height;
        
        // Seter and getter for board with
        public int BoardWidth
        {
            get { return _width; }
            set{ _width = Console.WindowHeight; }
        }

        // setter and getter for board height
        public int BoardHeight
        {
            get { return _height; }
            set{ _height = Console.WindowHeight; }
        }

        // Initial method that sets game elements
        public Console() 
        {
            Console.CursorVisible = false;
            Console.Title = "Westerdals Oslo ACT - SNAKE";
            writeConsolePoint(true, 10, 10, "@");
        }
        
        // Method to write to console with color
        public void writeConsolePoint(bool isGreen, int x, int y, String character)
        {
            if (isGreen)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Yellow;

            writeConsolePoint(x, y, character);            
        }

        // Method to write to console without color
        public void writeConsolePoint(int x, int y, String character)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(character);
        }

        // check if user wants to end game 
        public bool checkQuitGame( ConsoleKeyInfo cki )
        {
            if (cki.Key == ConsoleKey.Escape)
                return true;
            return false;
        }

        // Check if user wants to pause game 
        public bool checkPauseGame( ConsoleKeyInfo cki, bool pauseState)
        {
            if (cki.Key == ConsoleKey.Spacebar)
                return !pauseState;

            return pauseState;
        }

        // Check if user wants to change direction of the snake
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