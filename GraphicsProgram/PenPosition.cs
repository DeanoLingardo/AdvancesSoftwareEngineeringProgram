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

// ______  _______ _______ __   _             _____ __   _  ______ _______  ______ ______                     
// |     \ |______ |_____| | \  |      |        |   | \  | |  ____ |_____| |_____/ |     \                    
// |_____/ |______ |     | |  \_|      |_____ __|__ |  \_| |_____| |     | |    \_ |_____/                    
// © 2018  
