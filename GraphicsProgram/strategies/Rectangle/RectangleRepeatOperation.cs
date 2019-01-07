using System;
using System.Drawing;
using System.Windows.Forms;
using GraphicsProgram;
using GraphicsProgram.Shapes;

public class RectangleRepeatOperation : IUserOperationStrategy
{
    public bool AppliesTo(string userOperationType, string shape)
    {
        return userOperationType.Equals(OperationType.Repeat) && shape.Equals(ShapeType.Rectangle);
    }


    public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
    {
        var split = line.Split();
        string Operator;
        int repeatSize = 5;

        int.TryParse(split[5], out int AmountOfRepition);
        Operator = split[4];
      
        if (double.TryParse(split[2], out double W) && double.TryParse(split[3], out double H) && W != H)
        {
            IShape rec = new RectangleShape(W, H);

            float widthF = Convert.ToSingle(W);
            float heightF = Convert.ToSingle(H);

            if (Operator == "+")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    g.DrawRectangle(pen, penPosition.X, penPosition.Y, widthF, heightF);
                    widthF += repeatSize;
                    heightF += repeatSize;
                }
            }
            if (Operator == "-")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    g.DrawRectangle(pen, penPosition.X, penPosition.Y, widthF, heightF);
                    widthF -= repeatSize;
                    heightF -= repeatSize;
                }
            }
        }
        else
        {
            MessageBox.Show("Height & Width must be not be the same : FORMAT <Command> <Shape> <Width> <Height> <Operator> <Repitition Size>", "Wrong Paramters", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
