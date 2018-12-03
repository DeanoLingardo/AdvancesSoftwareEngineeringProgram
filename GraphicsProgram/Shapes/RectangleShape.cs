namespace GraphicsProgram.Shapes
{
    public class RectangleShape : IShape
    {
        private double height { get; set; }
        private double width { get; set; }

        public RectangleShape(double h, double w)
        {
            height = h;
            width = w;
        }

        public double CalculateArea()
        {
            return width * height;
        }

        public double GetDiameter()
        {
            throw new System.NotImplementedException();
        }

        public double GetCircumference()
        {
            throw new System.NotImplementedException();
        }
    }
}
