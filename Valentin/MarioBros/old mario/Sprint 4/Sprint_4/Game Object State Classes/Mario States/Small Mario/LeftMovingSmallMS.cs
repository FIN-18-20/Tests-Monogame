﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftMovingSmallMS : IMarioState
    {
        Mario mario;
        public IAnimatedSprite Sprite { get; set; }

        public LeftMovingSmallMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftMovingMarioSmall);
            this.mario = mario;
        }
        public Rectangle GetBoundingBox(Vector2 location)
        {
            return Sprite.GetBoundingBox(location);
        }

        public void TakeDamage()
        {
            if (Game1.GetInstance().isVVVVVV)
            {
                mario.state = new DeadFlipMS(mario);
            }
            else
            {
                mario.state = new DeadMS(mario);
            }
        }
        public void Up()
        {
            mario.state = new LeftJumpingSmallMS(mario);
        }
        public void Down()
        {
            mario.state = new LeftCrouchingSmallMS(mario);
        }
        public void GoLeft()
        {
        }
        public void GoRight()
        {
            mario.state = new RightMovingSmallMS(mario);
        }
        public void Idle()
        {
            mario.state = new LeftIdleSmallMS(mario);
        }
        public void Land()
        {

        }
        public void Fall()
        {
        }
        public void MakeBigMario()
        {
            mario.TransitionState(mario.state, new LeftMovingBigMS(mario));
        }
        public void MakeSmallMario()
        {
            // no-op
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new LeftMovingFireMS(mario));
        }
        public void MakeFireballMario()
        {
            
        }
        public void MakeNinjaMario()
        {
            mario.TransitionState(mario.state, new LeftMovingBigMS(mario));
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Flip() 
        {
            mario.state = new LeftMovingSmallFlipMS(mario);
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location, Color color)
        {
            Sprite.Draw(spriteBatch, location, color);
        }
    }
}
