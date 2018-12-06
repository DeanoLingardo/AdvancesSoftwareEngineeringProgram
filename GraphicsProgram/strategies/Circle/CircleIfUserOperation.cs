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
        throw new NotImplementedException();
    }
}