using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace SpaceInvaders
{
    class Ship
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
        
        private SpriteBatch spriteBatch;
        private SpriteSheet _spriteSheet;

        public Ship(float x, float y, float screenWidth, SpriteBatch spriteBatch, SpriteSheet spriteSheet)
        {
            this.X = x;
            this.Y = y;
            _spriteSheet = spriteSheet;
            this.Width = _spriteSheet.SHIP.Width;
            this.Height = _spriteSheet.SHIP.Height;
            this.spriteBatch = spriteBatch;
            this.ScreenWidth = screenWidth;
        }

        public void Draw()
        {
            _spriteSheet.Draw(_spriteSheet.SHIP, new Vector2(X, Y));
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
