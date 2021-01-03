namespace Minesweeper
{
    public class Uncovered : AbstractCoverState
    {
        public Uncovered(Cell cell) : base(cell)
        {
        }

        public override void Click() => Cell.CoverState = this;

        public override void RightClick() => Cell.CoverState = this;

        public override string ToString() => null;
    }
}
