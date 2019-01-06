using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsProgram;
using GraphicsProgram.Shapes;

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

            double diameter = circle.GetDiameter();
            float diameterF = Convert.ToSingle(diameter);

            g.DrawEllipse(pen, penPosition.X, penPosition.Y, diameterF, diameterF);
        }
        catch (IndexOutOfRangeException)
        {
            MessageBox.Show("Missing Radius Parameter", "Missing Paramters", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}