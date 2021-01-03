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
            Cells = (from x in Enumerable.Range(0, Width)
                     from y in Enumerable.Range(0, Height)
                     orderby ToIndex(x, y)
                     select new Cell(x, y, GetNearCells(x, y))).ToArray();
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

        public void SetNearBombsCounts()
        {
            (from c in Cells
             where c.IsBomb
             from n in GetNearCells(c)
             select n).ForEach(x => x.NearBombsCount++);
        }

        public IEnumerable<Cell> GetNearCells(int x, int y)
        {
            return from i in NearIndexGenerator(x, y)
                   let c = GetCell(i)
                   where c is not null
                   select c;
        }

        private int ToIndex(int x, int y) => x + (y * Width);

        private IEnumerable<int> IndexGenerator(Random rand)
        {
            while (true)
                yield return rand.Next(Width * Height);
        }

        private IEnumerable<Cell> GetNearCells(Cell bomb) => GetNearCells(bomb.X, bomb.Y);

        private Cell GetCell((int X, int Y) pos) => pos switch
        {
            (var x, _) when x < 0 => null,
            (var x, _) when x >= Width => null,
            (_, var y) when y < 0 => null,
            (_, var y) when y >= Height => null,
            (var x, var y) => Cells[ToIndex(x, y)],
        };

        public void Click(int x, int y) => Cells[ToIndex(x, y)].Click();

        private IEnumerable<(int, int)> NearIndexGenerator(int x, int y)
        {
            yield return (x - 1, y - 1);
            yield return (x, y - 1);
            yield return (x + 1, y - 1);
            yield return (x - 1, y);
            yield return (x + 1, y);
            yield return (x - 1, y + 1);
            yield return (x, y + 1);
            yield return (x + 1, y + 1);
        }

        public override string ToString() => string.Join<Cell>(string.Empty, Cells);
    }
}
