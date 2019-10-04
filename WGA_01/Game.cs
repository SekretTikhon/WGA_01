using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGA_01
{
    class Game
    {
        Field field = new Field();
        int src_i = 2;
        int src_j = 2;
        int dst_i = -1;
        int dst_j = -1;
        string message = "";



        void changeCell()
        {
            if (src_i != dst_i && src_j != dst_j)
                return;

            if (src_i == dst_i)
                if (Math.Abs(src_j - dst_j) != 1)
                    return;
            changeCell(field[src_i, src_j], field[dst_i, dst_j]);
        }
        void changeCell(Cell dst, Cell src)
        {
            if (dst.State != State.Clear || src.State != State.Busy) return;
            dst.State = State.Busy;
            dst.Chip = src.Chip;
            src.State = State.Clear;
            src.Chip = Chip.None;
        }

        private void print(string str, int mul = 1)
        {
            for (int i = 0; i < mul; i++)
                Console.Write(str);
        }
        private void println(string str = "")
        {
            Console.WriteLine(str);
        }
        public void printGame()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine();
            Console.WriteLine("info: " + message);
            Console.WriteLine();
            printField();
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private void printField()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            println(" -------------- ");
            
            for (int i = 0; i < Field.size; i++)
            {
                print("|");
                printChip(field[i]);
            }
            println("|");
            println(" ============== ");


            for (int i = 0; i < Field.size; i++)
            {
                for (int j = 0; j < Field.size; j++)
                {
                    print("|");
                    if (i == select_i && j == select_j || i == take_i && j == take_j)
                        printCell(field[i, j], true);
                    else
                        printCell(field[i, j], false);
                }
                println("|");
                println(" -------------- ");
            }
            

            Console.BackgroundColor = ConsoleColor.Black;
        }
        private void printCell(Cell cell, bool selected = false)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            if (cell.State == State.Block)
            {
                Console.BackgroundColor = ConsoleColor.Gray;
                if (selected)
                    Console.Write("[]");
                else
                    Console.Write("  ");
            }
            else
            {
                printChip(cell.Chip, selected);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private void printChip(Chip chip, bool selected = false)
        {
            if (chip == Chip.Red) Console.BackgroundColor = ConsoleColor.Red;
            if (chip == Chip.Green) Console.BackgroundColor = ConsoleColor.Green;
            if (chip == Chip.Blue) Console.BackgroundColor = ConsoleColor.Blue;
            if (chip == Chip.None) Console.BackgroundColor = ConsoleColor.Black;
            if (selected)
                Console.Write("[]");
            else
                Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
