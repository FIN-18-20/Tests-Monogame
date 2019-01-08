﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sprint4
{
    class LeftIdleSmallMS : IMarioState
    {
        public IAnimatedSprite Sprite { get; set; }
        Mario mario;

        public LeftIdleSmallMS(Mario mario)
        {
            ISpriteFactory factory = new SpriteFactory();
            Sprite = factory.build(SpriteFactory.sprites.leftIdleMarioSmall);
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
            mario.state = new LeftMovingSmallMS(mario);            
        }
        public void GoRight()
        {
            mario.state = new RightMovingSmallMS(mario);            
        }
        public void Idle()
        {

        }
        public void Land()
        {

        }
        public void Fall()
        {
        }
        public void MakeBigMario()
        {
            mario.TransitionState(mario.state, new LeftIdleBigMS(mario));            
        }
        public void MakeSmallMario()
        {
            // null
        }
        public void MakeFireMario()
        {
            mario.TransitionState(mario.state, new LeftIdleFireMS(mario));            
        }
        public void MakeFireballMario()
        {
            
        }
        public void MakeNinjaMario()
        {
            mario.TransitionState(mario.state, new LeftIdleBigMS(mario));  
        }
        public void MakeDeadMario()
        {
            mario.state = new DeadMS(mario);
        }
        public void Flip() 
        {
            mario.state = new LeftIdleSmallFlipMS(mario);
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
