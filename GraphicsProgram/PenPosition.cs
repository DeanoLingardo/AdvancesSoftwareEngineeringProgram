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
        private int xAxis;
        private int yAxis;

        public PenPosition()
        {
            xAxis = 0;
            yAxis = 0;
            PenState = false;
        }

        public PenPosition(int yAxis, int xAxis)
        {
            this.xAxis = xAxis;
            this.yAxis = yAxis;
        }


        public int xPosition
       {
            get
            {
                return xAxis;
            }
       }

        public int yPosition
        {
            get
            {
                return yAxis;
            }
        }
        // property Radius 
        public int setxPosition
        {

            get
            {
                return xAxis;
            }

            set
            {
                // ensure non-negative radius value 
                if (value >= 0)
                    xAxis = value;
            }
        }

        public int setyPosition
        {

            get
            {
                return yAxis;
            }

            set
            {
                // ensure non-negative radius value 
                if (value >= 0)
                    yAxis = value;
            }
        }
        public Boolean upDown
        {

            get
            {
                return PenState;
            }

            set
            {
                if (value == true)
                    PenState = value;
            }
        }
    }

}

