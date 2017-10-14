using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnakeMess
{
    class Window 
    {
        public void createFood()
        {
            Food fd = new Food();
            fd.Mat();
        }

        public void createSnake()
        {
            Snake sn = new Snake();
            sn.controlsNmovement();
            
        }
        
       

        public int BoardW
        { get; set; } = Console.WindowWidth;


        


        public int BoardH
        { get; set; } = Console.WindowHeight;

        
    

        

        
    }
}