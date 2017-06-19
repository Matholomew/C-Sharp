using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    public class Snake : Creature
    {
       
        private const int SNAKESTART = 10;
        private const int LENGTH = 8;
        private const int NCELLS = 30;
        private List<Point> position;
        private bool eaten = false;
        private Bitmap body;
        private Direction direction;
        private Frog frog;
        public Snake(String fileName, Grid grid, String fileName2)
            :base(fileName, grid)
        {
            body = new Bitmap(fileName2);
            direction = Direction.Right;
            position = new List<Point>();
            for (int i = 0; i < LENGTH; i++)
            {
                position.Add(new Point(SNAKESTART - i, SNAKESTART));
            }
        }
        public override void Draw() 
        {
            GetGridCellForPosition(position[0]).Value = head;
            for(int i = 1; i < position.Count; i++)
            {
                GetGridCellForPosition(position[i]).Value = body;
            }
        }
        public void Move() 
        {
            for (int i = (position.Count -1); i > 0; i--)
            {
                position[i] = position[i - 1];
            }

            switch (direction)
            {
                case Direction.Up:
                    position[0] = new Point(position[0].X, position[0].Y - 1);
                    break;
                case Direction.Down:
                    position[0] = new Point(position[0].X, position[0].Y + 1);
                    break;
                case Direction.Left:
                    position[0] = new Point(position[0].X - 1, position[0].Y);
                    break;
                case Direction.Right:
                    position[0] = new Point(position[0].X + 1, position[0].Y);
                    break;
                default:
                    break;
            }
        }
        public List<Point> Position
        {
          get { return position; }
          set { position = value; }
        }
        public Direction Direction
        {
          get { return direction; }
          set
            {
                if (((direction == Direction.Left) && (value != Direction.Right)) ||
                    ((direction == Direction.Right) && (value != Direction.Left)) ||
                    ((direction == Direction.Up) && (value != Direction.Down)) ||
                    ((direction == Direction.Down) && (value != Direction.Up)))
                {
                    direction = value;
                }
                
            }
        }
        public bool Alive
        {
            get { return alive; }
            set { alive = value; }
        }
    }
}
