using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class ViewMemberList
    {

        public void Grid(int gridSize)
        {
            int counter = 0;
            bool quit = false;
            
            String[] grid = new String[gridSize];

            do
            {
                Console.Clear();

                for (int i = 0; i < grid.Length; i++)
                {
                    int section = counter / grid.Length;
                    grid[i] = memberList[i + section * grid.Length];

                    if (i == counter || (counter - (grid.Length * section) == i))
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                    }

                    Console.Write("| ");
                    Console.Write(grid[i]);
                    Console.WriteLine(" |");
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.BackgroundColor = ConsoleColor.Black;
                int leftOffSet = (Console.WindowWidth / 2);
                int topOffSet = (Console.WindowHeight / 2);
                Console.SetCursorPosition(leftOffSet, topOffSet);
                Console.WriteLine();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (counter < memberList.Count - 1)
                        {
                            counter++;
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (counter > 0)
                        {
                            counter--;
                        }
                        break;
                    case ConsoleKey.Escape:
                        quit = true;
                        break;
                }





            }
            while (quit == false);
        }
    }
}
