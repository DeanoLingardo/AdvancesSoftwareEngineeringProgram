using System;
using System.Drawing;
using System.Windows;
using GraphicsProgram;
using GraphicsProgram.Shapes;
using Point = System.Drawing.Point;

namespace GraphicsProgram.strategies.Triangle
{
    public class TriangleRepeatUserOperation : IUserOperationStrategy
    {
        public bool AppliesTo(string userOperationType, string shape)
        {
            return userOperationType.Equals(OperationType.Repeat) && shape.Equals(ShapeType.Triangle);
        }


        public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
        {
            var split = line.Split();
            string Operator;
            var repeatSize = 5;

            Operator = split[2];
            int.TryParse(split[3], out int AmountOfRepition);

            var Points = new ShapePoints
            {
                A = new Points
                {
                    X = penPosition.X = 0,
                    Y = penPosition.Y = 0
                },
                B = new Points
                {
                    X = penPosition.X = 90,
                    Y = penPosition.Y = 40
                },
                C = new Points
                {
                    X = penPosition.X = 40,
                    Y = penPosition.Y = 90
                }
            };

            if (Operator == "+")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    Point[] points = { new Point(Points.A.X += repeatSize, Points.A.Y += repeatSize), new Point(Points.B.X += repeatSize, Points.B.Y += repeatSize), new Point(Points.C.X += repeatSize, Points.C.Y += repeatSize)};
                    g.DrawPolygon(pen, points);
                }

            }
            if (Operator == "-")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    Point[] points = { new Point(Points.A.X -= repeatSize, Points.A.Y -= repeatSize), new Point(Points.B.X -= repeatSize, Points.B.Y -= repeatSize), new Point(Points.C.X -= repeatSize, Points.C.Y -= repeatSize)};
                    g.DrawPolygon(pen, points);
                }
            }
        }
    }
}
