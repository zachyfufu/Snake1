using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Position
    {

        public int x, y;
        public List<Position> list;


        public Position(int x = 0, int y = 0)
        {
            this.x = x; this.y = y;
        }
        public Position(Position input)
        {
            x = input.x; y = input.y;
        }


     


        public void Snk()
        {
            List<Position> snake = new List<Position>();
            snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
            snake.Add(new Position(10, 10));
            this.list = snake;
        }
    }
}