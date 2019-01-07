namespace GraphicsProgram
{
    public class PenPosition
    {
        public int X { get; set; }

        public int Y { get; set; }

        public bool Enabled { get; set; }

        public string GetXAsString()
        {
            return X.ToString();
        }

        public string GetYAsString()
        {
            return Y.ToString();
        }

        public bool GetPenStatus()
        {
            return Enabled;
        }
    }

}
                                                                                                                                                                                                                           
