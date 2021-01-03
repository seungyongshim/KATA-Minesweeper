namespace Minesweeper
{
    public class Cell
    {
        public bool IsBomb { get; private set; }
        public int NearBombsCount { get; set; }
        public bool IsCovered { get; private set; } = true;

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
