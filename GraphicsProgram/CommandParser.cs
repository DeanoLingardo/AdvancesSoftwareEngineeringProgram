using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgram
{
    class CommandParser 
    {
        public string Operation { get; set; }
        public string Shape { get; set; }
        public bool IsVerified { get; private set; }
    


        string[] commands = new string[] { "repeat", "loop", "if"};
        string[] shapes = new string[] { "circle", "rectangle"};

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
    }
}
