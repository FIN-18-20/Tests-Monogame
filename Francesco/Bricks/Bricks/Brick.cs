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
    class Brick
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public bool Visible { get; set; }
        private Color _color;

        private Texture2D _brickImg;
        private SpriteBatch spriteBatch;

        public Brick(float x, float y, Color color, SpriteBatch spriteBatch, GameContent gameContent)
        {
            X = x;
            Y = y;
            _brickImg = gameContent.BrickImg;
            Width = _brickImg.Width;
            Height = _brickImg.Height;
            this.spriteBatch = spriteBatch;
            Visible = true;
            _color = color;
        }

        public void Draw()
        {
            if (Visible)
                spriteBatch.Draw(_brickImg, new Vector2(X, Y), _color);
        }
    }
}
