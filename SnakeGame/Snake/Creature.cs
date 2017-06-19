using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace SnakeGame
{
    public abstract class Creature
    {
        //fields
        protected Bitmap head;
        protected Grid grid;
        protected Point position;
        protected bool alive;

        //constructor
        public Creature(String fileName, Grid grid)
        {
            head = new Bitmap(fileName);
            this.grid = grid;
            
        }

        public DataGridViewCell GetGridCellForPosition(Point p)
        {
            return grid.Rows[p.Y].Cells[p.X]; 
        }

        public abstract void Draw();
    }
}
