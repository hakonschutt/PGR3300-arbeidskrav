//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Web;
//
//namespace SnakeMess
//{
//    public class SnakeGame
//    {
//	    private bool _goodGame = false;
//	    private bool _pause = false; 
//		private bool _inUse = false;
//	    private List<ConsolePoint> _snake;
//	    private ConsolePoint _apple;
//	    private ConsolePoint _snakeHead;
//	    private int _newDir;
//	    private GameConsole _console;
//	    private Stopwatch _timer;
//
////	    public static void Main(string[] args)
////	    {
////		    SnakeGame game = new SnakeGame();
////	    }
//	    
//		// Sets the snake body when game is initilized
//	    private void SetSnake()
//	    {
//		    _snake = new List<ConsolePoint>();
//			
//		    _snake.Add(new ConsolePoint()); 
//		    _snake.Add(new ConsolePoint()); 
//		    _snake.Add(new ConsolePoint()); 
//		    _snake.Add(new ConsolePoint());
//	    }
//
//	    // Sets apple in an open position
//	    private void SetApple()
//	    {
//		    int[] applePoints = VerifyApplePosition();
//		    _apple = new ConsolePoint(applePoints[0], applePoints[1]);
//		    _console.writeConsolePoint(true, _apple.X, _apple.Y, "$");
//	    }
//
//	    // Verifies that the position of the apple is available
//	    private int[] VerifyApplePosition()
//	    {
//		    Random rng = new Random();
//		    int[] applePoints = new int[2];
//
//		    bool appleCanBePlaced = true;
//
//		    while (true)
//		    {
//			    applePoints[0] = rng.Next(0, _console.BoardWidth);
//			    applePoints[1] = rng.Next(0, _console.BoardHeight);
//
//			    foreach (ConsolePoint i in _snake)
//			    {
//				    if ( i.X == applePoints[0] && i.Y == applePoints[1])
//				    {
//					    appleCanBePlaced = false;
//					    break;
//				    }
//			    }
//
//			    if (appleCanBePlaced)
//				    break;
//		    }
//
//		    return applePoints;
//	    }
//
//	    // Checks if the snake has eaten itself 
//	    public void checkSnakeDeath()
//	    {
//		    _snake.RemoveAt(0);
//
//		    foreach (ConsolePoint x in _snake)
//		    {
//			    if (ConsolePoint.CompareTwoPoints( x , _snakeHead ))
//			    {
//				    // Death by accidental self-cannibalism.
//				    _goodGame = true;
//				    break;
//			    }   
//		    }
//	    }
//
//	    // Intial game method for class SnakeGame
//	    public void PlayGame()
//	    {
//		    while (!_goodGame)
//		    {
//			    // Resets the timer every time so the console only writes every 100milisecond
//			    if (_timer.ElapsedMilliseconds < 100)
//			    {
//				    continue;
//			    }
//
//			    _timer.Restart();
//
//			    ConsolePoint tail = new ConsolePoint(_snake.First());
//			    ConsolePoint head = new ConsolePoint(_snake.Last());
//			    ConsolePoint newH = new ConsolePoint(head);
//
//			    // New direction for the snake if keystrokes have been made
//			    switch (_newDir)
//			    {
//				    case 0:
//					    newH.Y -= 1;
//					    break;
//				    case 1:
//					    newH.X += 1;
//					    break;
//				    case 2:
//					    newH.Y += 1;
//					    break;
//				    default:
//					    newH.X -= 1;
//					    break;
//			    }
//
//			    // Checks if the snake has gone of bound 
//			    if (newH.X < 0 || newH.X >= _console.BoardWidth)
//				    _goodGame = true;
//
//			    // Checks if the snake has gone of bound
//			    else if (newH.Y < 0 || newH.Y >= _console.BoardHeight)
//				    _goodGame = true;
//
//			    // Checks if the snake head and apple has the same positon (snake has eaten apple)
//			    if (ConsolePoint.CompareTwoPoints(newH, _apple))
//			    {
//				    if (_snake.Count + 1 >= _console.BoardWidth * _console.BoardHeight)
//					    // No more room to place apples - game over.
//					    _goodGame = true;
//				    else
//				    {
//					    SetApple();
//					    _inUse = true;
//				    }
//			    }
//
//			    if (!_inUse)
//			    {
//				    checkSnakeDeath();
//			    }
//
//			    // If game is not over, coninue writing to console
//			    if (!_goodGame)
//			    {
//
//				    // writes a new body part at the head of the snake
//				    _console.writeConsolePoint(false, head.X, head.Y, "0");
//
//				    if (!_inUse)
//				    {
//
//					    // Writes a empty tail, so the snake looks to be same size as earlier
//					    _console.writeConsolePoint(tail.X, tail.Y, " ");
//
//				    }
//				    else
//				    {
//
//					    // writes a apple if the snake has just eaten one 
//					    _console.writeConsolePoint(true, _apple.X, _apple.Y, "$");
//					    _inUse = false;
//
//				    }
//
//				    // Addes a new head to the snake given that we overwrote the old on earlier
//				    _snake.Add(newH);
//				    _console.writeConsolePoint(false, newH.X, newH.Y, "@");
//
//			    }
//		    }
//	    }
//
//	    // Sets game objects 
//	    public SnakeGame()
//		{	
//			
//			_console = new GameConsole();
//			
//			_timer = new Stopwatch();
//			_timer.Start();
//			
//			SetSnake();
//			SetApple();
//			
//			while (!_goodGame) {
//				if (Console.KeyAvailable) {
//					ConsoleKeyInfo cki = Console.ReadKey(true);
//					_goodGame = _console.checkQuitGame(cki);
//					_pause = _console.checkPauseGame(cki, _pause);
//					_newDir = _console.checkDirectionChange(cki, _newDir);
//				}
//				if (!_pause) {
//					PlayGame();	
//				}
//			}
//		}
//    }
//}