using System;
using System.Drawing;
using GraphicsProgram.Shapes;

public class SquareLoopUserOperation : IUserOperationStrategy
{
    public bool AppliesTo(string userOperationType, string shape)
    {
        return userOperationType.Equals(OperationType.Loop) && shape.Equals(ShapeType.Square);
    }

    public void DoDrawing(Graphics g, IShape shape)
    {
        throw new NotImplementedException();
    }
}