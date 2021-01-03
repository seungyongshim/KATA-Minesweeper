namespace Minesweeper
{
    public class Covered : AbstractCoverState
    {
        public Covered(Cell cell) : base(cell)
        {
        }

        public void Click() => Cell.CoverState = new Uncovered(Cell);

        public void RightClick() => Cell.CoverState = new Flaged(Cell);

        public override string ToString() => ".";
    }
}
