﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SnakeMess
{
    public class SnakeGame
    {
	    private bool _goodGame = false;
	    private bool _pause = false; 
		private bool _inUse = false;
	    private List<ConsolePoint> _snake;
	    private ConsolePoint _apple;
	    private ConsolePoint _snakeHead;
	    private int _newDir;
	    private Console _console;
	    private Stopwatch _timer;

	    private void SetSnake()
	    {
		    _snake = new List<ConsolePoint>();
			
		    _snake.Add(new ConsolePoint()); 
		    _snake.Add(new ConsolePoint()); 
		    _snake.Add(new ConsolePoint()); 
		    _snake.Add(new ConsolePoint());
	    }

	    private void SetApple()
	    {
		    int[] applePoints = VerifyApplePosition();
		    _apple = new ConsolePoint(applePoints[0], applePoints[1]);
		    _console.writeConsolePoint(true, _apple.X, _apple.Y, "$");
	    }

	    private int[] VerifyApplePosition()
	    {
		    Random rng = new Random();
		    int[] applePoints = new int[2];

		    bool appleCanBePlaced = true;

		    while (true)
		    {
			    applePoints[0] = rng.Next(0, _console.BoardWidth);
			    applePoints[1] = rng.Next(0, _console.BoardHeight);

			    foreach (ConsolePoint i in _snake)
			    {
				    if (i.X == applePoints[0] && i.Y == applePoints[1])
				    {
					    appleCanBePlaced = false;
					    break;
				    }
			    }

			    if (appleCanBePlaced)
				    break;
		    }

		    return applePoints;
	    }

	    public void checkSnakeDeath()
	    {
		    _snake.RemoveAt(0);

		    foreach (Point x in _snake)
		    {
			    if (x.X == _snakeHead.X && x.Y == _snakeHead.Y) {
				    // Death by accidental self-cannibalism.
				    _goodGame = true;
				    break;
			    }   
		    }
	    }

	    public void PlayGame()
	    {
		    if (_timer.ElapsedMilliseconds < 100)
			    continue;
		    _timer.Restart();
					
		    ConsolePoint tail = new ConsolePoint(_snake.First());
		    ConsolePoint head = new ConsolePoint(_snake.Last());
		    ConsolePoint newH = new ConsolePoint(head);
					
		    switch (_newDir) {
			    case 0:
				    newH.Y -= 1;
				    break;
			    case 1:
				    newH.X += 1;
				    break;
			    case 2:
				    newH.Y += 1;
				    break;
			    default:
				    newH.X -= 1;
				    break;
		    }
					
		    if (newH.X < 0 || newH.X >= _console.BoardWidth)
			    _goodGame = true;
					
		    else if (newH.Y < 0 || newH.Y >= _console.BoardHeight)
			    _goodGame = true;
					
		    if (newH.X == _apple.X && newH.Y == _apple.Y) {
			    if (_snake.Count + 1 >= _console.BoardWidth * _console.BoardHeight)
				    // No more room to place apples - game over.
				    _goodGame = true;
			    else {
				    SetApple();
				    _inUse = true;
			    }
		    }
		    
		    if (!_inUse) {
			    checkSnakeDeath();
		    }
		    
		    if (!_goodGame) {
			    
			    _console.writeConsolePoint(false, head.X, head.Y, "0");
			    
			    if (!_inUse) {
				    
				    _console.writeConsolePoint(tail.X, tail.Y, " ");
				    
			    } else {
				    
				    _console.writeConsolePoint(true, _apple.X, _apple.Y, "$");
				    _inUse = false;
				    
			    }
			    
			    _snake.Add(newH);
			    _console.writeConsolePoint(false, newH.X, newH.Y, "@");
			    
		    }
	    }

	    public SnakeGame()
		{	
			SetSnake();
			SetApple();
			_console = new Console();
			
			_timer = new Stopwatch();
			_timer.Start();
			
			while (!_goodGame) {
				if (Console.KeyAvailable) {
					ConsoleKeyInfo cki = Console.ReadKey(true);
					_goodGame = _console.checkQuitGame(cki);
					_pause = _console.checkPauseGame(cki, _pause);
					_newDir = _console.checkDirectionChange(cki, _newDir);
				}
				if (!_pause) {
					PlayGame();	
				}
			}
		}
    }
}