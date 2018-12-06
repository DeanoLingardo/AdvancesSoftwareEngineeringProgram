using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgram
{
    class CommandParser
    {
        public string Operation { get; set; }
        public string Shape { get; set; }

        public CommandParser(string operation, string shape)
        {
            Shape = shape;
            Operation = operation;
        }

        public string getOperation()
        {
            return Operation;
        }

        public string getshape()
        {
            return Shape;
        }
    }
}
