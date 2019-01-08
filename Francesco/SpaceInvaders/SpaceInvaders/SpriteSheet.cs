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
    class SpriteSheet
    {
        public readonly Rectangle INVADER = new Rectangle(51, 3, 11, 8);
        public readonly Rectangle SHIP = new Rectangle(36, 18, 13, 8);
        public readonly Rectangle BULLET = new Rectangle(31, 21, 1, 4);

        private Texture2D _spriteSheet;
        private SpriteBatch _spriteBatch;

        public SpriteSheet(SpriteBatch spriteBatch, ContentManager content)
        {
            _spriteBatch = spriteBatch;
            _spriteSheet = content.Load<Texture2D>("SpriteSheets/spaceInvadersSheet2");
        }

        public void Draw(Rectangle sprite, Vector2 position)
        {
            _spriteBatch.Draw(_spriteSheet, position, sprite, Color.White, 0, new Vector2(0,0), 5.0f, SpriteEffects.None, 0);
        }
    }
}
