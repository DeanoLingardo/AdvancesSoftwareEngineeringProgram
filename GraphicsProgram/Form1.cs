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
        private Pen myPen = new Pen(Color.Red, 2);
        private PenPosition pen = new PenPosition();

        double circleRadius = 0;
        double rectangleWidth = 100;
        double rectangleHeight = 50;
        float penX = 50;
        float penY = 50;

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
            //Update X & Y coardinte text fields on run
            float updateY = penY;
            float updateX = penX;

            string stringY = updateY.ToString();
            string stringX = updateX.ToString();

            textBox3.Text = stringX;
            textBox2.Text = stringY;

            //String array to split multi line text input
            string[] textBoxLines = textBox1.Lines;
            
            foreach (string line in textBoxLines)
            {
                var num = double.TryParse(line, out double cirleRadius);
                
                //need to sort x and y coordinates to match a pen
                if (line == "circle " + circleRadius)
                {
                   Circle ans = new Circle(circleRadius);
                   double diameter = ans.getDiameter;
                   float diameterF = Convert.ToSingle(diameter);
                   g.DrawEllipse(myPen, penX, penY, diameterF, diameterF);
                }
                else if (line == "rectangle " + rectangleHeight + "," + rectangleWidth)
                {
                    rectangle rec = new rectangle(rectangleHeight, rectangleWidth);
                    double height = rec.Height;
                    float heightF = Convert.ToSingle(height);

                    double width = rec.Width;
                    float widthF = Convert.ToSingle(width);

                    g.DrawRectangle(myPen, penX, penY, heightF, widthF);
                }
                else if (line == "triangle")
                {
                    MessageBox.Show("Coming Soon!");
                }
                else if (line == "Penup")
                {
                    pen.Enabled = true;
                }
                else if (line == "Pendown")
                {
                    pen.Enabled = false;
                }
                else if (line == "move" + penX + penY) 
                {
                    penX = pen.xPosition;
                    penY = pen.yPosition;
                    
                    g.DrawLine(myPen, penX, penY, 100, 70);          
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}