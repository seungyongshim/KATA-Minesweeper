using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Covered : AbstractCoverState
    {
        public Covered(Cell cell) : base(cell)
        {
        }

        public void Click()
        {
            Cell.CoverState = new Uncovered(Cell);
        }

        internal void RightClick()
        {
            throw new NotImplementedException();
        }
    }
}
