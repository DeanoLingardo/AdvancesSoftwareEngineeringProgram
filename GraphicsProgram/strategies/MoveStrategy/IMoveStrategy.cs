using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgram.strategies.MoveStrategy
{
    public interface IMoveStrategy
    {
        bool AppliesTo(string commandLine);

        PenPosition MovePen(string line, PenPosition penStatus, Pen pen, Graphics G);
    }
}
