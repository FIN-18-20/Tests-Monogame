using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public enum PipeType
    {
        TOP,
        BOT
    }

    public class Pipe : GameObject
    {
        // FIELDS
        private PipeType pipeType;
        private int timer;
        private bool toDelete;
        private bool isPassed;

        // GETTER
        public PipeType GetPipeType()
        {
            return this.pipeType;
        }

        public bool ToDelete()
        {
            return this.toDelete;
        }

        public bool IsPassed()
        {
            return this.isPassed;
        }

        public void SetPassed()
        {
            this.isPassed = true;
        }

        // CONSTRUCTOR
        public Pipe(int x, int y, PipeType type)
            : base(x, y, new Sprite("pipe_top"))
        {
            this.pipeType = type;
            this.timer = 0;
            this.toDelete = false;
            this.isPassed = false;

            if (type == PipeType.BOT)
                this.sprite.SetOrientation(SpriteEffects.FlipVertically);
        }

        // METHODS

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            while (this.timer >= 1)
            {
                this.timer -= 1;

                this.hitbox.X -= Settings.PIXEL_RATIO;

                if (this.hitbox.X <= -26 * Settings.PIXEL_RATIO)
                    this.toDelete = true;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
