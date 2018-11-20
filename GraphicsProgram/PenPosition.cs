using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgram
{
    class PenPosition
    {
        private Boolean PenState;
        int xAxis;
        int yAxis;

        public PenPosition()
        {
            PenState = false;
        }

        public PenPosition(int yAxis, int xAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }


        public int xPosition
       {
            get { return xAxis; }
            set { xAxis = value; }
        }

        public int yPosition
        {
            get { return yAxis; }
            set { yAxis = value; }
        }
       
        public bool Enabled
        {
            get { return PenState; }
            set { PenState = value; }
        }
    }

}

