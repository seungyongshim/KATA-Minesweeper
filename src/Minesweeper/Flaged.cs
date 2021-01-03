using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    public class Flaged : AbstractCoverState
    {
        public Flaged(Cell cell) : base(cell)
        {
        }

        public override void Click() => throw new NotImplementedException();
        public override void RightClick() => throw new NotImplementedException();
    }
}
