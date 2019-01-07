using System;
using System.Drawing;
using System.Windows;
using GraphicsProgram;
using GraphicsProgram.Shapes;
using Point = System.Drawing.Point;

namespace GraphicsProgram.strategies.Triangle
{
    public class TriangleBasicUserOperation : IUserOperationStrategy
    {
        public bool AppliesTo(string userOperationType, string shape)
        {
            return userOperationType.Equals(OperationType.Basic) && shape.Equals(ShapeType.Triangle);
        }

        public void DoDrawing(Pen pen, PenPosition penPosition, Graphics g, string line)
        {
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

            Point[] points = { new Point(Points.A.X, Points.A.Y), new Point(Points.B.X, Points.B.Y), new Point(Points.C.X, Points.C.Y) };
            g.DrawPolygon(pen, points);
        }
    }
}