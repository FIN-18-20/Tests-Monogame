using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public class Sprite
    {
        // FIELDS
        protected Texture2D texture;
        protected Rectangle destinationRectangle;
        protected Color color;
        protected float rotation;
        protected Vector2 origin;
        protected SpriteEffects imgOrientation;

        // GETTERS & SETTERS
        public Point GetTextureSize()
        {
            return new Point(this.destinationRectangle.Width, this.destinationRectangle.Height);
        }

        public void SetColor(Color color)
        {
            this.color = color;
        }

        public void SetOrientation(SpriteEffects orientation)
        {
            this.imgOrientation = orientation;
        }

        public void SetRotation(float rotation)
        {
            this.rotation = rotation;
        }

        public void SetOrigin(int x, int y)
        {
            this.origin.X = x;
            this.origin.Y = y;
        }

        // CONSTRUCTOR
        public Sprite(string imgKey)
        {
            this.Initialize(imgKey, 0, 0, SpriteEffects.None);
        }

        public Sprite(string imgKey, int x, int y)
        {
            this.Initialize(imgKey, x, y, SpriteEffects.None);
        }

        public Sprite(string imgKey, int x, int y, SpriteEffects orientation)
        {
            this.Initialize(imgKey, x, y, orientation);
        }

        private void Initialize(string imgKey, int x, int y, SpriteEffects orientation)
        {
            this.texture = Resources.Images[imgKey];
            this.color = Color.White;
            this.rotation = 0f;
            this.imgOrientation = orientation;
            this.origin = new Vector2(0, 0);
            this.destinationRectangle = new Rectangle((x + (int)this.origin.X) * Settings.PIXEL_RATIO,
                (y + (int)this.origin.Y) * Settings.PIXEL_RATIO,
                this.texture.Width * Settings.PIXEL_RATIO,
                this.texture.Height * Settings.PIXEL_RATIO);
        }

        // METHODS

        // UPDATE & DRAW
        public virtual void Update(int x, int y)
        {
            this.destinationRectangle.X = (x + (int)this.origin.X) * Settings.PIXEL_RATIO;
            this.destinationRectangle.Y = (y + (int)this.origin.Y) * Settings.PIXEL_RATIO;
            this.destinationRectangle.Width = this.texture.Width * Settings.PIXEL_RATIO;
            this.destinationRectangle.Height = this.texture.Height * Settings.PIXEL_RATIO;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.texture, this.destinationRectangle, null, this.color, this.rotation, this.origin, this.imgOrientation, 0f);
        }
    }
}
