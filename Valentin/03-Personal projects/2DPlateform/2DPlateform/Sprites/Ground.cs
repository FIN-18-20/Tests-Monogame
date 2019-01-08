using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace _2DPlateform.Sprites
{
    class Ground : Sprite, ICollidable
    {
        public Ground(GraphicsDevice graphics, Texture2D texture)
            : base(graphics, texture)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            base.Draw(gameTime, spriteBatch);
        }

        public void OnCollide(Sprite sprite)
        {
        
        }
    }
}
