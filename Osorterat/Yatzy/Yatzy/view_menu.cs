using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yatzy
{
    class view_menu
    {
        private int selected = 0;

        public int Selected
        {
            get { return selected; }
            set { selected = value; }
        }


        public view_menu()
        {
        }
        
        public void menu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Welcome!");
            Console.WriteLine("1. New Game");
            Console.WriteLine("2. Restore last non-finished game");
            Console.WriteLine("3. Load/View game");
            Console.WriteLine("4. Quit");
            ConsoleKeyInfo input = Console.ReadKey(true);

            if (input.Key == ConsoleKey.D1)
            {
                selected = 1;
            }

            else if (input.Key == ConsoleKey.D2)
            {
                selected = 2;
            }

            else if (input.Key == ConsoleKey.D3)
            {
                selected = 3;
            }

            else if (input.Key == ConsoleKey.D4)
            {
                selected = 4;
            }

    }





    }
}
