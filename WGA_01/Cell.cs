using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGA_01
{
    public enum State
    {
        Clear,
        Block,
        Busy,
    }
    public enum Chip
    {
        None,
        Red,
        Green,
        Blue,
    }

    struct Cell
    {
        public State State { get; set; }
        public Chip Chip { get; set; }
        public Cell(char ch)
        {
            switch (ch)
            {
                case 'O':
                    State = State.Clear;
                    Chip = Chip.None;
                    break;
                case 'X':
                    State = State.Block;
                    Chip = Chip.None;
                    break;
                case 'R':
                    State = State.Busy;
                    Chip = Chip.Red;
                    break;
                case 'G':
                    State = State.Busy;
                    Chip = Chip.Green;
                    break;
                case 'B':
                    State = State.Busy;
                    Chip = Chip.Blue;
                    break;
                default:
                    State = State.Clear;
                    Chip = Chip.None;
                    break;
            }
        }
    }
}
