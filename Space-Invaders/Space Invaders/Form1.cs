/*
   In this game the player controls a ship that moves from side to side at the bottom of the screen

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Assignment
{
    public partial class Form1 : Form
    {
        private bool start;
        private Graphics graphics;
        private GameManager manager;
        private Graphics bufferGraphics;
        private Image bufferImage;
        private int pause = 0;
        private SoundPlayer shot = new SoundPlayer("images\\shot.wav");

        public Form1()
        {/*
            Set the timer to false
            Create double buffering graphics
            Create graphics
            Create the manager constructor passing through buffered graphics and the Client Size
         */
            InitializeComponent();
            start = false;
            timer1.Enabled = false;
            graphics = CreateGraphics();
            bufferImage = new Bitmap(ClientSize.Width, ClientSize.Height - 50);
            bufferGraphics = Graphics.FromImage(bufferImage);
            manager = new GameManager(bufferGraphics, ClientSize);
        }

        private void button1_Click(object sender, EventArgs e)
        {/*
            Starts a new game
            Reset the enemies
         */
            manager.CreateEnemies();
            manager.GameOver = false;
            button1.Enabled = false;
            start = true;
            timer1.Enabled = true;
            pictureBox1.Visible = false;
            textBox2.Text = "Playing";
            textBox1.Visible = true;
            pictureBox2.Visible = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {/*
            If the game has started, run the timer.
            Call appropriate methods from the game manager
            If the game is over, stop the timer and give feedback to the user
         */
            if (start)
            {
                bufferGraphics.Clear(Color.Black);
                manager.Run();
                Application.DoEvents();
                graphics.DrawImage(bufferImage, 0, 0);
                textBox1.Text = manager.Points.ToString();
            }
            if (manager.GameOver)
            {
                pictureBox1.Visible = true;
                start = false;
                timer1.Enabled = false;
                button1.Enabled = true;
                manager.NOnScreen = 0;
                if (!manager.Won)
                {
                    textBox2.Text = "You lost!";
                    manager.ResetEnemies();
                    manager.Points = 0;
                }

                if (manager.Won)
                {
                    textBox2.Text = "You won!";
                    manager.Points = 0;
                }
                manager.Won = false;
                manager.GameOver = false;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {/*
            Return the position of the Mouse Move event to the manager to assign it to the Mother ship
         */
            manager.Mouse(e.Location);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {/*
            Call the manager to create a missile if the mouse is clicked
         */
            if (!manager.GameOver)
            {
                shot.Play();
            }
            manager.CreateMissiles();
        }

        private void button2_Click(object sender, EventArgs e)
        {/*
            Play or pause the game
        */
            start = false;
            pause++;
            if (pause % 2 == 0)
            {
                start = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {/*
            Change difficulty by changing the timers speed interval
         */
            timer1.Interval = 150;
        }

        private void button4_Click(object sender, EventArgs e)
        {/*
            Change difficulty by changing the timers speed interval
         */
            timer1.Interval = 100;
        }

        private void button5_Click(object sender, EventArgs e)
        {/*
            Change difficulty by changing the timers speed interval
         */
            timer1.Interval = 50;
        }
    }
}
