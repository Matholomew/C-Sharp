using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Conways
{
    public partial class Form1 : Form
    {
        private const int FORMHEIGHT = 600;
        private const int FORMWIDTH = 700; 
        
        private Random random;
        private Grid grid;
        private World world;

        //nGeneration is used to count the timertick and output to the label on the form
        private int nGeneration;

        public Form1()
        {
            InitializeComponent();
            random = new Random();
            grid = new Grid();
            world = new World(random, grid);
            // set the Properties of the form
            Top = 0;
            Left = 0;
            Height = FORMHEIGHT;
            Width = FORMWIDTH;

            // add the grid object to the list of controls on the form
            this.Controls.Add(grid);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // tell the world to compute its next generation
            // draw the world
            // increment the nGeneration count
            // write to the label
            
            world.ComputeNextWorldGeneration();
            world.Draw();
            nGeneration++;
            label1.Text = nGeneration.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // clear the world
            // fill the world
            // draw the world
            // set the generation count to 0
            // write to the label

            world.Clear();
            world.Fill();
            world.Draw();
            nGeneration = 0;
            label1.Text = nGeneration.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // clear the world
            // draw the world
            // set the generation count to 0
            // write to the label

            world.Clear();
            world.Draw();
            nGeneration = 0;
            label1.Text = nGeneration.ToString();
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            // enable the timer
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            // disable the timer
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // tell the world to compute its next generation
            // draw the world
            // increment the nGeneration count
            // write to the label

            world.ComputeNextWorldGeneration();
            world.Draw();
            nGeneration++;
            label1.Text = nGeneration.ToString();
        }
    }
}
