using GraphicsProgram.Constants;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgram.strategies.PenStrategy
{
    public class PenUpStrategy : IPenStrategy
    {
        public bool AppliesTo(string PenCommand)
        {
            return PenCommand.Equals(PenState.PenUp);
        }

        public bool ApplyPenState(TextBox textbox)
        {
            textbox.BackColor = Color.Red;
            return false;
        }
    }
}
