using System;

namespace Minesweeper
{
    public class Cell
    {
        public bool IsBomb { get; private set; }
        public int NearBombsCount { get; set; }

        public void SetBomb() => IsBomb = true;

        public override string ToString()
        {
            if (IsBomb)
            {
                return "*";
            }

            return null;
        }
    }
}
