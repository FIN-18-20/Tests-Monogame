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
    class Paddle
    {
        /// <summary>
        /// X position of the paddle on screen
        /// </summary>
        public float X { get; set; }
        /// <summary>
        /// Y position of the paddle on screen
        /// </summary>
        public float Y { get; set; }
        /// <summary>
        /// Width of the paddle
        /// </summary>
        public float Width { get; set; }
        /// <summary>
        /// Height of the paddle
        /// </summary>
        public float Height { get; set; }
        /// <summary>
        /// Width of the game screen
        /// </summary>
        public float ScreenWidth { get; set; }

        private Texture2D _paddleImg { get; set; }
        private SpriteBatch spriteBatch;

        public Paddle(float x, float y, float screenWidth, SpriteBatch spriteBatch, GameContent gameContent)
        {
            this.X = x;
            this.Y = y;
            _paddleImg = gameContent.PaddleImg;
            this.Width = _paddleImg.Width;
            this.Height = _paddleImg.Height;
            this.spriteBatch = spriteBatch;
            this.ScreenWidth = screenWidth;
        }

        public void Draw()
        {
            spriteBatch.Draw(_paddleImg, new Vector2(X, Y), null, Color.White, 0, new Vector2(0, 0), 1.0f, SpriteEffects.None, 0);
        }

        public void MoveLeft()
        {
            X = X - 5;
            if (X < 1)
                X = 1;
        }

        public void MoveRight()
        {
            X = X + 5;
            if ((X + Width) > ScreenWidth)
                X = ScreenWidth - Width;
        }

        public void MoveTo(float x)
        {
            if (x >= 0)
            {
                if (x < ScreenWidth - Width)
                    X = x;
                else
                    X = ScreenWidth - Width;
            }
            else
            {
                if (x < 0)
                    X = 0;
            }
        }
    }
}
