using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_TUTO_6.Sprites
{
    public class Bullet : Sprite
    {
        private float _timer;

        public Bullet(Texture2D texture)
            :base(texture)
        {

        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if(_timer > LifeSpan)
            {
                IsRemoved = true;
            }

            Position += Direction * LinearVelocity;
        }
    }
}
