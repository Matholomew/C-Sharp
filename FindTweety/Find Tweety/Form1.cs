using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Find_Tweety
{
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private GameBoard gb;
        public Form1()
        {
            InitializeComponent();
            panel1.Width = 350;
            panel1.Height = 350;
            graphics = panel1.CreateGraphics();                 //*******************
            gb = new GameBoard(graphics);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            gb.SetupNewGame();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            eSquareType result = gb.PlayThisSquare(e.Location);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
