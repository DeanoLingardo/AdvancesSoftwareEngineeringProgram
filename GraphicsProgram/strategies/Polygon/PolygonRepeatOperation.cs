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

            Operator = split[3];
            int.TryParse(split[4], out int AmountOfRepition);

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
                    X = penPosition.X = 60,
                    Y = penPosition.Y = 60
                }
            };

            if (Operator == "+")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    Point[] points = { new Point(Points.A.X + AmountOfRepition, Points.A.Y + AmountOfRepition), new Point(Points.B.X + AmountOfRepition, Points.B.Y + AmountOfRepition), new Point(Points.C.X + AmountOfRepition, Points.C.Y + AmountOfRepition), new Point(Points.D.X + AmountOfRepition, Points.D.Y + AmountOfRepition), new Point(Points.E.X + AmountOfRepition, Points.E.Y + AmountOfRepition) };
                    g.DrawPolygon(pen, points);
                }
            }
            if (Operator == "-")
            {
                for (int i = 0; i < AmountOfRepition; i++)
                {
                    Point[] points = { new Point(Points.A.X - AmountOfRepition, Points.A.Y - AmountOfRepition), new Point(Points.B.X - AmountOfRepition, Points.B.Y - AmountOfRepition), new Point(Points.C.X - AmountOfRepition, Points.C.Y - AmountOfRepition), new Point(Points.D.X - AmountOfRepition, Points.D.Y - AmountOfRepition), new Point(Points.E.X - AmountOfRepition, Points.E.Y - AmountOfRepition) };
                    g.DrawPolygon(pen, points);
                }
            }
        }
    }
}
