using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGA_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.printGame();
            for (int i = 0; i < 1; i++)
            {
                ConsoleKeyInfo k = Console.ReadKey();
                Console.WriteLine(k.Key);
            }
        }
    }
}
