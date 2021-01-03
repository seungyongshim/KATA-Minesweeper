namespace Minesweeper
{
    public class Covered : AbstractCoverState
    {
        public Covered(Cell cell) : base(cell)
        {
        }

        public override void Click() => Cell.CoverState = new Uncovered(Cell);

        public override void RightClick() => Cell.CoverState = new Flaged(Cell);

        public override string ToString() => ".";
    }
}
