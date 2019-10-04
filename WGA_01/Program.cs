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
            ConsoleKey pressKey;
            do
            {
                game.printGame();
                pressKey = Console.ReadKey().Key;
                game.action(pressKey);
            } while (pressKey != ConsoleKey.Escape);
            Console.Clear();
            Console.WriteLine("Thanks for playing!");
            Console.WriteLine("Press any key for exit.");
            Console.ReadKey();
        }
    }
}
