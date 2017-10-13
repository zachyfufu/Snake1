using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class End : SnakeMess
    {
        bool inUse = false;
        bool dead = false;
        public void DeathOptions() 
        {
           
            Window win = new Window();
            Random rnd = new Random();
            Position newH = new Position();
            Position pos = new Position();


            if (newH.x < 0 || newH.x >= win.BoardW)
                dead = true;
            else if (newH.y < 0 || newH.y >= win.BoardH)
                dead = true;
            if (newH.x == pos.x && newH.y == pos.y)
            {
                if (win.list.Count + 1 >= win.BoardW * win.BoardH)
                {
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
                            if (found)
                            {
                                inUse = true;
                                break;
                            }
                        }
                       
                    }
                }

                if (!inUse)
                {
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

            }
        }
         
    }
}

