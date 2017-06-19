using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SnakeGame
{
    public class GameManager
    {
        private Snake snake;
        private Grid grid;
        private Random random;
        private Frog frog;
        private int points = 0;

       
        public GameManager(Grid grid, Random random)
        {
           
            this.random = random;
            this.grid = grid;
            frog = new Frog("frog.bmp", grid);
        }

        public void StartNewGame()
        {
            grid.Draw();
            snake = new Snake("snakeEyes.bmp", grid, "snakeSkin.bmp");
            snake.Alive = true;
            frog.Position = FindFreeCell();
        }

        public ErrorMessage PlayGame()
        {
            ErrorMessage message = ErrorMessage.noError;
            if (!frog.Alive)
            {
                frog.Position = FindFreeCell();
                frog.Alive = true;
            }
            grid.Draw();
            if (snake.Alive)
            {
                snake.Draw();
                snake.Move();
            }
            if (frog.Alive)
            {
                frog.Draw();
            }
            if (frog.Position.X == snake.Position[1].X && frog.Position.Y == snake.Position[1].Y)               //          Snake eat frog
            {
                message = ErrorMessage.snakeEatenFrog;
                frog.Alive = false;
                points++;
                snake.Position.Add(frog.Position);
            }
            for (int i = 1; i < snake.Position.Count; i++)                                                  //      Snake Hit Self
            {
                if (snake.Position[0].X == snake.Position[i].X && snake.Position[0].Y == snake.Position[i].Y)
                {
                    snake.Alive = false;
                    message = ErrorMessage.snakeHitSelf;
                }
            }
            if (snake.Position[0].X >= 30 || snake.Position[0].X < 0 || snake.Position[0].Y >= 30 || snake.Position[0].Y < 0)           //  Snake hit wall
            {
                message = ErrorMessage.snakeHitWall;
                snake.Alive = false;   
            }
            
            return message;
        }

        private Point FindFreeCell()
        {
            Point target = Point.Empty;
            Random random = new Random();
            while (target == Point.Empty)
            {
                int i = random.Next(30);
                int j = random.Next(30);

                if (grid.Rows[i].Cells[j].Value == grid.Blank && grid.Rows[i].Cells[j].Value != snake.Position)
                {
                    target = new Point(i, j);
                }
            }

            return target;
        }

        public void SetSnakeDirection(Direction direction)
        {
            snake.Direction = direction;
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

    }
}
