using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public abstract class GameObject
    {
        // FIELDS
        protected Rectangle hitbox;
        protected Sprite sprite;

        // GETTERS
        public int X
        {
            get { return this.hitbox.X; }
        }

        public int Right
        {
            get { return this.hitbox.Right; }
        }

        // CONSTRUCTOR
        protected GameObject(int x, int y, Sprite sprite)
        {
            Point textureSize = sprite.GetTextureSize();
            this.hitbox = new Rectangle(x * Settings.PIXEL_RATIO, y * Settings.PIXEL_RATIO, textureSize.X, textureSize.Y);
            this.sprite = sprite;
            this.sprite.Update(x, y);
        }

        // METHODS
        public bool CollisionWith(GameObject obj)
        {
            return this.hitbox.Intersects(obj.hitbox);
        }

        // UPDATE & DRAW
        public virtual void Update(GameTime gameTime, Input input)
        {
            this.sprite.Update(this.hitbox.X / Settings.PIXEL_RATIO, this.hitbox.Y / Settings.PIXEL_RATIO);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            this.sprite.Draw(spriteBatch);
            //spriteBatch.Draw(Resources.Images["ground"], this.hitbox, Color.Red);
        }
    }
}
