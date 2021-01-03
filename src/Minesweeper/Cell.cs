using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Minesweeper.Tests")]

namespace Minesweeper
{
    public class Cell
    {
        public Cell() : this(Enumerable.Empty<Cell>())
        {
        }

        public Cell(IEnumerable<Cell> nearCells)
        {
            NearCells = nearCells;
            CoverState = new Covered(this);
        }

        public bool IsBomb { get; private set; }
        public int NearBombsCount { get; set; }
        public IEnumerable<Cell> NearCells { get; }
        internal AbstractCoverState CoverState { get; set; }

        public void SetBomb()
        {
            IsBomb = true;

            NearCells.ForEach(x => x.NearBombsCount++);
        }

        public void RightClick() => CoverState.RightClick();

        public void Click() => CoverState.Click();

        public override string ToString() => (CoverState.ToString(), IsBomb, NearBombsCount) switch
        {
            (null, true, _) => "*",
            (null, false, var c) => c.ToString(),
            (var c, _, _) => c.ToString(),
        };

        internal void ClickNearCells()
        {
            if (NearBombsCount != 0) return;

            NearCells.ForEach(x => x.Click());
        }
    }
}
