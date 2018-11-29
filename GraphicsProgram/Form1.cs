using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsProgram
{
    public partial class InitialTestForm : Form
    {
        private Graphics g;
        private Pen myPen = new Pen(Color.Black, 2);
        private PenPosition pen = new PenPosition();

        double circleRadius;
        double rectangleWidth;
        double rectangleHeight;
        int penX;
        int penY;
        

        public InitialTestForm()
        {
            InitializeComponent();
            this.Width = 1000;
            this.Height = 500;
            g = pictureBox1.CreateGraphics();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            g.Clear(Color.White);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Goodbye!");
            Application.Exit();
        }


        

        private void runbutton_Click(object sender, EventArgs e)
        {
            //Update X & Y coardinte text fields on run command
            int updateX = penX;
            int updateY = penY;

            string stringX = updateX.ToString();
            string stringY = updateY.ToString();

            textBox3.Text = stringX;
            textBox2.Text = stringY;


            //String array to split multi line text input
            string[] textBoxLines = userinput.Lines;

            string[] commands = new string[] { "repeat", "loop", "if" };



            //Input parsing
            foreach (string line in textBoxLines)
            {
                var splitString = line.Split();

                if (line.Contains("circle"))
                {
                    var number = splitString[1];
                    if (double.TryParse(number, out circleRadius))
                    {
                        Circle circle = new Circle(circleRadius);
                        double diameter = circle.getDiameter;
                        float diameterF = Convert.ToSingle(diameter);
                        g.DrawEllipse(myPen, penX, penY, diameterF, diameterF);
                    }
                    else
                    {
                        MessageBox.Show("Circle Parse Error");
                    }

                }
                else if (line.Contains("rectangle"))
                {
                    var W = splitString[1];
                    var H = splitString[2];
                    if (double.TryParse(W, out rectangleWidth) && double.TryParse(H, out rectangleHeight))
                    {
                        rectangle rec = new rectangle(rectangleWidth, rectangleHeight);

                        double width = rec.Width;
                        double height = rec.Height;

                        float widthF = Convert.ToSingle(width);
                        float heightF = Convert.ToSingle(height);

                        g.DrawRectangle(myPen, penX, penY, widthF, heightF);
                    }
                    else
                    {
                        MessageBox.Show("Rectangle Parse Error");
                    }
                }
                else if (line.Contains("triangle"))
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
                else if (line.Contains("move")&& pen.Enabled == false)
                {
                    var x = splitString[1];
                    var y = splitString[2];
                    if (int.TryParse(x, out penX) && int.TryParse(y, out penY))
                    {
                        pen.Xposition = penX;
                        pen.Yposition = penY;
                    }
                    else
                    {
                        MessageBox.Show("Move Parse Error");
                    }
                }
                else if (line.Contains("move") && pen.Enabled)
                {
                    var x = splitString[1];
                    var y = splitString[2];
                    if (int.TryParse(x, out penX) && int.TryParse(y, out penY))
                    {
                        pen.Xposition = penX;
                        pen.Yposition = penY;
                        g.DrawRectangle(myPen, penX, penY, penX, penY);
                    }
                    else
                    {
                        MessageBox.Show("Move Parse Error");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            userinput.Clear();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void textboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Save textbox contents to a text file
            SaveFileDialog SaveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, userinput.Text);
                MessageBox.Show("Succesfully saved", "Saved Text File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
           

        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog SaveFileDialog2 = new SaveFileDialog();
            SaveFileDialog2.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files(*.gif) | *.gif | All files(*.*) | *.* ";;

            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                string fName = saveFileDialog2.FileName;
                pictureBox1.Image.Save(saveFileDialog2.FileName);
                MessageBox.Show("Succesfully saved", "Saved image File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void imageToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Text files (*.txt)|*.txt";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {   // Open the text file using a stream reader.
                    using (StreamReader sr = new StreamReader(openFileDialog1.FileName))
                    {
                        // Read the stream to a string, and write the string to the textbox.
                        String line = sr.ReadToEnd();
                        userinput.Text = line;
                        MessageBox.Show("Text succefully written", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Text Files Only", "didnt open it m8", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
// ______  _______ _______ __   _             _____ __   _  ______ _______  ______ ______                     
// |     \ |______ |_____| | \  |      |        |   | \  | |  ____ |_____| |_____/ |     \                    
// |_____/ |______ |     | |  \_|      |_____ __|__ |  \_| |_____| |     | |    \_ |_____/                    
// © 2018                                                                                                          
