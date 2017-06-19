/*
   The user controls the Mother ship. The Mother ship must move side to side on the screen and can shoot missiles at the enemies.
   The user wins the game by destroying all of the enemy ships before getting hit by an enemie's bomb.
   The user loses the game if the mothership is hit by a bomb.
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
    public class MotherShip
    {
        private const int HEIGHT = 25;
        private const int WIDTH = 25;

        private Image image;
        private Bitmap bmp;
        private bool alive;
        private Graphics graphics;
        private Rectangle item;

        public MotherShip(Graphics graphics, Rectangle item)
        {/*
            Create instances of the mothership
            Retrieve the mothership image from the file
         */
            this.item = item;
            this.graphics = graphics;
            alive = true;
            image = Image.FromFile(@"images/ship.png");
            bmp = new Bitmap(image);
        }
        public void Draw()
        {/*
            Draw the image to the screen 
         */
            graphics.DrawImage(bmp, item.Location);

        }
        public void RunMotherShip()
        {
            Draw();
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
