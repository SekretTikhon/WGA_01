using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGA_01
{
    class Field
    {
        public static readonly int size = 5;
        Chip[] target;
        Cell[,] cells;

        public Field()
        {
            target = new Chip[size];
            cells = new Cell[size, size];
            init();

        }
        private void init()
        {
            //char[] targetParam = { 'R', 'O', 'G', 'O', 'B' };
            initTarget(new char[] { 'R', 'O', 'G', 'O', 'B' });

            initCells(new char[,] {
                { 'G', 'X', 'R', 'X', 'G' },
                { 'B', 'O', 'R', 'O', 'G' },
                { 'R', 'X', 'B', 'X', 'B' },
                { 'G', 'O', 'G', 'O', 'R' },
                { 'B', 'X', 'B', 'X', 'R' },
            });
            
        }
        private void initTarget(char[] targetParam)
        {
            for (int i = 0; i < size; i++)
                switch (targetParam[i])
                {
                    case 'O':
                        target[i] = Chip.None;
                        break;
                    case 'R':
                        target[i] = Chip.Red;
                        break;
                    case 'G':
                        target[i] = Chip.Green;
                        break;
                    case 'B':
                        target[i] = Chip.Blue;
                        break;
                }
        }
        private void initCells(char[,] cellsParam)
        {
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    cells[i, j] = new Cell(cellsParam[i, j]);
        }

        public Chip this[int i]
        {
            get { return target[i]; }
        }
        public Cell this[int i, int j]
        {
            get { return cells[i, j]; }
        }

        



    }
}
