using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace GraphicsProgram
{
    class rectangle
    {
        private int height;
        private int width;

        public rectangle(int height,int width)
        {
            this.width = width;
            this.height = height;
        }



        public override double Area
        {
            get
            {
                // Given the width and height, return the area of a rectangle:
                return width * height;
            }
        }
    }
}
