namespace Minesweeper
{
    public abstract class AbstractCoverState
    {
        protected Cell Cell { get; }

        protected AbstractCoverState(Cell cell) => Cell = cell;

        public abstract void Click();
        public abstract void RightClick();
    }
}
