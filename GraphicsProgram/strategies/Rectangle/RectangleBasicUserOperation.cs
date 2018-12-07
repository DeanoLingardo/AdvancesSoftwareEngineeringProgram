using System;
using System.Drawing;
using System.Windows;
using GraphicsProgram;
using GraphicsProgram.Shapes;

public class RectangleBasicUserOperation : IUserOperationStrategy
{
    public bool AppliesTo(string userOperationType, string shape)
    {
        return userOperationType.Equals(OperationType.Basic) && shape.Equals(ShapeType.Rectangle);
    }

    public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
    {
        var split = line.Split();
        double rectangleWidth;
        double rectangleHeight;

        var W = split[1];
        var H = split[2]; 

        if (double.TryParse(W, out rectangleWidth) && double.TryParse(H, out rectangleHeight))
        {
            IShape rec = new RectangleShape(rectangleWidth, rectangleHeight);

            float widthF = Convert.ToSingle(W);
            float heightF = Convert.ToSingle(H);

            g.DrawRectangle(pen, penPosition.X, penPosition.Y, widthF, heightF);
        }
    }
}