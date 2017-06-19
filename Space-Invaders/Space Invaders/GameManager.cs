/*
   The Game manager must be run by the timer and detect collisions for each object
   The manager will need to call and assign new constructors for the objects
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
using System.Threading;
using System.Media;

namespace Assignment
{
    public class GameManager
    {
        private MotherShip ship;
        private Graphics graphics;
        private Size clientSize;
        private List<EnemyShips> enemies;
        private List<Bombs> bombs;
        private List<Missiles> missiles;
        private int mouseLocation = 200;
        private Random random = new Random();
        private bool gameOver = false;
        private bool won = false;
        private int ticks = 0;
        private int points = 0;
        private int count = 0;
        private int nOnScreen = 0;
        private SoundPlayer dead = new SoundPlayer("images\\invaderKilled.wav");

        public GameManager(Graphics graphics, Size clientSize)
        {/*
            Constructor. Create instances and lists
         */
            this.graphics = graphics;
            this.clientSize = clientSize;
            enemies = new List<EnemyShips>();
            bombs = new List<Bombs>();
            missiles = new List<Missiles>();
        }
        public void Run()
        {/*
            Calls all methods with objects needed to run on the timer
         */
            drawBackground();
            if (!won)
            {
                ship.RunMotherShip();
            }
            RunMissiles();
            CollisionMissiles();
            RunEnemies();
            if (enemies.Count <= 0)
            {
                gameOver = true;
                bombs = new List<Bombs>();
                missiles = new List<Missiles>();
            }
            CreateBombs();
            CollisionsBomb();
            RunBombs();
        }

        public void CreateMissiles()
        {/*
            Call this method when the user clicks. Creates a missile at the mouse X location
            Only draw a missile if there isn't already 15 missiles currently on the screen
         */
            if (nOnScreen <= 15)
            {
                missiles.Add(new Missiles(graphics, new Rectangle(new Point(ship.Item.X + 12, ship.Item.Y - 20), new Size(25, 25)), new Point(0, 20), clientSize, true));
                nOnScreen++;
            }
        }
        public void RunMissiles()
        {/*
             Draws and moves all the missiles that are currently alive on the form
             Checks if the missiles have exceeded their lifespan or have gone off the form, then marks the missile as not alive and removes it from the list
         */
            for (int i = 0; i < missiles.Count; i++)
            {

                if (missiles[i].Alive)
                {
                    missiles[i].Draw();
                    missiles[i].Move();
                }

                if (missiles[i].Item.Y <= 0)
                {
                    missiles[i].Alive = false;
                    missiles.Remove(missiles[i]);
                    nOnScreen--;
                }
                //  Increase the ticks
                ticks++;
                int lifeSpan = random.Next(1, 70);
                // If the ticks == the life span, the missile dies
                if (ticks == lifeSpan)
                {
                    missiles[i].Alive = false;
                    missiles.Remove(missiles[i]);
                    nOnScreen--;
                }
                ticks = 0;
            }
        }
        public void CollisionMissiles()
        {
            /*Checks for collision detection between the missiles and the enemies*/
            foreach (Missiles missile1 in missiles)
            {
                if (missile1.Alive)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        EnemyShips enemy1 = enemies[i];
                        if ((missile1.Item.Right > enemy1.Item.Left) && (missile1.Item.Left < enemy1.Item.Right) && (missile1.Item.Top < enemy1.Item.Bottom + 10) && (missile1.Item.Bottom > enemy1.Item.Top - 10))
                        {
                            dead.Play();
                            missile1.Alive = false;
                            //Remove the enemy from the enemy list
                            enemy1.Alive = false;
                            enemies.Remove(enemy1);
                            count--;
                            points += 15;
                        }
                    }
                }
            }
            if (enemies.Count == 0)
            {
                won = true;
            }
        }

        public void RunBombs()
        {/*
            Draw and move the bombs on the screen
         */
            foreach (Bombs bomb in bombs)
            {
                if (bomb.Alive)
                {
                    bomb.Draw();
                    bomb.Move();

                }
                //If the ticks is equal to the random number then the bomb dies
                ticks++;
                int lifespan = random.Next(1, 70);
                if (ticks == lifespan)
                {
                    bomb.Alive = false;
                }
            }

        }
        public void CollisionsBomb()
        {/*
            Checks each bomb to depict whether it has collided with the player
            If collision is true, the game is over
         */
            foreach (Bombs bomb1 in bombs)
            {                                                                       //      For each bomb, if it is alive, draw it and test the edges 
                                                                                    //      of it for collisions with the mother ship
                if (bomb1.Alive)
                {
                    for (int i = 0; i < enemies.Count; i++)
                    {
                        Rectangle ships = new Rectangle(ship.Item.Location, new Size(32, 43));
                        if ((bomb1.Item.Right > ships.Left) && (bomb1.Item.Left < ships.Right) && (bomb1.Item.Top < ships.Bottom) && (bomb1.Item.Bottom > ships.Top))
                        {
                            bomb1.Alive = false;
                            ship.Alive = false;
                            gameOver = true;
                        }
                    }
                }
            }
        }
        public void CreateBombs()
        {/*
             Creating the bombs with a 1/100 chance
             assigning it's position to a random enemies
         */
            int randNumber = random.Next(1, 100);
            int randNum = random.Next(enemies.Count); // Pass this for the random enemy location
            if (randNumber == 99)
            {
                bombs.Add(new Bombs(graphics, new Rectangle(new Point(enemies[randNum].Item.X, enemies[enemies.Count - 1].Item.Bottom), new Size(25, 25)), new Point(0, 15), clientSize, true));
            }
        }


        public void CreateEnemies() 
        { /*
             Create the enemies by giving them a position on the screen 
             Add all enemies to a list so it can be looped through for each enemy to be drawn
          */
            int x = 0;
            int y = 50;
            for (int i = 0; i < 10; i++)
            {
                enemies.Add(new EnemyShips(graphics, new Rectangle(new Point(x, 50), new Size(25, 25)), new Point(15, 0), clientSize, true));
                x += 45;
            }
            x = 0;
            y += 45;
            for (int i = 0; i < 10; i++)
            {
                enemies.Add(new EnemyShips(graphics, new Rectangle(new Point(x, y), new Size(25, 25)), new Point(15, 0), clientSize, true));
                x += 45;
            }
            x = 0;
            y += 45;
            for (int i = 0; i < 10; i++)
            {
                enemies.Add(new EnemyShips(graphics, new Rectangle(new Point(x, y), new Size(25, 25)), new Point(15, 0), clientSize, true));
                x += 45;
            }
            x = 0;
            y += 45;
            for (int i = 0; i < 10; i++)
            {
                enemies.Add(new EnemyShips(graphics, new Rectangle(new Point(x, y), new Size(25, 25)), new Point(15, 0), clientSize, true));
                x += 45;
            }
        }
        public void RunEnemies()
        {/*
             Draw all alive enemies on the screen 
             For each of the enemies that collide with the edges of the screen call the appropriate collisions from the object
             For each of the enemies that collide with the bottom of the screen, the player loses.
         */
            bool collided = false;
            foreach (EnemyShips enemy in enemies)
            {
                if (enemy.Alive)
                {
                    enemy.Move();
                    enemy.Draw();
                }
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
                foreach (EnemyShips enemy1 in enemies)
                {
                    enemy1.ChangeDirection();
                    enemy1.Move();
                }
            }
        }

        public void Mouse(Point p)
        {/*
            Return the location from the form event (e)
            Draw the ship at the mouse location
         */
            if (!gameOver)
            {
                ship = new MotherShip(graphics, new Rectangle(new Point(mouseLocation, 620), new Size(32, 43)));
            }
            mouseLocation = p.X;
        }

        public void ResetEnemies()
        {/*
            Called from form to reset the list of enemies if user starts a new game.
         */
            enemies = new List<EnemyShips>();
        }

        private void drawBackground()
        {/*
            Replace the boring black background with an appropriate background image
         */
            Image image = Image.FromFile(@"images/space.bmp");
            graphics.DrawImage(image, new Point(0, 0));
        }

        public bool GameOver
        {
            get
            {
                return gameOver;
            }

            set
            {
                gameOver = value;
            }
        }
        public bool Won
        {
            get
            {
                return won;
            }

            set
            {
                won = value;
            }
        }
        public int Points
        {
            get
            {
                return points;
            }

            set
            {
                points = value;
            }
        }

        public int NOnScreen
        {
            get
            {
                return nOnScreen;
            }

            set
            {
                nOnScreen = value;
            }
        }
    }
}
