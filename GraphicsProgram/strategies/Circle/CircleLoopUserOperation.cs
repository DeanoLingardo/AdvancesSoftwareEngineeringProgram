using GraphicsProgram;
using GraphicsProgram.Shapes;
using System;
using System.Drawing;

public class CircleLoopUserOperation : IUserOperationStrategy
{
    public bool AppliesTo(string userOperationType, string shape)
    {
        return userOperationType.Equals(OperationType.Loop) && shape.Equals(ShapeType.Circle);
    }
    
    public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
    {
        throw new NotImplementedException();
    }
}