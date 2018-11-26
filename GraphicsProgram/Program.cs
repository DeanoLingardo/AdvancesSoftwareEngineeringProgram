using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgram
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InitialTestForm());
        }
    }
}

// ______  _______ _______ __   _             _____ __   _  ______ _______  ______ ______                     
// |     \ |______ |_____| | \  |      |        |   | \  | |  ____ |_____| |_____/ |     \                    
// |_____/ |______ |     | |  \_|      |_____ __|__ |  \_| |_____| |     | |    \_ |_____/                    
// © 2018  
