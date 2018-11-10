using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgram
{
    public partial class InitialTestForm : Form
    {
        private Graphics g;
        private Pen myPen = new Pen(Color.Blue, 2);


        public InitialTestForm()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 500;
            g = pictureBox1.CreateGraphics();
        }
 
        private void button3_Click(object sender, EventArgs e)
        {
            g.DrawEllipse(new Pen(Color.Black), 100, 100, 250, 250);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            g.DrawRectangle(new Pen(Color.Black), 400, 100, 250, 250);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            g.DrawLine(new Pen(Color.Black), 100, 100, 500, 500);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            g.Clear(Color.Coral);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input;
           input = textBox1.Text;

            if (input == "rectangle")
            {
                g.DrawRectangle(new Pen(Color.Black), 200, 100, 450, 250);
            }
            if (input == "ellipse")
            {
                g.DrawEllipse(new Pen(Color.Black), 100, 100, 250, 250);
            }
            if (input == "line")
            {
                g.DrawLine(new Pen(Color.Black), 100, 100, 500, 500);
            }
            if (input == "clear")
            {
                g.Clear(Color.Coral);
            }
        }
    }
}
