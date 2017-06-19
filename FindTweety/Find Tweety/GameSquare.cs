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
    public class GameSquare
    {
        private Rectangle bounds;
        private Image image;
        private Graphics graphics;
        private bool filled;
        public GameSquare(Graphics graphics, Rectangle bounds)
        {
            this.graphics = graphics;
            this.bounds = bounds;
            setup();
        }
        public void displayImage()
        {
            graphics.DrawImage(image, bounds.Location);
        }
        public bool findActiveSquare(Point location)
        {
            bool foundSquare = false;
            if (bounds.Contains(location))
            {
                foundSquare = true;
            }
            return foundSquare;
        }
        public void play(bool playerX)
        {
            if (!filled)
            {
                if (playerX)
                {
                    image = Image.FromFile(@"images/sylvester.bmp");
                }
                else
                {
                    image = Image.FromFile(@"images/tweety.bmp");
                }
            }
            displayImage();
            filled = true;
        }
        public void setup()
        {
            image = Image.FromFile(@"images/solid.bmp");
            displayImage();
            filled = false;
        }
    }
}
