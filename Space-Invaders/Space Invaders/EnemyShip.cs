/*
   Each enemy ship must move side to side on the screen and each time the enemies on the far left/right collide with the left/right side of the form,
   the enemies will drop down a row on the grid and move in the reverse direction.
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

namespace Assignment
{
    public class EnemyShips
    {
        private Image image;
        private Point speed;
        private Bitmap bmp;
        private Graphics graphics;
        private Rectangle item;
        private bool alive;
        private Size clientSize;

        public EnemyShips(Graphics graphics, Rectangle item, Point speed, Size clientSize, bool alive)
        {/*
            Create instances of the enemy ship
            Retrieve the enemy ship from the file
         */
            this.graphics = graphics;
            this.item = item;
            this.clientSize = clientSize;
            this.speed = speed;
            this.alive = alive;
            image = Image.FromFile(@"images/alien.png");
            bmp = new Bitmap(image);
        }
        public void Draw()
        {
            graphics.DrawImage(bmp, item.Location);
        }
        public void Move()
        {
            item.X += speed.X;
            item.Y += speed.Y;
        }
        public void ChangeDirection()
        {
            speed.X = speed.X * -1;
            item.Y += 25;
        }
        public void CollisionEdge()
        {
            foreach (/*Enemy in the fleet's list*/)
            {
                if ((enemy.Item.Left < 0) || (enemy.Item.X + 45 >= clientSize.Width))
                {
                    collided = true;
                }

                if (enemy.Item.Y + 90 > clientSize.Height)
                {
                    gameOver = true;
                }
            }
            if (collided)
            {
                foreach (/*Enemy in the fleet's list*/)
                {
                    enemy1.ChangeDirection();
                    enemy1.Move();
                }
            }
        }
        public void RunEnemies()
        {
            foreach (/*Enemy in fleet's list*/)
	        {
                    Draw();
                    CollisionEdge();
                    Move();
                
	        }
           
            
        }
        public bool Alive
        {
            get
            {
                return alive;
            }

            set
            {
                alive = value;
            }
        }

        public Rectangle Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }
    }
}
