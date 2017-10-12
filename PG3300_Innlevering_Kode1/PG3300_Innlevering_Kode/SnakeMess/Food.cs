using System.Collections.Generic;
using System.Linq;
using System.Diagnostics
using System;
public class Food
{
	public Food()

	{
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
