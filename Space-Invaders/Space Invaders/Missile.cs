/*
   The missile will need to be shot from the MotherShip and move vertically upwards and are destroyed if they hit an enemy ship
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
    public class Missiles
    {
        private Image image;
        private Point speed;
        private Bitmap bmp;
        private Graphics graphics;
        private Rectangle item;
        private bool alive;
        private Size clientSize;
        public Missiles(Graphics graphics, Rectangle item, Point speed, Size clientSize, bool alive)
        {/*
            Create instances for the missile
            Retrieve the image from the file
         */
            this.graphics = graphics;
            this.item = item;
            this.clientSize = clientSize;
            this.speed = speed;
            this.alive = alive;
            image = Image.FromFile(@"images/missile.png");
            bmp = new Bitmap(image);
        }
        public void Draw()
        {/*
            Draw the missile to the screen
         */
            graphics.DrawImage(bmp, item.Location);
        }
        public void Move()
        {/*
            Move the missile by decreasing it's Y axis
         */
            item.Y -= speed.Y;
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
