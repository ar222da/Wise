using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo info = Console.ReadKey();

            while (info.Key != ConsoleKey.Escape)
            {
                Console.Clear();
                info = Console.ReadKey();
            }

        }
    }
}
