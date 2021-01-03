namespace Minesweeper
{
    public class Cell
    {
        public Cell(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool IsBomb { get; private set; }
        public int NearBombsCount { get; set; }
        public bool IsCovered { get; private set; } = true;
        public int X { get; }
        public int Y { get; }

        public void SetBomb() => IsBomb = true;

        public void Click() => IsCovered = false;

        public override string ToString() => (IsCovered, IsBomb, NearBombsCount) switch
        {
            (true, _, _) => ".",
            (false, true, _) => "*",
            (false, false, var c) => c.ToString()
        };
    }
}
