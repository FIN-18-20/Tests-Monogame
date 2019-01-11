using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace FlappyBird_new
{
    public class Bird : GameObject
    {
        // CONST
        private const float FLAP = -6f;
        private const float MAX_SPEED = 15f;
        private const float MAX_ROTATION_VELOCITY = 0.15f;
        private const float MAX_ROTATION = (float)Math.PI / 2f;

        // FIELDS
        private bool gravity;
        private float speedY;
        private float rotationVelocity;
        private float rotation;
        private int currentFrame;
        private int timer;

        // CONSTRUCTOR
        public Bird(int x, int y)
            : base(x, y, new AnimatedSprite("bird", 17, 12, 0, SheetOrientation.HORIZONTAL))
        {
            this.gravity = false;
            this.speedY = 0f;
            this.rotationVelocity = 0f;
            this.rotation = 0f;
            this.currentFrame = 0;
            this.timer = 0;
            this.sprite.SetOrigin(8, 6);
        }

        // METHODS
        public void ActiveGravity()
        {
            this.gravity = true;
        }

        public void SetMaxRotation()
        {
            this.rotation = MAX_ROTATION;
        }

        // UPDATE & DRAW
        public override void Update(GameTime gameTime, Input input)
        {
            base.Update(gameTime, input);

            this.timer += gameTime.ElapsedGameTime.Milliseconds;

            if (this.timer >= 48)
            {
                this.timer = 0;
                if (this.currentFrame == 2)
                    this.currentFrame = 0;
                else
                    ++this.currentFrame;
                ((AnimatedSprite)this.sprite).SetIndex(this.currentFrame);
            }

            if (input != null)
            {
                if (input.IsLeftMousePressed())
                {
                    this.gravity = true;
                    this.speedY = FLAP;
                    this.rotation = -(float)Math.PI / 8f;
                    this.rotationVelocity = -0.15f;
                    //Resources.Sounds["flap"].Play();
                    Resources.Sounds["flap2"].Play();
                }
            }

            if (this.gravity)
            {
                if (this.speedY < MAX_SPEED)
                    this.speedY += 0.25f;

                if (this.rotationVelocity < MAX_ROTATION_VELOCITY)
                    this.rotationVelocity += 0.005f;
                if (this.rotation < MAX_ROTATION)
                {
                    if (this.rotationVelocity > 0f)
                        this.rotation += this.rotationVelocity;
                }
                else
                    this.rotation = MAX_ROTATION;

                this.sprite.SetRotation(this.rotation);
                this.hitbox.Y += (int)this.speedY;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
