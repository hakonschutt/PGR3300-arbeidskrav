using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SnakeMess
{
    public class SnakeGame
    {
        private bool _endGame,
            _pause,
            _occupiedCoordinate = false;

        private short _direction = 2; // 0 = up, 1 = right, 2 = down, 3 = left    
        private List<ConsolePoint> _snake;
        private ConsolePoint _snakeHead;
        private ConsolePoint _food;
        private GameConsole _gameConsole;
        private ConsolePoint _newSnakeHead;

        public SnakeGame()
        {
            _gameConsole = new GameConsole();
            CreateSnake();
            SetFood();
            StartGame();
        }

        private void StartGame()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            while (!_endGame)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo consoleKeyInfo = Console.ReadKey(true);
                    GameController(consoleKeyInfo);
                }
                if (!_pause)
                {
                    if (timer.ElapsedMilliseconds < 100)
                        continue;
                    timer.Restart();
                   
                    //deklarerer snakehead
                    _snakeHead = _snake.Last();
                    placeNewHeadOfSnake();
                    outOfField();
                    foodIsEaten();

                    if (!_occupiedCoordinate)
                        RemoveTail();
                    
                    

                    if (!_endGame)
                    {
                        writeObject('0', _snakeHead);
                        if (!_occupiedCoordinate)
                        {
                            writeObject(' ', _snake.First());
                        }
                        else
                        {
                            SetFood();
                            writeObject('$', _food);
                            _occupiedCoordinate = false;
                        }
                        _snake.Add(_newSnakeHead);
                        writeObject('@', _newSnakeHead);
                    }
                }
            }
        }

        private void foodIsEaten()
        {
            if (ConsolePoint.CompareTwoPoints(_food, _newSnakeHead))
            {
                _occupiedCoordinate = true;
            }
        }

        private void placeNewHeadOfSnake()
        {
            _newSnakeHead = new ConsolePoint(_snake.Last());
            switch (_direction)
            {
                case 0:
                    _newSnakeHead.Y -= 1;
                    break;
                case 1:
                    _newSnakeHead.X += 1;
                    break;
                case 2:
                    _newSnakeHead.Y += 1;
                    break;
                default:
                    _newSnakeHead.X -= 1;
                    break;
            }
        }
        

        private void outOfField()
        {
            bool legalBoardWidth = _newSnakeHead.X < 0 || _newSnakeHead.X >= _gameConsole.BoardWidth;
            bool legalBoardHeight = _newSnakeHead.Y < 0 || _newSnakeHead.Y >= _gameConsole.BoardHeight;
            if (legalBoardHeight || legalBoardWidth)
            {
                _endGame = true;
            }
        }


        private void RemoveTail()
        {
            _snake.RemoveAt(0);
            foreach (ConsolePoint consolePointInSnake in _snake)
                if (ConsolePoint.CompareTwoPoints(_newSnakeHead, consolePointInSnake))
                {
                    _endGame = true;
                    break;
                }
        }


        private void GameController(ConsoleKeyInfo consoleKeyInfo)
        {
            if (consoleKeyInfo.Key == ConsoleKey.Escape)
                _endGame = true;
            else if (consoleKeyInfo.Key == ConsoleKey.Spacebar)
                _pause = !_pause;
            else if (consoleKeyInfo.Key == ConsoleKey.UpArrow && _direction != 2)
                _direction = 0;
            else if (consoleKeyInfo.Key == ConsoleKey.RightArrow && _direction != 3)
                _direction = 1;
            else if (consoleKeyInfo.Key == ConsoleKey.DownArrow && _direction != 0)
                _direction = 2;
            else if (consoleKeyInfo.Key == ConsoleKey.LeftArrow && _direction != 1)
                _direction = 3;
        }


        private void CreateSnake()
        {
            _snake = new List<ConsolePoint>();
            _snake.Add(new ConsolePoint());
            _snake.Add(new ConsolePoint());
            _snake.Add(new ConsolePoint());
            _snake.Add(new ConsolePoint());
        }

        private void SetFood()
        {
            bool foodCanBePlaced;
            Random rand = new Random();
            int x, y;
            while (true)
            {
                foodCanBePlaced = true;
                x = rand.Next(0, _gameConsole.BoardWidth);
                y = rand.Next(0, _gameConsole.BoardHeight);
                _food = new ConsolePoint(x, y);
                foreach (ConsolePoint consolePoint in _snake)
                {
                    if (ConsolePoint.CompareTwoPoints(_food, consolePoint))
                    {
                        if (_snake.Count + 1 >= _gameConsole.BoardWidth * _gameConsole.BoardHeight)
                            _endGame = true;
                        
                        foodCanBePlaced = false;
                        break;
                    }
                }
                if (foodCanBePlaced)
                {
                    _occupiedCoordinate = true;
                    break;
                }
            }
        }

        private void writeObject(char symbol, ConsolePoint consolePoint)
        {
            _gameConsole.writeConsoleObject(symbol, consolePoint.X, consolePoint.Y);
        }
    }
}