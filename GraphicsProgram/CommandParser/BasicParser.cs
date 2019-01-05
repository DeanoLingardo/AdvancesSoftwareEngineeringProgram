using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsProgram.CommandParser.Models;

namespace GraphicsProgram.CommandParser
{
    class BasicParser : IParseCommands
    {
        private const int BasicCommandLineLength = 1;

        public bool AppliesTo(string[] line)
        {
            return (line.Length == BasicCommandLineLength) && ShapeType.ShapesList.Contains(line[0]);
        }

        public Command Parse(string[] line)
        {
            return new Command
            {
                Shape = line[0]
            };
        }
    }
}
