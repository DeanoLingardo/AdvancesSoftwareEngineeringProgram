using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgram.strategies.Polygon
{
    class PolygonBasicUserOperation : IUserOperationStrategy
    {
        public bool AppliesTo(string userOperationType, string shape)
        {
            return userOperationType.Equals(OperationType.Basic) && shape.Equals(ShapeType.Polygon);
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
                    Y = penPosition.Y
                },
                C = new Points
                {
                    X = penPosition.X = 40,
                    Y = penPosition.Y = 90
                },
                D = new Points
                {
                    X = penPosition.X = 100,
                    Y = penPosition.Y = 140
                },
                E = new Points
                {
                    X = penPosition.X = 140,
                    Y = penPosition.Y = 190
                }
            };

            Point[] points = { new Point(Points.A.X, Points.A.Y), new Point(Points.B.X, Points.B.Y), new Point(Points.C.X, Points.C.Y), new Point(Points.D.X, Points.D.Y), new Point(Points.E.X, Points.E.Y) };
            g.DrawPolygon(pen, points);
        }
    }
}

