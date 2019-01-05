using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphicsProgram.CommandParser.Models;


namespace GraphicsProgram.CommandParser
{
    public interface IParseCommands
    {
        bool AppliesTo(string[] line);

        Command Parse(string[] line);
    }
}
