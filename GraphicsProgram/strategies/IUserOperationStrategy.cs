using GraphicsProgram;
using GraphicsProgram.Shapes;
using System.Drawing;

public interface IUserOperationStrategy
{
    bool AppliesTo(string userOperationType, string shape);

    void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line);
}