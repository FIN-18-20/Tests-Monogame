using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public abstract class MenuBase
    {
        // FIELDS
        protected Sprite background;
        protected Ground ground;

        // CONSTRUCTOR
        protected MenuBase()
        {
            this.background = new Sprite("background");
            this.ground = new Ground(0, 200);
        }

        // METHODS

        // UPDATE & DRAW
        public virtual void Update(GameTime gameTime, Input input, Game1 game)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.background.Draw(spriteBatch);
            this.ground.Draw(spriteBatch);
        }
    }
}
