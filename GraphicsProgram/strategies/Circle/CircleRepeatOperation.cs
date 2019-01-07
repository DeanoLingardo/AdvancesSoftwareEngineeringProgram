using System;
using System.Drawing;
using GraphicsProgram.Shapes;

namespace GraphicsProgram.strategies.Circle
{
    public class CircleRepeatOperation : IUserOperationStrategy
    { 
        public bool AppliesTo(string userOperationType, string shape)
        {
            return userOperationType.Equals(OperationType.Repeat) && shape.Equals(ShapeType.Circle);
        }
    
        public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
        {
            var split = line.Split();
            string Operator;
            int repeatSize = 5;


            int.TryParse(split[4], out int AmountOfRepition);
            Operator = split[3];
            double.TryParse(split[2], out double circleRadius);

            
            IShape circle = new CircleShape(circleRadius);

            double diameter = circle.GetDiameter();
            float diameterF = Convert.ToSingle(diameter);
        
            if (Operator == "+")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    g.DrawEllipse(pen, penPosition.X, penPosition.Y, diameterF, diameterF);
                    diameterF += repeatSize;
                }
            }
            if (Operator == "-")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    g.DrawEllipse(pen, penPosition.X, penPosition.Y, diameterF, diameterF);
                    diameterF -= repeatSize;
                }
            }
        }
    }
}
