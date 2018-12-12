using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEW_TUTO7.Sprites
{
    public class Bullet : Sprite
    {

        public Bullet(Texture2D texture)
            :base(texture)
        {
            Position = new Vector2(250, 250);
            Speed = 5f;
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Position.Y -= Speed;

            if (Rectangle.Top < 0)
                IsRemoved = true;
        }
    }
}
