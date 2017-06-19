using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace SnakeGame
{
    public partial class Form1 : Form
    {
        private const int FORMHEIGHT = 600;
        private const int FORMWIDTH = 900;
        private bool start;
        private Grid grid;
        private Random random;
        private GameManager gameManager;
        private int pause = 0;

        public Form1()
        {
            InitializeComponent();

            // set the Properties of the form
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;
            KeyPreview = true;                                                              //        ***********    Allows keys to be pressed

            random = new Random();
            grid = new Grid("blank.bmp");
            // important, need to add the grid object to the list of controls on the form      **************
            Controls.Add(grid);

            gameManager = new GameManager(grid, random);


            // remember the Timer Enabled Property is set to false as a default
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (start)
            {
                textBox1.Text = gameManager.Points.ToString();
                gameManager.PlayGame();
                switch (gameManager.PlayGame())
                {
                    case ErrorMessage.snakeHitSelf:
                        textBox2.Text = "You died.";
                        start = false;
                        break;
                    case ErrorMessage.snakeHitWall:
                        textBox2.Text = "You died.";
                        start = false;
                        break;
                    case ErrorMessage.snakeEatenFrog:
                        textBox2.Text = "Eaten frog";
                        textBox1.Text = gameManager.Points.ToString();
                        break;
                    default:
                        break;
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            start = true;
            gameManager.Points = 0;
            textBox2.Text = "Playing...";
            gameManager.StartNewGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pause++;
            if (pause % 2 == 0)
            {
                timer1.Enabled = false;
            }                                                                     
            else
            {
                timer1.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    gameManager.SetSnakeDirection(Direction.Left);
                    break;

                case Keys.Right:
                    gameManager.SetSnakeDirection(Direction.Right);
                    break;

                case Keys.Up:
                    gameManager.SetSnakeDirection(Direction.Up);
                    break;

                case Keys.Down:
                    gameManager.SetSnakeDirection(Direction.Down);
                    break;

                default:
                    break;
            }
        }

    }
}
