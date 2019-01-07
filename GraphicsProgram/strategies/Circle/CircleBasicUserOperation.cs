using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsProgram.Shapes;

namespace GraphicsProgram.strategies.Circle
{
    public class CircleBasicUserOperation : IUserOperationStrategy
    {
        public bool AppliesTo(string userOperationType, string shape)
        {
            return userOperationType.Equals(OperationType.Basic) && shape.Equals(ShapeType.Circle);
        }

        public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
        {
            var split = line.Split();

            try
            {
                double.TryParse(split[1], out var circleRadius);
                IShape circle = new CircleShape(circleRadius);

                ShapeFactory fac = new ShapeFactory();
                fac.CreateShape("circle");

                double diameter = circle.GetDiameter();
                float diameterF = Convert.ToSingle(diameter);

                g.DrawEllipse(pen, penPosition.X, penPosition.Y, diameterF, diameterF);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Missing Radius Parameter, FORMAT <Shape> <Radius>", "Missing Paramters", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}