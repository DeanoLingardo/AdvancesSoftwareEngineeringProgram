using System;
using System.Drawing;
using GraphicsProgram;
using GraphicsProgram.Shapes;

public class CircleIfUserOperation : IUserOperationStrategy
{
    public bool AppliesTo(string userOperationType, string shape)
    {
        return userOperationType.Equals(OperationType.If) && shape.Equals(ShapeType.Circle);
    }

    public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
    {
        var split = line.Split();
        double circleRadius;

        double.TryParse(split[1], out circleRadius);

        IShape circle = new CircleShape(circleRadius);

        double diameter = circle.GetDiameter();
        float diameterF = Convert.ToSingle(diameter);

        g.DrawEllipse(pen, penPosition.X, penPosition.Y, diameterF, diameterF);
    }
}