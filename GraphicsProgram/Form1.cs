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

        int xAxis = 0;
        int yAxis = 0;
        int width = 0;
        int height = 0;

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


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input = textBox1.Text;

            if (input == "rectangle")
            {
                g.DrawRectangle(new Pen(Color.Black), xAxis, yAxis, height, width);
            }
            if (input == "circle")
            {
                g.DrawEllipse(new Pen(Color.Black), xAxis, yAxis, height, width);
            }
            if (input == "line")
            {
                g.DrawLine(new Pen(Color.Black), xAxis, yAxis, height, width);
            }
            if (input == "clear")
            {
                g.Clear(Color.Azure);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

            int i;

            if (int.TryParse(textBox2.Text, out i))
            {
                width = i;
            }
            else
            {
                //do nothing;
            }

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int i;

            if (int.TryParse(textBox3.Text, out i))
            {
                height = i;
            }
            else
            {
                //do nothing;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.Items[comboBox1.SelectedIndex].ToString();

            if (selectedItem == "Rectangle")
            {
                g.DrawRectangle(new Pen(Color.Black), xAxis, yAxis, height, width);
            }
            if (selectedItem == "Circle")
            {
                g.DrawEllipse(new Pen(Color.Black), xAxis, yAxis, height, width);
            }
            if (selectedItem == "Square")
            {
                g.DrawRectangle(new Pen(Color.Black), xAxis, yAxis, height, width);
            }
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
            Application.Exit();
        }
    }
}