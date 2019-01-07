using GraphicsProgram.CommandParser.Models;
using GraphicsProgram.Constants;
using GraphicsProgram.strategies.MoveStrategy;
using GraphicsProgram.strategies.PenStrategy;
using GraphicsProgram.strategies.Polygon;
using GraphicsProgram.strategies.Triangle;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Input;
using GraphicsProgram.strategies.Circle;

namespace GraphicsProgram
{
    public partial class InitialTestForm : Form
    {
        private Graphics g;
        private Pen myPen = new Pen(Color.Black, 2);
        private PenPosition pen = new PenPosition();

        string[] commands = new string[] { OperationType.Repeat, OperationType.Loop, OperationType.If };
        string[] shapes = new string[] { ShapeType.Circle, ShapeType.Rectangle, ShapeType.Triangle, ShapeType.Polygon};
        string[] moveStatus = new string[] {MoveState.Move};
        string[] penStatus = new string[] {PenState.PenDown, PenState.PenUp};

        private readonly IEnumerable<IUserOperationStrategy> _userOperationStrategies;
        private readonly IEnumerable<IPenStrategy> _penStrategies;
        private readonly IEnumerable<IMoveStrategy> _moveStrategies;



        public InitialTestForm()
        {
            /*
             * Initialise canvas properties
             */
            InitializeComponent();
          
            
            pen.Y = pictureBox1.Width / 2;
            pen.X = pictureBox1.Height / 2;
            g = pictureBox1.CreateGraphics();
            pencolorstatus.BackColor = myPen.Color;

           /*
            * All strategy lists below
            */        
            _userOperationStrategies = new List<IUserOperationStrategy>
            {
                new CircleBasicUserOperation(),
                new RectangleBasicUserOperation(),
                new CircleRepeatOperation(),
                new RectangleRepeatOperation(),
                new TriangleBasicUserOperation(),
                new PolygonBasicUserOperation()
            };

            
            _penStrategies = new List<IPenStrategy>
            {
                new PenUpStrategy(),
                new PenDownStrategy()
            };

           
            _moveStrategies = new List<IMoveStrategy>
            {
                new MoveStrategy()
            };
        }



        private void UpdatePenPositionBox()
        {
            textBox3.Text = pen.GetXAsString();
            textBox2.Text = pen.GetYAsString();
        }

        /// <summary>
        /// Method to split user input and 
        /// </summary>
        private void ProcessCommand(string userInput)
        {
            var splitString = userInput.Split();


            //If the input line contains move
            if (moveStatus.Contains(splitString[0]))
            {
                pen = _moveStrategies.Single(x => x.AppliesTo(splitString[0].ToLower())).MovePen(userInput.ToLower(), pen, myPen, g);
                UpdatePenPositionBox();
            }

            //If the input line contains pen, call pen strategy
            else if (penStatus.Contains(splitString[0]))
            {
               _penStrategies.Single(x => x.AppliesTo(userInput.ToLower().Trim())).ApplyPenState(textBox4);
            }   

            //If the input line is a command, call shape & command strategy
            else if (commands.Contains(splitString[0]) && shapes.Contains(splitString[1]))
            {
                var command = splitString[0];
                var shape = splitString[1];

                _userOperationStrategies.Single(x => x.AppliesTo(command, shape)).DoDrawing(myPen, pen, g, userInput);
            }

            //If the input line is a shape, call shape strategy (Set operation to basic)
            else if (shapes.Contains(splitString[0]))
                {
                var shape = splitString[0];
                _userOperationStrategies.Single(x => x.AppliesTo(OperationType.Basic, shape)).DoDrawing(myPen, pen, g, userInput);
            }

            else
            {
                MessageBox.Show("Incorrect command", "text error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        /// <summary>
        /// Run button for Multi-Line textbox
        /// </summary>
        private void runbutton_Click(object sender, EventArgs e)
        {
            //Input parsing, split multiline to single lines then split the single lines into an array
            foreach (var line in userinput.Lines)
            {
                ProcessCommand(line);
            }
        }

        /// <summary>
        /// Run button for Multi-line commands
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            {
                var singleUserInput = SingleLineUserInput.Text;
                ProcessCommand(singleUserInput);
            }
        }

        /// <summary>
        /// Single line accepts enter as input
        /// </summary>
        private void SingleLineUserInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Return))
            {
                {
                    var singleUserInput = SingleLineUserInput.Text;
                    ProcessCommand(singleUserInput);
                }
            }
        }

        /// <summary>
        /// Contains method for performing text save
        /// </summary>
        private void textboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var SaveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, userinput.Text);
                MessageBox.Show("Succesfully saved", "Saved Text File", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }    
        }

        /// <summary>
        /// Contains method for performing image save 
        /// </summary>
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

        /// <summary>
        /// Contains method for performing open text
        /// </summary>
        private void textFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog
            {
                Filter = "Text files (*.txt)|*.txt"
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {   
                    using (var sr = new StreamReader(openFileDialog1.FileName))
                    {
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

        /// <summary>
        /// Clears all textboxes & graphics panal
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
            userinput.Clear();
            SingleLineUserInput.Clear();
        }

        //Clears graphics panel only
        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.WhiteSmoke);
        }

        //Clears Multi-line textbox only
        private void button3_Click_2(object sender, EventArgs e)
        {
            userinput.Clear();
        }

        /// <summary>
        /// Clears Single-line commands textbox
        /// </summary>
        private void button2_Click_1(object sender, EventArgs e)
        {
            SingleLineUserInput.Clear();
        }

        /// <summary>
        /// Contains methods for choosing pen color
        /// </summary>
        private void penColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show the color dialog.
            DialogResult result = colorDialog1.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                // Set form background to the selected color.
                myPen.Color = colorDialog1.Color;
                pencolorstatus.BackColor = colorDialog1.Color;
            }
        }
 

        //Displays Exit application message box
        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure?", "Closing Application...", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //Displays program information message box
        private void programInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Use Commands tab to see the list of available commands!", "Need Help?", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
    }
    
    
//Created by Dean Lingard 2018