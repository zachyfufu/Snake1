using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;


namespace SnakeMess
{
	

	class MainMethod
	{


        public static void Main(string[] arguments)
		{
            Window win = new Window();
            win.createSnake();
            win.createFood();
 

			
		}
	}
}