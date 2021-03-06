﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace SnakeMess
{
	

	class SnakeMess
	{


        public static void Main(string[] arguments)
		{
            Console.Title = "Westerdals Oslo ACT - SNAKE";

            bool dead = false, pause = false;
			short newDir = 2; // 0 = up, 1 = right, 2 = down, 3 = left
			short last = newDir;
           

            Window win = new Window();
            Position pos = new Position();
            End death = new End();
            


          
			Console.CursorVisible = false;
            
            Random rnd = new Random();
            win.Snake();
            win.Food();

			Stopwatch t = new Stopwatch();
			t.Start();
			while (!dead) {
				if (Console.KeyAvailable) {
					ConsoleKeyInfo cki = Console.ReadKey(true);
					if (cki.Key == ConsoleKey.Escape)
						dead = true;
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
					Position tail = new Position(win.list.First());
					Position head = new Position(win.list.Last());
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

                    death.DeathOptions();


                    /*
					if (newH.x < 0 || newH.x >= win.BoardW)
						dead = true;
					else if (newH.y < 0 || newH.y >= win.BoardH)
						dead = true;
					if (newH.x == pos.x && newH.y == pos.y)
                    {
                        if (win.list.Count + 1 >= win.BoardW * win.BoardH)
                        {
                            // No more room to place apples - game over.
                            dead = true;
                        }
                        else
                        {
                            while (true)
                            {
                                pos.x = rnd.Next(0, win.BoardW);
                                pos.y = rnd.Next(0, win.BoardH);
                                bool found = true;
                                foreach (Position i in win.list)
                                {
                                    if (i.x == pos.x && i.y == pos.y)
                                    {
                                        found = false;
                                        break;
                                    }
                                }
                                if (found)
                                {
                                    inUse = true;
                                    break;
                                }
                            }
                        }
					}


					if (!inUse) {
						win.list.RemoveAt(0);
                        foreach (Position x in win.list)
                        {
                            if (x.x == newH.x && x.y == newH.y)
                            {
                                // Death by accidental self-cannibalism.
                                dead = true;
                                break;
                            }
                        }
					}

					if (!dead)
                    {
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.SetCursorPosition(head.x, head.y);
                        Console.Write("0");

						if (!inUse)
                        {
							Console.SetCursorPosition(tail.x, tail.y);
                            Console.Write(" ");
						}
                        else
                        {
							Console.ForegroundColor = ConsoleColor.Green;
                            Console.SetCursorPosition(pos.x, pos.y);
                            Console.Write("$");
							inUse = false;
						}*/

						win.list.Add(newH);
						Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.SetCursorPosition(newH.x, newH.y);
                        Console.Write("@");
						last = newDir;
					}
				}
			}
		}
	}
