using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace Minesweeper
{
    public class MineField
    {
        public MineField(int width, int height, int bombCount = 0)
            : this(width, height, IndexGenerator(width * height).Distinct().Take(bombCount))
        {
        }

        public MineField(int width, int height, IEnumerable<int> bombIndices)
        {
            Width = width;
            Height = height;

            Cells = (from x in Enumerable.Range(0, Width)
                     from y in Enumerable.Range(0, Height)
                     orderby ToIndex(x, y)
                     select new Cell(GetNearCells(x, y))).ToArray();

            (from i in bombIndices
             select Cells[i]).ForEach(x => x.SetBomb());
        }

        public int Width { get; }
        public int Height { get; }
        public Cell[] Cells { get; }

        public IEnumerable<Cell> GetNearCells(int x, int y)
        {
            return from i in NearIndexGenerator(x, y)
                   let c = GetCell(i)
                   where c is not null
                   select c;
        }

        public void Click(int x, int y) => Cells[ToIndex(x, y)].Click();

        public override string ToString() => string.Join<Cell>(string.Empty, Cells);

        private static IEnumerable<int> IndexGenerator(int max)
        {
            while (true)
                yield return RandomNumberGenerator.GetInt32(0, max);
        }

        private static IEnumerable<(int, int)> NearIndexGenerator(int x, int y)
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

        private int ToIndex(int x, int y) => x + (y * Width);

        private Cell GetCell((int X, int Y) pos) => pos switch
        {
            (var x, _) when x < 0 => null,
            (var x, _) when x >= Width => null,
            (_, var y) when y < 0 => null,
            (_, var y) when y >= Height => null,
            (var x, var y) => Cells[ToIndex(x, y)],
        };
    }
}
