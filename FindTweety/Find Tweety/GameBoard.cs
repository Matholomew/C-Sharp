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
    public class GameBoard
    {
        private const int NROWS = 3;
        private const int NCOLS = 3;
        private const int SQUARESIZE = 100;
        private List<GameSquare> gameSquares;
        private bool playerX;
        private Random random = new Random();
        public GameBoard(Graphics graphics)
        {
            playerX = true;
            gameSquares = new List<GameSquare>();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    int left = i * SQUARESIZE;
                    int top = j * SQUARESIZE;
                    Rectangle bounds = new Rectangle(left, top, SQUARESIZE, SQUARESIZE);
                    GameSquare gs = new GameSquare(graphics, bounds);
                    gameSquares.Add(gs);
                }
            }
        }
        public void SetupNewGame()
        {
            foreach (GameSquare gameSquare in gameSquares)
            {
                gameSquare.setup();
            }
            playerX = true;
        }
        public void PlayThisSquare(Point mouseLocation)
        {
            int winIndex = random.Next(gameSquares.Count);
            int loseIndex = random.Next(gameSquares.Count);
            while (winIndex == loseIndex)
            {
                loseIndex = random.Next(gameSquares.Count);
            }

          //  gameSquares[winIndex] = eSquareType.WIN;              Needs to be gameSquares[winIndex].Type  |   Type being either sylvester or tweety
          //  gameSquares[loseIndex] = eSquareType.LOSE;                      
            foreach (GameSquare gameSquare1 in gameSquares)
            {
                if (gameSquare1.findActiveSquare(mouseLocation))
                {
                    gameSquare1.play(playerX);
                    playerX = !playerX;
                }
            }
        }
    }
}
