using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    public class Frog : Creature
    {
        public Frog(String fileName, Grid grid)
            :base(fileName, grid)
        {
            alive = false;
        }
        public override void Draw()
        {
            GetGridCellForPosition(position).Value = head;
        }
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }
        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }
    }
}