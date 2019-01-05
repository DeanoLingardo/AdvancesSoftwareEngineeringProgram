using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgram.strategies.PenStrategy
{
    public interface IPenStrategy
    {
        bool AppliesTo(string PenCommand);

        bool ApplyPenState();
    }
}
