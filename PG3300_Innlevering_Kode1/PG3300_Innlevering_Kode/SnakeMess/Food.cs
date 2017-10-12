using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Food
    {

        public Food() { 

        public void spawnFood() { 
        Position pos = new Position();
        Random rnd = new Random();

            pos.x = rnd.Next(0, boardW);
            pos.y = rnd.Next(0, boardH);
            bool spot = true;

            foreach (Position i in snake)
                if (i.x == pos.x && i.y == pos.y)
                {
                    spot = false;
                    break;
                }
                if (spot)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(pos.x, pos.y);
                    Console.Write("$");
                    break;
                }
            }
        }
    }
}
