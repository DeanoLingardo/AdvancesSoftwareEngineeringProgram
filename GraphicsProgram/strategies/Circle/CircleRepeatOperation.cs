using System;
using System.Drawing;
using GraphicsProgram;
using GraphicsProgram.Shapes;

public class CircleRepeatOperation : IUserOperationStrategy
{ 
	public bool AppliesTo(string userOperationType, string shape)
	{
        return userOperationType.Equals(OperationType.Repeat) && shape.Equals(ShapeType.Circle);
	}
    
    public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
    {
        throw new NotImplementedException();
    }
}
