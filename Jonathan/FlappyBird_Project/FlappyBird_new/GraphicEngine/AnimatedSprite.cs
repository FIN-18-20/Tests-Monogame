using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public enum SheetOrientation
    {
        VERTICAL,
        HORIZONTAL
    }

    public class AnimatedSprite : Sprite
    {
        // FIELDS
        private int spriteWidth;
        private int spriteHeight;
        private int currentIndex;
        private Rectangle sourceRectangle;
        private SheetOrientation orientation;

        // SETTER
        public void SetIndex(int index)
        {
            this.currentIndex = index;

            if (index >= 0)
            {
                if (this.orientation == SheetOrientation.HORIZONTAL)
                {
                    this.sourceRectangle.X = this.currentIndex * this.spriteWidth;
                    this.sourceRectangle.Y = 0;
                }
                else
                {
                    this.sourceRectangle.X = 0;
                    this.sourceRectangle.Y = this.currentIndex * this.spriteHeight;
                }
                this.sourceRectangle.Width = this.spriteWidth;
                this.sourceRectangle.Height = this.spriteHeight;
            }
        }

        // CONSTRUCTOR
        public AnimatedSprite(string imgKey, int spriteWidth, int spriteHeight, int index, SheetOrientation orientation)
            : base(imgKey)
        {
            this.Initialize(imgKey, spriteWidth, spriteHeight, index, orientation, 0, 0);
        }

        public AnimatedSprite(string imgKey, int spriteWidth, int spriteHeight, int index, SheetOrientation orientation, int x, int y)
            : base(imgKey)
        {
            this.Initialize(imgKey, spriteWidth, spriteHeight, index, orientation, x, y);
        }

        private void Initialize(string imgKey, int spriteWidth, int spriteHeight, int index, SheetOrientation orientation, int x, int y)
        {
            this.spriteWidth = spriteWidth;
            this.spriteHeight = spriteHeight;
            this.currentIndex = index;
            this.orientation = orientation;

            this.destinationRectangle = new Rectangle((x + (int)this.origin.X) * Settings.PIXEL_RATIO,
                (y + (int)this.origin.Y) * Settings.PIXEL_RATIO,
                this.spriteWidth * Settings.PIXEL_RATIO,
                this.spriteHeight * Settings.PIXEL_RATIO);

            if (this.orientation == SheetOrientation.HORIZONTAL)
                this.sourceRectangle = new Rectangle(this.currentIndex * this.spriteWidth, 0, this.spriteWidth, this.spriteHeight);
            else
                this.sourceRectangle = new Rectangle(0, this.currentIndex * this.spriteHeight, this.spriteWidth, this.spriteHeight);
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(int x, int y)
        {
            this.destinationRectangle.X = (x + (int)this.origin.X) * Settings.PIXEL_RATIO;
            this.destinationRectangle.Y = (y + (int)this.origin.Y) * Settings.PIXEL_RATIO;
            this.destinationRectangle.Width = this.spriteWidth * Settings.PIXEL_RATIO;
            this.destinationRectangle.Height = this.spriteHeight * Settings.PIXEL_RATIO;

            if (this.orientation == SheetOrientation.HORIZONTAL)
            {
                this.sourceRectangle.X = this.currentIndex * this.spriteWidth;
                this.sourceRectangle.Y = 0;
            }
            else
            {
                this.sourceRectangle.X = 0;
                this.sourceRectangle.Y = this.currentIndex * this.spriteHeight;
            }
            this.sourceRectangle.Width = this.spriteWidth;
            this.sourceRectangle.Height = this.spriteHeight;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.currentIndex >= 0)
                spriteBatch.Draw(this.texture, this.destinationRectangle, this.sourceRectangle, this.color, this.rotation, this.origin, this.imgOrientation, 0f);
        }
    }
}
