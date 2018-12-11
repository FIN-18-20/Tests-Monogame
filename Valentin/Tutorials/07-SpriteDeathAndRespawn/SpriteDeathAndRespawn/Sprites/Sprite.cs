
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpriteDeathAndRespawn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpriteDeathAndRespawn.Sprites
{
    public class Sprite
    {
        protected Texture2D _texure;

        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed;
        public Input Input;
        public bool IsRemoved = false;

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texure.Width, _texure.Height);
            }
        }

        public Sprite(Texture2D texture)
        {
            _texure = texture;
        }

        public virtual void Update(GameTime gameTime, List<Sprite> sprite)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texure, Position, Color.White);
        }
    }
}
