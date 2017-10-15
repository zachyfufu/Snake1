using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Food : Position
    {

        public void Mat()
        {
            Random rnd = new Random();
            Snk();

            

            while (true)
            {
                x = rnd.Next(0, Console.WindowWidth);
                y = rnd.Next(0, Console.WindowHeight);


                bool food = true;
                foreach (Position i in list)
                    if (i.x == x && i.y == y)
                    {
                        food = true;
                        break;
                    }
                if (food)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(y, x);
                    Console.Write("$");
                    break;
                }

            }

        }
       
    }
}
