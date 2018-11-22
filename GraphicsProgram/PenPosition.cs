using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgram
{
    class PenPosition
    {
        public PenPosition()
        {
            Enabled = false;
        }

        public PenPosition(int yAxis, int xAxis)
        {
            this.Xposition = xAxis;
            this.Yposition = yAxis;
        }


        public int Xposition { get; set; }

        public int Yposition { get; set; }

        public bool Enabled { get; set; }
    }

}

