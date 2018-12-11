using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpriteDeathAndRespawn.Sprites
{
    public class Bomb : Sprite
    {
        public Bomb(Texture2D texture) 
            : base(texture)
        {
            Position = new Vector2(Game1.Random.Next(0, Game1.ScreenWidth - _texure.Width), - _texure.Height);
            Speed = Game1.Random.Next(3, 10); // 3 -> 9
        }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            Position.Y += Speed;

            if (Rectangle.Bottom >= Game1.ScreenHeight) // if we hit the bottom of the window
            {
                IsRemoved = true;
            }
        }
    }
}
