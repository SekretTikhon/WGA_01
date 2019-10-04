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

                if (game.gameOver())
                {
                    game.message = "\tCongratulations! You won!\n\tFor restart the Game press Enter, for exit press Escape.";
                    do
                    {
                        game.printGame();
                        pressKey = Console.ReadKey().Key;
                    }
                    while (pressKey != ConsoleKey.Enter && pressKey != ConsoleKey.Escape);
                    if (pressKey == ConsoleKey.Enter)
                        game = new Game();
                    else
                        break;
                }
                
            } while (pressKey != ConsoleKey.Escape);
            game.message = "Thanks for playing!\nPress any key for exit.";
            game.printGame();
            Console.ReadKey();
        }
    }
}
