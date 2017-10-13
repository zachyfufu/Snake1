using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Window : Position
    {
        
        public List<Position> list;


        public int BoardW
        { get; set; } = Console.WindowWidth;


        


        public int BoardH
        { get; set; } = Console.WindowHeight;


        public void Snake()
        {
            List<Position> snake = new List<Position>();
            snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
            this.list = snake;
        }

        public void Food()
        {
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