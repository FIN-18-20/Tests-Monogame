using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2DPlateform.Sprites
{
    public class Bullet : Sprite, ICollidable
    {
        private float _timer;

        public float LifeSpan { get; set; }

        public Vector2 Velocity { get; set; }

        public Bullet(GraphicsDevice graphics, Texture2D texture)
            : base(graphics, texture)
        {

        }

        public override void Update(GameTime gameTime)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (_timer >= LifeSpan)
                IsRemoved = true;

            Position += Velocity;
        }

        public void OnCollide(Sprite sprite)
        {
        }
    }
}
