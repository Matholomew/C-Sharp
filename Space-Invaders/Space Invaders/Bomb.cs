/*
   The bombs are dropped by the enemy ships which move vertically downwards and will destroy the Mother ship of hit by them.
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
    public class Bombs
    {
        private Image image;
        private Point speed;
        private Bitmap bmp;
        private Graphics graphics;
        private Rectangle item;
        private bool alive;
        private Size clientSize;
        public Bombs(Graphics graphics, Rectangle item, Point speed, Size clientSize, bool alive)
        {/*
            Create instances for the bomb
            Retrieve the bomb image from the file
         */
            this.graphics = graphics;
            this.item = item;
            this.clientSize = clientSize;
            this.speed = speed;
            this.alive = alive;
            image = Image.FromFile(@"images/bomb2.bmp");
            bmp = new Bitmap(image);
        }
        public void Draw()
        {/*
            Draw the image to the screen
         */
            graphics.DrawImage(bmp, item.Location);
        }
        public void Move()
        {/*
            Move the bomb by increasing it's Y axis
         */
            item.Y += speed.Y;
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
