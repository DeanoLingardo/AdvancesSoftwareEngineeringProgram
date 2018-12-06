namespace GraphicsProgram.Shapes
{
    public class CircleShape : IShape
    {
        private readonly double PI = 3.14159;

        //Default value of a double is 0.0 ;)
        private double radius { get; set; }

        public CircleShape(double r)
        {
            radius = r;
        }

        public double CalculateArea()
        {
            return PI * (radius * radius);
        }

        public double GetDiameter()
        {
            return radius * 2;
        }

        public double GetCircumference()
        {
            return (2 * PI) * radius;
        }

        public double GetWidth()
        {
            throw new System.NotImplementedException();
        }

        public double GetHeight()
        {
            throw new System.NotImplementedException();
        }
    }
}
