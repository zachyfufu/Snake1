using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class End : Position
    {
        public void DeathOptions() 
        {
            Window win = new Window();
            Random rnd = new Random();
            Position newH = new Position();


            if (newH.x < 0 || newH.x >= win.BoardW)
                dead = true;
            else if (newH.y < 0 || newH.y >= win.BoardH)
                dead = true;
            if (newH.x == x && newH.y == y)
            {
                if (snake.Count + 1 >= win.BoardW * win.BoardH)
                {
                    dead = true;
                }
                else
                {
                    while (true)
                    {
                        x = rnd.Next(0, win.BoardW);
                        y = rnd.Next(0, win.BoardH);
                        bool found = true;
                        foreach (Position i in snake)
                        {
                            if (i.x == x && i.y == y)
                            {
                                found = false;
                                break;
                            }
                        }
                        if (found)
                        {
                            inUse = false;
                            break;
                        }
                    }
                }
            }
        }
         
    }
}

