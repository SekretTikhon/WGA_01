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
        bool srcExist = false;
        int src_i = -1;
        int src_j = -1;
        int dst_i = 2;
        int dst_j = 2;
        string message = "";


        public void action(ConsoleKey key)
        {
            switch (key)
            {
                case ConsoleKey.Enter:
                    if (srcExist)
                        forgetSrc();
                    else
                        rememberSrc();
                    break;
                case ConsoleKey.UpArrow:
                    if (dst_i > 0)
                    {
                        dst_i--;
                        if (srcExist)
                        {
                            if (changeCell())
                                rememberSrc();
                            else
                                forgetSrc();
                        }
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (dst_i < 4)
                    {
                        dst_i++;
                        if (srcExist)
                        {
                            if (changeCell())
                                rememberSrc();
                            else
                                forgetSrc();
                        }
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (dst_j > 0)
                    {
                        dst_j--;
                        if (srcExist)
                        {
                            if (changeCell())
                                rememberSrc();
                            else
                                forgetSrc();
                        }
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (dst_j < 4)
                    {
                        dst_j++;
                        if (srcExist)
                        {
                            if (changeCell())
                                rememberSrc();
                            else
                                forgetSrc();
                        }
                    }
                    break;
            }
        }
        private void rememberSrc()
        {
            src_i = dst_i;
            src_j = dst_j;
            srcExist = true;
        }
        private void forgetSrc()
        {
            src_i = -1;
            src_j = -1;
            srcExist = false;
        }
        private bool changeCell()
        {
            //if (src_i == dst_i && Math.Abs(src_j - dst_j) == 1 || src_j == dst_j && Math.Abs(src_i - dst_i) == 1)
            //changeCell(field[dst_i, dst_j], field[src_i, src_j]);
            return field.changeCell(dst_i, dst_j, src_i, src_j);
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
            Console.Clear();
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
                    if (i == dst_i && j == dst_j)
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
            switch (chip)
            {
                case Chip.Red:
                    Console.BackgroundColor = ConsoleColor.Red;
                    break;
                case Chip.Green:
                    Console.BackgroundColor = ConsoleColor.Green;
                    break;
                case Chip.Blue:
                    Console.BackgroundColor = ConsoleColor.Blue;
                    break;
                case Chip.None:
                    Console.BackgroundColor = ConsoleColor.Black;
                    break;
            }
            if (selected)
                Console.Write("[]");
            else
                Console.Write("  ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
