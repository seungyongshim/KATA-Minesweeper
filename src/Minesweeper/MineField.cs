using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class MineField
    {
        public MineField(int width, int height)
        {
            Width = width;
            Height = height;
            //Cells = new Cell[Width * Height];
        }

        public int Width { get; }
        public int Height { get; }
        public Cell[] Cells { get; }
    }
}
