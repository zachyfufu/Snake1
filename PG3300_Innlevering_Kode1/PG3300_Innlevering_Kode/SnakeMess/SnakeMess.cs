using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace SnakeMess
{
	class Position
	{
		public const string Ok = "Ok";

		public int x; public int y;
		public Position(int x = 0, int y = 0)
        {
            this.x = x; this.y = y;
        }
		public Position(Position input)
        {
            x = input.x; y = input.y;
        }
	}
	// Stuff
	class SnakeMess
	{
		public static void Main(string[] arguments)
		{

            Console.Title = "Westerdals Oslo ACT - SNAKE";

            bool gg = false, pause = false, inUse = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
			int boardW = Console.WindowWidth, boardH = Console.WindowHeight;
			Random rnd = new Random();
			Position pos = new Position();
			List<Position> snake = new List<Position>();
			snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
			Console.CursorVisible = false;
			Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(10, 10); Console.Write("@");
			while (true) {
				pos.x = rnd.Next(0, boardW); pos.y = rnd.Next(0, boardH);
				bool spot = true;
				foreach (Position i in snake)
					if (i.x == pos.x && i.y == pos.y) {
						spot = false;
						break;
					}
				if (spot) {
					Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(pos.x, pos.y); Console.Write("$");
					break;
				}
			}
			Stopwatch t = new Stopwatch();
			t.Start();
			while (!gg) {
				if (Console.KeyAvailable) {
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						gg = true;
					else if (cki.Key == ConsoleKey.Spacebar)
						pause = !pause;
					else if (cki.Key == ConsoleKey.UpArrow && last != 2)
						newDir = 0;
					else if (cki.Key == ConsoleKey.RightArrow && last != 3)
						newDir = 1;
					else if (cki.Key == ConsoleKey.DownArrow && last != 0)
						newDir = 2;
					else if (cki.Key == ConsoleKey.LeftArrow && last != 1)
						newDir = 3;
				}
				if (!pause) {
					if (t.ElapsedMilliseconds < 100)
						continue;
					t.Restart();
					Position tail = new Position(snake.First());
					Position head = new Position(snake.Last());
					Position newH = new Position(head);
					switch (newDir) {
						case 0:
							newH.y -= 1;
							break;
						case 1:
							newH.x += 1;
							break;
						case 2:
							newH.y += 1;
							break;
						default:
							newH.x -= 1;
							break;
					}
					if (newH.x < 0 || newH.x >= boardW)
						gg = true;
					else if (newH.y < 0 || newH.y >= boardH)
						gg = true;
					if (newH.x == pos.x && newH.y == pos.y) {
						if (snake.Count + 1 >= boardW * boardH)
							// No more room to place apples - game over.
							gg = true;
						else {
							while (true) {
								pos.x = rnd.Next(0, boardW); pos.y = rnd.Next(0, boardH);
								bool found = true;
								foreach (Position i in snake)
									if (i.x == pos.x && i.y == pos.y) {
										found = false;
										break;
									}
								if (found) {
									inUse = true;
									break;
								}
							}
						}
					}
					if (!inUse) {
						snake.RemoveAt(0);
						foreach (Position x in snake)
							if (x.x == newH.x && x.y == newH.y) {
								// Death by accidental self-cannibalism.
								gg = true;
								break;
							}
					}
					if (!gg) {
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.x, head.y); Console.Write("0");
						if (!inUse) {
							Console.SetCursorPosition(tail.x, tail.y); Console.Write(" ");
						} else {
							Console.ForegroundColor = ConsoleColor.Green; Console.SetCursorPosition(pos.x, pos.y); Console.Write("$");
							inUse = false;
						}
						snake.Add(newH);
						Console.ForegroundColor = ConsoleColor.Yellow; Console.SetCursorPosition(newH.x, newH.y); Console.Write("@");
						last = newDir;
					}
				}
			}
		}
	}
}