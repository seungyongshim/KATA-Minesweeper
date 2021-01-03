using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class MineField
    {
        public MineField(int width, int height, int bombCount = 0)
        {
            Width = width;
            Height = height;
            BombCount = bombCount;
            Cells = new Cell[Width * Height];
        }

        public int Width { get; }
        public int Height { get; }
        public int BombCount { get; }
        public Cell[] Cells { get; }

        public void SetBombs()
        {
            throw new NotImplementedException();
        }
    }
}
