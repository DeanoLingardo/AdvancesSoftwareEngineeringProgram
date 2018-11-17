using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgram
{
    public partial class InitialTestForm : Form
    {
        private Graphics g;
        private Pen myPen = new Pen(Color.Orange, 2);
        private PenPosition pen = new PenPosition();

        int xAxis = 0;
        int yAxis = 0;
     


        public InitialTestForm()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 500;
            g = pictureBox1.CreateGraphics();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }
        

        private void button3_Click_1(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void meniToolStripMenuItem_Click(object sender, EventArgs e)
        {
       
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye!");
            Application.Exit();
        }


        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string[] textBoxLines = textBox1.Lines;
            //test integer, need to make input

            foreach (string line in textBoxLines)
            {
                int i = 100;
                int position = 100;
                
                
                //need to sort x and y coordinates to match a pen
                if (line == "circle " + i)
                {

                    Circle ans = new Circle(i);
                   double diameter = ans.getDiameter;
                   float diameterF = Convert.ToSingle(diameter);
                   g.DrawEllipse(myPen, 50, 50, diameterF, diameterF);
                }
                else if (line == "rectangle" + i)
                {
                    rectangle rec = new rectangle(i, i);
                    double height = rec.Height;
                    float heightF = Convert.ToSingle(height);

                    double width = rec.Width;
                    float widthF = Convert.ToSingle(width);

                    g.DrawRectangle(myPen, 100, 100, heightF, widthF);
                }
                else if (line == "triangle")
                {
                    MessageBox.Show("Coming Soon!");
                }
                else if (line == "move" + position) 
                {
                  PenPosition pen = new PenPosition();
                    int x = pen.xPosition;
                    int y = pen.yPosition;
                    g.DrawLine(myPen, x, y, 100, 70);
                    
                
    }
}
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void InitialTestForm_Load(object sender, EventArgs e)
        {

        }
    }
}