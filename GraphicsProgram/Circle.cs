using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;



namespace GraphicsProgram
{
    class Circle 
    {
        private double radius;
        public const double PI = 3.14159;
        public Circle(double r)
        {
            Radius = r;
        }

        public Circle()
        {
            radius = 0.0;
        }

        public double getDiameter
        {
            get
            {
                return radius * 2;
            }

        }


        public double getArea
        {
            get
            {
                return PI * radius * radius;
            }

        }
        public double getCircumference
        {
            get
            {
                return 2 * PI * radius;
            }

        }

        // property Radius 
        public double Radius
        {

            get
            {
                return radius;
            }

            set
            {
                // ensure non-negative radius value 
                if (value >= 0)
                radius = value;
            }
        }
    }
}
//DEAN LINGARD © 2018
