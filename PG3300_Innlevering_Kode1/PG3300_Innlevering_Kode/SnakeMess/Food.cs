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


                bool food = true;
                foreach (Position i in list)
                    if (i.x == x && i.y == y)
                    {
                        food = false;
                        break;
                    }
                if (food)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(x, y);
                    Console.Write("$");
                    break;
                }

            }

        }



    }
}
