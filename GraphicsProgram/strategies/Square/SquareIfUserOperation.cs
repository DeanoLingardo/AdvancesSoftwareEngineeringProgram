using System;
using System.Drawing;
using GraphicsProgram.Shapes;

public class SquareIfUserOperation : IUserOperationStrategy
{
    public bool AppliesTo(string userOperationType, string shape)
    {
        return userOperationType.Equals(OperationType.If) && shape.Equals(ShapeType.Square);
    }

    public void DoDrawing(Graphics g, IShape shape)
    {
        throw new NotImplementedException();
    }
}