using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace GraphicsProgram
{
    public partial class InitialTestForm : Form
    {
        private Graphics g;
        private Pen myPen = new Pen(Color.Black, 2);
        private PenPosition pen = new PenPosition();


        string[] commands = new string[] { "repeat", "loop", "if" };
        string[] shapes = new string[] { "circle", "rectangle" };


        private readonly IEnumerable<IUserOperationStrategy> _userOperationStrategies;

        int penX;
        int penY;
        bool penStatus;

        public InitialTestForm()
        {
            InitializeComponent();
            Width = 1000;
            Height = 500;
            g = pictureBox1.CreateGraphics();

            _userOperationStrategies = new List<IUserOperationStrategy>
            {
                new CircleBasicUserOperation(),new RectangleBasicUserOperation(),new CircleRepeatOperation(),
                new RectangleRepeatOperation()
            };
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
            //Update X & Y coordinate text fields on run command
            var penPosition = new PenPosition
            {
                X = penX,
                Y = penY,
                Enabled = penStatus
            };

            textBox3.Text = penPosition.GetXAsString();
            textBox2.Text = penPosition.GetYAsString();
            
            //String array to split multi line text input
            var textBoxLines = userinput.Lines;


            //Input parsing, split multiline to single lines then split the single lines into an array
            foreach (var line in textBoxLines)
            {
                var splitString = line.Split();

                switch (line)
                {
                    case "Penup":
                        penStatus = true;
                        textBox4.BackColor = (Color.Red);
                        break;
                    case "Pendown":
                        penStatus = false;
                        textBox4.BackColor = (Color.Green);
                        break;
                }

                switch (penStatus)
                {
                    case true:                  
                        if (line.Contains("move"))
                        {
                            var x = splitString[1];
                            var y = splitString[2];
                            if (int.TryParse(x, out penX) && int.TryParse(y, out penY))
                            {
                                pen.X = penX;
                                pen.Y = penY;
                            }
                            else
                            {
                                MessageBox.Show("Move Parse Error");
                            }
                        }
                        break;

                    case false:
                        if (shapes.Any(line.StartsWith))
                        {
                            var shape = splitString[0];
                           _userOperationStrategies.Single(x => x.AppliesTo(OperationType.Basic, shape)).DoDrawing(myPen, penPosition, g, line);
                        }
                        else if (commands.Any(line.StartsWith))
                        {
                            var shape = splitString[1];
                            _userOperationStrategies.Single(x => x.AppliesTo(OperationType.Repeat, shape)).DoDrawing(myPen, penPosition, g, line);
                        }


                        if (line.Contains("triangle"))
                        {
                            MessageBox.Show("Coming Soon!");
                        }
                        if (line.Contains("move"))
                        {
                            var x = splitString[1];
                            var y = splitString[2];
                            if (int.TryParse(x, out penX) && int.TryParse(y, out penY))
                            {
                                g.DrawLine(myPen, 0, 0, penX, penY);
                                penPosition.X = penX;
                                penPosition.Y = penY;
                            }
                            else
                            {
                                MessageBox.Show("Move Parse Error");
                            }
                        }
                        break;
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
            var SaveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, userinput.Text);
                MessageBox.Show("Succesfully saved", "Saved Text File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        private void imageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SaveFileDialog2 = new SaveFileDialog();
            SaveFileDialog2.Filter = "Bitmap files (*.bmp)|*.bmp|JPG files (*.jpg)|*.jpg|GIF files(*.gif) | *.gif | All files(*.*) | *.* ";;

            if (saveFileDialog2.ShowDialog() == DialogResult.OK)
            {
                var fName = saveFileDialog2.FileName;
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
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {   // Open the text file using a stream reader.
                    using (var sr = new StreamReader(openFileDialog1.FileName))
                    {
                        // Read the stream to a string, and write the string to the textbox.
                        var line = sr.ReadToEnd();
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

        private void InitialTestForm_Load(object sender, EventArgs e)
        {

        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
            userinput.Clear();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Update X & Y coordinate text fields on run command
            var penPosition = new PenPosition
            {
                X = penX,
                Y = penY,
                Enabled = penStatus
            };

            textBox3.Text = penPosition.GetXAsString();
            textBox2.Text = penPosition.GetYAsString();

            var SingletextBoxLines = SingleLineUserInput.Text;
            var splitString = SingletextBoxLines.Split();

            if (shapes.Any(SingletextBoxLines.StartsWith))
            {
                var shape = splitString[0];
                _userOperationStrategies.Single(x => x.AppliesTo(OperationType.Basic, shape)).DoDrawing(myPen, penPosition, g, SingletextBoxLines);
            }
            else if (commands.Any(SingletextBoxLines.StartsWith))
            {
                var shape = splitString[1];
                _userOperationStrategies.Single(x => x.AppliesTo(OperationType.Repeat, shape)).DoDrawing(myPen, penPosition, g, SingletextBoxLines);
            }


        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            SingleLineUserInput.Clear();
        }

        private void programInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use Commands tab to see the list of available commands!", "Need Help?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    }
    
    

// ______  _______ _______ __   _             _____ __   _  ______ _______  ______ ______                     
// |     \ |______ |_____| | \  |      |        |   | \  | |  ____ |_____| |_____/ |     \                    
// |_____/ |______ |     | |  \_|      |_____ __|__ |  \_| |_____| |     | |    \_ |_____/                    
// © 2018                                                                                                          
