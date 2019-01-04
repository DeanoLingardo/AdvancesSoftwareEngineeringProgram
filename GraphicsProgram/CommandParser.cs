using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgram
{
    public class CommandParser 
    {
        public string Operation { get; set; }
        public string Shape { get; set; }
        public bool IsVerified { get;  set; }
        public bool IsSingle { get; set; }


        public CommandParser(string operation, string shape)
        {
            Shape = shape;
            Operation = operation;
        }

        public string GetOperation()
        {
            return Operation;
        }

        public string Getshape()
        {
            return Shape;
        }

        public bool Verified()
        {
            return IsVerified;
        }
        
        public bool SingleLine()
        {
            return IsSingle;
        }

        
    }
}
