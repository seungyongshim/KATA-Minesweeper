using System;
using System.Collections.Generic;
using System.Linq;

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

            (from i in IndexGenerator(rand)
             select Cells[i]).Distinct()
                             .Take(BombCount)
                             .ForEach(x => x.SetBomb());
        }

        private IEnumerable<int> IndexGenerator(Random rand)
        {
            while (true)
                yield return rand.Next(Width * Height);
        }

        public void SetNearBombsCounts()
        {
            throw new NotImplementedException();
        }
    }
}
