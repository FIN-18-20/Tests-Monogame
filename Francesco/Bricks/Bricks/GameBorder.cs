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
    class GameBorder
    {
        public float Width { get; set; }
        public float Height { get; set; }

        private Texture2D _pixelImg;
        private SpriteBatch spriteBatch;

        public GameBorder(float screenWidth, float screenHeight, SpriteBatch spriteBatch, GameContent gameContent)
        {
            Width = screenWidth;
            Height = screenHeight;
            _pixelImg = gameContent.PixelImg;
            this.spriteBatch = spriteBatch;
        }

        public void Draw()
        {
            spriteBatch.Draw(_pixelImg, new Rectangle(0, 0, (int)Width - 1, 1), Color.White);   // Top border
            spriteBatch.Draw(_pixelImg, new Rectangle(0, 0, 1, (int)Height - 1), Color.White); // Left border
            spriteBatch.Draw(_pixelImg, new Rectangle((int)Width - 1, 0, 1, (int)Height - 1), Color.White); // Right border
        }
    }
}
