using GraphicsProgram.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgram.strategies.PenStrategy
{
    public class PenDownStrategy : IPenStrategy
    {
        public bool AppliesTo(string PenCommand)
        {
            return PenCommand.Equals(PenState.PenDown);
        }

        public bool ApplyPenState()
        {
            return true;
        }
    }
}
