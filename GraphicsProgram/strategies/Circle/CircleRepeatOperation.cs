using System;
using System.Drawing;
using System.Windows;
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
        var split = line.Split();
        double circleRadius;
        string Operator;
        int repeatSize = 5;
        int AmountOfRepition;


        int.TryParse(split[4], out AmountOfRepition);
        Operator = split[3];
        double.TryParse(split[2], out circleRadius);

        IShape circle = new CircleShape(circleRadius);

        double diameter = circle.GetDiameter();
        float diameterF = Convert.ToSingle(diameter);

        float update()
        {
           return diameterF + 5;         
        }
        
        if (Operator == "+")
        {
            for (int i = 0; i < AmountOfRepition; i++)
            {
                g.DrawEllipse(pen, penPosition.X, penPosition.Y, diameterF, diameterF);
                update();
            }
        }
        else if (Operator == "-")
        {
            g.DrawEllipse(pen, penPosition.X, penPosition.Y, diameterF, diameterF);
            g.DrawEllipse(pen, penPosition.X, penPosition.Y, diameterF - repeatSize, diameterF - repeatSize);
        }
    }
}
