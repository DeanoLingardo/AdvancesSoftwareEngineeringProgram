using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsProgram.strategies.Polygon
{
    class PolygonRepeatOperation : IUserOperationStrategy
    {
        public bool AppliesTo(string userOperationType, string shape)
        {
            return userOperationType.Equals(OperationType.Repeat) && shape.Equals(ShapeType.Polygon);
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
                    X = penPosition.X = 10,
                    Y = penPosition.Y = 10
                },
                B = new Points
                {
                    X = penPosition.X = 90,
                    Y = penPosition.Y = 10
                },
                C = new Points
                {
                    X = penPosition.X = 40,
                    Y = penPosition.Y = 90
                },
                D = new Points
                {
                    X = penPosition.X = 10,
                    Y = penPosition.Y = 90
                },
                E = new Points
                {
                    X = penPosition.X = 10,
                    Y = penPosition.Y = 10
                }
            };

            if (Operator == "+")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    Point[] points = { new Point(Points.A.X += repeatSize, Points.A.Y += repeatSize), new Point(Points.B.X += repeatSize, Points.B.Y += repeatSize), new Point(Points.C.X += repeatSize, Points.C.Y += repeatSize), new Point(Points.D.X += repeatSize, Points.D.Y += repeatSize), new Point(Points.E.X += repeatSize, Points.E.Y += repeatSize) };
                    g.DrawPolygon(pen, points);
                }
                
            }
            if (Operator == "-")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    Point[] points = { new Point(Points.A.X -= repeatSize, Points.A.Y -= repeatSize), new Point(Points.B.X -= repeatSize, Points.B.Y -= repeatSize), new Point(Points.C.X -= repeatSize, Points.C.Y -= repeatSize), new Point(Points.D.X -= repeatSize, Points.D.Y -= repeatSize), new Point(Points.E.X -= repeatSize, Points.E.Y -= repeatSize) };
                    g.DrawPolygon(pen, points);
                }
            }
        }
    }
}
