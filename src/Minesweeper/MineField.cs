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
            Cells = Enumerable.Range(0, Width * Height)
                              .Select(x => new Cell())
                              .ToArray();
        }

        public int Width { get; }
        public int Height { get; }
        public int BombCount { get; }
        public Cell[] Cells { get; }

        public void SetBombs()
        {
            var rand = new Random();

            for (int i = 0; i < BombCount; i++)
            {
                var curr = Cells[rand.Next(0, Width * Height)];

                if (curr.IsBomb)
                {
                    i--;
                }
                else curr.SetBomb();
            }
        }
    }
}
