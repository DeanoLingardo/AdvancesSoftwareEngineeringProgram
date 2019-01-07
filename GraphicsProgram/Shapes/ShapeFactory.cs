using GraphicsProgram.Shapes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GraphicsProgram
{
    class ShapeFactory
    {
        public ShapeFactory CreateShape (string shapeType)
        {
            shapeType = shapeType.ToUpper().Trim();

            if(shapeType.Equals("CIRCLE"))
            {
                return null;
            }
            
            
            else
            {
                ArgumentException argx = new ArgumentException("Factory Error: " + shapeType + "Does Not Exist!");
                throw argx;
            }
        }
    }
}
