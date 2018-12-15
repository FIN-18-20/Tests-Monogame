using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Bricks
{
    class Wall
    {
        /// <summary>
        /// 7 rows, 10 bricks per row, 3 blank rows at the top, each brick is 50 x 16
        /// </summary>
        public Brick[,] BrickWall { get; set; }

        public Wall(float x, float y, SpriteBatch spriteBatch, GameContent gameContent)
        {
            BrickWall = new Brick[7, 10];
            float brickX = x;
            float brickY = y;
            Color color = Color.White;

            /*  Rainbow loop    */
            for(int i = 0; i < 7; i++)
            {
                switch(i)
                {
                    case 0:
                        color = Color.Red;
                        break;
                    case 1:
                        color = Color.Orange;
                        break;
                    case 2:
                        color = Color.Yellow;
                        break;
                    case 3:
                        color = Color.Green;
                        break;
                    case 4:
                        color = Color.Blue;
                        break;
                    case 5:
                        color = Color.Indigo;
                        break;
                    case 6:
                        color = Color.Violet;
                        break;
                }
                brickY = y + i * (gameContent.BrickImg.Height + 1);

                for (int j = 0; j < 10; j++)
                {
                    brickX = x + j * (gameContent.BrickImg.Width);
                    Brick brick = new Brick(brickX, brickY, color, spriteBatch, gameContent);
                    BrickWall[i, j] = brick;
                }
            }
        }   // End Wall()

        public void Draw()
        {
            foreach (Brick brick in BrickWall)
            {
                brick.Draw();
            }
        }
    }
}
